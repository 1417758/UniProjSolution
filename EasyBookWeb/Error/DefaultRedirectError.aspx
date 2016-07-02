<%@ Page Title="" Language="C#" MasterPageFile="~/Error/ErrorMaster.master" AutoEventWireup="true" CodeFile="DefaultRedirectError.aspx.cs" Inherits="Error_DefaultRedirectError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <div class="jumbotron">
        <h1>Default Redirect Error Page</h1>
        <p class="lead">
            Standard error message suitable for all unhandled errors errors. The original exception object is not available.
        </p>
        <p>
            Return to <a href='TestError.aspx' class="btn btn-primary btn-lg">Test Error Page  &raquo;</a>
        </p>
    </div>
</asp:Content>

