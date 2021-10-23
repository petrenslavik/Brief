<template>
  <div>
    <v-form ref="form" @submit="submit" v-if="!isSubmitted">
      <div class="brief-banner">
        <p>Бриф на разработку ПО</p>
        <p>
          Данный опрос содержит вопросы для сбора базовой информации о Вас,
          Вашей организации и программном обеспечении, которое Вам требуется.
          Точные и содержательные ответы дадут нам возможность помочь Вам
          быстрее и дешевле. Пожалуйста отнеситесь серьезно к заполнению данного
          брифа
        </p>
      </div>
      <v-container class="width-container">
        <v-row no-gutters>
          <v-col class="brief-container">
            <v-card
              elevation="4"
              class="mx-auto field"
              v-for="section in sections"
              :key="section.name"
            >
              <v-card-title>{{ section.name }}</v-card-title>
              <v-card-text v-if="!isReadonly">
                <component
                  v-for="field in section.fields"
                  v-bind:is="getComponent(field)"
                  v-bind="field"
                  :key="field.name"
                  v-bind:isValid.sync="field.isValid"
                  @update="update"
                />
              </v-card-text>
              <v-card-text v-else>
                <component
                  v-for="field in section.fields"
                  v-bind:is="getComponent(field)"
                  v-bind="field"
                  :key="field.name"
                  v-bind:isValid.sync="field.isValid"
                  @update="update"
                  :readonly="isReadonly"
                  :value="submittedForm[field.name]"
                />
              </v-card-text>
            </v-card>
          </v-col>
        </v-row>
        <v-row no-gutters v-if="!isReadonly">
          <v-spacer />
          <v-btn
            color="#16475A"
            class="mr-4 mt-5 mb-5 form-submit-btn"
            type="submit"
          >
            Submit
          </v-btn>
          <v-spacer />
        </v-row>
      </v-container>
    </v-form>
    <div v-else>
      <v-container class="width-container">
        <v-row no-gutters>
          <v-col class="brief-container">
            <v-card elevation="4" class="mx-auto field">
              <v-card-title>Ваши ответы были записаны</v-card-title>
              <v-card-text> Мы вам перезвоним. </v-card-text>
            </v-card>
          </v-col>
        </v-row>
      </v-container>
    </div>
  </div>
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
  name: 'FieldsList',
  components: {
    TextField,
    SwitchField,
    DateField,
    RadioField,
  },
  props: {
    submittedForm: Object,
  },
  data() {
    return {
      inputs: {},
      isSubmitted: false,
    };
  },
  computed: {
    ...mapGetters(['sections']),
    isReadonly() {
      return !!this.submittedForm;
    },
  },
  methods: {
    getComponent(field) {
      return types[field.type];
    },
    submit(event) {
      event.preventDefault();
      const isValid = this.$refs.form.validate();
      const formData = new FormData();
      if (isValid) {
        this.sections.forEach((section) => {
          section.fields.forEach((field) => {
            formData.append(field.name, this.inputs[field.name]);
          });
        });
        request.post('/brief', formData);
        this.isSubmitted = true;
      }
    },
    update(name, value) {
      this.inputs[name] = value;
    },
  },
};
</script>
<style>
.brief-container > * {
  margin: 25px 0 0 0;
}

.width-container {
  max-width: 800px !important;
  margin-top: 16px;
}
.v-card__title {
  word-break: normal !important;
  color: initial;
}

.form-submit-btn {
  padding: 0 30px !important;
  min-height: 42px;
  color: white !important;
}

.step-progress__bar {
  height: 60px !important;
  margin-bottom: initial;
}

.brief-banner > p:first-child {
  font-size: 3rem;
}

.brief-banner {
  background: url(../assets/banner.jpeg);
  background-repeat: no-repeat;
  min-height: 700px;
  display: flex;
  flex-direction: column;
  color: white;
  justify-content: center;
  align-content: center;
  align-items: center;
  background-size: 100% 100%;
  font-size: 1.25rem;
  padding: 0 20%;
}
.v-form {
  background: aliceblue;
}
</style>
