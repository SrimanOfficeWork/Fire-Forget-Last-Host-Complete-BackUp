<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Import_Job_Bulk_Excel.aspx.cs" Inherits="Import_XL_CompleteJobDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import Job Bulk Upload</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />

    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />

    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />

    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
     <script src="../js/Import_Jscript/Import_General.js" type="text/javascript"></script>

     <!-- GRID SCROLL SCRIPT -->    
    <link href="../js/Grid_header_script/GridviewScroll.css" rel="stylesheet" />
    <script src="../js/Grid_header_script/gridviewScroll.min.js"></script>


<script type="text/javascript">

    function OnTreeClick(evt) {

        var src = window.event != window.undefined ? window.event.srcElement : evt.target;

        var isChkBoxClick = (src.tagName.toLowerCase() == "input" && src.type == "checkbox");

        if (isChkBoxClick) {

            var parentTable = GetParentByTagName("table", src);

            var nxtSibling = parentTable.nextSibling;
            //check if nxt sibling is not null & is an element node

            if (nxtSibling && nxtSibling.nodeType == 1) {
                //if node has children    
                if (nxtSibling.tagName.toLowerCase() == "div") {

                    //check or uncheck children at all levels

                    CheckUncheckChildren(parentTable.nextSibling, src.checked);
                }
            }

            //check or uncheck parents at all levels

            CheckUncheckParents(src, src.checked);
        }
    }



    function CheckUncheckChildren(childContainer, check) {

        var childChkBoxes = childContainer.getElementsByTagName("input");

        var childChkBoxCount = childChkBoxes.length;

        for (var i = 0; i < childChkBoxCount; i++) {

            childChkBoxes[i].checked = check;
        }
    }



    function CheckUncheckParents(srcChild, check) {

        var parentDiv = GetParentByTagName("div", srcChild);

        var parentNodeTable = parentDiv.previousSibling;

        if (parentNodeTable) {

            var checkUncheckSwitch;

            //checkbox checked 

            if (check) {
                var isAllSiblingsChecked = AreAllSiblingsChecked(srcChild);
                if (isAllSiblingsChecked)
                    checkUncheckSwitch = true;
                else
                    return; //do not need to check parent if any(one or more) child not checked
            }

            else //checkbox unchecked
            {
                checkUncheckSwitch = false;
            }



            var inpElemsInParentTable = parentNodeTable.getElementsByTagName("input");

            if (inpElemsInParentTable.length > 0) {

                var parentNodeChkBox = inpElemsInParentTable[0];

                parentNodeChkBox.checked = checkUncheckSwitch;

                //do the same recursively

                CheckUncheckParents(parentNodeChkBox, checkUncheckSwitch);
            }
        }
    }



    function AreAllSiblingsChecked(chkBox) {

        var parentDiv = GetParentByTagName("div", chkBox);
        var childCount = parentDiv.childNodes.length;

        for (var i = 0; i < childCount; i++) {

            if (parentDiv.childNodes[i].nodeType == 1) {

                //check if the child node is an element node

                if (parentDiv.childNodes[i].tagName.toLowerCase() == "table") {

                    var prevChkBox = parentDiv.childNodes[i].getElementsByTagName("input")[0];

                    //if any of sibling nodes are not checked, return false

                    if (!prevChkBox.checked) {

                        return false;
                    }
                }
            }
        }
        return true;
    }



    //utility function to get the container of an element by tagname

    function GetParentByTagName(parentTagName, childElementObj) {

        var parent = childElementObj.parentNode;

        while (parent.tagName.toLowerCase() != parentTagName.toLowerCase()) {

            parent = parent.parentNode;

        }

        return parent;

    }

    </script>

<style type="text/css">
        .treeNode
        {
            color:blue;
        }
        .rootNode
        {
            font-size:12px;
            font-family:Verdana;
            font-style:italic;
            font-size:10px;
            color:black;
            
        }
        .leafNode
        {
            font-size:09px;
            padding:0px;
            font-weight:bold;
            color:blue;
        }
    </style>
    <script>
        function toggleAll(source) {
            var tree = document.getElementById('<%= TreeView1.ClientID %>');
            var checkboxes = tree.getElementsByTagName("input");

            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].type === "checkbox") {
                    checkboxes[i].checked = source.checked;
                }
            }
        }

        /*window.onload = function () {
            var tree = document.getElementById('<%= TreeView1.ClientID %>');
            var checkboxes = tree.getElementsByTagName("input");

            if (checkboxes.length > 0) {
                // First checkbox = Select ALL
                checkboxes[0].onclick = function () {
                    toggleAll(this);
                };
            }            
        };*/

        window.onload = function () {

            var tree = document.getElementById("<%=TreeView1.ClientID%>");
            var checkboxes = tree.getElementsByTagName("input");

            if (checkboxes.length > 0) {
                // First checkbox = Select ALL
                checkboxes[0].onclick = function () {
                    toggleAll(this);
                };
            }      

            var links = tree.getElementsByTagName("a");
            for (var i = 0; i < links.length; i++) {

                links[i].removeAttribute("href");

                links[i].onclick = function (e) {
                    if (e) e.preventDefault();
                    return false;
                };
            }
        };

</script>


    <script type="text/javascript">
        function Spcl_Chars(percentage, Alt_type) {

            var split = percentage.split('*');
            var size = split.length;
            var val = '';
            for (var i = 0; i < size; i++) {
                val += split[i] + '\n';
            }
            var aa = '';
            if (Alt_type == 'alert') {
                aa = '                                ITEM DESCRIPTION-ERROR' + '\n' + '                        ==============================' + '\n';
            }
            else if (Alt_type == 'GeneralDesc_Alert') {
                aa = '                       GENERAL DESCRIPTION-ERROR' + '\n' + '                       ==============================' + '\n';
            }
            else if (Alt_type == 'Mnufactre_alert') {
                aa = '                        MANUFACTUTER NAME-ERROR' + '\n' + '                   ==============================' + '\n';
            }
            else {
                aa = '';
            }
            var msg = "Invalid Special Characters Found..Correct this and Again Upload !!!";
            alert(aa + msg + '\n' + '-------------------------------------------------------------------------------------------------' + '\n' + '\n' + val);

        }
</script>
  
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
   
 <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>            

            <div id="innerbox_MidMain" style="height: 32px;">
                <div id="tag_srcinner1">
                    <%--<div id="mainmastop2container_rght_tag2_txt1" style="width:150px" >
                       Job - Bulk Excel Upload
                         </div>--%>
                         <div id="mainmastop2container_rght_tag2_txt1" style="width: 270px;">
            Job - Bulk Excel Upload |              
            <asp:Label ID="lbl_JobNo" runat="server" 
                ForeColor="Red" 
                Font-Bold="true"
                style="margin-left:5px;">
            </asp:Label> 
        </div>
                   
                    <div id="verslic">
                    </div>
                   

                    <div id="txt_container_Transact_Main_l"  style="width: 190px; margin-top:0px;">

                       <%--<div id="editbu" style="padding-top: 3px;">
                            <asp:ImageButton ID="btnexcel" runat="server" ToolTip="Download Excel File Format" ImageUrl="~/images/xls.jpg" Height="28px" Width="28px" OnClientClick="downloadErrors()" />
                        </div>--%>
                        <div id="editbu"> 
                         <a href="../Submission/Import_Excel_Format/IMPORT_JOB_BULK_UPLOAD.xlsx"  target="_new">
                        <asp:Image ID="Image2" ImageUrl="~/images/xls.jpg" ToolTip="Download Excel File Format"  Height="30px"  Width="30px" runat="server" />
                        </a>
                        </div>
                        <div id="verslic">
                        </div>

                     <div id="editbu">
                    <asp:Button ID="btn_JobDownload" runat="server" CausesValidation="false" Width="130px" Text="Download Job Data" 
                        UseSubmitBehavior="false" CssClass="autowidmovebut"  OnClick="btn_Download_Click" />
                    </div>
                        <div id="verslic">
                        </div>

                    <%--<asp:Image ID="Image1" ImageUrl="~/images/icons/xl.png" ToolTip="Download Excel File Format"  Height="30px"  Width="30px" runat="server" /></a>--%>
                    </div>

                    <div id="txt_container_Transact_Main_l" style="width: 300px;">
                        <div id="tag_label_transact_Src" style="width: 106px;">
                            Select a Excel</div>                            
                        <div id="txtcon-m_Exchange" style="width: 120px;">
                        <asp:FileUpload ID="fileuploadExcel" runat="server" onchange="document.getElementById('btn_upload').click();" />
                            <%--<asp:FileUpload ID="fileuploadExcel" runat="server" onchange="triggerUpload();" />--%>

                            <%--<asp:Button ID="btn_upload" runat="server" OnClick="btn_upload_Click" Style="display: none;" />--%>
                        </div>
                    </div>
                   <%-- <div id="verslic">
                    </div>--%>
                    <%--<div id="editbu">
                        <asp:Button ID="btnUpload" runat="server" Width="110px" Text="Upload"  CssClass="autowidmovebut" 
                            OnClick="btnUpload_Click" />
                    </div>--%>
                    <div id="popupwindow_closebut_right_new">
                    <asp:Button ID="btnClose" runat="server" CssClass="clsicon_new" OnClientClick="RefreshParentOld();"
                            CausesValidation="false" UseSubmitBehavior="false" />                    
                     
                    </div>
                </div>
                   </div>

<div id="pop_tabs_menu_prod_master" style="width:930px; height:437px;">
                <ol id="toc_new">
                    <li><a href="#page1" onclick="tab1('0'); jQuery('#form1').validationEngine('hideAll')"
                        id="Tab1_Basic"><span>Custom Fields  </span></a> </li>
                    
                </ol>
          
          <%-- YG START --%>
 <div class="content" id="page1" style="vertical-align: top; position: relative; min-height: 380px;">

    <!-- FLEX ROW: TreeView + Grid side by side -->
    <div style="width:820px; display:flex; flex-direction:row;">

        <!-- LEFT: TreeView -->
        <div style="width:200px; padding-left:0px; height:300px;">
            <div id="tag_label_transaction_popup_gen" style="margin-top:0px; height:350px; width:200px; border:solid 2px #A9A9A9; overflow:hidden; overflow-y:scroll;">
                <asp:TreeView ID="TreeView1" 
                    NodeStyle-CssClass="treeNode"
                    RootNodeStyle-CssClass="rootNode"
                    LeafNodeStyle-CssClass="leafNode"
                    runat="server" 
                    OnTreeNodeCheckChanged="TreeView1_TreeNodeCheckChanged" 
                    ShowCheckBoxes="All" 
                    CssClass="Tree"
                    PopulateNodesFromClient="true">                    
                </asp:TreeView>
            </div>
        </div>


        <asp:Literal ID="litGridThemeCss" runat="server"></asp:Literal>
        <!-- RIGHT: Grid -->
<div style="width:600px; padding-left:5px;">

    <style type="text/css">
        #gv_Item_Details_wrap {
            width: 708px;
            max-height: 356px;
            overflow-y: auto;
            overflow-x: auto;
            border: 1px solid #C8C8C8;
            border-radius: 4px;
        }

        #gv_Item_Details_wrap table.grid-view-styled {
            border-collapse: collapse;
            width: 100%;
        }

        #gv_Item_Details_wrap .grid-view-styled th {
            background-color: #2E5C8A;
            color: #fff;
            font-size: 12px;
            font-weight: 600;
            padding: 6px 8px;
            text-align: left;
            position: sticky;
            top: 0;
            z-index: 1;
        }

        #gv_Item_Details_wrap .grid-view-styled td {
            font-size: 12px;
            padding: 5px 8px;
            border-bottom: 1px solid #E0E0E0;
        }

        #gv_Item_Details_wrap .grid-view-styled tr:hover td {
            background-color: #EAF2FB;
        }

        #gv_Item_Details_wrap .grid-view-styled .alt-row td {
            background-color: #F7F7F7;
        }

        #gv_Item_Details_wrap .pager-row td {
            background-color: #F0F0F0;
            padding: 6px;
            text-align: center;
        }

        #gv_Item_Details_wrap .pager-row a,
        #gv_Item_Details_wrap .pager-row span {
            margin: 0 4px;
            font-size: 12px;
            text-decoration: none;
            color: #2E5C8A;
        }

        #gv_Item_Details_wrap .pager-row span {
            font-weight: bold;
            color: #000;
        }
    </style>

    <div id="gv_Item_Details_wrap">
        <asp:GridView ID="gv_Item_Details" runat="server" EmptyDataText="No Record Found"
            ClientIDMode="Static" OnRowCreated="gv_Item_Details_RowCreated" Font-Names="Verdana"
            AutoGenerateColumns="true" GridLines="None" CellPadding="0" CellSpacing="0"
            CssClass="grid-view-styled" ShowHeaderWhenEmpty="True" AllowPaging="false"
            Width="100%" HorizontalAlign="Left"
            AlternatingRowStyle-CssClass="alt-row" PagerStyle-CssClass="pager-row">
        </asp:GridView>
    </div>
</div>

<%--        <!-- RIGHT: Grid -->
        <div style="width:600px; padding-left:5px; height:300px;">
            <div style="overflow:auto; height:356px; width:708px;">
                <asp:GridView ID="gv_Item_Details" runat="server" BackColor="LightGray" BorderColor="#C8C8C8" EmptyDataText="No Record Found"
                                     ClientIDMode="Static" OnRowCreated="gv_Item_Details_RowCreated" Font-Names="Verdana" AutoGenerateColumns="true"
                                    BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view" ShowHeaderWhenEmpty="True" AllowPaging="false"
                                    Width="100%"  HorizontalAlign="Left" HeaderStyle-Font-Bold="true">

                                <RowStyle BorderWidth="0.1em" BorderColor="black" />
                                    <PagerStyle ForeColor="Black" CssClass="pager" />                                    
                                </asp:GridView>

            </div>
        </div>--%>


<%--        <div style="width:708px; padding-left:5px; height:300px;">

    <div id="GridContainer">

        <asp:GridView ID="gv_Item_Details"
            runat="server"
            BackColor="LightGray"
            BorderColor="#C8C8C8"
            EmptyDataText="No Record Found"
            ClientIDMode="Static"
            OnRowCreated="gv_Item_Details_RowCreated"
            Font-Names="Verdana"
            AutoGenerateColumns="true"
            BorderWidth="1px"
            CellPadding="1"
            CellSpacing="1"
            CssClass="grid-view"
            ShowHeaderWhenEmpty="True"
            AllowPaging="false"
            Width="100%"
            HorizontalAlign="Left"
            HeaderStyle-Font-Bold="true">

            <RowStyle BorderWidth="0.1em" BorderColor="black" />
            <PagerStyle ForeColor="Black" CssClass="pager" />

        </asp:GridView>

    </div>

</div>--%>

    </div>
    <!-- END FLEX ROW -->

    <!-- BUTTONS: OUTSIDE the flex row -->
    <div id="innerbox_adcode_bot_inn"  style="position: absolute; bottom: 10px; left: 10px;">
        <div id="Div2">.
            <%--<asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate();" TabIndex="52" OnClick="btnSave_Click" CommandName="s"/>--%>
            <%--<asp:Button ID="btnUpdate" runat="server" CssClass="save" OnClick="btnUpdate_Click" OnClientClick="return validateAll();" TabIndex="63" /> original --%>
            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnUpdate_Click" OnClientClick="return validateAll();" TabIndex="63" />
            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"  OnClientClick="return validate();" />
            <asp:Button ID="btnCancel" runat="server" CssClass="scancel" OnClientClick="clearTreeView(); return false;" CausesValidation="false" UseSubmitBehavior="false" />
        </div>
    </div>   

  </div>
          <%-- YG END --%>
                                        
 </div>
           
            <script src="../activatables.js" type="text/javascript"></script>            

                 <script type="text/javascript">
                     var win = null

                     function Import_Job_Excel_download() {
                         var Type = 'excel';

                     }

    </script>

            <asp:HiddenField ID="hdinvslno" runat="server" ClientIDMode="Static"/>
            <asp:HiddenField ID="hdn_alert" runat="server"  />
            <asp:HiddenField ID="hdfTransport_mode" runat="server" />            
           
           </ContentTemplate>
    </asp:UpdatePanel>

    <asp:modalpopupextender ID="MP_U" runat="server" TargetControlID="HDU"
        PopupControlID="MessageDivupdated_U" 
        BackgroundCssClass="modalBackground" DropShadow="false"   >
    </asp:modalpopupextender> 
    <asp:HiddenField ID="HDU" runat="server" />
    
    <%-- ============================================================================================================ --%>
   <%--<asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup12" align="left"  BorderColor="Transparent">
   
     <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width:300px; height:80px; ">
         <table width="100%" style="padding-top: 10px;">
             <tr>
                 <td align="center">
                     <asp:Label ID="lblUser_Msg" runat="server" Text="Importer does not exist in the Master. Do you want to add it?"></asp:Label>
                 </td>
             </tr>
             
             <tr>
                 <td style="padding-left: 100px; padding-top:10px;">
                     <asp:Button ID="btnyes" runat="server" Text="Yes" 
                         CausesValidation="false" UseSubmitBehavior="false" OnClick="btnyes_Click" /> 
                           <asp:Button ID="btnNo" runat="server" Text="No" 
                         CausesValidation="false" UseSubmitBehavior="false" OnClientClick="return HideModalPopup_U()" /> 
                 </td>
                 
             </tr>
         </table>
     </div>
    
    </asp:Panel>--%>  
    
    <%-- Start &#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472; --%>
    <%--<asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup12" 
           BorderColor="Transparent">--%>
  
   <%-- Header &#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472; --%>
    <%--<div style="background:#f47920; padding:8px 14px; 
                border-radius:6px 6px 0 0;">
        <span style="color:#fff; font-weight:bold; font-size:12px; 
                     font-family:Arial,sans-serif; letter-spacing:0.5px;">
            &#9888; Master Verification
        </span>
    </div>--%>

    <%-- Body &#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472; --%>
   <%-- <div style="background:#fff; padding:16px 14px 14px 14px;
                border:1px solid #ddd; border-top:none;
                border-radius:0 0 6px 6px;">--%>

        <%-- Icon + Message &#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472; --%>
        <%--<table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td align="center" style="padding-bottom:4px;">
                    <span style="font-size:26px; line-height:1;">&#9888;&#65039;</span>
                </td>
            </tr>
            <tr>
                <td align="center" 
                    style="font-family:Arial,sans-serif; font-size:12px; 
                           color:#333; line-height:1.6; padding-bottom:12px;">
                    <asp:Label ID="lblUser_Msg" runat="server"
                               Text="Importer does not exist in the Master.&lt;br/&gt;Do you want to add it?">
                    </asp:Label>
                </td>
            </tr>--%>

            <%-- Divider &#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472; --%>
            <%--<tr>
                <td style="border-top:1px solid #eee; padding-bottom:12px;"></td>
            </tr>--%>

            <%-- Buttons &#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472; --%>
            <%--<tr>
                <td align="center">

                    <asp:Button ID="btnyes" runat="server" Text="Yes, Add"
                                CausesValidation="false" UseSubmitBehavior="false"
                                OnClick="btnyes_Click"
                                Style="background:#f47920; color:#fff; 
                                       border:1px solid #d4600a;
                                       padding:5px 18px; font-size:12px; 
                                       font-weight:bold; font-family:Arial,sans-serif; 
                                       border-radius:4px; cursor:pointer; 
                                       margin-right:6px;" />

                    <asp:Button ID="btnNo" runat="server" Text="No, Cancel"
                                CausesValidation="false" UseSubmitBehavior="false"
                                OnClientClick="return HideModalPopup_U()"
                                Style="background:#f5f5f5; color:#444; 
                                       border:1px solid #bbb;
                                       padding:5px 18px; font-size:12px; 
                                       font-weight:bold; font-family:Arial,sans-serif; 
                                       border-radius:4px; cursor:pointer;" />
                </td>
            </tr>
        </table>
    </div>

</asp:Panel>--%>

<asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup12" 
           BorderColor="Transparent">

    <%-- Header &#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472; --%>
    <div style="background:#f47920; padding:8px 14px; 
                border-radius:6px 6px 0 0;">
        <span style="color:#fff; font-weight:bold; font-size:12px; 
                     font-family:Arial,sans-serif; letter-spacing:0.5px;">
            &#9888; Master Verification
        </span>
    </div>

    <%-- Body &#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472; --%>
    <div style="background:#fff; padding:16px 14px 14px 14px;
                border:1px solid #ddd; border-top:none;
                border-radius:0 0 6px 6px;">

        <table width="100%" cellpadding="0" cellspacing="0">

            <%-- Icon &#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472; --%>
            <tr>
                <td align="center" style="padding-bottom:4px;">
                    <span style="font-size:26px; line-height:1;">&#9888;&#65039;</span>
                </td>
            </tr>

            <%-- Main message &#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472; --%>
            <tr>
                <td align="center" 
                    style="font-family:Arial,sans-serif; font-size:12px; 
                           color:#333; line-height:1.6; padding-bottom:10px;">
                    <asp:Label ID="lblUser_Msg" runat="server"
                               Text="Importer does not exist in the Master.&lt;br/&gt;Do you want to add it?">
                    </asp:Label>
                </td>
            </tr>

            

            <%-- Buttons &#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472; --%>
            <tr>
                <td align="center">
                    <asp:Button ID="btnyes" runat="server" Text="Yes, Add"
                                CausesValidation="false" UseSubmitBehavior="false"
                                OnClick="btnyes_Click"
                                Style="background:#f47920; color:#fff; 
                                       border:1px solid #d4600a;
                                       padding:5px 18px; font-size:12px; 
                                       font-weight:bold; font-family:Arial,sans-serif; 
                                       border-radius:4px; cursor:pointer; 
                                       margin-right:6px;" />

                    <asp:Button ID="btnNo" runat="server" Text="No, Cancel"
                                CausesValidation="false" UseSubmitBehavior="false"
                                OnClientClick="return HideModalPopup_U()"
                                Style="background:#f5f5f5; color:#444; 
                                       border:1px solid #bbb;
                                       padding:5px 18px; font-size:12px; 
                                       font-weight:bold; font-family:Arial,sans-serif; 
                                       border-radius:4px; cursor:pointer;" />
                </td>
            </tr>

            <%-- Divider &#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472; --%>
            <tr>
               <td style="padding-top:15px; padding-bottom:12px;">
                  <hr style="border:0; border-top:1px solid #eee; margin:0;" />
               </td>
            </tr>
            <%-- Condition label &#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472; --%>
            <tr>
                <td align="center" style="padding-bottom:12px;">
                    <div style="background:#fff8f0; border:1px solid #f4c28a;
                                border-radius:4px; padding:6px 10px;
                                font-family:Arial,sans-serif; font-size:11px;
                                color:#8a4500; line-height:1.5;">
                        &#8505;
                        <asp:Label ID="lblCondition" runat="server"
                                   Text="Note: Please verify values are correct before adding to master.">
                        </asp:Label>
                    </div>
                </td>
            </tr>

            

        </table>
    </div>

</asp:Panel>
    <%-- ============================================================================================================ --%> 

    </form> 
   
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>

    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").validationEngine();

        });

        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {

                return options.allrules.validate2fields.alertText;
            }
        }
        function close_button() {
            document.getElementById("General").click();
        }
        
    </script>


      <script type="text/javascript">

          function HideModalPopup_U() {

              $find("MP_U").hide();
              return false;
          }
    </script>

        <script type="text/javascript">
            function RefreshParentOld() {
                window.parent.location.reload();
            }

            function RefreshParent() {
                if (window.opener) {
                    window.opener.location.reload();
                }
                window.close();
            }
        
    </script>

    <script>
        function clearTreeView() {
            var tree = document.getElementById('<%= TreeView1.ClientID %>');
            var checkboxes = tree.getElementsByTagName("input");

            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].type === "checkbox") {
                    checkboxes[i].checked = false;
                }
            }
        }
</script>

<script>
    function validateAll() {

        // TreeView validation
        var tree = document.getElementById('<%= TreeView1.ClientID %>');
        var checkboxes = tree.getElementsByTagName("input");

        var isNodeSelected = false;

        for (var i = 0; i < checkboxes.length; i++) {
            if (checkboxes[i].type === "checkbox" && checkboxes[i].checked) {
                isNodeSelected = true;
                break;
            }
        }

        if (!isNodeSelected) {
            jAlert('Please select at least one node', 'Job Data Upload', function (r) { ""; });
            //alert("Please select at least one node");            
            return false;
        }

        // FileUpload validation
        var fileUpload = document.getElementById('<%= fileuploadExcel.ClientID %>');

        if (fileUpload.value === "") {
            jAlert('Please select an Excel file', 'Job Data Upload', function (r) { ""; });
            //alert("Please select an Excel file");
            return false;
        }

        // Optional: Check Excel file type
        var allowedExtensions = /(\.xls|\.xlsx)$/i;
        if (!allowedExtensions.exec(fileUpload.value)) {
            alert("Please upload a valid Excel file (.xls or .xlsx)");
            fileUpload.value = "";
            return false;
        }

        return true; // All validations passed
    }
</script>



<script type="text/javascript">
    $(document).ready(function () {
        /* gridviewScroll();*/

        var totalRows = $("#<%=gv_Item_Details.ClientID %> tr").length;
        var lastProductId = $("#<%=gv_Item_Details.ClientID %> tr:last").children("td:first").html();

        if (totalRows > 2) {
            gridviewScroll();
        }
        else {

            if (lastProductId > 0) {
                gridviewScroll();
            }
            else {
                /*alert (lastProductId);*/
            }
        }
    });

    function gridviewScroll() {
        gridView1 = $('#<%=gv_Item_Details.ClientID %>').gridviewScroll({

            width: 1030,
            height: 500,
            railcolor: "#F0F0F0",
            barcolor: "#CDCDCD",
            barhovercolor: "#606060",
            bgcolor: "#F0F0F0",
            freezesize: 1,
            arrowsize: 30,
            varrowtopimg: "../GridScroll_Images/arrowvt.png",
            varrowbottomimg: "../GridScroll_Images/arrowvb.png",
            harrowleftimg: "../GridScroll_Images/arrowhl.png",
            harrowrightimg: "../GridScroll_Images/arrowhr.png",
            headerrowcount: 1,
            railsize: 16,
            barsize: 15,
            IsInUpdatePanel: true
        });
    }

    

    
    </script>

<%--<script type="text/javascript">
    function triggerUpload() {
        var btn = document.getElementById('<%= btn_upload.ClientID %>');
        if (btn) {
            btn.click();
        }
    }
</script>--%>
     
</body>
</html>
