import Vue from 'vue';
import VueRouter from 'vue-router';
import Login from '../views/Login.vue';
import AdminDashboard from '../views/AdminDashboard.vue';
import Reports from '../views/Reports.vue';
import FrontDashboard from '../views/FrontDashboard.vue';
import ReportDetail from '../views/ReportDetail.vue';
import store from '../store/index';

Vue.use(VueRouter);

const routes = [
  {
    path: '/',
    name: 'Front',
    component: FrontDashboard,
    meta: {
      requiresAuth: false,
    },
  },
  {
    path: '/admin',
    component: AdminDashboard,
    children: [
      {
        path: 'login',
        name: 'Login',
        component: Login,
        meta: {
          guest: true,
        },
      },
      {
        path: 'reports',
        name: 'Reports',
        component: Reports,
        meta: {
          requiresAuth: true,
        },
      },
      {
        path: 'report/:id',
        name: 'ReportDetail',
        component: ReportDetail,
        meta: {
          requiresAuth: true,
        },
      },
    ],
  },
];

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes,
});

router.beforeEach((to, from, next) => {
  if (to.matched.some((record) => record.meta.requiresAuth)) {
    if (store.getters.isAuthorized) {
      next();
      return;
    }
    next({ name: 'Login' });
    return;
  }

  if (to.matched.some((record) => record.meta.guest)) {
    if (store.getters.isAuthorized) {
      next({ name: 'Reports' });
      return;
    }
    next();
    return;
  }

  next();
});

export default router;
