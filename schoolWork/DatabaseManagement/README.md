# Database Management Section

## Preface

In this class, we worked with Oracle 11g.  I was a little disappointed with the scope of this class, since I could have passed it just fine doing some basic SQL stuff.  I decided to make something out of it, and practice my scripting skills while I was at it.  This class was for my third semester at Manchester Community College.

## Overview

I decided to create a database for a fake streaming company that I never named.  I wrote two python scripts that would generate both the customers, and employees that would be in the database.  By the time the class was done, I had it running on one batch file to start up oracle, load the database, and print out my spools.  The idea was that I would be able to walk into class and always have my database with me.

## Customer Folder

This folder contains the python script that generates fake customers that live in New Hampshire based off of a list of first and last names that I grabbed from a government website, along with some New Hampshire statistics.  The load_data folder has the customer information split into three files named addresses_data.sql, customer_data.sql, and demographics_data.sql.  The other scripts in there also help set up the customers table, along with a drop_tables script to quickly erase everything.

## Employee Folder

The employee folder is very similar to the customer folder, but with a little less information being needed.  Other than that, it was essentially the same process, but the fake employees were generated a little bit differently.

## Scripts Folder

This folder has a script called "run_scripts.sql".  It would run all the other scripts within this folder, and those scripts just made spools of the data in the database.  Headings.sql was added to format the columns to give the headers more meaning.

## Spools Folder

A folder that contains the spools from our scripts folder.

## Streets Info Folder

I wanted the name of Manchester streets, which unfortunately wasn't as easy as getting a large list of first and last names.  I thought about it for a bit, and discovered that realtor websites have a good collection of street names per zipcode.  Originally, I was going to grab all the street names from each zipcode for every city in my python script, but I decided to settle for just streets in 03103.  Turns out that approximentally 400 streets names was enough to save my sanity.  I pulled the html from Zillow.com, conveniently named geewilikersbatman since I asked one of my friends what to call the file.  I then used address.py to extract the street names from the list and turned that into streets.txt.