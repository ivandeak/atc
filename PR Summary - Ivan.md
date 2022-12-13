## Notes:

Since this was done on a laptop with an older version of windows that could not install VSCode, and had issues running GraphQl to test/verify any of my changes, I was not able to complete all the front-end tasks, nor verify the back-end tasks and limited the exercise to the 2 hour (most of which was on trying to get GraphQl to run)

## Summary
### Task 1 - App - expose edit button in mobile view 
This was one of the main issues I had getting to run the front-end app locally, so could not verify the change, but made the following change:
app/src/components/ToDoCard.vue: removed `class="column is-hidden-mobile"` from the `Edit` div

### Task 2 - Service - expose a DeleteToDoItemOperation
This is captured in the `ToDoItemMutations.DeleteToDoItemAsync` method
Ideally, I should have also added a Unit Test, but ran out of time

### Task 3 - Project Tickets
This is captured in `docs/Project Tickets.md`

### Task 4 - New Feature
#### Service Changes:
Subtasks 1 & 2 have both been implemented

#### App Changes:
The associated subtasks for this have not been implemented, due to the issues I had with VSCode and also getting responses from GraphQl to verify the front-end changes 

