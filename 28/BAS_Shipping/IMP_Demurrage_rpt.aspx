<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="IMP_Demurrage_rpt.aspx.cs" Inherits="IMP_Demurrage_rpt" %> 
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
        .ad
        {
            width: 50px;
        }
    </style>

       <style type="text/css">
        th a
        {
            text-decoration: none;
        }
        .padding
        {
           padding-left:10px;
           padding-top:3px;
        }
        
    </style>


<div id="innerbox_MidMain" >

<div id="tag_srcinner1" >
        

<div id="tag_srcinner1"  >
         
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1" style="width:350px;">
                   Demurrage Report
                 </div>

            </div>
            
             <div id="tag_transact_src_inner" style="width: 1030px;">

                    <div id="tag_Exchange_inner_lft">
                       

                        <div id="tag_transact_lft_in1" style="width: 885px;">

                                       <div id="tag_label_transact_Src" style="width: 75px;" >
                               Job No
                            </div>

                            <div id="txtcon-m_transaction_code">
                                <asp:DropDownList ID="ddljobno" runat="server" CssClass="txtbox_none" Font-Size="12px" Width="100px" >
                                </asp:DropDownList>
                            </div>
                             <div id="tag_label_transaction_popup_IGM2_empty"></div>
                             <div id="tag_label_transaction_popup_gen"> Importer Name</div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                <asp:DropDownList ID="ddlimp_name" runat="server" CssClass="txtbox_none" Font-Size="12px" Width="250px" >
                                </asp:DropDownList>  
                            </div>
                           
                            <div id="tag_label_transaction_popup_no_empty">
                            </div>
                            <div id="tag_label_transaction_Src_longlabel" style="width: 45px;">
                                Tax % </div>
                            <div id="txtcon-m_transaction_code">
                               <asp:TextBox ID="txttax_per" runat="server" CssClass="validate[required] txtbox_none" Width="50px" Text ="18.00"
                                 MaxLength="6"></asp:TextBox>
                            </div>


                        </div>

                  
                    </div>
                                               
                            <div id="tag_transact_srcinner_rght">  <%--onclick="return validdate();"--%>
                        <div id="small-butt-left">
                            <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click" 
                                tabindex="5"></a>
                        </div>
                        <div id="small-butt-rght">
                            <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="6"></a>
                        </div>
                    </div>
                    </div>
              
                </div>
                 
                     </div>
      

    
         <div id="innerbox_MidMain_Grid"  style="height:580px;">
            <div id="tag_srcinner1grid">
             <div id="txtcon-m_transaction_code" style="margin-top:08px;width:70px;">
             <asp:ImageButton ID="btnexcel" runat="server"   ImageUrl="~/images/xls.jpg"  Height="28px" Width="28px"  OnClientClick="EXcel(); return false;"/>
              
              </div>

            </div>
          
                <div id="tag_srcinner1grid_table_Container" >
            
                 <div id="Main_Grid_Container" style="overflow:hidden;" runat="server">
                 
                 
                   <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="true"
                    CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="150%"
                     OnRowDataBound="gvdetails_RowDataBound" CellPadding="1"
                    CellSpacing="1" OnRowCreated="gvdetails_RowCreated">
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        CssClass="column_style_right" BorderWidth="1px" />
                    <HeaderStyle Font-Underline="false" ForeColor="Black" />
                  
                </asp:GridView>
                </div>
            </div>
             
         
             
        </div>

        <style type="text/css">
            .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
       
    </style>
     <asp:HiddenField ID="hd_Jobno" runat="server"  />
      <asp:HiddenField ID="HDBranch" runat="server" />



  <script type="text/javascript">
      $(document).ready(function () {

          var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
          var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

          if (totalRows > 2) {
              gridviewScroll();
          }
          else {

              if (lastProductId > 0) {
                  gridviewScroll();
              }
              else {
                  document.getElementById('<%=Main_Grid_Container.ClientID %>').style.overflow = "Auto";
                  document.getElementById('<%=gvdetails.ClientID %>').style.overflow = "100%";
                  document.getElementById('<%=gvdetails.ClientID %>').style.width = "100%";
                  /*alert (lastProductId);*/
              }
          }

      });

      function gridviewScroll() {
          gridView1 = $('#<%=gvdetails.ClientID %>').gridviewScroll({

              width: "99.9%",
              height: 520,
              railcolor: "#F0F0F0",
              barcolor: "#CDCDCD",
              barhovercolor: "#606060",
              bgcolor: "#F0F0F0",
              freezesize: 2,
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



    <script type="text/javascript">
        var win = null;

        var win = null;
        var ddljobno = document.getElementById("<%=ddljobno.ClientID%>").value;
        var ddlimp_name = document.getElementById("<%=ddlimp_name.ClientID%>").value;

        var txttax_per = $('#<%= txttax_per.ClientID %>').val();
        var Branch = $('#<%= HDBranch.ClientID %>').val();

        var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
        var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();


        if (lastProductId != 'NO RECORD FOUND') {
            function EXcel() {

                win = window.open('../FlatFile/MIS_report_1.aspx?IMP_Demurrage_rpt=Yes&ddljobno=' + ddljobno + '&ddlimp_name=' + ddlimp_name + '&txttax_per=' + txttax_per + '&Branch=' + Branch + '', 'ndf');
                    Loading_HideImage();
            }

        }

  </script>
</asp:Content>

