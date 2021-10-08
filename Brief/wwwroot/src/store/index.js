import Vue from 'vue';
import Vuex from 'vuex';
import request from '../services/request';

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    formConfig: [],
    isLoading: false,
  },
  getters: {
    sections: (state) => state.formConfig,
    isLoading: (state) => state.isLoading,
  },
  mutations: {
    SET_FIELDS(state, { sections }) {
      state.formConfig = sections;
      state.isLoading = false;
    },
    SET_LOADING_STATE(state, isLoading) {
      state.isLoading = isLoading;
    },
  },
  actions: {
    async getFields({ commit }) {
      commit('SET_LOADING_STATE', true);
      const { data } = await request.get('/brief');
      commit('SET_FIELDS', data);
    },
  },
  modules: {
  },
});
