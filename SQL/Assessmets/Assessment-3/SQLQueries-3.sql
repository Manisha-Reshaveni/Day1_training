use Assessments
create table Courses
(
CID varchar(20),
CName varchar(20),
Start_date date,
End_date date,
Fee float
)
INSERT INTO Courses VALUES('DN003','DotNet','2018-02-01','2018-02-28',15000),
('DV004','DataVisualization','2018-03-01','2018-04-15',15000),
('JA002','AdvancedJava','2018-01-02','2018-01-20',10000),
('JC001','CoreJava','2018-01-02','2018-01-12',3000)
select * from Courses
---1.Create a Function to calculate the course duration for the above relation by receiving start date and end date as input.
  create or alter function fn_CourseDuration(@start_date date,@end_date date)
  returns int
  as
  begin
  declare @duration int
  set @duration = datediff(day,@start_date,@end_date)
  return @duration
  end

  select CID,dbo.fn_CourseDuration(Start_date,End_date) Course_Duration_in_days from Courses 

  --Create a trigger to display the Course Name and Start date of the course
  create or alter trigger triggerCrse
on courses
for insert
as
begin
 declare @Cname varchar(20)
 declare @start_date date
 select @Cname = CName from courses
 select @start_date = Start_date from courses
 select @Cname,@start_date  from Courses
 end
 rollback

INSERT INTO Courses Values('DJ007','Java','2018-03-02','2018-04-20',4000)
select * from Courses
-------------------------------------------
--Write a stored Procedure that inserts records in the ProductsDetails table

--Table : ProductsDetails (ProductId, ProductName, Price, DiscountedPrice)

create table Product_Details
(ProductId int primary key,
ProductName varchar(20),
Price float,
DiscountedPrice as (price-Price*0.10) 
)
	insert  into Product_Details values(1,'bag',5000)
create or alter  procedure sp_products 
as
begin
declare @ProductName varchar(20),@price float,@productID int 
	INSERT INTO Products_Details(productname,price) values (@ProductName,@price)
	 select @productID = case
	   when max(ProductId) is null then 0
	   else max(ProductId)
	   end
	   from Product_Details
	set @productID = @productID + 1
	end
	exec sp_products
	select * from Product_Details

	insert  into Product_Details (productname,price) values(5,'book',2000)





 
--The procedure should generate the ProductId automatically to insert and should return the generated value to the user
--Hint(User should not give the ProductId while inserting)
--Also the Discounted Price Column is a calculated column (Price - 10%)
 
--Test the Procedure using ADO classes to call the Procedure and show the generated ProductId, and Discounted Price
