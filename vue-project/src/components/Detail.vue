<template>
  <div class="container" style="padding: 20px">
    <div>
      <h2>게시글 상세</h2>
    </div>
    <br />
    <br />
    <div>
      <button class="btn btn-primary">수정</button>
      <button
        class="btn btn-primary"
        @click="$store.commit('DELETE_BOARD', board.BOARD_SEQ)"
      >
        삭제
      </button>
    </div>
    <table class="table table-bordered">
      <thead>
        <tr>
          <th>제목</th>
          <td>{{ board.TITLE }}</td>
        </tr>
      </thead>
      <tbody>
        <tr>
          <th>작성자</th>
          <td>{{ board.USER_ID }}</td>
          <th>작성일</th>
          <td>{{ board.WRITE_DATE }}</td>
          <th>조회수</th>
          <td>{{ board.VIEW_COUNT }}</td>
        </tr>
      </tbody>
    </table>
    <div style="border: 1px">{{ board.CONTENTS }}</div>
    <Comment></Comment>
  </div>
</template>

<script>
import service from "../services/service.js";
import Comment from "../components/Comment.vue";

export default {
  data() {
    return {
      board: {},
    };
  },
  mounted() {
    service.getBoard(this.$route.params.seq).then((response) => {
      console.log(response);
      this.board = response;
    });
  },
  components: {
    Comment,
  },
};
</script>

<style></style>
