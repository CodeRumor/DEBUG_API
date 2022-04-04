# Debug API

### Introduction
This application is a web-base API that allows you to retrieve the error messages that 
have occured when running all CodeRumor based applications.

### Pre-software installations
- Install one of the following IDE to run the application 
    - Visual studio code https://code.visualstudio.com/download
    - Rider note: this is a paid version but offers 1 month evaluation https://www.jetbrains.com/rider/download/#section=windows
    - Visual studio 2019 https://visualstudio.microsoft.com/vs/
- Install Kitematic for windows or mac using the following link https://kitematic.com/
- Install docker using the following link https://docs.docker.com/engine/install/
- Install database monitoring tool using the following link https://dbeaver.io/download/

### Pre-application installation requirements
- Install .Net tools, this will be used to perform database migration later on.
- Install .Net sdk 5.0 or later download sdk using this link for windows, mac and linux https://dotnet.microsoft.com/download
- Create development and production database in docker using the repository in this  link https://github.com/ugolole/MSSQL

### Running application
- Running the application inside an IDE simply press F5 or the Run button.
- Building the application using docker can be done using the command shown below, only if you have added FEED_PATH and FEED_ACCESSTOKEN have been added to the system environment variables this values can be found in AzureDevOps.
  - **`docker-compose build --build-arg FEED_ACCESSTOKEN --build-arg FEED_PATH --no-cache`**
    - `docker-compose` is used to run the docker-compose.yml file. 
    - `build` builds the application before deployment.
    - `--build-arg` the build arguments needed for this build process FEED_ACCESSTOKEN is needed to access the nuget package store in azureDevOps
  FEED_PATH store the path to the feed where packages are stored in azureDevOps
    - `--no-cache` ensure the build process doesn't sure cached data to create the container for the application.
- Finally run the built application using the command shown below
  - **`docker-compose up -d`**
  - `up` run the application based the previously built image, this also restarts the application only if the image has been rebuilt..
  - `d` run the application in detached mode.

Conclusion
- **`docker-compose build --build-arg FEED_ACCESSTOKEN --build-arg FEED_PATH --no-cache`**
- **`docker-compose up -d`**


### Updating migrations
This application contains multiple contexts, a context is used has a mechanism for accessing data from the database. 
The contexts include applicationDbContext and IdentityContext. When rebuilding the database schema it's important to reference the correct context being used for that schema.
The correct context being used here is ApplicationDbContext.

- Delete all the files in the directory DEBUG_COPPO_API/Data/Migrations
- While in the terminal navigate to the directory \DEBUG_COPPO_API
- Use the command shown below to rebuild the database schema for **`applicationDbContext`** context.
  - **`dotnet ef migrations add "Initiai-application-database-schema" -o "Data\Migrations"`**
- Back up all the data in the database, if necessary.
- Delete the entire database using a database visualisation tool of choice.
- Run the application.

Note :- The application will rebuild the database schema and add all the data to the new database. 
