--1.	Write a T-SQL Program to find the factorial of a given number.
declare @num int=3
declare @fact int=1
while @num>0
begin
set @fact=@fact*@num
set @num=@num-1;
end
print 'Factorial of the given number is:'+cast(@fact as varchar(20))

--2.	Create a stored procedure to generate multiplication table that accepts a number and generates up to a given number. 
create or alter procedure TableMul(@num1 int,@limit int)
as 
begin
declare @val int=1
while @val<=@limit
begin
print cast(@num1 as varchar(10))+'*'+cast(@val as varchar(10))+'='+cast(@num1*@val as varchar(20))
set @val=@val+1;
end
end

 exec TableMul 5,10

 --3. Create a function to calculate the status of the student. If student score >=50 then pass, else fail. Display the data neatly

 create table student
 (
 Student_Id int PRIMARY KEY,
 Student_name varchar(20)
 )
 insert into student Values(1,'Jack'),
 (2,'Rithvik'),
(3,'Jaspreeth'),
  (4,'Praveen'),
(5,'Bisa'),
(6,'Suraj')


create table Marks(
Marks_Id int References Student(student_Id),
StudentId int,
Score int
)
INSERT INTO Marks VALUES(1,1,23),
(2, 6, 95),
(3,4,98),
(4,2, 17),
(5,3, 53),
(6,5,13)
Select * from student
select * from Marks

create or alter function fn_Student_Status(@Sc int)
returns varchar(20)
as
begin
--@Sc=select score from Marks
if(@Sc>=50)
begin 
print 'student is pass'
end
else
print 'Student fail'
end






