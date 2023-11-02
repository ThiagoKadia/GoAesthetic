function informaErros(listaErros) {
    $('.erros-formulario').remove();
    listaErros.forEach((element) => {
        $('#' + element.id).after('<span class="text-danger erros-formulario" >' + element.erro + '</span>');
    })
}