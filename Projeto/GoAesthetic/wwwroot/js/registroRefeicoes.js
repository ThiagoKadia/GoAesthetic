﻿var listaRefeicoesAdicionadas = new Array();

$('#btnCalcularAlimento').on("click", function () {
    limpaErros();
    if ($('#quantidade').val() == '' || $('#quantidade').val() == 0) {
        $('#quantidade').after('<span class="text-danger erros-formulario" id="erroQuantidade">Digite uma Quantidade</span>');
        return;
    }

    $('.custom-loader').show();
    $('#btnCalcularAlimento').attr('disabled', 'disabled');
    $.ajax({
        type: 'POST',
        url: '/RegistrosRefeicoes/BuscaInformacoesAlimentos',
        data: {
            Id: $('#listaAlimentos option').filter(':selected').val(),
            Quantidade: $('#quantidade').val().replace('.', ',')
        },
        datatype: "JSON",
        ContentType: "application/json",
        success: (resultado) => {
            if (resultado.sucesso) {
                $('#linhaInformacaoAlimento').remove();
                $('#idInformacaoAlimento').remove();

                $('#formularioRegistro').append('<input id="idInformacaoAlimento" type="hidden" value="' + resultado.alimento.id + '">');

                var novaLinha = '<tr id="linhaInformacaoAlimento">'+
                                     '<td id="nomeAlimentoInformacao">' + resultado.alimento.nome + '</td>' +
                                     '<td id="quantidadeAlimentoInformacao">' + FormataNumero(resultado.alimento.quantidade) + '</td>' +
                                     '<td id="energiaAlimentoInformacao">' + FormataNumero(resultado.alimento.energia) + '</td>' +
                                     '<td id="proteinaAlimentoInformacao">' + FormataNumero(resultado.alimento.proteina) + '</td>' +
                                     '<td id="carboidratosAlimentoInformacao">' + FormataNumero(resultado.alimento.carboidratos) + '</td>' +
                                     '<td id="lipideosAlimentoInformacao">' + FormataNumero(resultado.alimento.lipideos) + '</td>' +
                                '</tr > ';
                $("#resumoAlimento tbody").append(novaLinha);
            }
            else if (resultado.erro) {
                window.location.href = '/Erro/ErroGenerico';
            }
        },
        complete: function () {
            $('.custom-loader').hide();
            $('#btnCalcularAlimento').removeAttr('disabled');
        }
    });
});

$('#btnAdicionarRefeicao').on("click", function () {
    limpaErros();
    if ($('#resumoAlimento tr').length == 1) {
        $('#resumoAlimento').after('<span class="text-danger erros-formulario" id="erroAlimentoNaoBuscado">Nenhum alimento buscado para adicionar</span>');
        return;
    }

    var alimentoAdicionado = {
        IdLinhaAlimento: Math.floor(Math.random() * 100000),
        IdAlimentoAdicionado: $('#idInformacaoAlimento').val(),
        Nome:  $('#nomeAlimentoInformacao').html(),
        Quantidade: $('#quantidadeAlimentoInformacao').html(),
        Energia: $('#energiaAlimentoInformacao').html(),
        Proteina: $('#proteinaAlimentoInformacao').html(),
        Carboidratos: $('#carboidratosAlimentoInformacao').html(),
        Lipideos: $('#lipideosAlimentoInformacao').html(),
    };

    listaRefeicoesAdicionadas.push(alimentoAdicionado);

    var idLinhaRefeicao = alimentoAdicionado.IdLinhaAlimento;

    var novaLinha = '<tr id="' + idLinhaRefeicao + '" >' +
                         '<td><a href="#" onclick="RemoverLinha(' + idLinhaRefeicao + ')"><img src="/img/delete-ico.png" style="max-height:25px;max-width:25px;"></a></td>' +
                         '<td>' + alimentoAdicionado.Nome + '</td>' +
                         '<td>' + FormataNumero(alimentoAdicionado.Quantidade) + '</td>' +
                         '<td>' + FormataNumero(alimentoAdicionado.Energia) + '</td>' +
                         '<td>' + FormataNumero(alimentoAdicionado.Proteina) + '</td>' +
                         '<td>' + FormataNumero(alimentoAdicionado.Carboidratos) + '</td>' +
                         '<td>' + FormataNumero(alimentoAdicionado.Lipideos) + '</td>' +
                    '</tr > ';
    $("#Refeicao tbody").append(novaLinha);
    $('#linhaInformacaoAlimento').remove();
    CalculaResumoRefeicao();

});

function RemoverLinha(idLinhaRemover) {
    $('#' + idLinhaRemover).remove();

    listaRefeicoesAdicionadas = listaRefeicoesAdicionadas.filter(function (refeicao) {
        return refeicao.IdLinhaAlimento != idLinhaRemover;
    });
    
    CalculaResumoRefeicao();
}

function CalculaResumoRefeicao() {
    var totalQuantidade = 0;
    var totalEnergia = 0;
    var totalProteina = 0;
    var totalCarboidratos = 0;
    var totalLipideos = 0;

    listaRefeicoesAdicionadas.forEach((element) => {
        totalQuantidade += parseFloat(element.Quantidade);
        totalEnergia += parseFloat(element.Energia);
        totalProteina += parseFloat(element.Proteina);
        totalCarboidratos += parseFloat(element.Carboidratos);
        totalLipideos += parseFloat(element.Lipideos);
    });

    $('#linhaResumoRefeicao').remove();

    var novaLinha = '<tr id="linhaResumoRefeicao">' +
                         '<td>' + FormataNumero(totalQuantidade) + '</td>' +
                         '<td>' + FormataNumero(totalEnergia) + '</td>' +
                         '<td>' + FormataNumero(totalProteina) + '</td>' +
                         '<td>' + FormataNumero(totalCarboidratos) + '</td>' +
                         '<td>' + FormataNumero(totalLipideos) + '</td>' +
                    '</tr > ';
    $("#resumoRefeicao tbody").append(novaLinha);
}


$('#btnSalvar').on("click", function () {
    var refeicoesQuantidade = new Array();

    listaRefeicoesAdicionadas.forEach((element) => {
        var alimentoAdicionado = {
            InformacaoAlimentoId: element.IdAlimentoAdicionado,
            Quantidade: element.Quantidade.replace('.', ',')
        }
        refeicoesQuantidade.push(alimentoAdicionado);
    });

    $('.custom-loader').show();
    $('#btnSalvar').attr('disabled', 'disabled');
    $.ajax({
        type: 'POST',
        url: '/RegistrosRefeicoes/RegistraRefeicao',
        data: {
            ListaAlimentosAdicionados: refeicoesQuantidade, 
            nomeRefeicao: $('#Nome').val()
        },
        datatype: "JSON",
        ContentType: "application/json",
        success: (resultado) => {
            if (resultado.sucesso) {
                Swal.fire({
                    icon: 'success',
                    title: 'Cadastro Realizado',
                    text: 'Refeição Cadastrada com Sucesso',
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