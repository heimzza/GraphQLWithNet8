SELECT TOP (1000) [Id]
      ,[Name]
      ,[LicenseKey]
  FROM [GraphQLWithNet8DB].[dbo].[Platforms]

SELECT TOP (1000) [Id]
      ,[HowTo]
      ,[CommandLine]
      ,[PlatformId]
  FROM [GraphQLWithNet8DB].[dbo].[Commands]

DELETE FROM [GraphQLWithNet8DB].[dbo].[Platforms]
WHERE [Id] >= 3;

INSERT INTO [GraphQLWithNet8DB].[dbo].[Commands] ([HowTo], [CommandLine], [PlatformId])  
VALUES  
    ('Build a project', 'dotnet build', '1'),  
    ('Run a project', 'dotnet run', '1'),
    ('Debug a project', 'dotnet watch', '1'),
    ('Run docker', 'docker compose up -d', '2'),
    ('Stop docker', 'docker compose stop', '2');

