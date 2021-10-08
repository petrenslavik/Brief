<template>
  <v-text-field :label="question"></v-text-field>
</template>
<script>
export default {
  props: {
    question: String,
  },
};
</script>
