<template>
  <div class="item-card">
    <div class="columns">
      <div class="column is-three-quarters has-text-left">
        <BField class="checkbox-field">
          <BCheckbox v-model="done" @input="toggleDone">{{
            content
          }}</BCheckbox>
        </BField>
      </div>
      <div>
        <BButton outlined @click="editItem">Edit</BButton>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { Vue, Component, Prop } from "vue-property-decorator";
import gql from "graphql-tag";

@Component
export default class ToDoCard extends Vue {
  @Prop({ required: true }) item: any;
  @Prop({ default: () => () => ({}) }) onStatusToggle: Function;

  get content() {
    return this.item.content;
  }

  get createdDate() {
    return this.item.createdDate;
  }

  get createdDateDisplay() {
    return new Date(this.item.createdDate).toUTCString();
  }

  get done() {
    return this.item.status == "DONE";
  }

  set done(val: boolean) {
    this.item.status = val ? "DONE" : "PENDING";
  }

  editItem()
  {
    this.$router.push({
      name: 'edit',
      params: {
        item: this.item,
      }
    })
  }

  toggleDone() {
    this.$apollo
      .mutate({
        mutation: gql`
          mutation($input: UpdateToDoItemInput!) {
            updateToDoItem(input: $input) {
              toDoItem {
                content
                createdDate
                id
                status
              }
            }
          }
        `,
        variables: {
          input: {
            id: this.item.id,
            status: this.item.status
          }
        }
      })
      .then(() => this.onStatusToggle());
  }
}
</script>
<style lang="scss" scoped>
.checkbox-field {
  line-height: 2.5rem;
}
</style>
