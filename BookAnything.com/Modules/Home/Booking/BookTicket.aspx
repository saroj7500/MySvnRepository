<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/WebMasterPage.master" AutoEventWireup="true" CodeFile="BookTicket.aspx.cs" Inherits="Modules_Home_Booking_BookTicket" %>

 <%@Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Body" Runat="Server">
    <asp:ScriptManager ID="ScriptManager_BookTicket" runat="server"></asp:ScriptManager>
     <div style="width:100%;height:100%;background-color:cyan;">
         <div style="height:40%;width:30%;float:right;padding-top:20px;">
             <h3>Login:</h3>
            <table> 
           <tr><td>Username</td><td><asp:TextBox ID="TextBox_UserName" runat="server" Height="25px"></asp:TextBox></td></tr>
                <tr><td>Password</td><td><asp:TextBox ID="TextBox_Password" runat="server" Height="25px"></asp:TextBox></td></tr>
                <tr><td></td><td><asp:Button ID="Button_Submit" runat="server" Text="Login" /></td></tr>
                <tr><td><a href="#" style="color:red;">Forget Password</a></td></tr>
                <tr><td><a href="#" style="color:red;"> New User</a></td></tr>
                </table>
         </div>
    <div style="width:70%;height:50%;margin-top:100px; margin-left:50px;">
        <table style="width:600px;height:auto;border:thick; border-color:red;padding-top:20px;">
            <tr><td><h4>From</h4></td>
                <td><asp:TextBox ID="TextBox_From" runat="server" Height="25px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_TextBoxForm" runat="server" ControlToValidate="TextBox_From" Text="*Required Field " ForeColor="Red" SetFocusOnError="true" 
                     Display="Dynamic"></asp:RequiredFieldValidator></td></tr>

       <tr><td><h4>To</h4></td> 
        <td><asp:TextBox ID="TextBox_To" runat="server" Height="25px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_TextBoxTo" runat="server" ControlToValidate="TextBox_To" Text="*Required Field" ForeColor="Red" SetFocusOnError="true" 
                Display="Dynamic"></asp:RequiredFieldValidator></td></tr>
       
       <tr><td><h4>Date Of Journey</h4></td><td><asp:TextBox ID="TextBox_DateOfJourney" runat="server" Height="25px"></asp:TextBox>
           <asp:ImageButton ID="ImageButton_CalenderExtender" ImageUrl="~/SystemFolder/SystemImages/CalenderExtender.jpg" Height="25px" Width="25px" runat="server" 
               style="vertical-align:middle;" CausesValidation="false" />
             <asp:RequiredFieldValidator ID="RequiredFieldValidator_DateOfJourney" runat="server" ControlToValidate="TextBox_DateOfJourney" Text="*Required Field" ForeColor="Red" SetFocusOnError="true" 
                Display="Dynamic" InitialValue="__/__/____"></asp:RequiredFieldValidator></td></tr>
            
      <tr><td><h4>Depature Time Between</h4></td><td><asp:DropDownList ID="DropDownList1" runat="server" Width="100px" Height="25px">
                <asp:ListItem Text="Any Time" Value="0"></asp:ListItem></asp:DropDownList> ---
              <asp:DropDownList ID="DropDownList2" runat="server" Width="100px" Height="25px">
                <asp:ListItem Text="Any Time" Value="0"></asp:ListItem></asp:DropDownList></td></tr>
              
       <tr><td><h4>Type</h4></td><td><asp:DropDownList ID="DropDownList_BusType" runat="server" Width="100px" Height="25px">
                <asp:ListItem Text="Select" Value="0"></asp:ListItem></asp:DropDownList>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator__BusType" runat="server" ControlToValidate="DropDownList_BusType" Text="*Required Field" ForeColor="Red" SetFocusOnError="true" 
                Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator></td></tr>
            
            <tr><td></td><td>
                <asp:RadioButtonList ID="RadioButtonList_JourneyType" runat="server" TextAlign="Right" RepeatLayout="Table" style="display:block;" RepeatDirection="Horizontal">
                    <asp:ListItem Text="One Way" Value="0" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Return Journey" Value="1"></asp:ListItem>
                </asp:RadioButtonList>
               
               </td></tr>
            <tr><td></td><td><asp:Button ID="Button_BookTicket" runat="server" Text="Book" /><asp:Button ID="Button1" runat="server" Text="Clear" /></td></tr>
            <ajax:MaskedEditExtender ID="MaskedEditExtender_DateOfjourney" runat="server" TargetControlID="TextBox_DateOfJourney" MaskType="Date" InputDirection="LeftToRight" 
                ErrorTooltipEnabled="true" AcceptNegative="None" ClearMaskOnLostFocus="false" ClearTextOnInvalid="true" UserDateFormat="DayMonthYear" 
                Mask="99/99/9999" ClipboardEnabled="true"></ajax:MaskedEditExtender>
            
        </table>
        <ajax:CalendarExtender ID="CalendarExtender_DateOfJourney" runat="server" PopupButtonID="ImageButton_CalenderExtender" 
            TargetControlID="TextBox_Dateofjourney"></ajax:CalendarExtender>
        
    </div>
         
     </div>
    
</asp:Content>

