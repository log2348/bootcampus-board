import Vue from "vue";
import App from "./App.vue";
import axios from "axios";
import store from "./store/index.js";
import router from "./router/index.js";
import service from "./services/service.js";
import BootstrapVue from "bootstrap-vue";
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap-vue/dist/bootstrap-vue.css";

Vue.use(require("vue-moment"));
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
