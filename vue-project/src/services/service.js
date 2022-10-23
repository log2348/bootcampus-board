import axios from "axios";

const service = {
  /**
   * [참고] 공지사항 목록 조회
   * @param {*} params 
   */
  getNoticeList(params) {
    const data = axios
    .get(
      "/Notice/NoticeList", 
      params
    )
    .then(response => {
      console.log(response);
    });

    return data;
  }
};

export default service;