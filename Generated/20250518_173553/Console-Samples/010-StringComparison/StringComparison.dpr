// Define the type of application as a console application
{$APPTYPE CONSOLE}
// Include resource file (if exists) during the compilation
{$R *.res}

// Import necessary system utilities for string manipulation
uses
  System.SysUtils;

// Declare several string variables to demonstrate string comparison
var
  s1, s1L, s1U, s1LI, s1UI, s2, s2L, s2U, s2LI, s2UI, s3, s3L, s3U, s3LI, s3UI: string;

begin
  try
    // Assign values to string variables
    s1 := 'IciOuPas';
    s1L := s1.ToLower;  // Convert s1 to lower case using the default locale settings
    s1LI := s1.ToLowerInvariant;  // Convert s1 to lower case using invariant locale (culture-independent)
    s1U := s1.ToUpper;  // Convert s1 to upper case using the default locale settings
    s1UI := s1.ToUpperInvariant;  // Convert s1 to upper case using invariant locale (culture-independent)

    s2 := 'icioupas';
    s2L := s2.ToLower;
    s2LI := s2.ToLowerInvariant;
    s2U := s2.ToUpper;
    s2UI := s2.ToUpperInvariant;

    s3 := 'ICIOUPAS';
    s3L := s3.ToLower;
    s3LI := s3.ToLowerInvariant;
    s3U := s3.ToUpper;
    s3UI := s3.ToUpperInvariant;

    // Output the values of different string transformations
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

    // Uncomment the next line if you want the console to wait for a user input
    // readln;

    // Performing comparison between strings and output the results
    writeln('s1 = s2');
    writeln(s1 = s2);  // Checks if s1 equals s2 (case-sensitive)
    writeln(s1L = s2L);  // Checks if lowercased versions are equal
    writeln(s1U = s2U);  // Checks if uppercased versions are equal
    writeln(s1LI = s2LI);  // Checks invariant lowercased versions
    writeln(s1UI = s2UI);  // Checks invariant uppercased versions

    writeln('s1 = s3');
    writeln(s1 = s3);
    writeln(s1L = s3L);
    writeln(s1U = s3U);
    writeln(s1LI = s3LI);
    writeln(s1UI = s3UI);

    writeln('CompareStr');
    writeln(compareStr(s1, s2)); // Performs a binary comparison of s1 and s2
    writeln(compareStr(s1L, s2L)); 
    writeln(compareStr(s1U, s2U)); 
    writeln(compareStr(s1LI, s2LI));
    writeln(compareStr(s1UI, s2UI));
    writeln(compareStr(s1, s3));
    writeln(compareStr(s1L, s3L));
    writeln(compareStr(s1U, s3U));
    writeln(compareStr(s1LI, s3LI));
    writeln(compareStr(s1UI, s3UI));

    writeln('CompareText');
    writeln(compareText(s1, s2));  // Performs a textual (case-insensitive) comparison of s1 and s2
    writeln(compareText(s1L, s2L));
    writeln(compareText(s1U, s2U));
    writeln(compareText(s1LI, s2LI));
    writeln(compareText(s1UI, s2UI));
    writeln(compareText(s1, s3));
    writeln(compareText(s1L, s3L));
    writeln(compareText(s1U, s3U));
    writeln(compareText(s1LI, s3LI));
    writeln(compareText(s1UI, s3UI));

    // Wait for user to press enter before closing the program (necessary for seeing output in console applications)
    readln;
  except
    on E: Exception do
      // Output errors if exceptions are thrown during the execution
      writeln(E.ClassName, ': ', E.Message);
  end;

end.