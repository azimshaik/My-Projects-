<%@ Page Title="" Language="C#" MasterPageFile="~/MyMasterPage.master" AutoEventWireup="true" CodeFile="SimpleSearch.aspx.cs" Inherits="SimpleSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:TextBox ID="TxtBx_Search" runat="server" Width="350px" CssClass="mytext">NEC ECM</asp:TextBox> <br />
    <asp:Button ID="Btn_Search" runat="server" Text="Search" CssClass="myButton" OnClick="Btn_Search_Click"/> 
     <div id="divResults" style="height:auto">
     <table id="Tbl_Search" runat="server" style="height:100%">
        <tr>
            <td></td>
            <td></td>
        </tr>
     </table>
     </div>
</asp:Content>

