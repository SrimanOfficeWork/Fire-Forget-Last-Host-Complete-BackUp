using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;


public class E_LOGIX
{
    DataSet ds = new DataSet();

    public int result, UPDATE_ID = 0;

    public DataSet Select_IMP_EXP(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@Jobno",objUserBL.JOBNO);
            param[2] = new SqlParameter("@BRANCH_COMMON",Connection.Get_Company_Type());
            param[3] = new SqlParameter("@TYPE", objUserBL.File_Type);
            param[4] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[5] = new SqlParameter("@User", Connection.Current_User());
            param[6] = new SqlParameter("@Ename", objUserBL.Ename);
            param[7] = new SqlParameter("@Flag", objUserBL.flag);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            if (objUserBL.File_Type == "E")
            {
                ds = Connection.Get_Dataset("E_LOGIX_FF_EXP_DATA_SERVICES", param);
            }
            else if (objUserBL.File_Type == "I")
            {
                ds = Connection.Get_Dataset("E_LOGIX_FF_IMP_DATA_SERVICES", param);  //E_LOGIX_FF_IMP_EXP_DATA_SERVICES
            }
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }



    public DataSet Select_IMP_EXP_INVO_SYS(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[2] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[3] = new SqlParameter("@TYPE", objUserBL.File_Type);
            param[4] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[5] = new SqlParameter("@User", Connection.Current_User());
            param[6] = new SqlParameter("@Ename", objUserBL.Ename);
            param[7] = new SqlParameter("@Flag", objUserBL.flag);
            param[8] = new SqlParameter("@Company_Lic", Connection.Company_License());

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            if (objUserBL.File_Type == "E")
            {
                ds = Connection.Get_Dataset("INVO_SYS_FF_EXP_DATA_SERVICES", param); //E_LOGIX_FF_EXP_DATA_SERVICES
            }
            else if (objUserBL.File_Type == "I")
            {
                ds = Connection.Get_Dataset("INVO_SYS_FF_IMP_DATA_SERVICES", param);  //E_LOGIX_FF_IMP_EXP_DATA_SERVICES
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }



    public void E_logic_Update(string Jobno, string File_Type, string Ename)
    {
        string E_Logix_Company_Id = Connection.e_lOGIX_CHENNAI();
        if (E_Logix_Company_Id != string.Empty)
        {
            IMPL.ELOGIX_CS obj = new IMPL.ELOGIX_CS();
            UserBO ObjUBO = new UserBO();
            ObjUBO.JOBNO = Jobno;
            ObjUBO.File_Type = File_Type; //I E
            ObjUBO.Ename = Ename; //U D
            ObjUBO.flag = "Update_Elogix_Data";
            Select_IMP_EXP(ObjUBO);

            if (File_Type == "I" && Ename == "D")
            {
                
                obj.ImportPlanning(
                        Jobno
                       , ""
                       , ""
                       , ""
                       , ""
                       , ""
                       , ""
                       , ""
                       , ""
                       , ""
                       , ""
                       , ""
                       , ""
                        , ""
                        , ""
                        , ""
                        , ""
                        , ""
                        , ""
                        , ""
                        , ""                        
                       , E_Logix_Company_Id
                       , ""
                       , ""
                       , ""
                       , Connection.WorkingPeriod()
                       , "D"
                        , ""
                         , ""
                         , ""
                         , ""
                         , ""
                         , ""
                         , ""
                         , ""
                         , ""
                         , ""
                         , ""
                         , ""
                         , ""

                          , ""
                           , ""
                            , ""
                             , ""
                              , ""
                               , ""
                                , ""
                                 , ""
                               
                                 , ""
                                 , ""
                                 , ""
                                
                                
                       );
            }
            else if (File_Type == "E" && Ename == "D")
            {
            obj.ExportPlanning(
                              ""
                             , Jobno
                             , ""
                             , ""
                             , ""
                             , ""
                             , ""
                             , ""
                             , ""
                             , ""
                             , ""
                             , ""
                             , ""
                             , ""
                             , ""
                             , ""
                             , E_Logix_Company_Id
                             , Connection.Get_Company_Type()
                             , ""
                             , Connection.WorkingPeriod()
                             , ""
                             , ""
                             , "D"
                              , ""
                               , ""
                                , ""
                                 , ""

                                 , ""
                                  , ""
                                   , ""
                                    , ""
                                    
                                    , ""
                                    , ""
                                    , ""
                                    , ""
                                 , ""
                                  
                             );
            }


        }

        
        
    }
}