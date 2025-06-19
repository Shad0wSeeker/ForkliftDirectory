<!-- components/DowntimeTable.vue -->
<template>
  <div>
    <h3>Простои по погрузчику {{ forklift.number }}</h3>
    <table>
      <thead>
        <tr>
          <th>Код записи</th>
          <th>Начало</th>
          <th>Окончание</th>
          <th>Длительность</th>
          <th>Описание</th>
          <th>Действия</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="d in sortedDowntimes" :key="d.id">
          <td>{{ d.id }}</td>
          <td>{{ format(d.startTime) }}</td>
          <td>{{ d.endTime ? format(d.endTime) : '—' }}</td>
          <td>{{ d.downtimeDuration }}</td>
          <td>{{ d.description }}</td>
          <td>
            <button @click="$emit('edit', d)">✏️</button>
            <button @click="$emit('delete', d)">❌</button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {
  props: {
    downtimes: Array,
    forklift: Object,
  },
  computed: {
    sortedDowntimes() {
      return [...this.downtimes].sort((a, b) => new Date(b.startTime) - new Date(a.startTime))
    },
  },
  methods: {
    format(dt) {
      return new Date(dt).toLocaleString('ru-RU')
    },
  },
}
</script>

<style scoped>
table {
  width: 100%;
  border-collapse: collapse;
  margin-top: 10px;
}
th,
td {
  border: 1px solid #ddd;
  padding: 8px;
  background-color: #f9f9f9;
}
</style>
