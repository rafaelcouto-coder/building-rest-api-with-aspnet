# building-rest-api-with-aspnet

### Creating resources

`Create author:` POST api/authors

`Create course from author:` POST api/authors/{authorId}/courses

`Create collections author:` POST api/authorcollections

### Changing resources

`Change course:` PUT api/authors/{authorId}/courses/{coursesId}

### Deleting resources 

`Delete author:` DEL api/authors/{authorId}

`Delete course from author:` DEL api/authors/{authorId}/courses/{coursesId}
