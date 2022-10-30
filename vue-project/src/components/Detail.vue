<template>
  <div class="container" style="padding: 20px">
    <div>
      <h2 style="text-align: center"><b>게시글 상세</b></h2>
    </div>
    <br />
    <br />
    <div class="container flex" style="text-align: right">
      <b-button variant="light" @click="$bvModal.show('update-status-modal')"
        >상태 업데이트</b-button
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
        @click="clickDeleteBtn()"
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
          <td>{{ $moment(board.WRITE_DATE).format("YYYY-MM-DD") }}</td>
          <th>조회수</th>
          <td>{{ board.VIEW_COUNT }}</td>
        </tr>
      </tbody>
    </table>
    <div class="row">
      <img class="col" :src="imageSrc" style="width: 300px; height: 300px" />
      <div class="col border" style="height: 300px">
        {{ board.CONTENTS }}
      </div>
    </div>
    <div style="text-align: right">
      <br />
      <router-link to="/List"
        ><button class="btn btn-light">목록</button></router-link
      >
    </div>
    <Comment :boardSeq="$route.params.seq"></Comment>
    <Confirm :boardSeq="this.board.BOARD_SEQ"></Confirm>
    <StatusUpdate
      :status="this.board.STATE"
      :boardSeq="this.board.BOARD_SEQ"
      :showModal="showModal"
    ></StatusUpdate>
  </div>
</template>

<script>
import service from "../services/service.js";
import Comment from "../components/Comment.vue";
import Confirm from "../components/Confirm.vue";
import StatusUpdate from "../components/StatusUpdate.vue";

export default {
  data() {
    return {
      board: {},
      imageSeq: "",
      imageSrc: "data:image/jpg;base64,",
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
    service
      .getImage(17)
      .then((response) => (this.imageSrc += response));
  },
  components: {
    Comment,
    Confirm,
    StatusUpdate,
  },
};
</script>

<style></style>
