CREATE PROCEDURE GetSessionByID
	@SessionID INT
AS 
BEGIN
	SELECT SessionID, TopicID, SessionDate, DurationMinutes, SessionDescription, CreateUser, CreateDate, LastUpdateUser, LastUpdateDate
	FROM [Session]
	WHERE SessionID = @SessionID;
END
