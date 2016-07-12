<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="UI_Register" %>
<%@ Register Src="~/UserControls/IndAndNatBusUserControl.ascx" TagName="IndAndNatBusUserControl" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/OpeningHrsWeek.ascx" TagName="OpeningHrsWeek" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/AddStaffUserControl.ascx" TagName="AddStaffUserControl" TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/AddServicesUserControl.ascx" TagName="AddServicesUserControl" TagPrefix="uc4" %>
<%@ Register src="~/UserControls/PersonalDetailsUserControl.ascx" tagname="PersonalDetailsUserControl" tagprefix="uc5" %>

<%@ Reference Control="~/UserControls/AddServicesUserControl.ascx" %> 


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    

    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server"
        OnContinueButtonClick="CreateUserWizard1_ContinueButtonClick" OnCreatedUser="CreateUserWizard1_CreatedUser"
        OnActiveStepChanged="CreateUserWizard1_OnActiveStepChanged" 
        BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderStyle="Solid" BorderWidth="1px"
        Font-Names="Verdana" Font-Size="Medium" DuplicateUserNameErrorMessage="User name already in use. Please enter a different user name.">
        <ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
        <CreateUserButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
        <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" BorderStyle="Solid" Font-Bold="True" Font-Size="0.9em" ForeColor="White" HorizontalAlign="Center" />
        <%--<HeaderTemplate> <asp:Label ID="lblStepTitle" runat="server" Text="Step Title"></asp:Label>   </HeaderTemplate>--%>
        <WizardSteps>
            <%--1st step--%>
            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" />

             <asp:WizardStep ID="WizardStep1" runat="server" Title="SET YOUR PERSONAL DETAILS">
                <header style="background-color: #5D7B9D; border-style: Solid; font-weight: bold; font-size: 0.9em; color: White; text-align: center;">ENTER YOUR PERSONAL DETAILS</header>
                <uc5:PersonalDetailsUserControl ID="PersonalDetailsUserControl1" runat="server" />
            </asp:WizardStep>

            <%--2nd step--%>
            <asp:WizardStep ID="WizardStep2" runat="server" Title="SET YOUR BUSINESS DETAILS">
                <header style="background-color: #5D7B9D; border-style: Solid; font-weight: bold; font-size: 0.9em; color: White; text-align: center;">SET YOUR BUSINESS DETAILS</header>
                <uc1:IndAndNatBusUserControl ID="IndAndNatBusUserControl1" runat="server" />
            </asp:WizardStep>

            <%--3rd step--%>
            <asp:WizardStep ID="WizardStep3" runat="server" Title="SET YOUR BUSINESS HOURS">
                <header style="background-color: #5D7B9D; border-style: Solid; font-weight: bold; font-size: 0.9em; color: White; text-align: center;">SET YOUR BUSINESS HOURS</header>
                <uc2:OpeningHrsWeek ID="OpeningHrsWeek1" runat="server" />
            </asp:WizardStep>

            <%--4th step--%>
            <asp:WizardStep ID="WizardStep4" runat="server" Title="ADD STAFF">
                <header style="background-color: #5D7B9D; border-style: Solid; font-weight: bold; font-size: 0.9em; color: White; text-align: center;">ADD STAFF</header>
                <uc3:AddStaffUserControl ID="AddStaffUserControl1" runat="server" />
            </asp:WizardStep>

            <%--5th step--%>
            <asp:WizardStep ID="WizardStep5" runat="server" Title="ADD SERVICE" >
                <header style="background-color: #5D7B9D; border-style: Solid; font-weight: bold; font-size: 0.9em; color: White; text-align: center;">ADD SERVICE</header>
                <uc4:AddServicesUserControl ID="AddServicesUserControl1" runat="server" />
            </asp:WizardStep>

            <%--register confirmation--%>
            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server" />

        </WizardSteps>
        <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
        <SideBarButtonStyle Font-Names="Verdana" ForeColor="White" BorderWidth="0px" />
        <SideBarStyle BackColor="#5D7B9D" Font-Size="0.9em" VerticalAlign="Top" BorderWidth="0px" />
        <StepStyle BorderWidth="0px" />
    </asp:CreateUserWizard>


    


   <br />

</asp:Content>

