SET NOCOUNT ON;

--------------------------------------------
-- 2️⃣ Get Role IDs
--------------------------------------------
DECLARE @AdminRoleId NVARCHAR(450) = (SELECT TOP 1 Id FROM dbo.AspNetRoles WHERE Name = 'Admin');
DECLARE @TeacherRoleId NVARCHAR(450) = (SELECT TOP 1 Id FROM dbo.AspNetRoles WHERE Name = 'Teacher');
DECLARE @StudentRoleId NVARCHAR(450) = (SELECT TOP 1 Id FROM dbo.AspNetRoles WHERE Name = 'Student');

--------------------------------------------
-- 3️⃣ Get User IDs
--------------------------------------------
DECLARE @AdminId NVARCHAR(450)    = (SELECT TOP 1 Id FROM dbo.AspNetUsers WHERE Email = 'admin@example.com');
DECLARE @Teacher1Id NVARCHAR(450) = (SELECT TOP 1 Id FROM dbo.AspNetUsers WHERE Email = 'teacher_one@example.com');
DECLARE @Teacher2Id NVARCHAR(450) = (SELECT TOP 1 Id FROM dbo.AspNetUsers WHERE Email = 'teacher_two@example.com');
DECLARE @Student1Id NVARCHAR(450) = (SELECT TOP 1 Id FROM dbo.AspNetUsers WHERE Email = 'student@example.com');
DECLARE @Student2Id NVARCHAR(450) = (SELECT TOP 1 Id FROM dbo.AspNetUsers WHERE Email = 'student_one@example.com');

--------------------------------------------
-- 4️⃣ Assign Roles to Users (if not already assigned)
--------------------------------------------
IF NOT EXISTS (SELECT 1 FROM dbo.AspNetUserRoles WHERE UserId = @AdminId AND RoleId = @AdminRoleId)
    INSERT INTO dbo.AspNetUserRoles (UserId, RoleId) VALUES (@AdminId, @AdminRoleId);

IF NOT EXISTS (SELECT 1 FROM dbo.AspNetUserRoles WHERE UserId = @Teacher1Id AND RoleId = @TeacherRoleId)
    INSERT INTO dbo.AspNetUserRoles (UserId, RoleId) VALUES (@Teacher1Id, @TeacherRoleId);

IF NOT EXISTS (SELECT 1 FROM dbo.AspNetUserRoles WHERE UserId = @Teacher2Id AND RoleId = @TeacherRoleId)
    INSERT INTO dbo.AspNetUserRoles (UserId, RoleId) VALUES (@Teacher2Id, @TeacherRoleId);

IF NOT EXISTS (SELECT 1 FROM dbo.AspNetUserRoles WHERE UserId = @Student1Id AND RoleId = @StudentRoleId)
    INSERT INTO dbo.AspNetUserRoles (UserId, RoleId) VALUES (@Student1Id, @StudentRoleId);

IF NOT EXISTS (SELECT 1 FROM dbo.AspNetUserRoles WHERE UserId = @Student2Id AND RoleId = @StudentRoleId)
    INSERT INTO dbo.AspNetUserRoles (UserId, RoleId) VALUES (@Student2Id, @StudentRoleId);

PRINT '✅ Roles and UserRole mappings seeded successfully!';
GO