-- DROP PROCEDURE IF EXISTS get_employee 
DELIMITER $$
CREATE PROCEDURE get_employee()  
BEGIN
	SELECT * FROM `employees` 
END
END $$
DELIMITER ; -- this resets the semi-colon as a delimiter for further coding
