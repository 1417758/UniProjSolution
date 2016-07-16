<%@ Page Title="" Language="C#" MasterPageFile="~/UI/EndUser/SiteUser.master" AutoEventWireup="true" CodeFile="WelcomeUser.aspx.cs" Inherits="UI_EndUser_WelcomeUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <div class="jumbotron">
        <h1>Welcome to <asp:Label ID="LabelCompanyName" runat="server" Text=""></asp:Label></h1>
         <h2>Online Booking System</h2>
         <br />
        <p class="lead">Book and Pay online! </p>
        <p><a href="BookAppt.aspx" class="btn btn-primary btn-lg">Book Appointment &raquo;</a></p>
    </div>
</asp:Content>

