<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddServicesUserControl.ascx.cs" Inherits="UserControls_AddServicesUserControl" %>
<table >
     <tr>
        <td >Service Name</td>
        <td>Duration</td>
        <td>Price</td>
        <td colspan="2">Member of Staff</td>
        
    </tr>
    <tr>
        <td ><asp:BulletedList ID="BulletedListService" runat="server"></asp:BulletedList></td>
        <td><asp:BulletedList ID="BulletedListDuration" runat="server"></asp:BulletedList></td>
        <td><asp:BulletedList ID="BulletedListPrice" runat="server"></asp:BulletedList></td>
        <td><asp:BulletedList ID="BulletedListStaff" runat="server"></asp:BulletedList></td>
        <td></td>
    </tr>
      <tr>
        <td><asp:TextBox ID="TextBoxService" runat="server"></asp:TextBox></td>
        <td><asp:TextBox ID="TextBoxDuration" runat="server"></asp:TextBox></td>
         <td><asp:TextBox ID="TextBoxPrice" runat="server"></asp:TextBox></td>
        <td><asp:DropDownList ID="DropDownListStaff" runat="server"></asp:DropDownList></td>
        <td><asp:Button ID="ButtonAdd" runat="server" Text="Add" OnClick="ButtonAdd_Click" /></td>
    </tr>
</table>
