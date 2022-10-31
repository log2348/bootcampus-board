<template>
  <div class="container" style="padding: 20px">
    <h2 style="text-align: center"><b>Q&A 게시판</b></h2>
    <br /><br />
    <Search></Search>
    <br />
    <table class="table table-bordered">
      <thead style="text-align: center">
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
        <tr v-for="item in nowPage" :key="item.BOARD_SEQ">
          <td style="text-align: center">{{ item.BOARD_SEQ }}</td>
          <td>{{ item.STATE }}</td>
          <router-link
            :to="{ name: 'detail', params: { seq: item.BOARD_SEQ } }"
          >
            <td>{{ item.TITLE }}</td>
          </router-link>
          <td style="text-align: center">{{ item.USER_ID }}</td>
          <td style="text-align: center">
            {{ $moment(item.WRITE_DATE).format("YYYY-MM-DD") }}
          </td>
          <td style="text-align: center">{{ item.VIEW_COUNT }}</td>
        </tr>
      </tbody>

      <!-- 필터링된 리스트 -->
      <tbody v-else>
        <tr v-for="item in filteredList" :key="item.BOARD_SEQ">
          <td>{{ item.BOARD_SEQ }}</td>
          <td>{{ item.STATE }}</td>
          <router-link
            :to="{ name: 'detail', params: { seq: item.BOARD_SEQ } }"
          >
            <td>{{ item.TITLE }}</td>
          </router-link>
          <td>{{ item.USER_ID }}</td>
          <td>{{ $moment(item.WRITE_DATE).format("YYYY-MM-DD") }}</td>
          <td>{{ item.VIEW_COUNT }}</td>
        </tr>
      </tbody>
    </table>

    <div class="container">
      <ul class="pagination" style="justify-content: center; cursor: pointer">
        <li
          class="page-item"
          v-for="item in pageNumbers"
          :key="item"
        >
          <a class="page-link" @click="changePage(item)">{{ item }}</a>
        </li>
      </ul>
    </div>

    <div class="row">
      <div class="col">
        <button class="btn btn-light" @click="getExcelFile()">
          엑셀 다운로드</button
        >&nbsp;&nbsp;
        <input
          type="file"
          @change="readExcelFile()"
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
import { mapState } from "vuex";
import Search from "../components/Search.vue";

export default {
  data() {
    return {
      nowPageNumber: 1,
    };
  },
  mounted() {
    this.$store.commit("GET_BOARD_LIST");
    this.$store.commit("GET_TOTAL_BOARD_COUNT");
    this.$store.commit("GET_PAGE", this.nowPageNumber);
  },
  methods: {
    // 엑셀 파일 다운로드
    getExcelFile() {
      const workBook = Xlsx.utils.book_new();
      const workSheet = Xlsx.utils.json_to_sheet(
        this.filteredList
      );
      Xlsx.utils.book_append_sheet(workBook, workSheet, "myLog");
      Xlsx.writeFile(workBook, "myLog.xlsx");
    },

    // 엑셀 파일 업로드
    readExcelFile() {
      const file = event.target.files[0];
      let reader = new FileReader();
      reader.onload = () => {
        let data = reader.result;
        let workbook = Xlsx.read(data, { type: "binary" });
        workbook.SheetNames.forEach((sheetName) => {
          const file = Xlsx.utils.sheet_to_json(workbook.Sheets[sheetName]);
          this.nowPage.push(...file);
        });
      };
      reader.readAsBinaryString(file);
    },

    changePage(page) {
      this.nowPageNumber = page;
      this.$store.commit("GET_PAGE", page);
    },
  },

  computed: {
    formatDate: function (date) {
      let year = date.getFullYear();
      let month = ("0" + (date.getMonth() + 1)).slice(-2);
      let day = ("0" + date.getDate()).slice(-2);

      let dateString = year + "-" + month + "-" + day;

      return dateString;
    },

    ...mapState(["nowPage", "pageNumbers", "isFiltered", "filteredList", "mode"]),
  },

  components: {
    Search,
  },
};
</script>

<style></style>
