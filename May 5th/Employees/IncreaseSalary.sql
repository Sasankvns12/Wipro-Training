BEGIN Transaction;
UPDATE Employees
SET Salary = Salary + 2000
WHERE Department = 'HR'
COMMIT;