USE [Customers]
GO

INSERT INTO [dbo].[Customer]
           ([FirstName]
           ,[LastName]
           ,[MiddleInitial]
           ,[NickName]
           ,[Address1]
           ,[Address2]
           ,[City]
           ,[State]
           ,[Zip]
           ,[Age]
           ,[Occupation]
           ,[Hobbies])
     VALUES
           ('Fred', 'Flintstone', null, null, null, null, 'Bedrock', null, null, 39, 'stone cutter', 'bowling')

INSERT INTO [dbo].[Customer]
           ([FirstName]
           ,[LastName]
           ,[MiddleInitial]
           ,[NickName]
           ,[Address1]
           ,[Address2]
           ,[City]
           ,[State]
           ,[Zip]
           ,[Age]
           ,[Occupation]
           ,[Hobbies])
     VALUES
           ('Wilma', 'Flintstone', null, 'Wilmaaaaaaaaaa', null, null, 'Bedrock', null, null, 29, 'house wife', 'spending')

INSERT INTO [dbo].[Customer]
           ([FirstName]
           ,[LastName]
           ,[MiddleInitial]
           ,[NickName]
           ,[Address1]
           ,[Address2]
           ,[City]
           ,[State]
           ,[Zip]
           ,[Age]
           ,[Occupation]
           ,[Hobbies])
     VALUES
           ('Bob', 'Hope', null, null, '123 Main St.', null, 'New York', 'NY', '12345', 99, 'entertainer', 'smoking cigars')


GO


