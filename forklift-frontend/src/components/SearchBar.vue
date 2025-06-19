<!-- components/SearchBar.vue -->
<template>
  <div class="search-bar">
    <input v-model="searchValue" placeholder="Номер погрузчика" />
    <button @click="onSearch">🔍 Искать</button>
    <button @click="$emit('reset')">❌ Сбросить</button>
  </div>
</template>

<script>
export default {
  emits: ['search', 'reset'],
  data() {
    return {
      searchValue: '',
    }
  },
  methods: {
    onSearch() {
      this.$emit('search', this.searchValue)
    },
  },
}
</script>

<style scoped>
.search-bar {
  display: flex;
  gap: 10px;
  margin-bottom: 20px;
  align-items: center;
}

.search-bar input {
  padding: 8px;
  border: 1px solid #ccc;
  border-radius: 10px;
  max-width: 300px;
}

.search-bar button {
  padding: 8px 16px;
  background-color: rgb(181, 18, 18);
  color: white;
  border: 1px solid #ccc;
  border-radius: 10px;
  cursor: pointer;
}

.search-bar button:hover {
  background-color: #751a08;
}
</style>
