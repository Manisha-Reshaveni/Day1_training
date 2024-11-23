
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
INSERT INTO Departments VALUES(10,'Design','Pune'),
(20,'Development','Pune'),
(30,'Design','Mumbai'),
(40,'Testing','Mumbai')

--Employees table

create table Employees(
Empno int PRIMARY KEY,
Ename VARCHAR(20) NOT NULL,
job VARCHAR(15),
Salary BIGINT CHECK (salary>0),
Deptno int REFERENCES Departments(Depno)
)
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

--PROJECTS TABLE
CREATE TABLE Projects(
Project_ID INT PRIMARY KEY,
Descr VARCHAR(30) NOT NULL,
Start_Date DATE,
Planned_End_date DATE,
Actual_End_Date DATE ,
Budget BIGINT CHECK(Budget>0),
Client_ID INT REFERENCES Clients(Client_ID)
)
select*from Projects
ALTER TABLE Projects
ADD CONSTRAINT Chekcact CHECK (Actual_End_Date > Planned_End_date)
INSERT INTO Projects VALUES(401,'Inventary','2000-04-01','2011-10-01','2002-10-31',150000,1001)
INSERT INTO Projects(Project_ID,Descr,Start_Date,Planned_End_date,Budget,Client_ID) VALUES(401,'Inventory','2011/01/11','10/01/11',15000,1001)
DELETE from Projects Where Project_ID=401;


--EmpProjectsTasks TABLE 
CREATE TABLE EmpProjectsTasks(
Project_ID int REFERENCES Projects(Project_ID),
Empno int REFERENCES Employees(Empno),
Start_Date DATE,
End_Date DATE,
Task VARCHAR(25) NOT NULL,
Status VARCHAR(15) NOT NULL
)
SELECT * FROM EmpProjectsTasks
drop table EmpProjectsTasks
INSERT INTO EmpProjectsTasks VALUES(401,7001,'2011-04-01','2011-04-20','System Analyst','Completed')



