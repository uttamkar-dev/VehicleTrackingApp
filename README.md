# VehicleTrackingApp

# This project is developed by .NET5, EF Core 5

# Platform: VS 2022, SQL server 2019 Express

# Followed Architecture: CQRS implemented by MediatoR, Clean Architecture

# Setup Procedure: Need to restore the attach DB or run migration command to generate DB. If migration required then select default project as VehicleTracking.Infrastructure

# Change appsettings to  "ConnectionStrings": {
    "DefaultConnectionString": "Data Source=<server>; Database=VehicleTrackingDB; User Id=sa; Password=<password>"
  },

# Need to register a user and login 

# User Id & password for default login(uid: admin; pass: admin) if provided DB is used

# A token will be generated after successfull login and need to attach the token with each request to access the data
