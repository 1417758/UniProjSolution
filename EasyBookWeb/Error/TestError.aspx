<%@ Page Title="" Language="C#" MasterPageFile="~/Error/ErrorMaster.master" AutoEventWireup="true" CodeFile="TestError.aspx.cs" Inherits="Error_TestError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">


    <div class="jumbotron">
        <h1>Exception Handler Page</h1>

    </div>



    <section class="row">
        <div id="sec1" class="col-md-4">
            <h2>Invalid Operation Exception</h2>
            <p>
                Click this button to create an InvalidOperationException.<br />
                Page_Error will catch this and redirect to GenericErrorPage.aspx.
            </p>
            <p>
                <asp:Button ID="Submit1" runat="server" class="btn btn-primary btn-lg"
                    CommandArgument="1" OnClick="Submit_Click"
                    Text="Button 1" />
            </p>
        </div>
        <div id="sec2" class="col-md-4">
            <h2>Argument Out Of Range Exception</h2>
            <p>
                Click this button to create an ArgumentOutOfRangeException.
                 Page_Error will catch this and handle the error.
            </p>
            <p>
                <asp:Button ID="Submit2" runat="server" class="btn btn-primary btn-lg"
                    CommandArgument="2" OnClick="Submit_Click" Text="Button 2" />
            </p>
        </div>
        <div id="sec3" class="col-md-4">
            <h2>Generic Exception</h2>
            <p>
                Click this button to create a generic Exception.  Application_Error will catch this and handle the error.
            </p>
            <p>
                <asp:Button ID="Submit3" runat="server" class="btn btn-primary btn-lg"
                    CommandArgument="3" OnClick="Submit_Click" Text="Button 3" />
            </p>
        </div>
    </section>
    <br />
    <section class="row">
        <div id="sec4" class="col-md-4">
            <h2>Page Not Found</h2>
            <p>
                Click this button to create an HTTP 404 (not found) error. Application_Error will catch this 
                 and redirect to HttpErrorPage.aspx.
            </p>
            <p>
                <asp:Button ID="Submit4" runat="server" class="btn btn-primary btn-lg"
                    CommandArgument="4" OnClick="Submit_Click" Text="Button 4" />
            </p>
        </div>

        <div id="sec5" class="col-md-4">
            <h2>Page Not Found with Redirect</h2>
            <p>
                Click this button to create an HTTP 404 (not found) error. Application_Error will catch this 
                  but will not take any action on it, and ASP.NET will redirect to Http404ErrorPage.aspx. 
                  The original exception object will not be available.
            </p>
            <p>
                <asp:Button ID="Submit5" runat="server" class="btn btn-primary btn-lg"
                    CommandArgument="5" OnClick="Submit_Click" Text="Button 5" />
            </p>
        </div>
        <div id="sec6" class="col-md-4">
            <h2>Invalid URL Error</h2>
            <p>
                Click this button to create an HTTP 400 (invalid url) error.      Application_Error will catch this 
      but will not take any action on it, and ASP.NET      will redirect to DefaultRedirectErrorPage.aspx. 
      The original exception object will not      be available.
            </p>
            <p>
                <asp:Button ID="Button1" runat="server" class="btn btn-primary btn-lg"
                    CommandArgument="6" OnClick="Submit_Click" Text="Button 6" />
            </p>
        </div>

    </section>





</asp:Content>

