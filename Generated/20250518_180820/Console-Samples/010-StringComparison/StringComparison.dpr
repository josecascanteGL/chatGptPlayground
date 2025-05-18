// Defines the program named StringComparison which focuses on string comparison techniques
program StringComparison;

{$APPTYPE CONSOLE} // Directs the application to be a console application
{$R *.res} // Directs the linker to include resources found in the corresponding .res file

// Uses clause, specifying the units this program requires, in this case, SysUtils for system utilities
uses
  System.SysUtils;

// Declaration of multiple string variables used for demonstrating case conversion and comparison
var
  s1, s1L, s1U, s1LI, s1UI, s2, s2L, s2U, s2LI, s2UI, s3, s3L, s3U, s3LI, s3UI: string;

// Main block of the program begins
begin
  try
    // Initializing variable s1 and applying different case conversions
    s1 := 'IciOuPas';
    s1L := s1.ToLower; // Converts s1 to lower case
    s1LI := s1.ToLowerInvariant; // Converts s1 to lower case using culture-invariant mapping
    s1U := s1.ToUpper; // Converts s1 to upper case
    s1UI := s1.ToUpperInvariant; // Converts s1 to upper case using culture-invariant mapping

    // Initializing variable s2 and applying different case conversions
    s2 := 'icioupas';
    s2L := s2.ToLower;
    s2LI := s2.ToLowerInvariant;
    s2U := s2.ToUpper;
    s2UI := s2.ToUpperInvariant;

    // Initializing variable s3 and applying different case conversions
    s3 := 'ICIOUPAS';
    s3L := s3.ToLower;
    s3LI := s3.ToLowerInvariant;
    s3U := s3.ToUpper;
    s3UI := s3.ToUpperInvariant;

    // Printing out all variables initialized above to check the outcomes of the conversions
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

    // Showing boolean results of direct string comparisons
    writeln('s1 = s2');
    writeln(s1 = s2); // Compares s1 with s2
    writeln(s1L = s2L); // Compares lower case strings
    writeln(s1U = s2U); // Compares upper case strings
    writeln(s1LI = s2LI); // Compares lower case culture-invariant strings
    writeln(s1UI = s2UI); // Compares upper case culture-invariant strings

    // Showing boolean results of direct string comparisons for s1 and s3
    writeln('s1 = s3');
    writeln(s1 = s3);
    writeln(s1L = s3L);
    writeln(s1U = s3U);
    writeln(s1LI = s3LI);
    writeln(s1UI = s3UI);

    // Using CompareStr function to show difference between strings
    writeln('CompareStr');
    writeln(compareStr(s1, s2)); // Returns 0 if s1 equals s2
    writeln(compareStr(s1L, s2L));
    writeln(compareStr(s1U, s2U));
    writeln(compareStr(s1LI, s2LI));
    writeln(compareStr(s1UI, s2UI));
    writeln(compareStr(s1, s3));
    writeln(compareStr(s1L, s3L));
    writeln(compareStr(s1U, s3U));
    writeln(compareStr(s1LI, s3LI));
    writeln(compareStr(s1UI, s3UI));

    // Using CompareText function to show difference between strings, case-insensitively
    writeln('CompareText');
    writeln(compareText(s1, s2)); // Similar to CompareStr but case-insensitive
    writeln(compareText(s1L, s2L));
    writeln(compareText(s1U, s2U));
    writeln(compareText(s1LI, s2LI));
    writeln(compareText(s1UI, s2UI));
    writeln(compareText(s1, s3));
    writeln(compareText(s1L, s3L));
    writeln(compareText(s1U, s3U));
    writeln(compareText(s1LI, s3LI));
    writeln(compareText(s1UI, s3UI));

    // Pauses the console until the user presses a key, useful during development
    readln;
  except
    // Exception handling block to catch and display errors
    on E: Exception do
      writeln(E.ClassName, ': ', E.Message);
  end;

end.