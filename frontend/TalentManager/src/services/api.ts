import axios from 'axios'

// IMPORTANDO DA NOVA ESTRUTURA
import Companies from '@/views/Companies/Companies'

const api = axios.create({
  baseURL: 'https://localhost:7200/api'
})

// ---- COMPANIES ----
export const getCompanies = () => api.get<Companies[]>('/companies')
export const getCompanyById = (id: number | string) =>
  api.get<Companies>(`/companies/${id}`)
export const createCompany = (payload: Companies) =>
  api.post<Companies>(`/companies`, payload)
export const updateCompany = (id: number | string, payload: Companies) => 
  api.put<void>(`/companies/${id}`, payload)
export const deleteCompany = (id: number | string) =>
  api.delete<void>(`/companies/${id}`)

export default api