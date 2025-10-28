CREATE PROCEDURE UpdateQuestion
	@QuestionID INT,
	@TopicID INT,
	@QuestionStatement VARCHAR(150),
	@QuestionDate DATETIME,
	@AnswerDate DATETIME,
	@Answer VARCHAR(600)
AS
BEGIN
	UPDATE [Question]
	SET 
		TopicID = @TopicID,
		QuestionStatement = @QuestionStatement,
		QuestionDate = @QuestionDate,
		AnswerDate = @AnswerDate,
		Answer = @Answer
	WHERE
		QuestionID = @QuestionID;
END
