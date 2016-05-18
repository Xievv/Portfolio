#!/usr/bin/env python

# Script by Shawn Giroux
# Date: February 13 2016
#
# This Python script generates fake information for an Oracle Database.
# The output will be a .sql file.

import os      # For finding out directory
import time    # Finds our time elapsed
import random  # Used to generates phone numbers and select names from array
import re      # Used to pull names from raw data

# These lists will store information for randomize employees
firstNames = []
lastNames = []
streetNames = []

# departments = ['MARKETING', 'HUMAN RESOURCE', 'FINANCE', 'PRODUCTION', 'DEVELOPMENT', 'INFORMATION TECHNOLOGY']
marketSal = [3500, 3917, 4333, 4833]
hrSal = [4361, 4830, 5000, 4583]
financeSal = [5416, 5666, 5833, 4917]
develSal = [6166, 5833, 6500, 6667]
itSal = [4833, 5166, 4091, 5416]

EMPcount = 0
EADcount = 0
JOBcount = 0
EMRcount = 0

# This class fills out firstNames and lastNames list from text files
class FillList:
  # Generate a list of first names
  def genFirstNames():
    male_text = open("dist.male.first.txt", 'r')
    raw_text = male_text.readlines()
    
    for x in range(0,len(raw_text)):
      name = re.findall(r'[A-Z]\w+',raw_text[x])
      firstNames.append(name)
    
    male_text.close()
    
    female_text = open("dist.female.first.txt", 'r')
    raw_text = female_text.readlines()
    
    for x in range(0,len(raw_text)):
      name = re.findall(r'[A-Z]\w+',raw_text[x])
      firstNames.append(name)
    
    female_text.close()
    return

  # Generate a list of last names
  def genLastNames():
    last_text = open("dist.all.last.txt", 'r')
    raw_text = last_text.readlines()
    
    for x in range(0,len(raw_text)):
      name = re.findall(r'[A-Z]\w+',raw_text[x])
      lastNames.append(name)
    
    last_text.close()
    return

  # Generate street names
  def genStreetNames():
    street_text = open("streets.txt", 'r')
    raw_text = street_text.readlines()

    for x in raw_text:
      streetNames.append(x)

    street_text.close()
    return

# This class generates random personal information for employees
class InfoGen:
# Generates a random phone number with a 603 area code
  def phone():
    a = random.randint(1,9)
    b = random.randint(0,9)
    c = random.randint(0,9)
    d = random.randint(0,9)
    e = random.randint(0,9)
    f = random.randint(0,9)
    g = random.randint(0,9)
    rPhone = ("(603){0}{1}{2}-{3}{4}{5}{6}".format(a,b,c,d,e,f,g))
    return rPhone

  # Pulls a random name from firstNames list
  def firstName(nameList):
    randomFirstName = random.randint(0,len(nameList) - 1) # Generates random integer to select a random first name
    rFirstName = nameList[randomFirstName][0]         # Selects random name. [0] is because there is a nested list
    return rFirstName
    
  # Pulls a random name from lastNames list
  def lastName(nameList):
    randomLastName = random.randint(0,len(nameList) - 1)  # Generates a random integer to select a random last name
    rLastName = nameList[randomLastName][0]           # Selects random name. [0] is because there is a nested list
    return rLastName

  # Generate a street and street number (not anywhere close to accurate)
  def street():
    streetNum = random.randint(100,999)
    streetName = random.choice(streetNames)
    return str(streetNum) + " " + streetName

  # Generates cities for customers using NH statistics from 2010
  # of the top 10 cities.
  # https://en.wikipedia.org/wiki/List_of_cities_and_towns_in_New_Hampshire
  def city():
    a = random.randint(1,100)
    if (a > 0 and a <= 25):
      return "MANCHESTER"
    elif (a > 25 and a <= 45):
      return "NASHUA"
    elif (a > 45 and a <= 55):
      return "CONCORD"
    elif (a > 55 and a <= 63):
      return "DERRY"
    elif (a > 63 and a <= 70):
      return "DOVER"
    elif (a > 70 and a <= 77):
      return "ROCHESTER"
    elif (a > 77 and a <= 84):
      return "SALEM"
    elif (a > 84 and a <= 90):
      return "MERRIMACK"
    elif (a > 90 and a <= 95):
      return "HUDSON"
    elif (a > 95 and a <= 100):
      return "LONDONDERRY"
    else:
      return "Not Option"

  # Grabs the appropriate zipcode per city
  def zipcode(city):
    manchZip = ["03101","03102","03103","03104","03105","03107","03108","03109","03111"]
    nashZip = ["03060","03061","03062","03063","03064"]
    conZip = ["03301", "03302", "03303", "03305"]
    derryZip = ["03038"]
    doverZip = ["03820", "03821", "03822"]
    rochZip = ["03839", "03866", "03867", "03868"]
    salemZip = ["03089"]
    merZip = ["03054"]
    hudZip = ["03051"]
    londonZip = ["03053"]

    if (city == "MANCHESTER"):
      return random.choice(manchZip)
    elif (city == "NASHUA"):
      return random.choice(nashZip)
    elif (city == "CONCORD"):
      return random.choice(conZip)
    elif (city == "DERRY"):
      return random.choice(derryZip)
    elif (city == "DOVER"):
      return random.choice(doverZip)
    elif (city == "ROCHESTER"):
      return random.choice(rochZip)
    elif (city == "SALEM"):
      return random.choice(salemZip)
    elif (city == "MERRIMACK"):
      return random.choice(merZip)
    elif (city == "HUDSON"):
      return random.choice(hudZip)
    elif (city == "LONDONDERRY"):
      return random.choice(londonZip)
    else:
      return "Not Option"

  def keygen(label):
      # Key counts for generation
      global EMPcount
      global EADcount
      global JOBcount
      global EMRcount


      key = ""

      if label == "EMR":
        EMRcount += 1
        key = label + str(EMRcount).zfill(5)
      elif label == "EMP":
        EMPcount += 1
        key = label + str(EMPcount).zfill(5)
      elif label == "EAD":
        EADcount += 1
        key = label + str(EADcount).zfill(5)
      elif label == "JOB":
        JOBcount += 1
        key = label + str(JOBcount).zfill(5)

      return key

# This class will generate salary information depending on the department our employee works in    
class JobGen:
  def marketing():
    randomSal = random.randint(0,3)
    salary = marketSal[randomSal]
    return salary
    
  def hr():
    randomSal = random.randint(0,3)
    salary = hrSal[randomSal]
    return salary
    
  def development():
    randomSal = random.randint(0,3)
    salary = develSal[randomSal]
    return salary
    
  def finance():
    randomSal = random.randint(0,3)
    salary = financeSal[randomSal]
    return salary
    
  def infotech():
    randomSal = random.randint(0,3)
    salary = marketSal[randomSal]
    return salary
   
# This class will handle writing employee data into a text document
class Script:
  # Creates marketing employees. Note that the random integer determines the amount of employees in the department
  def marketEmp():

    employee = open("load_data/employee_info.sql", 'w')
    address = open("load_data/address_info.sql", 'w')
    job = open("load_data/job_info.sql", 'w')

    # Set back to a range of 0,23
    for x in range(0,25):
      empKey = InfoGen.keygen('EMP')
      city = InfoGen.city()

      lastname = InfoGen.lastName(lastNames)
      employee.write("INSERT INTO employee_data (EMPLOYEE_ID, FIRST_NAME, LAST_NAME) VALUES('{0}', '{1}', '{2}');\n".format(empKey, InfoGen.firstName(firstNames), lastname))
      address.write ("INSERT INTO employee_address_data (ADDRESS_ID, EMPLOYEE_ID, STREET, CITY, STATE, COUNTRY, ZIPCODE, PHONE_NUMBER) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');\n"
                     "".format(InfoGen.keygen('EAD'), empKey, InfoGen.street(), city, "NEW HAMPSHIRE", "UNITED STATES", InfoGen.zipcode(city), InfoGen.phone()))
      job.write("INSERT INTO employee_job_data (JOB_ID, EMPLOYEE_ID, DEPARTMENT, SALARY) VALUES ('{0}', '{1}', '{2}', '{3}');\n".format(InfoGen.keygen('JOB'), empKey, "MARKETING", JobGen.marketing()))

    employee.close()
    address.close()
    job.close()
    return
  
  # Creates HR employees. Note that the random integer determines the amount of employees in the department
  def hrEmp():

    employee = open("load_data/employee_info.sql", 'a+')
    address = open("load_data/address_info.sql", 'a+')
    job = open("load_data/job_info.sql", 'a+')

    for x in range(0,8):
      empKey = InfoGen.keygen('EMP')
      city = InfoGen.city()

      lastname = InfoGen.lastName(lastNames)
      employee.write("INSERT INTO employee_data (EMPLOYEE_ID, FIRST_NAME, LAST_NAME) VALUES('{0}', '{1}', '{2}');\n".format(empKey, InfoGen.firstName(firstNames), lastname))
      address.write ("INSERT INTO employee_address_data (ADDRESS_ID, EMPLOYEE_ID, STREET, CITY, STATE, COUNTRY, ZIPCODE, PHONE_NUMBER) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');\n"
                     "".format(InfoGen.keygen('EAD'), empKey, InfoGen.street(), city, "NEW HAMPSHIRE", "UNITED STATES", InfoGen.zipcode(city), InfoGen.phone()))
      job.write("INSERT INTO employee_job_data (JOB_ID, EMPLOYEE_ID, DEPARTMENT, SALARY) VALUES ('{0}', '{1}', '{2}', '{3}');\n".format(InfoGen.keygen('JOB'), empKey, "HUMAN RESOURCE", JobGen.hr()))

    employee.close()
    address.close()
    job.close()
    return
   
  # Creates finance employees. Note that the random integer determines the amount of employees in the department
  def financeEmp():

    employee = open("load_data/employee_info.sql", 'a+')
    address = open("load_data/address_info.sql", 'a+')
    job = open("load_data/job_info.sql", 'a+')

    for x in range(0,7):
      empKey = InfoGen.keygen('EMP')
      city = InfoGen.city()

      lastname = InfoGen.lastName(lastNames)
      employee.write("INSERT INTO employee_data (EMPLOYEE_ID, FIRST_NAME, LAST_NAME) VALUES('{0}', '{1}', '{2}');\n".format(empKey, InfoGen.firstName(firstNames), lastname))
      address.write ("INSERT INTO employee_address_data (ADDRESS_ID, EMPLOYEE_ID, STREET, CITY, STATE, COUNTRY, ZIPCODE, PHONE_NUMBER) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');\n"
                     "".format(InfoGen.keygen('EAD'), empKey, InfoGen.street(), city, "NEW HAMPSHIRE", "UNITED STATES", InfoGen.zipcode(city), InfoGen.phone()))
      job.write("INSERT INTO employee_job_data (JOB_ID, EMPLOYEE_ID, DEPARTMENT, SALARY) VALUES ('{0}', '{1}', '{2}', '{3}');\n".format(InfoGen.keygen('JOB'), empKey, "FINANCE", JobGen.finance()))

    employee.close()
    address.close()
    job.close()
    return
   
  # Creates development employees. Note that the random integer determines the amount of employees in the department
  def develEmp():

    employee = open("load_data/employee_info.sql", 'a+')
    address = open("load_data/address_info.sql", 'a+')
    job = open("load_data/job_info.sql", 'a+')

    for x in range(0,31):
      empKey = InfoGen.keygen('EMP')
      city = InfoGen.city()

      lastname = InfoGen.lastName(lastNames)
      employee.write("INSERT INTO employee_data (EMPLOYEE_ID, FIRST_NAME, LAST_NAME) VALUES('{0}', '{1}', '{2}');\n".format(empKey, InfoGen.firstName(firstNames), lastname))
      address.write ("INSERT INTO employee_address_data (ADDRESS_ID, EMPLOYEE_ID, STREET, CITY, STATE, COUNTRY, ZIPCODE, PHONE_NUMBER) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');\n"
                     "".format(InfoGen.keygen('EAD'), empKey, InfoGen.street(), city, "NEW HAMPSHIRE", "UNITED STATES", InfoGen.zipcode(city), InfoGen.phone()))
      job.write("INSERT INTO employee_job_data (JOB_ID, EMPLOYEE_ID, DEPARTMENT, SALARY) VALUES ('{0}', '{1}', '{2}', '{3}');\n".format(InfoGen.keygen('JOB'), empKey, "DEVELOPMENT", JobGen.development()))

    employee.close()
    address.close()
    job.close()
    return
    
  # Creates IT employees. Note that the random integer determines the amount of employees in the department
  def itEmp():

    employee = open("load_data/employee_info.sql", 'a+')
    address = open("load_data/address_info.sql", 'a+')
    job = open("load_data/job_info.sql", 'a+')

    for x in range(0,4):
      empKey = InfoGen.keygen('EMP')
      city = InfoGen.city()

      lastname = InfoGen.lastName(lastNames)
      employee.write("INSERT INTO employee_data (EMPLOYEE_ID, FIRST_NAME, LAST_NAME) VALUES('{0}', '{1}', '{2}');\n".format(empKey, InfoGen.firstName(firstNames), lastname))
      address.write ("INSERT INTO employee_address_data (ADDRESS_ID, EMPLOYEE_ID, STREET, CITY, STATE, COUNTRY, ZIPCODE, PHONE_NUMBER) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');\n"
                     "".format(InfoGen.keygen('EAD'), empKey, InfoGen.street(), city, "NEW HAMPSHIRE", "UNITED STATES", InfoGen.zipcode(city), InfoGen.phone()))
      job.write("INSERT INTO employee_job_data (JOB_ID, EMPLOYEE_ID, DEPARTMENT, SALARY) VALUES ('{0}', '{1}', '{2}', '{3}');\n".format(InfoGen.keygen('JOB'), empKey, "INFORMATION TECHNOLOGY", JobGen.infotech()))

    employee.close()
    address.close()
    job.close()
    return
   
  # Creates production employees. Note that the random integer determines the amount of employees in the department
    
startTime = time.time() # Gets current time to compare with the end time

# Fill out name lists
FillList.genFirstNames()
FillList.genLastNames()
FillList.genStreetNames()

# Run our employee generation scripts
Script.marketEmp()
Script.hrEmp()
Script.financeEmp()
Script.develEmp()
Script.itEmp()

elapsedTime = (time.time() - startTime) # Tells us the elapsed time

currentDir = os.getcwd() # Current directory to let user know where their file is

print("\nProcess Complete! Elapsed time: {0} seconds".format(str(int(elapsedTime))))