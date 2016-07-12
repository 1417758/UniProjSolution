<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddStaffUserControl.ascx.cs" Inherits="UserControls_AddStaffUserControl" %>

<table >
     <tr>
        <td>Title</td>
        <td>Employee First Name</td>
         <td>Employee Last Name</td>
        <td colspan="2">Email Address</td>
    </tr>
    <tr>
        <td><asp:BulletedList ID="BulletedListTitle" runat="server"></asp:BulletedList></td>
        <td><asp:BulletedList ID="BulletedList1stName" runat="server"></asp:BulletedList></td>
        <td><asp:BulletedList ID="BulletedListLastName" runat="server"></asp:BulletedList></td>
        <td colspan="2"><asp:BulletedList ID="BulletedListEmail" runat="server"></asp:BulletedList></td>
    </tr>
      <tr>
        <td><asp:DropDownList ID="DropDownListTitle" runat="server"></asp:DropDownList></td>
        <td><asp:TextBox ID="TextBox1stName" runat="server" placeholder="First Name"></asp:TextBox></td>
        <td><asp:TextBox ID="TextBoxLastName" runat="server" placeholder="Last Name"></asp:TextBox></td>
        <td><asp:TextBox ID="TextBoxEmail" runat="server" placeholder="Email Address"></asp:TextBox></td>
        <td><asp:Button ID="ButtonAdd" runat="server" Text="Add" OnClick="ButtonAdd_Click" /></td>
    </tr>
</table>


