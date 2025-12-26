<template>
  <section class="page">
    <div class="page-header">
      <h1>Companies Edit</h1>

      <div class="header-actions">
        <button class="btn btn-secondary" @click="onBack">← Back</button>
      </div>
    </div>
  </section>
</template>

<script setup lang="ts">
import { computed, onMounted, onUnmounted, reactive, ref } from 'vue'
import { useRoute, useRouter, onBeforeRouteLeave } from 'vue-router';
import { getCompanies, getCompanyById, createCompany, updateCompany } from '@/services/api';
import Companies from '@/views/Companies/Companies'
import { isAwaitKeyword } from 'typescript';

const router = useRouter()
const route = useRoute()
const company = reactive<Companies>(new Companies())

const errorMessage = ref('')
const originalSnapshot = ref<string>('')
const isNew = computed(() => route.params.id?.toString() === '0')
const snapshot = () => JSON.stringify(company)
const isDirty = computed(() => snapshot() !== originalSnapshot.value)

const loadCompanies = async () => {
  if (isNew.value) {
    originalSnapshot.value = snapshot()
    return
  }

  const id = Number(route.params.id)

  const { data } = await getCompanyById(id)

  Object.assign(company, data)

  originalSnapshot.value = snapshot()
}

const onSave = async () => {
  console.log('1. Iniciando onSave')
  errorMessage.value = ''

  // Validação de campos obrigatórios
  if (!company.name) {
    console.log('Erro: Nome incompleto')
    errorMessage.value = 'Erro: Nome é obrigatório'
    return
  }

  // Envio para a API
  console.log('2. Validações passaram. Enviando para API...')
  try {
    if (isNew.value) {
      console.log('Criando nova company')
      const { data } = await createCompany(company)
      Object.assign(company, data)
    } else {
      console.log('Atualizando Company existente (ID ' + company.id + ')...')
      await updateCompany(company.id, company)
    }

    console.log('Salvo com sucesso!')

    originalSnapshot.value = snapshot()

    router.push({ name: 'companies-list' })
  } catch (error) {
    console.error('Erro na API:', error)
    errorMessage.value = 'Ocorreu um erro. Verifique o console'
  }
}

const confirmDiscard = ref(false)
const showOnBackPopup = ref(false)

const onBack = () => {
  if (isDirty.value) {
    showOnBackPopup.value = true
  } else {
    router.push({ name: 'companies-list' })
  }
}

const confirmExit = () => {
  showOnBackPopup.value = false
  confirmDiscard.value = true
  router.push({name: 'companies-list'})
}

onBeforeRouteLeave((to, from, next) => {
  if (isDirty.value) {
    if (confirmDiscard.value) {
      next()
    } else {
      next(false)
    }
  } else {
    next()
  }
})

onUnmounted(async () => {
  await loadCompanies()
})
</script>