import Vue from "vue";
import VueRouter from "vue-router";
// import store from "../store/index.js";
import Login from "../components/Login.vue";
import List from "../components/List.vue";
import Edit from "../components/Edit.vue";
import Detail from "../components/Detail.vue";

Vue.use(VueRouter);

const router = new VueRouter({
  mode: "history",
  routes: [
    {
      name: "login",
      path: "/",
      component: Login,
    },
    {
      name: "boardList",
      path: "/List",
      component: List,
    },
    {
      name: "edit",
      path: "/Edit",
      component: Edit,
    },
    {
      name: "detail",
      path: "/Board/Detail/:seq",
      component: Detail,
    },
  ],
});

router.beforeEach(function (to, from, next) {
  // to: 이동할 url에 해당하는 라우팅 객체
  if (
    to.matched.some(function (routeInfo) {
      return routeInfo.meta.authRequired;
    })
  ) {
    // 이동할 페이지에 인증 정보가 필요하면 경고 창을 띄우고 페이지 전환은 하지 않음
    alert("Login Please!");
  } else {
    console.log("routing success : '" + to.path + "'");
    next(); // 페이지 전환
  }
});

export default router;
