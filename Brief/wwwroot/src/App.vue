<template>
  <v-app>
    <v-app-bar
      app
      color="primary"
      dark
    >
      <div class="d-flex align-center">
        Бриф
      </div>

      <div style="flex:1; max-width:400px; margin:auto;">
        <step-progress :steps="completedSections" :current-step="currentSection" icon-class="fa fa-check"
        :line-thickness="3"
        :active-thickness="3"
        :passive-thickness="3"
        active-color="#3498db"
        passive-color="#aed6f1"></step-progress>
      </div>

    </v-app-bar>

    <v-main class="main">
      <FieldsList/>
    </v-main>
  </v-app>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';
import StepProgress from 'vue-step-progress';
import 'vue-step-progress/dist/main.css';
import FieldsList from './components/FieldsList.vue';

export default {
  name: 'App',
  components: {
    FieldsList,
    StepProgress,
  },
  data: () => ({
    //
  }),
  computed: {
    ...mapGetters([
      'isLoading',
      'sections',
    ]),
    completedSections() {
      return this.sections.map(() => '');
    },
    currentSection() {
      return this.sections.filter((section) => section.fields.every((field) => field.isValid)).length;
    },
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

header{
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

.step-progress__step::after{
  width: 20px;
  height: 20px;
}

.step-progress__step span{
  display: none;
}
</style>
