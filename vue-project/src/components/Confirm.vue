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
          @click="update()"
        >
          확인
        </b-button>
        <b-button
          v-else-if="$store.state.mode == 'CREATE'"
          size="m"
          variant="success"
          @click="save()"
        >
          확인
        </b-button>
        <b-button v-else size="m" variant="success" @click="deleteBoard()">
          확인
        </b-button>
        <b-button size="m" variant="danger" @click="cancel()"> 취소 </b-button>
      </template>
    </b-modal>
  </div>
</template>

<script>
export default {
  props: ["title", "contents", "boardSeq"],
  methods: {
    save() {
      let data = {
        TITLE: this.title,
        CONTENTS: this.contents,
        USER_ID: this.$store.state.userId,
      };
      this.$store.commit("CREATE_BOARD", data);
    },

    update() {
      let data = {
        TITLE: this.title,
        CONTENTS: this.contents,
        BOARD_SEQ: 11,
        STATE: "",
        USER_ID: this.$store.state.userId,
      };
      this.$store.commit("UPDATE_BOARD", data);
      this.$route.push('/List');
    },
    deleteBoard() {
      this.$store.commit('DELETE_BOARD', this.boardSeq);
    },
  },
};
</script>

<style>
/* TODO */
.close {
  display: "none";
}
</style>
