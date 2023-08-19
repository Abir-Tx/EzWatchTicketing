# Developement Documentation

This documentation is aimed towards the developers who are currently working or will be working on this project in future. I will try to guide through you on how to setup and get into this project

## Technical Details

- DotNet Framework Version: 4.7.2
- Architecture Used: MVC Web API Tier Architecture
- SQL Server: MSSQL Server 2022
- Data Developement Model: Code-First Using Entity Framework
- Dependency Resolution: Can be restored using the packages.json using nuget

## Steps

So I will try to keep things as simple as possible. Just try to follow the steps:

### Clone

Clone the repo using **ssh** in your computer for local dev. If you are forking and then clonning (If you are not added as an contributor to this repo) then the URL will be different. I am assuming that you are a contributor on this project already so making the documentation in that regard.

```bash
git clone git@github.com:Abir-Tx/EzWatchTicketing.git
```

### Create Branch

It is always recommended to create your own new branch & work on that branch always as if that is the main branch for you. As the main branch of the project is protected and only accepts **PR**s and also the project requires local changes most of the time so creating a new branch is handy.

```bash
git checkout -b new_branch_name
git push --set-upstream origin new_branch_name
```

### Open Project

Open Visual Studio 2022 and select **Open project** option and then select `EWT.sln` file from inside the clonned directory

### Change Connection String

The very first thing after openning the project in Visual Studio 2022 is to change the connection string in the `Web.Config` file inside the `EWT-UI` project. Here just add your ***SQL Server Address***.

### Restore Nuget Packages

In VS 2022 - 

- Go to `Tools > NuGet Package Manager > Manage Nuget Packages For This Solution`
- A **Restore** button should be visible on that page. Click on the restore button to restore all the used packages.

### Build The Database

This is the most important part and critical too as it often becomes so error prone. Open `Package Manager Console` and then issue these commands - 

```powershell
Enable-Migration
Update-Database -Verbose
```
This should work fine most of the times. If any error occurs (Which might be) then delete the created (if so) database from the server using SQL management studio & then issue the update database command again but this time manually one by one. See the **Migrations** folder and take a note of the migration files name and then migrate those files one by one in order - 

```powershell
Update-Database -Verbose -TargetMigration:migration_name_1
Update-Database -Verbose -TargetMigration:migration_name_2
Update-Database -Verbose -TargetMigration:migration_name_3
```
This should avoid the error.

### Run The Project

Now test the project first before adding Developement. Everyting should work fine now. Test the APIs endpoints uisng **Postman**
