<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_IMP_EXP_Prefix_Suffix_Areawise.aspx.cs" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" 
Inherits="Admin_IMP_EXP_Prefix_Suffix" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<script type="text/javascript">
    $('#txtJobNo_Prefix_IA,#txtJobNo_Prefix_IS').attr("placeholder", "enter some text");
    $('#txtJobNo_IA,#txtJobNo_IS').attr("placeholder", "enter some text");
    $('#txt_Suffix_IA,#txt_Suffix_IS').attr("placeholder", "enter some text");
</script>

<style type="text/css">
fieldset
{
  max-width:500px;
  padding:16px;	
}
.legend1
{
  margin-bottom:0px;
  margin-left:16px;
}
</style>

<script type="text/javascript">
    $(document).ready(function () {
        $("#btnsave_update").click(function () {

            var Imp_max_job = document.getElementById("hdn_Imp_MaxJobno").value;
            var Exp_max_job = document.getElementById("hdn_Exp_MaxJobno").value;
            var Select_Type = document.getElementById("hdn_Select_Type").value;

            if (Select_Type == 'Common Job') {

                //---------------------------- Import------------------------------------
                if (document.getElementById("txt_Imp_common_jobno").value != '') {
                    if (parseInt(document.getElementById("txt_Imp_common_jobno").value) < parseInt(Imp_max_job)) {
                        jAlert('Import Job Number Greater than Current Jobno', 'Job Prefix Suffix', function (r) { document.getElementById("txt_Imp_common_jobno").focus(); });
                        return false;
                    }
                }
                //---------------------------- Export------------------------------------
                if (document.getElementById("txt_Exp_common_jobno").value != '') {
                    if (parseInt(document.getElementById("txt_Exp_common_jobno").value) < parseInt(Exp_max_job)) {
                        jAlert('Export Job Number Greater than Current Jobno', 'Job Prefix Suffix', function (r) { document.getElementById("txt_Exp_common_jobno").focus(); });
                        return false;
                    }
                }
            }
            else {//Branch & Areawise

                //---------------------------- Import------------------------------------

                if (document.getElementById("txtJobNo_IA").value != '') {
                    if (parseInt(document.getElementById("txtJobNo_IA").value) < parseInt(Imp_max_job)) {
                        jAlert('Import Job Number Greater than Current Jobno', 'Job Prefix Suffix', function (r) { document.getElementById("txtJobNo_IA").focus(); });
                        return false;
                    }
                }

                if (document.getElementById("txtJobNo_IS").value != '') {
                    if (parseInt(document.getElementById("txtJobNo_IS").value) < parseInt(Imp_max_job)) {
                        jAlert('Import Job Number Greater than Current Jobno', 'Job Prefix Suffix', function (r) { document.getElementById("txtJobNo_IS").focus(); });
                        return false;
                    }
                }

                if (document.getElementById("txtJobNo_IL").value != '') {
                    if (parseInt(document.getElementById("txtJobNo_IL").value) < parseInt(Imp_max_job)) {
                        jAlert('Import Job Number Greater than Current Jobno', 'Job Prefix Suffix', function (r) { document.getElementById("txtJobNo_IL").focus(); });
                        return false;
                    }
                }


                //---------------------------- Export------------------------------------
                if (document.getElementById("txtJobNo_EA").value != '') {
                    if (parseInt(document.getElementById("txtJobNo_EA").value) < parseInt(Exp_max_job)) {
                        jAlert('Export Job Number Greater than Current Jobno', 'Job Prefix Suffix', function (r) { document.getElementById("txt_Prefix_EA").focus(); });
                        return false;
                    }
                }

                if (document.getElementById("txtJobNo_ES").value != '') {
                    if (parseInt(document.getElementById("txtJobNo_ES").value) < parseInt(Exp_max_job)) {
                        jAlert('Export Job Number Greater than Current Jobno', 'Job Prefix Suffix', function (r) { document.getElementById("txt_Prefix_ES").focus(); });
                        return false;
                    }
                }

                if (document.getElementById("txtJobNo_EL").value != '') {
                    if (parseInt(document.getElementById("txtJobNo_EL").value) < parseInt(Exp_max_job)) {
                        jAlert('Export Job Number Greater than Current Jobno', 'Job Prefix Suffix', function (r) { document.getElementById("txt_Prefix_EL").focus(); });
                        return false;
                    }
                }
            }

        });
    });
  </script>


    <div id="innerbox_MidMain_Grid">
        <div id="tag_srcinner1">
            <div id="mainmastop2container_rght_tag2_txt1">
                Job prefix Suffix </div>
        </div>
        <div id="tag_srcinner2">
            <div id="innerbox_transac_bot_inn" style="height: 10px;">
            </div>
            <div id="pop_text_area_transac_popup_inn_container_left_Checklist">
                <div id="Branch_1" runat="server" style="width: 680px">
                    <div id="innerbox_transac_bot_inn">
                        <div id="tag_label_transaction_popup_gen" style="width: 90px">
                            Select Group
                        </div>
                        <div id="txtcon_m_src_new_Checklist" style="width: 200px">
                            <asp:DropDownList ID="ddlGrpname" runat="server" onkeyup="autotab(this);" CssClass="validate[required] txtbox_none_Mid_transac_InvNew"
                                OnSelectedIndexChanged="ddlGrpname_SelectedIndexChanged" AutoPostBack="true" Width="180px"
                                TabIndex="1">
                            </asp:DropDownList>
                        </div>
                      
                        <div id="tag_label_transaction_popup_gen" style="width: 60px">
                            Branch
                        </div>
                        <div id="txtcon_m_src_new_Checklist" style="width: 200px">
                            <asp:DropDownList ID="ddlbranch" runat="server" CssClass="txtbox_none" AutoPostBack="true" Width="190px"
                                OnSelectedIndexChanged="ddlbranch_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_gen" style="width: 70px">
                            CusHouse
                        </div>
                        <div id="txtcon_m_src_new_Checklist" style="width: 70px">
                            <asp:TextBox ID="txt_Cushouse" runat="server" Enabled="false" MaxLength="40" Width="100px"
                                CssClass="txtbox_none_CheckList"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div id="Common_I" runat="server">
                    <div id="innerbox_transac_bot_inn">
                        <div id="mainmastop2container_rght_tag2_txt1" style="width: 220px">
                            Import Initialization Jobno
                        </div>
                        <div id="txtcon_m_src_new_Checklist">
                            <asp:TextBox ID="txt_Imp_common_jobno" runat="server" placeholder="Job No" onkeypress="return pin(event)" ClientIDMode="Static"
                                MaxLength="40" Width="120px" CssClass="txtbox_none_CheckList"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <fieldset style="border: Black; border-style: double;">
                    <legend style="border: Black; border-collapse: collapse; width: 50px;">Import </legend>
                    <div id="innerbox_transac_bot_inn" style="width: 500px;">
                        <div id="tag_label_transaction_popup_gen">
                            Air
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big" style="width: 380px;">
                            <asp:TextBox ID="txt_Prefix_IA" runat="server" placeholder="Prefix" MaxLength="40"
                                titele="Text" Width="100px" CssClass="txtbox_none_CheckList"></asp:TextBox>
                            &nbsp;/&nbsp;
                            <asp:TextBox ID="txtJobNo_IA" runat="server" placeholder="Job No" onkeypress="return pin(event)" ClientIDMode="Static"
                                MaxLength="40" Width="120px" CssClass="txtbox_none_CheckList"></asp:TextBox>&nbsp;/&nbsp;
                            <asp:TextBox ID="txt_Suffix_IA" runat="server" placeholder="Suffix" MaxLength="40"
                                Width="100px" CssClass="txtbox_none_CheckList"></asp:TextBox>
                        </div>
                    </div>
                    <div id="innerbox_transac_bot_inn" style="width: 500px;">
                        <div id="tag_label_transaction_popup_gen">
                            Sea
                        </div>
                        <div id="txtcon_m_src_new_Checklist" style="width: 380px;">
                            <asp:TextBox ID="txt_Prefix_IS" runat="server" placeholder="Prefix" MaxLength="40"
                                titele="Text" Width="100px" CssClass="txtbox_none_CheckList"></asp:TextBox>
                            &nbsp;/&nbsp;
                            <asp:TextBox ID="txtJobNo_IS" runat="server" placeholder="Job No" onkeypress="return pin(event)" ClientIDMode="Static"
                                MaxLength="40" Width="120px" CssClass="txtbox_none_CheckList"></asp:TextBox>&nbsp;/&nbsp;
                            <asp:TextBox ID="txt_Suffix_IS" runat="server" placeholder="Suffix" MaxLength="40"
                                Width="100px" CssClass="txtbox_none_CheckList"></asp:TextBox>
                        </div>
                    </div>
                    <div id="innerbox_transac_bot_inn" style="width: 500px;">
                        <div id="tag_label_transaction_popup_gen">
                            Land
                        </div>
                        <div id="txtcon_m_src_new_Checklist" style="width: 380px;">
                            <asp:TextBox ID="txt_Prefix_IL" runat="server" placeholder="Prefix" MaxLength="40"
                                titele="Text" Width="100px" CssClass="txtbox_none_CheckList"></asp:TextBox>
                            &nbsp;/&nbsp;
                            <asp:TextBox ID="txtJobNo_IL" runat="server" onkeypress="return pin(event)" placeholder="Job No" ClientIDMode="Static"
                                MaxLength="40" Width="120px" CssClass="txtbox_none_CheckList"></asp:TextBox>&nbsp;/&nbsp;
                            <asp:TextBox ID="txt_Suffix_IL" runat="server" placeholder="Suffix" MaxLength="40"
                                Width="100px" CssClass="txtbox_none_CheckList"></asp:TextBox>
                             <span style="color: Red;">
                                <asp:Literal ID="lblimp" runat="server"></asp:Literal>
                                
                            </span>
                        </div>
                    </div>
                </fieldset>
                <div id="Common_E" runat="server" style="margin: 20px;">
                    <div id="innerbox_transac_bot_inn">
                        <div id="mainmastop2container_rght_tag2_txt1" style="width: 220px">
                            Export Initialization Jobno
                        </div>
                        <div id="txtcon_m_src_new_Checklist">
                            <asp:TextBox ID="txt_Exp_common_jobno" runat="server" placeholder="Job No" onkeypress="return pin(event)" ClientIDMode="Static"
                                MaxLength="40" Width="120px" CssClass="txtbox_none_CheckList"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <fieldset style="border: Black; border-style: double;">
                    <legend style="border: Black; border-collapse: collapse; width: 50px;">Export </legend>
                    <div id="innerbox_transac_bot_inn" style="width: 500px;">
                        <div id="tag_label_transaction_popup_gen">
                            Air
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big" style="width: 380px;">
                            <asp:TextBox ID="txt_Prefix_EA" runat="server" placeholder="Prefix" MaxLength="40"
                                titele="Text" Width="100px" CssClass="txtbox_none_CheckList"></asp:TextBox>
                            &nbsp;/&nbsp;
                            <asp:TextBox ID="txtJobNo_EA" runat="server" onkeypress="return pin(event)" placeholder="Job No" ClientIDMode="Static"
                                MaxLength="40" Width="120px" CssClass="txtbox_none_CheckList"></asp:TextBox>&nbsp;/&nbsp;
                            <asp:TextBox ID="txt_Suffix_EA" runat="server" placeholder="Suffix" MaxLength="40"
                                Width="100px" CssClass="txtbox_none_CheckList"></asp:TextBox>
                        </div>
                    </div>
                    <div id="innerbox_transac_bot_inn" style="width: 500px;">
                        <div id="tag_label_transaction_popup_gen">
                            Sea
                        </div>
                        <div id="txtcon_m_src_new_Checklist" style="width: 380px;">
                            <asp:TextBox ID="txt_Prefix_ES" runat="server" placeholder="Prefix" MaxLength="40"
                                titele="Text" Width="100px" CssClass="txtbox_none_CheckList"></asp:TextBox>
                            &nbsp;/&nbsp;
                            <asp:TextBox ID="txtJobNo_ES" runat="server" onkeypress="return pin(event)" placeholder="Job No" ClientIDMode="Static"
                                MaxLength="40" Width="120px" CssClass="txtbox_none_CheckList"></asp:TextBox>&nbsp;/&nbsp;
                            <asp:TextBox ID="txt_Suffix_ES" runat="server" placeholder="Suffix" MaxLength="40"
                                Width="100px" CssClass="txtbox_none_CheckList"></asp:TextBox>
                        </div>
                    </div>
                    <div id="innerbox_transac_bot_inn" style="width: 500px;">
                        <div id="tag_label_transaction_popup_gen">
                            Land
                        </div>
                        <div id="txtcon_m_src_new_Checklist" style="width: 380px;">
                            <asp:TextBox ID="txt_Prefix_EL" runat="server" placeholder="Prefix" MaxLength="40"
                                titele="Text" Width="100px" CssClass="txtbox_none_CheckList"></asp:TextBox>
                            &nbsp;/&nbsp;
                            <asp:TextBox ID="txtJobNo_EL" runat="server" onkeypress="return pin(event)" placeholder="Job No" ClientIDMode="Static"
                                MaxLength="40" Width="120px" CssClass="txtbox_none_CheckList"></asp:TextBox>&nbsp;/&nbsp;
                            <asp:TextBox ID="txt_Suffix_EL" runat="server" placeholder="Suffix" MaxLength="40"
                                Width="100px" CssClass="txtbox_none_CheckList"></asp:TextBox>
                                <span style="color: Red;">
                                <asp:Literal ID="lblexp" runat="server"></asp:Literal>
                            </span>
                        </div>
                    </div>
                </fieldset>
                <div id="innerbox_transac_bot_inn">
                </div>
                <div id="innerbox_transac_bot_inn" style="width: 500px;">
                    <div id="tag_label_transaction_popup_gen">
                        <asp:Button ID="btnsave_update" runat="server" Text="Save & Update" OnClick="btnsave_update_Click" ClientIDMode="Static" />
                    </div>

                    <div id="tag_label_transaction_popup_gen">
                        <asp:Button ID="btn_view" runat="server" Text="View Details" 
                          OnClientClick ="jQuery('#form1').validationEngine('hideAll');OpenPopup_Job_Prefix_Suffix_Areawise(''); return false"  />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField ID="hdn_Select_Type" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_Imp_MaxJobno" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_Exp_MaxJobno" runat="server" ClientIDMode="Static" />

</asp:Content>
