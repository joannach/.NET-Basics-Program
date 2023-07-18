/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName])
VALUES (1, 'John', 'ABC'),
       (2, 'Jane', 'XYZ')

INSERT INTO [dbo].[Address] ([Id], [Street], [City], [State], [ZipCode])
VALUES (1, '123 Sample St', 'New York', 'NY', '77777'),
       (2, '456 Temp St', 'Los Angeles', 'CA', '99999')

INSERT INTO [dbo].[Employee] ([Id], [AddressId], [PersonId], [CompanyName], [Position], [EmployeeName])
VALUES (1, 1, 1, 'Company A', 'Manager', 'John ABC'),
       (2, 2, 2, 'Company B', 'Developer', 'Jane XYZ')

INSERT INTO [dbo].[Company] ([Id], [Name], [AddressId])
VALUES (1, 'Company A', 1),
       (2, 'Company B', 2)
