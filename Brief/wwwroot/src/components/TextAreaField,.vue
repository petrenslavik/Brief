<template class="text-area-field">
  <div>
    <span :class="{required: isMandatory && !readonly}">{{ question }}</span>
    <v-textarea
      v-if="!readonly"
      class="text-area-field-input"
      auto-grow
      :rules="generatedRules"
      outlined
      v-model="fieldValue"
    ></v-textarea>
    <v-textarea
      v-else
      class="text-area-field-input"
      auto-grow
      :rules="generatedRules"
      outlined
      v-model="value"
      readonly
    ></v-textarea>
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
      return rules;
    },
  },
  data() {
    return {
      rulesBuilders: {
        required: (isMandatory) => (value) => !isMandatory || !!value || 'Обязательно.',
        maxLength: (length) => (value) => value === undefined
          || value.length <= length
          || `Максимально ${length} символов`,
      },
      rulesIsValid: {
        isMandatory: true,
        minLength: true,
        maxLength: true,
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
          this.$set(this.rulesIsValid, propName, true);
        } else {
          this.$set(this.rulesIsValid, propName, false);
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
.text-area-field-input {
  padding-top: 0px !important;
  padding-bottom: 5px;
}
.text-area-field .v-input__slot {
  min-height: 42px !important;
}
</style>
