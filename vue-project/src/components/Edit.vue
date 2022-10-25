<template>
  <div class="container" style="padding: 20px">
    <div>
      <h2 v-if="$store.state.mode == 'UPDATE'">게시글 수정</h2>
      <h2 v-else>게시글 등록</h2>
    </div>
    <br />
    <br />

    <b-button @click="$bvModal.show('modal-scoped')">등록</b-button>

    <Confirm :title="title" :contents="contents"></Confirm>

    <table class="table table-bordered">
      <thead>
        <tr>
          <th>제목</th>
          <td v-if="$store.state.mode == 'UPDATE'">
            <input value="board.TITLE" v-model="title" />
          </td>
          <td v-else><input v-model="title" /></td>
        </tr>
      </thead>
      <tbody>
        <tr>
          <th>작성자</th>
          <td>{{ $store.state.userId }}</td>
          <th>작성일</th>
          <td></td>
        </tr>
      </tbody>
    </table>
    <textarea
      v-if="$store.state.mode == 'UPDATE'"
      class="form-control"
      rows="10"
      placeholder="내용을 입력하세요"
      v-model="contents"
    ></textarea>
    <textarea
      v-else
      class="form-control"
      rows="10"
      placeholder="내용을 입력하세요"
      v-model="contents"
    ></textarea>
    <br />
    <h3>이미지 등록</h3>
  </div>
</template>

<script>
import Confirm from "../components/Confirm.vue";

export default {
  data() {
    return {
      title: "",
      contents: "",
      board: this.$route.params,
    };
  },
  mounted: {},
  components: {
    Confirm,
  },
};
</script>

<style></style>
