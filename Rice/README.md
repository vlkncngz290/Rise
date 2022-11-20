This project developed for Rice Technology assessment. Project uses the following ports on your local computer;

- 5432 ->postgresql container
- 15672 ->rabbitmq ui
- 5672 ->rabbitmq service
- 1000 ->UserService grpc server
- 5127 ->UserService application
- 5128 ->ReportService application


How To Build And Run This Project

1) Create run postgresql and rabbitmq containers
    Run "docker-compose up -d" command to run docker-compose.yaml file. It will create and run postgresql and rabbitmq containers
2) Open solution in Visual Studio
3) Open Package Manager Console
    Select UserService as Default project and run "Update-Database" command
    Select ReportService as Default project and run "Update-Database" command
    These commands creates databases and tables on postgresql db
4) Run UserService and ReportService projects via Visual Studio or Run via Terminal
    If you prefer Build and Run via terminal, open terminal and locate UserService folder
    Run "dotnet run" command, this command will start the UserService project
    Open new terminal and locate ReportService folder
    Run "dotnet run" command, this command will start the ReportService project

5) If you want to test endpoints, you can use postman collection exports located in solution root folder