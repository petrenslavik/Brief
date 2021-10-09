<template class="text-area-field">
  <div>
    {{question}}
    <v-textarea class="text-area-field-input" auto-grow :rules="generatedRules" outlined></v-textarea>
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
  },
  computed: {
    generatedRules() {
      const rules = [];
      Object.entries(backendPropsToRules).forEach(([propName, ruleName]) => {
        if (this[propName] !== undefined) {
          rules.push(this.hofValidation(this.rulesBuilders[ruleName](this[propName]), propName));
        }
      });
      return rules;
    },
  },
  data() {
    return {
      rulesBuilders: {
        required: (isMandatory) => (value) => !isMandatory || !!value || 'Required.',
        maxLength: (length) => (value) => value === undefined || value.length <= length || `Max ${length} characters`,
      },
      rulesIsValid: {
        isMandatory: true,
        minLength: true,
        maxLength: true,
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
          this.$set(this.rulesIsValid, propName, true);
        } else {
          this.$set(this.rulesIsValid, propName, false);
        }
        return result;
      };
    },
  },
};
</script>
<style>
.text-area-field-input{
  padding-top:0px !important;
  padding-bottom: 5px;
}
.text-area-field .v-input__slot{
  min-height: 42px !important;
}
</style>
