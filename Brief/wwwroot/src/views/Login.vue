<template>
         <v-container fluid fill-height class="container">
            <v-layout align-center justify-center>
               <v-flex xs12 sm8 md4>
                 <v-form ref="loginForm" @submit="submit">
                  <v-card class="elevation-12">
                     <v-card-title class="primary">Login form</v-card-title>
                     <v-card-text>
                           <v-text-field
                              :rules="generatedRules"
                              prepend-icon="person"
                              name="login"
                              label="Login"
                              type="text"
                              @input="error = null"
                           ></v-text-field>
                           <v-text-field
                              id="password"
                              :rules="generatedRules"
                              prepend-icon="lock"
                              name="password"
                              label="Password"
                              type="password"
                              @input="error = null"
                           ></v-text-field>
                           <p style="color: #ff1744">{{error}}</p>
                     </v-card-text>
                     <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn color="#16475A" class="mr-4 mt-5 mb-5 form-submit-btn" type="submit"> Submit </v-btn>
                     </v-card-actions>
                  </v-card>
                </v-form>
               </v-flex>
            </v-layout>
         </v-container>
</template>
<script>
import { mapActions } from 'vuex';

export default {
  data() {
    return {
      error: null,
    };
  },
  computed: {
    generatedRules() {
      const rules = [];
      rules.push((value) => !!value || 'Required.');
      return rules;
    },
  },
  methods: {
    ...mapActions([
      'getFields',
      'login',
    ]),
    submit(event) {
      event.preventDefault();
      const isValid = this.$refs.loginForm.validate();
      if (isValid) {
        this.login(new FormData(event.target)).then(() => {
          this.$router.push({ name: 'Reports' });
        }).catch((error) => {
          this.error = error.response.data;
        });
      }
    },
  },
};
</script>
<style>
    .primary {
        color: white !important;
    }
    .container {
        background: aliceblue;
    }
</style>
