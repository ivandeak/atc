<template>
  <div class="is-fab">
    <BButton type="is-primary" rounded size="is-large" @click="onClick">{{
      text
    }}</BButton>
  </div>
</template>
<script lang="ts">
import { Vue, Component, Prop } from "vue-property-decorator";

@Component
export default class FloatingButton extends Vue {
  @Prop({ required: true }) text: string;
  @Prop({ required: true }) onClick: Function;
}
</script>
<style lang="scss" scoped>
.is-fab {
  position: fixed;
  right: 2rem;
  bottom: 2rem;
}
</style>
