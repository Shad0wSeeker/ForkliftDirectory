<!-- components/ForkliftTable.vue -->
<template>
  <table>
    <thead>
      <tr>
        <th>Код записи</th>
        <th>Марка</th>
        <th>Номер</th>
        <th>Грузоподъемность</th>
        <th>Активен</th>
        <th>Дата и время изменения</th>
        <th>Пользователь</th>
        <th>Действия</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="forklift in forklifts" :key="forklift.id" @click="select(forklift)">
        <td>{{ forklift.id }}</td>
        <td>{{ forklift.brand }}</td>
        <td>{{ forklift.number }}</td>
        <td>{{ forklift.loadCapacity }}</td>
        <td>{{ forklift.isActive ? '✅' : '❌' }}</td>
        <td>{{ formatDateTime(forklift.updatedAt) }}</td>
        <td>{{ forklift.updatedBy }}</td>
        <td>
          <button @click="$emit('edit', forklift)">✏️</button>
          <button @click="$emit('delete', forklift)">❌</button>
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script>
export default {
  props: ['forklifts'],
  methods: {
    formatDateTime(dateString) {
      if (!dateString) return ''
      const date = new Date(dateString)
      return date.toLocaleString('ru-RU', {
        day: '2-digit',
        month: '2-digit',
        year: 'numeric',
        hour: '2-digit',
        minute: '2-digit',
      })
    },
    select(forklift) {
      this.$emit('select', forklift)
    },
  },
}
</script>

<style scoped>
table {
  width: 100%;
  border-collapse: collapse;
  margin-bottom: 20px;
  font-size: 0.9rem;
  border-color: black;
}

th,
td {
  border: 1px solid #ddd;
  padding: 12px;
  text-align: left;
  background-color: #f2f2f2;
}

tr:hover td {
  background: #888888;
}
</style>
