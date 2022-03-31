<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CafeWebYetkili.HomePage" %>

<!DOCTYPE html lang="tr">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Ana Sayfa</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />

    <link rel="stylesheet" type="text/css" href="../assets/font/iconsmind-s/css/iconsminds.css" />
    <link rel="stylesheet" type="text/css" href="../assets/font/simple-line-icons/css/simple-line-icons.css" />

    <link rel="stylesheet" type="text/css" href="../assets/css/vendor/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../assets/css/vendor/bootstrap.rtl.only.min.css" />
    <link rel="stylesheet" type="text/css" href="../assets/css/vendor/fullcalendar.min.css" />
    <link rel="stylesheet" type="text/css" href="../assets/css/vendor/dataTables.bootstrap4.min.css" />
    <link rel="stylesheet" type="text/css" href="../assets/css/vendor/datatables.responsive.bootstrap4.min.css" />
    <link rel="stylesheet" type="text/css" href="../assets/css/vendor/select2.min.css" />
    <link rel="stylesheet" type="text/css" href="../assets/css/vendor/perfect-scrollbar.css" />
    <link rel="stylesheet" type="text/css" href="../assets/css/vendor/glide.core.min.css" />
    <link rel="stylesheet" type="text/css" href="../assets/css/vendor/bootstrap-stars.css" />
    <link rel="stylesheet" type="text/css" href="../assets/css/vendor/nouislider.min.css" />
    <link rel="stylesheet" type="text/css" href="../assets/css/vendor/bootstrap-datepicker3.min.css" />
    <link rel="stylesheet" type="text/css" href="../assets/css/vendor/component-custom-switch.min.css" />
    <link rel="stylesheet" type="text/css" href="../assets/css/main.css" />

    <style>
        @import url('https://fonts.googleapis.com/css2?family=Cookie&display=swap');

        .card:active {
            box-shadow: rgba(0, 0, 0, 0.06) 0px 2px 4px 0px inset;
        }
    </style>

</head>
<body id="app-container" class="menu-default show-spinner">
    <form id="form7" runat="server">
       <div>
           <nav class="navbar fixed-top">
            <div class="d-flex align-items-center navbar-left">
                <a href="#" class="menu-button d-none d-md-block">
                    <svg class="main" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 9 17">
                        <rect x="0.48" y="0.5" width="7" height="1" />
                        <rect x="0.48" y="7.5" width="7" height="1" />
                        <rect x="0.48" y="15.5" width="7" height="1" />
                    </svg>
                    <svg class="sub" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 18 17">
                        <rect x="1.56" y="0.5" width="16" height="1" />
                        <rect x="1.56" y="7.5" width="16" height="1" />
                        <rect x="1.56" y="15.5" width="16" height="1" />
                    </svg>
                </a>

                <a href="#" class="menu-button-mobile d-xs-block d-sm-block d-md-none">
                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 26 17">
                        <rect x="0.5" y="0.5" width="25" height="1" />
                        <rect x="0.5" y="7.5" width="25" height="1" />
                        <rect x="0.5" y="15.5" width="25" height="1" />
                    </svg>
                </a>

                <div class="search" data-search-path="Home.aspx?q=">
                    <input placeholder="Search...">
                    <span class="search-icon">
                        <i class="simple-icon-magnifier"></i>
                    </span>
                </div>
            </div>


            <a class="navbar-logo" href="<%#: GetRouteUrl("Yetkili") %>" style="text-align: center;">
                <span class="logo d-none d-xs-block"></span><span style="font-size: large; font-weight: bold; font-family: 'Cookie', cursive;">CafeWeb</span>
                <span class="logo-mobile d-block d-xs-none"></span>
            </a>

            <div class="navbar-right">
                <div class="header-icons d-inline-block align-middle">
                    <div class="d-none d-md-inline-block align-text-bottom mr-3">
                        <div class="custom-switch custom-switch-primary-inverse custom-switch-small pl-1" 
                            data-toggle="tooltip" data-placement="left" title="Dark Mode">
                            <input class="custom-switch-input" id="switchDark" type="checkbox" v-on:change="themeControl" checked>
                            <label class="custom-switch-btn" for="switchDark"></label>
                        </div>
                    </div>

                    <div class="position-relative d-none d-sm-inline-block">
                        <button class="header-icon btn btn-empty" type="button" id="iconMenuButton" data-toggle="dropdown"
                            aria-haspopup="true" aria-expanded="false">
                            <i class="simple-icon-grid"></i>
                        </button>
                        <div class="dropdown-menu dropdown-menu-right mt-3  position-absolute" id="iconMenuDropdown">
                            <a href="#" class="icon-menu-item">
                                <i class="iconsminds-equalizer d-block"></i>
                                <span>Ayarlar</span>
                            </a>

                            <a href="#" class="icon-menu-item">
                                <i class="iconsminds-male-female d-block"></i>
                                <span>Kullanıcılar</span>
                            </a>

                            <a href="#" class="icon-menu-item">
                                <i class="iconsminds-puzzle d-block"></i>
                                <span>Bileşenler</span>
                            </a>

                            <a href="#" class="icon-menu-item">
                                <i class="iconsminds-bar-chart-4 d-block"></i>
                                <span>Kazançlar</span>
                            </a>

                            <a href="#" class="icon-menu-item">
                                <i class="iconsminds-file d-block"></i>
                                <span>Anketler</span>
                            </a>

                            <a href="#" class="icon-menu-item">
                                <i class="iconsminds-suitcase d-block"></i>
                                <span>Görevler</span>
                            </a>

                        </div>
                    </div>

                    <button class="header-icon btn btn-empty d-none d-sm-inline-block" type="button" id="fullScreenButton">
                        <i class="simple-icon-size-fullscreen"></i>
                        <i class="simple-icon-size-actual"></i>
                    </button>

                </div>

                <div class="user d-inline-block">
                    <button class="btn btn-empty p-0" type="button" data-toggle="dropdown" aria-haspopup="true"
                        aria-expanded="false">
                        <span class="name"><%: UserName %></span>
                        <span>
                            <img alt="Profile Picture" src="../Users/assets/img/profiles/accountLogo.svg" />
                        </span>
                    </button>

                    <div class="dropdown-menu dropdown-menu-right mt-3">
                        <a class="dropdown-item" href="#">Hesap</a>
                        <a class="dropdown-item" href="#">Özellikler</a>
                        <a class="dropdown-item" href="#">Geçmiş</a>
                        <a class="dropdown-item" href="#">Destek</a>
                        <a id="SignOut1" runat="server" onserverclick="SignOut1_ServerClick" class="dropdown-item">Çıkış yap</a>
                    </div>
                </div>
            </div>
        </nav>

        <div class="menu">
            <div class="main-menu">
                <div class="scroll">
                    <ul class="list-unstyled">
                        <li class="active">
                            <a href="#">
                                <i class="iconsminds-bucket"></i> Ana Sayfa
                            </a>
                        </li>
                        <li>
                            <a href="#dashboard">
                                <i class="iconsminds-shop-4"></i>
                                <span>Panolar</span>
                            </a>
                        </li>
                        <li>
                            <a href="#layouts">
                                <i class="iconsminds-digital-drawing"></i> Sayfalar
                            </a>
                        </li>
                        <li>
                            <a href="#menu">
                                <i class="iconsminds-three-arrow-fork"></i> Menü
                            </a>
                        </li>
                    </ul>
                </div>
            </div>

            <div class="sub-menu">
                <div class="scroll">
                    <ul class="list-unstyled" data-link="dashboard">
                        <li>
                            <a href="Dashboard.Default.html">
                                <i class="simple-icon-rocket"></i> <span class="d-inline-block">Varsayılan</span>
                            </a>
                        </li>
                        <li>
                            <a href="Dashboard.Analytics.html">
                                <i class="simple-icon-pie-chart"></i> <span class="d-inline-block">Analitikler</span>
                            </a>
                        </li>
                        <li>
                            <a href="Dashboard.Ecommerce.html">
                                <i class="simple-icon-basket-loaded"></i> <span class="d-inline-block">E-Ticaret</span>
                            </a>
                        </li>
                        <li>
                            <a href="Dashboard.Content.html">
                                <i class="simple-icon-doc"></i> <span class="d-inline-block">İçerik</span>
                            </a>
                        </li>
                    </ul>
                    <ul class="list-unstyled" data-link="layouts" id="layouts">
                        <li>
                            <a href="#" data-toggle="collapse" data-target="#collapseAuthorization" aria-expanded="true"
                                aria-controls="collapseAuthorization" class="rotate-arrow-icon opacity-50">
                                <i class="simple-icon-arrow-down"></i> <span class="d-inline-block">Yetki</span>
                            </a>
                            <div id="collapseAuthorization" class="collapse show">
                                <ul class="list-unstyled inner-level-menu">
                                    <li>
                                        <a href="Pages.Auth.Login.html">
                                            <i class="simple-icon-user-following"></i> <span
                                                class="d-inline-block">Giriş yap</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="Pages.Auth.Register.html">
                                            <i class="simple-icon-user-follow"></i> <span
                                                class="d-inline-block">Kayıt ol</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="Pages.Auth.ForgotPassword.html">
                                            <i class="simple-icon-user-unfollow"></i> <span class="d-inline-block">Şifremi
                                                Unuttum</span>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </li>
                        <li>
                            <a href="#" data-toggle="collapse" data-target="#collapseProduct" aria-expanded="true"
                                aria-controls="collapseProduct" class="rotate-arrow-icon opacity-50">
                                <i class="simple-icon-arrow-down"></i> <span class="d-inline-block">Ürün</span>
                            </a>
                            <div id="collapseProduct" class="collapse show">
                                <ul class="list-unstyled inner-level-menu">
                                    <li>
                                        <a href="Pages.Product.List.html">
                                            <i class="simple-icon-credit-card"></i> <span class="d-inline-block">Veri
                                                Listesi</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="Pages.Product.Thumbs.html">
                                            <i class="simple-icon-list"></i> <span class="d-inline-block">Thumb
                                                List</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="Pages.Product.Images.html">
                                            <i class="simple-icon-grid"></i> <span class="d-inline-block">Görsel
                                                Listesi</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="Pages.Product.Detail.html">
                                            <i class="simple-icon-book-open"></i> <span class="d-inline-block">Detaylar</span>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </li>
                        <li>
                            <a href="#" data-toggle="collapse" data-target="#collapseProfile" aria-expanded="true"
                                aria-controls="collapseProfile" class="rotate-arrow-icon opacity-50">
                                <i class="simple-icon-arrow-down"></i> <span class="d-inline-block">Profil</span>
                            </a>
                            <div id="collapseProfile" class="collapse show">
                                <ul class="list-unstyled inner-level-menu">
                                    <li>
                                        <a href="Pages.Profile.Social.html">
                                            <i class="simple-icon-share"></i> <span class="d-inline-block">Sosyal</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="Pages.Profile.Portfolio.html">
                                            <i class="simple-icon-link"></i> <span class="d-inline-block">Portfolyo</span>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </li>
                        <li>
                            <a href="#" data-toggle="collapse" data-target="#collapseBlog" aria-expanded="true"
                                aria-controls="collapseBlog" class="rotate-arrow-icon opacity-50">
                                <i class="simple-icon-arrow-down"></i> <span class="d-inline-block">Blog</span>
                            </a>
                            <div id="collapseBlog" class="collapse show">
                                <ul class="list-unstyled inner-level-menu">
                                    <li>
                                        <a href="Pages.Blog.html">
                                            <i class="simple-icon-list"></i> <span class="d-inline-block">Liste</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="Pages.Blog.Detail.html">
                                            <i class="simple-icon-book-open"></i> <span class="d-inline-block">Detay</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="Pages.Blog.Detail.Alt.html">
                                            <i class="simple-icon-picture"></i> <span class="d-inline-block">Detay
                                                Alt</span>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </li>
                        <li>
                            <a href="#" data-toggle="collapse" data-target="#collapseMisc" aria-expanded="true"
                                aria-controls="collapseMisc" class="rotate-arrow-icon opacity-50">
                                <i class="simple-icon-arrow-down"></i> <span class="d-inline-block">Çeşitli</span>
                            </a>
                            <div id="collapseMisc" class="collapse show">
                                <ul class="list-unstyled inner-level-menu">
                                    <li>
                                        <a href="Pages.Misc.Coming.Soon.html">
                                            <i class="simple-icon-hourglass"></i> <span class="d-inline-block">Çok
                                                Yakında</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="Pages.Misc.Error.html">
                                            <i class="simple-icon-exclamation"></i> <span
                                                class="d-inline-block">Hata</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="Pages.Misc.Faq.html">
                                            <i class="simple-icon-question"></i> <span class="d-inline-block">SSS</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="Pages.Misc.Invoice.html">
                                            <i class="simple-icon-bag"></i> <span class="d-inline-block">Fatura</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="Pages.Misc.Knowledge.Base.html">
                                            <i class="simple-icon-graduation"></i> <span class="d-inline-block">Bilgi
                                                Tabanı</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="Pages.Misc.Mailing.html">
                                            <i class="simple-icon-envelope-open"></i> <span
                                                class="d-inline-block">Mailing</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="Pages.Misc.Pricing.html">
                                            <i class="simple-icon-diamond"></i> <span class="d-inline-block">Fiyatlar</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="Pages.Misc.Search.html">
                                            <i class="simple-icon-magnifier"></i> <span class="d-inline-block">Arama</span>
                                        </a>
                                    </li>

                                </ul>
                            </div>
                        </li>
                    </ul>

                    <ul class="list-unstyled" data-link="menu" id="menuTypes">
                        <li>
                            <a href="#" data-toggle="collapse" data-target="#collapseMenuTypes" aria-expanded="true"
                                aria-controls="collapseMenuTypes" class="rotate-arrow-icon">
                                <i class="simple-icon-arrow-down"></i> <span class="d-inline-block">Menu Types</span>
                            </a>
                            <div id="collapseMenuTypes" class="collapse show" data-parent="#menuTypes">
                                <ul class="list-unstyled inner-level-menu">
                                    <li>
                                        <a href="Menu.Default.html">
                                            <i class="simple-icon-control-pause"></i> <span
                                                class="d-inline-block">Default</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="Menu.Subhidden.html">
                                            <i class="simple-icon-arrow-left mi-subhidden"></i> <span
                                                class="d-inline-block">Subhidden</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="Menu.Hidden.html">
                                            <i class="simple-icon-control-start mi-hidden"></i> <span
                                                class="d-inline-block">Hidden</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="Menu.Mainhidden.html">
                                            <i class="simple-icon-control-rewind mi-hidden"></i> <span
                                                class="d-inline-block">Mainhidden</span>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </li>
                        <li>
                            <a href="#" data-toggle="collapse" data-target="#collapseMenuLevel" aria-expanded="true"
                                aria-controls="collapseMenuLevel" class="rotate-arrow-icon collapsed">
                                <i class="simple-icon-arrow-down"></i> <span class="d-inline-block">Menu Levels</span>
                            </a>
                            <div id="collapseMenuLevel" class="collapse" data-parent="#menuTypes">
                                <ul class="list-unstyled inner-level-menu">
                                    <li>
                                        <a href="#">
                                            <i class="simple-icon-layers"></i> <span class="d-inline-block">Sub
                                                Level</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#" data-toggle="collapse" data-target="#collapseMenuLevel2"
                                            aria-expanded="true" aria-controls="collapseMenuLevel2"
                                            class="rotate-arrow-icon collapsed">
                                            <i class="simple-icon-arrow-down"></i> <span class="d-inline-block">Another
                                                Level</span>
                                        </a>
                                        <div id="collapseMenuLevel2" class="collapse">
                                            <ul class="list-unstyled inner-level-menu">
                                                <li>
                                                    <a href="#">
                                                        <i class="simple-icon-layers"></i> <span class="d-inline-block">Sub
                                                            Level</span>
                                                    </a>
                                                </li>
                                            </ul>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </li>
                        <li>
                            <a href="#" data-toggle="collapse" data-target="#collapseMenuDetached" aria-expanded="true"
                                aria-controls="collapseMenuDetached" class="rotate-arrow-icon collapsed">
                                <i class="simple-icon-arrow-down"></i> <span class="d-inline-block">Detached</span>
                            </a>
                            <div id="collapseMenuDetached" class="collapse">
                                <ul class="list-unstyled inner-level-menu">
                                    <li>
                                        <a href="#">
                                            <i class="simple-icon-layers"></i> <span class="d-inline-block">Sub
                                                Level</span>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </li>
                        <li>
                            <div class="dont-close-menu">
                                <a href="#">
                                    <i class="simple-icon-arrow-right"></i> <span class="d-inline-block">Keep Sub Open</span>
                                </a>
                            </div>
                        </li>
                    </ul>
                
                </div>
            </div>
        </div>

        <main id="app">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-12">
                        <h1 >Yetkili Paneli</h1>
                        <div class="separator mb-5"></div>
                    </div>
                    <div class="col-lg-12 col-xl-6">
                        <div class="icon-cards-row">
                            <div class="glide dashboard-numbers">
                                <div class="glide__track" data-glide-el="track">
                                    <ul class="glide__slides">
                                        <li class="glide__slide">
                                            <a href="#" class="card" id="PersYon" runat="server" onserverclick="PersYon_ServerClick">
                                                <div class="card-body text-center">
                                                    <i class="iconsminds-clock"></i>
                                                    <p class="card-text mb-0">İşletme Yönetimi</p>
                                                    <p class="lead text-center">1</p>
                                                </div>
                                            </a>
                                        </li>
                                        <li class="glide__slide">
                                            <a href="#" class="card">
                                                <div class="card-body text-center">
                                                    <i class="iconsminds-basket-coins"></i>
                                                    <p class="card-text mb-0">Personel Yönetimi</p>
                                                    <p class="lead text-center">2</p>
                                                </div>
                                            </a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </main>

        <footer class="page-footer" style="text-align: center;">
            <p class="mb-0 text-muted">CafeWeb© 2022</p>

        </footer>
       </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/vue@2.6.14/dist/vue.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script type="text/javascript" src="../Users/assets/js/vendor/bootstrap.bundle.min.js"></script>
    <script type="text/javascript" src="../Users/assets/js/vendor/Chart.bundle.min.js"></script>
    <script type="text/javascript" src="../Users/assets/js/vendor/chartjs-plugin-datalabels.js"></script>
    <script type="text/javascript" src="../Users/assets/js/vendor/moment.min.js"></script>
    <script type="text/javascript" src="../Users/assets/js/vendor/fullcalendar.min.js"></script>
    <script type="text/javascript" src="../Users/assets/js/vendor/datatables.min.js"></script>
    <script type="text/javascript" src="../Users/assets/js/vendor/perfect-scrollbar.min.js"></script>
    <script type="text/javascript" src="../Users/assets/js/vendor/progressbar.min.js"></script>
    <script type="text/javascript" src="../Users/assets/js/vendor/jquery.barrating.min.js"></script>
    <script type="text/javascript" src="../Users/assets/js/vendor/select2.full.js"></script>
    <script type="text/javascript" src="../Users/assets/js/vendor/nouislider.min.js"></script>
    <script type="text/javascript" src="../Users/assets/js/vendor/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="../Users/assets/js/vendor/Sortable.js"></script>
    <script type="text/javascript" src="../Users/assets/js/vendor/mousetrap.min.js"></script>
    <script type="text/javascript" src="../Users/assets/js/vendor/glide.min.js"></script>
    <script type="text/javascript" src="../Users/assets/js/dore.script.js"></script>
    <script type="text/javascript" src="../Users/assets/js/scripts.js"></script>
    <script type="text/javascript" src="../Users/assets/js/main.js"></script>
</body>
</html>
