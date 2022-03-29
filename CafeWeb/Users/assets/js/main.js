"use strict";

function GetSelectedRow(txt) {
    $(document).ready(function () {

        var gridRow = txt.parentNode.parentNode.parentNode;
        $('#orgUpdateId').val(gridRow.cells[0].textContent);
        $('#orgUpdateId').prop('readonly', true);
        $('#orgUpdateName').val(gridRow.cells[1].textContent);
        var chkBox = (gridRow.cells[2].textContent == "Evet") ? true : false;
        $('#orgUpdateActive').prop('checked', chkBox);
    });
}

var app = new Vue({
    el: '#app',
    data: {
        showOrg: false,
        showPers: false,
        save: true,
        edit: false,
        orgPop: false,
        persPop: false
    },
    methods: {
        focusBtn: function (typ) {
            var dataEl = document.getElementById(typ);
            dataEl.className = 'btn';
            dataEl.classList.add('btn-primary');
            switch (typ) {
                case 'saveBtn':
                    this.dynamicClass(['editBtn']);
                    break;

                case 'editBtn':
                    this.dynamicClass(['saveBtn']);
                    break;

                default:
                    break;

            }

        },
        dynamicClass: function (btnList) {
            for (let i = 0; i < btnList.length; i++) {
                document.getElementById(btnList[i]).className = 'btn';
                document.getElementById(btnList[i]).classList.add('btn-light');
            }
        }
    }
})