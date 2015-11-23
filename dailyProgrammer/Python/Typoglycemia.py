#!/usr/bin/env python
"""Typoglycemia.py: User will enter a string, then the program will apply 'typoglycemia' to the sentences.
					Currently is not functioning as intended; puntuation throws off the mixing algorithm."""
__author__      = "Shawn Giroux (shawn.giroux90@gmail.com)"

import random                            # Used to shuffle letters around

def scrambleWord(sentence):
	complete = ""

	test = sentence.split()              # Breaks string down into a list of letters for scrambling
	for x in test:
		x = list(x)
		if len(x) > 3:                   # If word is 3 letters long, it does not need to be scrambled ("are" still equals "are")
			toShuffle = x[1:len(x)-1]    # Variable swap to manipulate only specific letters  
			random.shuffle(toShuffle)
			x[1:len(x)-1] = toShuffle
		x = ''.join(x)                   # Joins letters together
		complete += x + " "              # Finalize each word for printing

	print(complete)

print("Please enter in a sentence.")
sentence = input("> ")
scrambleWord(sentence)