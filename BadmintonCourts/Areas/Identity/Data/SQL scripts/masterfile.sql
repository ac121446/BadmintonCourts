INSERT INTO Location (LocationName, Addresss, Suburb, City, PostalCode, PhoneNumber)
VALUES
('Rathlambgay', '123 Arena Rd', 'Parnell', 'Auckland', '1010', '09-123-4567'),
('Riverside Hub', '456 Court St', 'Te Aro', 'Wellington', '6011', '04-234-5678'),
('Mountain View Center', '789 Riccarton Rd', 'Riccarton', 'Christchurch', '8041', '03-876-5432'),
('Harborfront Square', '101 George St', 'Central Dunedin', 'Dunedin', '9016', '03-432-1234'),
('Victoria Gardens', '202 Victoria St', 'Central Hamilton', 'Hamilton', '3204', '07-987-6543'),
('Lakeview Heights', '303 Lakeview Rd', 'Queenstown Central', 'Queenstown', '9300', '03-234-5678'),
('Sunrise Park', '404 Fenton St', 'Fenton Park', 'Rotorua', '3010', '07-321-4321'),
('Bayview Complex', '505 Takitimu Dr', 'Mount Maunganui', 'Tauranga', '3116', '07-678-1234'),
('Seaview Towers', '606 Marine Parade', 'Ahuriri', 'Napier', '4110', '06-334-4455'),
('Pinehill Plaza', '707 Main St', 'Central Palmerston', 'Palmerston North', '4410', '06-123-9876');
GO

INSERT INTO Court (LocationID, CourtName, CourtType, Price)
VALUES
(1, 'Court 1', 'Singles', 30.00),
(2, 'Court 2', 'Doubles', 40.00),
(3, 'Court 3', 'Singles', 25.00),
(4, 'Court 4', 'Doubles', 45.00),
(5, 'Court 5', 'Singles', 35.00),
(6, 'Court 6', 'Doubles', 50.00),
(7, 'Court 7', 'Singles', 28.00),
(8, 'Court 8', 'Doubles', 38.00),
(9, 'Court 9', 'Singles', 33.00),
(10, 'Court 10', 'Doubles', 42.00);
GO

INSERT INTO AspNetUsers 
(Id, LastName, FirstName, PhoneNumber, UserName, NormalizedUserName, Email, NormalizedEmail, 
 EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, Phone, 
 PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) 
VALUES
(1, 'Smith', 'John', '+1234567890', 'jsmith', 'JSMITH', 'john.smith@example.com', 'JOHN.SMITH@EXAMPLE.COM', 1, 'AQAAAAEAACcQAAAAEOk1Tz...', 'stamp1', 'concstamp1', '+1234567890', 1, 0, NULL, 1, 0),
(2, 'Doe', 'Jane', '+1987654321', 'jdoe', 'JDOE', 'jane.doe@example.com', 'JANE.DOE@EXAMPLE.COM', 1, 'AQAAAAEAACcQAAAAEF2UZy...', 'stamp2', 'concstamp2', '+1987654321', 1, 0, NULL, 1, 0),
(3, 'Brown', 'Michael', '+1122334455', 'mbrown', 'MBROWN', 'michael.brown@example.com', 'MICHAEL.BROWN@EXAMPLE.COM', 0, 'AQAAAAEAACcQAAAAEpx7kJ...', 'stamp3', 'concstamp3', '+1122334455', 0, 1, NULL, 1, 1),
(4, 'Taylor', 'Emily', '+1098765432', 'etaylor', 'ETAYLOR', 'emily.taylor@example.com', 'EMILY.TAYLOR@EXAMPLE.COM', 1, 'AQAAAAEAACcQAAAAEoZkME...', 'stamp4', 'concstamp4', '+1098765432', 1, 0, NULL, 0, 0),
(5, 'Johnson', 'Chris', '+1230984567', 'cjohnson', 'CJOHNSON', 'chris.johnson@example.com', 'CHRIS.JOHNSON@EXAMPLE.COM', 1, 'AQAAAAEAACcQAAAAEMX9wZ...', 'stamp5', 'concstamp5', '+1230984567', 1, 1, NULL, 1, 2);
GO

INSERT INTO Equipment (EName, EType, EPrice)
VALUES
('Yonex Astrox 88D Pro', 'Racket', 5.00),
('Victor Thruster Ryuga II', 'Racket', 4.50),
('Li-Ning Aeronaut 9000C', 'Racket', 4.00),
('Babolat Satelite Gravity 74', 'Racket', 3.50),
('Carlton Kinesis X900', 'Racket', 3.00),
('Yonex Aerosensa 50', 'Shuttlecock', 30.00),
('Victor Master No.1', 'Shuttlecock', 28.00),
('Li-Ning A+600', 'Shuttlecock', 25.00),
('RSL Tourney No.1', 'Shuttlecock', 27.00),
('FeatherFlex Pro 12', 'Shuttlecock', 20.00);
GO

INSERT INTO Booking (UserID, CourtID, EquipmentID, BookingDate, StartTime, EndTime, TotalPrice)
VALUES
(1, 2, 3, '2025-04-01', '14:00:00', '16:00:00', 50.00),
(2, 1, 4, '2025-04-02', '09:00:00', '11:00:00', 40.00),
(3, 3, 5, '2025-04-03', '12:00:00', '14:00:00', 55.00),
(4, 2, 6, '2025-04-04', '16:00:00', '18:00:00', 60.00),
(5, 1, 7, '2025-04-05', '08:00:00', '10:00:00', 45.00),
(6, 4, 8, '2025-04-06', '15:00:00', '17:00:00', 70.00),
(7, 3, 2, '2025-04-07', '10:00:00', '12:00:00', 35.00),
(8, 1, 3, '2025-04-08', '11:00:00', '13:00:00', 50.00),
(9, 2, 4, '2025-04-09', '13:00:00', '15:00:00', 55.00),
(10, 4, 5, '2025-04-10', '17:00:00', '19:00:00', 60.00);
GO

INSERT INTO Payment (BookingID, PaymentAmount, PaymentDate, PaymentStatus)
VALUES
(1, 20.00, '2024-03-25', 'Paid'),
(2, 15.00, '2024-03-26', 'Paid'),
(3, 30.00, '2024-03-27', 'Pending'),
(4, 25.00, '2024-03-28', 'Paid'),
(5, 18.00, '2024-03-29', 'Paid'),
(6, 22.00, '2024-03-30', 'Pending'),
(7, 28.00, '2024-03-31', 'Paid'),
(8, 35.00, '2024-04-01', 'Paid'),
(9, 12.00, '2024-04-02', 'Pending'),
(10, 40.00, '2024-04-03', 'Paid');
GO