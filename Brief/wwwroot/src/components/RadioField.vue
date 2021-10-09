<template>
  <v-radio-group :mandatory="isMandatory" class="radio-field" :name="name">
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
    name: String,
    options: Array,
    isMandatory: Boolean,
    isValid: Boolean,
  },
  mounted() {
    this.$emit('update:isValid', true);
  },
};
</script>
<style>
.radio-field{
  margin-top:0px !important;
}
</style>
