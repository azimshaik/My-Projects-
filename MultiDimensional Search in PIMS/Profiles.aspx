<%@ Page Title="" Language="C#" MasterPageFile="~/MyMasterPage.master" AutoEventWireup="true" CodeFile="Profiles.aspx.cs" Inherits="Profiles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;">
        <tr>
            <td style="width:300px;">
                <asp:Image ID="Img_profilePhoto" runat="server" Height="320px" ImageUrl="images/coming-soon.jpg" />
            </td>
            <td>
                <table style="margin-top: -70px">
                     <tr>
                        <td>
                             <b>Name : </b>
                        </td>
                        <td>
                            <asp:Label ID="Lbl_Name" runat="server"></asp:Label>
                        </td>
                     </tr>
                    <tr>
                        <td>
                            <b>Department : </b>
                        </td>
                        <td>
                            <asp:Label ID="Lbl_Dept" runat="server" Text="N/A"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Entity Type : </b> 
                        </td>
                        <td>
                            <asp:Label ID="Lbl_EntityType" runat="server" Text="N/A"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Score : </b>
                        </td>
                        <td>
                            <asp:Label ID="Lbl_Score" runat="server" Text="N/A"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Qualification :</b> 
                        </td>
                        <td>
                            <asp:Label ID="Lbl_Qualification" runat="server" Text="N/A"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Position : </b>
                        </td>
                        <td>
                            <asp:Label ID="Lbl_Position" runat="server" Text="N/A"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Experience : </b>
                        </td>
                        <td>
                            <asp:Label ID="Lbl_Exp" runat="server" Text="N/A"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Accomplisments : </b>
                        </td>
                        <td>
                            <asp:Label ID="Lbl_Accomplishments" runat="server" Text="N/A"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:FileUpload ID="FileUploadImage" runat="server" Width="300px" />
    <asp:Button ID="Btn_ImageUpload"
        runat="server" Text="Upload Image" onclick="Btn_ImageUpload_Click" />
    <asp:Label Id = "Lbl_info" runat="server"></asp:Label>
</asp:Content>

