<%@ Page Title="" Language="C#" MasterPageFile="~/UI/ConfigPanel/SiteConfig.master" AutoEventWireup="true" CodeFile="ConfigContact.aspx.cs" Inherits="UI_ConfigPanel_ConfigContact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <h2><%: Title %>Contact.</h2>
    <h3>Easy Booking </h3>
    <address>
        Robert Gordon University<br />
        School of Computing<br />
        <abbr title="Phone">P:</abbr>
        01224.555.0100
    </address>

    <address>
        <strong>Technical Support:</strong>   <a href="mailto:Rachel.Santos@rgu.ac.uk">Rachel.Santos@rgu.ac.uk</a><br />
        <strong>Customer Services:</strong> <a href="mailto:Marketing@example.com">John.Issac@rgu.ac.uk</a>
    </address>
</asp:Content>

