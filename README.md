# TwoWaterJugPuzzle
WPF/C# Graphical program to solve the two water jug puzzle (A.K.A. Die Hard 3 riddle)

This is an extend version of the Die Hard 3 3-gallon jug and 5-gallon jug and a value of exactly 4-gallons 
must be determined from the 2 given gallons.  This program will determine if (A)-gallon jug and (B)-gallong jug
will be possible to determine exactly (C)-gallons.


When you pull or download make sure you get Both Projects:
  
PuzzleSolver 
TwoWaterJugPuzzle (as this program uses Puzzle Solver Dll, make sure it is build and added in you project)

Should be able to build right off the bat since I have enabled Nuget in VisualStudio IDE
Only TwoWaterJugPuzzle needs Nuget Packages Restore. 

In Nuget Online should be able to add these Pacakges un Manage Nuget Packages (install)
  
  Add in this order to simplify process (1 is dependent on others should be a 1 step process)
  1.) MVVM Light DependentRelayCommand (PCL) Version 5.0.2.0-- Created by: Thomas Mutzi 
  2.) MVVM Light libraries only (PCL) Version 5.0.2.0--Created by: Laurent Bugnion (GalaSoft)
  3.) CommonServiceLocator (Microsoft) 1.3

PuzzleSolver Library is self contained and nothing other than building
the project is sufficient to run it

After this just hit run under Visual Studio IDE. 
This is NOT a console application.

All this should be good to go if you download and open as Zip or just request a Get in Github.
Happy Coding!..

