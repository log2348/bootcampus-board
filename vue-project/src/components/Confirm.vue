<template>
  <div>
    <div>
      <!-- <b-button id="show-btn" @click="showModal">Open Modal</b-button> -->

      <b-modal
        ref="my-modal"
        v-show="showModal"
        hide-footer
        title="Using Component Methods"
      >
        <div class="d-block text-center">
          <h3>Hello From My Modal!</h3>
        </div>
        <b-button class="mt-3" variant="outline-danger" block @click="hideModal"
          >Close Me</b-button
        >
        <b-button
          class="mt-2"
          variant="outline-warning"
          block
          @click="toggleModal"
          >Toggle Me</b-button
        >
      </b-modal>
    </div>
  </div>
</template>

<script>
export default {
  props: ["showModal"],
  methods: {
    // hideModal() {
    //   this.$refs["my-modal"].hide();
    // },
    // toggleModal() {
    //   // We pass the ID of the button that we want to return focus to
    //   // when the modal has hidden
    //   this.$refs["my-modal"].toggle("#toggle-btn");
    // },
  },
};
</script>

<style></style>
