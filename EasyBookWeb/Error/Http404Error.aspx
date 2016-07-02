<%@ Page Title="" Language="C#" MasterPageFile="~/Error/ErrorMaster.master" AutoEventWireup="true" CodeFile="Http404Error.aspx.cs" Inherits="Error_Http404Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <div class="jumbotron">
        <h1>HTTP 404 Error (Page Not Found)</h1>
        <p class="lead">
            Standard error message suitable for file not found errors. The original exception object is not available, but the original requested URL is in the query string.
        </p>
        <p>
            Return to <a href='TestError.aspx' class="btn btn-primary btn-lg">Test Error Page  &raquo;</a>
        </p>
    </div>

</asp:Content>

