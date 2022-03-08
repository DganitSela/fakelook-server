# fakeLook server starter
##### this is a server starter aimed to help you to start your server development, note that the code here is simply a suggestion and after cloning you can change the implemntetion or write yourself all together

### this project contains 3 projects inside:
1. fakelook-dal: containes most of the entities you will need
2. fakelook-data: acts as the data layer of this server, containes the connection to our sql database, comes with model mapping and seeding function
3. fakelook-server: our server, comes with basic configuration and connection to our dal via the repositories 

### how to get started?
1. make sure you have git installed ([install git](https://git-scm.com/downloads))
3. create fakelook folder (will serve us also for the client)
4. inside that folder create fakelook-server folder and open it in the terminal
5. in GitHub, click on the green code button and copy the https url
![](https://docs.github.com/assets/cb-20366/images/help/repository/code-button.png)
5. run `$ git clone <copied url>`
6. check that all the files inside
7. open the solution with vs
8. go to appsettings.json inside fakelook-starter and put your sql server name inside the connection string (mssql studio example of where to find server name)


![](https://i.stack.imgur.com/sJnf8.png)

9. run the server and ensure everything works
10. if everyhing worked as planned you should see that your database with all the of the tables and seeded data created successfully

#### now lets create our own repository with the starter

11. go to your repositories view on Github (https://github.com/<user-name>?tab=repositories)
12. click on new
13. enter fakelook-server as repository name
14. select public repository and click create repository
15. open the project folder in the terminal
16. run `$ git remote set-url origin <new-repo-url> to change the origin url from the clone source to our new repo's one
17. run `$ git branch -M main` to change our main branch to main
18. run `$ git push -u origin main` to push our cloned code to the remote repository
