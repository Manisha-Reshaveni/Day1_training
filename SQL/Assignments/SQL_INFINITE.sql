
--Clients table

create table Clients(
Client_ID int PRIMARY KEY,
Cname varchar(40) NOT NULL,
Address varchar(30),
Email varchar(30) UNIQUE,
Phone BIGINT,
Bussiness varchar(20) NOT NULL
)
select * from Clients
SELECT * FROM Departments
INSERT INTO Clients values(1001,'ACME Utilities','Noida','contact@acmeutil.com',9567880032,'Manufacturing'),
(1002,'Trackon Consultants','Mumbai','consult@trackon.com',8734210090,'Consultant'),
(1003,'MoneySaver Distributors','Kolkata','save@moneysaver.com',7799886655,'Reseller'),
(1004,'Lawful Corp','chennai','justice@lawful.com',9210342219,'Professional')

--Department Table
create table Departments(
Depno int PRIMARY KEY,
Dname VARCHAR(15),
Loc VARCHAR(20)
)
select * from  Departments
INSERT INTO Departments VALUES(10,'Design','Pune'),
(20,'Development','Pune'),
(30,'Design','Mumbai'),
(40,'Testing','Mumbai')


sp_help Departments


--Employees table

create table Employees(
Empno int PRIMARY KEY,
Ename VARCHAR(20) NOT NULL,
job VARCHAR(15),
Salary BIGINT CHECK (salary>0),
Deptno int REFERENCES Departments(Depno)
)
select * from  Employees
INSERT INTO Employees VALUES(7001,'sandeep','Analyst',25000,10),
(7002,'Rajesh','Designer',30000,10),
(7003,'Madhav','Developer',40000,20),
(7004,'Manoj','Developer',40000,20),
(7005,'Abhay','Designer',35000,10),
(7006,'Uma','Tester',30000,30),
(7007,'Gita','Tech.Writer',30000,40),
(7008,'Priya','Tester',35000,30),
(7009,'Nutan','Developer',45000,20),
(7010,'Smitha','Analyst',20000,10),
(7011,'Anand','Project Mgr',65000,10)

sp_help Employees

--PROJECTS TABLE
CREATE TABLE Project(
Project_ID INT PRIMARY KEY,
Descr VARCHAR(30) NOT NULL,
Start_Date DATE,
Planned_End_date DATE,
Actual_End_Date DATE,
Budget BIGINT CHECK(Budget>0),
Client_ID INT REFERENCES Clients(Client_ID)
)
select*from Project

ALTER TABLE Project
ADD CONSTRAINT chechkac CHECK (Actual_End_Date > Planned_End_date) 
INSERT INTO Project  VALUES(401,'Inventary','01-Apr-11','01-Oct-11','31-Oct-11',150000,1001)
INSERT INTO Project VALUES(402,'Accounting','01-Aug-11','01-Jan-11',null,500000,1002)
INSERT INTO Project VALUES(403,'Payroll','01-Oct-11','31-Dec-11',null,75000,1003)
INSERT INTO Project VALUES(404,'Contact Mgmt','01-Nov-11','31-Dec-11',null,50000,1002)

sp_help Project

--EmpProjectsTasks TABLE 
CREATE TABLE EmployeProjectsTask(
Project_ID int REFERENCES Project(Project_ID),
Empno int REFERENCES Employees(Empno),
Start_Date DATE,
End_Date DATE,
Task VARCHAR(25) NOT NULL,
Status VARCHAR(15) NOT NULL
constraint TwoComposite_key PRIMARY KEY(Project_ID,Empno)
)
SELECT * FROM EmployeProjectsTask

drop table EmployeProjectsTask

INSERT INTO EmployeProjectsTask VALUES(401,7001,'2011-04-01','2011-04-20','System Analyst','Completed'),
(401,7002,'21-Apr-11','30-May-11','System Analyst','Completed'),
(401,7003,'01-Jun-11','15-Jul-11','Coding','Completed'),
(401,7004,'18-Jul-11','01-Sep-11','Coding ','Completed'),
(401,7006,'03-Sep-11','15-Sep-11','Testing','Completed'),
(401,7009,'18-Sep-11','5-Oct-11','Code Change','Completed'),
(401,7008,'06-Oct-11','16-Oct-11','Testing','Completed'),
(401,7007,'06-Oct-11','22-Oct-11','Documentation','Completed'),
(401,7011,'22-Oct-11','31-Oct-11','Sign off','Completed'),
(402,7010,'01-Aug-11','20-Aug-11','System Analysis','Completed'),
(402,7002,'22-Aug-11','30-Sep-11','System Design','Completed'),
(402,7004,'01-Oct-11',null,'Coding','In Progress')








