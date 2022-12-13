import Vue from 'vue';
import VueRouter, { RouteConfig } from 'vue-router';
import Home from '../views/Home.vue';

Vue.use(VueRouter);

const routes: Array<RouteConfig> = [
  {
    path: '/',
    name: 'default',
    component: Home
  },
  {
    path: '/done',
    name: 'done',
    component: () => import('@/views/Done.vue')
  },
  {
    path: '/new',
    name: 'new',
    component: () => import('@/views/AddNew.vue')
  },
  {
    path: '/edit',
    name: 'edit',
    component: () => import('@/views/Edit.vue'),
    props: true
  }
];

const router = new VueRouter({
  routes
});

export default router;
