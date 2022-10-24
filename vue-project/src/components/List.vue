<template>
  <div class="container">
    <h2>Q&A 게시판</h2>
    <div style="width: 20%">
      <p>상태</p>
      <select class="form-select">
        <option>1</option>
        <option>2</option>
        <option>3</option>
        <option>4</option>
      </select>
      <br />
      <p>검색조건</p>
      <select class="form-select">
        <option>1</option>
        <option>2</option>
        <option>3</option>
        <option>4</option>
      </select>
      <input
        type="text"
        class="form-control"
        placeholder="Enter email"
        name="email"
      />
      <button @click="getBoard" class="btn btn-primary">검색</button>
    </div>
    <br />
    <table class="table table-bordered">
      <thead>
        <tr>
          <th>번호</th>
          <th>상태</th>
          <th>제목</th>
          <th>작성자</th>
          <th>작성일</th>
          <th>조회수</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="item in $store.state.boardList" :key="item.BOARD_SEQ">
          <td>{{ item.BOARD_SEQ }}</td>
          <td>{{ item.STATE }}</td>
          <td>{{ item.TITLE }}</td>
          <td>{{ item.USER_ID }}</td>
          <td>{{ item.WRITE_DATE }}</td>
          <td>{{ item.VIEW_COUNT }}</td>
        </tr>
      </tbody>
    </table>

    <div style="text-align: right">
      <router-link to="/Edit">
        <button class="btn btn-primary">작성</button>
      </router-link>
    </div>

    <div>
      <ul class="pagination">
        <li class="page-item disabled">
          <a class="page-link" href="#">Previous</a>
        </li>
        <li class="page-item"><a class="page-link" href="#">1</a></li>
        <li class="page-item"><a class="page-link" href="#">2</a></li>
        <li class="page-item"><a class="page-link" href="#">3</a></li>
        <li class="page-item"><a class="page-link" href="#">Next</a></li>
      </ul>
    </div>
  </div>
</template>

<script>
import service from "../services/service.js";

export default {
  mounted() {
    service.getBoardList().then((response) => {
      console.log(response);
      this.$store.state.boardList = response;
    });
  },
  methods: {
    getBoard() {
      service.getBoard().then((data) => {
        console.log(data);
      });
    },
  },
};
</script>

<style></style>
