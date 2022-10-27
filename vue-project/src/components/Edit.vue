<template>
  <div class="container" style="padding: 25px">
    <div>
      <h2 v-if="$store.state.mode == 'UPDATE'" style="text-align: center">
        <b>게시글 수정</b>
      </h2>
      <h2 v-else style="text-align: center"><b>게시글 등록</b></h2>
    </div>
    <br />

    <div class="container" style="text-align: right">
      <b-button variant="success" @click="$bvModal.show('modal-scoped')"
        >등록</b-button
      >&nbsp;
      <router-link to="/List"><b-button>목록</b-button></router-link>
    </div>

    <Confirm
      v-if="$store.state.mode == 'UPDATE'"
      :title="board.TITLE"
      :contents="board.CONTENTS"
      :board="board"
    ></Confirm>
    <Confirm
      v-else
      :title="title"
      :contents="contents"
      :imageSubmit="imageSubmit"
    ></Confirm>

    <br />
    <table class="table table-bordered">
      <thead>
        <tr>
          <th>제목</th>
          <td v-if="$store.state.mode == 'UPDATE'">
            <input v-model="board.TITLE" />
          </td>
          <td v-else><input v-model="title" /></td>
        </tr>
      </thead>
      <tbody>
        <tr>
          <th>작성자</th>
          <td>{{ $store.state.userId }}</td>
          <th>작성일</th>
          <td>{{ Date() }}</td>
        </tr>
      </tbody>
    </table>
    <textarea
      v-if="$store.state.mode == 'UPDATE'"
      class="form-control"
      rows="10"
      placeholder="내용을 입력하세요"
      v-model="board.CONTENTS"
    ></textarea>
    <textarea
      v-else
      class="form-control"
      rows="10"
      placeholder="내용을 입력하세요"
      v-model="contents"
    ></textarea>
    <br />
    <br />

    <h4><b>이미지 등록</b></h4>

    <img
      :src="preview"
      title="이미지 미리보기"
      ref="preview"
      name="chooseFile"
      style="width: 250px; height: 250px; margin: 10px"
    />
    <form method="post" enctype="multipart/form-data" action="/Image/Create">
      <input
        type="file"
        accept="image/*"
        name="imageModel"
        @change="OnFileSelected()"
      />
      <input class="btn btn-primary" type="submit" v-model="imageSubmit" />
    </form>
  </div>
</template>

<script>
import service from "../services/service.js";
import Confirm from "../components/Confirm.vue";

export default {
  data() {
    return {
      title: "",
      contents: "",
      board: "",
      preview: "",
      imageFile: "",
      imageSubmit: ""
    };
  },
  mounted() {
    if (this.$store.state.mode == "UPDATE") {
      service.GetBoard(this.$route.params.seq).then((response) => {
        console.log(response);
        this.board = response;
      });
    }
  },
  methods: {
    OnFileSelected() {
      let input = event.target;
      if (input.files && input.files[0]) {
        let reader = new FileReader();
        reader.onload = (e) => {
          this.preview = e.target.result;
        };
        reader.readAsDataURL(input.files[0]);
      }
    },
  },
  components: {
    Confirm,
  },
};
</script>

<style></style>
