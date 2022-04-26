"use strict";

function SweetPopup() {
    let resultEl = document.getElementById('resultEl');
    let result = resultEl.textContent;
    let resultList = result.split(':');  

    if (resultList[0] != '0') {
        ErrorPopup(resultList[1]);
    }
    else {
        switch (resultList[1]) {
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
        }
    }

    resultEl.innerText = '';
}

function ErrorPopup(message) {
    let resultEl = document.getElementById('resultEl');

    Swal.fire(
        'Hata!',
        message,
        'error'
    )

    resultEl.innerText = '';
}

var app = new Vue({
    el: '#app',
    mounted() {
        if (document.getElementById('resultEl').innerText != "") {
            SweetPopup()
        }
    }
})
