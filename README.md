# PR_Assignment1_CO2Data
 
Programming	Assessment	Exercise
School	of	Information	Sciences.		Rev. 11/2017
Download	the	two	data	files from	this	Moodle	“Assignment”.		
They	are	called	“co2_hawaii.txt”	and	“co2_alaska.txt”.		
These	files	are	from	the	U.S.	National	Oceanic	and	Atmospheric	Administration(NOAA).		
They	contain	over	40	years	of	measurements	of	carbon	dioxide	levels	(CO2)	in	the	
atmosphere,	taken	from	instruments	at	Barrow,	Alaska	and	Mauna	Loa,	Hawaii.
Use	a	text	editor	to	view	and	familiarize	yourself	with their contents	and	format,	but	make	sure	you	do	
not	modify	the	input	files.		
There	are	detailed	comments	in the	data files	explaining	the	meaning	of	each	column	in	the	data.

Time	yourself	as	you	work	on	this	program.		When	finished,	you’ll	be	asked	how	long	you	
worked	on	it.
You	may	use any	general-purpose	programming	language	of	your	choice (whatever	you’re	most	
comfortable	using).		Do	not	use	Microsoft	Excel	or	another	spreadsheet	application,	nor SQL,
SAS	or	SPSS.		Those	are not	general-purpose	languages.

1. Read	the	unmodified	files and	load all	the	data values	into	some	kind	of	appropriate	array,	
matrix, or	similar	data	structure(s).
2. Parse	the	Quality	Control	Flags to	know	which	rows	have	invalid	data	that	must	be	ignored	in	
calculations.	Typically,	you’ll	see	“-999.99”	in	place	of	the	co2	value,	but	there	may	be	other	
kinds	of	invalid	rows,	so	determine	validity	from	the	“qcflag” column	only.
3. Calculate	the	following	items	PER	YEAR,	and	output	a	new	text	file called	“annual_co2.txt”
containing	a table	with	year	down	the	side	and	each	column	heading	indicated,	for	both	
locations.:
a. “MAX_LEVEL”:		The	highest CO2 daily	level	recorded.
b. “MEAN_LEVEL”:		The	mean	(average)	of daily	CO2 levels recorded.
c. “%CHANGE”:	Percentage	change	of	“Mean	level”	compared	to	previous	year.	
Arrange the	output	data	like	this,	and	round	the	mean	CO2	values to	2	decimal	places:
ALASKA HAWAII
YEAR MAX_LEVEL MEAN_LEVEL %CHANGE MAX_LEVEL MEAN_LEVEL %CHANGE
1973
1974
1975
…
2015
2016

4. Then	have	the	program	calculate	the	mean	of	the	annual	“%CHANGE” results	for	each	location,	
and	add	those	results	below	the	table
You can find the files co2_hawaii and co2_alaska in the code itself.