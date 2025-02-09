CREATE TABLE
	`employees` (
		`id` int (11) NOT NULL AUTO_INCREMENT,
		`firstName` varchar(100) CHARACTER
		SET
			utf8mb4 DEFAULT NULL COMMENT 'First Name',
			`lastName` varchar(100) COLLATE utf8mb4_bin NOT NULL COMMENT 'Last Name',
			`joinedDate` date DEFAULT NULL COMMENT 'Joined Date',
			`salary` decimal DEFAULT NULL COMMENT 'Salary',
			`departmentId` int (11) NOT NULL COMMENT 'Department id',
			PRIMARY KEY (`id`),
			FOREIGN KEY (departmentId) REFERENCES departments(id)
	) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_bin COMMENT = 'Employees'