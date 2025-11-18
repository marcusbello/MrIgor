--------------------------------------------
-- 1️⃣ Create Roles if they don't exist
--------------------------------------------
IF NOT EXISTS (SELECT 1 FROM dbo.AspNetRoles WHERE Name = 'Admin')
    INSERT INTO dbo.AspNetRoles (Id, [Name], [NormalizedName], [ConcurrencyStamp])
    VALUES (NEWID(), 'SuperAdmin', 'SUPERADMIN', NEWID());

IF NOT EXISTS (SELECT 1 FROM dbo.AspNetRoles WHERE Name = 'Admin')
    INSERT INTO dbo.AspNetRoles (Id, [Name], [NormalizedName], [ConcurrencyStamp])
    VALUES (NEWID(), 'Admin', 'ADMIN', NEWID());

IF NOT EXISTS (SELECT 1 FROM dbo.AspNetRoles WHERE Name = 'Teacher')
    INSERT INTO dbo.AspNetRoles (Id, [Name], [NormalizedName], [ConcurrencyStamp])
    VALUES (NEWID(), 'Teacher', 'TEACHER', NEWID());

IF NOT EXISTS (SELECT 1 FROM dbo.AspNetRoles WHERE Name = 'Student')
    INSERT INTO dbo.AspNetRoles (Id, [Name], [NormalizedName], [ConcurrencyStamp])
    VALUES (NEWID(), 'Student', 'STUDENT', NEWID());
