Select FirstName, Marks,
CASE
WHEN Marks >=90 THEN 'A'
WHEN Marks >=75 THEN 'B'
WHEN Marks >=60 THEN 'C'
ELSE 'D'
END AS Grade
FROM Students;