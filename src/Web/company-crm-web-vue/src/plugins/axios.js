import axios from 'axios'

window.axios = axios

axios.defaults.baseURL = import.meta.env.VITE_API_URL || ''
