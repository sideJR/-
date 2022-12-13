<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MM1_毛毛購物網._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel2" runat="server" BackColor="Yellow" Visible="false">
        寵物用品，應有盡有<br/>
        <asp:Button ID="btnBuy" runat="server" Text="選購" OnClick="btnBuy_Click" />
    </asp:Panel>
</asp:Content>
