CREATE PROCEDURE UpdateTopic
	@TopicID INT,
	@Theme VARCHAR(100),
	@Content VARCHAR(500)
AS
BEGIN
	UPDATE [Topic]
	SET 
		Theme = @Theme,
		Content = @Content
	WHERE
		TopicID = @TopicID;
END
