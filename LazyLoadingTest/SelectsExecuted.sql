//NHibernate output

SELECT this_.Id as Id1_0_, this_.Description as Descript2_1_0_, this_.Customer_id as Customer3_1_0_ FROM [Order] this_

//Entity framework output

SELECT 
1 AS [C1], 
[Extent1].[Id] AS [Id], 
[Extent1].[Description] AS [Description], 
[Extent1].[Customer_Id] AS [Customer_Id]
FROM [dbo].[Orders] AS [Extent1]

exec sp_executesql N'SELECT 
[Extent2].[Id] AS [Id], 
[Extent2].[Name] AS [Name]
FROM  [dbo].[Orders] AS [Extent1]
INNER JOIN [dbo].[Customers] AS [Extent2] ON [Extent1].[Customer_Id] = [Extent2].[Id]
WHERE ([Extent1].[Customer_Id] IS NOT NULL) AND ([Extent1].[Id] = @EntityKeyValue1)',N'@EntityKeyValue1 uniqueidentifier',@EntityKeyValue1='FF947EF3-5A3F-4A26-BDB9-039C49F559A7'

exec sp_executesql N'SELECT 
[Extent2].[Id] AS [Id], 
[Extent2].[Name] AS [Name]
FROM  [dbo].[Orders] AS [Extent1]
INNER JOIN [dbo].[Customers] AS [Extent2] ON [Extent1].[Customer_Id] = [Extent2].[Id]
WHERE ([Extent1].[Customer_Id] IS NOT NULL) AND ([Extent1].[Id] = @EntityKeyValue1)',N'@EntityKeyValue1 uniqueidentifier',@EntityKeyValue1='BDC1430B-A46B-4486-A946-2F3DAC3B69F5'

exec sp_executesql N'SELECT 
[Extent2].[Id] AS [Id], 
[Extent2].[Name] AS [Name]
FROM  [dbo].[Orders] AS [Extent1]
INNER JOIN [dbo].[Customers] AS [Extent2] ON [Extent1].[Customer_Id] = [Extent2].[Id]
WHERE ([Extent1].[Customer_Id] IS NOT NULL) AND ([Extent1].[Id] = @EntityKeyValue1)',N'@EntityKeyValue1 uniqueidentifier',@EntityKeyValue1='CB1151E0-2E52-41BA-B97B-69B98CB7B28C'