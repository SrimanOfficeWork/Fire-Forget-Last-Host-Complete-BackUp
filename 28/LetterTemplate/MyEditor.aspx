<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyEditor.aspx.cs" Inherits="LetterTemplate_MyEditor" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../js/LetterTemplate/jquery-3.0.0.min.js" type="text/javascript"></script>
    <link href="../css/LetterTemplate/TextEditor.css" rel="stylesheet" type="text/css" />
    <script src="../js/LetterTemplate/jspdf.min.js" type="text/javascript"></script>
    <script src="../js/LetterTemplate/TextEditor.js" type="text/javascript"></script>

    <%--------------------------------------------------------------------------------------------%>
    <%--------------------------------------------------------------------------------------------%>
</head>
<body>
    <form id="form1" runat="server">
    <div id="innerbox_MidMain_Transact_popup_new">
                <div id="tag_srcinner1_new">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                        Letter Template
                    </div>
                    <div id="popupwindow_closebut_right_new">
                       <%-- <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();RefreshParent();return false;" />--%>
                        <input type="close" value="Submit" class="clsicon" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                </div>
                <div id="tag_transact_src_inner" style="width: 965px">
                    <div id="tag_Exchange_inner_lft" style="width: 965px">
                            <div id="tag_transact_lft_in1" style="width: 950px; margin-top: 10px;"> 
                                <div id="tag_label_transaction_exp_jobb" style="width: 40px">
                                   Jobno
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 130px;">
                                    <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="listtxt_transac_src1" Width="130px">
                                    </asp:DropDownList>
                                </div>
                               
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 70px">
                                     <input type="radio" id="rdoCreateTemplate" name="templatePage" value="createtemplate" /> Create
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 70px">
                                   <input type="radio" id="rdoGenerateTemplate" name="templatePage"  value="generatetemplate"/>Modify
                                </div>
                                 <div id="tag_label_transaction_exp_jobb" style="width: 70px">
                                   <input type="radio" id="rdoReportTemplate" name="templatePage"  value="reporttetemplate"/>Report
                                </div>

                                  <div id="verslic"> </div>
                         
                                <div id="divGenerateTemplate" class="templateHeaderSection" >
                                    <table>
                                        <tr>
                                            <td>
                                                Template Names:
                                            </td>
                                            <td>
                                                <select id="ddlTemplateNames" name="ddlTemplateNames" runat="server">
                                                </select>
                                            </td>
                                            <td>
                                                <input id="btnGenerateTemplate" type="button" value="Generate" />
                                                <input id="btnPdf" type="button" value="Download PDF" />
                                            </td>
                                            
                                        </tr>
                                    </table>
                                </div>
                                <div id="divCreateTemplate" class="templateHeaderSection" >
                                    <table>
                                        <tr>
                                            <td>
                                                Template Name:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTemplateName" runat="server"></asp:TextBox>
                                            </td>
                                            <%--<td>
                                                <a href="#" id="aViewVariable">View Variables</a>
                                                <div id="divVariables" class="tree">
                                                    <button id="all">
                                                        Toggle All</button>
                                                    <button id='btnVariableClose' name='btnVariableClose'>
                                                        Close
                                                    </button>
                                                </div>
                                            </td>--%>
                                        </tr>
                                    </table>
                                </div>
                                <div id="divVar"  class="TempCommon">
                                <table>
                                        <tr>
                                        <td>
                                                <a href="#" id="aViewVariable">View Variables</a>  
                                                <div id="divVariables" class="tree">
                                                    <button id="all">
                                                        Toggle All</button>
                                                    <button id='btnVariableClose' name='btnVariableClose'>
                                                        Close
                                                    </button>
                                                </div>
                                            </td>
                                        </tr>
                                        </table>
                                </div>


                               

                        </div>
                    </div>


                </div>
            </div>


        <div id="divTextEditor">
            <div class="clearBoth"></div>
            <div class="clearBoth"></div>
             <div style="height:10px">
            </div>
            <CKEditor:CKEditorControl ID="CKEditor1" BasePath="../ckeditor/" runat="server" Height="310px">
            </CKEditor:CKEditorControl>

             <div class="templateFooterSection" style="text-align:right">
                 <input type="button" id="btnnew"  value="New" />
                 <input type="button" id="btnSave"  value="Save" />
                 <input type="button" id="btnUpdate"  value="Update" />
                 <input type="button" id="btnClear"  value="Clear" />
                 <input type="button" id="btnDelete"  value="Delete" />
            </div>
            <div id="htmlSource" style="display:none"></div>
        </div>
    </form>
   
    <script src="../js/Validation.js" type="text/javascript"></script>
   
</body>
</html>
