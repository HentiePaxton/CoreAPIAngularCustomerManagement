# .Net Core-API, Angular 6, Customer Management

# Introduction
This is my interview project for Propellerhead. 

Instead of using all my existing code libaries and previous projects, i have decided that it would be a code idea to challange myself and do this project in the latest Tech from scratch.

  Altough there are many tools available today, which would have split my development time in half.
  
  I have done a lot of custom development, especially in angular. The reason is that i wanted to showcase some of my capabilities, when the occasion had to arrise where the right tool was not available.
  
  All of this was quite alot of work to do manually and build the custom components, where time forced me to avoid building more re-usable libraries and fuctions. If this project might grow bigger and I have more time, I will 1st do a code clean-up, refactor
  and update most of my code and packages it's best version.

# Getting Started
##1.	Installation process
    * Clone repo from Git.
    * Open solution with Visual Studio 2019 
    * Navigate to appsettings.json
    ![alt text](http://url/to/img.png)
    * Update Connection String - (I used a local SQL Server)
    ![alt text](https://github.com/HentiePaxton/CoreAPIAngularCustomerManagement/blob/master/Git%20Images/ConnectionString.PNG)
    * Run Using IIS Express
    ![alt text](http://url/to/img.png)
    * The CompanyDB will automatically be migrated to SQL using your connection string.
    

##2.	Software dependencies
    * Visual Sudio 2019
    * .Net Core 2.1
    * MS SQL Server or Local SQL Server

# Note
Although i initially created the database using database first, and EF reverse engineer. I added code on the statup.cs which will ensure that the database is created. 
![alt text](http://url/to/img.png)

I have also added code to check and insert the required status upon migration and provide you with a test user.
![alt text](http://url/to/img.png)

# In the case of Emergancy
## Database not migrating
Don't stress. I scripted the database schema and data. 
This script can be found under the root repo folder: CoreAPIAngularCustomerManagement\SQL Scripts\FullDatabaseScriptWithData.sql

## App not communicating with Web API
I have not experience this, but there is always room for this. If this happens, disable your firewall, or allow the IIS local port on the firewall.

    # Developers

| Name | Email |
| ------ | ------ |
|Hentie Paxton | hentie.paxton@gmail.com|
