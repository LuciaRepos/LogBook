CREATE PROCEDURE DeleteQuestionByID
	@QuestionID INT
AS
BEGIN
	DELETE FROM [Question]
		WHERE QuestionID = @QuestionID;
END
