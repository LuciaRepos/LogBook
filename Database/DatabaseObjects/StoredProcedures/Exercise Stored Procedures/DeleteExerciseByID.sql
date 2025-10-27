CREATE PROCEDURE DeleteExerciseByID
	@ExerciseID INT
AS
BEGIN
	DELETE FROM [Exercise]
		WHERE ExerciseID = @ExerciseID;
END
