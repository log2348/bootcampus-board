import Vue from "vue";
import VueRouter from "vue-router";
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
      beforeEnter: (to, from, next) => {
        // to : 이동할 URL 정보가 담긴 라우터 객체
        // from : 현재 URL 정보가 담긴 라우터 객체
        // next : to에서 지정한 URL로 이동하기 위해 반드시 호출해야 하는 함수
        console.log(to);
        next();

        // 로그인된 유저일 때
        // if (true) {
        //   // 다음 라우터로 이동
        //   next();
        // } else {
        //   console.log("로그인 후 이용하실 수 있습니다.");
        // }


      },
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

export default router;
