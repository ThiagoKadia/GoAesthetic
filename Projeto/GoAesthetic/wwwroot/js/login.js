document.addEventListener('DOMContentLoaded', function () {
    const loginForm = document.getElementById('login-form');

    loginForm.addEventListener('submit', function (e) {
        e.preventDefault();

        const senha = loginForm.querySelector('input[name="senha"]').value;

        if (senha === '123') {
            Swal.fire({
                icon: 'success',
                title: 'Login realizado',
                text: 'Voce foi autenticado com sucesso!',
            });
        }
        else {
            Swal.fire({
                icon: 'error',
                title: 'Senha Incorreta!',
                text: 'Insira a senha cadastrada e tente novamente!',
            });
        }


    });
});