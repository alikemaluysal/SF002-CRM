<template>
	<div class="page-body">
		<div class="container-xl d-flex flex-column justify-content-center">
			<div class="empty">
				<div class="empty-img">
					<img src="/template/static/illustrations/undraw_printing_invoices_5r4r.svg" height="128" alt="">
				</div>
				<p class="empty-title">Welcome</p>
				<p class="empty-subtitle text-muted">
					Welcome to Company.CRM web application.
				</p>
			</div>


			<div id="chart-tasks-overview"></div>

		</div>
	</div>
</template>

<script setup>
import { ref, onMounted } from 'vue'

const chartData = ref();

onMounted(() => {

	axios.get('sale/chartData').then(response => {
		chartData.value = response.data.data

		window.ApexCharts && (new ApexCharts(document.getElementById('chart-tasks-overview'), {
			chart: {
				type: "bar",
				fontFamily: 'inherit',
				height: 320,
				parentHeightOffset: 0,
				toolbar: {
					show: false,
				},
				animations: {
					enabled: false
				},
			},
			plotOptions: {
				bar: {
					columnWidth: '50%',
				}
			},
			dataLabels: {
				enabled: true,
			},
			fill: {
				opacity: 1,
			},
			tooltip: {
				theme: 'dark'
			},
			grid: {
				padding: {
					top: -20,
					right: 0,
					left: -4,
					bottom: -4
				},
				strokeDashArray: 4,
			},
			series: [{
				name: "A",
				data: [44, 32]
			}],
			xaxis: {
				labels: {
					padding: 0,
				},
				tooltip: {
					enabled: false
				},
				axisBorder: {
					show: false,
				},
				categories: ['2022', '2023'],
			},
			yaxis: {
				labels: {
					padding: 4
				},
			},
			colors: [tabler.getColor("primary")],
			legend: {
				show: false,
			},
		})).render();

	})
})
</script>