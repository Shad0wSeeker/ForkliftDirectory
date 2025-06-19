<template>
  <div class="modal">
    <div class="modal-content">
      <h3>{{ isNew ? 'Регистрация инцидента' : 'Редактирование инцидента' }}</h3>
      <form @submit.prevent="submitForm">
        <div class="form-row">
          <label>Начало:</label>
          <input type="datetime-local" v-model="formData.startTime" required />
        </div>

        <div class="form-row">
          <label>Окончание:</label>
          <input type="datetime-local" v-model="formData.endTime" />
        </div>

        <div class="description-section">
          <h4>Описание инцидента</h4>
          <textarea v-model="formData.description" placeholder="Например: поломка, техобслуживание..." />
        </div>

        <div class="buttons">
          <button type="submit">Сохранить</button>
          <button type="button" @click="$emit('cancel')">Выход</button>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    downtime: Object,
    isNew: Boolean,
  },
  emits: ['submit', 'cancel'],
  data() {
    return {
      formData: {
        startTime: '',
        endTime: '',
        description: '',
      },
    }
  },
  mounted() {
    if (this.isNew) {
      const now = new Date().toISOString().slice(0, 16)
      this.formData.startTime = now
    }

    if (this.downtime) {
      this.formData = {
        startTime: this.downtime.startTime?.slice(0, 16) || '',
        endTime: this.downtime.endTime?.slice(0, 16) || '',
        description: this.downtime.description || '',
      }
    }
  },
  methods: {
    submitForm() {
      if (!this.formData.startTime) {
        alert('Поле "Начало инцидента" обязательно.')
        return
      }

      if (!this.formData.description || this.formData.description.trim().length < 3) {
        alert('Введите корректное описание (минимум 3 символа).')
        return
      }

      this.$emit('submit', {
        ...this.downtime,
        ...this.formData,
        startTime: new Date(this.formData.startTime).toISOString(),
        endTime: this.formData.endTime ? new Date(this.formData.endTime).toISOString() : null,
      })
    },
  },
}
</script>

<style scoped>
.modal {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: rgba(0, 0, 0, 0.4);
  display: flex;
  justify-content: center;
  align-items: center;
  z-index: 10;
}

.modal-content {
  background: white;
  padding: 25px;
  width: 450px;
  border-radius: 5px;
  box-shadow: 0 2px 10px rgba(0, 0, 0, 0.15);
}

h3 {
  margin-top: 0;
  margin-bottom: 20px;
  font-size: 18px;
  color: #333;
}

h4 {
  margin: 0 0 10px 0;
  font-size: 16px;
  font-weight: 500;
}

.form-row {
  display: flex;
  align-items: center;
  margin-bottom: 15px;
}

.form-row label {
  width: 100px;
  margin-right: 15px;
  font-weight: normal;
}

input[type='datetime-local'] {
  flex-grow: 1;
  padding: 8px;
  border: 1px solid #ddd;
  border-radius: 4px;
}

.description-section {
  margin-top: 25px;
  border-top: 1px solid #eee;
  padding-top: 15px;
}

textarea {
  width: 100%;
  padding: 8px;
  box-sizing: border-box;
  border-radius: 4px;
  border: 1px solid #ddd;
  min-height: 80px;
  resize: vertical;
}

.buttons {
  margin-top: 25px;
  display: flex;
  justify-content: space-between;
}

button {
  padding: 8px 16px;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  font-size: 14px;
  font-weight: 500;
  transition: background-color 0.2s;
  flex: 1;
  max-width: 48%;
}

button[type='submit'] {
  background-color: #4caf50;
  color: white;
}

button[type='submit']:hover {
  background-color: #45a049;
}

button[type='button'] {
  background-color: #f44336;
  color: white;
}

button[type='button']:hover {
  background-color: #d32f2f;
}
</style>
