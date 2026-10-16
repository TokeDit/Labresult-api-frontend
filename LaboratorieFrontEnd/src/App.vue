<script setup>
import { ref, onMounted } from 'vue'

const API_URL = 'http://localhost:5287/api/Sample'

const samples = ref([])
const name = ref('')
const temperature = ref(0)
const errorMessage = ref('')

async function fetchSamples() {
  const res = await fetch(API_URL)
  samples.value = await res.json()
}

async function createSample() {
  errorMessage.value = ''
  const res = await fetch(API_URL, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({ name: name.value, temperature: Number(temperature.value) })
  })
  if (!res.ok) {
    errorMessage.value = 'Could not add sample. Check the values and try again.'
    return
  }
  name.value = ''
  temperature.value = 0
  await fetchSamples()
}

function formatTime(ts) {
  return new Date(ts).toLocaleString(undefined, {
    year: 'numeric', month: 'short', day: 'numeric',
    hour: '2-digit', minute: '2-digit'
  })
}

onMounted(fetchSamples)
</script>

<template>
  <div class="page">
    <h1>Laboratorie Api display</h1>

    <ul class="sample-list">
      <li v-for="sample in samples" :key="sample.id">
        <span class="id">#{{ sample.id }}</span>
        <span class="name">{{ sample.name }}</span>
        <span class="temp">{{ sample.temperature }}°C</span>
        <span class="time">{{ formatTime(sample.timeStamp) }}</span>
      </li>
    </ul>

    <h2>Add Sample</h2>
    <p v-if="errorMessage" class="error">{{ errorMessage }}</p>
    <form @submit.prevent="createSample">
      <div class="field">
        <label for="name">Name</label>
        <input id="name" v-model="name" type="text" placeholder="e.g. Sample A" required />
      </div>
      <div class="field">
        <label for="temperature">Temperature (°C)</label>
        <input id="temperature" v-model="temperature" type="number" placeholder="0.0" step="any" required />
      </div>
      <button type="submit">Add</button>
    </form>
  </div>
</template>

<style scoped>
.page {
  max-width: 640px;
  margin: 2rem auto;
  padding: 1.5rem 2rem;
  font-family: system-ui, -apple-system, Segoe UI, Roboto, sans-serif;
  color: #1f2430;
}

h1 {
  font-size: 1.5rem;
  margin-bottom: 1rem;
}

h2 {
  font-size: 1.1rem;
  margin-top: 2rem;
  margin-bottom: 0.75rem;
}

.error {
  color: #b91c1c;
  font-size: 0.85rem;
  margin: 0.5rem 0 0;
}

.sample-list {
  list-style: none;
  padding: 0;
  display: flex;
  flex-direction: column;
  gap: 0.4rem;
}

.sample-list li {
  display: flex;
  align-items: center;
  gap: 0.75rem;
  padding: 0.6rem 0.9rem;
  background: #f5f6fa;
  border: 1px solid #e2e4eb;
  border-radius: 8px;
  font-size: 0.9rem;
}

.sample-list .id {
  color: #8a8f9c;
  font-size: 0.8rem;
}

.sample-list .name {
  font-weight: 600;
  flex: 1;
}

.sample-list .temp {
  color: #c2410c;
  font-weight: 600;
}

.sample-list .time {
  color: #8a8f9c;
  font-size: 0.8rem;
}

form {
  display: flex;
  align-items: flex-end;
  gap: 1rem;
  flex-wrap: wrap;
  background: #fafbfc;
  border: 1px solid #e2e4eb;
  border-radius: 8px;
  padding: 1rem;
}

.field {
  display: flex;
  flex-direction: column;
  gap: 0.3rem;
}

.field label {
  font-size: 0.8rem;
  font-weight: 600;
  color: #4b5160;
}

.field input {
  padding: 0.5rem 0.65rem;
  border: 1px solid #ccd0d9;
  border-radius: 6px;
  font-size: 0.9rem;
}

.field input:focus {
  outline: none;
  border-color: #6366f1;
  box-shadow: 0 0 0 3px rgba(99, 102, 241, 0.15);
}

button {
  padding: 0.55rem 1.1rem;
  background: #6366f1;
  color: white;
  border: none;
  border-radius: 6px;
  font-size: 0.9rem;
  font-weight: 600;
  cursor: pointer;
}

button:hover {
  background: #4f52d6;
}
</style>
