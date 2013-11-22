<%@ Page Title="" Language="C#" MasterPageFile="~/MyMasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
    <table style="width: 100%;">
        <tr>
            <td style="width: 145px">
                <b class="myLabel">User Name : </b>
            </td>
            <td>
                <asp:TextBox ID="TxtBx_UserName" runat="server" Width="200px" CssClass="mytext"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 145px">
                <b class="myLabel">Password :</b>
            </td>
            <td>
                <asp:TextBox ID="TxtBx_Password" runat="server" TextMode="Password" Width="200px" CssClass="mytext" />
            </td>
        </tr>
        <tr>
            <td style="width: 145px">
                <asp:Button ID="Btn_Login" runat="server" Text="Login"  CssClass="myButton" 
                    onclick="Btn_Login_Click"/>
            </td>
        </tr>
        <tr>
        <td>
            <p id="p_invalidUser" runat="server" visible="false">*Invalid Credentials</p>
        </td>
        </tr>
    </table>
</asp:Content>

