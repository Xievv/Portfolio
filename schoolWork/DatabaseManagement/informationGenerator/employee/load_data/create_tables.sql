create table employee_data
(
	EMPLOYEE_ID VARCHAR(8) NOT NULL PRIMARY KEY,
	FIRST_NAME VARCHAR(15) NOT NULL,
	LAST_NAME VARCHAR(15) NOT NULL
);

create table employee_address_data
(
	ADDRESS_ID VARCHAR(8) NOT NULL PRIMARY KEY,
	EMPLOYEE_ID VARCHAR(8) NOT NULL,
	STREET VARCHAR(25) NOT NULL,
	CITY VARCHAR(11) NOT NULL,
	STATE VARCHAR(13) NOT NULL,
	COUNTRY VARCHAR(13) NOT NULL,
	ZIPCODE VARCHAR(5) NOT NULL,
	PHONE_NUMBER VARCHAR(13),
	CONSTRAINT fk_employeeID FOREIGN KEY (EMPLOYEE_ID)
	REFERENCES employee_data(EMPLOYEE_ID)
);

CREATE TABLE employee_job_data
(
	JOB_ID VARCHAR(8) NOT NULL PRIMARY KEY,
	EMPLOYEE_ID VARCHAR(8) NOT NULL,
	DEPARTMENT VARCHAR(22) NOT NULL,
	SALARY NUMBER NOT NULL,
	FOREIGN KEY (EMPLOYEE_ID)
	REFERENCES employee_data(EMPLOYEE_ID)
);