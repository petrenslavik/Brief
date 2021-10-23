<template>
  <div>
    <v-radio-group
      v-if="!readonly"
      :mandatory="isMandatory"
      class="radio-field"
      :name="name"
      v-model="fieldValue"
    >
      <template v-slot:label>
        <span :class="{required: isMandatory}">{{ question }}</span>
      </template>
      <v-radio
        v-for="option in options"
        :key="option"
        :label="option"
        :value="option"
      >
      </v-radio>
    </v-radio-group>
    <v-radio-group
      v-else
      :mandatory="isMandatory"
      class="radio-field"
      :name="name"
      v-model="value"
      readonly
    >
      <template v-slot:label>
        {{ question }}
      </template>
      <v-radio
        v-for="option in options"
        :key="option"
        :label="option"
        :value="option"
      >
      </v-radio>
    </v-radio-group>
  </div>
</template>
<script>
export default {
  props: {
    question: String,
    name: String,
    options: Array,
    isMandatory: Boolean,
    isValid: Boolean,
    readonly: Boolean,
    value: String,
  },
  data() {
    return {
      fieldValue: '',
    };
  },
  mounted() {
    this.$emit('update:isValid', true);
  },
  watch: {
    fieldValue(val) {
      this.$emit('update', this.name, val);
    },
  },
};
</script>
<style>
.radio-field {
  margin-top: 0px !important;
}
</style>
