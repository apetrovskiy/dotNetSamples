<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Hello World</h2>
    <p>Welcome to Beginning ASP.NET 4.5.1 on <%: DateTime.Now.ToString() %></p>
</asp:Content>