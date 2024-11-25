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

--1. List all employees whose name begins with 'A'. 
SELECT * FROM Employees WHERE Ename like 'A%'

--2. Select all those employees who don't have a manager.
SELECT * FROM Employees WHERE Manager_id is null

--3. List employee name, number and salary for those employees who earn in the range 1200 to 1400. 
SELECT Ename,Empno,Salary FROM Employees where salary Between 1200 and 1400

--4. Give all the employees in the RESEARCH department a 10% pay rise. Verify that this has been done
--by listing all their details before and after the rise.
SELECT Empno, Ename, Job, Manager_id, Hiredate, Commission,Salary as 'Before Rise ',(salary*1.10) as 'after rise'
from Employees join Department on Employees.Deptno=Department.Deptno WHERE Dname='RESEARCH'

--5. Find the number of CLERKS employed. Give it a descriptive heading. 
SELECT count(Job) as 'Descriptive' FROM Employees where Job='CLERK' 

--6. Find the average salary for each job type and the number of people employed in each job.
SELECT job, AVG(Salary)  as 'AVERAGE SALARY',COUNT(job) as 'Number of employes' FROM Employees group by Job 

--7. List the employees with the lowest and highest salary. 
SELECT MIN(Salary) as 'lowest salary' ,MAX(Salary) as 'Highest salary' FROM Employees 

--8. List full details of departments that don't have any employees. 
SELECT * FROM Department WHERE Deptno NOT IN(SELECT Deptno FROM Employees)

--9. Get the names and salaries of all the analysts earning more than 1200 
--who are based in department 20. Sort the answer by ascending order of name. 
SELECT Ename,Salary,Job FROM Employees WHERE Job='ANALYST' and Salary>1200 and Deptno=20 ORDER BY Ename ASC

--10. For each department, list its name and number together with the total salary paid 
--to employees in that department. 
SELECT D.Dname,D.Deptno,SUM(E.Salary) as 'Total Salary' FROM Department D
 left join Employees E on D.Deptno=E.Deptno GROUP BY D.Dname ,D.Deptno

 --11. Find out salary of both MILLER and SMITH.
 SELECT Ename,Salary From Employees WHERE Ename in('MILLER','SMITH');

 --12. Find out the names of the employees whose name begin with ‘A’ or ‘M’.
 SELECT Ename FROM Employees WHERE Ename LIKE 'A%' OR  Ename LIKE 'M%'

 --13. Compute yearly salary of SMITH. 
 SELECT (Salary*12) as 'Yearly salary' From Employees where Ename='SMITH'

 --14. List the name and salary for all employees whose salary is not in the range of 1500 and 2850. 
 SELECT Ename,Salary FROM Employees WHERE Salary NOT BETWEEN 1500 AND 2850

 --15. Find all managers who have more than 2 employees reporting to them
 SELECT Manager_id ,COUNT(*) FROM Employees GROUP BY Manager_id HAVING COUNT(*)>2

