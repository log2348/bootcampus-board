import axios from "axios";

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
      .then(function(response) {
        this.$store.state.username = userData.USERNAME;
        this.$store.state.password = userData.PASSWORD;
        console.log(response);
      })
      .catch(function(error) {
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
   * 로그인
   */
};

export default service;
