<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPages/WebMasterPage.master" AutoEventWireup="false" CodeFile="search.aspx.vb" Inherits="MasterPages_search" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Body" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div style="width:100%;height:100%;">
       From <asp:TextBox ID="TextBox_From" runat="server"></asp:TextBox>
        To<asp:TextBox ID="TextBox_To" runat="server"></asp:TextBox>
        Date<asp:Calendar ID="Calender_Date" runat="server"></asp:Calendar>
        No. of Seat<ajax:CalendarExtender ID="CalendarExtender1" runat="server"></ajax:CalendarExtender>
    </div>
</asp:Content>
