$('#btnSalvar').on("click", function () {
    var url = "";
    var tituloAlert = "";
    var textoAlert = "";

    if ($('#Inclusao').val()) {
        url = '/Login/RealizaCadastro';
        tituloAlert = 'Cadastro Realizado';
        textoAlert = 'Seu cadastro foi criado com sucesso!';
    }
    else {
        url = '/Login/AtualizaCadastro';
        tituloAlert = 'Cadastro Atualizado';
        textoAlert = 'Seu cadastro foi atualizado com sucesso!';
    }

    $('.custom-loader').show();
    $('#btnSalvar').attr('disabled', 'disabled');
    $.ajax({
        type: 'POST',
        url: url,
        data: {
            Nome: $('#Nome').val(),
            Email: $('#Email').val(),
            Senha: $('#Senha').val(),
            DataNascimento: $('#DataNascimento').val(),
            Sexo: $('#Sexo').val(),
            Altura: $('#Altura').val(),
            Peso: $('#Peso').val().replace('.', ','),
        },
        datatype: "JSON",
        ContentType: "application/json",
        success: (resultado) => {
            if (resultado.sucesso) {
                Swal.fire({
                    icon: 'success',
                    title: tituloAlert,
                    text: textoAlert,
                    customClass: {
                        popup: 'swal-custom-popup',
                        content: 'swal-custom-text'
                    },
                }).then(function () {
                    window.location.href = '/Home/Index';
                })
            }
            else if (resultado.erro) {
                window.location.href = '/Erro/ErroGenerico';
            }
            else {
                informaErros(resultado.dados);
            }
        },
        complete: function () {
            $('.custom-loader').hide();
            $('#btnSalvar').removeAttr('disabled');
        }
    });
});
