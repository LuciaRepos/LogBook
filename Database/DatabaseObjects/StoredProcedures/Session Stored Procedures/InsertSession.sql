CREATE PROCEDURE InsertSession
	@TopicID INT,
	@SessionDate DATETIME,
	@DurationMinutes INT, 
	@SessionDescription VARCHAR (500),
AS
BEGIN
	INSERT INTO [Session] (TopicID, SessionDate, DurationMinutes, SessionDescription, CreateUser, CreateDate, LastUpdateUser, LastUpdateDate)
	VALUES (@TopicID, @SessionDate, @DurationMinutes, @SessionDescription, ORIGINAL_LOGIN(), GETDATE(), ORIGINAL_LOGIN(), GETDATE());
 END
