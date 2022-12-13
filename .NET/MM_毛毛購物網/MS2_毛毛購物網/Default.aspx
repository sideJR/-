<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MS2_毛毛購物網._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    寵物用品，應有盡有<br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <br />
    <table style="border:solid;width:100%">
        <tr>
            <td rowspan="2" style="width:25%;background-color:lightskyblue">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="ItemId" HeaderText="編號" />
                        <asp:BoundField DataField="ItemName" HeaderText="品名" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID ="Bx" runat="server" Text="詳細" CommandName="Detail" CommandArgument="<%#((GridViewRow)Container).RowIndex %>"/>
                            </ItemTemplate>
                        </asp:TemplateField>               
                    </Columns>
                </asp:GridView>
            </td>
            <td style="width:35%;background-color:antiquewhite">
                <asp:Label ID="Label3" runat="server" Text="品名"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text="價格"></asp:Label>
                <asp:Label ID="Label5" runat="server" Text="製造地"></asp:Label>
            </td>
            <td style="width:30%;background-color:antiquewhite">
                <asp:Button ID="Button1" runat="server" Text="加入購物車" OnClick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Image ID="Image1" runat="server" Width="300px" Height="300px" AlternateText="產品相片"/>
            </td>
        </tr>
    </table>
</asp:Content>
