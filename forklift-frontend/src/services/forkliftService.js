import axios from 'axios'

const api = axios.create({
  baseURL: 'https://localhost:5001/api',
})

export const getAllForklifts = () => api.get('/forklifts')
export const searchForklifts = (number) => api.get(`/forklifts/search?number=${number}`)
export const createForklift = (data) => api.post('/forklifts', data)
export const updateForklift = (id, data) => api.put(`/forklifts/${id}`, data)
export const deleteForklift = (id) => api.delete(`/forklifts/${id}`)
