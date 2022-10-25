import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

export default new Vuex.Store({
  state() {
    return {
      // 로그인된 유저 정보
      username: "",
      password: "",
      isAuthenticated: false,
      boardList: []
    }
  },
  actions: {

  },
  mutations: {

  },
  getters: {

  }
});
