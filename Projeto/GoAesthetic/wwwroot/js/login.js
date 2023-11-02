document.addEventListener('DOMContentLoaded', function () {
    const loginForm = document.getElementById('login-form');

    loginForm.addEventListener('submit', function (e) {
        e.preventDefault();

        const senha = loginForm.querySelector('input[name="senha"]').value;

        $.ajax({
            type: 'POST',
            url: '/Login/RealizaLogin',
            data: {
                Email: $('#Email').val(),
                Senha: $('#Senha').val()
            },
            datatype: "JSON",
            ContentType: "application/json",
            success: (resultado) => {
                if (resultado.sucesso) {
                   Swal.fire({
                	icon: 'success',
                	title: 'Login realizado',
                	text: 'Usuario autenticado com sucesso!',
                	customClass: {
                    		popup: 'swal-custom-popup',
                    		content: 'swal-custom-text'
                	},
            	   }).then(function () {
                            window.location.href = '/Home/Index';                       
                    })            
                }
                else if (resultado.erro) {
                    window.location.href = '/Erro/Index';
                }
                else {
                    Swal.fire({
                	icon: 'error',
                	title: 'Senha Incorreta!',
                	text: 'Insira a senha cadastrada e tente novamente!',
                	customClass: {
                    		popup: 'swal-custom-popup',
                    		content: 'swal-custom-text'
                	},
           	   });             
            }
        });
    })
});
