<template>
  <div>
    <div class="container" style="padding: 50px">
      <h2><b>로그인</b></h2>
      <br />
      <div class="mb-3 mt-3">
        <label>ID:</label>
        <input
          type="text"
          class="form-control"
          placeholder="Enter ID"
          v-model="userId"
        />
      </div>
      <div class="mb-3">
        <label for="pwd">Password:</label>
        <input
          type="password"
          class="form-control"
          placeholder="Enter password"
          v-model="password"
        />
      </div>
      <router-link to="/List"> 리스트 </router-link>

      <button class="btn btn-primary" @click="login(userId, password)">
        로그인
      </button>
    </div>
  </div>
</template>

<script>
import service from "../services/service.js";

export default {
  data() {
    return {
      userId: "",
      password: "",
    };
  },
  methods: {
    login(userId, password) {
      let objUser = {
        USER_ID: userId,
        PASSWORD: password,
      };

      service.login(objUser).then((response) => {
        console.log(objUser);
        alert("11111111" + response);
        // 성공하면 페이지 이동
      });
    },
  },
};
</script>

<style></style>
