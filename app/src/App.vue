<template>
  <div id="app">
    <BNavbar>
      <template #brand>
        <RouterLink :to="{ name: 'default' }">
          <img
            src="@/assets/logo.png"
            style="max-height: 100px; padding-right: 2rem"
          />
        </RouterLink>
      </template>
      <template #start>
        <BNavbarItem href="/">
          To Do
        </BNavbarItem>
        <BNavbarItem href="/#/done">
          Done
        </BNavbarItem>
      </template>
    </BNavbar>
    <div id="viewport">
    <router-view />
    </div>
  </div>
</template>

<style lang="scss">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#viewport {
  margin: 1.5rem;
}

.navbar {
  margin-bottom: 1rem;
}

</style>
