spool C:\Users\Shawn\Desktop\informationGenerator\spools\distinct_zipcodes.txt
set linesize 80
SELECT DISTINCT zipcode, city
FROM customer_address_data
ORDER BY zipcode;
spool off