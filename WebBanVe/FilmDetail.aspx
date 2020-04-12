<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FilmDetail.aspx.cs" Inherits="WebBanVe.FilmDetail" %>

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
                       
                        <div class="cart_text"> &nbsp;&nbsp;&nbsp;&nbsp;LOGIN </div>
            
                    </div>
                </div>
                <!-- Sidebar Menu dọc -->

                <!-- Home  ẢNh tiêu đều của web-->
                <div class="home"style="height:450px">
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
                        <div class="row">
                            <div>
                                <asp:Repeater ID="rptPaging" runat="server">
                                    <HeaderTemplate>
                                        <table border="0" id="tbDetails" style="width: 1000px; border-collapse: collapse;" cellpadding="5" cellspacing="0">
                                            <tr>
                                                <th>hình Ảnh</th>
                                                <th>Chi Tiet</th>
                                            </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr style="height: 25px;" >
                                            <td rowspan="10">
                                                <image src="<%#Eval("[poster]") %>" width="200" height="300"></image>
                                            </td>
                                            <td>
                                                <label style="color: darkred; font-weight: bold">Tên Phim  : </label>
                                                <%#Eval("tenphim").ToString()%></td>
                                        </tr>
                                        <tr style="height: 25px;">

                                            <td>
                                                <label style="color: darkred; font-weight: bold">Đạo Diễn  : </label>
                                                <%#Eval("[daoDien]").ToString()%></td>
                                        </tr>
                                        <tr style="height: 25px;">

                                            <td>
                                                <label style="color: darkred; font-weight: bold">Diễn Viên  : </label>
                                                <%#Eval("[dienVien]").ToString()%></td>
                                        </tr>
                                        <tr style="height: 25px;">

                                            <td>
                                                <label style="color: darkred; font-weight: bold">Thể Loại  : </label>
                                                <%#Eval("[theLoai]").ToString()%></td>
                                        </tr>
                                        <tr style="height: 25px;">

                                            <td>
                                                <label style="color: darkred; font-weight: bold">Năm Sản Xuất  : </label>
                                                <%#Eval("[namSanXuat]").ToString()%></td>
                                        </tr>
                                        <tr style="height: 25px;">

                                            <td>
                                                <label style="color: darkred; font-weight: bold">Quốc Gia  : </label>
                                                <%#Eval("[quocGia]").ToString()%></td>
                                        </tr>
                                        <tr style="height: 25px;">

                                            <td>
                                                <label style="color: darkred; font-weight: bold">Thời Lượng  : </label>
                                                <%#Eval("[thoiLuong]").ToString()%></td>
                                        </tr>
                                        <tr style="height: 25px;">

                                            <td>
                                                <label style="color: darkred; font-weight: bold">Ngôn Ngữ  : </label>
                                                <%#Eval("[ngonNgu]").ToString()%></td>
                                        </tr>
                                        <tr style="height: 25px;">

                                            <td>
                                                <label style="color: darkred; font-weight: bold">Ngày Khởi Chiếu  : </label>
                                                <%#Eval("[ngayKhoiChieu]").ToString()%></td>
                                        </tr>
                                        <tr style="height: 100px;">

                                            <td>
                                                <label style="color: darkred; font-weight: bold">Nội Dung  : </label>
                                                <%#Eval("[noiDung]").ToString()%></td>
                                        </tr>
                                        <tr style="height: 300px;">
                                            <td colspan="2">
                                                <iframe width="1000" height="315" src='<%#Eval("[trailer]").ToString()%>' frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                                <table style="height: 100px">
                                    <tr>
                                        <td style="width: 300px; color: sienna; font-weight: bold">Dach Sach Rạp Có Suất Chiếu:</td>
                                        <td>
                                            <asp:RadioButtonList ID="rblRap" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rblRap_SelectedIndexChanged"></asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Ngày Chiếu</td>
                                        <td>
                                            <asp:Calendar ID="cPickDate" runat="server" AutoPostBack="false" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" OnDayRender="cPickDate_DayRender" TitleFormat="Month" Width="400px" OnSelectionChanged="cPickDate_SelectionChanged">
                                                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
                                                <DayStyle Width="14%" />
                                                <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                                                <OtherMonthDayStyle ForeColor="#999999" />
                                                <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
                                                <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                                                <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                                                <TodayDayStyle BackColor="#CCCC99" />
                                            </asp:Calendar>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 300px; color: sienna; font-weight: bold">Suất Chiếu</td>
                                        <td>
                                            <asp:RadioButtonList AutoPostBack="true" ID="rbSuat" runat="server" OnSelectedIndexChanged="rbSuat_SelectedIndexChanged" OnLoad="rbSuat_Load"></asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 300px; color: sienna; font-weight: bold">Khán Đài</td>
                                        <td>
                                            <asp:RadioButtonList AutoPostBack="true" ID="rbKhanDai" runat="server"></asp:RadioButtonList>.
                                        </td>
                                    </tr>

                                </table>
                                <label>Chọn ghế</label>
                                <asp:Panel ID="pnGhe" runat="server">
                                </asp:Panel>
                                <br />
                                <div style="color: white">
                                    <label style="background-color: #40568D">Phổ Thông</label><asp:TextBox ID="txtPhoThong" Enabled="false" runat="server"></asp:TextBox><br />
                                    <label style="background-color: #0084FF">VIP &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp</label><asp:TextBox ID="txtVIP" runat="server" Enabled="false"></asp:TextBox><br />
                                    <label style="background-color: #FE6550">Deluxe &nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp; </label>
                                    <asp:TextBox ID="txtDeluxe" runat="server" Enabled="false"></asp:TextBox><br />
                                    <label style="background-color: #D04323">SwitchBox&nbsp</label><asp:TextBox ID="txtSwitchBox" runat="server" Enabled="false"></asp:TextBox>
                                </div>

                                <label>Tạm Tính </label>
                                <asp:TextBox ID="txtTamTinh" runat="server" Enabled="false"></asp:TextBox>
                               <br />
                                <%--<asp:Button  ID="btnDatVe" runat="server" Text="Đặt Vé"  OnClick="btnDatVe_Click" />--%>
                                <asp:ImageButton Height="50" Width="70" ID="btnDatVe" runat="server" ImageUrl="~/images/datve.PNG" OnClick="btnDatVe_Click" />

                            </div>
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
