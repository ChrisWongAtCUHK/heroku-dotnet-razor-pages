CREATE TABLE
	employeeSkills (
		employeeId int (11) NOT NULL COMMENT 'Employee Id',
		skillId int (11) NOT NULL COMMENT 'Skill Id',
		FOREIGN KEY (employeeId) REFERENCES employees (id),
		FOREIGN KEY (skillId) REFERENCES skills (id)
	) ENGINE = InnoDB DEFAULT CHARSET = latin1 COLLATE = latin1_swedish_ci COMMENT = 'Employee skills';