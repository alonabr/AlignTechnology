Disclaimers:

1. For the assignment, I chose to use mongoDB. The reason is that there are no relations between tables, just a collection.
2. I didn't implement authentication.
3. I didn't implement middleware to deal with exceptions, in one place.
3. I assumed the text in the requests is valid, so I didn't implements validations. 
4. In the question of gets the closet mission, I calculate the distance from the requested address, for each of a mission in the DB, which means O(n).
   In case the DB will be grater that solution in not a solution I would choose. 
5. I saved some paramters in appsettings.json file, in the real world I would choose to save it in other place like SSM.