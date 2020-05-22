<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="WebBanVe.Account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Untitled Document</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="description" content="aStar Fashion Template Project" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" type="text/css" href="styles/bootstrap-4.1.3/bootstrap.css" />
    <link href="plugins/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="plugins/OwlCarousel2-2.2.1/owl.carousel.css" />
    <link rel="stylesheet" type="text/css" href="plugins/OwlCarousel2-2.2.1/owl.theme.default.css" />
    <link rel="stylesheet" type="text/css" href="plugins/OwlCarousel2-2.2.1/animate.css" />
    <link rel="stylesheet" type="text/css" href="styles/cart.css" />
    <link rel="stylesheet" type="text/css" href="styles/cart_responsive.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="super_container">
            <%--Header--%>
            <div>
                <!-- Sidebar Menu dọc -->
                <div class="sidebar">

                    <!-- Info -->
                    <!-- Language Viet Nam-->
                    <div class="info_content d-flex flex-row align-items-center justify-content-start">
                        <div class="info_languages has_children">
                            <div class="language_flag">
                                <img src="images/coVietNam.png" alt="LOGO">
                            </div>
                            <div class="dropdown_text">Viet Nam</div>
                        </div>
                    </div>
                    <!-- Logo Bên Trái-->
                    <div class="sidebar_logo">
                        <img src="images/CSGO-Astralis-Wallpaper-csgo-csgowallpapers-.jpg" style="width: 200px; height: 100px">
                    </div>

                    <!-- Sidebar Navigation -->
                    <nav class="sidebar_nav">
                        <ul>
                            <li><a href="/Home.aspx">Home<i class="fa fa-angle-right" aria-hidden="true"></i></a></li>
                            <li><a href="/Home.aspx">Phim Đang Chiếu<i class="fa fa-angle-right" aria-hidden="true"></i></a></li>
                            <li><a href="/PhimSapCieu.aspx">Phim Sắp Chiếu<i class="fa fa-angle-right" aria-hidden="true"></i></a></li>
                            <li><a href="https://www.facebook.com/astralisgg/" target="_blank">Tuyển Dụng<i class="fa fa-angle-right" aria-hidden="true"></i></a></li>

                            <li><a href="https://www.facebook.com/astralisgg/" target="_blank">Liên Hệ<i class="fa fa-angle-right" aria-hidden="true"></i></a></li>
                        </ul>
                    </nav>

                    <!--Ô Search -->

                    <!-- Giọ Hàng -->
                    <div class="cart d-flex flex-row align-items-center justify-content-start">
                        <div class="cart_icon">
                            <a href="cart.html">
                                <asp:ImageButton ID="btnAccount" runat="server" ImageUrl="~/images/unknowPerson.PNG" PostBackUrl="~/Account.aspx" />
                            </a>
                        </div>

                        <div class="cart_text">&nbsp;&nbsp;&nbsp;&nbsp;LOGIN </div>

                    </div>
                </div>
                <!-- Sidebar Menu dọc -->

                <!-- Home  ẢNh tiêu đều của web-->
                <div class="home" style="height: 450px">
                    <div class="parallax_background parallax-window" data-parallax="scroll" data-image-src="image/Ast.gif" data-speed="0.8"></div>
                    <div class="home_container">
                        <div class="home_content">
                            <div class="home_title" style="color: white">ASTRALIS CINEMA</div>
                        </div>
                    </div>
                </div>
            </div>










            <div class="cart_section">
                <div class="section_container cart_extra_container">
                    <div class="container">
                        <h1 style="text-align: center">Trang Tài Khoản</h1>
                        <br />
                        <br />
                        <br />
                        <div class="row">

                            <table style="width: 600px; height: 150px">
                                <tr>
                                    <td>Email:</td>
                                    <td>
                                        <asp:TextBox ID="txtEmailLog" runat="server" type="email"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Password:</td>
                                    <td>
                                        <asp:TextBox ID="txtPasswordLog" runat="server" type="password"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                    <td></td> 
                                    <td>
                                        <asp:ImageButton ID="btnLogin" runat="server" ImageUrl="\images\loginbutton.png" OnClick="ImageButton1_Click" />LOGIN</td>
                                </tr>
                            </table>
                            <table style="width: 600px; height: 300px">
                                <tr>
                                    <td>Email:</td>
                                    <td>
                                        <asp:TextBox ID="txtEmailSign" runat="server" type="email"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                    <td>Password:ddd</td>
                                    <td>
                                        <asp:TextBox ID="txtPasswordSign" runat="server" type="password"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Họ Và Tên:Duy sau:</td>
                                    <td>
                                        <asp:TextBox ID="txtName" runat="server" type="text"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Số Điện Thoại:</td>
                                    <td>
                                        <asp:TextBox ID="txtSDT" runat="server" type="number"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                    <td>Địa Chỉ:</td>
                                    <td>
                                        <asp:TextBox ID="txtDiaChi" runat="server" type="text"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                    <td>Ngày Sinh:</td>
                                    <td>
                                        <asp:TextBox ID="txtDOB" runat="server" type="date"></asp:TextBox>


                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <asp:ImageButton ID="btnSign" runat="server" ImageUrl="\images\loginbutton.png" OnClick="btnSign_Click" />Sign Up</td>
                                </tr>
                            </table>
                        </div>
                        <div>Thông Tin Tài Khoản Sau Khi Đăng Nhập</div>
                        <div style="border:solid">
                            <table style="width: 600px; height: 200px">
                                <tr>
                                    <td>Email:</td>
                                    <td>
                                        <asp:Label ID="txtEmailacc" runat="server"></asp:Label>

                                    </td>
                                </tr>
                               
                                <tr>
                                    <td>Họ Và Tên:</td>
                                    <td>
                                        <asp:Label ID="txtNameacc" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Số Điện Thoại:</td>
                                    <td>
                                        <asp:Label ID="txtSdtacc" runat="server"></asp:Label>

                                    </td>
                                </tr>
                                <tr>
                                    <td>Địa Chỉ:</td>
                                    <td>
                                        <asp:Label ID="txtDiaChiacc" runat="server"></asp:Label>

                                    </td>
                                </tr>
                                <tr>
                                    <td>Ngày Sinh:</td>
                                    <td>
                                        <asp:Label ID="txtNgaySinhacc" runat="server"></asp:Label>


                                    </td>
                                </tr>

                            </table>
                        </div>

                    </div>
                </div>
            </div>







            <!--footer-->
            <footer class="footer">
                <div class="footer_content">
                    <div class="section_container">
                        <div class="container">
                            <div class="row">
                                <!-- About -->
                                <div class="col-xxl-3 col-md-6 footer_col">
                                    <div class="footer_about">
                                        <!-- Logo -->
                                        <div class="footer_logo">
                                            <img src="images/CSGO-Astralis-Wallpaper-csgo-csgowallpapers-.jpg" style="width: 250px; height: 150px">
                                        </div>
                                        <div class="footer_about_text">
                                            <p>
                                                Dịch Vụ Khách Hàng<br>
                                                *Hotline: 0377398442<br>
                                                *Giờ hoạt động: 24/7
                                                <br>
                                                *Email : kieuminhduc01@gmail.com
                                            </p>
                                        </div>
                                    </div>
                                </div>
                                <!-- Questions -->
                                <!-- Blog -->
                                <!-- Contact -->
                                <div class="col-xxl-3 col-md-6 footer_col">
                                    <div class="footer_contact">
                                        <div class="footer_title">Danh Sách Các Rạp</div>
                                        <div class="">
                                            <ul>
                                                <li class="d-flex flex-row align-items-start justify-content-start"><span>1.</span>
                                                    <div>Rạp Astralis Wuhan(Địac chỉ wuhan-china)</div>
                                                </li>
                                                <li class="d-flex flex-row align-items-start justify-content-start"><span>2.</span>
                                                    <div>Rạp Astralis Hola(Địac chỉ Hòa Lạc-Thạch Thất-Hà Nội)</div>
                                                </li>
                                                <li class="d-flex flex-row align-items-start justify-content-start"><span>3.</span>
                                                    <div>Rạp Astralis Xuho(Địac chỉ Xuân Hòa-Vĩnh Phúc)</div>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Social -->
                <div class="footer_social">
                    <div class="section_container">
                        <div class="container">
                            <div class="row">
                                <div class="col">
                                    <div class="footer_social_container d-flex flex-row align-items-center justify-content-between">
                                        <!-- Google + -->
                                        <a href="https://aboutme.google.com/u/0/?referer=gplus" target="_blank">
                                            <div class="footer_social_item d-flex flex-row align-items-center justify-content-start">
                                                <div class="footer_social_icon">
                                                    <i class="fa fa-google-plus" aria-hidden="true">
                                                        <link>
                                                    </i>
                                                </div>
                                                <div class="footer_social_title">google +</div>
                                            </div>
                                        </a>

                                        <!-- Facebook -->
                                        <a href="https://www.facebook.com/astralisgg/" target="_blank">
                                            <div class="footer_social_item d-flex flex-row align-items-center justify-content-start">
                                                <div class="footer_social_icon"><i class="fa fa-facebook" aria-hidden="true"></i></div>
                                                <div class="footer_social_title">facebook</div>
                                            </div>
                                        </a>
                                        <!-- Twitter -->
                                        <a href="https://twitter.com/twitterau?lang=en" target="_blank">
                                            <div class="footer_social_item d-flex flex-row align-items-center justify-content-start">
                                                <div class="footer_social_icon"><i class="fa fa-twitter" aria-hidden="true"></i></div>
                                                <div class="footer_social_title">twitter</div>
                                            </div>
                                        </a>
                                        <!-- YouTube -->
                                        <a href="https://www.youtube.com/channel/UCcAT4ylQFMRuntX0B-ZRwtA" target="_blank">
                                            <div class="footer_social_item d-flex flex-row align-items-center justify-content-start">
                                                <div class="footer_social_icon"><i class="fa fa-youtube" aria-hidden="true"></i></div>
                                                <div class="footer_social_title">youtube</div>
                                            </div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Credits -->
                <div class="credits">
                    <div class="section_container">
                        <div class="container">
                            <div class="row">
                                <div class="col">
                                    <div class="credits_content d-flex flex-row align-items-center justify-content-end"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </footer>
        </div>
    </form>
</body>
<script src="js/jquery-3.2.1.min.js"></script>
<script src="styles/bootstrap-4.1.3/popper.js"></script>
<script src="styles/bootstrap-4.1.3/bootstrap.min.js"></script>
<script src="plugins/greensock/TweenMax.min.js"></script>
<script src="plugins/greensock/TimelineMax.min.js"></script>
<script src="plugins/scrollmagic/ScrollMagic.min.js"></script>
<script src="plugins/greensock/animation.gsap.min.js"></script>
<script src="plugins/greensock/ScrollToPlugin.min.js"></script>
<script src="plugins/OwlCarousel2-2.2.1/owl.carousel.js"></script>
<script src="plugins/easing/easing.js"></script>
<script src="plugins/parallax-js-master/parallax.min.js"></script>
<script src="js/cart.js"></script>
</html>
