document.addEventListener('DOMContentLoaded', function () {
    let currentChart;

    function updateChartType() {
        const chartType = document.getElementById('chartType').value;

        $('.custom-loader').show();
        $('#chartType').attr('disabled', 'disabled');
        $.ajax({
            type: 'POST',
            url: '/Relatorios/MontaRelatorio',
            data: {
                TipoGrafico: chartType
            },
            datatype: "JSON",
            ContentType: "application/json",
            success: (resultado) => {
                if (resultado.sucesso) {
                    var dadosRelatorio = {
                        labels: new Array(),
                        datasets: new Array()
                    };

                    resultado.labels.forEach((elemento) => {
                        dadosRelatorio.labels.push(elemento);
                    });

                    resultado.datasets.forEach((elemento) => {
                        dadosRelatorio.datasets.push(elemento);
                    });

                    updateChart(dadosRelatorio);
                }
                else if (resultado.erro) {
                    window.location.href = '/Erro/ErroGenerico';
                }
            },
            complete: function () {
                $('.custom-loader').hide();
                $('#chartType').removeAttr('disabled');
            }
        });
    }

    function updateChart(data) {
        const ctx = document.getElementById('caloriesChart').getContext('2d');

        if (currentChart) {
            currentChart.destroy();
        }

        currentChart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: data.labels,
                datasets: data.datasets,
            },
            options: {
                scales: {
                    y: {
                        beginAtZero: true,
                    },
                },
                plugins: {
                    legend: {
                        labels: {
                            color: '#F9F5EC',
                        },
                    },
                },
            },
        });
    }

    document.getElementById('chartType').addEventListener('change', updateChartType);
    updateChartType();
});
