# LBC-Assessment

Install instructions:
1. Clone the repository.
2. Open the sln file.
3. On the solution explorer, right click the VacationManager project file and set it as the default project.
4. On the PMC (Package Manager Console) run the following command: ```dotnet restore```
5. Clean and build the solution.
6. Make sure to select ```IIS Express``` at the top.
   
   <img width="391" height="216" alt="image" src="https://github.com/user-attachments/assets/2e0ee10a-8dda-4acd-9702-0dbc12f9c046" />
8. Run the application.

## Heads-up for testing

1. All users are already registered on the database. They all have the password ```123456``` for simplicity of testing.
2. There's a default administrator user with credentials ```admin@workflow.com``` and password ```admin```
3. If for some reason the database is cleared or deleted, run the following commands in order:

      ```dotnet ef migrations add InitialCreate --project VacationManager```

      ```dotnet ef migrations add SeedAdminUser --project VacationManager```

      ```dotnet ef database update --project VacationManager```

5. To authenticate, call the Authentication endpoint with the user and email.
   <img width="795" height="150" alt="image" src="https://github.com/user-attachments/assets/90ecee2e-6b1a-422e-b860-e1c1ec2fedc4" />
   
   It'll return the bearer token which have to be added in the authentication button at the top of the page.
   <img width="1770" height="193" alt="image" src="https://github.com/user-attachments/assets/97f890c9-9da8-4296-a1a0-deec161365dd" />
   
   <img width="419" height="338" alt="image" src="https://github.com/user-attachments/assets/96b3e050-2c2b-42ee-8fe9-a5e71c1dfdfa" />
   
   <img width="876" height="407" alt="image" src="https://github.com/user-attachments/assets/45106cc9-50cc-4b43-8107-14ed6e8e92dc" />




   
