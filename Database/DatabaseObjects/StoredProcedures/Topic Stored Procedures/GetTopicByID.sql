CREATE PROCEDURE GetTopicByID
	@TopicID INT
AS 
BEGIN
	SELECT TopicID, Theme, Content, CreateUser, CreateDate, LastUpdateUser, LastUpdateDate
	FROM [Topic]
	WHERE TopicID = @TopicID;
END