create database Assessments
use Assessments

 create table Book
 (
 Book_ID int PRIMARY KEY,
 Title varchar(20),
 author varchar(20),
 Isbn BIGINT unique,
 published_date DATETIME
 )
 select * from Book
 INSERT INTO Book VALUES(1,'My first SQL Book','mary parker',9214483029127,'2012-02-22 12:08:17'),
 (2,'My second SQL Book','John mayer',857300923713,'1972-07-03 09:22:45'),
  (3,'My Third SQL Book','Cary Flint',523120967812,'2015-10-18 14:05:44')
  --Write a query to fetch the details of the books written by author whose name ends with er.
  select* from Book where author like '%er'

  create table Reviewer
  (
  ID int REFERENCES Book(Book_ID),
  book_id int ,
  Review_name varchar(20),
  content varchar(20),
  rating int,
  Publish_date DATETIME
  )
  SELECT * FROM Reviewer
  INSERT INTO  Reviewer VALUES(1,1,'John Smith','my first SQL book',4,'2017-12-10 05:50:11.1'),
  (1,2,'John Smith','my second SQL book',5,'2017-10-13 15:50:22.6'),
  (1,2,'Alice Walker','my third SQL book',1,'2017-10-22 23:47:10')
  update Reviewer set id=3 where Review_name='Alice Walker'
    update Reviewer set id=2 where rating=5
  --Display the Title ,Author and ReviewerName for all the books from the above table
  select b.Title,b.author,r.Review_name from Book b  join Reviewer r on b.Book_ID=r.ID 
  --Display the reviewer name who reviewed more than one book.
  select Review_name,count(*) as books from Reviewer group by Review_name having COUNT(*)>1

  create table Customer
  (
  ID int,
  Name varchar(20),
  Age int,
  Address varchar(20),
  Salary float
  )
  INSERT INTO Customer VALUES(1,'Rakesh',32,'Ahmedabad',2000.00),
  (2,'Khilan',25,'Delhi',1500.00),
  (3,'Kaushik',23,'kota',2000.00),
  (4,'Chaitali',25,'Mumbai',6500.00),
  (5,'Hardik',27,'Bhopal',8500.00),
  (6,'komal',24,'MP',4500.00),
   (7,'komal',24,'Indor',10000.00)
   select* from Customer
   --Display the Name for the customer from above customer table who live
   --in same address which has character o anywhere in addres
   select Name from Customer where Address like '%o%'

create table Orders
(
OID int,
Date DATETIME,
Customer_ID int,
Amount float
)
select * from Orders
INSERT INTO Orders VALUES(102,'2009-11-08 00:00:00',3,3000),
(100,'2009-11-08 00:00:00',3,1500),
(101,'2009-11-20 00:00:00',2,1560),
(103,'2008-05-20 00:00:00',4,2060)
--Write a query to display the Date,Total no of customer placed order on same Date
select Date,COUNT(*) as 'Total_numberof customers' from Orders group by Date

create table Employee
(
  ID int,
  EName varchar(20),
  EAge int,
  EAddress varchar(20),
  ESalary float
)
  INSERT INTO Employee VALUES(1,'Rakesh',32,'Ahmedabad',2000.00),
  (2,'Khilan',25,'Delhi',1500.00),
  (3,'Kaushik',23,'kota',2000.00),
  (4,'Chaitali',25,'Mumbai',6500.00),
  (5,'Hardik',27,'Bhopal',8500.00),
  (6,'komal',24,'MP',null),
   (7,'komal',24,'Indor',null)
   select * from Employee
   --Display the Names of the Employee in lower case, whose salary is null
   select Ename ,LOWER(Ename)as 'lower' from Employee where ESalary is null;

create table Student_Details
(
Register_NO INT,
Student_Name VARCHAR(20),
Age int,
Qualification varchar(10),
Mobile_NO BIGINT,
Mail_ID varchar(30),
Location varchar(20),
Gender varchar(10),
)
select * from Student_Details
INSERT INTO Student_Details VALUES(2,'sai',22,'B.E',9952836777,'sai@gmail.com','Chennai','M'),
(3,'Kumar',22,'BSE',7890125648,'Kumar@gmail.com','Madhurai','M'),
(2,'selvi',22,'B.TECH',890457342,'selvi@gmail.com','selam','F'),
(2,'Nisha',22,'M.E',7834672316,'Nisha@gmail.com','Theni','F'),
(2,'saisaran',22,'B.A',7890125678,'saisaran@gmail.com','Madhurai','F'),
(2,'tom',22,'B.CA',8901234675,'sai@gmail.com','pune','M')
--Write a sql server query to display the Gender,Total no of male and female from the above
select Gender,COUNT(*) as 'Total' from Student_Details group by Gender 