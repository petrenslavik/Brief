<template>
  <v-app>
    <v-app-bar app dark>
      <div
        class="d-flex align-center"
        style="font-style: italic; font-size: 44px; margin-top: 25px; color: rgb(22, 71, 90);"
      >
        Brief
      </div>
    </v-app-bar>

    <v-main class="main">
        <router-view></router-view>
    </v-main>
  </v-app>
</template>

<script>
export default {
  name: 'AdminDashboard',
};
</script>
<style>
    .main {
        background: aliceblue;
    }
</style>
