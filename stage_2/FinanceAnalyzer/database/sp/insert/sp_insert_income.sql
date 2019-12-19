CREATE PROCEDURE [dbo].[sp_insert_income]
(
    @amount DECIMAL,
    @userId INT
)
AS
BEGIN
	INSERT INTO [dbo].[Income] ([Amount], [UserId]) VALUES (@amount, @userId)
END
GO