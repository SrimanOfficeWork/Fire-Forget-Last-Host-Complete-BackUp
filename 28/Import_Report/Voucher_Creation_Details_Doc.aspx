<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Voucher_Creation_Details_Doc.aspx.cs" Inherits="Import_Report_Voucher_Creation_Details_Doc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../main.css" rel="stylesheet" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
    </style>
    <style >
        .txt{
        list-style: none;
            /*background-color:#f5f5f5;*/
            border: 0px solid  #dedede;
          

font-family:Arial,Helvetica,sans-serif;
font-size:14px;
height:20px;


min-width:525px;
max-width:525px;

background-color: #FFFFFF;

vertical-align: baseline;
background-image:url(images/grid_Row_2_bit.gif);
background-repeat:repeat-x;
background-position:top;
border-left:#c8c8c8 solid thin;
border-right:#c8c8c8 solid thin;
border-bottom:#c8c8c8 solid thin;
font-family:Arial, Helvetica, sans-serif;
font-size:12px;
font-weight:normal;
color:#232323;
text-align:left;
line-height:1.5em;
}
       
        .textarea
        {
            list-style: none;
            /*background-color:#f5f5f5;*/
            border: 1px dotted #dedede;
            text-indent: 25px;
            height: auto;
            padding: 10px;
            text-transform: capitalize;
            
        }
      
        .lines
        {
             border-left: 1px solid #ffaa9f;
            border-right: 1px solid #ffaa9f;
            width: 2px;
            float: left;
            height:20px;
            margin-left: 0px;
        }
        
     
    </style>
    
</head>
<body>
    <form id="form1" runat="server" >
  
  <span id="Page_Lock" runat="server" disabled="disabled" >

             <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>

      <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
  <div id="innerbox_MidMain_Transact_popup_new" style="height:25px; width:650px;">
                <div id="tag_srcinner1_new">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                       Voucher Creation Documents Required
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="parent.adcodewindow.hide();RefreshParent();return false;" />
                    </div>
                   
                </div>

             
                
        
            </div>

             <div class="content" id="page-1">
               <%--<div id="innerbox_MidMain_Trans_new" style="height: 320px; width:485px;margin-top:-10px;margin-left:-10px"> --%>
               
                 <div id="innerbox_MidMain_Transact_popup_new" 
                     style="height:500px; width:650px;">
                     <div id="tag_transact_lft_in1" 
                         style="margin-left: 15px;  margin-top: 10px; width: 600px;">


                      <div id="tag_label_Clientname" style="width: 60px">
                             Customer
                            </div>
                            <div id="txtcon-m_src" style="width: 205px">
                                <asp:TextBox ID="txt_dirname" runat="server"  CssClass="txtbox_none_Mid_transac_code"
                                    ClientIDMode="Static" TabIndex="1"   Width="200px"></asp:TextBox>

                            </div>
                            <div id="txtcon-r_src" style="width:10px">
                            </div>
                             <%-- <div id="tag_label_Clientname" style="width: 100px">
                               Doc Required
                            </div>
                             <asp:DropDownList ID="ddl_Record_Status" runat="server"   AutoPostBack="true"
                                        CssClass="listtxt_transac_FCL" Width="200px" TabIndex="2">
                                 
                                </asp:DropDownList>
                                 <div id="txtcon-m_src">
                                <asp:TextBox ID="txt_docs" runat="server"  CssClass="txtbox_none_Mid_transac_code"
                                    ClientIDMode="Static" TabIndex="2"   Width="200px"></asp:TextBox>

                            </div>--%>
                    </div>
                       <div id="tag_transact_lft_in1" 
                         style="margin-left: 15px;  margin-top: 10px; margin-bottom: 10px;">
                      <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:Button ID="btn_Upload" runat="server" Text="Upload" OnClick="btn_Upload_Click" OnClientClick="return GetFileSize('FileUpload1');"/>
                    </div>
                     <asp:Button ID="btn_File_Delete" runat="server"  CausesValidation="false" style="display:none;"
                                            UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jConfirm('Delete this File?', 'Voucher_Creation_Doc_Upload', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn1').click();
            
          }
          else {
          }
    
});return false;" />
                                        <asp:Button ID="btn1" runat="server"  OnClick="btn_File_Delete_Click" CausesValidation="false"
                                            UseSubmitBehavior="false" 
                                            CssClass="dlete" Style="display: none;" />
                        <div style="width: 400px; height: 300px; overflow: auto;">
                            <asp:GridView ID="gvdetails" runat="server" ShowHeader="true" Width="390px" AllowPaging="True"
                                AllowSorting="True" AutoGenerateColumns="false" OnRowCreated="gvdetails_RowCreated"
                                BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" 
                                CellPadding="1" CellSpacing="1"
                                EmptyDataText="NO RECORD FOUND" PageSize="10" ShowHeaderWhenEmpty="True" CssClass="grid-view"
                                OnRowDataBound="gvdetails_RowDataBound" 
                                OnPageIndexChanging="gvdetails_PageIndexChanging">
                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    BorderWidth="1px" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <div style="width: 10px;">
                                                <asp:CheckBox ID="chkAll" runat="server" onclick="javascript:SelectheaderCheckboxes(this,'gvdetails','btn_File_Delete')" />
                                            </div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="File">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="txtdate" runat="server" Text='<%#Eval("Imp_DOCUMENTS_NAME")%>'
                                                OnClick="lnkDownload_Click"> </asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="350px" CssClass="column_style_left" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="IMP_DOC_ID">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IMP_DOCUMENTS_NAME">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    
                                </Columns>
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                    NextPageText="Next" Position="Top" PreviousPageText="Previous" />
                            </asp:GridView>
                        </div>
            
             <asp:Button ID="btnMySubmitButton" UseSubmitBehavior="true" runat="server" Text="Click or press Enter" style="display:none;" OnClientClick="sd();" />
         
             <%--   <asp:Button ID="btn_Save"  runat="server" Text="Add" OnClick="btn_Save_Click" style="display:none;"/>
                <asp:Button ID="btn_Add1"  runat="server" Text="Add" OnClick="btn_Add_Click" style="display:none;"/>--%>
    <asp:HiddenField ID="hidden_path" runat="server" />
     <asp:HiddenField ID="HiddenField1" runat="server" />
     <asp:HiddenField ID="HiddenDoc" runat="server" />

    </div>

    
    </div>
      </ContentTemplate>
    </asp:UpdatePanel>

    </span>
    </form>
    
    <script  type="text/javascript">

        function EnterEvent(e) {
            if (e.keyCode == 13) {


                document.getElementById('hdn_Val').value = 'Y';
                document.getElementById('btn_Add1').click();
            }
            else {
                document.getElementById('hdn_Val').value = 'N';
            }

        }
        function sd() {
            alert('l');
        }
    </script>

    <script type="text/javascript">
        // Select/Deselect checkboxes based on header checkbox
        function SelectheaderCheckboxes(headerchk, gv, button) {
            debugger
            var gvcheck = document.getElementById(gv);
            var i;
            //Condition to check header checkbox selected or not if that is true checked all checkboxes
            if (headerchk.checked) {
                for (i = 0; i < gvcheck.rows.length; i++) {
                    var inputs = gvcheck.rows[i].getElementsByTagName('input');
                    inputs[0].checked = true;
                }
                document.getElementById(button).click();

            }
            //if condition fails uncheck all checkboxes in gridview
            else {
                for (i = 0; i < gvcheck.rows.length; i++) {
                    var inputs = gvcheck.rows[i].getElementsByTagName('input');
                    inputs[0].checked = false;
                }
            }
        }
        //function to check header checkbox based on child checkboxes condition
        function Selectchildcheckboxes(header, gv, button) {
            var ck = header;
            var count = 0;
            var gvcheck = document.getElementById(gv);
            var headerchk = document.getElementById(header);
            var rowcount = gvcheck.rows.length;
            //By using this for loop we will count how many checkboxes has checked
            for (i = 1; i < gvcheck.rows.length; i++) {
                var inputs = gvcheck.rows[i].getElementsByTagName('input');
                if (inputs[0].checked) {
                    document.getElementById(button).click();
                    count++;
                }
            }
            //Condition to check all the checkboxes selected or not
            if (count == rowcount - 1) {
                headerchk.checked = true;

            }
            else {
                headerchk.checked = false;
            }
        }
</script>

<script type="text/javascript">
    function GetFileSize(fileid) {
        try {
            var fileSize = 0;
            //for IE
            if ($.browser.msie) {
                //before making an object of ActiveXObject,
                //please make sure ActiveX is enabled in your IE browser
                var objFSO;

                if ($("#" + fileid)[0].files.length === 0) {

                    jAlert('No files selected.', 'DOCUMENT', function (r) { document.getElementById("btn_Upload").focus(); });

                }
                else {
                    objFSO = new ActiveXObject("Scripting.FileSystemObject");
                    var filePath = $("#" + fileid)[0].value;

                    var objFile = objFSO.getFile(filePath);
                    var fileSize = objFile.size; //size in kb
                }
                //fileSize = fileSize / 1048576; //size in mb
            }
            //for FF, Safari, Opeara and Others
            else {
                if ($("#" + fileid)[0].files.length > 0) {

                    fileSize = $("#" + fileid)[0].files[0].size //size in kb
                }
                //fileSize = fileSize / 1048576; //size in mb
            }

            if (fileSize < 1048576) {

            }
            else {
                jAlert('File size exceeds maximum limit 1 MB.', 'JOB HISTORY', function (r) { document.getElementById("btn_Upload").focus(); });

                //alert("File size exceeds maximum limit 1 MB.");
                return false;
            }

        }
        catch (e) {
            alert("Error is :" + e);
        }
    }
 </script>
</body>
</html>