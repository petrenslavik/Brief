<template>
  <v-container class="width-container" fluid>
    <v-row no-gutters>
      <v-col class="brief-container">
        <v-card elevation="4" class="mx-auto field">
          <v-card-title>Отправленные формы</v-card-title>
          <v-card-text>
            <v-data-table
              :loading="isLoading"
              :headers="headers"
              :items="mappedForms"
              :items-per-page="10"
              item-key="id"
              class="elevation-1"
              @click:row="openDetails"
            >
              <template v-slot:item.action="{ item }">
                <v-btn class="form-delete-btn"
                  @click="(event) => deleteForm(event, item.id)"
                  color="error"
                  fab
                  small
                  dark
                >
                  <v-icon>delete</v-icon>
                </v-btn>
              </template></v-data-table
            >
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

export default {
  name: 'Reports',
  data: () => ({
    headers: [
      {
        text: 'Id',
        value: 'id',
      },
      {
        text: 'Name',
        value: 'name',
      },
      {
        text: 'Email',
        value: 'email',
      },
      {
        text: 'Date',
        value: 'date',
      },
      {
        text: '',
        value: 'action',
      },
    ],
  }),
  computed: {
    ...mapGetters(['isLoading', 'submittedForms']),
    mappedForms() {
      return this.submittedForms.map((submittedForm) => ({
        id: submittedForm.id,
        date: submittedForm.date.toFormat('dd.LL.yyyy HH:mm'),
        name: submittedForm.data.Name,
        email: submittedForm.data.Email,
      }));
    },
  },
  methods: {
    ...mapActions(['getSubmittedForms', 'deleteSubmittedForm']),
    openDetails(mappedForm) {
      this.$router.push({
        name: 'ReportDetail',
        params: { id: mappedForm.id },
      });
    },
    deleteForm(event, id) {
      event.stopPropagation();
      this.deleteSubmittedForm(id);
    },
  },
  mounted() {
    this.getSubmittedForms();
  },
};
</script>
<style>
#app {
  background: none;
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

.form-delete-btn {
  box-shadow: none !important;
}
</style>
