import { createRouter, createWebHistory } from 'vue-router'
import HomePage from '../views/HomePage.vue'
import CustomerList from '../views/customer/CustomerList.vue'
import NotFound from '../views/NotFound.vue'
import session from '../plugins/session'
import Login from '../views/auth/Login.vue'
import Register from '../views/auth/Register.vue'
import MasterLayout from '../views/_layouts/MasterLayout.vue'
import BasicLayout from '../views/_layouts/BasicLayout.vue'

const routes = [
  {
    path: "/",
    name: "admin",
    component: MasterLayout,
    children: [
      { path: '/', name: 'home', component: HomePage },
      { path: '/customer/list', component: CustomerList, meta: { requiresAuth: true } },
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
    path: "/auth",
    name: "auth",
    redirect: "/auth/login",
    component: BasicLayout,
    children: [
      { path: "/auth/login", name: "Login", component: Login },
      { path: "/auth/register", name: "Register", component: Register }
    ]
  },
  { path: '/:pathMatch(.*)*', name: 'not-found', component: NotFound },
]

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes
})

router.beforeEach((to, from) => {
  /*
  /// TODO: Bu kısım geliştirilecek.
  if (to.matched.some(record => record.meta.requiresAuth) && !session.isLoggedIn() && to.name !== 'Login') {
    return {
      name: 'Login',
      // save the location we were at to come back later
      query: { redirect: to.fullPath },
    }
  }
  */
})

export default router
