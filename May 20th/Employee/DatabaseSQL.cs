// CREATE
CREATE TABLE [dbo].[Employee] (
    [EmployeeID] INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]  NVARCHAR (MAX) NOT NULL,
    [LastName]   NVARCHAR (MAX) NOT NULL,
    [department] NVARCHAR (MAX) NOT NULL,
    [Salary]     INT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([EmployeeID] ASC)
);


// INSERT/READ
SET IDENTITY_INSERT [dbo].[Employee] ON
INSERT INTO [dbo].[Employee] ([EmployeeID], [FirstName], [LastName], [department], [Salary]) VALUES (2, N'Pranati', N'Devaraju ', N'Technical Lead', 60000)
INSERT INTO [dbo].[Employee] ([EmployeeID], [FirstName], [LastName], [department], [Salary]) VALUES (4, N'Vithala', N'Sasank ', N'Support Manager', 40000)
SET IDENTITY_INSERT [dbo].[Employee] OFF



// UPDATE
SET IDENTITY_UPDATE [dbo].[Employee] ON
UPDATE INTO [dbo].[Employee] ([EmployeeID], [FirstName], [LastName], [department], [Salary]) VALUES (2, N'Pranati', N'Devaraju 20', N'Technical Lead', 60000)
UPDATE INTO [dbo].[Employee] ([EmployeeID], [FirstName], [LastName], [department], [Salary]) VALUES (4, N'Vithala', N'Sasank 12', N'Support Manager', 40000)
SET IDENTITY_UPDATE [dbo].[Employee] OFF



// DELETE
SET IDENTITY_DELETE [dbo].[Employee] ON
DELETE INTO [dbo].[Employee] ([EmployeeID], [FirstName], [LastName], [department], [Salary]) VALUES (4, N'Vithala', N'Sasank 12', N'Support Manager', 40000)
SET IDENTITY_DELETE [dbo].[Employee] OFF
