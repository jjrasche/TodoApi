dotnet new webapi --framework 7.0
dotnet dev-certs https --trust
dotnet add package Hangfire
dotnet add package Hangfire.SqlServer
dotnet add package Hangfire.AspNet
dotnet add package Microsoft.Data.SqlClient

CREATE DATABASE [HangfireTest]