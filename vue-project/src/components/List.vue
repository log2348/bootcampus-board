<template>
  <div class="container" style="padding: 20px">
    <h2>Q&A 게시판</h2>
    <br /><br />
    <div class="row">
      <div class="col-2">
        <p>상태</p>
        <select class="form-select" v-model="state" @change="selectByState(state)">
          <option>전체</option>
          <option v-for="item in stateList" :key="item">{{ item }}</option>
        </select>
      </div>
      <br />
      <div class="row col-6">
        <p>검색조건</p>
        <select class="col form-select">
          <option>제목</option>
          <option>내용</option>
          <option>번호</option>
          <option>작성자</option></select
        >&nbsp;
        <input
          type="text"
          class="col form-control"
          placeholder="검색어를 입력하세요."
        />&nbsp;
        <button @click="getBoard" class="col btn btn-primary">검색</button>
      </div>
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
          <router-link
            :to="{ name: 'detail', params: { seq: item.BOARD_SEQ } }"
          >
            <td>{{ item.TITLE }}</td>
          </router-link>
          <td>{{ item.USER_ID }}</td>
          <td>{{ item.WRITE_DATE }}</td>
          <td>{{ item.VIEW_COUNT }}</td>
        </tr>
      </tbody>
    </table>

    <div style="text-align: center">
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
    <div class="row">
      <div style="text-align: left">
        <button class="btn btn-light">엑셀 업로드</button>&nbsp;
        <button class="btn btn-light">엑셀 다운로드</button>
      </div>
      <div style="text-align: right">
        <router-link to="/Edit">
          <button class="btn btn-primary">작성</button>
        </router-link>
      </div>
    </div>
  </div>
</template>

<script>
import service from "../services/service.js";

export default {
  data() {
    return {
      // 게시글 상태 정보
      stateList: [],
    };
  },
  mounted() {
    service.getBoardList().then((response) => {
      this.stateList = Array.from(new Set(response.map((a) => a.STATE)));
      this.$store.state.boardList = response;
    });
  },
  methods: {
    selectByState() {

    }
  },
};
</script>

<style></style>
