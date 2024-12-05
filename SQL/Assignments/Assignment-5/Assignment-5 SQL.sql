--1. Write a T-Sql based procedure to generate complete payslip of a given employee with respect to the following condition

  -- a) HRA as 10% of Salary
  -- b) DA as 20% of Salary
  -- c) PF as 8% of Salary
  -- d) IT as 5% of Salary
  -- e) Deductions as sum of PF and IT
  -- f) Gross Salary as sum of Salary, HRA, DA
  -- g) Net Salary as Gross Salary - Deductions

--Print the payslip neatly with all details
use ASSIGNMENTS

create or alter procedure PaySlip    @empid int
as
begin
declare @HRA float
declare @DA float
declare @PF float
declare @IT float
declare @Deduction float
declare @GrossSalary float
declare @NetSalary float,@salary float
select @Salary=salary from Employees where Empno=@empid
set @HRA=@Salary*0.10
set @DA=@Salary*0.20
set @PF=@Salary*0.08
set @IT=@Salary*0.05;
set @Deduction=(@PF+@IT)
set @GrossSalary= (@HRA+@DA)
set @NetSalary=@GrossSalary-@Deduction
print 'PaySlip for EmployeeId:'+' '+cast(@empid as varchar(20))

print 'Salary:'+cast(@salary as varchar(20))

print 'HRA as 10% of Salary'+' '+cast(@HRA as varchar(20))

print 'DA as 20% of Salary'+' '+cast(@DA as varchar(20))

print 'PF as 8% of Salary'+' '+cast(@PF as varchar(20))

print 'IT as 5% of Salary'+' '+cast(@IT as varchar(20))

print 'Deduction'+' '+cast(@Deduction as varchar(20))

print 'Gross Salary'+' '+cast(@GrossSalary as varchar(20))

print 'Net Salary'+' '+cast(@NetSalary as varchar(20))
end

exec PaySlip 7902

--2.  Create a trigger to restrict data manipulation on EMP table during General holidays. Display 
--the error message like “Due to Independence day you cannot manipulate data” or "Due To Diwali", you cannot manipulate" etc
--Note: Create holiday table with (holiday_date,Holiday_name). Store at least 4 holiday details. try to match and stop manipulation 

create table Holidays(
Holiday_date date,
Holiday_name varchar(20),
)
INSERT INTO Holidays values('2022-01-01','New Year'),
('2022-01-26','Republic Day'),
('2022-03-18','Holi'),
('2022-04-14','Ambedhkar Jayanti'),
('2022-04-15','Good Friday'),
('2022-08-15','Independence Day'),
('2022-10-02','Gandhi Jayanti'),
('2022-10-06','Dussehra'),
('2022-11-01','Diwali')
select * from Holidays


create or alter trigger Restrict_data_manipulation 
on Employees
for insert,update,delete
as
begin
declare @date date
set @date='2022-01-26'
declare @tblHoliday date
if exists (select Holiday_date from Holidays where Holiday_date=@date)
begin
declare @holidat_name varchar(50)
set @holidat_name=(select Holiday_name from Holidays where Holiday_date=@date)
raiserror ('Due to holiday %s data manipulation is not possible in employee',14,3,@holidat_name)
rollback 
end
end

select * from employees

insert into employees values(1111,'manisha','developer',7521,'2020-10-16',6000,700,30)

delete from Employees where Empno=1111






