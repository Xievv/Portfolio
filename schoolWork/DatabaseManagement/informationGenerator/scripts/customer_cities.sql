spool C:\Users\Shawn\Desktop\informationGenerator\spools\customer_cities\manchester_customers.txt
set linesize 150
SELECT customer_data.first_name, customer_data.last_name, customer_address_data.street, customer_address_data.zipcode
FROM customer_data
INNER JOIN customer_address_data
ON customer_address_data.customer_id = customer_data.customer_id
WHERE customer_address_data.city like 'MANCHESTER'
ORDER BY customer_address_data.zipcode, customer_data.last_name;
spool off

spool C:\Users\Shawn\Desktop\informationGenerator\spools\customer_cities\nashua_customers.txt
set linesize 150
SELECT customer_data.first_name, customer_data.last_name, customer_address_data.street, customer_address_data.zipcode
FROM customer_data
INNER JOIN customer_address_data
ON customer_address_data.customer_id = customer_data.customer_id
WHERE customer_address_data.city like 'NASHUA'
ORDER BY customer_address_data.zipcode, customer_data.last_name;
spool off

spool C:\Users\Shawn\Desktop\informationGenerator\spools\customer_cities\concord_customers.txt
set linesize 150
SELECT customer_data.first_name, customer_data.last_name, customer_address_data.street, customer_address_data.zipcode
FROM customer_data
INNER JOIN customer_address_data
ON customer_address_data.customer_id = customer_data.customer_id
WHERE customer_address_data.city like 'CONCORD'
ORDER BY customer_address_data.zipcode, customer_data.last_name;
spool off

spool C:\Users\Shawn\Desktop\informationGenerator\spools\customer_cities\derry_customers.txt
set linesize 150
SELECT customer_data.first_name, customer_data.last_name, customer_address_data.street, customer_address_data.zipcode
FROM customer_data
INNER JOIN customer_address_data
ON customer_address_data.customer_id = customer_data.customer_id
WHERE customer_address_data.city like 'DERRY'
ORDER BY customer_address_data.zipcode, customer_data.last_name;
spool off

spool C:\Users\Shawn\Desktop\informationGenerator\spools\customer_cities\dover_customers.txt
set linesize 150
SELECT customer_data.first_name, customer_data.last_name, customer_address_data.street, customer_address_data.zipcode
FROM customer_data
INNER JOIN customer_address_data
ON customer_address_data.customer_id = customer_data.customer_id
WHERE customer_address_data.city like 'DOVER'
ORDER BY customer_address_data.zipcode, customer_data.last_name;
spool off

spool C:\Users\Shawn\Desktop\informationGenerator\spools\customer_cities\rochester_customers.txt
set linesize 150
SELECT customer_data.first_name, customer_data.last_name, customer_address_data.street, customer_address_data.zipcode
FROM customer_data
INNER JOIN customer_address_data
ON customer_address_data.customer_id = customer_data.customer_id
WHERE customer_address_data.city like 'ROCHESTER'
ORDER BY customer_address_data.zipcode, customer_data.last_name;
spool off

spool C:\Users\Shawn\Desktop\informationGenerator\spools\customer_cities\salem_customers.txt
set linesize 150
SELECT customer_data.first_name, customer_data.last_name, customer_address_data.street, customer_address_data.zipcode
FROM customer_data
INNER JOIN customer_address_data
ON customer_address_data.customer_id = customer_data.customer_id
WHERE customer_address_data.city like 'SALEM'
ORDER BY customer_address_data.zipcode, customer_data.last_name;
spool off

spool C:\Users\Shawn\Desktop\informationGenerator\spools\customer_cities\merrimack_customers.txt
set linesize 150
SELECT customer_data.first_name, customer_data.last_name, customer_address_data.street, customer_address_data.zipcode
FROM customer_data
INNER JOIN customer_address_data
ON customer_address_data.customer_id = customer_data.customer_id
WHERE customer_address_data.city like 'MERRIMACK'
ORDER BY customer_address_data.zipcode, customer_data.last_name;
spool off

spool C:\Users\Shawn\Desktop\informationGenerator\spools\customer_cities\hudson_customers.txt
set linesize 150
SELECT customer_data.first_name, customer_data.last_name, customer_address_data.street, customer_address_data.zipcode
FROM customer_data
INNER JOIN customer_address_data
ON customer_address_data.customer_id = customer_data.customer_id
WHERE customer_address_data.city like 'HUDSON'
ORDER BY customer_address_data.zipcode, customer_data.last_name;
spool off

spool C:\Users\Shawn\Desktop\informationGenerator\spools\customer_cities\londonderry_customers.txt
set linesize 150
SELECT customer_data.first_name, customer_data.last_name, customer_address_data.street, customer_address_data.zipcode
FROM customer_data
INNER JOIN customer_address_data
ON customer_address_data.customer_id = customer_data.customer_id
WHERE customer_address_data.city like 'LONDONDERRY'
ORDER BY customer_address_data.zipcode, customer_data.last_name;
spool off