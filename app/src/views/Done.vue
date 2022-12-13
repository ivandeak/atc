<template>
  <div class="done">
    <ToDoItemsList :filters="{ status: { in: ['DONE'] } }" />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import ToDoItemsList from "@/components/ToDoItemsList.vue";

@Component({
  components: {
    ToDoItemsList
  }
})
export default class Done extends Vue {}
</script>
