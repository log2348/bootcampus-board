<template>
  <div>
    <label for="comment"><b>> 댓글</b></label>
    <br />
    <textarea class="form-control" rows="3" v-model="contents"></textarea>
    <br />
    <div style="text-align: right">
      <button class="btn btn-secondary" @click="setReply()">등록</button>
    </div>
    <br />

    <ul class="list-group">
      <li
        class="list-group-item"
        v-for="parent in parentReplies"
        :key="parent.REPLY_SEQ"
      >
        <!-- 상위 댓글 목록 -->
        <div class="container">
          <span>
            <b>{{ parent.USER_ID }}</b
            >&nbsp;&nbsp;<span>({{ parent.WRITE_DATE }})</span>
            &nbsp;&nbsp;&nbsp;<span
              type="button"
              style="color: blue; text-align: end"
              v-show="$store.state.userId == parent.USER_ID"
              @click="clickUpdateBtn(parent.REPLY_SEQ)"
              >수정</span
            >&nbsp;<span
              type="button"
              v-show="$store.state.userId == parent.USER_ID"
              @click="deleteReply(parent.REPLY_SEQ)"
              style="color: red; text-align: end"
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
            @click="clickComment(parent.REPLY_SEQ)"
          ></i>
        </div>
        <br />

        <!-- 댓글 수정 폼 -->
        <div class="container" v-show="isUpdated" :id="parent.REPLY_SEQ">
          <textarea
            class="form-control"
            rows="3"
            v-model="updateContents"
          ></textarea>
          <button
            class="btn btn-primary"
            @click="updateReply(parent.REPLY_SEQ)"
          >
            수정
          </button>
        </div>
        <br />

        <!-- 대댓글 작성 폼 -->
        <div class="container" v-show="isReplied">
          <input type="hidden" ref="reply" :value="parent.REPLY_SEQ" />
          <textarea
            class="form-control"
            rows="3"
            v-model="childContents"
          ></textarea>

          <button class="btn btn-primary" @click="setReReply(parent.REPLY_SEQ)">
            등록
          </button>
        </div>

        <!-- 하위 댓글 목록 -->
        <ul v-for="child in childReplies" :key="child.REPLY_SEQ">
          <li
            class="list-group-item"
            v-if="child.PARENT_SEQ == parent.REPLY_SEQ"
          >
            <div class="container">
              <span>
                <b>{{ child.USER_ID }}</b
                >&nbsp;&nbsp;<span>{{ child.WRITE_DATE }}</span>
                &nbsp;&nbsp;&nbsp;<span
                  type="button"
                  style="color: blue; text-align: end"
                  v-show="$store.state.userId == child.USER_ID"
                  @click="isReplyUpdated = !isReplyUpdated"
                  >수정</span
                >&nbsp;<span
                  type="button"
                  @click="deleteReply(child.REPLY_SEQ)"
                  style="color: red; text-align: end"
                  v-show="$store.state.userId == child.USER_ID"
                  >삭제</span
                >
              </span>
            </div>
            <div class="container">
              {{ child.REPLY_CONTENTS }}
            </div>
            <div style="text-align: right">
              답변 달기
              <i
                type="button"
                class="bi bi-arrow-return-left"
                @click="clickComment(parent.REPLY_SEQ, child.REPLY_SEQ)"
              ></i>
            </div>
            <br />
            <!-- 대댓글 수정 폼 -->
            <div class="container" v-show="isReplyUpdated">
              <textarea
                class="form-control"
                rows="3"
                v-model="updateReplyContents"
              ></textarea>
              <button
                class="btn btn-primary"
                @click="updateReReply(child.REPLY_SEQ)"
              >
                수정
              </button>
            </div>
            <br />
          </li>
        </ul>
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
      childContents: "",
      updateContents: "",
      updateReplyContents: "",
      parentSeq: "",
      childSeq: "",
      isReplied: false,
      isUpdated: false,
      isReplyUpdated: false,
    };
  },
  props: ["boardSeq"],
  mounted() {
    this.$store.commit("GET_REPLY_LIST", this.boardSeq);
  },
  computed: {
    parentReplies() {
      return this.$store.state.replyList.filter((a) => a.LEVEL == 0);
    },

    childReplies() {
      return this.$store.state.replyList.filter((a) => a.LEVEL != 0);
    },
  },
  methods: {
    // 댓글 등록
    setReply() {
      let replyData = {
        REPLY_CONTENTS: this.contents,
        USER_ID: this.$store.state.userId,
        BOARD_SEQ: this.boardSeq,
      };
      this.$store.commit("SET_REPLY", replyData);

      this.contents = "";
      this.$store.commit("GET_REPLY_LIST", this.boardSeq);
    },

    // 대댓글 등록
    setReReply(parentSeq) {
      let replyData = {
        USER_ID: this.$store.state.userId,
        BOARD_SEQ: this.boardSeq,
        PARENT_SEQ: parentSeq,
        REPLY_CONTENTS: this.childContents,
      };
      this.$store.commit("SET_REPLY", replyData);
      this.isReplied = !this.isReplied;
      this.childContents = "";
      this.$store.commit("GET_REPLY_LIST", this.boardSeq);
    },

    // 수정 버튼 클릭
    clickUpdateBtn() {
      this.isUpdated = !this.isUpdated;
    },

    // 답변 달기 버튼 클릭
    clickComment() {
      this.isReplied = !this.isReplied;
    },

    deleteReply(replySeq) {
      this.$store.commit("DELETE_REPLY", replySeq);
      this.$store.commit("GET_REPLY_LIST", this.boardSeq);
    },

    // 댓글 수정
    updateReply(replySeq) {
      let replyData = {
        REPLY_SEQ: replySeq,
        REPLY_CONTENTS: this.updateContents,
      };
      this.$store.commit("UPDATE_REPLY", replyData);
      this.updateContents = "";
      this.isUpdated = !this.isUpdated;
      this.$store.commit("GET_REPLY_LIST", this.boardSeq);
    },

    // 대댓글 수정
    updateReReply(replySeq) {
      let replyData = {
        REPLY_SEQ: replySeq,
        REPLY_CONTENTS: this.updateReplyContents,
      };
      this.$store.commit("UPDATE_REPLY", replyData);
      this.updateReplyContents = "";
      this.isReplyUpdated = !this.isReplyUpdated;
      this.$store.commit("GET_REPLY_LIST", this.boardSeq);
    },
  },
};
</script>

<style></style>
