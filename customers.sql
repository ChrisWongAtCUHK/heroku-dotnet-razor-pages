CREATE TABLE customers (
	id int(11) auto_increment NULL,
	name varchar(100) NULL,
	PRIMARY KEY(id)
)
ENGINE=InnoDB
DEFAULT CHARSET=latin1
COLLATE=latin1_swedish_ci
COMMENT='Customers';

INSERT INTO customers
(id, name)
VALUES(1, 'Customer 1');