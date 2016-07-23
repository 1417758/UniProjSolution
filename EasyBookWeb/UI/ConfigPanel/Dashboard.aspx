<%@ Page Title="" Language="C#" MasterPageFile="~/UI/ConfigPanel/SiteConfig.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="UI_ConfigPanel_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="jumbotron" style="background-color:aquamarine;">
        <h2>Give the following link to your clients <br />for Online Bookings!</h2>
       Try yourself:<br />
        <p class="lead"> <a id="clientLink" runat="server">  "~/UI/EndUser/WelcomeUser.aspx?field1=5" </a>
            <br /><br />
            
          <b>  Copy and paste the link below on your website!</b>
            <br />
         <pre> <a  href="<%= Page.ResolveUrl("~")%>UI/EndUser/WelcomeUser.aspx?urlco1=?urlco2=meTestingYouFixed">  http://forums.asp.net/t/1105798.aspx?Response+Redirect+in+C+for+page+to+page+parameter+passing </a> </pre>
        </p>
        
    </div>
</asp:Content>

