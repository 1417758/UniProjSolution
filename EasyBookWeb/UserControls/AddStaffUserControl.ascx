<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddStaffUserControl.ascx.cs" Inherits="UserControls_AddStaffUserControl" %>

<table >
     <tr>
        <td>Employee First Name</td>
         <td>Employee Last Name</td>
        <td colspan="2">Email Address</td>
    </tr>
    <tr>
        <td><asp:BulletedList ID="BulletedList1stName" runat="server"></asp:BulletedList></td>
        <td><asp:BulletedList ID="BulletedListLastName" runat="server"></asp:BulletedList></td>
        <td colspan="2"><asp:BulletedList ID="BulletedListEmail" runat="server"></asp:BulletedList></td>
    </tr>
      <tr>
        <td><asp:TextBox ID="TextBox1stName" runat="server"></asp:TextBox></td>
        <td><asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox></td>
        <td><asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox></td>
        <td><asp:Button ID="ButtonAdd" runat="server" Text="Add" OnClick="ButtonAdd_Click" /></td>
    </tr>
</table>


