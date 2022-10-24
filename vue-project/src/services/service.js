import axios from "axios";

const service = {
  /**
   * @param {*} params
   */
  getNoticeList(params) {
    const data = axios.get("/Notice/NoticeList", params).then((response) => {
      console.log(response);
    });

    return data;
  },

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

  // test API
  getBoard() {
    const data = axios
      .get("/Board/Board")
      .then((response) => {
        console.log(response);
      });

    return data;
  },
};

export default service;
