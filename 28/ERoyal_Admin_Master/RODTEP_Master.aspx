<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master" CodeFile="RODTEP_Master.aspx.cs" Inherits="RODTEP_Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >

<link href="../Master_StyleSheet.css" rel="stylesheet" type="text/css" />
 <script src="../js/eRoyalmaster_Jscript/eRoyalMasters.js" type="text/javascript"></script>

 <style type="text/css">
    #Validation123
        {
            top: 35% !important;
            left: 55% !important;
            width: 100%;
            max-width: 62% !important;
            background-color: #fbdbdb !important;
            border: 3px solid #cc6b4d;
            height: 36% !important;
        }

</style>
<script language='javascript'>
    window.onload = happycode;
    function happycode() {
        document.getElementById("Drawback_Tab").className = 'smenuactive';
        document.getElementById("ADMIN_ID").click();

    }
      
</script>
    <script type ="text/javascript" >
        function validateLimit(obj, divID, maxchar) {

            objDiv = get_object(divID);

            if (this.id) obj = this;

            var remaningChar = maxchar - trimEnter(obj.value).length;

            if (objDiv.id) {
                objDiv.innerHTML = remaningChar + "";
            }
            if (remaningChar <= 0) {
                obj.value = obj.value.substring(maxchar, 0);
                if (objDiv.id) {
                    objDiv.innerHTML = "0 ";
                }
                return false;
            }
            else
            { return true; }
        }
        function get_object(id) {
            var object = null;
            if (document.layers) {
                object = document.layers[id];
            } else if (document.all) {
                object = document.all[id];
            } else if (document.getElementById) {
                object = document.getElementById(id);
            }
            return object;
        }

        function trimEnter(dataStr) {
            return dataStr.replace(/(\r\n|\r|\n)/g, "");
        }

</script>
    <script type="text/javascript">


        function num1(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 27 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

        //    function numdot1(evt) {
        //        var charCode = (evt.which) ? evt.which : event.keyCode
        //        if (charCode > 27 && (charCode < 48 || charCode > 57) && (charCode < 46 || charCode > 46))
        //            return false;
        //        return true;
        //    }

        function notn(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 27 && (charCode < 48 || charCode > 57) && (charCode < 47 || charCode > 47))
                return false;
            return true;
        }

        function char1(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 27 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
                return false;
            return true;
        }

        function ChangeCase(elem) {
            elem.value = elem.value.toUpperCase();
        }

        function numcharDOT(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 27 && (charCode < 48 || charCode > 57) && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode < 46 || charCode > 46))
                return false;
            return true;
        }


        function numdot1(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 27 && (charCode < 48 || charCode > 57) && (charCode < 46 || charCode > 46))
                return false;
            return true;
        }
    
    </script>
    <script type="text/javascript">
        function validate() {
            var txtRODTEPTAR = document.getElementById("<%=txtRODTEPTAR.ClientID%>").value;
            if (txtRODTEPTAR.length <= 0) {
                alert("Tariff cannot be blank");
                document.getElementById("<%=txtRODTEPTAR.ClientID%>").focus();
                return false;
            }
            var txtDesC;
            TxtDesC = document.getElementById("<%=txtDesC.ClientID%>").value;

            if (txtDesC.length <= 0) {


                alert("Description  cannot be blank");
                document.getElementById("<%=txtDesC.ClientID%>").focus();
                return false;
            }
            var txtRODTEPRATE;
            txtRODTEPRATE = document.getElementById("<%=txtRODTEPRATE.ClientID%>").value;

            if (txtRODTEPRATEe.length <= 0) {

                alert("Rate cannot be blank");
                document.getElementById("<%=txtRODTEPRATE.ClientID%>").focus();
                return false;

            }


            var txtRODTEPUQC;
            txtRODTEPUQC = document.getElementById("<%=txtRODTEPUQC.ClientID%>").value;

            if (txtRODTEPUQC.length <= 0) {

                alert("Unit cannot be blank");
                document.getElementById("<%=txtRODTEPUQC.ClientID%>").focus();
                return false;
            }


        }

        function ValidateFile() {
            jQuery('#form1').validationEngine('detach');

            var UpdatePriorities = $("#ContentPlaceHolder1_ddl_Priority").val();
            var FileValues = $('#ContentPlaceHolder1_fileuploadExcel').val();
            var CTH_CODE = $('#ContentPlaceHolder1_txtCth_Code_Search').val();
            var Count = 1;
            var Msg = "";
            if (FileValues == "" || FileValues == null) {
                Msg += Count + "." + "Please Upload file \n";
                Count++;
            }
            if (UpdatePriorities == "0") {
                Msg += Count + "." + "Select Update Priority \n";
                Count++;
            }
            else {
                if (UpdatePriorities == '1') {
                    var response = confirm('Are You Sure want to Delete Old Records');

                }
            }
            if (Msg != "") {
                alert(Msg);
                return false;
            }
            else {
                return true;
            }
        }


        function Excel_File_Validation() {
            $('#Validation123').css("display", "block");
        }

        function ClosePop_up() {
            $('#Validation123').css("display", "none");
        }
    </script>
    
   
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                </ProgressTemplate>
            </asp:UpdateProgress>
    <div >
        <div id="innerbox_MidMain_admin_catagory" style="height: 180px">
            <div id="tag_srcinner1">
                <div id="mainmastop2container_rght_tag2_txt1">
                    Admin RODTEP Master
                </div>
            </div>
            <div id="tag_admin_catagory_src_inner" style="height: 90px">
                <div id="tag_admin_catagory_lft_in1" style="height: 25px; width: 800px">
                    <div id="txt_container_Transact_Main_l" style="width: 250px">
                        <div id="tag_label_transact_Src" style="width: 100px">
                            RODTEP TARIFF<br />
                        </div>
                        <div id="txtcon-m_transaction_src">
                            <asp:TextBox ID="txtRODTEPTAR" runat="server" MaxLength="15" CssClass="validate[required] txtbox_none_Mid_transac_src"
                                TabIndex="1" onkeypress="return notn(event)"></asp:TextBox>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 200px">
                        <div id="tag_label_transact_Src">
                            RODTEP RATE</div>
                        <div id="txtcon-m_transaction_item_maindet">
                            <asp:TextBox ID="txtRODTEPRATE" runat="server" MaxLength="15" onkeypress="return numdot1(event)"
                                CssClass="txtbox_none_Mid_transac_item_maindet" TabIndex="2"></asp:TextBox>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 200px">
                        <div id="tag_label_transact_Src">
                            RODTEP UQC
                        </div>
                        <div id="txtcon-m_transaction_item_maindet">
                            <asp:TextBox ID="txtRODTEPUQC" runat="server" MaxLength="10" onkeyup="autotab(this);"
                                ClientIDMode="Static" CssClass="validate[required,custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_CTH_small"
                                TabIndex="3" onkeypress="return char1(event)" onblur="return ChangeCase(this);"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_admin_catagory_lft_in1" style="width: 250px">
                        <div id="txt_container_Transact_Main_l" style="width: 250px">
                            <div id="tag_label_transact_Src" style="width: 100px">
                                RODTEP CAP
                            </div>
                            <div id="txtcon_m_admin_small_small_src">
                                <asp:TextBox ID="txtCAP" runat="server" MaxLength="15" CssClass="txtbox_none_Mid_transac_src"
                                    TabIndex="4" onkeypress="return notn(event)"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 200px; height: 20px">
                        <div id="tag_label_transact_Src" style="width: 100px">
                            RODTEP DESC
                        </div>
                        <div id="txtcon_m_admin_small_small_src" style="width: 500px; height: 50px">
                            <asp:TextBox ID="txtDesC" runat="server" MaxLength="100" onkeyDown="return checkTextAreaMaxLength(this,event,'100');"
                                onpaste="return checkTextAreaMaxLength(this,event,'100');" CssClass="txtbox_none_Mid_admin_remarks"
                                Width="200px" Height="29px" TextMode="MultiLine" TabIndex="5"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div id="tag_admin_catagory_lft_in1" style="height: 50px; width: 300px; height: 0px;">
            </div>
            <div id="innerbox_transac_bot_inn"  style="height: 0px ; width:900px">
                <div id="newbu">
                    <asp:Button ID="btnNew" runat="server" TabIndex="6" OnClick="btnNew_Click" CssClass="new"
                        CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" OnClientClick="return validate();"
                        CssClass="save" TabIndex="7" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="updates"
                        TabIndex="8" OnClientClick="return validate();" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" TabIndex="9"
                        CssClass="dlete" OnClientClick="return confirm('Are you sure want to delete?');" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnCancel" runat="server" CssClass="scancel" TabIndex="10" CausesValidation="true"
                        UseSubmitBehavior="false" OnClick="btnCancel_Click" />
                   </div>
                   
                         <div id="editbu" style="width: 8%;margin-top: -12px; margin-left:30px">
                                       
                           <asp:Panel ID="GridDownloadTemplate" runat="server">
                                <asp:LinkButton ID="lnkExport" runat="server" OnClick ="lnkExport_Click"   style="text-decoration: none; color: inherit;">
                            <span style="vertical-align: middle;">
                                <asp:Image ID="ImageExport" runat="server" ImageUrl="~/images/icons/xl.png" Width="34px" Height="28px" ToolTip="Download Excel" />
                       
                             <span >Download</span>
                            </span>
                        </asp:LinkButton>
                        </asp:Panel>

                       <span id="NewRODTEPTemplate" runat="server">
                           <a href="../Submission/Export_Excel_Format/RODEP_MASTER_BULK_UPLOAD.xlsx" style="text-decoration: none; color: inherit;">
           
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/icons/xl.png" Width="34px" Height="28px" ToolTip="Download Template" />
                               <br />         
                            <span>New</span>               
                           </a>
                       </span>

                    </div>

                    <div id="editbu" style="margin-top: 6px; margin-left: 25px;" >
                              <asp:FileUpload ID="fileuploadExcel" runat="server" style="Width:180px" onchange="document.getElementById('btn_upload').click();"
                                  TabIndex="14" />
                              <asp:Button ID="btn_upload" runat="server" Style="display: none;" />
                          </div>

                           <div id="editbu" style="width: 110px; margin-top: 15px; margin-left:30px">
                              <div id="editbu" style="width: 98px; margin-top: -35px; margin-bottom: 10px;">
                                  Update Priority</div>
                              <div id="editbu">
                                  <asp:DropDownList ID="ddl_Priority" AutoPostBack="false" runat="server" Width="90px"
                                      TabIndex="13">
                                      <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                      <asp:ListItem Text="Insert New" Value="3"></asp:ListItem>
                                      <asp:ListItem Text="Delete & New Insert" Value="1"></asp:ListItem>
                                      <asp:ListItem Text="Update & Insert" Value="2"></asp:ListItem>
                                  </asp:DropDownList>
                              </div>
                          </div>

                            <div id="editbu" style="margin-top: 10px;">
                              <asp:Button ID="btnUpload" runat="server" Width="100px" Height="25px" Text="Upload"
                                   OnClientClick="return ValidateFile();" OnClick ="btn_upload_Click"  CssClass="autowidmovebut"
                                  TabIndex="16" />
                          </div>
                                        </div>
    
                
            </div>
        </div>
    </div>
            <div id="tag_admin_src_border" style="width: 0px">
            </div>
            <div id="tag_transact_src_inner">
                <div id="tag_Adminsrc_inner_lft" style="width: 730px; height: 100px">
                    <div id="tag_transact_lft_in1" style="width: 540px">
                        <div id="txt_container_Transact_Main_l" style="width: 250px">
                            <div id="tag_label_transact_Src" style="width: 110px">
                                RODTEP TARIFF
                            </div>
                            <div id="txtcon-m_transaction_src" style="width: 120px">
                                <asp:TextBox ID="txtRODTEPTARSearch" runat="server" CssClass="txtbox_none" Onkeypress="return numchar1(event)"
                                    ClientIDMode="Static" Width="80px" MaxLength="15" TabIndex="11"></asp:TextBox>
                            </div>
                        </div>
                        <div id="txt_container_Transact_Main_l" style="width: 280px">
                            <div id="tag_label_transact_Src" style="width: 100px">
                                RODTEP DESC
                            </div>
                            <div id="txtcon-m_transaction_src" style="width: 180px">
                                <asp:TextBox ID="txtDesCSearch" runat="server" onfocus="jQuery('#form1').validationEngine('hide');"
                                    Width="170PX" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_src" MaxLength="100"
                                    TabIndex="12"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div id="tag_admin_srcinner_rght">
                        <div id="small-butt-left">
                            <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                                tabindex="13"></a>
                        </div>
                        <div id="small-butt-rght">
                            <a href="../E_royal_Impex_Main.aspx" class="cancelButt" onclick="RefreshParent();return false;"
                                tabindex="14"></a>
                        </div>
                    </div>
                </div>
            </div>
            <div id="Main_GridView" runat="server">
            <div id="innerbox_MidMain_Grid_Admin_catagory" style="height: 480px">
                <div id="tag_srcinner1grid" style="width: 790px; height: 45px">
                    <div id="allbu">
                        <input type="submit" value="Submit" class="allgrid" /></div>
                    <div id="verslic">
                    </div>
                    <div id="mainmastop2container_rght_tag3">
                        <div id="small-alph-icon-tag">
                            <a href="#" class="small-alph-iconButt">#</a></div>
                        <div id="small-alph-icon-tag">
                            <a href="#" class="small-alph-iconButt">A</a></div>
                        <div id="small-alph-icon-tag">
                            <a href="#" class="small-alph-iconButt">B</a></div>
                        <div id="small-alph-icon-tag">
                            <a href="#" class="small-alph-iconButt">C</a></div>
                        <div id="small-alph-icon-tag">
                            <a href="#" class="small-alph-iconButt">D</a></div>
                        <div id="small-alph-icon-tag">
                            <a href="#" class="small-alph-iconButt">E</a></div>
                        <div id="small-alph-icon-tag">
                            <a href="#" class="small-alph-iconButt">F</a></div>
                        <div id="small-alph-icon-tag">
                            <a href="#" class="small-alph-iconButt">G</a></div>
                        <div id="small-alph-icon-tag">
                            <a href="#" class="small-alph-iconButt">H</a></div>
                        <div id="small-alph-icon-tag">
                            <a href="#" class="small-alph-iconButt">I</a></div>
                        <div id="small-alph-icon-tag">
                            <a href="#" class="small-alph-iconButt">J</a></div>
                        <div id="small-alph-icon-tag">
                            <a href="#" class="small-alph-iconButt">K</a></div>
                        <div id="small-alph-icon-tag">
                            <a href="#" class="small-alph-iconButt">L</a></div>
                        <div id="small-alph-icon-tag">
                            <a href="#" class="small-alph-iconButt">M</a></div>
                        <div id="small-alph-icon-tag">
                            <a href="#" class="small-alph-iconButt">N</a></div>
                        <div id="small-alph-icon-tag">
                            <a href="#" class="small-alph-iconButt">O</a></div>
                        <div id="small-alph-icon-tag">
                            <a href="#" class="small-alph-iconButt">P</a></div>
                        <div id="small-alph-icon-tag">
                            <a href="#" class="small-alph-iconButt">Q</a></div>
                        <div id="small-alph-icon-tag">
                            <a href="#" class="small-alph-iconButt">R</a></div>
                        <div id="small-alph-icon-tag">
                            <a href="#" class="small-alph-iconButt">S</a></div>
                        <div id="small-alph-icon-tag">
                            <a href="#" class="small-alph-iconButt">T</a></div>
                        <div id="small-alph-icon-tag">
                            <a href="#" class="small-alph-iconButt">U</a></div>
                        <div id="small-alph-icon-tag">
                            <a href="#" class="small-alph-iconButt">V</a></div>
                        <div id="small-alph-icon-tag">
                            <a href="#" class="small-alph-iconButt">W</a></div>
                        <div id="small-alph-icon-tag">
                            <a href="#" class="small-alph-iconButt">X</a></div>
                        <div id="small-alph-icon-tag">
                            <a href="#" class="small-alph-iconButt">Y</a></div>
                        <div id="small-alph-icon-tag">
                            <a href="#" class="small-alph-iconButt">Z</a></div>
                    </div>
                </div>
                <div id="tag_Admin_srcinner1grid_table_Container" style="width: 690px; height: 410px">
                    <div id="Admin_Main_Grid_Container" style="width: 1046px; height: 350px">
                        <asp:GridView runat="server" ID="gvdetails" DataKeyNames="RODTEP_ID" EmptyDataText="NO RECORD FOUND"
                            AutoGenerateColumns="False" BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view"
                            OnRowCreated="gvdetails_RowCreated" Width="100%" ShowHeaderWhenEmpty="True" PageSize="15"
                            AllowPaging="True" OnSelectedIndexChanged="gvdetails_SelectedIndexChanged" OnRowDataBound="gvdetails_RowDataBound"
                            AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                            CellPadding="1" CellSpacing="1">
                            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                BorderWidth="1px" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True">
                                    <HeaderStyle CssClass="hideGridColumn" />
                                    <ItemStyle CssClass="hideGridColumn" />
                                </asp:CommandField>
                                <asp:BoundField DataField="RODTEP_TARIFF" HeaderText="RODTEP_TARIF">
                                    <ItemStyle CssClass="column_style_left6" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RODTEP_DESC" HeaderText="RODTEP_DESC">
                                    <ItemStyle CssClass="column_style_left6" Width="450px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RODTEP_RATE" HeaderText="RODTEP_RATE">
                                    <ItemStyle CssClass="column_style_left6" Width="90px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RODTEP_UQC" HeaderText="RODTEP_UQC">
                                    <ItemStyle CssClass="column_style_left6" Width="90px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RODTEP_CAP" HeaderText="RODTEP_CAP">
                                    <ItemStyle CssClass="column_style_left6" Width="90px" />
                                </asp:BoundField>
                            </Columns>
                            <PagerSettings Visible="False" />
                        </asp:GridView>
                    </div>
                </div>
                <div class="pagination" id="Div_Pagination" runat="server" style="width: 650px; height: 45px">
                    <div id="tag_label_transaction_popup_IGM_Container">
                        Page No.</div>
                    <div id="txtcon-m_transaction_list1_fcl">
                        <asp:DropDownList ID="ddlSelectPageno" runat="server" AutoPostBack="true" CssClass="listtxt_transac_FCL"
                            OnSelectedIndexChanged="ddlSelectPageno_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <span class="disabled">
                        <asp:LinkButton CommandName="First" ID="btnFirst" runat="server" OnCommand="ChangePage">« First</asp:LinkButton></span>
                    <span class="disabled">
                        <asp:LinkButton CommandName="Previous" ID="btnPrev" runat="server" OnCommand="ChangePage">« Previous</asp:LinkButton></span>
                    <span class="selected">Record
                        <asp:Label ID="lblCurrentPage" runat="server"></asp:Label>
                        -
                        <asp:Label ID="lblTotalPages" runat="server"></asp:Label></span> <span class="disabled">
                            <asp:LinkButton CommandName="Next" ID="btnNext" runat="server" OnCommand="ChangePage">Next</asp:LinkButton></span>
                    <span class="disabled">
                        <asp:LinkButton CommandName="Last" ID="btnLast" runat="server" OnCommand="ChangePage">Last</asp:LinkButton>
                    </span>
                </div>
            </div>
            </div>
            </div>

             <div id="Validation123" style="display: none; margin-top:80px">
                  <div id="popupwindow_closebut_right_new" style="margin-top: -12px; margin-right: 4px;">
                      <input type="close" value="Submit" class="clsicon_new" onclick="ClosePop_up()" style="width: 23px;
                          height: 27px;">
                  </div>
                  <asp:Label ID="Label12" runat="server"></asp:Label>
                  <div style="height: 300px;overflow: auto;">
                      <div style="margin-top: 13px;">
                          <asp:GridView ID="gv_Preview" runat="server" AllowPaging="false" AutoGenerateColumns="true"
                              BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                              CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
                              OnRowCreated="gvdetails_RowCreated" OnRowDataBound="gv_Details_RowDataBound"
                              Width="100%">
                              <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                  CssClass="column_style_right" BorderWidth="1px" />
                          </asp:GridView>
                      </div> 
                  </div>
              </div>

        </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>