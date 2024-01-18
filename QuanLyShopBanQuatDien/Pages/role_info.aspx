<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/master_page.Master" AutoEventWireup="true"
    CodeBehind="role_info.aspx.cs" Inherits="QuanLyShopBanQuatDien.Pages.role_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    Thêm vai trò
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <style>
        tr, td
        {
            cursor: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <div id="header" class="px-4 py-3">
        <asp:Label ID="pageNameLabel" class="h2" runat="server" Text="Thêm vai trò"></asp:Label>
    </div>
    <div id="body" class="overflow-auto">
        <div class="d-flex justify-content-between ml-4 mt-4">
            <asp:LinkButton ID="LinkButton1" href="role_page.aspx" class="btn shadow btn-secondary"
                runat="server">
                <i class="fa fa-arrow-left mr-2" aria-hidden="true"></i>Vai trò
            </asp:LinkButton>
            <div>
                <asp:LinkButton ID="saveLinkButton" class="shadow btn btn-primary mr-3" runat="server"
                    OnClick="saveLinkButton_Click" >
                    <i class="fa fa-save mr-2" aria-hidden="true"></i> Lưu
                </asp:LinkButton>
                <asp:LinkButton ID="deleteLinkButton" Visible="false" OnClientClick="return confirm('Bạn chắc chắn xóa?');"
                    runat="server" class="shadow btn btn-outline-danger mr-3" OnClick="deleteLinkButton_Click">
                    <i class="fa fa-times mr-2" aria-hidden="true"></i> Xóa
                </asp:LinkButton>
            </div>
        </div>
        <div class="mb-5">
            <div class="form-row">
                <div class="col-12 text-center">
                    <asp:Label ID="messageLabel" class="" runat="server"></asp:Label>
                </div>
            </div>
            <div class="form-row ml-3 mr-2 my-4 ">
                <div class="col-6">
                    <label for="codeTextBox">
                        Mã vai trò</label>
                    <asp:TextBox ID="codeTextBox" class="form-control" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="codeValidator" class="text-danger small" runat="server"
                        OnServerValidate="codeValidator_ServerValidate"></asp:CustomValidator>
                </div>
                <div class="col-6">
                    <label for="nameTextBox">
                        Tên vai trò</label>
                    <asp:TextBox ID="nameTextBox" class="form-control" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="nameValidator" class="text-danger small" runat="server"
                        OnServerValidate="nameValidator_ServerValidate"></asp:CustomValidator>
                </div>
            </div>
            <div class="form-row ml-3 mr-2 mt-4 border-top">
            </div>
            <div class="form-row ml-3 mr-2 mt-3">
                <div class="h5 text-secondary">
                    Quyền hạn</div>
            </div>
            <div class="row ml-1 mr-2">
                <div class="col-12">
                    <asp:GridView ID="GridView1" runat="server" GridLines="None" AutoGenerateColumns="False"
                        ShowHeaderWhenEmpty="true" EmptyDataText="Không có dữ liệu" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <div class="mb-3 text-primary font-weight-bold">
                                        <asp:CheckBox ID="checkAll" class="mr-1" runat="server" />
                                        <asp:Label ID="Label1" AssociatedControlID="checkAll" runat="server" Text='<%# Eval("Key") %>'></asp:Label>
                                    </div>
                                    <div class="row text-secondary ml-1">
                                        <asp:PlaceHolder ID="checkBoxPlaceHolder" runat="server"></asp:PlaceHolder>
                                    </div>
                                    <hr />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script" runat="server">
    <script>
        $(document).ready(function () {
            $('td > div:first-child input').on('click', function () {
                var checkboxes = $(this).closest("td").find('> div:nth-child(2) input');
                checkboxes.prop('checked', $(this).is(":checked"));
            });


            $('td div:nth-child(2) input').on('click', function () {
                var masterCheckBox = $(this).closest("td").find('> div:first-child input');
                var checkboxes = $(this).closest("td").find("> div:nth-child(2) input");

                var allChecked = checkboxes.length === checkboxes.filter(':checked').length;
                masterCheckBox.prop('checked', allChecked);
            });
        });
    </script>
</asp:Content>
