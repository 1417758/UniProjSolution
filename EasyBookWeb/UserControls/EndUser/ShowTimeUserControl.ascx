<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ShowTimeUserControl.ascx.cs" Inherits="UserControls_EndUser_ShowTimeUserControl" %>

<asp:Table ID="TableShowTime" runat="server">
    <asp:TableHeaderRow Font-Size="Small">
        <asp:TableHeaderCell ID="EM_H">Early Morning</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="EB_H">Early Bird</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="M_H">Morning</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="A_H">Afternoon</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="E_H">Evening</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="N_H">Night</asp:TableHeaderCell>
    </asp:TableHeaderRow>
     <asp:TableRow>
        <asp:TableCell ID="EM_1"><asp:Button runat="server" ID="bttn0000" class="btn btn-default" Text="00:00" OnClick="bttn_Click"/></asp:TableCell>
        <asp:TableCell ID="EB_1"><asp:Button runat="server" ID="bttn0400" class="btn btn-default" Text="04:00" OnClick="bttn_Click"/></asp:TableCell>
        <asp:TableCell ID="M_1"><asp:Button runat="server" ID="bttn0800" class="btn btn-default" Text="08:00" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="A_1"><asp:Button runat="server" ID="bttn1200" class="btn btn-default" Text="12:00" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="E_1"><asp:Button runat="server" ID="bttn1600" class="btn btn-default" Text="16:00" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="N_1"><asp:Button runat="server" ID="bttn2000" class="btn btn-default" Text="20:00" OnClick="bttn_Click" /></asp:TableCell>
    </asp:TableRow>
     <asp:TableRow>
        <asp:TableCell ID="EM_2"><asp:Button runat="server" ID="bttn0030" class="btn btn-default" Text="00:30" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="EB_2"><asp:Button runat="server" ID="buttn0430" class="btn btn-default" Text="04:30" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="M_2"><asp:Button runat="server" ID="bttn0830" class="btn btn-default" Text="08:30" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="A_2"><asp:Button runat="server" ID="bttn1230" class="btn btn-default" Text="12:30" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="E_2"><asp:Button runat="server" ID="bttn1630" class="btn btn-default" Text="16:30" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="N_2"><asp:Button runat="server" ID="bttn2030" class="btn btn-default" Text="20:30" OnClick="bttn_Click" /></asp:TableCell>
    </asp:TableRow>
     <asp:TableRow>
        <asp:TableCell ID="EM_3"><asp:Button runat="server" ID="bttn0100" class="btn btn-default" Text="01:00" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="EB_3"><asp:Button runat="server" ID="txBox0500" class="btn btn-default" Text="05:00" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="M_3"><asp:Button runat="server" ID="bttn0900" class="btn btn-default" Text="09:00" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="A_3"><asp:Button runat="server" ID="bttn1300" class="btn btn-default" Text="13:00" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="E_3"><asp:Button runat="server" ID="bttn1700" class="btn btn-default" Text="17:00" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="N_3"><asp:Button runat="server" ID="bttn2100" class="btn btn-default" Text="21:00" OnClick="bttn_Click" /></asp:TableCell>
    </asp:TableRow>
     <asp:TableRow>
        <asp:TableCell ID="EM_4"><asp:Button runat="server" ID="bttn0130" class="btn btn-default" Text="01:30" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="EB_4"><asp:Button runat="server" ID="bttn0530" class="btn btn-default" Text="05:30" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="M_4"><asp:Button runat="server" ID="bttn0930" class="btn btn-default" Text="09:30" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="A_4"><asp:Button runat="server" ID="bttn1330" class="btn btn-default" Text="13:30" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="E_4"><asp:Button runat="server" ID="bttn1730" class="btn btn-default" Text="17:30" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="N_4"><asp:Button runat="server" ID="bttn2130" class="btn btn-default" Text="21:30" OnClick="bttn_Click" /></asp:TableCell>
    </asp:TableRow>
     <asp:TableRow>
        <asp:TableCell ID="EM_5"><asp:Button runat="server" ID="bttn0200" class="btn btn-default" Text="02:00" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="EB_5"><asp:Button runat="server" ID="bttn0600" class="btn btn-default" Text="06:00" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="M_5"><asp:Button runat="server" ID="bttn1000" class="btn btn-default" Text="10:00" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="A_5"><asp:Button runat="server" ID="bttn1400" class="btn btn-default" Text="14:00" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="E_5"><asp:Button runat="server" ID="bttn1800" class="btn btn-default" Text="18:00" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="N_5"><asp:Button runat="server" ID="bttn2200" class="btn btn-default" Text="22:00" OnClick="bttn_Click" /></asp:TableCell>
    </asp:TableRow>
     <asp:TableRow>
        <asp:TableCell ID="EM_6"><asp:Button runat="server" ID="bttn0230" class="btn btn-default" Text="02:30" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="EB_6"><asp:Button runat="server" ID="bttn0630" class="btn btn-default" Text="06:30" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="M_6"><asp:Button runat="server" ID="bttn1030" class="btn btn-default" Text="10:30" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="A_6"><asp:Button runat="server" ID="bttn1430" class="btn btn-default" Text="14:30" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="E_6"><asp:Button runat="server" ID="bttn1830" class="btn btn-default" Text="18:30" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="N_6"><asp:Button runat="server" ID="bttn2230" class="btn btn-default" Text="22:30" OnClick="bttn_Click" /></asp:TableCell>
    </asp:TableRow>
     <asp:TableRow>
        <asp:TableCell ID="EM_7"><asp:Button runat="server" ID="bttn0300" class="btn btn-default" Text="03:00" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="EB_7"><asp:Button runat="server" ID="bttn0700" class="btn btn-default" Text="07:00" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="M_7"><asp:Button runat="server" ID="bttn1100" class="btn btn-default" Text="11:00" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="A_7"><asp:Button runat="server" ID="bttn1500" class="btn btn-default" Text="15:00" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="E_7"><asp:Button runat="server" ID="bttn1900" class="btn btn-default" Text="19:00" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="N_7"><asp:Button runat="server" ID="bttn2300" class="btn btn-default" Text="23:00" OnClick="bttn_Click" /></asp:TableCell>
    </asp:TableRow>
     <asp:TableRow>
        <asp:TableCell ID="EM_8"><asp:Button runat="server" ID="bttn0330" class="btn btn-default" Text="03:30" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="EB_8"><asp:Button runat="server" ID="bttn0730" class="btn btn-default" Text="07:30" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="M_8"><asp:Button runat="server" ID="bttn1130" class="btn btn-default" Text="11:30" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="A_8"><asp:Button runat="server" ID="bttn1530" class="btn btn-default" Text="15:30" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="E_8"><asp:Button runat="server" ID="bttn1930" class="btn btn-default" Text="19:30" OnClick="bttn_Click" /></asp:TableCell>
        <asp:TableCell ID="N_8"><asp:Button runat="server" ID="bttn2330" class="btn btn-default" Text="23:30" OnClick="bttn_Click" /></asp:TableCell>
    </asp:TableRow>     
</asp:Table>

