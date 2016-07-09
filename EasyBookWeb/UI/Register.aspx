<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="UI_Register" %>

<%@ Register src="../UserControls/IndAndNatBusUserControl.ascx" tagname="IndAndNatBusUserControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" 
        OnContinueButtonClick="CreateUserWizard1_ContinueButtonClick" OnCreatedUser="CreateUserWizard1_CreatedUser" 
        
        BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderStyle="Solid" BorderWidth="1px" 
        Font-Names="Verdana" Font-Size="Medium">
        <ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
        <CreateUserButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
        <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <WizardSteps>
            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
            </asp:CreateUserWizardStep>
          <%--  <asp:TemplatedWizardStep ID="TemplatedWizardStep1" runat="server">
            </asp:TemplatedWizardStep>--%>
            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
            </asp:CompleteWizardStep>
        </WizardSteps>
        <HeaderStyle BackColor="#5D7B9D" BorderStyle="Solid" Font-Bold="True" Font-Size="0.9em" ForeColor="White" HorizontalAlign="Center" />
        <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
        <SideBarButtonStyle Font-Names="Verdana" ForeColor="White" BorderWidth="0px" />
        <SideBarStyle BackColor="#5D7B9D" Font-Size="0.9em" VerticalAlign="Top" BorderWidth="0px" />
        <StepStyle BorderWidth="0px" />
    </asp:CreateUserWizard>

    <br />
    <br />
    <asp:CreateUserWizard ID="CreateUserWizard2" runat="server">
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" />
            <asp:WizardStep runat="server" Title="Wizard Step">
                test
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <br />
                test 2
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </asp:WizardStep>
            <asp:TemplatedWizardStep runat="server" Title="Template Step">
                <ContentTemplate>
                 <%--   <uc1:IndAndNatBusUserControl ID="IndAndNatBusUserControl1" runat="server" />
                 --%>   <br />
                </ContentTemplate>
            </asp:TemplatedWizardStep>
            <asp:CompleteWizardStep runat="server" />
        </WizardSteps>
    </asp:CreateUserWizard>
    
    <br />
    <br />
        <uc1:IndAndNatBusUserControl ID="IndAndNatBusUserControl1" runat="server" />
     <br />
    <br />
</asp:Content>

