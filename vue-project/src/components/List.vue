<template>
  <div class="container" style="padding: 20px">
    <h2 style="text-align: center"><b>Q&A 게시판</b></h2>
    <br /><br />
    <Search></Search>
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
      <tbody v-if="!$store.state.isFiltered">
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
      <tbody v-if="$store.state.isFiltered">
        <tr v-for="item in $store.state.filteredList" :key="item.BOARD_SEQ">
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

    <div class="container">
      <ul class="pagination" style="justify-content: center; cursor: pointer">
        <li class="page-item" v-for="item in pageNumbers" :key="item">
          <a class="page-link" @click="OnPageChange(item)">{{ item }}</a>
        </li>
      </ul>
    </div>

    <div class="row">
      <div class="col">
        <button class="btn btn-light" @click="GetExcelFile()">
          엑셀 다운로드</button
        >&nbsp;&nbsp;
        <input
          type="file"
          @change="ReadExcelFile()"
          accept="application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
        />
      </div>
      <div class="col" style="text-align: right">
        <router-link to="/Edit">
          <button class="btn btn-primary" @click="$store.state.mode = 'CREATE'">
            작성
          </button>
        </router-link>
      </div>
    </div>
  </div>
</template>

<script>
import Xlsx from "xlsx";
import Search from "../components/Search.vue";

export default {
  data() {
    return {
      nowPage: 1,
    };
  },
  mounted() {
    this.$store.commit("GET_BOARD_LIST");
    this.$store.commit("GET_TOTAL_BOARD_COUNT");
  },
  methods: {
    // 엑셀 파일 다운로드
    GetExcelFile() {
      const workBook = Xlsx.utils.book_new();
      const workSheet = Xlsx.utils.json_to_sheet(
        this.$store.state.filteredList
      );
      Xlsx.utils.book_append_sheet(workBook, workSheet, "myLog");
      Xlsx.writeFile(workBook, "myLog.xlsx");
    },

    // 엑셀 파일 업로드
    ReadExcelFile() {
      const file = event.target.files[0];
      console.log(this.$store.state.boardList);
      let reader = new FileReader();
      reader.onload = () => {
        let data = reader.result;
        let workbook = Xlsx.read(data, { type: "binary" });
        workbook.SheetNames.forEach((sheetName) => {
          const file = Xlsx.utils.sheet_to_json(workbook.Sheets[sheetName]);
          this.$store.state.boardList.push(...file);
          console.log(this.$store.state.boardList);
        });
      };
      reader.readAsBinaryString(file);
    },

    OnPageChange(page) {
      this.nowPage = page;
      this.$store.commit("SELECT_PAGE", page);
    },
  },

  computed: {
    // 페이지 번호 배열에 담기
    pageNumbers: function () {
      const list = [];
      for (let i = 1; i < Math.ceil(this.$store.state.boardList / 5); i++) {
        list.push(i);
      }
      return list;
    },
  },

  components: {
    Search,
  },
};
</script>

<style></style>
