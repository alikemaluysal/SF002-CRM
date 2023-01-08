<script setup>
import { ref, onMounted } from 'vue';
import axios from 'axios';
const customerList = ref([]);
onMounted(() => {
	axios.get('https://localhost:7177/api/customer')
		.then(function (response) {
			customerList.value = response.data;
		})
})
</script>
<template>
	<h1>Customer List</h1>
	<table class="table table-bordered">
		<thead>
			<tr>
				<th>companyName</th>
			</tr>
		</thead>
		<tbody>
			<tr v-for="customer of customerList">
				<td>{{ customer.companyName }}</td>
			</tr>
		</tbody>
	</table>
</template>