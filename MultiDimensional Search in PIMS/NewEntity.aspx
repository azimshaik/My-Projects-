<%@ Page Title="" Language="C#" MasterPageFile="~/MyMasterPage.master" AutoEventWireup="true" CodeFile="NewEntity.aspx.cs" Inherits="NewEntity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="height:500px">
   <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <select id="selectEntity" class="mytext" onchange="ToggleSearchInputs(this)">
        <option value="-1">--Select Entity-</option>
        <option value="Faculty">Faculty</option>
        <option value="Students">Students</option>
        <option value="Staff">Staff</option>
        <option value="Contractors">Contractors</option>
    </select>

    <div id="SearchDiv">
       <table id="Tbl_Faculty" >
                    <tr>
                        <td>First Name : </td>
                        <td><asp:TextBox ID="TxtBx_F_FName" runat="server" Width="350px" CssClass="mytext"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Last Name : </td>
                        <td><asp:TextBox ID="TxtBx_F_LName" runat="server" Width="350px" CssClass="mytext"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Department : </td>
                        <td>
                            <select id="selectFDept" class="mytext" runat="server">
                                <option value="-1">--Select Dept-</option>
                                <option value="1">ECM</option>
                                <option value="2">ECE</option>
                                <option value="3">EIE</option>
                                <option value="4">CSE</option>
                                <option value="5">IT</option>
                                <option value="6">EEE</option>
                                <option value="7">Mech</option>
                                <option value="8">MBA</option>
                                <option value="9">MCA</option>
                            </select>                      
                    </td>
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
                        <td>
                        <select id="selectExpYears" runat="server">
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">3</option>
                            <option value="4">4</option>
                            <option value="5">5</option>
                            <option value="6">6</option>
                            <option value="7">7</option>
                            <option value="8">8</option>
                            <option value="9">9</option>
                            <option value="10">10</option>
                            <option value="15">15+</option>
                            <option value="20">20+</option>
                            <option value="25">25+</option>
                        </select>
                        </td>
                    </tr>
                    <tr>
                        <td>Accomplishments : </td>
                        <td><asp:TextBox ID="TxtBx_F_Acc" runat="server" Width="350px" CssClass="mytext"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                        <asp:Button ID="Btn_Faculty" runat="server" Text="Add" CssClass="myButton ui-button" 
                                OnClientClick="MultiDimSearch(this)" onclick="Btn_Faculty_Click" />
            </ContentTemplate>
            </asp:UpdatePanel>
                                </td>
                    </tr>
                 </table>
       <table id="Tbl_Student" class="myHide">
                    <tr>
                        <td>First Name : </td>
                        <td><asp:TextBox ID="TxtBx_S_FName" runat="server" Width="350px" CssClass="mytext"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Last Name : </td>
                        <td><asp:TextBox ID="TxtBx_S_LName" runat="server" Width="350px" CssClass="mytext"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Department : </td>
                        <td>
                            <select id="slectSDept" class="mytext" runat="server">
                                <option value="-1">--Select Dept-</option>
                                <option value="1">ECM</option>
                                <option value="2">ECE</option>
                                <option value="3">EIE</option>
                                <option value="4">CSE</option>
                                <option value="5">IT</option>
                                <option value="6">EEE</option>
                                <option value="7">Mech</option>
                                <option value="8">MBA</option>
                                <option value="9">MCA</option>
                            </select>                      
                        </td>
                    </tr>
                    <tr>
                        <td>
                       <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="Btn_Students" runat="server" Text="Add" 
                                CssClass="myButton ui-button" OnClick="Btn_Student_Click" />
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
    </div>
    <span id="spanCreated" runat="server"></span>
</asp:Content>

