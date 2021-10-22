import Vue from 'vue';
import VueRouter from 'vue-router';
import Login from '../views/Login.vue';
import AdminDashboard from '../views/AdminDashboard.vue';
import Reports from '../views/Reports.vue';
import FrontDashboard from '../views/FrontDashboard.vue';
import ReportDetail from '../views/ReportDetail.vue';

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
    name: 'Admin',
    component: AdminDashboard,
    children: [
      {
        path: 'login',
        component: Login,
      },
      {
        path: 'reports',
        name: 'Reports',
        component: Reports,
      },
      {
        path: 'report/:id',
        name: 'ReportDetail',
        component: ReportDetail,
      },
    ],
  },
];

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes,
});

export default router;
