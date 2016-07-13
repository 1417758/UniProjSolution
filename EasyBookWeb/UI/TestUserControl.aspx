<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TestUserControl.aspx.cs" Inherits="UI_TestUserControl" %>

<%@ Register Src="~/UserControls/PersonalDetailsUserControl.ascx" TagPrefix="uc1" TagName="PersonalDetailsUserControl" %>


<%--<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" Runat="Server">
     <script type="text/javascript">
        history.go(+1);
        window.onbeforeunload = function (e) {
            document.getElementById("btnValidate").click();
            document.getElementById("PersButton1").click();
            
        }
        function performCheck() {

            if (Page_ClientValidate()) {
            }

        }
    </script>

</asp:Content>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <uc1:PersonalDetailsUserControl runat="server" ID="PersonalDetailsUserControl" />

</asp:Content>

