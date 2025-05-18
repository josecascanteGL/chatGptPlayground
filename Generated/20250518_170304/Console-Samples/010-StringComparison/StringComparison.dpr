```delphi
program StringComparison;

{$APPTYPE CONSOLE} // Specifies the application type as a console application
{$R *.res} // Includes RES file resources into the application

uses
  System.SysUtils;  // Imports the SysUtils unit which contains system utilities and functions

var
  // Declares various string variables used in the program
  s1, s1L, s1U, s1LI, s1UI, s2, s2L, s2U, s2LI, s2UI, s3, s3L, s3U, s3LI, s3UI: string;

begin
  try
    // Initialize strings with different cases to demonstrate case sensitivity
    s1 := 'IciOuPas'; // original string
    s1L := s1.ToLower; // converts s1 to lowercase
    s1LI := s1.ToLowerInvariant; // converts s1 to lowercase using invariant culture
    s1U := s1.ToUpper; // converts s1 to uppercase
    s1UI := s1.ToUpperInvariant; // converts s1 to uppercase using invariant culture

    s2 := 'icioupas'; // lowercase version
    s2L := s2.ToLower; // redundant: s2 already is in lowercase
    s2LI := s2.ToLowerInvariant; // redundant: s2 already is in lowercase using invariant
    s2U := s2.ToUpper; // converts s2 to uppercase
    s2UI := s2.ToUpperInvariant; // converts s2 to uppercase using invariant culture

    s3 := 'ICIOUPAS'; // uppercase version
    s3L := s3.ToLower; // converts s3 to lowercase
    s3LI := s3.ToLowerInvariant; // converts s3 to lowercase using invariant culture
    s3U := s3.ToUpper; // redundant: s3 already is in uppercase
    s3UI := s3.ToUpperInvariant; // redundant: s3 already is in uppercase using invariant

    // Display various transformations of the strings
    writeln('s1'); // header
    writeln(s1); // displays original s1
    writeln(s1L); // displays lowercase s1
    writeln(s1LI); // displays lowercased invariant s1
    writeln(s1U); // displays uppercase s1
    writeln(s1UI); // displays uppercased invariant s1

    writeln('s2'); // header for s2 block
    writeln(s2); // displays original s2
    writeln(s2L); // displays lowercase s2
    writeln(s2LI); // displays lowercased invariant s2
    writeln(s2U); // displays uppercase s2
    writeln(s2UI); // displays upper-cased invariant s2

    writeln('s3'); // header for s3 block
    writeln(s3); // displays original s3
    writeln(s3L); // displays lowercase s3
    writeln(s3LI); // displays lowercased invariant s3
    writeln(s3U); // displays uppercase s3
    writeln(s3UI); // displays uppercased invariant s3

    //readln; // commented out; was used to pause the console

    // Demonstrating string comparison
    writeln('s1 = s2');
    writeln(s1 = s2); // equality check between s1 and s2
    writeln(s1L = s2L); // checks if lowercase versions are equal
    writeln(s1U = s2U); // checks if uppercase versions are equal
    writeln(s1LI = s2LI); // checks if invariant lowercase versions are equal
    writeln(s1UI = s2UI); // checks if invariant uppercase versions are equal

    writeln('s1 = s3');
    writeln(s1 = s3); // equality check between s1 and s3
    writeln(s1L = s3L); // checks if lowercase versions are equal
    writeln(s1U = s3U); // checks if uppercase versions are equal
    writeln(s1LI = s3LI); // checks if invariant lowercase versions are equal
    writeln(s1UI = s3UI); // checks if invariant uppercase versions are equal

    writeln('CompareStr'); // using CompareStr function for case sensitive comparison
    writeln(compareStr(s1, s2)); // compares s1 and s2
    writeln(compareStr(s1L, s2L)); // compares lowercase versions
    writeln(compareStr(s1U, s2U)); // compares uppercase versions
    writeln(compareStr(s1LI, s2LI)); // compares invariant lowercase versions
    writeln(compareStr(s1UI, s2UI)); // compares invariant uppercase versions
    writeln(compareStr(s1, s3)); // compares s1 and s3
    writeln(compareStr(s1L, s3L)); // compares lowercase versions
    writeln(compareStr(s1U, s3U)); // compares uppercase versions
    writeln(compareStr(s1LI, s3LI)); // compares invariant lowercase versions
    writeln(compareStr(s1UI, s3UI)); // compares invariant uppercase versions

    writeln('CompareText'); // using CompareText function for case insensitive comparison
    writeln(compareText(s1, s2)); // compares s1 and s2
    writeln(compareText(s1L, s2L)); // compares lowercase versions
    writeln(compareText(s1U, s2U)); // compares uppercase versions
    writeln(compareText(s1LI, s2LI)); // compares invariant lowercase versions
    writeln(compareText(s1UI, s2UI)); // compares invariant uppercase versions
    writeln(compareText(s1, s3)); // compares s1 and s3
    writeln(compareText(s1L, s3L)); // compares lowercase versions
    writeln(compareText(s1U, s3U)); // compares uppercase versions
    writeln(compareText(s1LI, s3LI)); // compares invariant lowercase versions
    writeln(compareText(s1UI, s3UI)); // compares invariant uppercase versions

    readln; // read a line from the console, preventing the program from terminating immediately

  except
    on E: Exception do
      writeln(E.ClassName, ': ', E.Message); // Handles exceptions and prints the class name and message
  end;

end.
```