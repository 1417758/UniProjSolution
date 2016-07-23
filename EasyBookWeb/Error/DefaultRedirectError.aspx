<%@ Page Title="" Language="C#" MasterPageFile="~/Error/ErrorMaster.master" AutoEventWireup="true" CodeFile="DefaultRedirectError.aspx.cs" Inherits="Error_DefaultRedirectError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <div class="jumbotron">
        <%--<h1>Default Redirect Error Page</h1>--%>
        <h1>Error Page</h1>
        <h4 class="lead">
            <%--Standard error message suitable for all unhandled errors errors. The original exception object is not available.--%>
            Sorry an error has happened. we are working to sort this as soon as possible.
            <br />
            Meanwhile please try running the website again on a new browser.
        </h4>
        <p>
            Return to <a href='TestError.aspx' class="btn btn-primary btn-lg">Test Error Page  &raquo;</a>
        </p>
    </div>
</asp:Content>

