import axios from 'axios'

const api = axios.create({
  baseURL: 'https://localhost:5001/api',
})

export const getDowntimesByForkliftId = (forkliftId) => api.get(`forkliftDowntimes/${forkliftId}`)
export const getForkliftDowntimeById = (id) => api.get(`forkliftDowntimes/forkliftDowntime/${id}`)
export const createDowntime = (data) => api.post('/forkliftDowntimes', data)
export const updateDowntime = (id, data) => api.put(`/forkliftDowntimes/${id}`, data)
export const deleteDowntime = (id) => api.delete(`/forkliftDowntimes/${id}`)
