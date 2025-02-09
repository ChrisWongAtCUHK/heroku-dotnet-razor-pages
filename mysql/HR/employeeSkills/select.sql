SELECT
  e.*,
  d.name,
  s.title
FROM
  employees e
  INNER JOIN departments d ON d.id = e.departmentId
  JOIN employeeSkills es ON es.employeeId = e.id
  INNER JOIN skills s ON s.id = es.skillId