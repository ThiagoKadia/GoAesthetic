document.addEventListener('DOMContentLoaded', function () {
    const loginForm = document.getElementById('btn-secondary');

    loginForm.addEventListener('submit', function (e) {
        e.preventDefault();

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
