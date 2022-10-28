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
          <label><b>아이디</b></label>
          <input
            type="text"
            class="form-control"
            placeholder="Enter ID"
            v-model="userId"
          />
        </div>

        <div class="col-sm-3">
          <label for="pwd"><b>비밀번호</b></label>
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
        <button class="btn btn-primary" @click="Login(userId, password)">
          로그인</button
        >&nbsp;&nbsp;&nbsp;
        <router-link to="/List">
          <button class="btn btn-secondary">목록</button></router-link
        >
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      userId: "",
      password: "",
    };
  },
  methods: {
    Login(userId, password) {
      let objUser = {
        USER_ID: userId,
        PASSWORD: password,
      };

      this.$store.commit("LOGIN", objUser);
    },
  },
};
</script>

<style></style>
