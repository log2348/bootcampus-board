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
  getBoard() {
    const data = axios.get("/Board/Board").then((response) => response.data);
    return data;
  },

  /**
   * Board List 조회
   */
  getBoardList() {
    const data = axios
      .get("/Board/BoardList")
      .then((response) => response.data);
    return data;
  },
};

export default service;
