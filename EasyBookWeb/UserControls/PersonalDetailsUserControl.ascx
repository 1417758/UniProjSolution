<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PersonalDetailsUserControl.ascx.cs" Inherits="UserControls_PersonalDetailsUserControl" %>



<asp:Table ID="Table2" runat="server">
    <asp:TableRow>
        <asp:TableCell ID="row1_c1">Title</asp:TableCell>
        <asp:TableCell>
            <asp:DropDownList ID="DropDownListTitles" runat="server"></asp:DropDownList></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>First Name</asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="TextBoxFirstName" runat="server" placeholder="First Name"  ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" runat="server" ErrorMessage="First Name is required."
                ControlToValidate="TextBoxFirstName" ValidationGroup="PersDetails">*</asp:RequiredFieldValidator>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>Last Name</asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="TextBoxLastName" runat="server" placeholder="Last Name"  ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" runat="server" ErrorMessage="Last Name is required."
                ControlToValidate="TextBoxLastName" ValidationGroup="PersDetails">*</asp:RequiredFieldValidator>
        </asp:TableCell>
    </asp:TableRow>

</asp:Table>