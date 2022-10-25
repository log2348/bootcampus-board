<template>
  <div class="container" style="padding: 20px">
    <div>
      <h2>게시글 작성 / 수정</h2>
    </div>
    <br />
    <br />

    <b-button @click="showModal = !showModal">Open Modal</b-button>
    <Confirm :showModal="showModal"></Confirm>

    <table class="table table-bordered">
      <thead>
        <tr>
          <th>제목</th>
          <td><input /></td>
        </tr>
      </thead>
      <tbody>
        <tr>
          <th>작성자</th>
          <td>{{ $store.state.username }}</td>
          <th>작성일</th>
          <td></td>
        </tr>
      </tbody>
    </table>
    <textarea
      class="form-control"
      rows="10"
      placeholder="내용을 입력하세요"
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
      showModal: false
    }
  },
  components: {
    Confirm,
  },
};
</script>

<style></style>
