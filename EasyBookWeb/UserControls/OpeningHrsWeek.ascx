<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OpeningHrsWeek.ascx.cs" Inherits="UserControls_OpeningHrsWeek" %>
<%@ Register Src="~/UserControls/OpeningHrs.ascx" TagPrefix="uc1" TagName="OpeningHrs" %>


<table style="padding:15px;">
    <tr>
        <td>Monday</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem Text="ON" Selected="True"></asp:ListItem>
                <asp:ListItem Text="OFF" Selected="False"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td><uc1:OpeningHrs runat="server" ID="OpeningHrsMonday" /></td>
    </tr>
    <tr>
        <td>Tuesday</td>
        <td> <asp:RadioButtonList ID="RadioButtonList2" runat="server">
                <asp:ListItem Text="ON" Selected="True"></asp:ListItem>
                <asp:ListItem Text="OFF" Selected="False"></asp:ListItem>
            </asp:RadioButtonList></td>
        <td><uc1:OpeningHrs runat="server" ID="OpeningHrsTuesday" /></td>
    </tr>
     <tr>
        <td>Wednesday</td>
        <td> <asp:RadioButtonList ID="RadioButtonList3" runat="server">
                <asp:ListItem Text="ON" Selected="True"></asp:ListItem>
                <asp:ListItem Text="OFF" Selected="False"></asp:ListItem>
            </asp:RadioButtonList></td>
        <td><uc1:OpeningHrs runat="server" ID="OpeningHrsWednesday" /></td>
    </tr>
     <tr>
        <td>Thursday</td>
        <td> <asp:RadioButtonList ID="RadioButtonList4" runat="server">
                <asp:ListItem Text="ON" Selected="True"></asp:ListItem>
                <asp:ListItem Text="OFF" Selected="False"></asp:ListItem>
            </asp:RadioButtonList></td>
        <td><uc1:OpeningHrs runat="server" ID="OpeningHrsThursday" /></td>
    </tr>
     <tr>
        <td>Friday</td>
        <td> <asp:RadioButtonList ID="RadioButtonList5" runat="server">
                <asp:ListItem Text="ON" Selected="True"></asp:ListItem>
                <asp:ListItem Text="OFF" Selected="False"></asp:ListItem>
            </asp:RadioButtonList></td>
        <td><uc1:OpeningHrs runat="server" ID="OpeningHrsFriday" /></td>
    </tr>
     <tr>
        <td>Saturday</td>
        <td> <asp:RadioButtonList ID="RadioButtonList6" runat="server">
                <asp:ListItem Text="ON" Selected="False"></asp:ListItem>
                <asp:ListItem Text="OFF" Selected="True"></asp:ListItem>
            </asp:RadioButtonList></td>
        <td><uc1:OpeningHrs runat="server" ID="OpeningHrsSaturday" /></td>
    </tr>
     <tr>
        <td>Sunday</td>
        <td> <asp:RadioButtonList ID="RadioButtonList7" runat="server">
                <asp:ListItem Text="ON" Selected="False"></asp:ListItem>
                <asp:ListItem Text="OFF" Selected="True"></asp:ListItem>
            </asp:RadioButtonList></td>
        <td><uc1:OpeningHrs runat="server" ID="OpeningHrsSunday" /></td>
    </tr>
</table>




