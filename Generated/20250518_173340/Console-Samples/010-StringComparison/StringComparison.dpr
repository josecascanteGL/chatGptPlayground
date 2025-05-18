program StringComparison;

{$APPTYPE CONSOLE} // Specifies the type of application as console
{$R *.res} // Include resources in the compiled file

uses
  System.SysUtils; // Use the System.SysUtils unit for system utilities like string handling

var
  // Declaration of string variables to demonstrate different cases and conversions
  s1, s1L, s1U, s1LI, s1UI, s2, s2L, s2U, s2LI, s2UI, s3, s3L, s3U, s3LI, s3UI: string;

begin
  try
    // Initializing string variables
    s1 := 'IciOuPas';
    s1L := s1.ToLower; // Convert to lowercase using current locale
    s1LI := s1.ToLowerInvariant; // Convert to lowercase using invariant locale
    s1U := s1.ToUpper; // Convert to uppercase using current locale
    s1UI := s1.ToUpperInvariant; // Convert to uppercase using invariant locale

    s2 := 'icioupas';
    s2L := s2.ToLower; // These are conceptually unnecessary as s2 is already lower
    s2LI := s2.ToLowerInvariant; // Invariant lowercase conversion, redundant as s2 is lowercase
    s2U := s2.ToUpper; // Convert to uppercase
    s2UI := s2.ToUpperInvariant; // Uppercase using invariant locale

    s3 := 'ICIOUPAS';
    s3L := s3.ToLower; // Convert to lowercase
    s3LI := s3.ToLowerInvariant; // Convert to lowercase using invariant locale
    s3U := s3.ToUpper; // These are conceptually unnecessary as s3 is already upper
    s3UI := s3.ToUpperInvariant; // Invariant uppercase conversion, redundant as s3 is uppercase

    // Outputs the string values, demonstrating changes due to case conversions
    writeln('s1');
    writeln(s1);
    writeln(s1L);
    writeln(s1LI);
    writeln(s1U);
    writeln(s1UI);

    writeln('s2');
    writeln(s2);
    writeln(s2L);
    writeln(s2LI);
    writeln(s2U);
    writeln(s2UI);

    writeln('s3');
    writeln(s3);
    writeln(s3L);
    writeln(s3LI);
    writeln(s3U);
    writeln(s3UI);

    // Uncomment below line in real use to keep console window from closing immediately
    // readln;

    // Checking equality of strings in different cases
    writeln('s1 = s2');
    writeln(s1 = s2); // Checks if s1 is exactly equal to s2
    writeln(s1L = s2L); // Compares both in lowercase
    writeln(s1U = s2U); // Compares both in uppercase
    writeln(s1LI = s2LI); // Lowercase invariant comparison
    writeln(s1UI = s2UI); // Uppercase invariant comparison

    writeln('s1 = s3');
    writeln(s1 = s3); // Direct comparison, should be false
    writeln(s1L = s3L); // Lowercase comparison, likely true
    writeln(s1U = s3U); // Uppercase comparison, also likely true
    writeln(s1LI = s3LI); // Lowercase invariant comparison, likely true
    writeln(s1UI = s3UI); // Uppercase invariant comparison, likely true

    writeln('CompareStr');
    writeln(compareStr(s1, s2)); // Compares s1 and s2. Zero if equal
    writeln(compareStr(s1L, s2L)); // Compares lowercases
    writeln(compareStr(s1U, s2U)); // Compares uppercases
    writeln(compareStr(s1LI, s2LI)); // Compares lowercases invariant
    writeln(compareStr(s1UI, s2UI)); // Compares uppercases invariant
    writeln(compareStr(s1, s3)); // Between s1 and s3
    writeln(compareStr(s1L, s3L)); // Lowercases of s1 and s3
    writeln(compareStr(s1U, s3U)); // Uppercases of s1 and s3
    writeln(compareStr(s1LI, s3LI)); // Lowercases invariant
    writeln(compareStr(s1UI, s3UI)); // Uppercases invariant

    writeln('CompareText');
    writeln(compareText(s1, s2)); // Case-insensitive comparison
    writeln(compareText(s1L, s2L)); // Redundant as already both are lower
    writeln(compareText(s1U, s2U)); // Redundant as already both are upper
    writeln(compareText(s1LI, s2LI)); // Case-insensitive invariant comparison
    writeln(compareText(s1UI, s2UI)); // Also case-insensitive invariant comparison
    writeln(compareText(s1, s3)); // Between s1 and s3, case-insensitive
    writeln(compareText(s1L, s3L)); // Case-insensitive
    writeln(compareText(s1U, s3U)); // Case-insensitive
    writeln(compareText(s1LI, s3LI)); // Case-insensitive invariant
    writeln(compareText(s1UI, s3UI)); // Case-insensitive invariant

    readln; // Holds the console open until user input
  except
    on E: Exception do
      writeln(E.ClassName, ': ', E.Message); // Capture and print exceptions to the console
  end;

end.