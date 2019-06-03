
# .Net Core-API, Angular 6, Customer Management

# Introduction
This is my interview project for Propellerhead. 

This really was a fun project to do, and it did push me to think FullStack while working on the project.

Instead of using all my existing code libraries and previous projects, i have decided that it would be a good idea to challenge myself and do this project in the latest tech from scratch.

  Although there are many tools available today, which would have split my development time in half, I took the path of doing lot of custom development, especially in angular. 

I wanted to showcase my capabilities, for when the occasion every arises and the right tool was not available.
  
  I will definitely carry on with this shell in the futures, after doing some code clean-up, refactor to allow my code to be more re-usable and dynamic, with a bit more time.

# Getting Started
##1.	Installation process
-  Clone repo from Git.
-  Open solution with Visual Studio 2019 
-  Navigate to appsettings.json
- ![alt text](https://github.com/HentiePaxton/CoreAPIAngularCustomerManagement/blob/master/Git%20Images/appsettings.PNG)
-  Update Connection String - (I used a local SQL Server)
- ![alt text](https://github.com/HentiePaxton/CoreAPIAngularCustomerManagement/blob/master/Git%20Images/ConnectionString.PNG)
-  Run Using IIS Express
- ![alt text](https://github.com/HentiePaxton/CoreAPIAngularCustomerManagement/blob/master/Git%20Images/IISExpress.PNG)
-  The CompanyDB will automatically be migrated to SQL using your connection string.
    

##2.	Software dependencies
* Visual Sudio 2019
* .Net Core 2.1
* MS SQL Server or Local SQL Server

# Note
Although i initially created the database using database first, and EF reverse engineer. I added code on the statup.cs which will ensure that the database is created. 

I have also added code to check and insert the required status upon migration and provide you with a test user.
![alt text](https://github.com/HentiePaxton/CoreAPIAngularCustomerManagement/blob/master/Git%20Images/Migration.PNG)

# In the case of Emergency
## Database not migrating
Don't stress. I scripted the database schema and data. 
This script can be found under the root repo folder: CoreAPIAngularCustomerManagement\SQL Scripts\FullDatabaseScriptWithData.sql

## App not communicating with Web API
I have not experience this, but there is always room for this. If this happens, disable your firewall, or allow the IIS local port on the firewall.

    # Developers

| Name | Email |
| ------ | ------ |
|Hentie Paxton | hentie.paxton@gmail.com|
