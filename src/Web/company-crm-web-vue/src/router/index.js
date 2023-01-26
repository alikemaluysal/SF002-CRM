import { createRouter, createWebHistory } from 'vue-router'
import HomePage from '../views/HomePage.vue'
import CustomerList from '../views/customer/CustomerList.vue'
import TaskStatusList from '../views/taskStatus/TaskStatusList.vue'
import NotificationList from '../views/notification/NotificationList.vue'
import UserAddressList from '../views/userAddress/UserAddressList.vue'
import NotFound from '../views/NotFound.vue'
import session from '../plugins/session'
import Login from '../views/auth/Login.vue'
import Register from '../views/auth/Register.vue'
import MasterLayout from '../views/_layouts/MasterLayout.vue'
import BasicLayout from '../views/_layouts/BasicLayout.vue'
import UserImport from '../views/user/UserImport.vue'

const routes = [
	{
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
	},
	{
		path: '/auth',
		name: 'auth',
		redirect: '/auth/login',
		component: BasicLayout,
		children: [
			{ path: '/auth/login', name: 'Login', component: Login },
			{ path: '/auth/register', name: 'Register', component: Register }
		]
	},
	{ path: '/:pathMatch(.*)*', name: 'not-found', component: NotFound }
]

const router = createRouter({
	history: createWebHistory(import.meta.env.BASE_URL),
	routes
})

router.beforeEach((to, from) => {
	if (
		to.name !== 'Login' &&
		!session.isLoggedIn() &&
		to.matched.some((record) => record.meta.requiresAuth)
	) {
		return {
			name: 'Login',
			// save the location we were at to come back later
			query: { redirect: to.fullPath }
		}
	}
})

export default router
