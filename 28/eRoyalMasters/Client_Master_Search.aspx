<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master"
    CodeFile="Client_Master_Search.aspx.cs" Inherits="eRoyalMasters_Client_Master_Search" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
       th a
       {
           text-decoration: none;
       }
         .space
       {
          padding-left:20%;
          height:15px;
          width:12px;
          vertical-align:middle;
       }
       
        .space_2
       {
          padding-left:20%;
          height:16px;
          width:14px;
          
          vertical-align:middle;
       }
   </style>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
           
            <div>
                <div id="innerbox_MidMain" >
                    <div id="tag_srcinner1">
                        <div id="newbu">
                           <%-- <input type="submit" value="Submit" class="new" onclick="opennewclientnew(); return false" />--%>
                             <input type="submit" value="Submit" class="new" onclick="opennewclientnew_N(); return false" />
                        </div>
                        <div id="verslic">
                        </div>
                        <div id="editbu">
                            <a href="#" class="edit"></a>
                        </div>
                           <div id="editbu">
                                   <asp:Button ID="btnitemCopy" Text="Quick Entry" CssClass="autowidupdatebut" Visible="false"
                                 runat="server" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');open_AD_Code_Bulk_Entry('New'); return false;"  />
                             </div>
                               <div id="editbu">
                            <a href="#" class="edit"></a>
                        </div>
                        <div id="mainmastop2container_rght_tag2_txt1">
                            CLIENT MASTER</div>
                        <div id="verslic">
                        </div>
                        <div id="editbu" style="padding-top: 3px;">
                            <asp:ImageButton ID="btnexcel" runat="server" ImageUrl="~/images/xls.jpg" Height="28px"
                                Width="28px" OnClientClick="Excel()" />
                        </div>
                         <div id="newbu">
                           <%-- <input type="submit" value="Submit" class="new" onclick="opennewclientnew_N(); return false" />--%>
                        </div>
                    </div>
                    <div id="tag_srcinner" style="width:1050px; margin-left:5px">
                        <div id="tag_srcinner_lft" style="width:250px">
                            <div id="tag_srcinner_lft_in1" style="width:250px">
                                <div id="txt-container_src_l" style="width:250px">
                                    <div id="tag_label_src">
                                        Client Name</div>
                                    <asp:TextBox ID="txtimpexpname" runat="server" Width="160px" CssClass="txtbox_none" Onkeypress="return numchar1(event)"
                                        ClientIDMode="Static" MaxLength="50" TabIndex="1"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                         <div id="tag_srcinner_lft" style="width:180px">
                            <div id="tag_srcinner_lft_in1" style="width:180px">
                                <div id="txt-container_src_l" style="width:180px">
                                    <div id="tag_label_src" style="width:40px">
                                        Type</div>
                                    <asp:DropDownList ID="ddlType" runat="server" TabIndex="2"  CssClass="listtxt-s_inner" Width="120px" 
                                    >
                                    <asp:ListItem Value="">Standard</asp:ListItem>
                                    <asp:ListItem Value="Non_STD">Non-Standard</asp:ListItem>

                                </asp:DropDownList>
                                </div>
                            </div>
                        </div><div id="tag_srcinner_lft" style="width:210px">
                            <div id="tag_srcinner_lft_in1" style="width:210px">
                                <div id="txt-container_src_l" style="width:210px">
                                    <div id="tag_label_src" style="width:50px">
                                        IEC No.</div>
                                    <asp:TextBox ID="txtIecno" runat="server" CssClass="txtbox_none" Onkeypress="return numchar1(event)"
                                        ClientIDMode="Static" Width="150px" TabIndex="3"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div id="tag_srcinner_lft" style="width:210px">
                            <div id="tag_srcinner_lft_in1" style="width:210px">
                                <div id="txt-container_src_l" style="width:210px">
                                    <div id="tag_label_src" style="width:40px">
                                        State</div>
                                    <asp:TextBox ID="txtCommercial_StateName" runat="server" CssClass="txtbox_none" Onkeypress="return char(event)"
                                        ClientIDMode="Static" Width="160px" TabIndex="4"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div id="tag_srcinner_rght_Single_line">
                            <div id="small-butt-left">
                                <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                                    tabindex="2" onclick="page_Loading();"></a>
                            </div>
                            <div id="small-butt-rght">
                                <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="3"></a>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="innerbox_MidMain_Grid">
                    <div id="tag_srcinner1grid">
                        <div id="allbu">
                            <input id="submit" type="submit" value="Submit" class="allgrid" runat="server" onserverclick="btnSearchAll_Click" /></div>
                        <div id="verslic">
                        </div>
                        <div id="mainmastop2container_rght_tag3">
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt">#</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('A','A_Z')">A</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('B','A_Z')">B</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('C','A_Z')">C</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('D','A_Z')">D</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('E','A_Z')">E</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('F','A_Z')">F</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('G','A_Z')">G</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('H','A_Z')">H</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('I','A_Z')">I</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('J','A_Z')">J</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('K','A_Z')">K</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('L','A_Z')">L</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('M','A_Z')">M</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('N','A_Z')">N</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('O','A_Z')">O</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('P','A_Z')">P</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('Q','A_Z')">Q</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('R','A_Z')">R</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('S','A_Z')">S</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('T','A_Z')">T</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('U','A_Z')">U</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('V','A_Z')">V</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('W','A_Z')">W</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('X','A_Z')">X</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('Y','A_Z')">Y</a></div>
                            <div id="small-alph-icon-tag">
                                <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('Z','A_Z')">Z</a></div>
                        </div>
                    </div>
                    <div class="pagination" id="Div_Pagination" runat="server">
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
                        <span class="selected">Page
                            <asp:Label ID="lblTotalPages" runat="server" Visible="false"></asp:Label>-
                            <asp:Label ID="lblCurrentPage" runat="server"></asp:Label>
                        </span>
                        <%-- <span class="selected"> [Record <%= gvdetails.PageIndex * gvdetails.PageSize%> - <%= gvdetails.PageIndex * gvdetails.PageSize + gvdetails.PageSize - 1%>]</span>
                        --%>
                        <span class="disabled">
                            <asp:LinkButton CommandName="Next" ID="btnNext" runat="server" OnCommand="ChangePage">Next</asp:LinkButton></span>
                        <span class="disabled">
                            <asp:LinkButton CommandName="Last" ID="btnLast" runat="server" OnCommand="ChangePage">Last</asp:LinkButton>
                        </span>
                    </div>
                    <div runat="server" id="div_pagination1" visible="false">
                        <br />
                        <br />
                    </div>
                    <div id="tag_srcinner1grid_table_Container">
                        <div id="Main_Grid_Container">
                            <asp:GridView runat="server" ID="gvdetails" DataKeyNames="IMP_EXP_ID" PageSize="23"
                                ShowHeader="true" AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view"
                                OnRowCreated="gvdetails_RowCreated" Width="100%" 
                                ShowHeaderWhenEmpty="True" AllowPaging="True"
                                OnRowDataBound="gvdetails_RowDataBound" Style="overflow: auto" AllowSorting="True"
                                ShowFooter="True" onsorting="gvdetails_Sorting" >
                                
                                <SortedAscendingHeaderStyle CssClass="sortasc" />
                                 <SortedDescendingHeaderStyle CssClass="sortdesc" />
                                                       
                                  <HeaderStyle  Font-Underline="false" ForeColor="Black"   />
                                <Columns>
                                    <asp:BoundField DataField="IMP_EXP_NAME"  HeaderText="CLIENT" SortExpression="IMP_EXP_NAME"  >
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IMP_EXP_IECNO" HeaderText="IEC NO" SortExpression="IMP_EXP_IECNO">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IMP_EXP_BRSLNO" HeaderText="BRANCH">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IMP_EXP_ADD1" HeaderText="ADDRESS 1">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <%--<asp:BoundField DataField="IMP_EXP_ADD2" HeaderText="ADDRESS 2" />--%>
                                    <asp:BoundField DataField="IMP_EXP_ADD3"  HeaderText="CITY" SortExpression="IMP_EXP_ADD3">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IMP_EXP_ADD4" HeaderText="STATE" SortExpression="IMP_EXP_ADD4">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IMP_EXP_PIN_CODE" HeaderText="PINCODE" >
                                      <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                         </asp:BoundField>
                                    <%--<asp:BoundField DataField="IMP_EXP_CONTACT_PERSON" HeaderText="CONTACT" />--%>
                                    <asp:BoundField DataField="IMP_EXP_PHONE" HeaderText="PHONE NO" >
                                      <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                         </asp:BoundField>
                                </Columns>
                                <PagerSettings Visible="False" />
                            </asp:GridView>
                        </div>
                    </div>
              
                </div>
            </div>
            <asp:HiddenField ID="hdn_A_to_Z_Search" runat="server" />
             <asp:HiddenField ID="HD_tbl_sort" runat="server" />
             <asp:HiddenField ID="hdsort" runat="server" />
              <asp:HiddenField ID="Hdn_GetValue" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>

    <script>

        window.onload = happycode;
        function happycode() {
            document.getElementById("Client_Id").className = 'smenuactive';
            document.getElementById("Master_Id").click();

        }
        function Get_A_to_Z_Value_Master(val, val2) {
      

            document.getElementById("<%=hdn_A_to_Z_Search.ClientID %>").value = val;
            document.getElementById("<%=Hdn_GetValue.ClientID %>").value = val2;
            document.getElementById("<%=btnSearch.ClientID %>").click();
           
        }

    </script>
      <script src="../js/eRoyalmaster_Jscript/eRoyalMasters.js" type="text/javascript"></script>
    <script src="../js/eRoyalmaster_Jscript/eRoyalMasters.js" type="text/javascript"></script>
    <script type="text/javascript">
        var win = null;
        var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
        var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

        if (lastProductId != 'NO RECORD FOUND') {
            function Excel() {
                win = window.open('../FlatFile/MIS_report_1.aspx?CHA_CLIENT_LIST_TO_EXCEL=Yes', 'ndf');
                Loading_HideImage();
            }
        }

        $(function () {
            $("#txtimpexpname").autocomplete({

                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_List1",
                        //                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById("hdfTransport_mode").value + "'}",
                        //                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById('hdfTransport_mode').value + "' ,'Type':'" + document.getElementById('Hdn_STANDARD_TYPE').value + "'}",
                        data: "{ 'mail': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {

                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txtimpexpname').validationEngine('showPrompt', 'Incorrect Consignee Name', 'error', 'topRight', true);

                                //jAlert('ExporterName is Incorrect', 'GENERAL', function (r) { document.getElementById("txtExporterName").focus(); });
                                //return false;
                            }
                            else {
                                jQuery('#txtimpexpname').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            ////alert(textStatus);
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;

        });

        $(function () {

            $('#txtCommercial_StateName').bind('focus keyup keypress change keydown', function () {

                var data = $(this).val();
                commercial_state(data);

            });
        });

        function commercial_state(val) {

            var data = val;
            if (data == '') {
                $('#txtCommercial_StateCode').val('');
            }
            //$('#hdn_Autosearch').val(data);

            if (data.indexOf("-") != -1) {


                var s = data.split('-');

                var before = s[0];
                var after = s[1];

                $('#txtCommercial_StateCode').val(after);
                $('#txtCommercial_StateName').val(before);

            }
            else {

            }
        }
        $(function () {
            $("#txtCommercial_StateName").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/State_Master_Name_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txtCommercial_StateName').validationEngine('showPrompt', 'Incorrect State Name', 'error', 'topRight', true);

                                //jAlert('State Export is Incorrect', 'GENERAL', function (r) { document.getElementById("txtStateExport').focus(); });
                                //return false;
                            }
                            else {
                                jQuery('#txtCommercial_StateName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            ////alert(textStatus);
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });

        $(function () {

            $("#txtIecno").autocomplete({

                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_IECCode_List",
                        data: "{ 'mail': '" + request.term + "' ,'IEC':''}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);

                            if (data.d == '') {
                                jQuery('#txtIecno').validationEngine('showPrompt', 'Incorrect IEC Code', 'error', 'topRight', true);
                                //jAlert('IEC Code is Incorrect', 'ADCODE MASTER', function (r) { document.getElementById('txtIec_Code').focus(); });
                                //return false;
                            }
                            else {
                                jQuery('#txtIecno').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            ////alert(textStatus);
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });
    </script>

</asp:Content>
