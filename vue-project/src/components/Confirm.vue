<template>
  <div>
    <b-modal id="modal-scoped">
      <template>
        <h3 v-if="$store.state.mode == 'UPDATE'">수정하시겠습니까?</h3>
        <h3 v-else-if="$store.state.mode == 'DELETE'">삭제하시겠습니까?</h3>
        <h3 v-else>저장하시겠습니까?</h3>
      </template>

      <template #modal-footer>
        <b-button
          v-if="$store.state.mode == 'UPDATE'"
          size="m"
          variant="success"
          @click="updateBoard()"
        >
          확인
        </b-button>
        <b-button
          v-else-if="$store.state.mode == 'CREATE'"
          size="m"
          variant="success"
          @click="setBoard()"
        >
          확인
        </b-button>
        <b-button v-else size="m" variant="success" @click="deleteBoard()">
          확인
        </b-button>
        <b-button size="m" variant="danger"> 취소 </b-button>
      </template>
    </b-modal>
  </div>
</template>

<script>
export default {
  props: ["title", "contents", "boardSeq", "board", "imageSubmit", "isClicked"],
  methods: {
    setBoard() {
      let data = {
        TITLE: this.title,
        CONTENTS: this.contents,
        USER_ID: this.$store.state.userId,
      };

      if (data.TITLE == "") {
        alert("제목을 입력하세요.");
        return;
      }

      if (data.CONTENTS == "") {
        alert("내용을 입력하세요.");
        return;
      }
      this.$store.commit("SET_BOARD", data);
    },

    updateBoard() {
      let data = {
        TITLE: this.board.TITLE,
        CONTENTS: this.board.CONTENTS,
        BOARD_SEQ: this.board.BOARD_SEQ,
        STATE: this.board.STATE,
        USER_ID: this.$store.state.userId,
      };
      this.$store.commit("UPDATE_BOARD", data);
      this.$router.push("/Board/Detail/" + this.board.BOARD_SEQ);
    },

    deleteBoard() {
      this.$store.commit("DELETE_BOARD", this.boardSeq);
    },
  },
};
</script>

<style>
/* TODO */
.close {
  display: none;
}
</style>
