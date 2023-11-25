document.addEventListener('DOMContentLoaded', function () {
    const monthData = {
        labels: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho'],
        datasets: [
            {
                label: 'Proteína (g)',
                data: [120, 130, 110, 140, 125, 135],
                backgroundColor: 'rgba(255, 255, 255, 0)',
                borderColor: 'rgba(54, 162, 235, 1)',
                borderWidth: 2,
            },
            {
                label: 'Carboidrato (g)',
                data: [250, 270, 300, 280, 290, 260],
                backgroundColor: 'rgba(255, 255, 255, 0)',
                borderColor: 'rgba(255, 206, 86, 1)',
                borderWidth: 2,
            },
            {
                label: 'Gordura (g)',
                data: [80, 75, 85, 90, 70, 95],
                backgroundColor: 'rgba(255, 255, 255, 0)',
                borderColor: 'rgba(75, 192, 192, 1)',
                borderWidth: 2,
            },
        ],
    };

    const weekdayData = {
        labels: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb'],
        datasets: [
            {
                label: 'Proteína (g)',
                data: [120, 130, 110, 140, 125, 135, 115],
                backgroundColor: 'rgba(255, 255, 255, 0)',
                borderColor: 'rgba(54, 162, 235, 1)',
                borderWidth: 2,
            },
            {
                label: 'Carboidrato (g)',
                data: [250, 270, 300, 280, 290, 260, 275],
                backgroundColor: 'rgba(255, 255, 255, 0)',
                borderColor: 'rgba(255, 206, 86, 1)',
                borderWidth: 2,
            },
            {
                label: 'Gordura (g)',
                data: [80, 75, 85, 90, 70, 95, 88],
                backgroundColor: 'rgba(255, 255, 255, 0)',
                borderColor: 'rgba(75, 192, 192, 1)',
                borderWidth: 2,
            },
        ],
    };

    let currentChart;

    function updateChartType() {
        const chartType = document.getElementById('chartType').value;

        if (chartType === 'month') {
            updateChart(monthData);
        } else if (chartType === 'weekday') {
            updateChart(weekdayData);
        }
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
