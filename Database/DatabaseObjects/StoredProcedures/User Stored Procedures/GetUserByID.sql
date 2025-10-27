CREATE PROCEDURE GetUserByID
	@UserID INT
AS 
BEGIN
	SELECT UserID, Email, UserName, CreateUser, CreateDate, LastUpdateUser, LastUpdateDate
	FROM [User]
	WHERE UserID = @UserID;
END
