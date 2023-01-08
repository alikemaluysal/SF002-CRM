<script setup>
import { ref } from 'vue'
const appName = ref('CRM Admin')
const version = ref('1.0')
</script>

<template>
	<nav class="navbar navbar-expand-lg bg-body-tertiary">
		<div class="container">
			<a class="navbar-brand" href="#">
				<img src="../assets/logo.svg">
				{{ appName }} {{ version }}
			</a>
			<button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
				<span class="navbar-toggler-icon"></span>
			</button>
			<div class="collapse navbar-collapse" id="navbarSupportedContent">
				<ul class="navbar-nav me-auto mb-2 mb-lg-0">
					<li class="nav-item">
						<router-link class="nav-link" aria-current="page" to="/">Home</router-link>
					</li>
					<li class="nav-item dropdown">
						<a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
							Customers
						</a>
						<ul class="dropdown-menu">
							<li>
								<router-link class="dropdown-item" to="/customer/list">Customer List</router-link>
							</li>
						</ul>
					</li>
				</ul>
			</div>
		</div>
	</nav>
</template>

<style scoped>
.navbar-brand img {
	height: 24px;
}
</style>
