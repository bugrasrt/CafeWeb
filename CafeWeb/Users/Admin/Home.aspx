<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CafeWebAdmin.WebForm1" %>

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
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">

    <style>
        @import url('https://fonts.googleapis.com/css2?family=Cookie&display=swap');

        .card:active {
            box-shadow: rgba(0, 0, 0, 0.06) 0px 2px 4px 0px inset;
        }
    </style>
</head>
<body id="app-container" class="menu-default show-spinner">
    <form id="form2" runat="server">
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


        <a class="navbar-logo" href="<%#: GetRouteUrl("Admin") %>" style="text-align: center;">
            <span class="logo d-none d-xs-block"></span><span style="font-size: large; font-weight: bold; font-family: 'Cookie', cursive;">CafeWeb</span>
            <span class="logo-mobile d-block d-xs-none"></span>
        </a>

        <div class="navbar-right">
            <div class="header-icons d-inline-block align-middle">
                <div class="d-none d-md-inline-block align-text-bottom mr-3">
                    <div class="custom-switch custom-switch-primary-inverse custom-switch-small pl-1" 
                        data-toggle="tooltip" data-placement="left" title="Dark Mode">
                        <input class="custom-switch-input" id="switchDark" type="checkbox" checked>
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
                    <span class="name"><%: userName %></span>
                    <span>
                        <img alt="Profile Picture" src="../Users/assets/img/profiles/accountLogo.svg" />
                    </span>
                </button>

                <div class="dropdown-menu dropdown-menu-right mt-3">
                    <a class="dropdown-item" href="#">Hesap</a>
                    <a class="dropdown-item" href="#">Özellikler</a>
                    <a class="dropdown-item" href="#">Geçmiş</a>
                    <a class="dropdown-item" href="#">Destek</a>
                    <a id="SignOut" runat="server" onserverclick="SignOut_ServerClick" class="dropdown-item">Çıkış yap</a>
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
                            <i class="iconsminds-digital-drawing"></i> Ana Sayfa
                        </a>
                    </li>
                </ul>
            </div>
        </div>

        <div class="sub-menu">
            <div class="scroll">
            </div>
        </div>

    </div>

    <!--MAIN-->
    <main>
        <div id="app" class="container-fluid">
            <div  id="bgBlur" v-if="orgPop || persPop" @click="orgPop=false; persPop=false;"></div>
            <div class="row" style="text-align:center;">
                <div class="col-12">
                    <h1>Admin Paneli</h1>
                    <div class="separator mb-5"></div>
                    <button class="w3-button w3-large w3-circle w3-light-grey" v-show="(showOrg || showPers) && (!orgPop || persPop)" style="margin-bottom:30px;" 
                        @click="showOrg=false; showPers=false; save=true; edit=false; focusBtn('saveBtn');">‹</button>
                </div>
            </div>

            <div class=row v-show="showOrg || showPers" style="gap: 30px; margin-bottom: 30px; justify-content:center; align-content:center;">
                <button id="saveBtn" @focus="focusBtn('saveBtn'); save=true; edit=false;"  type="button" class="btn btn-primary">Kaydet</button>
                <button id="editBtn" @focus="focusBtn('editBtn'); edit=true; save=false;"  type="button" class="btn btn-light">Düzenle</button>
            </div>
            
            <!--İşlem Blokları-->
            <div class="row" style="justify-content:center;"> 

                <!--İşletme Kayıt-->
                <div class="col-12 col-lg-6 mb-5" v-show="showOrg && save">
                    <h5 class="mb-5">İşletme Kayıt Formu</h5>
                    <div class="card mb-4">
                        <div class="card-body">
                            <h5 class="mb-4">İşletme</h5>
                            <div class="needs-validation tooltip-label-right">
                                <div class="form-group position-relative error-l-50">
                                    <label>Ad</label>
                                    <input type="text" runat="server" id="orgName" name="orgName" class="form-control" required>
                                    <div class="invalid-tooltip">
                                        Ad gerekli!
                                    </div>
                                </div>
                                <div class="form-group position-relative">
                                    <div class="custom-control custom-checkbox">
                                        <input type="checkbox" runat="server" class="custom-control-input" id="isActive"
                                            name="isActive">
                                        <label class="custom-control-label" for="isActive">Aktif mi?</label>
                                    </div>
                                </div>
                                <button id="SaveOrg" type="button" class="btn btn-primary mb-0" runat="server" onserverclick="SaveOrg_ServerClick">Kaydet</button>
                            </div>
                        </div>
                    </div>
                </div>

                <!--İşletme Düzenleme-->
                <div v-show="(showOrg && edit) && (!orgPop && !persPop)">
                    <h5 class="mb-5">İşletme Listesi</h5>
                    <asp:GridView runat="server" ID="OrgView"
                        ItemType="Database.Org" DataKeyNames="Id" AllowPaging="true"
                        SelectMethod="OrgView_GetData" CssClass="styled-table" OnRowDataBound="OrgView_RowDataBound"
                        AutoGenerateColumns="false" EmptyDataText="There are no data records to display.">
                        <Columns>
                            <asp:DynamicField DataField="Id" />
                            <asp:TemplateField HeaderText="İşletme Adı">
                                <ItemTemplate>
                                <asp:Label Text="<%# Item.OrgName.ToString() %>" 
                                    runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Aktif mi?">
                                <ItemTemplate>
                                <asp:Label Text='<%# Item.isActive == true ? "Evet": "Hayır" %>' 
                                    runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="Oluşturulma Tarihi">
                                <ItemTemplate>
                                <asp:Label Text="<%# Item.CreatedAt.ToString() %>" 
                                    runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>   
                            <asp:TemplateField HeaderText="Değiştirilme Tarihi">
                                <ItemTemplate>
                                <asp:Label Text="<%# Item.ChangedAt.ToString() %>" 
                                    runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>  
                            <asp:TemplateField HeaderText="Güncelle">
                                <ItemTemplate>
                                    <div @click="orgPop=true;">
                                        <a id="updateOrg" href="#" onclick="GetSelectedRow(this);">Güncelle</a>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sil">
                                <ItemTemplate>
                                <a href="#">Sil</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>

                <!--İşletme Güncelleme Popup-->
                <div id="orgUpdatePop" class="col-12 col-lg-6 mb-5" v-show="showOrg && edit && orgPop">
                    <button class="closeBtn" @click="orgPop=false" style="float:right;">X</button>
                    <h5 class="mb-5">İşletme Güncelleme</h5>
                    <div class="card mb-4">
                        <div class="card-body">
                            <h5 class="mb-4">İşletme</h5>
                            <div class="needs-validation tooltip-label-right">
                                <div class="form-group position-relative error-l-50">
                                    <label for="orgUpdateId">Id</label>
                                    <input type="text" runat="server" id="orgUpdateId" name="orgUpdateId" class="form-control"/>
                                </div>
                                <div class="form-group position-relative error-l-50">
                                    <label for="orgUpdateName">Ad</label>
                                    <input type="text" runat="server" id="orgUpdateName" name="orgUpdateName" class="form-control" required>
                                    <div class="invalid-tooltip">
                                        Ad gerekli!
                                    </div>
                                </div>
                                <div class="form-group position-relative">
                                    <div class="custom-control custom-checkbox">
                                        <input type="checkbox" runat="server" class="custom-control-input" id="orgUpdateActive"
                                            name="orgUpdateActive">
                                        <label class="custom-control-label" for="orgUpdateActive">Aktif mi?</label>
                                    </div>
                                </div>
                                <button id="orgUpdateBtn" type="button" class="btn btn-primary mb-0" runat="server" onserverclick="orgUpdateBtn_ServerClick">Güncelle</button>
                            </div>
                        </div>
                    </div>
                </div>


                <!--Personel Kayıt-->
                <div class="col-12 col-lg-6" v-show="showPers && save">
                    <h5 class="mb-5">Personel Kayıt Formu</h5>
                    <div class="card mb-4">
                        <div class="card-body">
                            <h5 class="mb-4">İlgili Bilgiler</h5>
                            <div id="rulesForm" class="tooltip-label-right">
                                <div class="form-group position-relative error-l-50">
                                    <label>Organizasyon Id</label>
                                    <input type="text" class="form-control" name="rulesId">
                                    <small class="form-text text-muted">Sadece 6 adet rakamdan oluşmalıdır!</small>
                                </div>
                                <div class="form-group position-relative error-l-50">
                                    <label>Ad</label>
                                    <input type="text" class="form-control" name="rulesName">
                                    <small class="form-text text-muted">Sadece karakter içermelidir!</small>
                                </div>
                                <div class="form-group position-relative error-l-75">
                                    <label>Şifre</label>
                                    <input type="text" class="form-control" name="rulesPassword" id="rulesPassword">
                                    <small class="form-text text-muted">En az 8 karakter olmalıdır!</small>
                                </div>
                                <div class="form-group position-relative error-l-125">
                                    <label>Şifre tekrar</label>
                                    <input type="text" class="form-control" name="rulesPasswordConfirm"
                                        id="rulesPasswordConfirm">
                                    <small class="form-text text-muted">Şifreyle aynı olmalıdır!</small>
                                </div>
                                <button type="button" class="btn btn-primary mb-0">Kaydet</button>
                            </div>
                        </div>
                    </div>
                </div>

                <!--Personel Düzenleme-->
                <div v-show="(showPers && edit) && (!orgPop && !persPop)">
                    <h5 class="mb-5">Personel Listesi</h5>
                    <asp:GridView runat="server" ID="UserView"
                        ItemType="Database.User" DataKeyNames="Id"
                        SelectMethod="UserView_GetData" CssClass="styled-table" OnRowDataBound="UserView_RowDataBound"
                        AutoGenerateColumns="false" EmptyDataText="There are no data records to display.">
                        <Columns>
                            <asp:DynamicField DataField="Id" />
                            <asp:TemplateField HeaderText="Kullanıcı Adı">
                                <ItemTemplate>
                                <asp:Label Text="<%# Item.UserName.ToString() %>" 
                                    runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>   
                            <asp:TemplateField HeaderText="Yetki">
                                <ItemTemplate>
                                <asp:Label ID="authLabel" Text='<%# Item.Auth == 2 ? "Yetkili" : "" %>' 
                                    runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>   
                            <asp:TemplateField HeaderText="Oluşturulma Tarihi">
                                <ItemTemplate>
                                <asp:Label Text="<%# Item.CreatedAt.ToString() %>" 
                                    runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>   
                            <asp:TemplateField HeaderText="Değiştirilme Tarihi">
                                <ItemTemplate>
                                <asp:Label Text="<%# Item.ChangedAt.ToString() %>" 
                                    runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>   
                            <asp:TemplateField HeaderText="Organizasyon Id">
                                <ItemTemplate>
                                <asp:Label Text="<%# Item.OrgFk.ToString() %>" 
                                    runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Güncelle">
                                <ItemTemplate>
                                <a href="#">Güncelle</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sil">
                                <ItemTemplate>
                                <a href="#">Sil</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>

                <!--Admin İşlem Butonları-->
                <div class="col-lg-12 col-xl-8" v-show="!showOrg && !showPers">
                    <div class="icon-cards-row">
                        <div class="glide dashboard-numbers">
                            <div class="glide__track" data-glide-el="track">
                                <ul class="glide__slides">
                                    <li class="glide__slide">
                                        <a href="#" class="card" @click="showOrg=true;">
                                            <div class="card-body text-center">
                                                <i class="simple-icon-home"></i>
                                                <p class="card-text mb-0">İşletme Yönetimi</p>
                                                <p class="lead text-center">1</p>
                                            </div>
                                        </a>
                                    </li>
                                    <li class="glide__slide">
                                        <a href="#" class="card" @click="showPers=true;">
                                            <div class="card-body text-center">
                                                <i class="simple-icon-people"></i>
                                                <p class="card-text mb-0">Personel Yönetimi</p>
                                                <p class="lead text-center">2</p>
                                            </div>
                                        </a>
                                    </li>
                                    <li class="glide__slide">
                                        <a href="#" class="card">
                                            <div class="card-body text-center">
                                                <i class="simple-icon-credit-card"></i>
                                                <p class="card-text mb-0">Bilanço Yönetimi</p>
                                                <p class="lead text-center">3</p>
                                            </div>
                                        </a>
                                    </li>
                                    <li class="glide__slide">
                                        <a href="#" class="card">
                                            <div class="card-body text-center">
                                                <i class="simple-icon-basket-loaded"></i>
                                                <p class="card-text mb-0">Envanter Yönetimi</p>
                                                <p class="lead text-center">4</p>
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

<%--        <footer class="page-footer" style="text-align:center;">
            <div class="footer-content">
                <p class="mb-0 text-muted">CafeWeb© 2022</p>
            </div>
        </footer>--%>

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
