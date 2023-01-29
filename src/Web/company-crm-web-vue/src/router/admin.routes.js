import MasterLayout from '../views/_layouts/MasterLayout.vue'
import CustomerList from '../views/customer/CustomerList.vue'
import HomePage from '../views/HomePage.vue'
import UserImport from '../views/user/UserImport.vue'

export default {
	path: '/',
	name: 'admin',
	component: MasterLayout,
	meta: { requiresAuth: true },
	children: [
		{ path: '/', name: 'home', component: HomePage },
		{ path: '/customer/list', component: CustomerList },
		{ path: '/user/import', component: UserImport },
		{ path: '/notification/list', component: NotificationList, meta: { requiresAuth: true } },
		{ path: '/user-address/list', component: UserAddressList, meta: { requiresAuth: true } },
		{ path: '/taskStatus/list', component: TaskStatusList, meta: { requiresAuth: true } },
		{
			path: '/about',
			name: 'about',
			// route level code-splitting
			// this generates a separate chunk (About.[hash].js) for this route
			// which is lazy-loaded when the route is visited.
			component: () => import('../views/AboutPage.vue')
		}
	]
}