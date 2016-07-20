<%@ Page Title="" Language="C#" MasterPageFile="~/UI/EndUser/SiteUser.master" AutoEventWireup="true" CodeFile="BookAppt.aspx.cs" Inherits="UI_EndUser_BookAppt" %>

<%@ Register Src="~/UserControls/EndUser/ServiceSelectionUserControl.ascx" TagPrefix="uc1" TagName="ServiceSelectionUserControl" %>
<%@ Register Src="~/UserControls/EndUser/StaffSelectionUserControl.ascx" TagPrefix="uc1" TagName="StaffSelectionUserControl" %>
<%@ Register Src="~/UserControls/EndUser/DateSelectionUserControl.ascx" TagPrefix="uc1" TagName="DateSelectionUserControl" %>
<%@ Register Src="~/UserControls/EndUser/UserInfoUserControl.ascx" TagPrefix="uc1" TagName="UserInfoUserControl" %>





<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="Server">
    <link href="../../Content/AccordionPane.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h2><%: Title %>Book Appointment</h2>
    <div class="form-horizontal">
        <h4>Simply follow the five steps below</h4>
        <hr />
    </div>
    <ajaxToolkit:Accordion ID="Accordion1" runat="server"
        SelectedIndex="0"
        HeaderCssClass="accordionHeader"
        HeaderSelectedCssClass="accordionHeaderSelected"
        ContentCssClass="accordionContent"
        AutoSize="None"
        FadeTransitions="true"
        TransitionDuration="250"
        FramesPerSecond="40"
        RequireOpenedPane="false"
        SuppressHeaderPostbacks="true">
        <HeaderTemplate>...</HeaderTemplate>
        <ContentTemplate>...</ContentTemplate>

        <Panes>
            <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server">
                <Header>1. Select Service</Header>
                <Content>
                    All Services Currently Available: 
                    <uc1:ServiceSelectionUserControl runat="server" ID="ServiceSelectionUserControl" />

                    <asp:Button ID="button1" runat="server" Text="Next &raquo;" OnClick="Button_Click" class="btn btn-default" />
                </Content>
            </ajaxToolkit:AccordionPane>

            <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
                <Header>2. Service Provider</Header>
                <Content>
                  Select a Member of our team: 
                    <uc1:StaffSelectionUserControl runat="server" ID="StaffSelectionUserControl" />
                    <asp:Button ID="button2" runat="server" Text="Next &raquo;" OnClick="Button_Click" class="btn btn-default" />
                </Content>
            </ajaxToolkit:AccordionPane>

            <ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server" OnClick="Button_Click">
                <Header>3. Select Date & Time</Header>
                <Content>
                 <p> <b>Current Selected Service Provider:  <asp:Label ID="LabelServProvider" runat="server" Text="Label"></asp:Label></b></p> 
                    <uc1:DateSelectionUserControl runat="server" ID="DateSelectionUserControl" />
                    <asp:Button ID="button3" runat="server" Text="Next &raquo;" OnClick="Button_Click" class="btn btn-default" />
                </Content>
            </ajaxToolkit:AccordionPane>

            <ajaxToolkit:AccordionPane ID="AccordionPane4" runat="server">
                <Header>4. Your Info</Header>
                <Content>
                    Enter your personal information

                    <uc1:UserInfoUserControl runat="server" ID="UserInfoUserControl" />
                    <asp:Button ID="button4" runat="server" Text="Next &raquo;" OnClick="Button_Click" class="btn btn-default" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:CheckBox ID="CheckBoxSaveUserDet" runat="server" Text="Save my details for next visit" Checked="true" />
                </Content>
            </ajaxToolkit:AccordionPane>

            <ajaxToolkit:AccordionPane ID="AccordionPane5" runat="server">
                <Header>5. Payment Details</Header>
                <Content>
                    content is located here 
                <asp:Button ID="button5" runat="server" Text="Next &raquo;" OnClick="Button_Click" class="btn btn-default" />
                </Content>
            </ajaxToolkit:AccordionPane>

            <ajaxToolkit:AccordionPane ID="AccordionPane6" runat="server">
                <Header>6. Appointment Confirmation</Header>
                <Content>
                    content is located here 
                    <asp:Button ID="button6" runat="server" Text="Finish &raquo;" OnClick="Button_Click" class="btn btn-default" />
                </Content>
            </ajaxToolkit:AccordionPane>
        </Panes>
    </ajaxToolkit:Accordion>




</asp:Content>

