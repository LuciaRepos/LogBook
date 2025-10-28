CREATE PROCEDURE InsertQuestion
	@TopicID INT,
	@QuestionStatement VARCHAR(150),
	@QuestionDate DATETIME,
	@AnswerDate DATETIME,
	@Answer VARCHAR (600)
AS
BEGIN
	INSERT INTO [Question] (TopicID, QuestionStatement, QuestionDate, AnswerDate, Answer, CreateUser, CreateDate, LastUpdateUser, LastUpdateDate)
	VALUES (@TopicID, @QuestionStatement, @QuestionDate, @AnswerDate, @Answer, ORIGINAL_LOGIN(), GETDATE(), ORIGINAL_LOGIN(), GETDATE());
 END
