<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="UI_Register" %>

<%@ Register Src="~/UserControls/IndAndNatBusUserControl.ascx" TagName="IndAndNatBusUserControl" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/OpeningHrsWeek.ascx" TagName="OpeningHrsWeek" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/AddStaffUserControl.ascx" TagName="AddStaffUserControl" TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/AddServicesUserControl.ascx" TagName="AddServicesUserControl" TagPrefix="uc4" %>
<%@ Register Src="~/UserControls/PersonalDetailsUserControl.ascx" TagName="PersonalDetailsUserControl" TagPrefix="uc5" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <h2><%: Title %>Register.</h2>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4>Create an account to register.</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>


                    <div class="form-group">
                        <div class="col-md-10">
                            <asp:CreateUserWizard ID="CreateUserWizard1" runat="server"
                                OnContinueButtonClick="CreateUserWizard1_ContinueButtonClick" OnCreatedUser="CreateUserWizard1_CreatedUser"
                                OnActiveStepChanged="CreateUserWizard1_OnActiveStepChanged" OnNextButtonClick="CreateUserWizard1_NextButtonClick"
                                OnFinishButtonClick="CreateUserWizard1_FinishButtonClick"
                                BorderPadding="4" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderStyle="Solid" BorderWidth="1px" Height="298px" Width="682px"
                                Font-Names="Verdana" Font-Size="small" DuplicateUserNameErrorMessage="User name already in use. Please enter a different user name.">
                                <ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
                                <CreateUserButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
                                <TitleTextStyle BackColor="black" Font-Bold="True" ForeColor="LightGray" Font-Size="Medium"  />
                                <HeaderStyle BackColor="black" BorderStyle="Solid" Font-Bold="True" Font-Size="Medium" ForeColor="White" HorizontalAlign="Center"  />
                                <%--<HeaderTemplate> <asp:Label ID="lblStepTitle" runat="server" Text="Step Title"></asp:Label>   </HeaderTemplate>--%>
                                <WizardSteps >
                                    <%--1st step--%>
                                    <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" />

                                    <asp:WizardStep ID="WizardStep1" runat="server" Title="SET YOUR PERSONAL DETAILS">
                                        <header style="background-color: black; border-style: Solid; font-weight: bold; font-size: medium; color: lightgrey; text-align: center;">ENTER YOUR PERSONAL DETAILS</header>
                                        <uc5:PersonalDetailsUserControl ID="PersonalDetailsUserControl1" runat="server" />
                                    </asp:WizardStep>

                                    <%--2nd step--%>
                                    <asp:WizardStep ID="WizardStep2" runat="server" Title="SET YOUR BUSINESS DETAILS" ValidateRequestMode="Enabled" >
                                        <header style="background-color: black; border-style: Solid; font-weight: bold; font-size: medium; color: lightgrey; text-align: center;">SET YOUR BUSINESS DETAILS</header>
                                        <uc1:IndAndNatBusUserControl ID="IndAndNatBusUserControl1" runat="server" />
                                    </asp:WizardStep>

                                    <%--3rd step--%>
                                    <asp:WizardStep ID="WizardStep3" runat="server" Title="SET YOUR BUSINESS HOURS" >
                                        <header style="background-color: black; border-style: Solid; font-weight: bold; font-size: medium; color: lightgrey; text-align: center;">SET YOUR BUSINESS HOURS</header>
                                        <uc2:OpeningHrsWeek ID="OpeningHrsWeek1" runat="server" />
                                    </asp:WizardStep>

                                    <%--4th step--%>
                                    <asp:WizardStep ID="WizardStep4" runat="server" Title="ADD STAFF" >
                                        <header style="background-color: black; border-style: Solid; font-weight: bold; font-size: medium; color: lightgrey; text-align: center;">ADD STAFF</header>
                                        <uc3:AddStaffUserControl ID="AddStaffUserControl1" runat="server" />
                                        <asp:Label ID="lblWarningStaff" runat="server" Text="" ForeColor="Red" Height="20px"></asp:Label>
                                    </asp:WizardStep>

                                    <%--5th step--%>
                                    <asp:WizardStep ID="WizardStep5" runat="server" Title="ADD SERVICE" >
                                        <header style="background-color: black; border-style: Solid; font-weight: bold; font-size: medium; color: lightgrey; text-align: center;">ADD SERVICE</header>
                                        <uc4:AddServicesUserControl ID="AddServicesUserControl1" runat="server" />
                                        <asp:Label ID="lblWarningService" runat="server" Text="" ForeColor="Red" Height="20px"></asp:Label>
                                    </asp:WizardStep>

                                    <%--register confirmation--%>
                                    <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server" />

                                </WizardSteps>
                                <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
                                <SideBarButtonStyle Font-Names="Verdana" ForeColor="White" BorderWidth="0px" />
                                <SideBarStyle BackColor="#5D7B9D" Font-Size="0.9em" VerticalAlign="Top" BorderWidth="0px" />
                                <StepStyle BorderWidth="0px" />
                                <TextBoxStyle Font-Size="Small" Width="100%" />
                                <CreateUserButtonStyle  />
                            </asp:CreateUserWizard>


                        </div>
                    </div>

                </div>
                <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled" NavigateUrl="~/UI/MyLogin.aspx">Log in</asp:HyperLink>
                    &nbsp;if you are already registered.
                </p>
            </section>
        </div>

        <div class="col-md-4">
            <section id="socialLoginForm">
                <%--<uc:openauthproviders runat="server" id="OpenAuthLogin" />--%>
            </section>
        </div>
    </div>





</asp:Content>

