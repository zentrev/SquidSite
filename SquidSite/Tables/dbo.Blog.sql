CREATE TABLE [dbo].Blog
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [WriterId] INT NOT NULL, 
    [Title] NCHAR(100) NOT NULL, 
    [DatePosted] DATETIME NOT NULL, 
    [DateEdited] DATETIME NOT NULL, 
    [Content] NVARCHAR(MAX) NOT NULL, 
    [tagId] INT NULL
)
