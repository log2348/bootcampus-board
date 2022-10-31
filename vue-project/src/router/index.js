import Vue from "vue";
import VueRouter from "vue-router";
import store from "../store/index.js";
import Login from "../components/Login.vue";
import List from "../components/List.vue";
import Edit from "../components/Edit.vue";
import Detail from "../components/Detail.vue";

Vue.use(VueRouter);

const router = new VueRouter({
  routes: [
    {
      name: "login",
      path: "/",
      component: Login,
      meta: { authRequired: true },
    },
    {
      name: "boardList",
      path: "/List",
      component: List,
      meta: { authRequired: true },
    },
    {
      name: "edit",
      path: "/Edit",
      component: Edit,
      meta: { authRequired: true },
    },
    {
      name: "detail",
      path: "/Board/Detail/:seq",
      component: Detail,
      meta: { authRequired: true },
    },
  ],
});

// 네비게이션 가드
router.beforeEach(function (to, from, next) {
  if (
    to.matched.some(function (routeInfo) {
      return routeInfo.meta.authRequired;
    })
  ) {
    next();
  } else {
    if (store.state.userId != "") {
      next();
      return;
    } else {
      alert("로그인 후 이용가능합니다.");
      router.push("/");
    }
  }
});

export default router;
