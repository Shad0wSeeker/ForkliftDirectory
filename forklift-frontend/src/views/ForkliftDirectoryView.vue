<!-- views/ForkliftDirectoryView.vue -->
<template>
  <div class="forklift-directory">
    <h2>Справочник погрузчиков</h2>

    <SearchBar @search="handleSearch" @reset="resetFilter" />
    <div>
      <button class="add-button" @click="startAdd">➕ Добавить</button>
    </div>

    <div class="main-content">
      <div class="left">
        <ForkliftTable :forklifts="forklifts" @edit="startEdit" @delete="confirmDelete" @select="handleSelect" />
      </div>
      <div class="right" v-if="selectedForklift">
        <div class="downtime-section">
          <button class="add-button" @click="startAddDowntime">➕ Добавить</button>
          <DowntimeTable
            :downtimes="downtimes"
            :forklift="selectedForklift"
            @add="createDowntime"
            @edit="startEditDowntime"
            @delete="confirmDeleteDowntime" />
        </div>
      </div>
    </div>

    <ForkliftForm v-if="editing" :form="form" :isNew="isNew" @submit="save" @cancel="cancelEdit" />
    <DowntimeForm
      v-if="editingDowntime"
      :downtime="downtimeForm"
      :isNew="isNewDowntime"
      @submit="saveDowntime"
      @cancel="cancelDowntimeEdit" />
  </div>
</template>

<script>
import { ref, onMounted } from 'vue'
import {
  getAllForklifts,
  searchForklifts,
  createForklift,
  updateForklift,
  deleteForklift,
} from '@/services/forkliftService'

import DowntimeForm from '@/components/DowntimeForm.vue'
import { createDowntime, updateDowntime, deleteDowntime, getDowntimesByForkliftId } from '@/services/downtimeService'

import SearchBar from '@/components/SearchBar.vue'
import ForkliftTable from '@/components/ForkliftTable.vue'
import ForkliftForm from '@/components/ForkliftForm.vue'
import DowntimeTable from '@/components/DowntimeTable.vue'

export default {
  components: { SearchBar, ForkliftTable, ForkliftForm, DowntimeTable, DowntimeForm },
  setup() {
    const forklifts = ref([])
    const downtimes = ref([])
    const selectedForklift = ref(null)
    const editing = ref(false)
    const isNew = ref(false)
    const form = ref({
      brand: '',
      number: '',
      loadCapacity: 0,
      updatedBy: '',
      isActive: true,
    })
    const downtimeForm = ref(null)
    const isNewDowntime = ref(false)
    const editingDowntime = ref(false)

    const loadAll = async () => {
      const res = await getAllForklifts()
      forklifts.value = res.data
    }

    const handleSearch = async (term) => {
      if (!term.trim()) {
        await loadAll()
      } else {
        const res = await searchForklifts(term)
        forklifts.value = res.data
      }
    }

    const resetFilter = loadAll

    const startAdd = () => {
      editing.value = true
      isNew.value = true
      form.value = {
        brand: '',
        number: '',
        loadCapacity: 0,
        updatedBy: '',
        isActive: true,
      }
    }

    const startEdit = (forklift) => {
      editing.value = true
      isNew.value = false
      form.value = { ...forklift }
    }

    const cancelEdit = () => {
      if (confirm('Не сохранять изменения?')) {
        editing.value = false
      }
    }

    const save = async (data) => {
      if (isNew.value) {
        await createForklift(data)
      } else {
        await updateForklift(data.id, data)
      }
      editing.value = false
      await loadAll()
    }

    const confirmDelete = async (item) => {
      if (confirm('Удалить погрузчик?')) {
        try {
          await deleteForklift(item.id)
          await loadAll()
        } catch {
          alert('Невозможно удалить: возможно, есть зарегистрированные простои.')
        }
      }
    }

    const handleSelect = async (forklift) => {
      if (selectedForklift.value && selectedForklift.value.id === forklift.id) {
        selectedForklift.value = null
        downtimes.value = []
        return
      }

      selectedForklift.value = forklift
      const res = await getDowntimesByForkliftId(forklift.id)
      downtimes.value = res.data
    }

    onMounted(loadAll)

    const startAddDowntime = () => {
      downtimeForm.value = {
        forkliftId: selectedForklift.value.id,
        description: '',
        startTime: new Date().toISOString().slice(0, 16),
        endTime: null,
      }
      isNewDowntime.value = true
      editingDowntime.value = true
    }

    const startEditDowntime = (downtime) => {
      downtimeForm.value = { ...downtime }
      isNewDowntime.value = false
      editingDowntime.value = true
    }

    const cancelDowntimeEdit = () => {
      if (confirm('Не сохранять изменения?')) {
        editingDowntime.value = false
      }
    }

    const saveDowntime = async (data) => {
      if (isNewDowntime.value) {
        await createDowntime(data)
      } else {
        await updateDowntime(data.id, data)
      }
      editingDowntime.value = false
      const res = await getDowntimesByForkliftId(selectedForklift.value.id)
      downtimes.value = res.data
    }

    const confirmDeleteDowntime = async (downtime) => {
      if (confirm('Удалить информацию о простое? Вы уверены?')) {
        await deleteDowntime(downtime.id)
        const res = await getDowntimesByForkliftId(selectedForklift.value.id)
        downtimes.value = res.data
      }
    }

    return {
      forklifts,
      downtimes,
      selectedForklift,
      editing,
      isNew,
      form,
      handleSearch,
      resetFilter,
      startAdd,
      startEdit,
      cancelEdit,
      save,
      confirmDelete,
      handleSelect,
      downtimeForm,
      isNewDowntime,
      editingDowntime,
      startAddDowntime,
      startEditDowntime,
      cancelDowntimeEdit,
      saveDowntime,
      confirmDeleteDowntime,
    }
  },
}
</script>

<style scoped>
.forklift-directory {
  padding: 20px;
  max-width: 1400px; /* Увеличим общую ширину */
  margin: 0 auto;
  height: calc(100vh - 40px);
  display: flex;
  flex-direction: column;
}

.main-content {
  display: flex;
  gap: 30px; /* Увеличим промежуток */
  margin-top: 20px;
  align-items: flex-start;
}

.left {
  flex: 1;
  min-width: 0;
  overflow-x: auto;
  max-height: 70vh;
  overflow-y: auto;
}

.right {
  flex: 1;
  min-width: 200px;
  max-height: 70vh;
  overflow-y: auto;
}

.downtime-section {
  width: 100%;
  background-color: #f5f5f5;
  padding: 15px;
  border-radius: 8px;
  border: 1px solid #e0e0e0;
  box-sizing: border-box;
}

.add-button {
  padding: 8px 16px;
  background-color: #b51212;
  color: white;
  border: none;
  border-radius: 6px;
  cursor: pointer;
  font-size: 14px;
  margin-bottom: 15px;
  white-space: nowrap;
}

.add-button:hover {
  background-color: #9a0f0f;
}
</style>
