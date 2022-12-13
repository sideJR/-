<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MM1_毛毛購物網.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <hr/>
    <asp:TextBox ID="txtAccount2" runat="server" Text="請填帳號" 
        OnFocus="javascript:if(this.value=='請填帳號') {this.value=''}" 
        OnBlur="javascript:if(this.value==''){this.value='請填帳號'}"></asp:TextBox><br/>
    <asp:TextBox ID="txtPassword2" runat="server" Text="請填密碼" 
        OnFocus="javascript:if(this.value=='請填密碼') {this.value=''}" 
        OnBlur="javascript:if(this.value==''){this.value='請填密碼'}"></asp:TextBox><br/>

    <div>
        <input type="checkbox" onclick="ShowButton()"/>我已閱讀會員條款
    </div>
    
    <div id="Z" style="visibility:hidden">
        <asp:Button ID="btnApply" runat="server" Text="申請" OnClick="btnApply_Click" onclientclick="ShowThanks()"/>
    </div>
</asp:Content>
