CREATE TRIGGER [dbo].[CreateCompany]
ON [dbo].[Employee]
AFTER INSERT
AS
BEGIN
    DECLARE 
    @EmployeeId INT,
    @AddressId INT,
    @CompanyName NVARCHAR(20),
    @Street NVARCHAR(50),
    @City NVARCHAR(20),
    @State NVARCHAR(50),
    @ZipCode NVARCHAR(50)

    SELECT @EmployeeId = [Id], @AddressId = [AddressId], @CompanyName = [CompanyName]
    FROM inserted

    SELECT @Street = [Street], @City = [City], @State = [State], @ZipCode = [ZipCode]
    FROM [dbo].[Address]
    WHERE [Id] = @AddressId

    INSERT INTO [dbo].[Company] ([Name], [AddressId])
    VALUES (@CompanyName, @AddressId)

END