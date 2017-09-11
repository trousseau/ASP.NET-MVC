<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="My404.aspx.cs" Inherits="WebForm.My404" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>The page <%=Request["aspxerrorpath"] %> does not exist</h3>
</asp:Content>
