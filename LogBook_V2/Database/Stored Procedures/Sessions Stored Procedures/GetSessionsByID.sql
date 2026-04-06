CREATE PROCEDURE GetSessionsByID
	@SessionID INT
AS 
BEGIN
	SELECT SessionID, TopicID, SessionDate, DurationMinutes, SessionDescription, CreateUser, CreateDate, LastUpdateUser, LastUpdateDate
	FROM [Sessions]
	WHERE SessionID = @SessionID;
END
