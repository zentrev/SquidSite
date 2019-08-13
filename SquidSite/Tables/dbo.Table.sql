CREATE TABLE [dbo].Comment
(
	[CommentId] INT NOT NULL PRIMARY KEY, 
    [WriterId] INT NOT NULL, 
    [BlogId] INT NOT NULL, 
    [DateCreated] DATETIME NOT NULL, 
    [DateEdited] DATETIME NOT NULL, 
    [Content] NCHAR(1000) NOT NULL
)
