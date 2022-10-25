<template>
  <div class="container" style="padding: 20px">
    <h2>Q&A 게시판</h2>
    <br /><br />
    <Search
      :stateList="stateList"
      @getListByState="getListByState"
      @searchBoard="searchBoard"
    ></Search>
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

      <!-- 필터링 되지 않은 리스트 -->
      <tbody v-if="!isFiltered">
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

      <!-- 필터링된 리스트 -->
      <tbody v-if="isFiltered">
        <tr v-for="item in filteredList" :key="item.BOARD_SEQ">
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
import Search from "../components/Search.vue";

export default {
  data() {
    return {
      // 게시글 상태 정보
      stateList: [],
      filteredList: [],
      isFiltered: false,
    };
  },
  mounted() {
    service.getBoardList().then((response) => {
      this.$store.state.boardList = response;
      // 상태 정보 배열에 담기
      this.stateList = Array.from(new Set(response.map((a) => a.STATE)));
    });
  },
  methods: {
    getListByState(state) {
      service.getListByState(state).then((response) => {
        if (state != "전체") {
          this.isFiltered = true;
          this.filteredList = response;
        } else {
          this.isFiltered = false;
        }
      });
    },

    searchBoard(searchType, searchWord) {
      const data = {
        searchType: searchType,
        searchWord: searchWord,
      };
      service
        .searchBoard(data)
        .then((response) => {
          console.log(response);
          if (searchType == "전체" || searchWord == "") {
            this.isFiltered = false;
          } else {
            this.isFiltered = true;
            this.filteredList = response;
          }
        })
        .catch((error) => {
          console.log(error);
        });
    },
  },
  components: {
    Search,
  },
};
</script>

<style></style>
