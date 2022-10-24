import Vue from "vue";
import VueRouter from "vue-router";
import Login from "../components/Login.vue";
import List from "../components/List.vue";
import Edit from "../components/Edit.vue";

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
  ],
});

export default router;
