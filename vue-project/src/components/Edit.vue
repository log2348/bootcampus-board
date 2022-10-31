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
      @submit="submit"
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
          <td name="USER_ID">{{ $store.state.userId }}</td>
          <th>작성일</th>
          <td v-if="$store.state.mode == 'UPDATE'">
            {{ $moment(board.WRITE_DATE).format("YYYY-MM-DD") }}
          </td>
          <td v-else>{{ $moment().format("YYYY-MM-DD") }}</td>
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
      style="width: 250px; height: 250px; margin: 10px"
    />
    <form method="post" enctype="multipart/form-data" action="/Image/Create">
      <input
        type="file"
        accept="image/*"
        name="imageFile"
        ref="imageFile"
        @change="onFileSelected()"
      />
      <input class="btn btn-primary" type="submit" />
    </form>
  </div>
</template>

<script>
import service from "../services/service.js";
import Confirm from "../components/Confirm.vue";
import axios from "axios";

export default {
  data() {
    return {
      title: "",
      board: "",
      contents: "",
      preview: "",
      imageFile: ""
    };
  },
  mounted() {
    if (this.$store.state.mode == "UPDATE") {
      service.getBoard(this.$route.params.seq).then((response) => {
        console.log(response);
        this.board = response;
      });
    }
  },
  methods: {
    onFileSelected() {
      let image = event.target;

      // 첨부한 이미지 미리보기
      if (image.files[0]) {
        let itemImage = this.$refs.preview; //img dom 접근
        itemImage.src = window.URL.createObjectURL(image.files[0]); //img src에 blob주소 변환
        this.itemImageInfo.uploadImages = itemImage.src; //이미지 주소 data 변수에 바인딩해서 나타내게 처리
        itemImage.onload = () => {
          window.URL.revokeObjectURL(this.src);
        };
      }
    },

    submit() {
      const formData = new FormData();
      formData.append("imageFile", this.$refs.imageFile.files[0]);
      axios
        .post("/Image/Create", formData, {
          headers: {
            "Content-Type": "multipart/form-data",
          },
        })
        .then((response) => console.log(response));
    },
  },
  components: {
    Confirm,
  },
};
</script>

<style></style>
