<template>
  <div>
    <b-modal id="modal-scoped">
      <template>
        <h3>저장(수정)하시겠습니까?</h3>
      </template>

      <template #modal-footer>
        <b-button size="m" variant="success" @click="save()"> 확인 </b-button>
        <b-button size="m" variant="danger" @click="cancel()"> 취소 </b-button>
      </template>
    </b-modal>
  </div>
</template>

<script>
export default {
  props: ["title", "contents"],
  methods: {
    save() {
      let data = {
        TITLE: this.title,
        CONTENTS: this.contents,
        USER_ID: this.$store.state.userId,
      };
      this.$store.commit("CREATE_BOARD", data);
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
