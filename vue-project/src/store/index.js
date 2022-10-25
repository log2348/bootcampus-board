import Vue from "vue";
import Vuex from "vuex";
import service from "../services/service";

Vue.use(Vuex);

export default new Vuex.Store({
  state() {
    return {
      // 로그인된 유저 정보
      userId: "",
      password: "",
      isAuthenticated: false,
      boardList: [],
    };
  },
  actions: {},
  mutations: {
    /**
     * 게시글 등록
     */
    CREATE_BOARD(state, data) {
      if (data.TITLE == "") {
        alert("제목을 입력하세요");
        return;
      }

      if (data.CONTENTS == "") {
        alert("내용을 입력하세요");
        return;
      }

      service
        .createBoard(data)
        .then((response) => {
          if (response == 1) {
            state.boardList.push();
            alert("저장 성공");
            // 등록 성공시 목록 화면으로 이동
            this.$router.push("/List");
          } else {
            alert("게시글이 등록되지 않았습니다.");
          }
        })
        .catch((error) => {
          console.log(error);
        });
    },
  },
  getters: {},
});
