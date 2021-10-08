<template>
  <v-radio-group :mandatory={isMandatory}>
      <template v-slot:label>
        {{ question }}
      </template>
      <v-radio v-for="option in options" :key="option" :label="option" :value="option">
      </v-radio>
    </v-radio-group>
</template>
<script>
export default {
  props: {
    question: String,
    options: Array,
    isMandatory: Boolean,
  },
};
</script>
