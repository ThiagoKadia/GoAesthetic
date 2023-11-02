document.addEventListener('DOMContentLoaded', function () {
    const loginForm = document.getElementById('acesso');

    loginForm.addEventListener('submit', function (e) {
        e.preventDefault();

        const acesso = false;

        if (acesso === false) {
            Swal.fire({
                icon: 'question',
                title: 'Acesso Negado!',
                text: 'Você não tem acesso a essa aba. Entre em contato com os administradores',
                customClass: {
                    popup: 'swal-custom-popup',
                    content: 'swal-custom-text'
                },
            });
        }

    });
});
