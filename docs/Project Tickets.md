# Project Tickets

## Assumptions
1. There is no status for a project. If it exists, it is active
2. Based on the reference screenshot ("projectspage"), a project can never be deleted
3. Based on the reference screenshot ("projectspage"), a project can not be renamed
4. Based on the reference screenshot ("projectspage"), there is no limit on how many projects are to be retrieved/rendered
5. Based on the reference screenshot ("projectspage"), ordering of the project list does not matter
6. Based on the reference screenshot ("projectstasklist",) ordering of the tasks does not matter  
7. A TodoItem cannot be moved to a different project
8. Since there is no reference screenshot for the add project, it will be assumed to be a dialog - this was missing
9. The interactions (Edit, Add buttons) on the ToDo item view has already been implemented
10. The Edit modal has already been implemented for the ToDo item

## Tickets - Projects List
### Display all projects Project List View
Allow the user to view all the projects as a list in the "project list" view

Acceptance Criteria
1. As a user, when i navigate to the project list view, it will render all the projects stored in the database so that I can interact with each project
2. As a user, I want to know the name and how many items are in each project so that I can easier interact with the system 
3. As a user, when there are no projects to be shown in the list view, A message saying "No projects exist" should appear, so that I know there are no projects

#### Tasks/SubTickets:
##### Service - Project Table Migration Script
Create a migration script to create a new Project table

Structure: 
- table name: Project
- Id [text<Guid>, primary key, not nullable]
- Name [text<string>, maxLength: 255, nullable]

##### Service - Add Project column to ToDo table 
Create a migration script to create a new column in the ToDoItems table table

Structure: 
- ProjectId [text<Guid>, foreign key[Project.Id], not nullable]

Note: Unit Tests must be written as part of the development of the ticket

##### Service - Project Queries
Create a new ProjectQueries class, containing a GetProjects method 
(reference implementation: ToDoItemQueries.cs)

Note: Unit Tests must be written as part of the development of the ticket

##### App - No Projects Message
When the GetProjects endpoint returns no projects, a label containing the text "No projects exist" should be rendered in place of the collection of projects

##### App - New View


### Ability to Add a new Project
Allow the user to add a new project via the "project list" view

Acceptance Criteria
1. As a user, when I am on the Projects List View, I should see an Add button
3. As a user, when I am on the Projects List View AND I click on the add button, I will have the ability to create a new project via a dialog
4. As a user, when i am on the Projects List View AND i click on the View

#### Tasks/SubTickets:
##### Service - create a ProjectMutations.CreateProjectAsync method
Expose a method to accept a request to create a new project
It should accept the following payload:
- string name [required]

Note: Unit Tests must be written as part of the development of the ticket

##### App - Add Button
Expose an add button at the bottom of the projects page.
Upon clicking on the button, the Create Project Dialog should render

##### App - Add Dialog
Expose a Create Project Dialog, prompting for the name of the project via a textbox and a save button (pending designs)

Upon clicking Save, the app should submit a request to the service and call ProjectMutations.CreateProjectAsync 


### Ability to navigate into a project
Allow the user to navigate to the ToDo items associated with a Project

Acceptance Criteria:
1. As a user, when I am on the Projects List View, I should see a View button for each project
2. As a user, when I am on the Projects List View AND i click on the View button of a project, I should be redirected to the Project Task List view 


## Tickets - Project Task List
Allow the user to view the project name, as well as the ToDoIitems associated with the project

### App - Render Project Name
Allow the user to see the name of the Project

Acceptance Criteria: 
1. As a user, when I navigate to the Project Task View, I should see the name of the Project so I know exactly what project is in context
2. As a user, when I navigate to the Project Task View, I should see the tasks of the Project so I know what tasks are remaining 
3. As a user, when I navigate to the Project Task View, I should be able to edit the each task in the project so that I have fine-grain control
4. As a user, when I am on the Project Task View AND I click on the edit button of a task, the edit modal should appear
5. As a user, when I navigate to the Project Task View, I should be able to add a new Task
6. As a user, when I navigate to the Project Task View, I should be able to see the status of each task via a completed checkbox so that I can track the status of each item

#### Tasks/SubTickets:

##### Service - Project Queries
Update the ProjectQueries class, to add a new GetProject method 
(reference implementation: ToDoItemQueries.cs)

The model should return Project.Name as well as a collection of each ToDoItem associated to it

Note: Unit Tests must be written as part of the development of the ticket

##### App - Render Project Name
Expose a label to indicate the name of the project
Should be mapped from the response models Name property

##### App - Render ToDo Items
Extend the existing ToDoItemsList component
Should query the project query endpoint mentioned in subtask 1 based on the project id in context in order to filter the tasks associated to the project



