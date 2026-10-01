<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Userwise_Job_Lock.aspx.cs" Inherits="Users_Userwise_Job_Lock" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
    
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
   <script type = "text/javascript">
       //<!--
       function Check_Click(objRef) {
           //Get the Row based on checkbox
           var row = objRef.parentNode.parentNode;

           //Get the reference of GridView
           var GridView = row.parentNode;

           //Get all input elements in Gridview
           var inputList = GridView.getElementsByTagName("input");

           for (var i = 0; i < inputList.length; i++) {
               //The First element is the Header Checkbox
               var headerCheckBox = inputList[0];

               //Based on all or none checkboxes
               //are checked check/uncheck Header Checkbox
               var checked = true;
               if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                   if (!inputList[i].checked) {
                       checked = false;
                       break;
                   }
               }
           }
           headerCheckBox.checked = checked;

       }
       function checkAll(objRef) {
           var GridView = objRef.parentNode.parentNode.parentNode;
           var inputList = GridView.getElementsByTagName("input");
           for (var i = 0; i < inputList.length; i++) {
               var row = inputList[i].parentNode.parentNode;
               if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                   if (objRef.checked) {
                       inputList[i].checked = true;
                   }
                   else {
                       if (row.rowIndex % 2 == 0) {
                           //                              row.style.backgroundColor = "#C2D69B";
                       }
                       else {
                           //                              row.style.backgroundColor = "white";
                       }
                       inputList[i].checked = false;
                   }
               }
           }
       }
       //-->

       function win_close1() {
           window.parent.document.getElementById('interVeil').style.display = 'none';
           window.parent.adcodewindow.hide();
       }
</script>

 
<div id="innerbox_MidMain" style=" height:128px;">
            <div id="tag_srcinner1" ">
              <div id="mainmastop2container_rght_tag2_txt1">
               Job Lock
              </div>

            </div>
            <div id="tag_transact_src_inner" style="width:805px;">
               <div id="tag_transaction_inner_new" style="margin-left:20px;">

                      <%-- Row-1  --%>

                    <div id="tag_Exchange_lft_in1_new1">
                        <div id="tag_label_transaction_Src_new">
                         Job Type
                        </div>
                        <div id="txtcon-m_transaction_code">
                              <asp:DropDownList ID="ddlJobType" runat="server" CssClass="listtxt_transac_src1" ClientIDMode="Static">
       
                            <asp:ListItem>Import</asp:ListItem>
                            <asp:ListItem>Export</asp:ListItem>
                            <asp:ListItem>Both</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                            <div id="tag_label_transact_Src">
                        
                            Select Branch
                        </div>
                        
                        <div id="txtcon-m_transaction_list1_bondtype">
                        <asp:DropDownList ID="ddlBranch" runat="server" CssClass="listtxt_transac_bondtype"  Width="150px">
                        </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_mode_empty">
                        </div>
                         
                        <div id="tag_label_transaction_Src_new" >
                        User Name
                        </div>
                        <div id="txtcon-m_transaction_list1_bondtype">
                          <asp:DropDownList ID="ddlUserName" runat="server" CssClass="listtxt_transac_src1"  Width="150px" ClientIDMode="Static">
                         </asp:DropDownList>
                        </div>

                    
                        <%--<div id="tag_label_transaction_date">
                           Importer Name
                        </div>--%>
                       
                                <%--<div id="txtcon-m_transaction_list1_bondtype">
                                <asp:TextBox ID="txtimpname" runat="server" MaxLength="40" onblur="ChangeCase(this);"
                                                ClientIDMode="Static" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Onkeypress="return numcharspl1(event)" TabIndex="5"></asp:TextBox>
                        </div>--%>
                       <%-- <div id="tag_label_transaction_popup_no_empty">
                        </div>--%>
                        
                    </div>


                     <%-- Row-2  --%>
                    <div id="tag_label_transaction_popup_IGM2_empty_gen">
                    </div>
                  
                    <%-- Row-3  --%>
                    <div id="tag_Exchange_lft_in1_new1">
                    <div id="tag_label_transaction_Src">
                           Need Job
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                   <asp:DropDownList ID="ddlneedjob" runat="server" CssClass="listtxt_transac_src1" >
                                     <asp:ListItem Text="Lock"></asp:ListItem>
                                      <asp:ListItem Text="UnLock"></asp:ListItem>
                                     </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_no_empty">
                        </div>
                     
                     <%--  ROW-4--%>
                     
                       
                    </div>

                    <div id="tag_label_transaction_popup_mode_empty" style="padding-left:300px;">
                    </div>
                  <div id="tag_label_transaction_Src_longlabel" style="padding-top:10px;" >
                                          
                                           <div id="small-butt-left" >
                                <a href="#" class="srcbu" id="btnSearch"  runat="server"   onserverclick="btnSearch_Click"   tabindex="10">   </a>                                             
                               
                              </div>
                            </div>


                        <div id="txtcon-m_transaction_mode" style="padding-top:10px;" >
                        <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="11"></a>
                        </div>

                       <div id="joblockoption" runat="server"> 
                         <div id="txtcon-m_transaction_mode" style="padding-left:30px;padding-top:10px;">

                             <asp:Button ID="btnLock" runat="server"  CausesValidation="false" 
                                 UseSubmitBehavior="false" CssClass="autowidmovebut" Text="Lock" 
                                 onclick="btnLock_Click"   />
                        </div>
                        <div id="txtcon-m_transaction_mode" style="padding-left:20px;padding-top:10px;">
                        
                        <asp:Button ID="btnUnlock" runat="server"  CausesValidation="false" UseSubmitBehavior="false"
                         CssClass="autowidmovebut" Text="UnLock" onclick="btnUnlock_Click" />
                        </div>
                        </div>
                </div> 
                
                
            </div>
        </div>


        <div id="innerbox_MidMain_Grid"  style="height:580px; ">
            <div id="tag_srcinner1grid">
             <div id="mainmastop2container_rght_tag2_txt1" style="margin-top:08px;">
             
                 <asp:Literal ID="lbljobchoose" runat="server"></asp:Literal>
              </div>
          

            </div>
           
                <div id="tag_srcinner1grid_table_Container" >
            
                 <div id="Main_Grid_Container" style="overflow:scroll;height:520px;" runat="server">

                


                  <asp:GridView ID="gv_details" runat="server" AllowPaging="false"  
                         AutoGenerateColumns="true"
                            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                            CellPadding="1" CellSpacing="1" CssClass="grid-view" 
                            DataKeyNames="JOBID" EmptyDataText="NO RECORD FOUND"
                            ShowHeaderWhenEmpty="True" Width="100%" 
                         onrowcreated="gv_details_RowCreated" 
                         onrowdatabound="gv_details_RowDataBound" >
                              
                           
                            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid" CssClass="column_style_right" 
                            BorderWidth="1px" />
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server" onclick="Check_Click(this)"  />
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
               
                </div>
            </div>
             
         
             
        </div>
         
         
       </asp:Content>
