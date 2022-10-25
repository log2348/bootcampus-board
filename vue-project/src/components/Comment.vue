<template>
  <div>
    <label for="comment"><b>> 댓글</b></label>
    <textarea class="form-control" rows="4" id="comment" name="text"></textarea>
    <br />

    <ul
      class="list-group"
      v-for="item in $store.state.replyList"
      :key="item.REPLY_SEQ"
    >
      <li class="list-group-item">{{ item.REPLY_CONTENTS }}</li>
    </ul>
  </div>
</template>

<script>
export default {
  mounted() {
    this.$store.commit("GET_REPLY_LIST", this.$route.params.seq);
  }
};
</script>

<style></style>
