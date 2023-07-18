CREATE VIEW [dbo].[EmployeeInfo]
AS
SELECT 
    E.Id AS EmployeeId,
    ISNULL(E.EmployeeName, P.FirstName + ' ' + P.LastName) AS EmployeeFullName,
    CONCAT(A.ZipCode, '_', A.State, ', ', A.City, '-', A.Street) AS EmployeeFullAddress,
    CONCAT(C.Name, '(', E.Position, ')') AS EmployeeCompanyInfo
FROM 
    [dbo].[Employee] AS E
JOIN 
    [dbo].[Person] AS P ON E.PersonId = P.Id
JOIN 
    [dbo].[Address] AS A ON E.AddressId = A.Id
JOIN 
    [dbo].[Company] AS C ON E.CompanyName = C.Name