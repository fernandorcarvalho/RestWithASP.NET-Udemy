USE rest_with_asp_net_udemy;

CREATE TABLE persons (
	id					INT(10) 		UNSIGNED,
	FirstName		VARCHAR(50),
	LastName			VARCHAR(50),
	Address			VARCHAR(50),
	Gender			VARCHAR(50)
)
ENGINE=INNODB;


ALTER TABLE persons CHANGE ID ID INT(10) AUTO_INCREMENT PRIMARY KEY;