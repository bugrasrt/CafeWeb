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
                    this.dynamicClass('editBtn', 'delBtn');
                    break;

                case 'editBtn':
                    this.dynamicClass('saveBtn', 'delBtn');
                    break;

                case 'delBtn':
                    this.dynamicClass('editBtn', 'saveBtn');
                    break;

                default:
                    break;

            }

        },
        dynamicClass: function (btn1, btn2) {
            document.getElementById(btn1).className = 'btn';
            document.getElementById(btn1).classList.add('btn-light');
            document.getElementById(btn2).className = 'btn';
            document.getElementById(btn2).classList.add('btn-light');
        }   
    }
})