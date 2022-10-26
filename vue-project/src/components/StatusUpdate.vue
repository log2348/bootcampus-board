<template>
  <div>
    <b-modal id="update-status-modal">
      <template #modal-header>
        <h4>상태 업데이트</h4>
      </template>
      <template>
        <table class="table table-bordered">
          <thead>
            <tr>
              <th>현재 상태</th>
              <td>{{ this.status }}</td>
            </tr>
          </thead>
          <tbody>
            <tr>
              <th>변경 상태</th>
              <td>
                <select v-model="newStatus" class="form-select">
                  <option v-for="item in $store.state.stateList" :key="item">
                    {{ item }}
                  </option>
                </select>
              </td>
            </tr>
          </tbody>
        </table>
      </template>

      <template #modal-footer>
        <b-button size="m" variant="primary" @click="updateStatus()">
          확인
        </b-button>
      </template>
    </b-modal>
  </div>
</template>

<script>
export default {
  data() {
    return {
      newStatus: "",
    };
  },
  props: ["status", "boardSeq", "showModal"],
  methods: {
    updateStatus() {
      let data = {
        boardSeq: this.boardSeq,
        state: this.status,
      };
      if (this.status == this.newStatus) {
        alert("현재 상태와 동일합니다.");
      } else {
        this.$store.commit("UPDATE_STATUS", data);
        this.close();
      }
    },
  },
};
</script>

<style></style>
