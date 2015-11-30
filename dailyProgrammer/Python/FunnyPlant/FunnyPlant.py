def funnyPlant(people, fruitPlants):
	fruitHarvest = 0
	fruit = []
	weeks = 0

	for x in range(fruitPlants):
		fruit.append(0)

	while(fruitHarvest < people):
		fruitHarvest = sum(fruit)
		if fruitHarvest > 0:
			for x in range(fruitHarvest):
				fruit.append(0)
		for x in range(len(fruit)):
			fruit[x] += 1
		weeks += 1

	print("People: %d\nFruit: %d\nWeeks: %d"% (people, fruitHarvest, weeks))

people = input("Enter number of people: ")         # Number of people to support
fruitPlants = input("Enter number of plants: ")    # Number of plants to start

funnyPlant(int(people), int(fruitPlants));