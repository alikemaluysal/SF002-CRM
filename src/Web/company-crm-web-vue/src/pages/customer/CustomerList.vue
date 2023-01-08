<script setup>
import { ref, onMounted } from 'vue';
const dataList = ref([]);

onMounted(() => {
	fetchItems();
})

function fetchItems(page = 1) {
	axios.get('customer/getpaged', { params: { page, perPage: 10 } }).then(response => {
		dataList.value = response.data.data;
	})
}
</script>
<template>
	<div class="btn-group float-end">
		<button class="btn btn-primary" @click="createItem">Yeni</button>
		<button class="btn btn-primary" @click.prevent="fetchItems(1)">Yenile</button>
	</div>

	<h1>Customer List</h1>
	<table class="table table-bordered">
		<thead>
			<tr>
				<th>#</th>
				<th>Company</th>
				<th>Gender</th>
				<th></th>
			</tr>
		</thead>
		<tbody>
			<tr v-for="{ id, companyName, genderName } in dataList" :key="id">
				<td>{{ id }}</td>
				<td>{{ companyName }}</td>
				<td>{{ genderName }}</td>
				<td>
					<button class="btn btn-success btn-sm me-2" @click="editItem(id)">
						Düzenle
					</button>
					<button class="btn btn-danger btn-sm" @click="deleteItem(id)">Sil</button>
				</td>
			</tr>
		</tbody>
	</table>
</template>