CREATE PROCEDURE GetQuestionByID
	@QuestionID INT
AS 
BEGIN
	SELECT QuestionID, TopicID, QuestionStatement, QuestionDate, AnswerDate, Answer, CreateUser, CreateDate, LastUpdateUser, LastUpdateDate
	FROM [Question]
	WHERE QuestionID = @QuestionID;
END
