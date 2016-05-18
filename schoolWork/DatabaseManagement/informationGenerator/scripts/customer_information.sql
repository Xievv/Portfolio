spool C:\Users\Shawn\Desktop\informationGenerator\spools\customer_information\customer_information.txt
set linesize 150
SELECT customer_data.first_name, customer_data.last_name, street, city, state, country, zipcode
FROM customer_address_data
INNER JOIN customer_data
ON customer_address_data.customer_id = customer_data.customer_id
ORDER BY city, last_name;
spool off

spool C:\Users\Shawn\Desktop\informationGenerator\spools\customer_information\customer_demographics.txt
set linesize 150
SELECT customer_data.first_name, customer_data.last_name, gender, ethnicity, marriage_status
FROM customer_demographics
INNER JOIN customer_data
ON customer_demographics.customer_id = customer_data.customer_id
ORDER BY gender, ethnicity;
spool off

spool C:\Users\Shawn\Desktop\informationGenerator\spools\customer_information\manchester_package_deals.txt
set linesize 150
SELECT customer_data.first_name, customer_data.last_name, customer_address_data.city, customer_packages.type, customer_packages.price
FROM customer_data
INNER JOIN customer_address_data
ON customer_data.customer_id=customer_address_data.customer_id
INNER JOIN customer_packages
ON customer_data.package_id=customer_packages.package_id
WHERE customer_address_data.city LIKE 'MANCHESTER'
ORDER BY customer_packages.price DESC;
spool off