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
	<div class="page-body">
		<div class="container-xl">

			<div class="card">
				<div class="card-header">
					<h3 class="card-title">Customers</h3>
					<div class="btn-group ms-auto">
						<button class="btn btn-primary" @click="createItem">Yeni</button>
						<button class="btn btn-primary" @click.prevent="fetchItems(1)">Yenile</button>
					</div>
				</div>
				<div class="table-responsive">
					<table class="table table-vcenter card-table">
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
									<div class="btn-list flex-nowrap">
										<a href="#" class="btn btn-success" @click="editItem(id)">
											Edit
										</a>

										<a href="#" class="btn btn-danger" @click="deleteItem(id)">
											Delete
										</a>
									</div>
								</td>
							</tr>
						</tbody>
					</table>
				</div>
			</div>
		</div>
	</div>
</template>