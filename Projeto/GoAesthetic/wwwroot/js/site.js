function FormataNumero(numero) {
    return (Math.round(numero * 100) / 100).toFixed(2);
}

document.addEventListener("DOMContentLoaded", function () {
    const logoutButton = document.querySelector(".logout-button");

    if (logoutButton) {
        logoutButton.addEventListener("click", function (e) {
            e.preventDefault(); // Evitar o comportamento padrão do link

            Swal.fire({
                title: "Encerrar Sessão",
                text: "Tem certeza que deseja encerrar a sessão?",
                icon: "question",
                showCancelButton: true,
                confirmButtonColor: "#d33",
                cancelButtonColor: "#3085d6",
                confirmButtonText: "Sim, encerrar",
                cancelButtonText: "Cancelar",
            }).then((result) => {
                if (result.isConfirmed) {
                    // Redirecione o usuário para a página de logout
                    window.location.href = "/Login";
                }
            });
        });
    }
});

