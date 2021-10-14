<template>
  <div class="text-field">
    {{ question }}
    <v-text-field
      class="text-field-input"
      :rules="generatedRules"
      outlined
    ></v-text-field>
  </div>
</template>
<script>
const backendPropsToRules = {
  isMandatory: 'required',
  minLength: 'minLength',
  maxLength: 'maxLength',
};

export default {
  props: {
    question: String,
    isMandatory: Boolean,
    isValid: Boolean,
    minLength: Number,
    maxLength: Number,
    name: String,
  },
  computed: {
    generatedRules() {
      const rules = [];
      Object.entries(backendPropsToRules).forEach(([propName, ruleName]) => {
        if (this[propName] !== undefined) {
          rules.push(
            this.hofValidation(this.rulesBuilders[ruleName](this[propName]), propName),
          );
        }
      });
      if (this.name === 'Email') {
        rules.push(this.hofValidation(this.rulesBuilders.email, 'email'));
      }
      if (this.name === 'PhoneNumber') {
        rules.push(this.hofValidation(this.rulesBuilders.phone, 'phone'));
      }
      return rules;
    },
  },
  data() {
    return {
      rulesBuilders: {
        required: (isMandatory) => (value) => !isMandatory || !!value || 'Required.',
        maxLength: (length) => (value) => value === undefined || value.length <= length || `Max ${length} characters`,
        minLength: (length) => (value) => value === undefined || value.length >= length || `Min ${length} characters`,
        email: (value) => {
          const pattern = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
          return pattern.test(value) || 'Invalid e-mail.';
        },
        phone: (value) => {
          const pattern = /\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})/;
          return pattern.test(value) || 'Invalid phone.';
        },
      },
      rulesIsValid: {
        isMandatory: true,
        minLength: true,
        maxLength: true,
        email: true,
        phone: true,
      },
    };
  },
  watch: {
    rulesIsValid: {
      handler(newObj) {
        this.$emit('update:isValid', Object.values(newObj).every((val) => val));
      },
      deep: true,
    },
  },
  methods: {
    hofValidation(validateFunc, propName) {
      return (value) => {
        const result = validateFunc(value);
        if (result === true) {
          this.rulesIsValid[propName] = true;
        } else {
          this.rulesIsValid[propName] = false;
        }
        return result;
      };
    },
  },
};
</script>
<style>
.text-field-input {
  padding-top: 0px !important;
  padding-bottom: 5px;
}
.text-field .v-input__slot {
  min-height: 42px !important;
}
</style>
