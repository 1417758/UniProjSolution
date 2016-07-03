<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MyLogin.aspx.cs" Inherits="UI_MyLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <h2><%: Title %>Log in.</h2>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4>Use a local account to log in.</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>


                    <div class="form-group">
                        <div class="col-md-10">
                            <asp:Login ID="Login1" runat="server" onloggedin="Login1_LoggedIn" OnAuthenticate="Login1_Authenticate1" OnLoginError="Login1_LoginError"
                                BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="Small" ForeColor="black" Height="198px" Width="482px" >
                                <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                                <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="Small" ForeColor="#284775" />
                                <TextBoxStyle Font-Size="Small" Width="100%" />
                                <TitleTextStyle BackColor="black" Font-Bold="True" Font-Size="Small" ForeColor="LightGray" />
                                <LabelStyle Width="20%" HorizontalAlign="Left" />
                                <ValidatorTextStyle ForeColor="Red" />
                            </asp:Login>
                            <asp:Label runat="server" ID="lblRTAPWarning" Font-Bold="False" ForeColor="Red"
                                Font-Size="Small"></asp:Label>                           
                        </div>
                    </div>

                </div>
                <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register</asp:HyperLink>
                    if you don't have a local account.
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

