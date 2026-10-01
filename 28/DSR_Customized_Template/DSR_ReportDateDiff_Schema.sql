-- Report Settings -> Date Comparison
-- One row per (From Date field, To Date field) pair configured for a template.
-- Follows the same shape/conventions as DSR_ReportFilter/Group/Sort/Summary
-- (see TemplateBuilder.aspx.cs / TemplateReport.aspx.cs).
-- Run this once against each company database that uses Report Settings.

CREATE TABLE DSR_ReportDateDiff (
    DateDiffID   INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    TemplateID   INT NOT NULL,
    Label        NVARCHAR(200) NOT NULL,
    FromFieldID  INT NOT NULL,
    ToFieldID    INT NOT NULL,
    DisplayOrder INT NOT NULL,
    CONSTRAINT FK_DSR_ReportDateDiff_Template FOREIGN KEY (TemplateID)
        REFERENCES DSR_Template (TemplateID),
    -- NO ACTION (the default) to match DSR_ReportFilter/Group/Sort/Summary -
    -- SaveTemplate.cs explicitly clears out-of-date rows here itself when a
    -- field is removed, rather than relying on a cascading delete.
    CONSTRAINT FK_DSR_ReportDateDiff_FromField FOREIGN KEY (FromFieldID)
        REFERENCES DSR_TemplateField (FieldID),
    CONSTRAINT FK_DSR_ReportDateDiff_ToField FOREIGN KEY (ToFieldID)
        REFERENCES DSR_TemplateField (FieldID)
);
GO

CREATE INDEX IX_DSR_ReportDateDiff_TemplateID ON DSR_ReportDateDiff (TemplateID);
GO
