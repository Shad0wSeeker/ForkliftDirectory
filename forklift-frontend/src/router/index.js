import { createRouter, createWebHistory } from 'vue-router'
import ForkliftDirectoryView from '@/views/ForkliftDirectoryView.vue'

const routes = [
  {
    path: '/forklifts',
    name: 'Forklifts',
    component: ForkliftDirectoryView,
  },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
})

export default router
