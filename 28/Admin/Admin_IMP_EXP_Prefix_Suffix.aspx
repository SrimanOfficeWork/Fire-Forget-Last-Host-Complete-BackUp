<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_IMP_EXP_Prefix_Suffix.aspx.cs" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" 
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
    <div id="innerbox_MidMain_Grid">
        <div id="tag_srcinner1">
            <div id="mainmastop2container_rght_tag2_txt1">
                Job prefix Suffix </div>
        </div>
        <div id="tag_srcinner2">
            
            <div id="innerbox_transac_bot_inn" style="height:10px;">
                   
                </div>
            <div id="pop_text_area_transac_popup_inn_container_left_Checklist">
            <div id="Branch_1" runat="server">
                <div id="innerbox_transac_bot_inn">
                    <div id="tag_label_transaction_popup_gen">
                        Branch
                    </div>
                    <div id="txtcon_m_src_new_Checklist">
                        <asp:DropDownList ID="ddlbranch" runat="server" CssClass="txtbox_none" AutoPostBack="true"
                            onselectedindexchanged="ddlbranch_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
             </div>
             <div id="Common_I" runat="server"  >
                <div id="innerbox_transac_bot_inn" >
                    <div id="mainmastop2container_rght_tag2_txt1" style="width:220px">
                        Import Initialization Jobno
                    </div>
                    <div id="txtcon_m_src_new_Checklist">
                        <asp:TextBox ID="txt_Imp_common_jobno" runat="server" placeholder = "Job No" onkeypress="return pin(event)"  MaxLength="40" Width="120px"  CssClass="txtbox_none_CheckList"></asp:TextBox>
                    </div>
                </div>
             </div>

                <fieldset style="border:Black;border-style:double;">
                <legend style="border:Black;border-collapse: collapse; width:50px;" > Import </legend>
                <div id="innerbox_transac_bot_inn" style="width:500px;">
                    <div id="tag_label_transaction_popup_gen">
                        Air </div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big" style="width:380px;">
                          
                                <asp:TextBox ID="txt_Prefix_IA"  runat="server" placeholder = "Prefix"   MaxLength="40" titele="Text" Width="100px"    CssClass="txtbox_none_CheckList"></asp:TextBox> &nbsp;/&nbsp;
                                <asp:TextBox ID="txtJobNo_IA" runat="server" placeholder = "Job No" onkeypress="return pin(event)"  MaxLength="40" Width="120px"  CssClass="txtbox_none_CheckList"></asp:TextBox>&nbsp;/&nbsp;
                                <asp:TextBox ID="txt_Suffix_IA" runat="server" placeholder = "Suffix" MaxLength="40" Width="100px" CssClass="txtbox_none_CheckList"></asp:TextBox>
                    </div>
                     
                </div>
                
                <div id="innerbox_transac_bot_inn" style="width:500px;">
                    <div id="tag_label_transaction_popup_gen">
                       Sea  
                        </div>
                    <div id="txtcon_m_src_new_Checklist" style="width:380px;">
                        <asp:TextBox ID="txt_Prefix_IS"  runat="server" placeholder = "Prefix"   MaxLength="40" titele="Text" Width="100px"    CssClass="txtbox_none_CheckList"></asp:TextBox> &nbsp;/&nbsp;
                                <asp:TextBox ID="txtJobNo_IS" runat="server" placeholder = "Job No" onkeypress="return pin(event)"  MaxLength="40" Width="120px"  CssClass="txtbox_none_CheckList"></asp:TextBox>&nbsp;/&nbsp;
                                <asp:TextBox ID="txt_Suffix_IS" runat="server" placeholder = "Suffix" MaxLength="40" Width="100px" CssClass="txtbox_none_CheckList"></asp:TextBox>
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn" style="width:500px;">
                    <div id="tag_label_transaction_popup_gen" >
                        Land </div>
                    <div id="txtcon_m_src_new_Checklist" style="width:380px;">
                         <asp:TextBox ID="txt_Prefix_IL"  runat="server" placeholder = "Prefix"   MaxLength="40" titele="Text" Width="100px"    CssClass="txtbox_none_CheckList"></asp:TextBox> &nbsp;/&nbsp;
                                <asp:TextBox ID="txtJobNo_IL" runat="server" onkeypress="return pin(event)" placeholder = "Job No"  MaxLength="40" Width="120px"  CssClass="txtbox_none_CheckList"></asp:TextBox>&nbsp;/&nbsp;
                                <asp:TextBox ID="txt_Suffix_IL" runat="server" placeholder = "Suffix" MaxLength="40" Width="100px" CssClass="txtbox_none_CheckList"></asp:TextBox>
                      </br>
                          <span style="color:Red;" >  <asp:Literal ID="lblimp" runat="server"></asp:Literal> </span> 
                    </div>
                    
                   
                </div>
                </fieldset>
                <div id="Common_E" runat="server" style="margin:20px;">
                <div id="innerbox_transac_bot_inn">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width:220px">
                        Export Initialization Jobno
                    </div>
                    <div id="txtcon_m_src_new_Checklist">
                        <asp:TextBox ID="txt_Exp_common_jobno" runat="server" placeholder = "Job No" onkeypress="return pin(event)"  MaxLength="40" Width="120px"  CssClass="txtbox_none_CheckList"></asp:TextBox>
                    </div>
                </div>
             </div>

                <fieldset style="border:Black;border-style:double;">
                <legend style="border:Black;border-collapse: collapse; width:50px;" > Export </legend>
                <div id="innerbox_transac_bot_inn" style="width:500px;">
                    <div id="tag_label_transaction_popup_gen">
                        Air </div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big" style="width:380px;">
                          
                                <asp:TextBox ID="txt_Prefix_EA"  runat="server" placeholder = "Prefix"   MaxLength="40" titele="Text" Width="100px"    CssClass="txtbox_none_CheckList"></asp:TextBox> &nbsp;/&nbsp;
                                <asp:TextBox ID="txtJobNo_EA" runat="server" onkeypress="return pin(event)" placeholder = "Job No"  MaxLength="40" Width="120px"  CssClass="txtbox_none_CheckList"></asp:TextBox>&nbsp;/&nbsp;
                                <asp:TextBox ID="txt_Suffix_EA" runat="server" placeholder = "Suffix" MaxLength="40" Width="100px" CssClass="txtbox_none_CheckList"></asp:TextBox>
                    </div>
                     
                </div>
                
                <div id="innerbox_transac_bot_inn" style="width:500px;">
                    <div id="tag_label_transaction_popup_gen">
                       Sea  
                        </div>
                    <div id="txtcon_m_src_new_Checklist" style="width:380px;">
                        <asp:TextBox ID="txt_Prefix_ES"  runat="server" placeholder = "Prefix"   MaxLength="40" titele="Text" Width="100px"    CssClass="txtbox_none_CheckList"></asp:TextBox> &nbsp;/&nbsp;
                                <asp:TextBox ID="txtJobNo_ES" runat="server" onkeypress="return pin(event)" placeholder = "Job No"  MaxLength="40" Width="120px"  CssClass="txtbox_none_CheckList"></asp:TextBox>&nbsp;/&nbsp;
                                <asp:TextBox ID="txt_Suffix_ES" runat="server" placeholder = "Suffix" MaxLength="40" Width="100px" CssClass="txtbox_none_CheckList"></asp:TextBox>
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn" style="width:500px;">
                    <div id="tag_label_transaction_popup_gen" >
                        Land </div>
                    <div id="txtcon_m_src_new_Checklist" style="width:380px;">
                         <asp:TextBox ID="txt_Prefix_EL"  runat="server" placeholder = "Prefix"   MaxLength="40" titele="Text" Width="100px"    CssClass="txtbox_none_CheckList"></asp:TextBox> &nbsp;/&nbsp;
                                <asp:TextBox ID="txtJobNo_EL" runat="server" onkeypress="return pin(event)" placeholder = "Job No"  MaxLength="40" Width="120px"  CssClass="txtbox_none_CheckList"></asp:TextBox>&nbsp;/&nbsp;
                                <asp:TextBox ID="txt_Suffix_EL" runat="server" placeholder = "Suffix" MaxLength="40" Width="100px" CssClass="txtbox_none_CheckList"></asp:TextBox>
                     </br>
                          <span style="color:Red;" > <asp:Literal ID="lblexp" runat="server"></asp:Literal> </span> 
                    </div>
                </div>
                </fieldset>
                 <div id="innerbox_transac_bot_inn" >
                 </div>
                   <div id="innerbox_transac_bot_inn" style="width:500px;">
                    <div id="tag_label_transaction_popup_gen" >
                        <asp:Button ID="btnsave_update" runat="server" Text="Save & Update" 
                            onclick="btnsave_update_Click" />
                        
                    </div>
                    <%--<div id="txtcon_m_src_new_Checklist" style="width:380px;">
                    </div>--%>
                </div>
            </div>
   
    </div>
    </div>
</asp:Content>
