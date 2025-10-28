CREATE PROCEDURE DeleteSessionByID
	@SessionID INT
AS
BEGIN
	DELETE FROM [Session]
		WHERE SessionID = @SessionID;
END
