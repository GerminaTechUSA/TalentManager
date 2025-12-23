import { createRouter, createWebHistory } from "vue-router";

// Rotas principais

// Companies
import CompaniesList from "@/views/Companies/CompaniesList.vue";
import CompaniesEdit from "@/views/Companies/CompaniesEdit.vue";

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        { path: '/', name: 'home', component: HomeView },
    ]
})