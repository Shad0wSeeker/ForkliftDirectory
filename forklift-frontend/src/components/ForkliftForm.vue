<!-- components/ForkliftForm.vue -->
<template>
  <div class="modal">
    <div class="modal-content">
      <h3>{{ isNew ? 'Добавить' : 'Изменить' }} погрузчик</h3>

      <form @submit.prevent="onSubmit">
        <div class="form-group">
          <label>Марка</label>
          <input v-model="formData.brand" placeholder="Марка" />
        </div>
        <div class="form-group">
          <label>Номер</label>
          <input v-model="formData.number" placeholder="Номер" />
        </div>
        <div class="form-group">
          <label>Г/П</label>
          <input
            v-model="formData.loadCapacity"
            type="number"
            step="0.001"
            min="0"
            placeholder="Грузоподъемность"
            @input="validateLoadCapacity" />
        </div>
        <div class="form-group">
          <label>Пользователь</label>
          <input v-model="formData.updatedBy" placeholder="Пользователь" />
        </div>

        <div class="form-group checkbox-group" v-if="!isNew">
          <label>
            <span>Активен</span>
            <input type="checkbox" v-model="formData.isActive" />
          </label>
        </div>

        <div class="buttons">
          <button type="submit" class="save-btn">Сохранить</button>
          <button type="button" class="cancel-btn" @click="$emit('cancel')">Отменить</button>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
export default {
  props: ['form', 'isNew'],
  emits: ['submit', 'cancel'],
  data() {
    return {
      formData: { ...this.form },
    }
  },
  watch: {
    form(newVal) {
      this.formData = { ...newVal }
    },
  },
  methods: {
    validateLoadCapacity(event) {
      if (event.target.value < 0) {
        this.formData.loadCapacity = 0
        alert('Грузоподъемность не может быть отрицательной')
      }
    },
    onSubmit() {
      if (this.formData.loadCapacity < 0) {
        this.formData.loadCapacity = 0
        alert('Исправьте грузоподъемность на положительное значение')
        return
      }
      this.$emit('submit', this.formData)
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
  z-index: 1000;
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
  text-align: center;
}

.form-group {
  display: grid;
  align-items: center;
  margin-bottom: 15px;
  gap: 10px;
  grid-template-columns: 110px 1fr;
}

.form-group label {
  margin-right: 15px;
  font-weight: normal;
  text-align: left;
}

input {
  width: 90%;
  padding: 10px;
  border: 1px solid #ddd;
  border-radius: 4px;
  font-size: 14px;
}

input:focus {
  outline: none;
  border-color: #4caf50;
  box-shadow: 0 0 0 2px rgba(76, 175, 80, 0.2);
}

.checkbox-group {
  display: flex;
  align-items: center;
}

.checkbox-group label {
  display: flex;
  align-items: center;
  cursor: pointer;
}

.checkbox-group input[type='checkbox'] {
  width: auto;
  margin-right: 8px;
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

.save-btn {
  background-color: #4caf50;
  color: white;
}

.save-btn:hover {
  background-color: #45a049;
}

.cancel-btn {
  background-color: #f44336;
  color: white;
}

.cancel-btn:hover {
  background-color: #d32f2f;
}
</style>
