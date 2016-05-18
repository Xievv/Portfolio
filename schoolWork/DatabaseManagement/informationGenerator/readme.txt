Throwing a readme in here incase someone is curious how to navigate this project.

[customer] folder contains the python script that generates python data, it also holds
a folder called 'load_data', which contains SQL scripts to set up the customer database.

[employee] folder is pretty much the same as [customer], just for employee's.

[scripts] folder contains all the SQL scripts for generating reports, along with the 'main'
script that the batch file calls at the start.

[spools] folder holds all the information spooled out from the [script] folder.

WARNING: If you want to run this on your machine, you will have to adjust your file paths,
along with your database credentials in the batch file.  This is adjusted to work on my
machine.  Just start from the batch file, and work your way down the file path tree.  If 
you just wanted to see it working, refer to my jings.