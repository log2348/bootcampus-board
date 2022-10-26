<template>
  <div>
    <label for="comment"><b>> 댓글</b></label>
    <br />
    <textarea class="form-control" rows="3" v-model="contents"></textarea>
    <br />
    <div style="text-align: right">
      <button class="btn btn-primary" @click="saveReply">등록</button>
    </div>
    <br />

    <ul
      class="list-group"
      v-for="item in $store.state.replyList"
      :key="item.REPLY_SEQ"
    >
      <li class="list-group-item">
        <input type="hidden" v-model="replySeq" value=item.REPLY_SEQ />
        <div>
          <span>
            <b>{{ item.USER_ID }}</b
            ><span>현재날짜</span>
            <span
              @click="deleteReply(replySeq)"
              style="color: red; cursor: pointer"
              >삭제</span
            >
          </span>
        </div>
        {{ item.REPLY_CONTENTS }}
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  data() {
    return {
      contents: "",
      replySeq: "",
    };
  },
  props: ["boardSeq"],
  mounted() {
    this.$store.commit("GET_REPLY_LIST", this.boardSeq);
  },
  methods: {
    saveReply() {
      let replyData = {
        REPLY_CONTENTS: this.contents,
        USER_ID: this.$store.state.userId,
        BOARD_SEQ: this.boardSeq,
      };
      this.$store.commit("CREATE_REPLY", replyData);
      this.contents = "";
    },

    deleteReply(replySeq) {
      this.$store.commit("DELETE_REPLY", replySeq);
    },
  },
};
</script>

<style></style>
