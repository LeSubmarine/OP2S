CREATE TABLE Facility(
Facility_No int NOT NULL PRIMARY KEY,
Types varchar(50) NOT NULL);

CREATE TABLE Hotel(
Hotel_No int NOT NULL PRIMARY KEY,
Name varchar(50) NOT NULL,
Address varchar(50) NOT NULL);

CREATE TABLE Guest(
Guest_No int NOT NULL PRIMARY KEY,
Name varchar(50) NOT NULL,
Address varchar(50) NOT NULL);

CREATE TABLE HotelUseOfFacilities(
Hotel_Facility_No int NOT NULL PRIMARY KEY,
Hotel_No int NOT NULL FOREIGN KEY REFERENCES Hotel(Hotel_No),
Facility_No int NOT NULL FOREIGN KEY REFERENCES Facility(Facility_No),
Location varchar(50) NOT NULL
);

CREATE TABLE Room(
Room_Id int NOT NULL PRIMARY KEY,
Hotel_No int NOT NULL FOREIGN KEY REFERENCES Hotel(Hotel_No),
Types varchar(1) NOT NULL,
Room_No int NOT NULL,
Price int NOT NULL);

CREATE TABLE Booking(
Booking_No int NOT NULL PRIMARY KEY,
Hotel_No int NOT NULL FOREIGN KEY REFERENCES Hotel(Hotel_No),
Guest_No int NOT NULL FOREIGN KEY REFERENCES Guest(Guest_No),
Room_No int NOT NULL,
Date_From DateTime NOT NULL);

