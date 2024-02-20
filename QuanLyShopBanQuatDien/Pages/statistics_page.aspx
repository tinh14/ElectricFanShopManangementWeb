<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/master_page.Master" AutoEventWireup="true"
    CodeBehind="statistics_page.aspx.cs" Inherits="QuanLyShopBanQuatDien.Pages.statistics_page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titleContentPlaceHolder" runat="server">
    Thống kê
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link rel="stylesheet" href="../Resources/Libs/jquery-ui/jquery-ui.css">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <div id="header" class="bg-white px-4 py-3">
        <div class="d-flex justify-content-between">
            <div class="h4">
                Thống kê</div>
            <asp:LinkButton ID="exportButton" class="btn btn-primary" runat="server" 
                onclick="exportButton_Click">
                        <i class="fa fa-file-excel-o mr-2"></i><span>Xuất file</span>
            </asp:LinkButton>
        </div>
    </div>
    <div id="body" class="bg-white">
        <div class="px-4 py-3">
            <div class="row">
                <div class="col-6">
                    <div class="input-group">
                        <span class="input-group-text" style="font-size: 14px"><i class="fa fa-bar-chart-o mr-2">
                        </i>Loại </span>
                        <asp:DropDownList ID="dropdownList" class="form-control" runat="server">
                            <asp:ListItem Text="Doanh thu theo sản phẩm" Value="product" />
                            <asp:ListItem Text="Doanh thu theo khách hàng " Value="customer" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-2">
                    <asp:TextBox ID="startDateTextBox" ClientIDMode="Static" class="form-control" placeholder="Từ ngày..."
                        runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="startDateValidator" class="text-danger small" runat="server"
                        OnServerValidate="startDateValidator_ServerValidate"></asp:CustomValidator>
                </div>
                <div class="col-2">
                    <asp:TextBox ID="endDateTextBox" ClientIDMode="Static" class="form-control" placeholder="Đến ngày..."
                        runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="endDateValidator" class="text-danger small" runat="server"
                        OnServerValidate="endDateValidator_ServerValidate"></asp:CustomValidator>
                </div>
                <div class="col-2 d-flex justify-content-end">
                    <asp:LinkButton ID="findButton" class="btn btn-primary" runat="server" OnClick="findButton_Click">
                        <i class="fa fa-search mr-1"></i><span>Tìm</span>
                    </asp:LinkButton>
                </div>
            </div>
        </div>
        <div class="px-4">
            <asp:Label ID="messageLabel" runat="server"></asp:Label>
        </div>
        <div class="px-4">
            <div class="table-responsive">
                <asp:GridView ID="productGridView" Visible="false" class="bg-white rounded shadow table table-hover table-bordered text-center"
                    runat="server" AutoGenerateEditButton="False" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true"
                    EmptyDataText="Không có dữ liệu" EmptyDataRowStyle-CssClass="font-italic text-secondary h6"
                    OnRowDataBound="gridView_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="code" HeaderText="Mã sản phẩm" />
                        <asp:BoundField DataField="name" HeaderText="Tên sản phẩm" />
                        <asp:BoundField DataField="quantity" HeaderText="Tổng số lượng" />
                        <asp:BoundField DataField="totalAmount" DataFormatString="{0:N}" HeaderText="Doanh thu" />
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="customerGridView" Visible="false" class="bg-white rounded shadow table table-hover table-bordered text-center"
                    runat="server" AutoGenerateEditButton="False" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true"
                    EmptyDataText="Không có dữ liệu" EmptyDataRowStyle-CssClass="font-italic text-secondary h6"
                    OnRowDataBound="gridView_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="code" HeaderText="Mã khách hàng" />
                        <asp:BoundField DataField="name" HeaderText="Tên khách hàng" />
                        <asp:BoundField DataField="totalAmount" DataFormatString="{0:N}" HeaderText="Doanh thu" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="ml-4 mt-2">
            <div class="small font-italic text-secondary">
                Tổng
                <asp:Label ID="totalOfRecordsLabel" Text="0" runat="server"></asp:Label>
                bản ghi</div>
        </div>
    </div>
    <div id="footer">
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="script" runat="server">
    <script type="text/javascript" src="../Resources/Libs/jquery-ui/jquery-ui.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#startDateTextBox').datepicker({
                dateFormat: 'dd/mm/yy'
            });
            $('#endDateTextBox').datepicker({
                dateFormat: 'dd/mm/yy'
            });

            $('.table').DataTable({
                order: [],
                columnDefs: [{
                    targets: [],
                    orderable: false
                }],
                searching: false,
                lengthChange: false,
                info: false,
                paging: false,
                dom: 'Bfrtip'
            });
        });
    </script>
</asp:Content>
