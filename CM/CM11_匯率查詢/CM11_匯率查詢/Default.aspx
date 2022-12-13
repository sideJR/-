<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CM11_匯率查詢._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="Button1" runat="server" Text="擷取資料" OnClick="Button1_Click" />
    <br />
    <h3>美元對其他貨幣的匯率</h3>
    <table border="1">
        <tr>
            <th>貨幣</th><th>匯率</th>            
        </tr>
        <tr>
            <td>新台幣</td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="無"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>日圓</td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="無"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>英鎊</td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="無"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>韓元</td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="無"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
