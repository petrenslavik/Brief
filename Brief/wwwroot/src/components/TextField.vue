<template>
  <div>
    {{question}}
    <v-text-field class="text-field" :rules="generatedRules"></v-text-field>
  </div>
</template>
<script>
export default {
  props: {
    question: String,
    isMandatory: Boolean,
  },
  computed: {
    generatedRules() {
      const rules = [];
      if (this.isMandatory) {
        rules.push(this.rules.required);
      }
      return rules;
    },
  },
  data() {
    return {
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
};
</script>
<style scoped>
.text-field{
  padding-top:0px !important;
  padding-bottom: 5px;
}
</style>
