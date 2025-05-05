SELECT FirstName, Salary
CASE
WHEN Salary >=70000 THEN 'High'
WHEN Salary >=50000 THEN 'Medium'
ELSE 'Low'
END AS SalaryBand
FROM Employees; 