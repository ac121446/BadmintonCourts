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