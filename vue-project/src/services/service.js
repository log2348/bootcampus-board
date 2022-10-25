import axios from "axios";
import router from "../router/index.js";
import store from "../store/index.js";

const service = {
  /**
   *
   * @param {*} params
   * @returns
   */
  login(userData) {
    const data = axios
      .post("/User/Login", {
        USER_ID: userData.USER_ID,
        PASSWORD: userData.PASSWORD,
      })
      .then(function (response) {
        if (response.data != 1) {
          if (response.data == 0) {
            alert("비밀번호가 일치하지 않습니다.");
            return;
          }

          if (response.data == -1) {
            alert("아이디가 존재하지 않습니다.");
            return;
          }
        }

        if (response.data == 1) {
          alert("로그인 성공");
          store.state.userId = userData.USER_ID;
          store.state.password = userData.PASSWORD;
          store.state.isAuthenticated = true;
          router.push("/List");
        }

        return response.data;
      })
      .catch(function (error) {
        console.log(error);
      });
    return data;
  },

  /**
   *
   * @returns
   */
  getBoard(seq) {
    const params = {
      seq: seq,
    };
    const data = axios
      .get("/Board/Detail", { params })
      .then((response) => response.data);
    return data;
  },

  /**
   * 게시글 전체 목록 조회
   */
  getBoardList() {
    const data = axios
      .get("/Board/BoardList")
      .then((response) => response.data);
    return data;
  },

  /**
   * 상태별 게시글 목록 조회
   */
  getListByState(state) {
    const params = {
      state: state,
    };
    const data = axios
      .get("/Board/BoardListByState", { params })
      .then((response) => response.data);
    return data;
  },

  /**
   * 게시글 검색
   */
  searchBoard(searchData) {
    const params = {
      searchType: searchData.searchType,
      searchWord: searchData.searchWord,
    };
    const data = axios
      .get("/Board/Search", { params })
      .then((response) => response.data)
      .catch((error) => console.log(error));

    return data;
  },

  /**
   * 게시글 등록
   */
  createBoard(boardData) {
    const params = {
      STATE: boardData.STATE,
      TITLE: boardData.TITLE,
      CONTENTS: boardData.CONTENTS,
      USER_ID: boardData.USER_ID,
    };
    const data = axios
      .get("/Board/Create", { params })
      .then((response) => response.data)
      .catch((error) => console.log(error));

    return data;
  },

  /**
   * 게시글 삭제
   */
  deleteBoard(boardSeq) {
    const params = {
      boardSeq: boardSeq,
    };
    const data = axios
      .get("/Board/Delete", { params })
      .then((response) => response.data)
      .catch((error) => console.log(error));

    router.push("/List");

    return data;
  },

  /**
   * 게시글 페이징
   */
  selectPage(pageNumber) {
    const data = axios
      .get("/Board/BoardPage", pageNumber)
      .then((response) => response.data)
      .catch((error) => console.log(error));

    return data;
  },

  /**
   * 게시글 수정
   */
  updateBoard(boardData) {
    const data = axios
      .post("/Board/Update", boardData)
      .then((response) => response.data)
      .catch((error) => console.log(error));

    return data;
  },

  /**
   * 댓글 목록 조회
   */
  getReplyList(boardSeq) {
    const data = axios
      .get("/Reply/ReplyList", boardSeq)
      .then((response) => response.data)
      .catch((error) => console.log(error));

      return data;
  },
};

export default service;
