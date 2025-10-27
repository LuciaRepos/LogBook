CREATE PROCEDURE GetExerciseByID
	@ExerciseID INT
AS 
BEGIN
	SELECT ExerciseID, TopicID, ExerciseDescription, Result, CreateUser, CreateDate, LastUpdateUser, LastUpdateDate
	FROM [Exercise]
	WHERE ExerciseID = @ExerciseID;
END
