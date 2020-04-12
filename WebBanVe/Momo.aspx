<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Momo.aspx.cs" Inherits="WebBanVe.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>JSP Page</title>
    <link rel="stylesheet" href="bootstrap-4.3.1-dist/css/bootstrap.css">
    <script src="bootstrap-4.3.1-dist/js/bootstrap.js"></script>
    <link rel="stylesheet" href="css/momo.css">
</head>
<body>
    <form id="form1" runat="server">
        <div id="main">
            <div class="col-md-9 offset-md-1" id="head">
                <img alt="telephone" src="image/momoFone.PNG" />
                <a href="https://mail.google.com/mail/u/0/#inbox?compose=jrjtXDzgwXCnHSjBPzVvSxXDgJGLqbKgXzGZplGHcRLFZbbKLxGDQDQhxsfnTllNXmnpSgrS">
                    <img alt="email" src="image/Capture.PNG" /></a>
            </div>
            <div id="left">
                <table class="table " style="color: white">
                    <tr>
                        <td>Nhà cung cấp</td>
                        <td>ASTRALIS CINEMA</td>
                    </tr>
                    <tr>
                        <td>Số tiền</td>
                        <td>
                            <asp:Label ID="tongTien" runat="server" ></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <div id="clockdiv">
                                <h2>THỜI GIAN ĐẶT VÉ</h2>
                                <div>
                                    <span class="minutes"></span>
                                    <div class="smalltext">Minutes</div>
                                </div>
                                <div>
                                    <span class="seconds"></span>
                                    <div class="smalltext">Seconds</div>
                                </div>
                            </div>
                        </td>
                    </tr>

                </table>
            </div>
            <div id="content">
                <div>
                    <img alt="logoMoMo" src="image/logomomo.PNG" width="400">
                    <p style="color: #AF206F; text-align: center; font-weight: 800">Quét mã để thanh toán</p>
                    <img id="qrcode" alt="QRCode" src="image/qrCode.PNG">
                    <p style="text-align: center">sử dụng App MOMO hoặc ứng dụng camera hỗ trợ QR code để quét mã.</p>
                    <p style="color: aqua; text-align: center">Hoặc</p>
                    <p>Đăng kí tài khoản <strong>MOMO</strong> và thanh toán lần đầu Hoặc <a href="https://vimomo.vn/vi-momo-la-gi-nhan-khuyen-mai-tu-vi-dien-tu-momo">Đăng Nhập</a></p>
                    </br>
                   
                    <a href="https://business.momo.vn/thanh-toan-cung-momo/dang-ky">
                        <img alt="dang ki" src="image/KiNgay.PNG"></a>
                    <asp:Button ID="Button1" runat="server" Text="Thanh Toán" style="color: #AF206F; font-size: 25px; font-weight: 900" OnClick="Button1_Click"></asp:Button>
        

                </div>
            </div>
            <img src="image/Capture_1.PNG" alt="" />
        </div>
        <script type='text/javascript'>
            //<![CDATA[
            function getTimeRemaining(endtime) {
                var t = Date.parse(endtime) - Date.parse(new Date());
                var seconds = Math.floor((t / 1000) % 60);
                var minutes = Math.floor((t / 1000 / 60) % 2);


                return {
                    'total': t,
                    'minutes': minutes,
                    'seconds': seconds
                };
            }

            function initializeClock(id, endtime) {
                var clock = document.getElementById(id);
                var minutesSpan = clock.querySelector('.minutes');
                var secondsSpan = clock.querySelector('.seconds');

                function updateClock() {
                    var t = getTimeRemaining(endtime);
                    minutesSpan.innerHTML = ('0' + t.minutes).slice(-2);
                    secondsSpan.innerHTML = ('0' + t.seconds).slice(-2);

                    if (t.total <= 0) {
                        clearInterval(timeinterval);
                        alert("Hết Thời Gian Mua Vé");
                        window.location.href = "/Home.aspx";
                       
                    }
                }

                var timeinterval = setInterval(updateClock, 1000);
            }

            var deadline = new Date(Date.parse(new Date()) + 1 * 60 * 1000);
            initializeClock('clockdiv', deadline);
//]]>
        </script>
    </form>
</body>
</html>
