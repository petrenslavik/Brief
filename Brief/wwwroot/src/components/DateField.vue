<template>
  <v-menu
    v-model="fromDateMenu"
    :close-on-content-click="false"
    :nudge-right="40"
    transition="scale-transition"
    offset-y
    max-width="290px"
    min-width="290px"
  >
    <template v-slot:activator="{ on }">
      <v-text-field
        :label="question"
        prepend-icon="event"
        readonly
        :value="fromDateDisp"
        v-on="on"
      ></v-text-field>
    </template>
    <v-date-picker
      locale="en-in"
      no-title
      @input="fromDateMenu = false"
      :min="minDate"
      v-model="fromDateVal"
    ></v-date-picker>
  </v-menu>
</template>
<script>
export default {
  props: {
    question: String,
  },
  data: () => {
    const date = new Date();
    return {
      minDate: date.toISOString(),
      fromDateVal: null,
      fromDateMenu: false,
    };
  },
  computed: {
    fromDateDisp() {
      return this.fromDateVal;
    },
  },
};
</script>
