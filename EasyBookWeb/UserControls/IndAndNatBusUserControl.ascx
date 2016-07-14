<%@ Control Language="C#" AutoEventWireup="true" CodeFile="IndAndNatBusUserControl.ascx.cs" Inherits="UserControls_IndAndNatBusUserControl" %>


<table>
     <tr>
        <td>Business Name</td>
        <td>
            <asp:TextBox ID="TextBoxDomain" runat="server" placeholder="Company Name"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidatorDomain" runat="server" ErrorMessage="Business Name is required."
                ControlToValidate="TextBoxDomain" ValidationGroup="BusDetails">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>Industry:</td>
        <td>
            <asp:DropDownList ID="DropDownListInd" runat="server" OnSelectedIndexChanged="DropDownListInd_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>Nature of Business:</td>
        <td>
            <asp:DropDownList ID="DropDownListNatOfBuss" runat="server" OnSelectedIndexChanged="DropDownListNatOfBuss_SelectedIndexChanged"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>Business Phone No:</td>
        <td><asp:TextBox ID="TextBoxPhone" runat="server" placeholder="Business Phone Number" type="number"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhone" runat="server" ErrorMessage="Business Phone Number is required."
                ControlToValidate="TextBoxPhone" ValidationGroup="BusDetails">*</asp:RequiredFieldValidator>
        </td>
    </tr>

</table>



                    
