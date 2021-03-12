# coding-challenge-source
a web application (angular/asp.net) which retrieves activities from boredapi.com, stores them in an ef in-memory database, and displays them in a table

# Notes
## Regarding the spa
HTTP error status codes have not been handled, currently they're logged in the console. In a real-world application, an error message would probably be displayed to the user.

Activities are added to the activities table before the activity is added to the database to improve responsiveness. In a real-world application, it's possible that you'd wait for the activity to be added to the database before displaying it to the user (as an error could occur when adding it to the database).

I've used Bootstrap as the UI library. It isn't the nicest looking UI library, but it's easy to use.

## Regarding the api
For the CORS policy, I've allowed all origins/methods/headers. In a real-world application, you'd ideally lock it down to specific origins/methods/headers.
