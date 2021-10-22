<template>
  <div>
    <FieldsList :submittedForm="getCurrentForm" />
    <v-btn fab large dark class="back-to-list" @click="toList">
      <v-icon>arrow_back</v-icon>
    </v-btn>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';
import FieldsList from '../components/FieldsList.vue';

export default {
  name: 'ReportDetail',
  components: {
    FieldsList,
  },
  data: () => ({
    id: 0,
  }),
  computed: {
    ...mapGetters(['isLoading', 'submittedForms']),
    getCurrentForm() {
      return this.submittedForms.find((x) => x.id === this.id)?.data;
    },
  },
  methods: {
    ...mapActions(['getSubmittedForms', 'getFields']),
    toList() {
      this.$router.push({ name: 'Reports' });
    },
  },
  mounted() {
    this.id = Number.parseInt(this.$route.params.id, 10);
    this.getSubmittedForms();
    this.getFields();
  },
};
</script>
<style>
#app {
  background: none;
}

body {
  background: linear-gradient(#dca467, #c99db6);
}

header {
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

.step-progress__step-label {
  color: #aed6f1;
}

.step-progress__step::after {
  width: 20px;
  height: 20px;
}

.step-progress__step span {
  display: none;
}

.back-to-list {
  position: fixed;
  bottom: 16px;
  left: 16px;
}
</style>
