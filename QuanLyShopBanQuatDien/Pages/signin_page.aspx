<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signin_page.aspx.cs" Inherits="QuanLyShopBanQuatDien.Pages.signin_page" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Đăng nhập</title>
    <link rel="Stylesheet" href="../Resources/Libs/bootstrap-4.5.3/css/bootstrap.min.css" />
    <link rel="Stylesheet" href="../Resources/Custom/Css/main.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="app" class="container-fluid overflow-hidden bg-light">
        <div class="row d-flex align-items-center justify-content-center h-100">
            <div class="col-4 bg-warning bg-white shadow px-4 pb-2">
                <div class="form-group text-center mt-5 mb-4">
                    <div class="h2">Đăng nhập</div>
                </div>
                <div class="form-group">
                    <label for="">
                        Tên đăng nhập</label>
                    <asp:TextBox ID="usernameTextBox" class="form-control" autofocus runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="">
                        Mật khẩu</label>
                    <asp:TextBox ID="passwordTextBox" class="form-control" TextMode="Password" runat="server"></asp:TextBox>
                </div>
                <div class="form-group mb-4">
                    <asp:Label ID="messageLabel" runat="server"></asp:Label>
                </div>
                <div class="form-group">
                    <asp:Button ID="singinButton" class="btn btn-lg btn-primary btn-block" runat="server"
                        Text="Đăng nhập" onclick="singinButton_Click" />
                </div>
            </div>
        </div>
    </div>
    </form>
    <script type="text/javascript" src="../Resources/Libs/jquery-3.7.1/jquery-3.7.1.min.js"></script>
    <script type="text/javascript" src="../Resources/Libs/bootstrap-4.5.3/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../Resources/Custom/Js/main.js"></script>
</body>
</html>
