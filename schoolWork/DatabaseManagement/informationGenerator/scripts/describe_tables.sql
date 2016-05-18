spool C:\Users\Shawn\Desktop\informationGenerator\spools\describe_tables.txt
set echo on
set linesize 80
desc employee_data;
desc employee_address_data;
desc employee_job_data;
desc customer_packages;
desc customer_data;
desc customer_address_data;
desc customer_demographics;
spool off