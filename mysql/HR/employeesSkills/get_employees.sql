DROP PROCEDURE IF EXISTS get_employees;

DELIMITER $$
$$
CREATE PROCEDURE get_employees(skip INT, take INT)
BEGIN
  SELECT
    e.id,
    e.firstName,
    e.lastName,
    e.joinedDate,
    e.salary,
    d.name AS `departmentName`,
    GROUP_CONCAT(s.title) AS `skills`
  FROM
    employees e
    INNER JOIN departments d ON d.id = e.departmentId
    LEFT JOIN employeesSkills es ON es.employeeId = e.id
    LEFT JOIN skills s ON s.id = es.skillId
  GROUP BY
    e.id
  LIMIT
    take
  OFFSET
    skip;
END$$
DELIMITER ;
-- SHOW CREATE PROCEDURE get_employees
-- CALL get_employees(0, 10)
