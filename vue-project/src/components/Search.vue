<template>
  <div>
    <div class="row">
      <div class="col-2">
        <p>상태</p>
        <select
          class="form-select"
          v-model="state"
          @change="$store.commit('GET_LIST_BY_STATE', state)"
        >
          <option>전체</option>
          <option v-for="item in stateList" :key="item">{{ item }}</option>
        </select>
      </div>
      <br />
      <div class="row col-6">
        <p>검색조건</p>
        <select class="col form-select" v-model="searchType">
          <!-- <option>전체</option> -->
          <option>제목</option>
          <option>내용</option>
          <option>번호</option>
          <option>작성자</option></select
        >&nbsp;
        <input
          type="text"
          v-model="searchWord"
          class="col form-control"
          placeholder="검색어를 입력하세요."
        />&nbsp;
        <button
          class="col btn btn-primary"
          @click="$store.commit('SEARCH_BOARD', {searchType, searchWord})"
        >
          검색
        </button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      state: "전체",
      searchType: "",
      searchWord: "",
    };
  },
  props: ["stateList"],
  
};
</script>

<style></style>
