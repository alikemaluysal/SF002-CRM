<template>
	<div class="page">
		<Navbar />
		<div class="page-wrapper">
			<router-view></router-view>
			<Footer />
		</div>
	</div>
</template>

<script setup>
import { onBeforeMount } from 'vue'
import { useRouter } from 'vue-router'
import session from '@/plugins/session'
import Navbar from '@/components/Navbar.vue'
import Footer from '@/components/Footer.vue'
const router = useRouter()

onBeforeMount(() => {
	// if (session.needsAuthentication()) {
	// 	window.localStorage.clear();
	// 	router.push("/auth/login");
	// }
})
</script>