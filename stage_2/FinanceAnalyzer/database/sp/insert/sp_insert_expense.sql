CREATE PROCEDURE [dbo].[sp_insert_expense]
(
    @amount DECIMAL,
    @userId INT
)
AS
BEGIN
	INSERT INTO [dbo].[Expense] ([Amount], [UserId]) VALUES (@amount, @userId)
END
GO