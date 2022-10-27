<template>
  <div>
    <label for="comment"><b>> 댓글</b></label>
    <br />
    <textarea class="form-control" rows="3" v-model="contents"></textarea>
    <br />
    <div style="text-align: right">
      <button class="btn btn-secondary" @click="saveReply">등록</button>
    </div>
    <br />

    <ul class="list-group">
      <li
        class="list-group-item"
        v-for="parent in $store.state.replyP"
        :key="parent.REPLY_SEQ"
      >
        <div class="container">
          <span>
            <b>{{ parent.USER_ID }}</b
            >&nbsp;&nbsp;<span>({{ parent.WRITE_DATE }})</span>
            &nbsp;&nbsp;&nbsp;<span
              type="button"
              style="color: blue; text-align: end"
              v-show="$store.state.userId == parent.USER_ID"
              >수정</span
            >&nbsp;<span
              type="button"
              @click="deleteReply(parent.REPLY_SEQ)"
              style="color: red; text-align: end"
              v-show="$store.state.userId == parent.USER_ID"
              >삭제</span
            >
          </span>
        </div>
        <div class="container">
          {{ parent.REPLY_CONTENTS }}
        </div>
        <div style="text-align: right">
          답변 달기
          <i
            type="button"
            class="bi bi-arrow-return-left"
            @click="clickComment()"
          ></i>
        </div>
        <br />

        <!-- Re-reply Container -->
        <div class="container" v-if="isShow">
          <textarea
            class="form-control"
            rows="3"
            v-model="reContents"
          ></textarea>
          <button class="btn btn-primary" @click="addReply(parentSeq)">
            등록
          </button>
          <br />
          <br />

          <!-- Re-reply 목록 -->
          <ul v-for="item in $store.state.replyC" :key="item.REPLY_SEQ">
            <li
              class="list-group-item"
              v-if="item.PARENT_SEQ == parent.REPLY_SEQ"
            >
              <div class="container">
                <span>
                  <b>{{ item.USER_ID }}</b
                  >&nbsp;&nbsp;<span>{{ item.WRITE_DATE }}</span>
                  &nbsp;&nbsp;&nbsp;<span
                    type="button"
                    style="color: blue; text-align: end"
                    v-show="$store.state.userId == item.USER_ID"
                    @click="clickUpdateBtn()"
                    >수정</span
                  >&nbsp;<span
                    type="button"
                    @click="deleteReply(item.REPLY_SEQ)"
                    style="color: red; text-align: end"
                    v-show="$store.state.userId == item.USER_ID"
                    >삭제</span
                  >
                </span>
              </div>
              <div class="container">
                {{ item.REPLY_CONTENTS }}
              </div>
              <div style="text-align: right">
                답변 달기
                <i
                  type="button"
                  class="bi bi-arrow-return-left"
                  @click="clickComment()"
                ></i>
              </div>
            </li>
          </ul>
        </div>
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
      reContents: "",
      parentSeq: "",
      childSeq: "",
      isShow: false,
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

    // 대댓글 등록 버튼 클릭
    clickComment() {
      this.isShow = !this.isShow;
    },

    // 수정 버튼 클릭
    clickUpdateBtn() {

    },

    // 대댓글 등록
    addReply(parentSeq) {
      let replyData = {
        USER_ID: this.$store.state.userId,
        BOARD_SEQ: this.boardSeq,
        PARENT_SEQ: parentSeq,
        REPLY_CONTENTS: this.reContents,
      };
      this.$store.commit("CREATE_REPLY", replyData);
      this.contents = "";
    },
  },
};
</script>

<style></style>
