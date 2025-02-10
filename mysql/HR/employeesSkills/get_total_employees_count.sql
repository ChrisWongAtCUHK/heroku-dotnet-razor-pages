DROP PROCEDURE IF EXISTS get_employees;

DELIMITER $$
$$
CREATE PROCEDURE get_total_employees_count()
BEGIN
  SELECT
    COUNT(DISTINCT e.id) AS `count`
  FROM
      employees e
  INNER JOIN departments d ON d.id = e.departmentId
  INNER JOIN employeesSkills es ON es.employeeId = e.id
  INNER JOIN skills s ON s.id = es.skillId;
END$$
DELIMITER ;
-- SHOW CREATE PROCEDURE get_employees
-- CALL get_employees(0, 10)
