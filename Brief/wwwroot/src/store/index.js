/* eslint-disable no-param-reassign */
import Vue from 'vue';
import Vuex from 'vuex';
import { DateTime } from 'luxon';
import request from '../services/request';

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    formConfig: [],
    isLoading: false,
    submittedForms: [],
    isAuthorized: JSON.parse(localStorage.getItem('isAuthorized')),
  },
  getters: {
    sections: (state) => state.formConfig,
    isLoading: (state) => state.isLoading,
    submittedForms: (state) => state.submittedForms,
    isAuthorized: (state) => state.isAuthorized,
  },
  mutations: {
    SET_FIELDS(state, { sections }) {
      state.formConfig = sections;
      state.isLoading = false;
    },
    SET_LOADING_STATE(state, isLoading) {
      state.isLoading = isLoading;
    },
    SET_SUBBMITED_FORMS(state, forms) {
      forms.forEach((x) => {
        x.data = JSON.parse(x.serializedForm);
        x.date = DateTime.fromISO(x.date);
      });
      state.submittedForms = forms;
      state.isLoading = false;
    },
    DELETE_FORM(state, id) {
      state.isLoading = false;
      const index = state.submittedForms.findIndex((x) => x.id === id);
      if (index !== -1) {
        state.submittedForms.splice(index, 1);
      }
    },
    SET_USER(state) {
      state.isAuthorized = true;
      localStorage.setItem('isAuthorized', JSON.stringify(true));
    },
  },
  actions: {
    async getFields({ commit }) {
      commit('SET_LOADING_STATE', true);
      const { data } = await request.get('/brief');
      commit('SET_FIELDS', data);
    },
    async getSubmittedForms({ commit }) {
      commit('SET_LOADING_STATE', true);
      const { data } = await request.get('/admin/forms');
      commit('SET_SUBBMITED_FORMS', data);
    },
    async deleteSubmittedForm({ commit }, id) {
      commit('SET_LOADING_STATE', true);
      try {
        await request.delete('/admin/deleteForm', { params: { id } });
      } finally {
        commit('DELETE_FORM', id);
      }
    },
    async login({ commit }, data) {
      try {
        await request.post('/admin/loginUser', data);
        commit('SET_USER');
      } catch (error) {
        console.log(error);
      }
    },
  },
  modules: {
  },
});
