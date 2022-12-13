<template>
  <div class="home">
    <ToDoItemsList :filters="{ status: { in: ['PENDING', 'DOING'] } }" />
    <FloatingButton text="+ Add" :on-click="addNew" />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import ToDoItemsList from "@/components/ToDoItemsList.vue";
import FloatingButton from "@/components/FloatingButton.vue";

@Component({
  components: {
    ToDoItemsList,
    FloatingButton
  }
})
export default class Home extends Vue {
  addNew() {
    this.$router.push({ name: "new" });
  }
}
</script>
