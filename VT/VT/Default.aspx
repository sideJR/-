<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VT._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--TestPanel是測試區,上線前註解以失效
        測試區有標onnctLe,
        前者呈現網路連線狀態,後者自由運用--%>
    <asp:Panel ID="TestPanel" BackColor="LightGray" runat="server">
        <asp:Label ID="ConnectLabel" runat="server" Text="連線狀態"></asp:Label>
        <asp:Label ID="TestLabel" runat="server" Text="!"></asp:Label>
        <div style="height: 0px"></div>
    </asp:Panel>

    <%--TitlePanel是網頁上方的標題版面--%>
    <asp:Panel ID="TitlePanel" runat="server">
        <h2>社區投票網</h2>
    </asp:Panel>

    <%--LoginPanel是用戶登入版面
        登入成功,才能顯示UserPanel與內部的用户資訊
        以及VotePanel的投票選項--%>
    <asp:Panel ID="LoginPanel" runat="server">        
        <asp:Label ID="AccountLabel" runat="server" Text="帳號"></asp:Label>
        <asp:TextBox ID="AccountTextBox" runat="server"></asp:TextBox>
        <div style="height: 0px"></div>

        <asp:Label ID="PasswordLabel" runat="server" Text="密碼"></asp:Label>
        <asp:TextBox ID="PasswordTextBox" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
        <asp:Button ID="LoginButton" runat="server" Text="登入" OnClick="LoginButton_Click" />
    </asp:Panel>

    <%--UserPanel呈現住戶ID與權重資訊--%>
    <asp:Panel ID="UserPanel" runat="server" Visible="false">
        <div style="height: 30px"></div>
        <asp:Label ID="UserIdLabel" runat="server"></asp:Label>
        <asp:Label ID="UserWeightLabel" runat="server"></asp:Label>
    </asp:Panel>
    
    <%--MessagePanel發佈訊息--%>
    <asp:Panel ID="MessagePanel" runat="server">
        <div style="height: 30px"></div>
        <asp:Label ID="MessageLabel" runat="server" Text="歡迎光臨，麻煩您先登入" Font-Size="Large" ForeColor="White" BackColor="Red"></asp:Label>
    </asp:Panel>

    <%--VotePanel是住戶投票的版面
        由VoteControlButton與VoteControlPanel組成
        並由前者控制後者的出現與消失--%>
    <asp:Panel ID="VotePanel" runat="server">
        <div style="height: 30px"></div>
        <asp:Button ID="VoteControlButton" runat="server" Text="我要投票" BackColor="Yellow" OnClick="VoteControlButton_Click" />

        <asp:Panel ID="VoteControlPanel" runat="server" BackColor="Yellow" Visible="false">
            <asp:Label ID="VoteControlLabel" runat="server" Text="投票區"></asp:Label>
            <div style="height: 30px"></div>

            <asp:Button ID="YesButton" runat="server" Text="同意" OnClick="YesButton_Click" />
            <asp:Button ID="NoButton" runat="server" Text="反對" OnClick="NoButton_Click" />
            <asp:Button ID="DropButton" runat="server" Text="棄權" OnClick="DropButton_Click" />
        </asp:Panel>

    </asp:Panel>

</asp:Content>
