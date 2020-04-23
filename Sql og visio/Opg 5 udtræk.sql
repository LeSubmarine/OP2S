SELECT * FROM Hotel;
SELECT * FROM Hotel WHERE Address LIKE '% Roskilde';
SELECT Name,Address FROM Guest WHERE Address LIKE '% Roskilde';
SELECT Name,Address FROM Guest WHERE Address LIKE '% Roskilde' ORDER BY Name;
SELECT * FROM Room WHERE Price < 200 AND Types = 'D';
SELECT * FROM Room WHERE Price < 400 AND (Types = 'D' OR Types = 'F');
SELECT * FROM Room WHERE Price < 400 AND (Types = 'D' OR Types = 'F') ORDER BY Price DESC;
SELECT * FROM Guest WHERE Name LIKE 'G%';


SELECT COUNT(*) FROM Hotel;
SELECT COUNT(*) FROM Hotel WHERE Address LIKE '% Roskilde';
SELECT AVG(Price) FROM Room;
SELECT AVG(Price) FROM Room WHERE Types = 'S';
SELECT AVG(Price) FROM Room WHERE Types = 'D';
SELECT AVG(Price) FROM Room WHERE Hotel_No = (SELECT Hotel_No FROM Hotel WHERE Name LIKE '%Scandic%');
SELECT SUM(Price) FROM Room;
SELECT COUNT(DISTINCT Guest_No) FROM Booking WHERE Date_From LIKE '%-03-%' OR Date_To Like '%-03-%';
SELECT COUNT(*) FROM Booking LEFT JOIN Hotel ON Booking.Hotel_No = Hotel.Hotel_No WHERE Booking.Date_From < GETDATE() AND Booking.Date_To > GETDATE() AND Hotel.Name LIKE '%Scandic%';
SELECT COUNT(*) FROM Booking LEFT JOIN Hotel ON Booking.Hotel_No = Hotel.Hotel_No WHERE Booking.Date_From < GETDATE()+1 AND Booking.Date_To > GETDATE()+1 AND Hotel.Name LIKE '%Scandic%';
SELECT * FROM Room WHERE Hotel_No = (SELECT Hotel_No FROM Hotel WHERE Name LIKE '%Prindsen%');
SELECT Guest.Guest_No,Guest.Name,Guest.Address FROM Guest LEFT JOIN Booking ON Guest.Guest_No = Booking.Guest_No LEFT JOIN Hotel ON Booking.Hotel_No = Hotel.Hotel_No WHERE Hotel.Name LIKE '%Prindsen%' AND Booking.Date_From < GETDATE() AND Booking.Date_To > GETDATE();
SELECT Hotel.Name,Count(Room.Room_No) AS NumberOfRooms FROM Hotel LEFT JOIN Room ON Hotel.Hotel_No = Room.Hotel_No GROUP BY Hotel.Name;
SELECT Hotel.Name,Count(Room.Room_No) AS NumberOfRooms FROM Hotel LEFT JOIN Room ON Hotel.Hotel_No = Room.Hotel_No WHERE Address LIKE '% Roskilde' GROUP BY Hotel.Name;
--SELECT COUNT()/COUNT(DemoHotel) FROM DemoBooking LEFT JOIN DemoHotel ON DemoBooking.Hotel_No = DemoHotel.Hotel_No WHERE (MONTH(DemoBooking.Date_From) = MONTH(GETDATE()) OR MONTH(DemoBooking.Date_To) = MONTH(GETDATE())) AND YEAR(DemoBooking.Date_From) = YEAR(GETDATE());




--SELECT * FROM DemoGuest;
--INSERT INTO DemoGuest VALUES (31,'Tony','DJFUCKDJFUCK 666, 1000 Nederland');
--INSERT INTO DemoGuest VALUES (32,'Tchobi','Aufvierlangvej 33, 2610 brrtbrrt');
--INSERT INTO DemoGuest VALUES (33,'EYYYY','Aufvierlangvej 34, 2620 LamoGtfo');
--INSERT INTO DemoGuest VALUES (34,'TchobiMenNummer2','Aufvierlangvej 32, 2610 brrtbrrt');
--SELECT* FROM DemoGuest;
SELECT * FROM Room;
UPDATE Room SET Price = Price * 1.1;
SELECT * FROM Room;
