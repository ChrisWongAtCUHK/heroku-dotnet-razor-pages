SELECT
  m.id,
  m.name,
  GROUP_CONCAT(a.name) AS `actors`
FROM
  movies m
  INNER JOIN movieActors ma ON ma.movieId = m.id
  INNER JOIN actors a ON a.id = ma.actorId
GROUP BY
  m.id
LIMIT
  10
OFFSET
  0