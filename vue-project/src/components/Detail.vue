<template>
  <div class="container" style="padding: 20px">
    <div>
      <h2>게시글 상세</h2>
    </div>
    <br />
    <br />
    <div>
      <router-link :to="{ name: 'edit', params: { boardSeq: board.BOARD_SEQ } }"
        ><button class="btn btn-primary" @click="$store.state.mode = 'UPDATE'">
          수정
        </button></router-link
      >&nbsp;
      <button
        class="btn btn-primary"
        @click="$bvModal.show('modal-scoped')"
      >
        <!-- @click="$store.commit('DELETE_BOARD', board.BOARD_SEQ)" -->
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
    <Comment></Comment>
    <Confirm></Confirm>
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
  mounted() {
    service.getBoard(this.$route.params.seq).then((response) => {
      console.log(response);
      this.board = response;
    });
  },
  components: {
    Comment,
    Confirm
  },
};
</script>

<style></style>
