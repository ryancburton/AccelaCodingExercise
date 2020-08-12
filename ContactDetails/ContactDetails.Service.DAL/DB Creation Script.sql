CREATE TABLE [dbo].[Person](
	Id int NOT NULL IDENTITY(1,1),
	[firstName] varchar(20) NOT NULL,
	[LastName] varchar(20) NOT NULL
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Address](
	Id int NOT NULL IDENTITY(1,1),
	[street] varchar(50) NOT NULL,
	[city] varchar(20) NOT NULL,
	[state] varchar(15) NOT NULL,
	[postalCode] varchar(10) NOT NULL,
	[PersonId] int NOT NULL,
	FOREIGN KEY (PersonId) REFERENCES Person(id),
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

Insert into [Person] values('Bruce', 'Wayne');

--select * from [Person]
--delete from [Person]
--drop table [Person]
--drop table [Address]

--select * from [Address]
