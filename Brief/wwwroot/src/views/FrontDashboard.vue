<template>
  <v-app>
    <v-app-bar
      app
      dark
    >
      <div class="d-flex align-center" style="font-style: italic; font-size: 44px; margin-top: 25px;">
        Brief
      </div>

      <div style="flex:1; max-width:400px; margin:auto;">
        <step-progress :steps="steps" :current-step="currentSection" icon-class="fa fa-check"
        :line-thickness="3"
        :active-thickness="3"
        :passive-thickness="3"
        active-color="#16475A"
        passive-color="#aed6f1"></step-progress>
      </div>

    </v-app-bar>

    <v-main class="main">
      <FieldsList />
    </v-main>
  </v-app>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

import StepProgress from 'vue-step-progress';
import FieldsList from '../components/FieldsList.vue';
import 'vue-step-progress/dist/main.css';

export default {
  name: 'FrontDashboard',
  components: {
    StepProgress,
    FieldsList,
  },
  data: () => ({
    steps: ['25%', '50%', '75%', '100%'],
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
  background: linear-gradient(#dca467, #c99db6);
}

header{
  height: 90px !important;
  background-color: #dca467 !important;
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

.step-progress__bar{
  height: auto;
  margin-bottom: 0;
}

.step-progress__step-label {
  color: #aed6f1;
}

.step-progress__step::after{
  width: 20px;
  height: 20px;
}

.step-progress__step span{
  display: none;
}
</style>
