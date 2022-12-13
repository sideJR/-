<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="MS2_毛毛購物網.Checkout" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br />
    購物車內容如下，結帳處理中...<br />

    <hr /> <!--水平線-->
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="OrderId" HeaderText="訂單編號 | " />
            <asp:BoundField DataField="ItemId" HeaderText="品名編號 | " />
            <asp:BoundField DataField="ItemName" HeaderText="品名 | " />
            <asp:BoundField DataField="ItemPrice" HeaderText="價格" />
        </Columns>
    </asp:GridView>

    <hr style=" width:20%;margin-left:0" />

    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label><br />
    <asp:Button ID="btnCheckout" runat="server" Text="確定結帳" OnClick="btnCheckout_Click" />

</asp:Content>
