document.addEventListener('DOMContentLoaded', function () {
    const loginForm = document.getElementById('erro');

    loginForm.addEventListener('submit', function (e) {
        e.preventDefault();

        const erro = true;

        if (erro) {
            Swal.fire({
                icon: 'error',
                title: 'ERRO!',
                text: 'Um erro inesperado ocorreu, entre em contato com os administradores do sistema.',
                customClass: {
                    popup: 'swal-custom-popup',
                    content: 'swal-custom-text'
                },
            });
        }

    });
});
