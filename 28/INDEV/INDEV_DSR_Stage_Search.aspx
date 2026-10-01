<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="INDEV_DSR_Stage_Search.aspx.cs" Inherits="INDEV_DSR_Stage_Search" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
   
<style type="text/css">
.roundcorner
{
border:2px solid #a1a1a1;
padding:5px 5px; 
background:#dddddd;
width:150px;
text-align:center;
border-radius:25px;
-moz-border-radius:35px; /* Firefox 3.6 and earlier */
}

</style>
    
    <div id="innerbox_MidMain_Grid" >
      <div id="mainmastop2container_rght_tag2_txt1" style="margin-top:08px;">
                 <asp:Literal ID="ltl" Text="DSR Entry"   runat="server"></asp:Literal>
                 
             </div>
            <div id="Main_Grid_Container" runat="server"  style="margin-top:50px;">  
             
                <div id="pop_text_area_transac_popup_inn_container_left_new" style=" width:100%;">
                 
                                
                                 <br />
                                 
                                <div id="mainmastop2container_rght_tag2_txt1" style="width:100% ; height:10%;"><asp:Button ID="btnstage_I" runat="server" CssClass="roundcorner" Text=" Stage I "  
                                OnClientClick="open_Imp_DSR_State_I_New('New'); return false"   />
                                 * Status, Remarks, Aging 
                                  </div> <br />
                               <div id="mainmastop2container_rght_tag2_txt1" style="width:100% ; height:10%;"><asp:Button ID="btnstage_II" runat="server"  OnClientClick="open_Imp_DSR_State_II_New('New'); return false"  CssClass="roundcorner" Text="Stage II " />
                                 * Doc. Rec. Date, Gate in Export, I ETD from orgin Port, I Transit Port ETA, II Transit Port ETA, II ETD from Transit Port ... etc
                                 </div> <br />
                                <div id="mainmastop2container_rght_tag2_txt1" style="width:100% ; height:10%;" ><asp:Button ID="btnstage_III"  OnClientClick="open_Imp_DSR_Stage_III_New('New'); return false"  runat="server" CssClass="roundcorner" Text="Stage III " />
                                 * Checklist date, Checklist approval date, License Number, BOE Type, BE date, Assessment date, PD Bond No, ... etc
                                  </div> <br />
                               <div id="mainmastop2container_rght_tag2_txt1" style="width:100% ; height:10%;" ><asp:Button ID="btnstage_IV" OnClientClick="open_Imp_DSR_Stage_IV_New('New'); return false" runat="server" CssClass="roundcorner" Text="Stage IV " /> 
                                 * Contr Arval CCTL WIT TIMG, D.O Validity Dt, Last free date CNTR Detention, Container Reached CFS, ... etc
                                </div> <br />
                                <div id="mainmastop2container_rght_tag2_txt1" style="width:100% ; height:10%;" ><asp:Button ID="btnstage_V" OnClientClick="open_Imp_DSR_Stage_V_New('New'); return false" runat="server" CssClass="roundcorner" Text="Stage V " /> 
                                * Ground Rent Charges, Vehicle Detention Days, No of Ground Rent Days, No of Detention Days, Detention, CFS Charges, ... etc
                                 </div> <br />
            </div>
         </div>
       </div>
     
        <style type="text/css">
            .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
       
    </style>
   


</asp:Content>

