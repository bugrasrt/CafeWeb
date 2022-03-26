"use strict";

var app = new Vue({
    el: '#app',
    data: {
        showCard: true
    },
    methods: {
       capWord: function () {
            this.uname = this.uname.charAt(0).toUpperCase() + uname.slice(1)
        }
    }
})