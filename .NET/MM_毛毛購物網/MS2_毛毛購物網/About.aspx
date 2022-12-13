<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="MS2_毛毛購物網.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand">
        <Columns>

            <asp:BoundField DataField="ItemId" HeaderText="編號" />
            <asp:BoundField DataField="ItemName" HeaderText="品名" />
            <asp:BoundField DataField="ItemPrice" HeaderText="價格" />
            <asp:BoundField DataField="ItemPlace" HeaderText="製造地" />
            <asp:BoundField DataField="ItemPic" HeaderText="圖名" />
            
            <asp:TemplateField HeaderText="圖片">
                <ItemTemplate>
                    <asp:Image ID="px" runat="server" Width="100px" Height="100px" BorderWidth="2px" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="編輯">
                <ItemTemplate>
                    <asp:Button ID="Bx" runat="server" CommandName="Del" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" Text="刪除" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
   
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <br/>
        <asp:TextBox ID="txtId" runat="server" Width="100px" Text="編號"
            OnFocus="javascript:if(this.value=='編號') {this.value=''}" 
            OnBlur="javascript:if(this.value==''){this.value='編號'}"></asp:TextBox>
        <asp:TextBox ID="txtName" runat="server" Width="100px" Text="品名"
            OnFocus="javascript:if(this.value=='品名') {this.value=''}" 
            OnBlur="javascript:if(this.value==''){this.value='品名'}"></asp:TextBox>
        <asp:TextBox ID="txtPrice" runat="server" Width="100px" Text="價格"
            OnFocus="javascript:if(this.value=='價格') {this.value=''}" 
            OnBlur="javascript:if(this.value==''){this.value='價格'}"></asp:TextBox>
        <asp:TextBox ID="txtPlace" runat="server" Width="100px" Text="製造地"
            OnFocus="javascript:if(this.value=='製造地') {this.value=''}" 
            OnBlur="javascript:if(this.value==''){this.value='製造地'}"></asp:TextBox>
        <asp:TextBox ID="txtImg" runat="server" Width="100px" Text="圖片檔"
            OnFocus="javascript:if(this.value=='圖片檔') {this.value=''}" 
            OnBlur="javascript:if(this.value==''){this.value='圖片檔'}"></asp:TextBox>
        <asp:Button ID="btnCreate" runat="server" Text="新增商品" OnClick="btnCreate_Click" />
    <br/>
    <asp:FileUpload ID="FileUpload1" runat="server" Width="200px"/>
    <asp:Button ID="btnUploadImg" runat="server" Text="上傳圖片" OnClick="btnUploadImg_Click" />
</asp:Content>
