1. Configure Your Database Connection
	Make sure your application is configured to connect to the SQL Server database. Update the appsettings.json file in the "EmailWebApi" project with the appropriate connection string;

2. SQL Server Configuration
	Open SQL Server Management Studio (SSMS).
	Connect to your SQL Server instance.
	Create the database and user:

		CREATE DATABASE dbEmailProject;
		CREATE LOGIN EPLogin WITH PASSWORD = 'EPLogin';

		USE dbEmailProject;
		CREATE USER EPLogin FOR LOGIN EPLogin;
		ALTER ROLE db_owner ADD MEMBER EPLogin;

	
  	Right-click on the server name in the Object Explorer and select Properties.
  	Go to the Security page.
  	Ensure that SQL Server and Windows Authentication mode is selected.
	Click OK to save any changes.

3. Create Migrations
	After the initial db creation open the "Package Manager Console" and make sure to select "Persistence" as the Default project.

	Once your connection string is configured and you created your user you can remove the current migrations to start fresh with:
		Remove-Migration

	Create Initial Migration with:
		Add-Migration Init

	Finally, apply the migration to your database by running:
		Update-Database

