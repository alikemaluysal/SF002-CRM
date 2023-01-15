import axios from 'axios'
import session from '@/plugins/session'

window.axios = axios

axios.defaults.baseURL = import.meta.env.VITE_API_URL || ''

// Request Interceptor
axios.interceptors.request.use((config) => {
	// Do something before request is sent
	if (!import.meta.env.PROD) console.log('[Request]', config.baseURL + config.url)

	const token = session.getSession()
	if (token) {
		config.headers["Authorization"] = `Bearer ${token.accessToken}`;
	}

	return config;
});

// Response Interceptor
axios.interceptors.response.use((response) => {
	if (!import.meta.env.PROD)
		console.log('[Response]', response);
	return response;
}, (error) => {
	const { config, response } = error;
	const originalRequest = config;
	const { status, statusText, data } = response;
	if (status === 401) {
		if (!originalRequest._retry) {
			originalRequest._retry = true;
			const refreshToken = localStorage.getItem("refreshtoken");
			var payload = {
				RefreshToken: refreshToken,
			};
			return axios.post("auth/refreshtoken", payload).then((response) => {
				window.localStorage.setItem("accessToken", response.data.data.accessToken);
				window.localStorage.setItem("refreshtoken", response.data.data.refreshToken);
				axios.defaults.headers.common["Authorization"] = "Bearer " + response.data.data.accessToken;
				originalRequest.headers["Authorization"] = "Bearer " + response.data.data.accessToken;
				return axios(originalRequest);
			});
		}
		else {
			router.push({ name: 'login' });
		}
	}

	if (status >= 500) {
		toastr.error(data.message, 'Hata');
		swal.fire({
			icon: 'error',
			title: 'Error',
			text: data.message,
			reverseButtons: true
		})
	}

	return Promise.reject(error);
});