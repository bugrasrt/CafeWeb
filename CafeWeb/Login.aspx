<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LoginClass.WebForm2" %>

<!DOCTYPE html lang="tr">

<html xmlns="http://www.w3.org/1999/xhtml" 
  lang="tr"
  class="light-style customizer-hide"
  dir="ltr"
  data-theme="theme-default"
  data-assets-path="assets/"
  data-template="vertical-menu-template-free">
  <head>
    <meta charset="utf-8" />
    <meta
      name="viewport"
      content="width=device-width, initial-scale=1.0, user-scalable=no, minimum-scale=1.0, maximum-scale=1.0"
    />

    <title>Login Page</title>

    <meta name="description" content="CafeWeb Giriş Sayfası" />

    <!-- Favicon -->
    <!-- <link rel="icon" type="image/x-icon" href="assets/img/favicon/favicon.ico" /> -->

    <!-- Fonts -->
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin="crossorigin" />
    <link
      href="https://fonts.googleapis.com/css2?family=Public+Sans:ital,wght@0,300;0,400;0,500;0,600;0,700;1,300;1,400;1,500;1,600;1,700&display=swap"
      rel="stylesheet"
    />

    <!-- Icons. Uncomment required icon fonts -->
    <link rel="stylesheet" href="assets/vendor/fonts/boxicons.css" />

    <!-- Core CSS -->
    <link rel="stylesheet" href="assets/vendor/css/core.css" class="template-customizer-core-css" />
    <link rel="stylesheet" href="assets/vendor/css/theme-default.css" class="template-customizer-theme-css" />
    <link rel="stylesheet" href="assets/css/demo.css" />

    <!-- Vendors CSS -->
    <link rel="stylesheet" href="assets/vendor/libs/perfect-scrollbar/perfect-scrollbar.css" />

    <!-- Page CSS -->
    <!-- Page -->
    <link rel="stylesheet" href="assets/vendor/css/pages/page-auth.css" />
    <!-- Helpers -->
    <script src="assets/vendor/js/helpers.js"></script>

    <!--! Template customizer & Theme config files MUST be included after core stylesheets and helpers.js in the <head> section -->
    <!--? Config:  Mandatory theme config file contain global vars & default theme options, Set your preferred theme option in this file.  -->
    <script src="assets/js/config.js"></script>
  </head>
<body>
    <form id="formAuthentication" runat="server" action="Default.aspx" class="mb-3" method="post">
      <div class="container-xxl">
      <div class="authentication-wrapper authentication-basic container-p-y">
        <div class="authentication-inner">
          <!-- Register -->
          <div class="card">
            <div class="card-body">
              <!-- Logo -->
              <div class="app-brand justify-content-center">
                <a href="index.html" class="app-brand-link gap-2">
                  <span class="app-brand-logo demo">
                      <svg version="1.0" xmlns="http://www.w3.org/2000/svg"
                        width="1280.000000pt" height="1280.000000pt" viewBox="0 0 1280.000000 1280.000000"
                        preserveAspectRatio="xMidYMid meet">
                        <metadata>
                        Created by potrace 1.15, written by Peter Selinger 2001-2017
                        </metadata>
                        <g transform="translate(0.000000,1280.000000) scale(0.100000,-0.100000)"
                        fill="#000000" stroke="none">
                        <path d="M6100 12794 c-832 -49 -1570 -223 -2285 -539 -1908 -845 -3297 -2580
                        -3694 -4615 -85 -437 -115 -755 -115 -1235 0 -476 29 -802 110 -1220 324
                        -1678 1313 -3163 2739 -4112 903 -601 1890 -947 2995 -1050 258 -24 853 -24
                        1105 0 834 80 1553 282 2276 638 1793 884 3074 2562 3453 4524 36 186 73 450
                        93 665 24 258 24 853 0 1105 -80 832 -283 1558 -637 2275 -834 1688 -2364
                        2923 -4188 3379 -305 77 -652 135 -987 166 -161 15 -721 27 -865 19z m957
                        -692 c198 -300 339 -714 383 -1129 19 -171 8 -536 -20 -693 -41 -231 -122
                        -460 -223 -632 -73 -124 -124 -190 -269 -349 -245 -270 -378 -456 -493 -694
                        -134 -275 -195 -505 -226 -849 -22 -239 -3 -718 42 -1054 6 -46 9 -85 6 -88
                        -9 -9 -189 279 -250 401 -146 293 -243 614 -277 919 -16 135 -13 404 4 537 57
                        426 224 771 546 1129 123 136 237 273 300 359 438 599 521 1144 335 2199 -14
                        78 -25 148 -25 154 0 16 102 -112 167 -210z m-1393 -844 c176 -271 270 -610
                        269 -973 -1 -271 -39 -449 -142 -660 -60 -123 -97 -172 -279 -378 -216 -243
                        -350 -497 -406 -767 -51 -252 -52 -672 0 -1000 l5 -35 -20 25 c-43 53 -144
                        231 -190 335 -134 303 -186 579 -163 858 22 266 95 473 242 686 39 57 56 77
                        234 282 280 324 398 602 413 974 8 197 -8 361 -73 765 l-7 44 30 -34 c17 -19
                        56 -74 87 -122z m2458 28 c313 -468 380 -1165 158 -1632 -63 -134 -110 -201
                        -237 -342 -271 -299 -404 -542 -467 -857 -47 -233 -47 -578 -2 -914 13 -93 12
                        -94 -6 -71 -84 104 -206 344 -266 525 -72 216 -87 309 -87 555 1 187 3 227 22
                        306 63 259 167 453 360 669 137 154 171 196 246 306 117 170 195 349 233 539
                        22 104 29 388 15 547 -11 121 -51 404 -67 469 l-7 29 23 -20 c12 -11 49 -60
                        82 -109z m808 -5338 c-1 -1102 -369 -2135 -1001 -2802 -106 -113 -273 -257
                        -398 -342 l-96 -66 100 6 c55 3 237 11 405 16 665 22 904 32 1105 46 116 8
                        264 18 330 21 113 5 122 4 148 -17 59 -47 28 -92 -112 -157 -374 -175 -788
                        -308 -1140 -365 -136 -22 -140 -22 -1776 -26 -1155 -2 -1678 0 -1770 8 -396
                        34 -816 155 -1288 371 -166 75 -202 119 -139 169 31 25 64 25 477 -4 215 -15
                        530 -27 1200 -46 209 -6 388 -14 398 -16 36 -11 13 13 -62 64 -115 77 -286
                        227 -393 345 -51 56 -100 101 -108 100 -8 -1 -107 -5 -220 -8 -454 -15 -692
                        38 -954 212 -211 140 -483 460 -585 685 -96 213 -146 529 -122 773 57 567 377
                        915 904 986 l97 13 0 61 c0 33 3 77 6 98 l7 37 2493 0 2494 0 0 -162z"/>
                        <path d="M3770 5529 c-222 -57 -377 -210 -448 -439 -49 -161 -54 -397 -13
                        -590 36 -170 77 -255 203 -425 150 -203 300 -329 483 -408 166 -72 302 -96
                        512 -89 l72 2 -59 100 c-290 487 -498 1136 -561 1748 l-13 122 -50 -1 c-28 0
                        -85 -9 -126 -20z"/>
                        </g>
                        </svg>
                  </span>
                  <span class="app-brand-text demo text-body fw-bolder">CafeWeb</span>
                </a>
              </div>
              <!-- /Logo -->
              <h4 class="mb-2">Hoşgeldiniz</h4>
              <p class="mb-4">CafeWeb'in ayrıcalıklarından yararlanmak için şimdi kaydolun.</p>

                <div class="mb-3">
                  <label for="username" class="form-label">Kullanıcı Adı</label>
                  <input
                    type="text"
                    class="form-control"
                    id="username"
                    name="username"
                    placeholder="Enter your username"
                    autofocus="autofocus"
                  />
                </div>
                <div class="mb-3 form-password-toggle">
                  <div class="d-flex justify-content-between">
                    <label class="form-label" for="password">Şifre</label>
                    <a href="auth-forgot-password-basic.html">
                      <small>Şifremi unuttum</small>
                    </a>
                  </div>
                  <div class="input-group input-group-merge">
                    <input
                      type="password"
                      id="password"
                      class="form-control"
                      name="password"
                      placeholder="&#xb7;&#xb7;&#xb7;&#xb7;&#xb7;&#xb7;&#xb7;&#xb7;&#xb7;&#xb7;&#xb7;&#xb7;"
                      aria-describedby="password"
                    />
                    <span class="input-group-text cursor-pointer"><i class="bx bx-hide"></i></span>
                  </div>
                </div>
                <div class="mb-3">
                  <div class="form-check">
                    <input class="form-check-input" id="Remember" type="checkbox" value="true" name="Remember" />
                    <input type="hidden" value="false" name="Remember" />
                    <label  class="form-check-label" for="rememberMe"> Beni Hatırla </label>
                  </div>
                </div>
                <div class="mb-3">
                  <button id="LogIn" class="btn btn-primary d-grid w-100" type="submit" runat="server">Giriş Yap</button>
                </div>

              <p class="text-center">
                <span>Platformda yeni misiniz?</span>
                <a href="auth-register-basic.html">
                  <span>Hesap oluşturun</span>
                </a>
              </p>
            </div>
          </div>
          <!-- /Register -->
        </div>
      </div>
    </div>

    <!-- Core JS -->
    <!-- build:js assets/vendor/js/core.js -->
    <script src="assets/vendor/libs/jquery/jquery.js"></script>
    <script src="assets/vendor/libs/popper/popper.js"></script>
    <script src="assets/vendor/js/bootstrap.js"></script>
    <script src="assets/vendor/libs/perfect-scrollbar/perfect-scrollbar.js"></script>

    <script src="assets/vendor/js/menu.js"></script>
    <!-- endbuild -->

    <!-- Vendors JS -->

    <!-- Main JS -->
    <script src="assets/js/main.js"></script>

    <!-- Page JS -->

    <!-- Place this tag in your head or just before your close body tag. -->
    <script async="async" defer="defer" src="https://buttons.github.io/buttons.js"></script>
    </form>
</body>
</html>
