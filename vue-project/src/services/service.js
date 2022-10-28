import axios from "axios";

const service = {
  /**
   *
   * 로그인
   */
  Login(userData) {
    const data = axios
      .post("/User/Login", {
        USER_ID: userData.USER_ID,
        PASSWORD: userData.PASSWORD,
      })
      .then((response) => response.data)
      .catch(function (error) {
        console.log(error);
      });
    return data;
  },

  /**
   *
   * 게시글 상세 조회
   */
  GetBoard(seq) {
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
  GetBoardList() {
    const data = axios
      .get("/Board/BoardList")
      .then((response) => response.data);
    return data;
  },

  /**
   * 상태별 게시글 목록 조회
   */
  GetListByState(state) {
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
  SearchBoard(searchData) {
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
  CreateBoard(boardData) {
    const params = {
      STATE: boardData.STATE,
      TITLE: boardData.TITLE,
      CONTENTS: boardData.CONTENTS,
      USER_ID: boardData.USER_ID,
    };
    const data = axios
      .post("/Board/Create", null, { params })
      .then((response) => response.data)
      .catch((error) => console.log(error));

    return data;
  },

  /**
   * 게시글 삭제
   */
  DeleteBoard(boardSeq) {
    const params = {
      boardSeq: boardSeq,
    };
    const data = axios
      .get("/Board/Delete", { params })
      .then((response) => response.data)
      .catch((error) => console.log(error));

    return data;
  },

  /**
   * 게시글 페이징
   */
  SelectPage(pageNumber) {
    const params = {
      pageNumber: pageNumber,
    };
    const data = axios
      .get("/Board/BoardPage", { params })
      .then((response) => response.data)
      .catch((error) => console.log(error));

    return data;
  },

  /**
   * 게시글 수정
   */
  UpdateBoard(boardData) {
    const params = {
      BOARD_SEQ: boardData.BOARD_SEQ,
      STATE: boardData.STATE,
      TITLE: boardData.TITLE,
      USER_ID: boardData.USER_ID,
      CONTENTS: boardData.CONTENTS,
    };
    const data = axios
      // axios post의 두 번째 인자를 null로 주고, 세 번째 인자에 매개변수를 주어야 한다.
      .post("/Board/Update", null, { params })
      .then((response) => response.data)
      .catch((error) => console.log(error));

    return data;
  },

  /**
   * 댓글 목록 조회
   */
  GetReplyList(boardSeq) {
    const params = {
      boardSeq: boardSeq,
    };
    const data = axios
      .get("/Reply/ReplyList", { params })
      .then((response) => response.data)
      .catch((error) => console.log(error));

    return data;
  },

  /**
   * 댓글 등록
   */
  CreateReply(replyData) {
    const data = axios
      .post("/Reply/Create", replyData)
      .then((response) => response.data)
      .catch((error) => console.log(error));

    return data;
  },

  /**
   * 댓글 삭제
   */
  DeleteReply(replySeq) {
    const params = {
      replySeq: replySeq,
    };
    const data = axios
      .get("/Reply/Delete", { params })
      .then((response) => response.data)
      .catch((error) => console.log(error));

    return data;
  },

  /**
   * 댓글 수정
   */
  UpdateReply(replyData) {
    const params = {
      REPLY_SEQ: replyData.REPLY_SEQ,
      CONTENTS: replyData.CONTENTS,
    };
    const data = axios
      .post("/Reply/Update", null, { params })
      .then((response) => response.data)
      .catch((error) => console.log(error));
    return data;
  },

  /**
   * 상태 업데이트
   */
  UpdateStatus(boardData) {
    const params = {
      boardSeq: boardData.boardSeq,
      state: boardData.state,
    };
    const data = axios
      .post("/Board/UpdateState", null, { params })
      .then((response) => response.data)
      .catch((error) => console.log(error));

    return data;
  },

  /**
   * 총 게시물 개수 가져오기
   */
  GetTotalBoardCount() {
    const data = axios
      .get("/Board/TotalRowCount")
      .then((response) => response.data)
      .catch((error) => console.log(error));
    return data;
  },
};

export default service;
