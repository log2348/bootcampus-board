import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

export default new Vuex.Store({
  state() {
    return {
      username: "",
      password: "",
      boardList: []
    }
  },
  actions: {

  },
  mutations: {
    // LOGIN(state, data) {
    //   if (data.username == "") {
    //     alert("아이디를 입력하세요.");
    //     return;
    //   }

    //   if (data.password == "") {
    //     alert("비밀번호를 입력하세요.");
    //     return;
    //   }
      
    // }
  },
  getters: {

  }
});
