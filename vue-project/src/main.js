import Vue from "vue";
import App from "./App.vue";
import axios from "axios";
import router from "./router/index.js";
import store from "./store/index.js";
import BootstrapVue from "bootstrap-vue";
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap-vue/dist/bootstrap-vue.css";

Vue.use(BootstrapVue);
Vue.prototype.$axios = axios;

Vue.config.productionTip = false;

new Vue({
  axios,
  store,
  router,
  render: (h) => h(App),
}).$mount("#app");
