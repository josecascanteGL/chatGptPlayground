program StringComparison; // Defines a program named StringComparison

{$APPTYPE CONSOLE} // Compiler directive to specify the application type as console  
{$R *.res} // Compiles with the project's resource file

uses
  System.SysUtils; // Using System.SysUtils unit for utilities like exceptions and string functions

var
  // Declaration of multiple string variables to be used for testing string case operations
  s1, s1L, s1U, s1LI, s1UI, s2, s2L, s2U, s2LI, s2UI, s3, s3L, s3U, s3LI, s3UI: string;

begin
  try  // Block to handle exceptions that might occur within its scope
    // Assign string literals to variables and perform transformations: lower case, upper case, and invariant culture versions
    s1 := 'IciOuPas';
    s1L := s1.ToLower; // Convert s1 to lower case
    s1LI := s1.ToLowerInvariant; // Convert s1 to lower case using invariant culture settings
    s1U := s1.ToUpper; // Convert s1 to upper case
    s1UI := s1.ToUpperInvariant; // Convert s1 to upper case using invariant culture settings

    s2 := 'icioupas';
    s2L := s2.ToLower; // Convert s2 to lower case
    s2LI := s2.ToLowerInvariant; // Convert s2 to lower case using invariant culture settings
    s2U := s2.ToUpper; // Convert s2 to upper case
    s2UI := s2.ToUpperInvariant; // Convert s2 to upper case using invariant culture settings

    s3 := 'ICIOUPAS';
    s3L := s3.ToLower; // Convert s3 to lower case
    s3LI := s3.ToLowerInvariant; // Convert s3 to lower case using invariant culture settings
    s3U := s3.ToUpper; // Convert s3 to upper case
    s3UI := s3.ToUpperInvariant; // Convert s3 to upper case using invariant culture settings

    // Output variables to console
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

    // Comparing strings with direct equality and showing the results
    writeln('s1 = s2');
    writeln(s1 = s2); // Compare original strings
    writeln(s1L = s2L); // Compare lower case versions
    writeln(s1U = s2U); // Compare upper case versions
    writeln(s1LI = s2LI); // Compare lower case invariant versions
    writeln(s1UI = s2UI); // Compare upper case invariant versions

    writeln('s1 = s3');
    writeln(s1 = s3); // Compare original strings
    writeln(s1L = s3L); // Compare lower case versions
    writeln(s1U = s3U); // Compare upper case versions
    writeln(s1LI = s3LI); // Compare lower case invariant versions
    writeln(s1UI = s3UI); // Compare upper case invariant versions

    // Using CompareStr and CompareText functions to compare strings and handle case sensitivities
    writeln('CompareStr');
    writeln(compareStr(s1, s2)); // Case sensitive
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
    writeln(compareText(s1, s2)); // Case insensitive
    writeln(compareText(s1L, s2L));
    writeln(compareText(s1U, s2U));
    writeln(compareText(s1LI, s2LI));
    writeln(compareText(s1UI, s2UI));
    writeln(compareText(s1, s3));
    writeln(compareText(s1L, s3L));
    writeln(compareText(s1U, s3U));
    writeln(compareText(s1LI, s3LI));
    writeln(compareText(s1UI, s3UI));

    readln; // Wait for user input before closing the console window (used commonly in console testing)
  except
    on E: Exception do
      writeln(E.ClassName, ': ', E.Message); // Output class type and message of any exceptions caught
  end;

end.