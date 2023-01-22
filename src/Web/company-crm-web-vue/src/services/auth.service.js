import session from '@/plugins/session'
import router from '@/router'

export default {
	Logout() {
		session.clearSession();
		router.push({ name: 'Login' });
	}
}