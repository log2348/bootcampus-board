<template>
  <div class="container" style="padding: 20px">
    <div>
      <h2 style="text-align: center"><b>게시글 상세</b></h2>
    </div>
    <br />
    <br />
    <div class="container flex" style="text-align: right">
      <router-link to="/List"
        ><button class="btn btn-secondary">목록</button></router-link
      >&nbsp;
      <router-link :to="{ name: 'edit', params: { seq: board.BOARD_SEQ } }"
        ><button
          v-show="$store.state.userId == board.USER_ID"
          class="btn btn-success"
          @click="$store.state.mode = 'UPDATE'"
        >
          수정
        </button></router-link
      >&nbsp;
      <button
        v-show="$store.state.userId == board.USER_ID"
        class="btn btn-danger"
        @click="clickDeleteBtn"
      >
        삭제
      </button>
    </div>
    <br />
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
    <div class="container p-5 my-5 border">{{ board.CONTENTS }}</div>
    <Comment :boardSeq="$route.params.seq"></Comment>
    <Confirm :boardSeq="this.board.BOARD_SEQ"></Confirm>
  </div>
</template>

<script>
import service from "../services/service.js";
import Comment from "../components/Comment.vue";
import Confirm from "../components/Confirm.vue";

export default {
  data() {
    return {
      board: {},
    };
  },
  methods: {
    clickDeleteBtn() {
      this.$store.state.mode = "DELETE";
      this.$bvModal.show("modal-scoped");
    },
  },
  mounted() {
    // 게시글 정보 세팅
    service.getBoard(this.$route.params.seq).then((response) => {
      console.log(response);
      this.board = response;
    });
  },
  components: {
    Comment,
    Confirm,
  },
};
</script>

<style></style>
