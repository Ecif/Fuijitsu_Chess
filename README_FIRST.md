Fuijitsu_Chess
==============
I've included input and output file samples within "~\Fuijitsu_Chess\SourceFiles" folder.

*IMPORTANT!
After building project, add "SourceFiles" folder to your build folder like this:
"~\Fuijitsu_Chess\bin\Debug\SourceFiles". 
All input files are read from that folder and output files are found from that folder.
E.g:
"~\Fuijitsu_Chess\bin\Debug\SourceFiles\input.txt" 
"~\Fuijitsu_Chess\bin\Debug\SourceFiles\output.txt"

Parameters for running the application:
"Fuijitsu_Chess.exe args[0] args[1]"
args[0] = input file name
args[1] = output file name
E.g:
"C:\Fuijitsu_Chess\bin\Debug>Fuijitsu_Chess.exe source.txt output.txt"


INTRODUCTION FOR INPUT AND OUTPUT FILES:
------------------------------------------------------------------------------------------
Maximum board size: 8x8
Chess pieces: Knight(default), King, Queen, Rook, Bishop

Here's what sample input file(input.txt) contains:
----(input.txt)-----
8           [ First row is for board X-axis length. ]
8           [ Second row is for board Y-axis length. ]
A1          [ REQUIRED. Starting point coordinates. ]
H8          [ REQUIRED. Destionation point coordinates. ]
B2, D7, G6  [ Blocked positions on chess board. ]
Queen       [ Chess piece type ]
---(input.txt end)--

Do NOT skip ANY rows. If you do not wish to enter any data, use "-" instead. For Example:
----(input.txt)-----
-   [ NOT required, using "-" instead ]
-   [ NOT required, using "-" instead ]
A1  [ Always REQUIRED ]
H8  [ Always REQUIRED ]
B2  [ NOT required ]
-   [ NOT required(default is "Knight"), using "-" instead ]
---(input.txt end)--


If output file name already exists, then all data will be appended. 
Otherwise, new output file is created.
Here's what sample output file(output.txt) contains:
----(output.txt)-----
Queen solution 1: [ Chess piece type and a solution number ]
2                 [ Number of moves ]
A8, H8            [ Move positions ]

Queen solution 2: 
2
H1, H8
---(output.txt end)--
------------------------------------------------------------------------------------------

