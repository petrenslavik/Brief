<template>
  <v-form ref="form" @submit="submit">
    <v-container class="width-container">
      <v-row no-gutters>
        <v-card elevation="4" class="mx-auto field">
          <v-card-title>Бриф на разработку ПО</v-card-title>
          <v-card-text>
            Данный опрос содержит вопросы для сбора базовой информации о Вас,
            Вашей организации и программном обеспечении, которое Вам требуется.
            Точные и содержательные ответы дадут нам возможность помочь Вам
            быстрее и дешевле. Пожалуйста отнеситесь серьезно к заполнению
            данного брифа
          </v-card-text>
        </v-card>
      </v-row>
      <v-row no-gutters class="brief-container">
        <v-col class="brief-container">
          <v-card
            elevation="4"
            class="mx-auto field"
            v-for="section in sections"
            :key="section.name"
          >
            <v-card-title>{{ section.name }}</v-card-title>
            <v-card-text>
              <component
                v-for="field in section.fields"
                v-bind:is="getComponent(field)"
                v-bind="field"
                :key="field.name"
                v-bind:isValid.sync="field.isValid"
              />
            </v-card-text>
          </v-card>
        </v-col>
      </v-row>
      <v-row no-gutters>
        <v-spacer />
        <v-btn color="success" class="mr-4 form-submit-btn" type="submit"> Submit </v-btn>
        <v-spacer />
      </v-row>
    </v-container>
  </v-form>
</template>
<script>
import { mapGetters } from 'vuex';
import TextField from './TextField.vue';
import SwitchField from './SwitchField.vue';
import DateField from './DateField.vue';
import RadioField from './RadioField.vue';
import TextAreaField from './TextAreaField,.vue';
import request from '../services/request';

const types = {
  text: TextField,
  switch: SwitchField,
  date: DateField,
  radio: RadioField,
  'text-area': TextAreaField,
};

export default {
  components: {
    TextField,
    SwitchField,
    DateField,
    RadioField,
  },
  computed: {
    ...mapGetters(['sections']),
  },
  methods: {
    getComponent(field) {
      return types[field.type];
    },
    submit(event) {
      event.preventDefault();
      const isValid = this.$refs.form.validate();
      if (isValid) {
        request.post('/brief', new FormData(event.target));
      }
    },
  },
};
</script>
<style>
.brief-container > * {
  margin: 25px 0;
}

.width-container {
  max-width: 800px !important;
}
.v-card__title {
  word-break: normal !important;
}

.form-submit-btn{
  padding: 0 30px !important;
  min-height: 42px;
}
</style>
