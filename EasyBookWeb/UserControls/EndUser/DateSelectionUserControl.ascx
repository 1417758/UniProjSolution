<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DateSelectionUserControl.ascx.cs" Inherits="UserControls_EndUser_DateSelectionUserControl" %>
<%@ Register Src="~/UserControls/hours.ascx" TagPrefix="uc1" TagName="hours" %>


<%@ Register Src="ShowTimeUserControl.ascx" TagName="ShowTimeUserControl" TagPrefix="uc2" %>

<table>
    <tr>
        <td>Select Date:</td>
        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
        <td>Appointments Available: </td>
        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;</td>
        <td>&nbsp;&nbsp;Selected Date &amp; Time:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"
                BackColor="White" BorderColor="White" BorderWidth="1px" ForeColor="Black" NextPrevFormat="FullMonth" Width="250px">
                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="DeepPink" ForeColor="White" />
                <TitleStyle BackColor="White" BorderColor="Black" BorderStyle="Inset" BorderWidth="3px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                <TodayDayStyle BackColor="#CCCCCC" />
            </asp:Calendar>
        </td>
        <td>&nbsp;</td>


        <td>
            <uc2:ShowTimeUserControl ID="ShowTimeUserControl1" runat="server" />
        </td>
        <td>&nbsp;</td>


        <td>Date:
           <h4 style="padding-left:20%;"> <asp:Label ID="LabelDate" runat="server" Height="40px"></asp:Label></h4>
            <br />
            Time:
           <h4 style="padding-left:20%;"> <asp:Label ID="LabelTime" runat="server" Height="40px"></asp:Label></h4>

            
        </td>


    </tr>
    <tr>
        <td colspan="4" style="padding-left:10px;">Tip: Cant find your ideal time?
            <br />
            try changing the service   
            provider to &quot;No Preference&quot; </td>
        <td>&nbsp;</td>

    </tr>

</table>




