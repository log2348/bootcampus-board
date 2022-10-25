import Vue from "vue";
import Vuex from "vuex";
import service from "../services/service.js";
import router from "../router/index.js";

Vue.use(Vuex);

export default new Vuex.Store({
  state() {
    return {
      // 로그인된 유저 정보
      userId: "",
      password: "",
      boardList: [],
      filteredList: [],
      isFiltered: false,
      isAuthenticated: false,
    };
  },
  actions: {},
  mutations: {
    /**
     * 상태별 게시글 목록 조회
     */
    GET_LIST_BY_STATE(state, data) {
      service.getListByState(data).then((response) => {
        if (data != "전체") {
          state.isFiltered = true;
          state.filteredList = response;
        } else {
          state.isFiltered = false;
        }
      });
    },

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
            router.push("/List");
          } else {
            alert("게시글이 등록되지 않았습니다.");
          }
        })
        .catch((error) => {
          console.log(error);
        });
    },

    /**
     * 게시글 검색
     */
    SEARCH_BOARD(state, data) {
      service
        .searchBoard(data)
        .then((response) => {
          console.log(response);
          if (data.searchWord == "") {
            state.isFiltered = false;
          } else {
            state.isFiltered = true;
            state.filteredList = response;
          }
        })
        .catch((error) => {
          console.log(error);
        });
    },

    /**
     * 게시글 페이징
     */
    SELECT_PAGE(state, pageNumber) {
      service
        .selectPage(pageNumber)
        .then((response) => {
          state.boardList = response;
        })
        .catch((error) => {
          console.log(error);
        });
    },
  },
  getters: {},
});
