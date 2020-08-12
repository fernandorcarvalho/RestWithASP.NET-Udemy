USE rest_with_asp_net_udemy;

CREATE TABLE books(
	id			int(10) NOT NULL AUTO_INCREMENT,
	Author		longtext,
	LaunchDate	datetime(6) NOT NULL,
	Price			decimal(65,2) NOT NULL,
	Title			longtext,
	PRIMARY KEY (id)
) ENGINE=InnoDB;

