import axios from "axios";

const service = {
  /**
   *
   * @param {username}
   * @param {password}
   */
  login(params) {
    const data = axios
      .post("/User/Login", {
        params,
      })
      .then((response) => {
        console.log(response);
      });

    return data;
  },

  /**
   *
   * @returns
   */
  getBoard(seq) {
    const params = {
      seq: seq
    }
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
   * 로그인
   */
};

export default service;
