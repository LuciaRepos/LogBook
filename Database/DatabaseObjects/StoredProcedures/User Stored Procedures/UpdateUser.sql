CREATE PROCEDURE UpdateUser
	@UserID INT,
	@Email VARCHAR(100),
	@UserName VARCHAR(50)
AS
BEGIN
	UPDATE [User]
	SET 
		Email = @Email,
		UserName = @UserName
	WHERE
		UserID = @UserID;
END