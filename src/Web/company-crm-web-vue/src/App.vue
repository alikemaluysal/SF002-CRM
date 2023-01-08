<script setup>
import { onMounted } from 'vue'
import Navbar from './components/Navbar.vue'

onMounted(() => {
  // sayfa yüklendiğinde
})
</script>

<template>
  <Navbar />

  <div class="container">
    <router-view></router-view>
  </div>
</template>
