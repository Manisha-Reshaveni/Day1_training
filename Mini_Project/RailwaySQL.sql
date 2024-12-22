create database Railway

---------Trains Table
 
create table Trains (
    TrainNumber varchar(10) PRIMARY KEY,
    TrainName NVARCHAR(50),
    Source NVARCHAR(50),
    Destination NVARCHAR(50),
    DateTime DATETIME,
    PriceAC FLOAT,
    PriceSleeper FLOAT,
    PriceGeneral FLOAT,
    SeatsAC INT,
    SeatsSleeper INT,
    SeatsGeneral INT
);


--====booking table
CREATE TABLE Bookings (
    BookingID INT IDENTITY(1,1) PRIMARY KEY,
    UserName VARCHAR(50),
    TrainNumber VARCHAR(10),
    Class VARCHAR(20),
    SeatsBooked INT,
    Status VARCHAR(20),
    BookingTime DATETIME,
    Refund FLOAT
);

 -------------Admin table
 CREATE TABLE Admins (
    AdminID INT IDENTITY(1,1) PRIMARY KEY,
    AdminName NVARCHAR(50),
    Password NVARCHAR(50)
);

INSERT INTO Admins (AdminName, Password) VALUES ('admin', 'adminpass123')
INSERT INTO Admins (AdminName, Password) VALUES ('manisha', '234')




 --------------------------------------procedure for bookTicket------------------------


create or alter procedure BookTicket (  @UserName varchar(50),  @TrainNumber varchar(10),  @Class varchar(20), @SeatsToBook int,@bookingstatus varchar(30) output)
as
begin
    declare @AvailableSeats int;
    select @AvailableSeats = case    
            when @Class = 'AC' then SeatsAC
            when @Class = 'Sleeper' then SeatsSleeper
            when @Class = 'General' then SeatsGeneral
            else NULL
        end
    from Trains where TrainNumber = @TrainNumber;
 
    if (@AvailableSeats >= @SeatsToBook)
    begin
        insert into Bookings (UserName, TrainNumber, Class, SeatsBooked, Status, BookingTime, Refund)
        values (@UserName, @TrainNumber, @Class, @SeatsToBook, 'Booked', GETDATE(), 0);
 
        update Trains 
        set 
            SeatsAC = CASE WHEN @Class = 'AC' THEN SeatsAC - @SeatsToBook ELSE SeatsAC END,
            SeatsSleeper = CASE WHEN @Class = 'Sleeper' THEN SeatsSleeper - @SeatsToBook ELSE SeatsSleeper END,
            SeatsGeneral = CASE WHEN @Class = 'General' THEN SeatsGeneral - @SeatsToBook ELSE SeatsGeneral END
        where TrainNumber = @TrainNumber;
 
        set @bookingstatus='Booking successful!';
    end
    else
    begin
        set @bookingstatus='Not enough seats available!';
    end
end;
 
--------------------------------------procedure for cancellation------------------------
create or alter procedure CancelBooking( @UserName varchar(50), @BookingID int,@printoutput varchar(50) output)
as
begin
    declare @TrainNumber varchar(10), @Class varchar(20), @SeatsBooked int, @Refund float
 
    select @TrainNumber = TrainNumber, @Class = Class, @SeatsBooked = SeatsBooked FROM Bookings where BookingID = @BookingID AND UserName = @UserName AND Status = 'Booked';
 
    if (@TrainNumber IS NOT NULL)
    begin
        UPDATE Trains
        set
            SeatsAC = case when @Class = 'AC' then SeatsAC + @SeatsBooked else SeatsAC end,
            SeatsSleeper = CASE WHEN @Class = 'Sleeper' THEN SeatsSleeper + @SeatsBooked ELSE SeatsSleeper END,
            SeatsGeneral = CASE WHEN @Class = 'General' THEN SeatsGeneral + @SeatsBooked ELSE SeatsGeneral END
        where TrainNumber = @TrainNumber;
 
        SET @Refund =
            CASE
                WHEN @Class = 'AC' THEN (SELECT PriceAC FROM Trains WHERE TrainNumber = @TrainNumber) * @SeatsBooked
                WHEN @Class = 'Sleeper' THEN (SELECT PriceSleeper FROM Trains WHERE TrainNumber = @TrainNumber) * @SeatsBooked
                WHEN @Class = 'General' THEN (SELECT PriceGeneral FROM Trains WHERE TrainNumber = @TrainNumber) * @SeatsBooked
                ELSE 0
            end;
 
        UPDATE Bookings SET Status = 'Cancelled', Refund = @Refund where BookingID = @BookingID;
 
        set @printoutput= 'Cancellation successful. Refund :'+'  '++cast(@Refund as varchar);
    end
    else
    begin
        set @printoutput= 'Invalid Booking ID or User Name.';
    end
end

select * from Bookings
select * from Trains

delete from Bookings where TrainNumber='12001' 







 