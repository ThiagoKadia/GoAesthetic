
document.getElementById('foto').addEventListener('change', function (e) {
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
document.getElementById('foto').addEventListener('change', function (e) {
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
