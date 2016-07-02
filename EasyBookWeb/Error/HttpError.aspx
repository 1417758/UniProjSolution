<%@ Page Title="" Language="C#" MasterPageFile="~/Error/ErrorMaster.master" AutoEventWireup="true" CodeFile="HttpError.aspx.cs" Inherits="Error_HttpError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

     <div class="jumbotron">
        <h1>HTTP Error Page</h1>
        <p class="lead">
            bla bla bla
        </p>
        <p>
            Return to <a href='TestError.aspx' class="btn btn-primary btn-lg">Test Error Page  &raquo;</a>
        </p>
    </div>


    <section class="row">
        <div id="div1" class="col-md-6">
            <h2>Inner Error Message</h2>
            <p>
                <asp:Label ID="lblInnerMessage" runat="server" Font-Bold="true"
                    Font-Size="Large" />
            </p>
            <%--  <br />--%>
            <pre>
                <asp:Label ID="lblInnerTrace" runat="server" />
            </pre>

        </div>
        <div id="div2" class="col-md-6">
            <h2>Error Message</h2>
            <p>
                <asp:Label ID="lblExMessage" runat="server" Font-Bold="true"
                    Font-Size="Large" />
            </p>
            <pre>
              <asp:Label ID="lblExTrace" runat="server" Visible="true" />
            </pre>
        </div>

    </section>

</asp:Content>

