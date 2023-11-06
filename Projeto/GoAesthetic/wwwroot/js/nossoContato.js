document.addEventListener('DOMContentLoaded', function () {
    const btnFaleConosco = document.getElementById('btnFaleConosco');

    btnFaleConosco.addEventListener('click', function () {
        Swal.fire({
            icon: 'info',
            title: 'Nossos Contatos:',
            text: 'E-mail: contato.goaesthetic@gmail.com Tel: (11) 94548-3720',
            customClass: {
                popup: 'swal-custom-popup',
                content: 'swal-custom-text'
            },
        });
    });
});
