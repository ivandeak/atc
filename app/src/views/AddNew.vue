<template>
  <div class="add-new">
    <ValidationObserver v-slot="{ handleSubmit }">
      <form @submit.prevent="handleSubmit(createItem)">
        <ValidationProvider
          v-slot="{ errors }"
          name="To Do"
          :rules="'min:3|max:255'"
          slim
        >
          <BField
            :type="{ 'is-danger': errors[0] }"
            :message="errors"
            :expanded="true"
          >
            <BInput v-model="content" placeholder="To Do" :expanded="true" />
          </BField>
        </ValidationProvider>
        <section>
            <div class="buttons are-medium">
              <BButton native-type="submit" type="is-primary" class="control">
                Save
              </BButton>
              <BButton @click="$emit('close')">
                Cancel
              </BButton>
            </div>
        </section>
      </form>
    </ValidationObserver>
    <BLoading :is-full-page="false" :active.sync="isLoading" />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { ValidationProvider, ValidationObserver } from "vee-validate";
import gql from "graphql-tag";

@Component({
  components: {
    ValidationProvider,
    ValidationObserver
  }
})
export default class AddNew extends Vue {
  isLoading = false;
  content = "";

  createItem() {
    this.isLoading = true;
    this.$apollo
      .mutate({
        mutation: gql`
          mutation($input: CreateToDoItemInput!) {
            createToDoItem(input: $input) {
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
            content: this.content
          }
        }
      })
      .then(() => this.$router.push({ name: "default" }))
      .finally(() => (this.isLoading = false));
  }
}
</script>
