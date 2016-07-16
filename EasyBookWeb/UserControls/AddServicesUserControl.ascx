<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddServicesUserControl.ascx.cs" Inherits="UserControls_AddServicesUserControl" %>
<table >
     <tr>
        <td >Service Name</td>
        <td>Duration (min)</td>
        <td>Price (£)</td>
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
        <td><asp:TextBox ID="TextBoxService" runat="server" placeholder="Service"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorService" runat="server" ErrorMessage="Service name is required."
                ControlToValidate="TextBoxService" ValidationGroup="AddService">*</asp:RequiredFieldValidator>
        </td>
        <td><asp:TextBox ID="TextBoxDuration" runat="server" placeholder="Duration" type="number" min="0" max="255"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDuration" runat="server" ErrorMessage="Service duration is required."
                ControlToValidate="TextBoxDuration" ValidationGroup="AddService">*</asp:RequiredFieldValidator>
        </td>
         <td><asp:TextBox ID="TextBoxPrice" runat="server" placeholder="Price" type="number" step="0.01"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidatorPrice" runat="server" ErrorMessage="Service price is required."
                ControlToValidate="TextBoxPrice" ValidationGroup="AddService">*</asp:RequiredFieldValidator>
         </td>
        <td><asp:DropDownList ID="DropDownListStaff" runat="server"></asp:DropDownList></td>
        <td><asp:Button ID="ButtonAdd" runat="server" Text="Add" OnClick="ButtonAdd_Click" /></td>
    </tr>
</table>
