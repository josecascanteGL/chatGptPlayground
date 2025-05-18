// Declares a console application
program StringComparison;

// Compiler directives for application type and resource linking
{$APPTYPE CONSOLE}
{$R *.res}

// Specifies the units used in the program (for example, the SysUtils unit includes system and utility functions)
uses
  System.SysUtils;

// Variable declarations for strings. These will be used for string manipulation and comparison.
var
  s1, s1L, s1U, s1LI, s1UI, s2, s2L, s2U, s2LI, s2UI, s3, s3L, s3U, s3LI, s3UI: string;

// Main block of the program
begin
  try
    // Assigning string values to variables and converting strings to lower and upper cases
    s1 := 'IciOuPas';
    s1L := s1.ToLower; // Converts s1 to lowercase
    s1LI := s1.ToLowerInvariant; // Converts s1 to lowercase using invariant culture
    s1U := s1.ToUpper; // Converts s1 to uppercase
    s1UI := s1.ToUpperInvariant; // Converts s1 to uppercase using invariant culture

    // Similar string manipulations for another set of strings
    s2 := 'icioupas';
    s2L := s2.ToLower;
    s2LI := s2.ToLowerInvariant;
    s2U := s2.ToUpper;
    s2UI := s2.ToUpperInvariant;

    // And another set
    s3 := 'ICIOUPAS';
    s3L := s3.ToLower;
    s3LI := s3.ToLowerInvariant;
    s3U := s3.ToUpper;
    s3UI := s3.ToUpperInvariant;

    // Displaying the results of the string manipulations using writeln (writes the output plus a line break)
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

    // Commenting out the readln; prevents program from pausing here (meant for debugging or interactive sessions)

    // Performing and displaying string comparisons
    writeln('s1 = s2'); // Simple equality comparison
    writeln(s1 = s2); // Direct comparison, case-sensitive
    writeln(s1L = s2L); // Compares lowercase versions
    writeln(s1U = s2U); // Compares uppercase versions
    writeln(s1LI = s2LI); // Compares lowercase invariant versions
    writeln(s1UI = s2UI); // Compares uppercase invariant versions

    writeln('s1 = s3'); // Another set of comparisons
    writeln(s1 = s3); // Direct comparison, case-sensitive
    writeln(s1L = s3L); // Compares lowercase versions
    writeln(s1U = s3U); // Compares uppercase versions
    writeln(s1LI = s3LI); // Compares lowercase invariant versions
    writeln(s1UI = s3UI); // Compares uppercase invariant versions

    writeln('CompareStr'); // Case-sensitive full string comparison, results in 0 when strings are identical
    writeln(compareStr(s1, s2));
    writeln(compareStr(s1L, s2L));
    writeln(compareStr(s1U, s2U));
    writeln(compareStr(s1LI, s2LI));
    writeln(compareStr(s1UI, s2UI));
    writeln(compareStr(s1, s3));
    writeln(compareStr(s1L, s3L));
    writeln(compareStr(s1U, s3U));
    writeln(compareStr(s1LI, s3LI));
    writeln(compareStr(s1UI, s3UI));

    writeln('CompareText'); // Case-insensitive full string comparison, results in 0 when strings are identical, ignoring case
    writeln(compareText(s1, s2));
    writeln(compareText(s1L, s2L));
    writeln(compareText(s1U, s2U));
    writeln(compareText(s1LI, s2LI));
    writeln(compareText(s1UI, s2UI));
    writeln(compareText(s1, s3));
    writeln(compareText(s1L, s3L));
    writeln(compareText(s1U, s3U));
    writeln(compareText(s1LI, s3LI));
    writeln(compareText(s1UI, s3UI));

    // Keeps the console window open so results can be viewed. Press Enter to close.
    readln;
  except
    on E: Exception do
      // Handles exceptions and prints the error message to the console
      writeln(E.ClassName, ': ', E.Message);
  end;

end.
