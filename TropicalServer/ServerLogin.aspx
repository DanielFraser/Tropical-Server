<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/TropicalServer.Master" AutoEventWireup="true" CodeBehind="ServerLogin.aspx.cs" Inherits="TropicalServer.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="customlogin.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="container">
        <div id="BodyDetail">
            <label id="legendlbl">Mobile Customer Ordering Tracking</label>
            <div id="loginBox">
                <div id="credentials">
                    <asp:Label CssClass="credentiallbl" runat="server">Login ID:</asp:Label>
                    <asp:TextBox ID="user" CssClass="logintextbox" runat="server"></asp:TextBox>
                    <asp:Label CssClass="credentiallbl" runat="server">Password:</asp:Label>
                    <asp:TextBox CssClass="logintextbox" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <br />
                <br />
                <div id="other">
                    <asp:Label CssClass="rememberid" runat="server">Remember my ID</asp:Label>
                    <asp:CheckBox runat="server" />
                    <asp:Button CssClass="loginbtn" runat="server" Text="Log-in" PostBackUrl="~/Products.aspx"/>
                </div>
            </div>

            <div id="forgot">
                <a id="forgotUsername">Forgot Username</a>
                <a id="forgotPassword">Forgot Password</a>
            </div>
        </div>
    </div>
</asp:Content>
