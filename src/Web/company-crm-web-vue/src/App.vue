<script setup>
import { onMounted } from 'vue'
import Navbar from './components/Navbar.vue'
import Footer from './components/Footer.vue'

onMounted(() => {
  // sayfa yüklendiğinde
})
</script>

<template>

  <div class="page">
    <Navbar />
    <div class="page-wrapper">
      <router-view></router-view>
      <Footer />
    </div>
  </div>

</template>
