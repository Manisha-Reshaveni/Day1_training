USE ASSIGNMENTS

CREATE TABLE Department(
Deptno INT PRIMARY KEY,
Dname VARCHAR(20), 
Location VARCHAR(20),
)
CREATE TABLE Employees(
Empno int , 
Ename VARCHAR(20), 
Job VARCHAR(20),
Manager_id int,
Hiredate DATE , 
Salary Float,
Commission int,
Deptno INT,
FOREIGN KEY(Deptno) REFERENCES Department(Deptno)
)


 

INSERT INTO Employees VALUES (7369,'SMITH','CLERK',7902,'17-DEC-80',800,NULL,20),
(7499,'ALLEN ',' SALESMAN ' ,7698,'20-FEB-81', 1600,300,30),
(7521,'WARD','SALESMAN ',7698,'22-FEB-81',1250, 500,30),
(7566,'JONES','MANAGER',7839,'02-APR-81',2975,null,20),
(7654,'MARTIN ','SALESMAN',7698,'28-SEP-81', 1250,1400, 30),
(769,'BLAKE','MANAGER ', 7839,'01-MAY-81 ',2850,null,30),
(7782,'CLARK','MANAGER', 7839,'09-JUN-81',2450,null, 10),
(7788,'SCOTT','ANALYST',7566,'19-APR-87', 3000,null, 20),
(7839,'KING','PRESIDENT',Null,'17-NOV-81',5000,null, 10),
(7844,'TURNER','SALESMAN',7698,'08-SEP-81',1500,0,30),
(7876,'ADAMS','CLERK',7788,'23-MAY-87',1100,null,20),
(7900,'JAMES',' CLERK',7698,'03-DEC-81', 950,null, 30),
(7902,'FORD','ANALYST', 7566,'03-DEC-81',3000 , null, 20),
(7934,'MILLER','CLERK', 7782,'23-JAN-82',1300,null,10)


 
 INSERT INTO Department VALUES (10,' ACCOUNTING','NEW YORK'),
(20,'RESEARCH',' DALLAS'),
(30,'SALES','CHICAGO'),
(40,' OPERATIONS','BOSTON') 

---1.	Write a query to display your birthday( day of week)
select DATENAME(WEEKDAY,'04/30/2003') [Day of week]


--2.	Write a query to display your age in days

  create or alter function fn_DateOfbirth(@dob date)
  returns int
  as
  begin
  declare @age int
  set @age = datediff(day,@dob,getdate())
  return @age
  end

 select dbo.fn_DateOfbirth('04/30/2003') [Age_In_Days]

  --3.	Write a query to display all employees information those who joined before 5 years in the current month
 -- select * from Employees where date
 update Employees set hiredate='04/30/2019'  where Empno=7566
  update Employees set hiredate='04/30/2020'  where Empno=7654
   update Employees set hiredate='04/30/2020'  where Empno=7876
    update Employees set hiredate='04/30/2020'  where Empno=7902

 select * from Employees where Hiredate<DATEADD(year,-5,GETDATE()) and MONTH(hiredate)=MONTH(getdate())

 select * from Employees

 ---4.	Create table Employee with empno, ename, sal, doj columns or use and perform the following operations in a single transaction
---a. First insert 3 rows 
--b. Update the second row sal with 15% increment  
 -- c. Delete first row.
--After completing above all actions, recall the deleted row without losing increment of second row.
create table emp(
empno int identity(1,1),
ename varchar(20),
sal float,
doj date,
)
drop table emp
begin transaction
INSERT INTO emp VALUES('Manisha',30000,'10/16/2020'),
('Alekhya',25000,'12/04/2023'),
('Rakesh',35000,'01/01/2022')
update emp set sal=sal*1.15 where empno=2
delete from emp where empno=1

rollback transaction

select * from emp

--5.      Create a user defined function calculate Bonus for all employees of a  given dept using 	following conditions
	--a.     For Deptno 10 employees 15% of sal as bonus.
	--b.     For Deptno 20 employees  20% of sal as bonus
	--c      For Others employees 5%of sal as bonus




    create or alter function fn_CalculateBonus(@deptid int)
  returns table
  as
   return (select Empno,salary,Deptno from Employees  where Empno=@deptid)
  
select * from dbo.fn_CalculateBonus(7369)

select Empno,salary*0.10 from dbo.fn_CalculateBonus(7369) where deptno=10

select Empno,salary*0.20 from dbo.fn_CalculateBonus(7369) where deptno=20

select Empno,salary*0.05 from dbo.fn_CalculateBonus(7369) 










 ---6. Create a procedure to update the salary of employee by 500 whose dept name is Sales and current salary is below 1500 (use emp table)
 create or alter proc UpdatedSalary
 as
 begin
 update Employees set Salary=Salary+500
 where Deptno=30 and Salary<1500
 end
 exec UpdatedSalary

 select * from Employees
