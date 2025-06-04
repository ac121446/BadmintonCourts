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