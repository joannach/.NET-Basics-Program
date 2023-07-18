CREATE PROCEDURE [dbo].[InsertEmployee]
    @EmployeeName NVARCHAR(100) = NULL,
    @FirstName NVARCHAR(50) = NULL,
    @LastName NVARCHAR(50) = NULL,
    @CompanyName NVARCHAR(20),
    @Position NVARCHAR(30) = NULL,
    @Street NVARCHAR(50),
    @City NVARCHAR(20) = NULL,
    @State NVARCHAR(50) = NULL,
    @ZipCode NVARCHAR(50) = NULL
AS
BEGIN
    IF (@EmployeeName IS NULL OR LTRIM(RTRIM(ISNULL(@EmployeeName, ''))) = '')
        AND (@FirstName IS NULL OR LTRIM(RTRIM(ISNULL(@FirstName, ''))) = '')
        AND (@LastName IS NULL OR LTRIM(RTRIM(ISNULL(@LastName, ''))) = '')
    BEGIN
        RAISERROR('At least one name field (EmployeeName, FirstName, or LastName) should be provided.', 16, 1)
        RETURN;
    END

    SET @CompanyName = CASE WHEN LEN(@CompanyName) > 20 THEN LEFT(@CompanyName, 20) ELSE @CompanyName END

    INSERT INTO [dbo].[Person] ([FirstName], [LastName])
    VALUES (@FirstName, @LastName)

    DECLARE @PersonId INT
    SET @PersonId = SCOPE_IDENTITY()

    INSERT INTO [dbo].[Employee] ([PersonId], [CompanyName], [Position])
    VALUES (@PersonId, @CompanyName, @Position)

    DECLARE @EmployeeId INT
    SET @EmployeeId = SCOPE_IDENTITY()

    INSERT INTO [dbo].[Address] ([Street], [City], [State], [ZipCode])
    VALUES (@Street, @City, @State, @ZipCode)

    DECLARE @AddressId INT
    SET @AddressId = SCOPE_IDENTITY()

    UPDATE [dbo].[Employee]
    SET [AddressId] = @AddressId
    WHERE [Id] = @EmployeeId
END