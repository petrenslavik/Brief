<template>
  <v-app>
    <v-app-bar
      app
      color="primary"
      dark
    >
      <div class="d-flex align-center">
        <v-img
          alt="Vuetify Logo"
          class="shrink mr-2"
          contain
          src="https://cdn.vuetifyjs.com/images/logos/vuetify-logo-dark.png"
          transition="scale-transition"
          width="40"
        />

        <v-img
          alt="Vuetify Name"
          class="shrink mt-1 hidden-sm-and-down"
          contain
          min-width="100"
          src="https://cdn.vuetifyjs.com/images/logos/vuetify-name-dark.png"
          width="100"
        />
      </div>

      <v-spacer></v-spacer>
      <div>
        <v-icon dense>
          mdi-circle-outline
        </v-icon>
      </div>
      <v-spacer></v-spacer>

      <v-btn
        href="https://github.com/vuetifyjs/vuetify/releases/latest"
        target="_blank"
        text
      >
        <span class="mr-2">Latest Release</span>
        <v-icon>mdi-open-in-new</v-icon>
      </v-btn>
    </v-app-bar>

    <v-main class="main">
      <FieldsList/>
    </v-main>
  </v-app>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';
import FieldsList from './components/FieldsList.vue';

export default {
  name: 'App',
  components: {
    FieldsList,
  },
  data: () => ({
    //
  }),
  computed: {
    ...mapGetters([
      'isLoading',
    ]),
  },
  methods: {
    ...mapActions([
      'getFields',
    ]),
  },
  mounted() {
    this.getFields();
  },
};
</script>
<style>
#app{
  background: none;
}

body {
  background: linear-gradient(-45deg, #d8a273, #c99db6);
  background-size: 400% 400%;
  animation: gradient 40s ease infinite;
}

@keyframes gradient {
  0% {
    background-position: 0% 50%;
  }
  50% {
    background-position: 100% 50%;
  }
  100% {
    background-position: 0% 50%;
  }
}
</style>
