CREATE PROCEDURE UpdateSession
	@SessionID INT,
	@TopicID INT,
	@SessionDate VARCHAR(500),
	@DurationMinutes INT,
	@SessionDescription VARCHAR(500)
AS
BEGIN
	UPDATE [Session]
	SET 
		TopicID = @TopicID,
		SessionDate = @SessionDate,
		DurationMinutes = @DurationMinutes,
		SessionDescription = @SessionDescription
	WHERE
		SessionID = @SessionID;
END
