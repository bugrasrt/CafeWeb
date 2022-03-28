"use strict";

var app = new Vue({
    el: '#app',
    data: {
        showOrg: false,
        showPers: false,
        save: true,
        edit: false,
        del: false
    },
    methods: {
        focusBtn: function (typ) {
            var dataEl = document.getElementById(typ);
            dataEl.className = 'btn';
            dataEl.classList.add('btn-primary');
            switch (typ) {
                case 'saveBtn':
                    this.dynamicClass(['editBtn', 'delBtn']);
                    break;

                case 'editBtn':
                    this.dynamicClass(['saveBtn', 'delBtn']);
                    break;

                case 'delBtn':
                    this.dynamicClass(['editBtn', 'saveBtn']);
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