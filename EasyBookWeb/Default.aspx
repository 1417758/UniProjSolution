<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Easy Booking</h1>
        <p class="lead">Customer appointments made easy! Virtual Diary 100% reliable which can be taken anywhere!</p>
        <p><a href="UI/Register.aspx" class="btn btn-primary btn-lg">Join Today &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                An easy and familiar interface will take you through five steps to setup an account with Easy Booking. After that you will have access to a configuration panel where your business details, services and members of staff can be easily updated. Also, a web link will be provided where your own clients can book their appointments
            </p>
            <p>
                <a class="btn btn-default">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Advantages</h2>
            <p>
                <span>Manage clients appointments on the go, r</span>each a new geographic area, provide the facility of self-booking to clients, <span>reduce business paperwork, improve the business effectiveness and performance, integrated CRM, business statics and sales reports and also payment at the time of booking</span>.
            </p>
            <p>
                <a class="btn btn-default">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Features</h2>
            <p>
                <span>Mobile App, auto-scheduler, employee availability, Email clients and employees, Cloud based appointment scheduling system, calendar sync, business reports, Help &amp; Support and much more</span>
            </p>
            <p>
                <a class="btn btn-default">Learn more &raquo;  </a>
            </p>
        </div>
    </div>
</asp:Content>
