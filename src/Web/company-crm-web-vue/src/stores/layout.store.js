import { ref } from 'vue'
import { defineStore } from 'pinia'

export const useLayoutStore = defineStore('layout', () => {
	// state
	const isPageLoading = ref(false)
	const isTableLoading = ref(false)

	// actions
	function showPageLoading() {
		isPageLoading.value = true
	}

	function hidePageLoading() {
		isPageLoading.value = false
	}

	function showTableLoading() {
		isTableLoading.value = true
	}

	function hideTableLoading() {
		isTableLoading.value = false
	}

	return {
		isPageLoading,
		showPageLoading,
		hidePageLoading,
		isTableLoading,
		showTableLoading,
		hideTableLoading
	}
})
