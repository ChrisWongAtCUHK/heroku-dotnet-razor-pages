INSERT INTO
  employees (
    id,
    firstName,
    lastName,
    joinedDate,
    salary,
    departmentId
  )
VALUES
  (
    1,
    'John',
    'Smith',
    STR_TO_DATE ('1-01-1999', '%d-%m-%Y'),
    40000,
    1
  ),
  (
    2,
    '三',
    '張',
    STR_TO_DATE ('1-07-1997', '%d-%m-%Y'),
    30000,
    2
  ),
  (
    3,
    '四',
    '李',
    STR_TO_DATE ('1-10-1999', '%d-%m-%Y'),
    10000,
    3
  )