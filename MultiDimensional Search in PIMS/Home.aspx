<%@ Page Language="C#" MasterPageFile="~/MyMasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" Title="NEC Management System" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div style="height:500px">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        
        <div id="tabs-2">
            <select id="selectEntity" class="mytext" onchange="ToggleSearchInputs(this)">
                <option value="-1">--Select Entity-</option>
                <option value="Faculty">Faculty</option>
                <option value="Students">Students</option>
                <option value="Staff">Staff</option>
                <option value="Contractors">Contractors</option>
            </select><br /><br />

            <div id="SearchDiv">
               <table id="Tbl_Faculty" >
                <tr>
                    <td>Name : </td>
                    <td><asp:TextBox ID="TxtBx_F_Name" runat="server" Width="350px" CssClass="mytext"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Department : </td>
                    <td><asp:TextBox ID="TxtBx_F_Dept" runat="server" Width="350px" CssClass="mytext"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Qualification : </td>
                    <td><asp:TextBox ID="TxtBx_F_Q" runat="server" Width="350px" CssClass="mytext"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Position : </td>
                    <td><asp:TextBox ID="TxtBx_F_P" runat="server" Width="350px" CssClass="mytext"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Exp Years : </td>
                    <td><asp:TextBox ID="TxtBx_F_Exp" runat="server" Width="350px" CssClass="mytext"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                    <asp:Button ID="Btn_Faculty" runat="server" Text="Search" CssClass="myButton ui-button mysrchButton"  
                            OnClientClick="MultiDimSearch(this)" onclick="Btn_Faculty_Click" />
        </ContentTemplate>
        </asp:UpdatePanel>
                            </td>
                </tr>
             </table>
               <table id="Tbl_Student" class="myHide">
                <tr>
                    <td>Name : </td>
                    <td><asp:TextBox ID="TxtBx_S_N" runat="server" Width="350px" CssClass="mytext"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Department : </td>
                    <td><asp:TextBox ID="TxtBx_S_D" runat="server" Width="350px" CssClass="mytext"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                   <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="Btn_Students" runat="server" Text="Search" 
                            CssClass="myButton ui-button" OnClick="Btn_StudentSearch_Click" />
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    </td>
                </tr>
               </table> 
               <table id="Table_Staff" class="myHide">
                <tr>
                    <td>Name : </td>
                    <td><asp:TextBox ID="TxtBx_st_N" runat="server" Width="350px" CssClass="mytext"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Type : </td>
                    <td>
                        <select id="selectStaffType" class="mytext" runat="server">
                            <option value="-1">--Select One--</option>
                            <option value="Acadamic">Acadamic</option>
                            <option value="Accounts">Accounts</option>
                            <option value="Misc">Misc</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>   
                   <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="Btn_Staff" runat="server" Text="Search" 
                            CssClass="myButton ui-button" OnClientClick="MultiDimSearch(this)" 
                            onclick="Btn_Staff_Click" />
                    </ContentTemplate>
                    </asp:UpdatePanel>    
                        </td>
                
                </tr>
               </table> 
               <table id="Table_Contractors" class="myHide">
                <tr>
                    <td>Name : </td>
                    <td><asp:TextBox ID="TxtBx_C_N" runat="server" Width="350px" CssClass="mytext"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Contractor Type : </td>
                    <td>
                        <select id="selectContractorType" class="mytext" runat="server">
                            <option value="-1">--Select One--</option>
                            <option value="Long Term">Long Term</option>
                            <option value="Short Term">Short Term</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="Btn_Contractors" runat="server" Text="Search" 
                            CssClass="myButton ui-button" OnClientClick="MultiDimSearch(this)" 
                            onclick="Btn_Contractors_Click" />
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    </td>
                </tr>
               </table> 
            </div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div id="divResults">
                   <table id="Tbl_Search" runat="server">
                       <tr>
                       <td></td>
                       <td></td>
                       </tr>
                    </table>
                </div>
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        

    </div> 
    
   
    

</asp:Content>

