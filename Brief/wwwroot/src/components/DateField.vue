<template>
  <v-menu
    v-model="fromDateMenu"
    :close-on-content-click="false"
    :nudge-right="40"
    transition="scale-transition"
    offset-y
    max-width="290px"
    min-width="290px"
  >
    <template v-slot:activator="{ on }">
      {{ question }}
      <v-text-field
        prepend-icon="event"
        readonly
        :value="fromDateDisp"
        v-on="on"
        :rules="generatedRules"
      ></v-text-field>
    </template>
    <v-date-picker
      locale="en-in"
      no-title
      @input="fromDateMenu = false"
      :min="minDate"
      v-model="fromDateVal"
    ></v-date-picker>
  </v-menu>
</template>
<script>
export default {
  props: {
    question: String,
    isMandatory: Boolean,
    isValid: Boolean,
    name: String,
  },
  data: () => {
    const date = new Date();
    return {
      minDate: date.toISOString(),
      fromDateVal: '',
      fromDateMenu: false,
      rules: {
        required: (value) => !!value || 'Required.',
        counter: (value) => value.length <= 20 || 'Max 20 characters',
        email: (value) => {
          const pattern = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
          return pattern.test(value) || 'Invalid e-mail.';
        },
      },
    };
  },
  computed: {
    fromDateDisp() {
      return this.fromDateVal;
    },
    generatedRules() {
      const rules = [];
      if (this.isMandatory) {
        rules.push(this.hofValidation(this.rules.required));
      }
      return rules;
    },
  },
  watch: {
    fromDateVal(val) {
      this.$emit('update', this.name, val);
    },
  },
  methods: {
    hofValidation(validateFunc) {
      return (value) => {
        const result = validateFunc(value);
        if (result === true) {
          this.$emit('update:isValid', true);
        } else {
          this.$emit('update:isValid', false);
        }
        return result;
      };
    },
  },
};
</script>
