select o.*
from tblOrder o, tblCustomer c
where o.OrderCustomerNumber = c.CustNumber

select *
from tblOrder

select *
from tblTropicalUserRole

select *
from tblTropicalUser

go
drop procedure SrchOrders
go
alter procedure SrchOrders(@orderdate int = -1, @custID int=null, 
	@custName varchar(200)=null,@managerName varchar(200)=null)
as begin
	begin transaction
	begin try
	declare @rows nvarchar(max) = 'select OrderID, OrderTrackingNumber, OrderDate, CustID, CustName, CustBillingAddress1, OrderRouteNumber '			
	declare @tables nvarchar(max) = ' from tblOrder o, tblCustomer c '
	declare @where nvarchar(max) = ' where o.OrderCustomerNumber = c.CustNumber '
	declare @paramDef nvarchar(max) = '@orderdate datetime = null, @custID int=null, @custName varchar(200)=null,@managerName varchar(200)=null'

	if @orderdate > -1
	begin
		if @orderdate = 7
			set @where = @where + ' And (datediff(day, OrderDate, getdate()) <= @orderdate) '
		else if @orderdate = 0
			set @where = @where + ' And (CONVERT(DATE, OrderDate) = CONVERT(DATE, CURRENT_TIMESTAMP)) '
		else
			set @where = @where + ' And (datediff(month, OrderDate, getdate()) <= @orderdate) '
	end

	if @custID > -1
	begin
		set @where = @where + ' And (CustID = @custID) '
	end

	if @custName is not null
	begin
		set @where = @where + ' And (CustName = @custName) '
	end

	if @managerName is not null
	begin
		set @where = @where + ' And (CustName = @managerName) '
	end

	--DECLARE @tab AS TABLE (col VARCHAR(10), colu2 varchar(10)) 

	declare @query nvarchar(max) = @rows +' '+ @tables +' '+ @where
	print @query
	exec sp_executesql @query, @paramDef, @orderdate, @custID, @custName, @managerName
	end try
	begin catch
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		print Error_Message()
	end catch
	IF @@TRANCOUNT > 0
		COMMIT TRANSACTION;
end
go
exec SrchOrders -1, -1,null,null

select OrderID, OrderTrackingNumber, OrderDate, CustID, CustName, CustBillingAddress1, OrderRouteNumber   
from tblOrder o, tblCustomer c   
where o.OrderCustomerNumber = c.CustNumber  And (datediff(month, OrderDate, getdate()) <= 6)


use TropicalServer

print getdate()


delete from tblOrder
where OrderID = 0

select *
from tblOrder
where OrderID = 0

select distinct CustName
from tblCustomer
where CustName is not null

go
alter procedure searchCustID (@id varchar(100))
as begin
	select distinct CustID
	from tblCustomer
	where CustID like '%'+@id+'%'
end

exec searchCustID '1'

go
alter procedure searchCustName (@name varchar(100))
as begin
	select distinct CustName
	from tblCustomer
	where CustName is not null and CustName like '%'+@name+'%'

end
go
alter procedure updateOrder (@id int, @track varchar(100), @date datetime, @custID int, @name varchar(200), @addr varchar(200), @route int)
as begin
	--tracking route date
	if @route = -1
		set @route = null
	UPDATE tblOrder
	SET OrderTrackingNumber = @track, OrderDate = @date, OrderRouteNumber = @route
	WHERE OrderID = @id;

end

exec searchCustName 'g'

select *
from tblUserLogin