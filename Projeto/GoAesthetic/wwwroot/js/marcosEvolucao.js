
document.getElementById('Arquivo').addEventListener('change', function (e) {
    const preview = document.getElementById('preview');
    const file = e.target.files[0];

    if (file) {
        const fileExtension = file.name.split('.').pop().toLowerCase();

        if (['jpg', 'jpeg', 'png'].includes(fileExtension)) {
            const reader = new FileReader();

            reader.onload = function (e) {
                preview.src = e.target.result;
            };

            reader.readAsDataURL(file);
        } else {
            alert('Por favor, selecione um arquivo .jpg, .jpeg ou .png válido.');
            e.target.value = ''; // Limpa o campo de envio de arquivo
            preview.src = ''; // Remove a prévia
        }
    } else {
        preview.src = '';
    }
});
// Adicione este código ao seu arquivo marcosEvolucao.js
document.getElementById('Arquivo').addEventListener('change', function (e) {
    const preview = document.getElementById('preview');
    const file = e.target.files[0];

    if (file) {
        const fileExtension = file.name.split('.').pop().toLowerCase();

        if (['jpg', 'jpeg', 'png'].includes(fileExtension)) {
            const reader = new FileReader();

            reader.onload = function (e) {
                preview.src = e.target.result;
            };

            reader.readAsDataURL(file);
        } else {
            alert('Por favor, selecione um arquivo .jpg, .jpeg ou .png válido.');
            e.target.value = ''; // Limpa o campo de envio de arquivo
            preview.src = ''; // Remove a prévia
        }
    } else {
        preview.src = '';
    }
});


$('#btnEnviar').on("click", function () {
    var model = new FormData();

    model.append("Altura", $('#Altura').val().replace('.', ','));
    model.append("Peso", $('#Peso').val().replace('.', ','));
    var fileInput = $('#Arquivo')[0];
    var file = fileInput.files[0];
    model.append("Arquivo", file);

    $.ajax({
        type: 'POST',
        url: '/MarcosEvolucao/CadastraMarco',
        data: model,
        contentType: false,
        processData: false,
        success: (resultado) => {
            if (resultado.sucesso) {
                Swal.fire({
                    icon: 'success',
                    title: 'Marco Enviado',
                    text: 'Marco de Evolução Enviado com Sucesso!',
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
        }
    });
});
