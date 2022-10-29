import Vue from "vue";
import App from "./App.vue";
import axios from "axios";
import store from "./store/index.js";
import router from "./router/index.js";
import service from "./services/service.js";
import BootstrapVue from "bootstrap-vue";
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap-vue/dist/bootstrap-vue.css";
import "bootstrap-icons/font/bootstrap-icons.css";
import VueMoment from "vue-moment"; // 날짜 포맷 라이브러리

Vue.use(VueMoment);
Vue.use(BootstrapVue);
Vue.prototype.$axios = axios;

Vue.config.productionTip = false;

new Vue({
  axios,
  store,
  service,
  router,
  render: (h) => h(App),
}).$mount("#app");
