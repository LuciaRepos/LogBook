CREATE PROCEDURE UpdateExercise
	@ExerciseID INT,
	@TopicID INT,
	@ExerciseDescription VARCHAR(150),
	@Result VARCHAR(500)
AS
BEGIN
	UPDATE [Exercise]
	SET 
		TopicID = @TopicID,
		ExerciseDescription = @ExerciseDescription,
    Result = @Result
	WHERE
		ExerciseID = @ExerciseID;
END
