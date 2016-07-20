<%@ Page Title="" Language="C#" MasterPageFile="~/UI/ConfigPanel/SiteConfig.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="UI_ConfigPanel_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="jumbotron" style="background-color:aquamarine;">
        <h2>Give the following link to your clients <br />for Online Bookings!</h2>
        <p class="lead"> "~/UI/EndUser/WelcomeUser.aspx?field1=5" 
            <br /><br /><br />
            NOTES:<br />
            <B>field1=5</B> is key-value pairs at the end of the URL
            <br /><br />
          <b>  NB:---value 5 --will vary according to companyID</b>
            <br />
         <pre>   http://forums.asp.net/t/1105798.aspx?Response+Redirect+in+C+for+page+to+page+parameter+passing</pre>
        </p>
        
    </div>
</asp:Content>

