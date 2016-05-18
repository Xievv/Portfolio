import random
import re

# Consider making a class the fills in characteristics and create objects
# from that class.  Then build my sql scripts from those object characteristics.
# Things were added throughout the process for this class, so the code became
# progressively more messy and poorly structured.

maleFirstNames = []
femaleFirstNames = []
lastNames = []
streetNames = []

CUScount = 0
ADRcount = 0
DEMcount = 0

class Script:

	# Fills our name lists with the proper genders for determining gender later
	def genFirstNames():

		#This section fills maleFirstNames list from a text file
		male_text = open("dist.male.first.txt", 'r')
		raw_text = male_text.readlines()

		for x in range(0,len(raw_text)):
		  name = re.findall(r'[A-Z]\w+',raw_text[x])
		  maleFirstNames.append(name)

		male_text.close()

		# This section fills femaleFirstNames list from a text file
		female_text = open("dist.female.first.txt", 'r')
		raw_text = female_text.readlines()

		for x in range(0,len(raw_text)):
		  name = re.findall(r'[A-Z]\w+',raw_text[x])
		  femaleFirstNames.append(name)

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

	def genStreetNames():
		street_text = open("streets.txt", 'r')
		raw_text = street_text.readlines()

		for x in raw_text:
			streetNames.append(x)

		street_text.close()
		return

	def keygen(label):
		# Key counts for generation
		global CUScount
		global ADRcount
		global DEMcount

		key = ""

		if label == "CUS":
			CUScount += 1
			key = label + str(CUScount).zfill(5)
		elif label == "ADR":
			ADRcount += 1
			key = label + str(ADRcount).zfill(5)
		elif label == "DEM":
			DEMcount += 1
			key = label + str(DEMcount).zfill(5)

		return key

class Person:
	# Generates male names
	def maleName(nameList):
		randomFirstName = random.randint(0,len(nameList) - 1) # Generates random integer to select a random first name
		rFirstName = nameList[randomFirstName][0]         # Selects random name. [0] is because there is a nested list
		return rFirstName

	# Generates female names
	def femaleName(nameList):
		randomFirstName = random.randint(0,len(nameList) - 1)
		rFirstName = nameList[randomFirstName][0]
		return rFirstName

		# Pulls a random name from lastNames list

	# Generates last names
	def lastName(nameList):
		randomLastName = random.randint(0,len(nameList) - 1)  # Generates a random integer to select a random last name
		rLastName = nameList[randomLastName][0]           # Selects random name. [0] is because there is a nested list
		return rLastName

	# Generates random package id key
	def package():
		a = random.randint(1,10)
		if (a > 0 and a <= 3):
			return "PCK_3"
		elif (a > 3 and a <= 8):
			return "PCK_2"
		elif (a > 8 and a <= 10):
			return "PCK_1"
		else:
			return "Not Option"

	# Generates ethnicity based off NH stats
	def ethnicity():
		a = random.randint(1,100)
		if (a > 0 and a <= 97):
			return "WHITE"
		elif (a > 97 and a <= 99):
			return "ASIAN"
		elif (a > 99 and a <= 100):
			return "BLACK"
		else:
				return "Not Option"

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

	# Generates a phone number
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

	# Selects a marriage status based of united states marriage stats
	def marriageStatus():
		a = random.randint(1,10)
		if (a > 0 and a <= 2):
			return "YES"
		elif (a > 2 and a <= 10):
			return "NO"
		else:
			return "Not Option"

def generate(quantity):
	Script.genFirstNames()
	Script.genLastNames()
	Script.genStreetNames()
	
	# Open file to dump out SQL code into text file
	customer = open("load_data/customer_data.sql", 'w')
	addresses = open("load_data/addresses_data.sql", 'w')
	demographics = open("load_data/demographics.sql", 'w')

	# Loops the amount of times a user selects and generates people into SQL code
	for x in range(0, quantity):
		# Used for picking a random gender
		pickGender = random.randint(1,2)

		# Variables that hold customer information
		cusKey = Script.keygen("CUS") # Customer table prefix for key
		adrKey = Script.keygen("ADR") # Address table prefix for key
		demKey = Script.keygen("DEM") # Demographic table prefix for key

		firstName = ""
		lastName = Person.lastName(lastNames)
		package = Person.package()
		gender = ""
		street = Person.street()
		city = Person.city()
		state = "NEW HAMPSHIRE" # All customers are from new hampshire
		country = "UNITED STATES"
		zipcode = Person.zipcode(city)
		phone = Person.phone()
		ethnicity = Person.ethnicity()
		marriage = Person.marriageStatus()

		# Determines gender based off last name
		if pickGender == 1:
			firstName = Person.maleName(maleFirstNames)
			gender = "MALE"
		elif pickGender == 2:
			firstName = Person.femaleName(femaleFirstNames)
			gender = "FEMALE"

		# Generates SQL code
		customer.write("INSERT INTO customer_data (CUSTOMER_ID, PACKAGE_ID, FIRST_NAME, LAST_NAME)"
					   "VALUES ('{0}', '{1}', '{2}', '{3}');\n".format(cusKey, package,firstName, lastName))
		addresses.write("INSERT INTO customer_address_data (ADDRESS_ID, CUSTOMER_ID, STREET, CITY, STATE, COUNTRY, ZIPCODE, PHONE_NUMBER) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');\n"
			           "".format(adrKey, cusKey, street, city, state, country, zipcode, phone))
		demographics.write("INSERT INTO customer_demographics (DEMOGRAPHICS_ID, CUSTOMER_ID, GENDER, ETHNICITY, MARRIAGE_STATUS)"
			           "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');\n".format(demKey, cusKey, gender, ethnicity, marriage))

	# Close text file to properly save data
	customer.close()
	addresses.close()
	demographics.close()

def main():
	quantity = input("How many people do you want to generate? ")
	generate(int(quantity))
	print("Process Complete")

main()