import Vue from "vue";
import Vuex from "vuex";
import service from "../services/service.js";
import router from "../router/index.js";

Vue.use(Vuex);

export default new Vuex.Store({
  state() {
    return {
      mode: "UPDATE",
      // 로그인된 유저 정보
      userId: "",
      password: "",

      totalRow: "",

      boardList: [],
      filteredList: [],
      stateList: [],
      replyP: [], // 부모 댓글
      replyC: [], // 자식 댓글
      isFiltered: false,
      isAuthenticated: false,
    };
  },
  actions: {},
  mutations: {
    /**
     * 게시글 전체 목록 조회
     */
    GET_BOARD_LIST(state) {
      service.getBoardList().then((response) => {
        state.boardList = response;
        // 상태 정보 배열에 담기
        state.stateList = Array.from(new Set(response.map((a) => a.STATE)));
      });
    },

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

            alert("게시글이 등록되었습니다.");

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
     * 게시글 삭제
     */
    DELETE_BOARD(state, boardSeq) {
      service
        .deleteBoard(boardSeq)
        .then((response) => {
          if (response == 1) {
            alert("게시글이 삭제되었습니다.");
            router.push("/List");
          } else {
            alert("게시글이 삭제되지 않았습니다.");
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

    /**
     * 게시글 수정
     */
    UPDATE_BOARD(state, boardData) {
      service
        .updateBoard(boardData)
        .then((response) => {
          if (response == 1) {
            alert("수정이 완료되었습니다.");
          } else {
            alert("수정이 완료되지 않았습니다");
          }
        })
        .catch((error) => {
          alert("수정 실패. 다시 시도해주세요.");
          console.log(error);
        });
    },

    /**
     * 댓글 목록 조회
     */
    GET_REPLY_LIST(state, boardSeq) {
      service
        .getReplyList(boardSeq)
        .then((response) => {
          console.log(response);
          // 댓글, 대댓글 구분해서 넣기
          response.forEach((element) => {
            if (element.PARENT_SEQ != 0) {
              state.replyC.push(element);
            } else {
              state.replyP.push(element);
            }
            console.log(state.replyP);
            console.log(state.replyC);
          });
        })
        .catch((error) => {
          console.log(error);
        });
    },

    /**
     * 댓글 등록
     */
    CREATE_REPLY(state, replyData) {
      service
        .createReply(replyData)
        .then((response) => {
          if (response == 1) {
            state.replyP.push(replyData);
          } else {
            alert("댓글이 등록되지 않았습니다.");
          }
        })
        .catch((error) => {
          console.log(error);
        });
    },

    /**
     * 댓글 삭제
     */
    DELETE_REPLY(state, replySeq) {
      service
        .deleteReply(replySeq)
        .then((response) => {
          if (response == 1) {
            state.replyP.fillter((a) => a.REPLY_SEQ != replySeq);
            alert("댓글이 삭제되었습니다.");
          } else {
            alert("댓글이 삭제되지 않았습니다.");
          }
        })
        .catch((error) => {
          console.log(error);
        });
    },

    /**
     * 댓글 수정
     */
    UPDATE_REPLY(state, replayData) {
      service
        .updateReply(replayData)
        .then((response) => {
          console.log(response);
        })
        .catch((error) => {
          console.log(error);
        });
    },

    /**
     * 상태 업데이트
     */
    UPDATE_STATUS(state, data) {
      service.updateStatus(data).then((response) => {
        if (response == 1) {
          alert("게시글의 상태가 변경되었습니다.");
          router.push("/List");
        } else {
          alert("게시글의 상태가 변경되지 않았습니다.");
        }
      });
    },

    /**
     * 총 게시글 개수 가져오기
     */
    GET_TOTAL_BOARD_COUNT(state) {
      service
        .getTotalBoardCount()
        .then((response) => {
          state.totalRow = response;
        })
        .catch((error) => {
          console.log(error);
        });
    },
  },
  getters: {},
});
