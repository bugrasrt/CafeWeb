"use strict";

function GetOrgRow(row) {
    $(document).ready(function () {

        var gridRow = row.parentNode.parentNode.parentNode;
        $('#OrgUpdateId').val(gridRow.cells[0].textContent);
        $('#OrgUpdateId').prop('readonly', true);
        $('#OrgUpdateName').val(gridRow.cells[1].textContent);
        var chkBox = (gridRow.cells[2].textContent == "Evet") ? true : false;
        $('#OrgUpdateActive').prop('checked', chkBox);
    });
}

function GetPersRow(row) {
    $(document).ready(function () {

        var gridRow = row.parentNode.parentNode.parentNode;
        $('#PersUpdateId').val(gridRow.cells[0].textContent);
        $('#PersUpdateId').prop('readonly', true);
        $('#PersUpdateOrgId').val(gridRow.cells[6].textContent);
        $('#PersUpdateName').val(gridRow.cells[1].textContent);
        $('#PersUpdateYetki').val(gridRow.cells[2].textContent == 'Yetkili' ? "2" : "3");
        var chkBox = (gridRow.cells[5].textContent == "Evet") ? true : false;
        $('#PersUpdateActive').prop('checked', chkBox);
    });
}

function GetRowForDel(type, row) {
    var gridRow = row.parentNode.parentNode.parentNode;
    var id = gridRow.cells[0].textContent;
    sessionStorage.setItem('delId', `${type}:${id}`);
    document.getElementById('aspHidden').value = sessionStorage.getItem('delId');
}

function GetWaitingRow(row) {
    $(document).ready(function () {

        var gridRow = row.parentNode.parentNode.parentNode;
        document.getElementById('aspHidden').value = gridRow.cells[0].textContent;
    });
}

function SweetPopup(option) {
    let resultEl = document.getElementById('resultEl');
    let result = resultEl.textContent;
    let resultList = result.split(':');

    if (resultList[0] != '0') {
        ErrorPopup(resultList[1]);
    }
    else {
        switch (option) {
            case 'save':
                Swal.fire(
                    'Başarılı',
                    'Başarıyla kaydedilmiştir.',
                    'success'
                )
                break;

            case 'edit':
                Swal.fire(
                    'Başarılı',
                    'Başarıyla güncellenmiştir.',
                    'success'
                )
                break;

            case 'del':
                Swal.fire(
                    'Başarılı',
                    'Başarıyla silinmiştir.',
                    'success'
                )
                break;

            case 'onay':
                Swal.fire(
                    'Başarılı',
                    'Başarıyla onaylanmıştır.',
                    'success'
                )
                break;
        }
        
    }

    resultEl.innerText = '';
}

function ErrorPopup(message) {
    Swal.fire(
        'Hata!',
        message,
        'error'
    )
}

var app = new Vue({
    el: '#app',
    data: {
        showOrg: false,
        showPers: false,
        showMenus: false,
        showFinancial: false,
        save: true,
        edit: false,
        del: false,
        waiting: false,
        orgPop: false,
        persPop: false,
        isPostBack: false,
        isPop: false
    },
    mounted() {
        this.getState();
    },
    updated() {
        this.setFocusBtn();
    },
    methods: {
        focusBtn: function (btn) {

            var dataEl = document.getElementById(btn);
            dataEl.className = 'btn';
            dataEl.classList.add('btn-primary');

            if (this.showPers) {
                switch (btn) {
                    case 'saveBtn':
                        this.dynamicClass(['editBtn', 'waitingBtn']);

                        break;

                    case 'editBtn':
                        this.dynamicClass(['saveBtn', 'waitingBtn']);

                        break;

                    case 'waitingBtn':
                        this.dynamicClass(['saveBtn', 'editBtn']);

                        break;

                    default:
                        break;
                }
            }
            else {
                switch (btn) {
                    case 'saveBtn':
                        this.dynamicClass(['editBtn']);

                        break;

                    case 'editBtn':
                        this.dynamicClass(['saveBtn']);

                        break;

                    default:
                        break;
                }
            }
            
        },
        setFocusBtn: function () {
            if ((this.save && !this.edit) && (!this.del && !this.waiting)) {
                if (this.showPers || this.showOrg || this.showMenus || this.showFinancial) {
                    this.focusBtn('saveBtn');
                } 
            }
            else if ((!this.save && this.edit) && !this.waiting) {
                if (this.showPers || this.showOrg || this.showMenus || this.showFinancial) {
                    this.focusBtn('editBtn');
                }
            }
            else if ((!this.save && !this.edit) && (!this.del && this.waiting)) {
                if (this.showPers) {
                    this.focusBtn('waitingBtn');
                }
            }
        },
        dynamicClass: function (btnList) {
            for (let i = 0; i < btnList.length; i++) {
                document.getElementById(btnList[i]).className = 'btn';
                document.getElementById(btnList[i]).classList.add('btn-light');
            }
        },
        setFirstState: function () {
            this.showOrg = false;
            this.showPers = false;
            this.showMenus = false;
            this.showFinancial = false;
            this.save = true;
            this.edit = false;
            this.del = false;
            this.waiting = false;
            this.focusBtn('saveBtn');
        },
        clearResultEl: function () {
            document.getElementById('resultEl').innerText = '';
            document.getElementById('aspHidden').innerText = '';
        },
        persFormCheck: function () {
            let orgFk = document.getElementById('PersUpdateOrgId');
            let persName = document.getElementById('PersUpdateName');
            let persYetki = document.getElementById('PersUpdateYetki');
            let yetki = persYetki.options[persYetki.selectedIndex].value;
            if (yetki == null || yetki == "") {
                ErrorPopup('Yetkilendirme boş geçilemez!');
                return null;

            }
            if (orgFk.value == null || orgFk.value == "") {
                ErrorPopup("İşletme Id'si boş bırakılamaz!");
                return null;
            }
            if (persName.value == null || persName.value == "") {
                ErrorPopup("Kullanıcı adı boş geçilemez!");
                return null;
            }

            this.isPop = true;
        },
        userFormCheck: function () {
            let orgFk = document.getElementById('UserOrgId');
            let userName = document.getElementById('UserSetName');
            let userYetki = document.getElementById('UserYetki');
            let password = document.getElementById('UserSetPassword');
            let passConf = document.getElementById('UserSetPassConfirm');
            let yetki = userYetki.options[userYetki.selectedIndex].value;
            if (yetki == null || yetki == "") {
                ErrorPopup('Yetkilendirme boş geçilemez!');
                return null;
            }
            if (orgFk.value == null || orgFk.value == "") {
				ErrorPopup("İşletme Id'si boş bırakılamaz!");
                return null;
            }
            if (userName.value == null || userName.value == "") {
				ErrorPopup("Kullanıcı adı boş geçilemez!");
                return null;
            }
            if ((password.value == "" || passConf.value == "") || (password.value != passConf.value)) {
                ErrorPopup("Şifreler boş veya uyumsuz!");
                return null;
            }

            this.isPop = true;
        },
        preventPostBack: function () {
            if (window.history.replaceState) {
                window.history.replaceState(null, null, window.location.href);
            }
        },
        setState: function (showOrg, showPers, save, edit, del, waiting, isPostBack) {
            sessionStorage.setItem('showOrg', showOrg);
            sessionStorage.setItem('showPers', showPers);
            sessionStorage.setItem('save', save);
            sessionStorage.setItem('edit', edit);
            sessionStorage.setItem('del', del);
            sessionStorage.setItem('onay', waiting);
            sessionStorage.setItem('isPostBack', isPostBack);
            
        },
        getState: function () {
            if (sessionStorage.getItem('isPostBack') != null || sessionStorage.getItem('isPostBack') != "") {
                this.isPostBack = sessionStorage.getItem('isPostBack') == "true" ? true : false;

                if (this.isPostBack) {
                    if (sessionStorage.getItem('showOrg') != null || sessionStorage.getItem('showOrg') != "") {
                        this.showOrg = sessionStorage.getItem('showOrg') == "true" ? true : false;
                    }
                    if (sessionStorage.getItem('showPers') != null || sessionStorage.getItem('showPers') != "") {
                        this.showPers = sessionStorage.getItem('showPers') == "true" ? true : false;
                    }
                    if (sessionStorage.getItem('save') != null || sessionStorage.getItem('save') != "") {
                        this.save = sessionStorage.getItem('save') == "true" ? true : false;
                    }
                    if (sessionStorage.getItem('edit') != null || sessionStorage.getItem('edit') != "") {
                        this.edit = sessionStorage.getItem('edit') == "true" ? true : false;
                    }
                    if (sessionStorage.getItem('del') != null || sessionStorage.getItem('del') != "") {
                        this.del = sessionStorage.getItem('del') == "true" ? true : false;
                    }
                    if (sessionStorage.getItem('onay') != null || sessionStorage.getItem('onay') != "") {
                        this.waiting = sessionStorage.getItem('onay') == "true" ? true : false;
                    }

                    if ((this.save && !this.edit) && (!this.del && !this.waiting)) {
                        SweetPopup('save');
                    }
                    else if ((!this.save && this.edit) && !this.waiting) {
                        if (this.del) {
                            document.getElementById('aspHidden').value = sessionStorage.getItem('delId');
                            this.del = false;
                            SweetPopup('del');
                        }
                        else {
                            SweetPopup('edit');
                        }
                    }
                    else if ((!this.save && !this.edit) && (!this.del && this.waiting)) {
                        SweetPopup('onay');
                    }

                    this.isPostBack = false;
                    sessionStorage.setItem('isPostBack', this.isPostBack);

                    this.preventPostBack();
                }
            }
        }
    }
})
