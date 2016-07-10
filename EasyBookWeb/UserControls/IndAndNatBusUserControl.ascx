<%@ Control Language="C#" AutoEventWireup="true" CodeFile="IndAndNatBusUserControl.ascx.cs" Inherits="UserControls_IndAndNatBusUserControl" %>


<table>
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
        <td><asp:TextBox ID="TextBoxPhone" runat="server" AutoCompleteType="BusinessPhone"></asp:TextBox></td>
    </tr>

</table>



                    
