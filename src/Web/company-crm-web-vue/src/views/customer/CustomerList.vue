<script setup>
import { ref, onMounted } from 'vue'
import Pagination from '../../components/Pagination.vue'
import CustomerModal from './CustomerModal.vue'
import { moment } from '@/plugins/datetime'

let appModal
const dataItem = ref()
const dataList = ref()
const dataMeta = ref()

onMounted(() => {
	fetchItems()
})

function fetchItems(page = 1) {
	axios.get('customer/getpaged', { params: { page, perPage: 10 } }).then(response => {
		dataList.value = response.data.data
		dataMeta.value = response.data.meta
	})
}

function showModal() {
	appModal = new bootstrap.Modal('#appModal', {
		keyboard: false
	})
	appModal.show();
}

function createItem() {
	dataItem.value = {}
	showModal();
}

function editItem(id) {
	axios.get('customer/' + id).then(response => {
		dataItem.value = response.data.data

		// input date elemanı sadece tarih verilerini gösterebildiği için tarih kısmını aldık 10 karakter olarak yyyy-mm-dd
		//dataItem.value.birthDate = dataItem.value.birthDate.substring(0, 10)
		dataItem.value.birthDate = new Date(dataItem.value.birthDate)

		showModal();
	})
}

function deleteItem(id) {
	swal.fire({
		icon: "question",
		title: "Are you sure?",
		text: "Are you sure you want to delete this item?",
		showCancelButton: true,
		confirmButtonText: "Delete",
		confirmButtonColor: '#ff0000'
	}).then(result => {
		if (result.value) {
			axios.delete("customer/" + id).then(res => {
				fetchItems()
			})
		}
	})
}

function itemSaved() {
	appModal.hide()
	fetchItems()
}
</script>
<template>
	<div class="page-body">
		<div class="container-xl">
			<div class="card">
				<div class="card-header">
					<h3 class="card-title">Customers</h3>
					<div class="btn-group ms-auto">
						<button class="btn btn-primary" @click="createItem">New</button>
						<button class="btn btn-primary" @click.prevent="fetchItems(1)">Refresh</button>
					</div>
				</div>
				<div class="table-responsive" v-if="dataList && dataList.length">
					<table class="table table-vcenter card-table">
						<thead>
							<tr>
								<th>#</th>
								<th>Company</th>
								<th>Gender</th>
								<th>Birth Date</th>
								<th>Birth Date</th>
								<th>Action</th>
							</tr>
						</thead>
						<tbody>
							<tr v-for="{ id, companyName, genderName, birthDate } in dataList" :key="id">
								<td>{{ id }}</td>
								<td>{{ companyName }}</td>
								<td>{{ genderName }}</td>
								<td>{{ moment(birthDate).format("DD.MM.YYYY") }}</td>
								<td>{{ moment(birthDate).fromNow() }}</td>
								<td>
									<div class="btn-list flex-nowrap">
										<button class="btn btn-success" @click="editItem(id)">
											Edit
										</button>

										<button class="btn btn-danger" @click="deleteItem(id)">
											Delete
										</button>
									</div>
								</td>
							</tr>
						</tbody>
					</table>
				</div>

				<div v-else>
					No records!
				</div>

				<pagination v-if="dataMeta" :meta="dataMeta" v-on:pageChange="fetchItems" />
			</div>

			<customer-modal :item="dataItem" @onSaved="itemSaved"></customer-modal>
		</div>
	</div>
</template>