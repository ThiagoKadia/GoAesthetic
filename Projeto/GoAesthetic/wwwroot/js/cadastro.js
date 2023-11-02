document.addEventListener('DOMContentLoaded', function () {
    const loginForm = document.getElementById('cadastro-form');

    loginForm.addEventListener('submit', function (e) {
        e.preventDefault();

        const cadastroSucedido = true;

        if (cadastroSucedido) {
            Swal.fire({
                icon: 'success',
                title: 'Cadastro Realizado',
                text: 'Seu cadastro foi criado com sucesso!',
                customClass: {
                    popup: 'black-background', // Aplica a classe CSS personalizada ao modal
                },
            });
        }
        else {
            Swal.fire({
                icon: 'error',
                title: 'Cadastro incompleto',
                text: 'Ficaram faltando informações ou houve algum erro no preenchimento.',
                customClass: {
                    popup: 'black-background', // Aplica a classe CSS personalizada ao modal
                },
            });
        }

    });
});
