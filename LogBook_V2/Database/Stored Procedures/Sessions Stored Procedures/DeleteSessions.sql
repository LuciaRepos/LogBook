CREATE PROCEDURE DeleteSessionsByID
	@SessionID INT
AS
BEGIN
	DELETE FROM [Sessions]
		WHERE SessionID = @SessionID;
END
