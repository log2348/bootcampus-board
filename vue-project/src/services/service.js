import axios from "axios";
//import router from "../router/index.js";
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
        USERNAME: userData.USERNAME,
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
          store.state.username = userData.USERNAME;
          store.state.password = userData.PASSWORD;
          store.state.isAuthenticated = true;
          //router.push("/List");
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
};

export default service;
