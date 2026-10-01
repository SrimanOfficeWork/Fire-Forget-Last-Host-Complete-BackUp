
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Job_Initialization.aspx.cs" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
    Inherits="Users_Job_Initialization" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

   
               
                <div id="innerbox_MidMain_Grid">
                    <div id="tag_srcinner1">
                        <div id="mainmastop2container_rght_tag2_txt1">
                            Import Job-Initialization</div>
                    </div>
                    <div id="tag_srcinner2">
                        <div id="tag_srcinner_lft1">
                            <div id="tag_label_transaction_popup_no_empty">
                            </div>
                            <div id="tag_label_transaction_popup_gen">
                                Job No</div>
                            <div id="txtcon-m_src">
                                <%--<asp:TextBox ID="txtimpexpname" runat="server" CssClass="txtbox_none" MaxLength="10" ></asp:TextBox>--%>
                                <%-- <input class="txtbox_none" type="text" id="txtimpexpname" runat="server" disabled="false"
                                    maxlength="10" />--%>
                               <%-- <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="txtbox_none">
                                    <asp:ListItem>Select</asp:ListItem>
                                </asp:DropDownList>--%>

                                  <asp:TextBox ID="txtJobNo" runat="server" MaxLength="40" ClientIDMode="Static"
                                        CssClass="txtbox_none_CheckList"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_srcinner_rght_Single_line">
                            <div id="small-butt-left">
                                <asp:Button ID="btnSave" CssClass="save" runat="server" 
                                    onclick="btnSave_Click" />
                              
                             <%--  <a href="#" class="generate" id="btnSearch" runat="server" onclick="open_jobno(); return false">
                                </a>--%>
                            </div>
                            <div id="small-butt-rght">
                                <a href="../../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt"></a>
                            </div>
                        </div>
                       
                    </div>
                </div>
          
    <asp:HiddenField ID="HiddenField1" runat="server" />


       </asp:Content>

