<template>
  <v-checkbox
      :label="question"
    ></v-checkbox>
</template>
<script>
export default {
  props: {
    question: String,
  },
};
</script>
