CREATE PROCEDURE GetOrderDetails @userId int
AS
	Select Distinct
		o.Id AS OrderId,
		os.Status,
		oi.Quantity,
		p.Id AS ProductId,
		p.Name AS ProductName,
		p.Weight,
		p.Height,
		p.ImageUrl,
		p.Sku,
		p.BarCode,
		u.Name AS UserName,
		u.EmailAddress,
		a.Id AS AddressId
	FROM Orders o
	INNER JOIN OrderItems oi ON oi.OrderId = o.Id
	INNER JOIN Addresses a ON a.Id = o.AddressId
	INNER JOIN Products p ON p.Id = oi.ProductId
	INNER JOIN Users u ON u.Id = a.UserId
	INNER JOIN OrderStatus os ON os.Id = o.OrderStatusId
	WHERE o.Active = 1
	AND (u.RoleId <> 1 OR u.Id = @userId)
 GO