-- Adds ONE new flag, DOCKER_VISION_TIMEOUT, to the existing procedure. No existing flag or column is changed.
-- Run on every company database that has PDF_AI_QUEUE. Take a backup / keep PDF_AI_QUEUE_INSERT_UPDATE_SELECT.original.sql for rollback.
ALTER PROCEDURE [dbo].[PDF_AI_QUEUE_INSERT_UPDATE_SELECT]
(
    @QUEUE_ID        INT              = 0,
    @JOB_NO          NVARCHAR(MAX)    = '',
    @FILE_NAME       NVARCHAR(255)    = '',
    @COMPANY_ID      NVARCHAR(50)     = '',
    @USER_ID         NVARCHAR(50)     = '',
    @BRANCH_CODE     NVARCHAR(50)     = '',
    @WORKING_PERIOD  NVARCHAR(50)     = '',
    @VENDOR_TYPE     NVARCHAR(50)     = '',
    @PROCESS_ID      NVARCHAR(255)    = '',
    @STATUS          NVARCHAR(30)     = '',
    @JSON_RESPONSE   NVARCHAR(MAX)    = '',
    @IMPORTER_NAME   NVARCHAR(255)    = '',
    @FROM_DATE       NVARCHAR(20)     = '',
    @TO_DATE         NVARCHAR(20)     = '',
    @Branch_Common   NVARCHAR(50)     = '',
    @COMPANY_LICENSE NVARCHAR(50)     = '',
    @JOB_TYPE        NVARCHAR(10)     = '',   -- NEW: 'IMP' / 'EXP' / '' (both)
    @MFLAG           NVARCHAR(50)     = '',
    @startRowIndex   NVARCHAR(10)     = '1',
    @maximumRows     NVARCHAR(10)     = '10',
    @SL_NO     int     = 0,
    @PDF_CLIENT_NAME     VARCHAR(100)     = '',
    @TIMEOUT_MINUTES INT             = 0,   -- used only by DOCKER_VISION_TIMEOUT
    @totalRows       INT              = 0 OUTPUT,
    @ErrorMsg        NVARCHAR(1000)   = '' OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    -- ── INSERT ──────────────────────────────────────────────────────
    IF @MFLAG = 'INSERT'
    BEGIN
		DECLARE @NextNo BIGINT;
        DECLARE @VendorType VARCHAR(50);
        DECLARE @PdfId VARCHAR(50);


        IF CHARINDEX('-', @VENDOR_TYPE) > 0
        BEGIN
            SET @VendorType = LEFT(@VENDOR_TYPE, CHARINDEX('-', @VENDOR_TYPE) - 1);
            SET @PdfId = SUBSTRING(@VENDOR_TYPE,
                                   CHARINDEX('-', @VENDOR_TYPE) + 1,
                                   LEN(@VENDOR_TYPE));
        END
        ELSE
        BEGIN
            SET @VendorType = @VENDOR_TYPE;
            SET @PdfId = '';
        END


		SELECT @NextNo = ISNULL(
			MAX(CAST(REPLACE(JOB_NO, 'TEMP_', '') AS BIGINT))
		, 0) + 1
		FROM PDF_AI_QUEUE
		WHERE JOB_NO LIKE 'TEMP_%'
		  AND ISNUMERIC(REPLACE(JOB_NO, 'TEMP_', '')) = 1;

		SET @JOB_NO = 'TEMP_' + CAST(@NextNo AS VARCHAR(20));
        INSERT INTO PDF_AI_QUEUE
        (
            JOB_NO, FILE_NAME, COMPANY_ID, USER_ID,
            BRANCH_CODE, WORKING_PERIOD, VENDOR_TYPE,
            PROCESS_ID, STATUS, IMPORTER_NAME, JOB_TYPE, CREATED_DATE,SL_NO,PDF_CLIENT_NAME,PDF_ID
        )
        VALUES
        (
            @JOB_NO, @FILE_NAME, @COMPANY_ID, @USER_ID,
            @BRANCH_CODE, @WORKING_PERIOD,  @VendorType,
            @PROCESS_ID, 'IN PROGRESS', @IMPORTER_NAME, 
            CASE WHEN @JOB_TYPE = '' THEN 'IMP' ELSE @JOB_TYPE END,
            GETDATE(),@SL_NO,@PDF_CLIENT_NAME,@PdfId
        )
        SET @ErrorMsg = 'SUCCESS'
    END

    -- ── UPDATE STATUS ────────────────────────────────────────────────
    ELSE IF @MFLAG = 'UPDATE_STATUS'
    BEGIN
        UPDATE PDF_AI_QUEUE
        SET
            STATUS        = @STATUS,
            JSON_RESPONSE = CASE WHEN @JSON_RESPONSE != '' THEN @JSON_RESPONSE ELSE JSON_RESPONSE END,
            UPDATED_DATE  = GETDATE()
        WHERE PROCESS_ID  = @PROCESS_ID
        SET @ErrorMsg = 'SUCCESS'
    END

    -- ── DELETE SINGLE ────────────────────────────────────────────────
    ELSE IF @MFLAG = 'DELETE'
    BEGIN
        DELETE FROM PDF_AI_QUEUE WHERE QUEUE_ID = @QUEUE_ID
        SET @ErrorMsg = 'SUCCESS'
    END

    -- ── DELETE MULTIPLE ──────────────────────────────────────────────
    ELSE IF @MFLAG = 'DELETE_MULTIPLE'
    BEGIN
        DELETE FROM PDF_AI_QUEUE
        WHERE QUEUE_ID IN (
            SELECT CONVERT(INT, value)
            FROM dbo.SplitString(@JOB_NO, ',')
        )
        SET @ErrorMsg = 'SUCCESS'
    END

    -- ── COUNT ONLY — for summary cards ───────────────────────────────
    -- JOB_TYPE filter: '' = both, 'IMP' = import only, 'EXP' = export only
    ELSE IF @MFLAG = 'COUNT_ONLY'
    BEGIN
        SELECT @totalRows = COUNT(*)
        FROM PDF_AI_QUEUE
        WHERE
            (@STATUS   = '' OR STATUS   = @STATUS)
            AND (@JOB_TYPE = '' OR JOB_TYPE = @JOB_TYPE)
        SET @ErrorMsg = 'SUCCESS'
    END

    -- ── GRID DATA ────────────────────────────────────────────────────
    ELSE IF @MFLAG = 'GRID_DATA'
    BEGIN
        DECLARE @StartRow INT = (CONVERT(INT, @startRowIndex) - 1) * CONVERT(INT, @maximumRows) + 1
        DECLARE @EndRow   INT = CONVERT(INT, @startRowIndex) * CONVERT(INT, @maximumRows)

        SELECT @totalRows = COUNT(*)
        FROM PDF_AI_QUEUE
        WHERE
            (@JOB_NO      = '' OR JOB_NO      LIKE '%' + @JOB_NO + '%')
            AND (@VENDOR_TYPE = '' OR VENDOR_TYPE  = @VENDOR_TYPE)
            AND (@STATUS      = '' OR STATUS        = @STATUS)
            AND (@JOB_TYPE    = '' OR JOB_TYPE      = @JOB_TYPE)
            AND (@FROM_DATE   = '' OR CONVERT(DATE, CREATED_DATE) >= CONVERT(DATE, @FROM_DATE))
            AND (@TO_DATE     = '' OR CONVERT(DATE, CREATED_DATE) <= CONVERT(DATE, @TO_DATE))

        SELECT *
        FROM
        (
            SELECT
                QUEUE_ID, JOB_NO, FILE_NAME, IMPORTER_NAME,SL_NO,
                VENDOR_TYPE, PROCESS_ID, STATUS, JOB_TYPE,
                CONVERT(NVARCHAR(20), CREATED_DATE, 103) + ' ' +
                CONVERT(NVARCHAR(8),  CREATED_DATE, 108) AS CREATED_DATE,
                CASE WHEN UPDATED_DATE IS NULL THEN ''
                     ELSE CONVERT(NVARCHAR(20), UPDATED_DATE, 103) + ' ' +
                          CONVERT(NVARCHAR(8),  UPDATED_DATE, 108)
                END AS UPDATED_DATE,
                ROW_NUMBER() OVER (ORDER BY CREATED_DATE DESC) AS ROWNUM
            FROM PDF_AI_QUEUE
            WHERE
                (@JOB_NO      = '' OR JOB_NO      LIKE '%' + @JOB_NO + '%')
                AND (@VENDOR_TYPE = '' OR VENDOR_TYPE  = @VENDOR_TYPE)
                AND (@STATUS      = '' OR STATUS        = @STATUS)
                AND (@JOB_TYPE    = '' OR JOB_TYPE      = @JOB_TYPE)
                AND (@FROM_DATE   = '' OR CONVERT(DATE, CREATED_DATE) >= CONVERT(DATE, @FROM_DATE))
                AND (@TO_DATE     = '' OR CONVERT(DATE, CREATED_DATE) <= CONVERT(DATE, @TO_DATE))
        ) AS PaginatedResult
        WHERE ROWNUM BETWEEN @StartRow AND @EndRow
        SET @ErrorMsg = 'SUCCESS'
    END

    -- ── GET BY PROCESS ID ────────────────────────────────────────────
    ELSE IF @MFLAG = 'GET_BY_PROCESS_ID'
    BEGIN
        SELECT
            QUEUE_ID, JOB_NO, FILE_NAME, IMPORTER_NAME,SL_NO,
            VENDOR_TYPE, PROCESS_ID, STATUS, JSON_RESPONSE, JOB_TYPE,
            CONVERT(NVARCHAR(20), CREATED_DATE, 103) AS CREATED_DATE,PDF_ID
        FROM PDF_AI_QUEUE
        WHERE PROCESS_ID = @PROCESS_ID
        SET @ErrorMsg = 'SUCCESS'
    END
    ELSE IF @MFLAG = 'UPDATE_JOBNO'
        BEGIN
            UPDATE PDF_AI_QUEUE SET JOB_NO = @JOB_NO WHERE PROCESS_ID = @PROCESS_ID;

            DECLARE @QueuePdfId INT;

            SELECT @QueuePdfId = PDF_ID  FROM PDF_AI_QUEUE WHERE PROCESS_ID = @PROCESS_ID;

            UPDATE PDF_AI_COUNT_DETAILS  SET PDF_PROCESS_STATUS = 'UPLOAD SUCCESS' WHERE PDF_ID = @QueuePdfId;

            SET @ErrorMsg = 'SUCCESS';
        END


    -- ── DOCKER VISION TIMEOUT ────────────────────────────────────────
    -- Marks Docker Vision jobs that are still IN PROGRESS after @TIMEOUT_MINUTES as FAILED.
    -- The marker "Source":"Timeout" lets the worker overwrite this row if the real response arrives late.
    ELSE IF @MFLAG = 'DOCKER_VISION_TIMEOUT'
    BEGIN
        UPDATE PDF_AI_QUEUE
        SET STATUS        = 'FAILED',
            JSON_RESPONSE = CASE WHEN ISNULL(JSON_RESPONSE, '') = ''
                                 THEN '{"Status":"Failed","Source":"Timeout","Reason":"No response received from Docker Vision within '
                                      + CAST(@TIMEOUT_MINUTES AS NVARCHAR(10)) + ' minutes"}'
                                 ELSE JSON_RESPONSE END,
            UPDATED_DATE  = GETDATE()
        WHERE STATUS      = 'IN PROGRESS'
          AND VENDOR_TYPE = 'DOCKER_VISION'
          AND @TIMEOUT_MINUTES > 0
          AND CREATED_DATE < DATEADD(MINUTE, -@TIMEOUT_MINUTES, GETDATE());

        SET @totalRows = @@ROWCOUNT;
        SET @ErrorMsg  = 'SUCCESS';
    END
END

GO
