<template>
  <div class="container">
    <h2>Q&A 게시판</h2>
    <div class="row">
      <div style="width: 20%">
        <p>상태</p>
        <select class="form-select">
          <option>1</option>
          <option>2</option>
          <option>3</option>
          <option>4</option>
        </select>
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
    </div>
    <br />
    <table class="table table-bordered">
      <thead>
        <tr>
          <th>Firstname</th>
          <th>Lastname</th>
          <th>Email</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>John</td>
          <td>Doe</td>
          <td>john@example.com</td>
        </tr>
        <tr>
          <td>Mary</td>
          <td>Moe</td>
          <td>mary@example.com</td>
        </tr>
        <tr>
          <td>July</td>
          <td>Dooley</td>
          <td>july@example.com</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import service from "../services/service.js";

export default {
  data() {
    return {
      test: "",
    };
  },
  methods: {
    getBoard() {
      alert("getBoardList");
      service.getBoard().then((data) => {
        console.log(data);
      });
    },
  },
};
</script>

<style></style>
