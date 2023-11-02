document.addEventListener('DOMContentLoaded', function () {
    const loginForm = document.getElementById('cadastro-form');

    loginForm.addEventListener('submit', function (e) {
        e.preventDefault();

        $.ajax({
            type: 'POST',
            url: '/Cadastro/RealizaCadastro',
            data: {
                Nome: $('#Nome').val(),
                Email: $('#Email').val(),
                Senha: $('#Senha').val(),
                DataNascimento: $('#DataNascimento').val(),
                Sexo: $('#Sexo').val(),
                Altura: $('#Altura').val(),
                Peso: $('#Peso').val(),
            },
            datatype: "JSON",
            ContentType: "application/json",
            success: (resultado) => {
                if (resultado.sucesso) {
                     Swal.fire({
                	icon: 'success',
                	title: 'Cadastro Realizado',
                	text: 'Seu cadastro foi criado com sucesso!',
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
                    informaErros(resultado.dados);
                }
            }
        });
    })
});
