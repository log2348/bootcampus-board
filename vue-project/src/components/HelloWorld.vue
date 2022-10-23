<template>
  <div>
    <input type="button" value="버튼" @click="getNoticeList">
  </div>
</template>

<script>
import service from "@/services/service.js";

export default {
  methods: {
    /**
     * [참고] 공지사항 목록 조회
     */
    getNoticeList() {
      // //Request Parameter
      // let objParams = {
      //   page: 1
      // };

      //API 서비스 호출
      service.getNoticeList().then(data => {
        console.log(data);
      });
    }
  }
}
</script>

<style scoped></style>
