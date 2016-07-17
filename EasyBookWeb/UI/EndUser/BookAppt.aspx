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
            <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server" Visible="true">
                <Header>1. Select Service</Header>
                <Content>
                    All Services Currently Available: 
                    <uc1:ServiceSelectionUserControl runat="server" ID="ServiceSelectionUserControl" />
                </Content>
            </ajaxToolkit:AccordionPane>

            <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
                <Header>2. Service Provider</Header>
                <Content>
                    Select a Member of our team 
                    <uc1:StaffSelectionUserControl runat="server" ID="StaffSelectionUserControl" />

                </Content>
            </ajaxToolkit:AccordionPane>

            <ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server">
                <Header>3. Select Date & Time</Header>
                <Content>

                    <uc1:DateSelectionUserControl runat="server" ID="DateSelectionUserControl" />

                </Content>
            </ajaxToolkit:AccordionPane>

            <ajaxToolkit:AccordionPane ID="AccordionPane4" runat="server">
                <Header>4. Your Info</Header>
                <Content>Enter your personal information

                    <uc1:UserInfoUserControl runat="server" ID="UserInfoUserControl" />

                </Content>
            </ajaxToolkit:AccordionPane>

            <ajaxToolkit:AccordionPane ID="AccordionPane5" runat="server">
                <Header>5. Payment Details</Header>
                <Content>content is located here </Content>
            </ajaxToolkit:AccordionPane>

            <ajaxToolkit:AccordionPane ID="AccordionPane6" runat="server">
                <Header>6. Appointment Confirmation</Header>
                <Content>content is located here </Content>
            </ajaxToolkit:AccordionPane>
        </Panes>
    </ajaxToolkit:Accordion>




</asp:Content>

