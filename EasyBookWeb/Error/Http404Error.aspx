<%@ Page Title="" Language="C#" MasterPageFile="~/Error/ErrorMaster.master" AutoEventWireup="true" CodeFile="Http404Error.aspx.cs" Inherits="Error_Http404Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

 <%--   <div class="jumbotron">
        <h1>HTTP 404 Error (Page Not Found)</h1>
        <p class="lead">
            Standard error message suitable for file not found errors. The original exception object is not available, but the original requested URL is in the query string.
        </p>
        <p>
            Return to <a href='TestError.aspx' class="btn btn-primary btn-lg">Test Error Page  &raquo;</a>
        </p>
    </div>--%>

    <div class="jumbotron">
        <h1>The page you are looking for cannot be found</h1>
        <p class="lead">
            This is a standard error message for file/page not found errors. <br /> Sorry for any inconvenient please click on the button below and try again.
        </p>
        <p>
            Return to <a href='Default.aspx' class="btn btn-primary btn-lg">Home  &raquo;</a>
        </p>
    </div>

</asp:Content>

