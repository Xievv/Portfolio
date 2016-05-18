from urllib.request import urlopen
import re

# Used zillow.com to grab a list of street names.
html = urlopen('http://www.zillow.com/browse/homes/nh/hillsborough-county/03103/')

streetsuffix = ["st", "ave", "way", "dr", "ct", "rd"]
streets = []

pull = open("geewilikersbatman.txt", 'r')

for i in pull:
	if re.findall('>\w+\s\w+<', i):
		test = re.findall('>\w+\s\w+<', i)
		again = re.findall('\w+\s\w+', test[0])
		for x in streetsuffix:
			check = again[0].lower()
			if check.find(x) != -1:
				streets.append(again[0])

dump = open("streets.txt", 'w')

for x in streets:
	dump.write(x.upper() + '\n')

dump.close()
pull.close()