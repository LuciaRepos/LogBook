CREATE PROCEDURE InsertTopic
	@Theme VARCHAR(100),
	@Content VARCHAR(500)
AS
BEGIN
	INSERT INTO [Topic] (Theme, Content, CreateUser, CreateDate, LastUpdateUser, LastUpdateDate)
	VALUES (@Theme, @Content, ORIGINAL_LOGIN(), GETDATE(), ORIGINAL_LOGIN(), GETDATE());
 END
