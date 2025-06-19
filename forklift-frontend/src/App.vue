<template>
  <nav></nav>
  <router-view />
</template>

<style>
html,
body {
  height: auto;
  margin: 0;
}

#app {
  font-family: Avoir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  background-color: rgb(215, 215, 215);
  width: 100%;
  height: 100%;
}

nav {
  padding: 30px;
  background-color: rgb(160, 17, 17);
  border-radius: 10px;
}

nav a {
  font-weight: bold;
  color: #2c3e50;
}

nav a.router-link-exact-active {
  color: #000000;
}
</style>
