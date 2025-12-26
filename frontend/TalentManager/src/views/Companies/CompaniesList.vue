<template>
  <section class="page">
    <div class="page-header">
      <h1>Companies List</h1>
    </div>

    <div class="filters-box">
      <div v-for="f in filtersConfig" :key="f.field" class="filter-item">
        <button
          v-if="activeFilter !== f.field"
          class="filter-btn"
          @click="activateFilter(f.field)"
        >
          {{ f.label }}
        </button>
        <input 
          v-else
          v-model="filters[f.field]"
          class="filter-input"
          :placeholder="`Filter by ${f.label}`"
          @keyup.enter="deactivateFilter"
          @blur="deactivateFilter">
      </div>
    </div>

    <div class="table-card">
      <table class="table">
        <thead>
          <tr>
            <th></th>
            <th>Id</th>
            <th>Name</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="c in filteredCompanies" :key="c.id">
            <td class="table-actions">
              <button class="icon-btn" @click="edit(c.id)">✏️</button>
              <button class="icon-btn" @click="removeClick(c.id, c.name)">🗑️</button>
            </td>

            <td>{{ c.id }}</td>
            <td>{{ c.name }}</td>
          </tr>
          
          <tr v-if="!loading && filteredCompanies.length === 0">
            <td colspan="3" class="empty">No records found.</td>
          </tr>

          <tr v-if="loading">
            <td colspan="3" class="empty">Loading...</td>
          </tr>
        </tbody>
      </table>
    </div>
    
    <div v-if="showDeletePopup" class="delete-group">
      <div class="delete-card">
        <h2>Delete</h2>
        <p>Delete {{ companyDeletName }}'s data?</p>

        <div class="delete-actions">
          <button class="btn btn-secondary" @click="showDeletePopup = false">
            Cancel
          </button>
          <button class="btn btn-warning" @click="remove">
            Delete
          </button>
        </div>
      </div>
    </div>
  </section>
</template>

<script setup lang="ts">
import {
  computed,
  onMounted,
  onBeforeMount,
  onUpdated,
  onBeforeUnmount,
  onUnmounted,
  reactive,
  ref,
  watch,
} from 'vue'
import { useRouter } from 'vue-router';
import { deleteCompany, getCompanies } from '@/services/api'
import type Companies from '@/views/Companies/Companies' 

console.log('[CompaniesList] setup executado')

const router = useRouter()
const companies = ref<Companies[]>([])
const loading = ref(false)

const filtersConfig = [
  { field: 'id', label: 'Id'},
  { field: 'name', label: 'Name'},
] as const

type CompaniesFilterField = (typeof filtersConfig)[number]['field']

const filters = reactive<Record<CompaniesFilterField, string>>({
  id: '',
  name: '',
})

const activeFilter = ref<CompaniesFilterField | null>(null)

const loadCompanies = async () => {
  console.log('[CompaniesList] loadCompanies() chamado')
  loading.value = true

  try {
    const { data } = await getCompanies()
    console.log('[CompaniesList] Dados recebidos da API', data)
    companies.value = data
  } catch (error) {
    console.error('Erro ao carregar empresas', error)
  } finally {
    loading.value = false
  }
}

onBeforeMount(() => {
  console.log('[CompaniesList] beforeMount → DOM ainda não foi renderizado')
})

onMounted(() => {
  console.log('[CountriesList] mounted → componente montado, chamando loadCompanies()')
  loadCompanies()
})

const activateFilter = (field: CompaniesFilterField) => {
  activeFilter.value = field
  console.log('[CountriesList] activateFilter → filtro ativo:', field)
}

const deactivateFilter = () => {
  console.log('[CountriesList] deactivateFilter → removendo filtro ativo')
  activeFilter.value = null
}

const filteredCompanies = computed(() => 
  companies.value.filter((c) =>
    (Object.entries(filters) as [CompaniesFilterField, string][]).every(
      ([field, value]) => {
        if (!value) return true

        const raw = c[field]
        if (raw === null || raw === undefined) return false

        return String(raw).toLowerCase().includes(value.toLowerCase())
      },
    ),
  ),
)

onUpdated(() => {
  console.log('[CompaniesList] update → DOM atualizado com novos dados/filtros')
})

watch(
  () => ({ ...filters }),
  (novo, antigo) => {
    console.log('[CompaniesList] filtros alterados', {antigo, novo})
  },
  { deep: true },
)

onBeforeUnmount(() => {
  console.log('[CompaniesList] beforeUnmount → componente CompaniesList será destruído')
})

onUnmounted(() => {
  console.log('[CompaniesList] unmonted → componente CompaniesList foi destruído')
})

const edit = (id: number) => {
  console.log('[CompaniesList] edit → navegando para edição com id =', id)
  router.push({ name: 'companies-edit', params: { id } })
}

const showDeletePopup = ref(false)
const companyDeletId = ref(0)
const companyDeletName = ref<string | undefined>('')

const removeClick = (id: number, name: string | undefined) => {
  companyDeletId.value = id
  companyDeletName.value = name
  showDeletePopup.value = true
}

const remove = async () => {
  console.log('[CompaniesList] remove → tentativa de remover id =', companyDeletId.value)
  await deleteCompany(companyDeletId.value) 
  
  console.log('[CompaniesList] remove → registro deletado, recarregando lista')
  showDeletePopup.value = false
  await loadCompanies()
}
</script>

