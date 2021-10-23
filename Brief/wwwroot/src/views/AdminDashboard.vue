<template>
  <v-app>
    <v-app-bar app dark>
      <div
        class="d-flex align-center"
        style="
          font-style: italic;
          font-size: 44px;
          margin-top: 25px;
          color: rgb(22, 71, 90);
        "
      >
               <router-link to="/">  Brief</router-link>
      </div>
      <v-spacer />
      <div v-if="isAuthorized" class="logout-container">
        <v-btn color="#16475A" @click="logoutUser"> Выход </v-btn>
      </div>
    </v-app-bar>

    <v-main class="main">
      <router-view></router-view>
    </v-main>
  </v-app>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

export default {
  name: 'AdminDashboard',
  computed: {
    ...mapGetters(['isAuthorized']),
  },
  methods: {
    ...mapActions(['logout']),
    logoutUser() {
      this.logout();
      this.$router.push({ name: 'Login' });
    },
  },
};
</script>
<style>
.main {
  background: aliceblue;
}

.logout-container {
  display: flex;
  align-items: flex-end;
  height: 100%;
}

a{
  text-decoration: none;
}
</style>
