<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyClient._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <br />

    <asp:TextBox ID="TextBox1" Width="40px" runat="server"></asp:TextBox>
    <asp:TextBox ID="TextBox2" Text="+" Width="20px" runat="server"></asp:TextBox>
    <asp:TextBox ID="TextBox3" Width="40px" runat="server"></asp:TextBox>

    <asp:Button ID="Button1" runat="server" Text="計算" OnClick="Button1_Click" />
    <asp:Label ID="Label1" runat="server" Text="答案"></asp:Label>
    
</asp:Content>
