<template>
  <div class="text-field">
    <span :class="{required: isMandatory && !readonly}">{{ question }}</span>
    <v-text-field
      v-if="!readonly"
      class="text-field-input"
      :rules="generatedRules"
      outlined
      :id="name"
      v-model="fieldValue"
    ></v-text-field>
    <v-text-field
      v-else
      class="text-field-input"
      :rules="generatedRules"
      outlined
      :id="name"
      v-model="value"
      readonly
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
    readonly: Boolean,
    value: String,
  },
  computed: {
    generatedRules() {
      const rules = [];
      Object.entries(backendPropsToRules).forEach(([propName, ruleName]) => {
        if (this[propName] !== undefined) {
          rules.push(
            this.hofValidation(
              this.rulesBuilders[ruleName](this[propName]),
              propName,
            ),
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
        required: (isMandatory) => (value) => !isMandatory || !!value || 'Обязательно.',
        maxLength: (length) => (value) => !value
          || value.length <= length
          || `Максимально ${length} символов`,
        minLength: (length) => (value) => !value
          || value.length >= length
          || `Минимально ${length} символа`,
        email: (value) => {
          const pattern = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
          return pattern.test(value) || 'Неверный формат электронного адреса.';
        },
        phone: (value) => {
          const pattern = /\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})/;
          return pattern.test(value) || 'Неверный номер телефона.';
        },
      },
      rulesIsValid: {
        isMandatory: true,
        minLength: true,
        maxLength: true,
        email: true,
        phone: true,
      },
      fieldValue: '',
    };
  },
  watch: {
    rulesIsValid: {
      handler(newObj) {
        this.$emit(
          'update:isValid',
          Object.values(newObj).every((val) => val),
        );
      },
      deep: true,
    },
    fieldValue(val) {
      this.$emit('update', this.name, val);
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
        this.$emit(
          'update:isValid',
          Object.values(this.rulesIsValid).every((val) => val),
        );
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

span.required:after {
    color: #e32;
    content: ' *';
    display:inline;
}
</style>
