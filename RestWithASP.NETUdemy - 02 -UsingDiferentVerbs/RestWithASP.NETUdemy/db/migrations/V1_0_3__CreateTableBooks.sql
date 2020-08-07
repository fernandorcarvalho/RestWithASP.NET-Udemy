USE rest_with_asp_net_udemy;

CREATE TABLE IF NOT EXISTS books(
	id			varchar(127) NOT NULL,
	Author		longtext,
	LaunchDate	datetime(6) NOT NULL,
	Price			decimal(65,2) NOT NULL,
	Title			longtext,
	PRIMARY KEY (id)
) ENGINE=InnoDB;