<template>
  <v-form ref="form" @submit="submit">
    <v-container>
      <v-row no-gutters>
        <v-col class="brief-container">
          <v-card
            elevation="4"
            shaped
            class="mx-auto field"
            v-for="section in sections"
            :key="section.name"
          >
            <v-card-title>{{ section.name }}</v-card-title>
            <v-card-text>
              <component
                v-for="field in section.fields"
                v-bind:is="getComponent(field)"
                v-bind="field"
                :key="field.name"
              />
            </v-card-text>
          </v-card>
        </v-col>
      </v-row>
      <div>
        <v-btn color="success" class="mr-4" type="submit"> Submit </v-btn>
        <v-btn color="error" class="mr-4" @click="reset"> Reset </v-btn>
      </div>
    </v-container>
  </v-form>
</template>
<script>
import { mapGetters } from 'vuex';
import TextField from './TextField.vue';
import SwitchField from './SwitchField.vue';
import DateField from './DateField.vue';

const types = {
  text: TextField,
  switch: SwitchField,
  date: DateField,
};

export default {
  components: {
    TextField,
  },
  computed: {
    ...mapGetters(['sections']),
  },
  methods: {
    getComponent(field) {
      return types[field.type];
    },
    reset() {
      this.$refs.form.reset();
    },
    submit(event) {
      event.preventDefault();
    },
  },
};
</script>
<style>
.brief-container > * {
  margin: 25px 0;
}
</style>
