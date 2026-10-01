 <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Job_history.aspx.cs" Inherits="Job_histroy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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



    
<script src="../js/Calendar_Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="../js/Calendar_Scripts/jquery.dynDateTime.min.js" type="text/javascript"></script>
<script src="../js/Calendar_Scripts/calendar-en.min.js" type="text/javascript"></script>
<link href="../js/Calendar_Scripts/calendar-blue.css" rel="stylesheet" type="text/css" />
<script type = "text/javascript">
    $(document).ready(
    function () {
        $(".Calender").dynDateTime({
            showsTime: true,
            ifFormat: "%d/%m/%Y %H:%M",
            daFormat: "%l;%M %p, %e %m, %Y",
            align: "BR",
            electric: false,
            singleClick: false,
            displayArea: ".siblings('.dtcDisplayArea')",
            button: ".next()"
        });
    });
</script>


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
            
    <ol id="toc">
       
        <li><a href="#page-2" onclick="tab2('0'); jQuery('#form1').validationEngine('hideAll')"
                        id="Jobdoc"><span>Job Documents</span></a> </li>
        <li><a href="#page-3" onclick="tab3('0'); jQuery('#form1').validationEngine('hideAll')"
                        id="Jobclr"><span>Clearence Details</span></a> </li>
                         <li>
            <a href="#page-1" onclick="tab1('0'); jQuery('#form1').validationEngine('hideAll')" id="Jobdel">
                <span>Job Notes</span>
            </a>
        </li>
    </ol>
  
                 <div class="content" id="page-1" style="height:350px;">
                    
                        

                <div id="Main_Grid_Container" style="overflow:auto;height:330px;width:680px;" class="listbox">


                   <span style="color:Red; font-weight:bold;" > <asp:Literal ID="lblmsg"  runat="server"></asp:Literal> </span>



          
                    <asp:Button ID="btnDelete" runat="server" CausesValidation="false" Style="display: none;"
                        UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jConfirm('Delete this Job?', 'JOB HISTROY', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                                        <asp:Button ID="btn" runat="server"  OnClick="btnDelete_Click" CausesValidation="false"
                                            UseSubmitBehavior="false" 
                                            CssClass="dlete" Style="display: none;" />
                    <div style="float: left; width: 720px;">
                        <asp:GridView ID="GridView1" runat="server" ShowHeader="true" GridLines="None" Width="190%"
                            AllowPaging="True" AllowSorting="True" AutoGenerateColumns="false" CssClass="grid-view"
                            OnRowCreated="GridView1_RowCreated" PageSize="10" ShowHeaderWhenEmpty="True"
                            Style="border: 1px solid #dedede;" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAll" runat="server" onclick="javascript:SelectheaderCheckboxes(this,'GridView1','btnDelete')" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_JobId" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="10px" CssClass="column_style_left" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label ID="lblFullName1" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="lines" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%--<asp:Label ID="txtdate" runat="server" CssClass="column_style_left txt" Text='<%#Eval("UPLOAD_DATE")%>'></asp:Label>--%>
                                          <asp:TextBox ID="txtdate" runat="server" Text='<%#Eval("UPLOAD_DATE")%>'  class="Calender" />
                                           <img src="../js/Calendar_Scripts/calender.png" />
                                    </ItemTemplate>
                                    <ItemStyle CssClass="column_style_left" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <div style="float: right; padding-right: 30px;">
                                            <asp:Button ID="btn_Add" runat="server" Text="+" OnClick="btn_Add_Click" />
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtItem" runat="server" CssClass="txt" AutoPostBack="true" Text='<%#Eval("DESCRIPTION")%>'
                                            HtmlEncode="false" TextMode="MultiLine" OnTextChanged="txtItem_TextChanged"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="JOB_ID">
                                    <HeaderStyle CssClass="hideGridColumn" />
                                    <ItemStyle CssClass="hideGridColumn" />
                                </asp:BoundField>
                            </Columns>
                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                NextPageText="Next" Position="Top" PreviousPageText="Previous" />
                        </asp:GridView>
                    </div>
                </div>
                    <div id="f" style="width:235px;float:right;margin-top:-380px;">
                    
                      <%--<asp:FileUpload ID="FileUpload1" runat="server" />--%>
                      <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true" />

                    <asp:Button ID="btn_Upload" runat="server" Text="Upload" OnClick="btn_Upload_Click" OnClientClick="return GetFileSize('FileUpload1');"/>

                     <asp:Button ID="btn_File_Delete" runat="server"  CausesValidation="false" style="display:none;"
                                            UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jConfirm('Delete this File?', 'JOB HISTROY', function(r) {
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
                        <div style="width: 235px; height: 300px; overflow: auto;">
                            <asp:GridView ID="gvdetails" runat="server" ShowHeader="true" Width="235px" AllowPaging="True"
                                AllowSorting="True" AutoGenerateColumns="false" OnRowCreated="gvdetails_RowCreated"
                                BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                                EmptyDataText="NO RECORD FOUND" PageSize="10" ShowHeaderWhenEmpty="True" CssClass="grid-view"
                                OnRowDataBound="gvdetails_RowDataBound" OnPageIndexChanging="gvdetails_PageIndexChanging">
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
                                            <asp:LinkButton ID="txtdate" runat="server" Text='<%#Eval("ATTACHMENT_FILE") %>'
                                                OnClick="lnkDownload_Click"> </asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="350px" CssClass="column_style_left" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="FILE_JOB_ID">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                </Columns>
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                    NextPageText="Next" Position="Top" PreviousPageText="Previous" />
                            </asp:GridView>
                        </div>
            
             <asp:Button ID="btnMySubmitButton" UseSubmitBehavior="true" runat="server" Text="Click or press Enter" style="display:none;" OnClientClick="sd();" />
         
                <asp:Button ID="btn_Save"  runat="server" Text="Add" OnClick="btn_Save_Click" style="display:none;"/>
                <asp:Button ID="btn_Add1"  runat="server" Text="Add" OnClick="btn_Add_Click" style="display:none;"/>
    <asp:HiddenField ID="hdn_Val" runat="server" />
    </div>
     </div>
      

     <div class="content" id="page-2" style="height:300px;">
       <!-- PAGE 2 - Job Documents -->

    <div id="Main_Grid_Container1">
       
       <asp:GridView runat="server" ID="gvdetails1" DataKeyNames="MailSubject" EmptyDataText="NO RECORD FOUND"
    AutoGenerateColumns="False" CssClass="grid-view" ShowHeader="true" Width="100%"
    AllowPaging="True" OnRowDataBound="gvdetails1_RowDataBound"
    AllowSorting="True" CellPadding="1" CellSpacing="1" OnRowCreated="gvdetails1_RowCreated"
    PageSize="23">
    
    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" />

    <Columns>
        <asp:BoundField DataField="JOB_NO" HeaderText="Job No" />
        <asp:BoundField DataField="entrydate" HeaderText="Entry Date" />
        <asp:BoundField DataField="File_Remarks" HeaderText="Remarks" />

        <asp:TemplateField HeaderText="Attachment">
            <ItemTemplate>
                <asp:LinkButton ID="lnkDownload" runat="server"
                    Text='<%#Eval("MailSubject") %>' 
                    OnClick="lnkDownload_Click_New"> </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>

    <PagerSettings Visible="False" />
</asp:GridView>


    </div>
</div>

     <div class="content" id="page-3" style="height:350px;">
        <!-- PAGE 3 - Clearence Details -->
        <div id="Main_Grid_Container2" style="overflow:auto;height:330px;width:900px;">

            <asp:HiddenField ID="hdn_ImpName" runat="server" />

            <div style="margin-bottom:10px; position:relative;">
                <div style="text-align:center;">
                    <asp:Button ID="btnsaveupdate" Text="Save & Update" runat="server" OnClick="btnsaveupdate_Click" />
                </div>
                <div style="position:absolute; top:0; right:0;">
                    <asp:Button ID="btnClrDelete" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                        CssClass="dlete" />
                    <asp:Button ID="btnClr" runat="server" OnClick="btnClrDelete_Click" CausesValidation="false"
                        UseSubmitBehavior="false"
                        CssClass="dlete" Style="display: none;" />
                </div>
            </div>

            <asp:GridView ID="gv_Chg_Details" runat="server" EmptyDataText="No Record Found" ShowHeader="true"
                AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"
                ShowFooter="false" BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view" AllowPaging="false"
                HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%"
                OnRowCreated="gv_Chg_Details_RowCreated">

                <RowStyle BorderWidth="0.1em" BorderColor="black" />
                <Columns>

                    <asp:TemplateField HeaderText="Stage" HeaderStyle-Font-Bold="true" HeaderStyle-Width="40px">
                        <ItemTemplate>
                            <asp:Label ID="txt_CH_ID" runat="server" Text='<%# Bind("CH_ID") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="40px" HorizontalAlign="Left" Font-Size="12px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Stage" HeaderStyle-Font-Bold="true" HeaderStyle-Width="200px">
                        <ItemTemplate>
                            <asp:Label ID="txt_stage" runat="server" Text='<%# Bind("STAGE") %>' ToolTip='<%# Bind("STAGE") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="200px" HorizontalAlign="Left" Font-Size="12px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Actual Date" HeaderStyle-Font-Bold="true" HeaderStyle-Width="120px">
                        <ItemTemplate>
                            <asp:TextBox ID="txt_Acc_date" Text='<%# Bind("DATE_INFO") %>' Width="100px" runat="server"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="120px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Handled By" HeaderStyle-Font-Bold="true" HeaderStyle-Width="140px">
                        <ItemTemplate>
                            <asp:TextBox ID="txt_handled_by" Text='<%# Bind("HANDLED_BY") %>' Width="140px" runat="server"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="140px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Remarks" HeaderStyle-Font-Bold="true" HeaderStyle-Width="400px">
                        <ItemTemplate>
                            <asp:TextBox ID="txt_remarks" Text='<%# Bind("REMARKS") %>' Width="400px" runat="server"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="400px" />
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </div>

      </ContentTemplate>
    </asp:UpdatePanel>

    </span>
    </form>
    <script type="text/javascript">
        activatables('page', ['page-1', 'page-2', 'page-3']);
    </script>
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
        function SelectheaderCheckboxes(headerchk,gv,button) {
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
                var objFSO = new ActiveXObject("Scripting.FileSystemObject"); var filePath = $("#" + fileid)[0].value;
                var objFile = objFSO.getFile(filePath);
                var fileSize = objFile.size; //size in kb

                //fileSize = fileSize / 1048576; //size in mb
            }
            //for FF, Safari, Opeara and Others
            else {
                fileSize = $("#" + fileid)[0].files[0].size //size in kb

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
 <script type="text/javascript">
     function tab1(val) {
          document.getElementById("page-1").style.display = 'Block';
          document.getElementById("page-2").style.display = 'none';
          document.getElementById("page-3").style.display = 'none';

          document.getElementById("Jobdel").className = 'active';
          document.getElementById("Jobdoc").className = 'inactive';
          document.getElementById("Jobclr").className = 'inactive';
      }

      function tab2(val) {
          document.getElementById("page-1").style.display = 'none';
          document.getElementById("page-2").style.display = 'Block';
          document.getElementById("page-3").style.display = 'none';

          document.getElementById("Jobdel").className = 'inactive';
          document.getElementById("Jobdoc").className = 'active';
          document.getElementById("Jobclr").className = 'inactive';
      }

      function tab3(val) {
          document.getElementById("page-1").style.display = 'none';
          document.getElementById("page-2").style.display = 'none';
          document.getElementById("page-3").style.display = 'Block';

          document.getElementById("Jobdel").className = 'inactive';
          document.getElementById("Jobdoc").className = 'inactive';
          document.getElementById("Jobclr").className = 'active';
      }
</script>
</body>
</html>
