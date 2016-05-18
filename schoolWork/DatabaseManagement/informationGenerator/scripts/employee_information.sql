spool C:\Users\Shawn\Desktop\informationGenerator\spools\employee_information\employee_information.txt
set linesize 150
SELECT first_name, last_name, employee_address_data.phone_number, employee_job_data.salary, employee_job_data.department
FROM employee_data
INNER JOIN employee_address_data
ON employee_data.employee_id=employee_address_Data.employee_id
INNER JOIN employee_job_data
ON employee_data.employee_id=employee_job_data.employee_id
ORDER BY employee_job_data.department, employee_job_data.salary DESC;
spool off

spool C:\Users\Shawn\Desktop\informationGenerator\spools\employee_information\employee_addresses.txt
set linesize 150
SELECT employee_data.first_name, employee_data.last_name, street, city, state, country, zipcode
FROM employee_address_data
INNER JOIN employee_data
ON employee_address_data.employee_id=employee_data.employee_id
ORDER BY city, zipcode, employee_data.last_name;
spool off