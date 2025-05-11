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
EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, 
PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) 
VALUES
('1', 'Smith', 'John', '123-456-7890', 'johnsmith', 'JOHNSMITH', 'john@example.com', 'JOHN@EXAMPLE.COM', 1, 'AQAAAAIAAYagAAAAE123456...', 'ABCDEF123', 'XYZ987654', 1, 0, NULL, 1, 0),
('2', 'Johnson', 'Emily', '234-567-8901', 'emilyjohnson', 'EMILYJOHNSON', 'emily@example.com', 'EMILY@EXAMPLE.COM', 1, 'AQAAAAIAAYagAAAAE654321...', 'GHIJKL456', 'LMN789012', 1, 0, NULL, 1, 0),
('3', 'Brown', 'Michael', '345-678-9012', 'michaelbrown', 'MICHAELBROWN', 'michael@example.com', 'MICHAEL@EXAMPLE.COM', 1, 'AQAAAAIAAYagAAAAE789123...', 'MNOPQR789', 'UVW123456', 1, 0, NULL, 1, 0),
('4', 'Davis', 'Sophia', '456-789-0123', 'sophiadavis', 'SOPHIADAVIS', 'sophia@example.com', 'SOPHIA@EXAMPLE.COM', 1, 'AQAAAAIAAYagAAAAE456789...', 'STUVWX012', 'ABC345678', 1, 0, NULL, 1, 0),
('5', 'Wilson', 'Daniel', '567-890-1234', 'danielwilson', 'DANIELWILSON', 'daniel@example.com', 'DANIEL@EXAMPLE.COM', 1, 'AQAAAAIAAYagAAAAE012345...', 'YZABC6789', 'DEF901234', 1, 0, NULL, 1, 0),
('6', 'Martinez', 'Olivia', '678-901-2345', 'oliviamartinez', 'OLIVIAMARTINEZ', 'olivia@example.com', 'OLIVIA@EXAMPLE.COM', 1, 'AQAAAAIAAYagAAAAE987654...', 'GHIJKL321', 'MNO543210', 1, 0, NULL, 1, 0),
('7', 'Anderson', 'William', '789-012-3456', 'williamanderson', 'WILLIAMANDERSON', 'william@example.com', 'WILLIAM@EXAMPLE.COM', 1, 'AQAAAAIAAYagAAAAE321987...', 'PQRSTU456', 'VWX789012', 1, 0, NULL, 1, 0),
('8', 'Garcia', 'Isabella', '890-123-4567', 'isabellagarcia', 'ISABELLAGARCIA', 'isabella@example.com', 'ISABELLA@EXAMPLE.COM', 1, 'AQAAAAIAAYagAAAAE654789...', 'YZABC1234', 'DEF567890', 1, 0, NULL, 1, 0),
('9', 'Lopez', 'James', '901-234-5678', 'jameslopez', 'JAMESLOPEZ', 'james@example.com', 'JAMES@EXAMPLE.COM', 1, 'AQAAAAIAAYagAAAAE852963...', 'MNOXYZ456', 'UVW098765', 1, 0, NULL, 1, 0),
('10', 'Taylor', 'Mia', '012-345-6789', 'miataylor', 'MIATAYLOR', 'mia@example.com', 'MIA@EXAMPLE.COM', 1, 'AQAAAAIAAYagAAAAE741258...', 'ABCPQR123', 'GHI345678', 1, 0, NULL, 1, 0);
GO

INSERT INTO Equipment (EquipmentID, EName, EType, EPrice)
VALUES
(1, 'Yonex Astrox 88D Pro', 'Racket', 5.00),
(2, 'Victor Thruster Ryuga II', 'Racket', 4.50),
(3, 'Li-Ning Aeronaut 9000C', 'Racket', 4.00),
(4, 'Babolat Satelite Gravity 74', 'Racket', 3.50),
(5, 'Carlton Kinesis X900', 'Racket', 3.00),
(6, 'Yonex Aerosensa 50', 'Shuttlecock', 30.00),
(7, 'Victor Master No.1', 'Shuttlecock', 28.00),
(8, 'Li-Ning A+600', 'Shuttlecock', 25.00),
(9, 'RSL Tourney No.1', 'Shuttlecock', 27.00),
(10, 'FeatherFlex Pro 12', 'Shuttlecock', 20.00);
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

INSERT INTO Payment (PaymentID, BookingID, PaymentAmount, PaymentDate, PaymentStatus)
VALUES
(1, 1, 20.00, '2024-03-25', 'Paid'),
(2, 2, 15.00, '2024-03-26', 'Paid'),
(3, 3, 30.00, '2024-03-27', 'Pending'),
(4, 4, 25.00, '2024-03-28', 'Paid'),
(5, 5, 18.00, '2024-03-29', 'Paid'),
(6, 6, 22.00, '2024-03-30', 'Pending'),
(7, 7, 28.00, '2024-03-31', 'Paid'),
(8, 8, 35.00, '2024-04-01', 'Paid'),
(9, 9, 12.00, '2024-04-02', 'Pending'),
(10, 10, 40.00, '2024-04-03', 'Paid');
GO