<template>
  <div>
    <div class="container" style="padding: 50px">
      <div style="text-align: center">
        <h2><b>로그인</b></h2>
      </div>
      <br />
      <br />

      <div class="row" style="justify-content: center">
        <div class="col-sm-3">
          <label><b>ID:</b></label>
          <input
            type="text"
            class="form-control"
            placeholder="Enter ID"
            v-model="userId"
          />
        </div>

        <div class="col-sm-3">
          <label for="pwd"><b>Password:</b></label>
          <input
            type="password"
            class="form-control"
            placeholder="Enter password"
            v-model="password"
          />
        </div>
      </div>
      <br />
      <div class="container" style="text-align: center; width: 20%">
        <button class="btn btn-primary" @click="login(userId, password)">
          로그인
        </button>
      </div>
      <router-link to="/List"> 리스트 </router-link>
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
        console.log(response);
      });
    },
  },
};
</script>

<style></style>
