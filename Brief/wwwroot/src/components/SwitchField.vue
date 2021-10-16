<template>
  <v-checkbox
      :label="question"
      v-model="fieldValue"
    ></v-checkbox>
</template>
<script>
export default {
  props: {
    question: String,
  },
  data() {
    return {
      fieldValue: '',
    };
  },
  watch: {
    fieldValue(val) {
      this.$emit('update', this.name, val);
    },
  },
};
</script>
