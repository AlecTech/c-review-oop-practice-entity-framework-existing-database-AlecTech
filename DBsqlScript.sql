DROP TABLE IF EXISTS PhoneNumber;
DROP TABLE IF EXISTS Person;

CREATE TABLE Person (
	ID		INT(10)		PRIMARY KEY AUTO_INCREMENT,
	FirstName	VARCHAR(50)	NOT NULL,
	LastName	VARCHAR(50)	NOT NULL
); 
CREATE TABLE PhoneNumber (
	ID		INT(10)	PRIMARY KEY AUTO_INCREMENT,
	Number	CHAR(12)	NOT NULL,
	PersonID	INT(10)	NOT NULL,
	CONSTRAINT FK_PhoneNumber_Person FOREIGN KEY (PersonID) REFERENCES Person(ID)
);
INSERT INTO Person (FirstName, LastName)
VALUES	('John',	'Doe'), 
('Jane',	'Doe'), 
('Tommy',	'Wiseau'), 
('Jimmy',	'Smith'), 
('Sally',	'Smith');
INSERT INTO PhoneNumber (Number, PersonID)
VALUES	('800-555-0110',	1),
('800-555-0115',	2), 
('800-555-0112',	3), 
('800-555-0114',	3), 
('800-555-0140',	3),  
('800-555-0130',	4), 
('800-555-0135',	5), 
('800-555-0138',	5) ;
