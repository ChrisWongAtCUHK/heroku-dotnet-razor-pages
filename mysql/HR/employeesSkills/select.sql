SELECT
  e.id,
  e.firstName,
  e.lastName,
  e.joinedDate,
  e.salary,
  d.name,
  GROUP_CONCAT(s.title) AS `skills`
FROM
  employees e
  INNER JOIN departments d ON d.id = e.departmentId
  INNER JOIN employeesSkills es ON es.employeeId = e.id
  INNER JOIN skills s ON s.id = es.skillId
GROUP BY e.id