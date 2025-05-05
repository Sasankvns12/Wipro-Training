SELECT Department, MAX(Salary) AS HighestSalary
FROM Employees
GROUP BY Department;