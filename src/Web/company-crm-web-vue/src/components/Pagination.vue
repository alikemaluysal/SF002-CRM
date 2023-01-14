<template>
    <nav>
        <ul class="pagination">
            <li class="page-item" :class="{ 'disabled': meta.currentPage === 1 }">
                <button class="page-link" @click="pageChange(meta.currentPage - 1)">
                    &laquo;
                </button>
            </li>
            <li class="page-item" :class="{ 'active': meta.currentPage === page }" v-for="page in meta.lastPage" :key="page">
                <button class="page-link" @click="pageChange(page)">
                    {{ page }}
                </button>
            </li>
            <li class="page-item" :class="{ 'disabled': meta.currentPage === meta.lastPage }">
                <button class="page-link" @click="pageChange(meta.currentPage + 1)">
                    &raquo;
                </button>
            </li>
        </ul>
    </nav>
</template>

<script setup>
defineProps(['meta'])
const emit = defineEmits(['pageChange'])
function pageChange(page) {
    emit('pageChange', page);
}
</script>