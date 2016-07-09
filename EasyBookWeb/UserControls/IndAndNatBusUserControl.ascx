<%@ Control Language="C#" AutoEventWireup="true" CodeFile="IndAndNatBusUserControl.ascx.cs" Inherits="UserControls_IndAndNatBusUserControl" %>

Industry:
<asp:DropDownList ID="DropDownListInd" runat="server" OnSelectedIndexChanged="DropDownListInd_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>

<br />
Nature of Business:
<asp:DropDownList ID="DropDownListNatOfBuss" runat="server" OnSelectedIndexChanged="DropDownListNatOfBuss_SelectedIndexChanged"></asp:DropDownList>
