use ASSIGNMENTS
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
select* from Department
select * from Employees


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



--1. Retrieve a list of MANAGERS. 
select Ename as 'Managers list',Empno from Employees where  Empno in(select Manager_id from Employees)

--2. Find out the names and salaries of all employees earning more than 1000 per 
--month.
select Ename,Salary as 'salary greater than 1000'  from Employees where salary>1000

--3. Display the names and salaries of all employees except JAMES.
select Ename,Salary from Employees 
except
select Ename,Salary from Employees where Ename='JAMES'
---or--
select Ename,Salary from Employees where Ename!='JAMES'


--4. Find out the details of employees whose names begin with ‘S’.
select * from Employees where Ename like 's%'

--5. Find out the names of all employees that have ‘A’ anywhere in their name. 
select * from Employees where Ename like '%A%'

--6. Find out the names of all employees that have ‘L’ as their third character in 
select * from Employees where Ename like '__L%'

--7. Compute daily salary of JONES.
select (salary/30) as 'daily salary' from Employees where Ename='JONES'

--8. Calculate the total monthly salary of all employees.
select Ename,sum(salary) as 'Total monthly salary' from Employees

--9. Print the average annual salary .
select Ename,Avg(salary*12) as 'Annual salary' from Employees group by Ename

--10. Select the name, job, salary, department number of all employees except 
--SALESMAN from department number 30. 
select Ename,job,salary,Deptno from Employees where Empno not in(select Empno from Employees where job='SALESMAN' and deptno=30)

--11. List unique departments of the EMP table.
select Dname,count(distinct (dname)) from Department group by dname

--12. List the name and salary of employees who earn more than 1500 and are in department 10 or 30. Label the columns Employee and Monthly Salary respectively.
select ename,salary as 'Monthly salary' from Employees where salary>1500 and Deptno in (10,20) 

--13. Display the name, job, and salary of all the employees whose job is MANAGER or 
--ANALYST and their salary is not equal to 1000, 3000, or 5000.
select Ename,job,salary from Employees where job='MANAGER' or job='ANALYST' and Salary not in(1000,3000,5000)

--14. Display the name, salary and commission for all employees whose commission 
--amount is greater than their salary increased by 10%. 
select Ename,salary,salary+(salary*10/100) as 'salary increased 10%',commission from Employees where commission>salary+(salary*10/100)

--15. Display the name of all employees who have two Ls in their name and are in 
--department 30 or their manager is 7782. 
select Ename from Employees where Ename like '%L%L%' and Deptno in(20,30) or Manager_id=7782

--16. Display the names of employees with experience of over 30 years and under 40 yrs.
 --Count the total number of employees.
 select hiredate,cast( DATEDIFF(yyyy,Hiredate,GETDATE()) as int) as 'Experience',ename from Employees where  
 cast( DATEDIFF(yyyy,Hiredate,GETDATE()) as int)>30 and cast( DATEDIFF(yyyy,Hiredate,GETDATE()) as int)<40

 --17. Retrieve the names of departments in ascending order and their employees in 
--descending order. 
select E.Ename,D.Dname FROM  Employees E join Department D on E.Deptno=D.Deptno order by D.Dname asc,E.Ename desc

--18. Find out experience of MILLER. 
 select hiredate,cast( DATEDIFF(yyyy,Hiredate,GETDATE()) as int)  as 'Experience',ename from Employees where ename='MILLER'
