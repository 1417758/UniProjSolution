<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PersonalDetailsUserControl.ascx.cs" Inherits="UserControls_PersonalDetailsUserControl" %>


<table>
    <tr>
        <td>Title</td>
        <td>
            <asp:DropDownList ID="DropDownListTitles" runat="server"></asp:DropDownList></td>
    </tr>
    <tr>
        <td>First Name</td>
        <td>
            <asp:TextBox ID="TextBoxFirstName" runat="server" placeholder="First Name"  ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" runat="server" ErrorMessage="First Name is required."
                ControlToValidate="TextBoxFirstName" ValidationGroup="PersDetails">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>Last Name</td>
        <td>
            <asp:TextBox ID="TextBoxLastName" runat="server" placeholder="Last Name"  ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" runat="server" ErrorMessage="Last Name is required."
                ControlToValidate="TextBoxLastName" ValidationGroup="PersDetails">*</asp:RequiredFieldValidator>
        </td>
    </tr>

</table>