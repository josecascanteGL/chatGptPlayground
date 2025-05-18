// Defines a console application named `StringComparison`
program StringComparison;

// Compiler directives that apply console application type and link resource files
{$APPTYPE CONSOLE}
{$R *.res}

// Import SysUtils unit containing system utilities like string functions
uses
  System.SysUtils;

// Declaration of multiple string variables for performing operations 
var
  s1, s1L, s1U, s1LI, s1UI, s2, s2L, s2U, s2LI, s2UI, s3, s3L, s3U, s3LI, s3UI: string;

// Start of the program's execution block
begin
  try
    // Initializing string variables with values and converting them in different cases
    s1 := 'IciOuPas';
    s1L := s1.ToLower; // Convert s1 to lowercase using system's locale settings // Suggestion: Consider the implications of localization on case conversion
    s1LI := s1.ToLowerInvariant; // Convert s1 to lowercase using invariant culture
    s1U := s1.ToUpper; // Convert s1 to uppercase using system's locale settings 
    s1UI := s1.ToUpperInvariant; // Convert s1 to uppercase using invariant culture

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

    // Writing output to console 
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

    // Comparisons for all cases between s1, s2, and s3 and their converted cases.
    // Checking for equality and displaying results on the console
    writeln('s1 = s2');
    writeln(s1 = s2); // Checks if s1 is exactly equal to s2
    writeln(s1L = s2L); // Checks if s1 converted to lower case is equal to s2 in lower case
    writeln(s1U = s2U); // Checks if s1 converted to upper case is equal to s2 in upper case
    writeln(s1LI = s2LI); 
    writeln(s1UI = s2UI);

    writeln('s1 = s3');
    writeln(s1 = s3);
    writeln(s1L = s3L);
    writeln(s1U = s3U);
    writeln(s1LI = s3LI);
    writeln(s1UI = s3UI);

    // Comparisons of strings using CompareStr and CompareText
    // CompareStr - Performs a sensitive string comparison and returns diff index
    writeln('CompareStr');
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

    // CompareText - Performs a case-insensitive string comparison and returns diff index
    writeln('CompareText');
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

    readln; // Pause the execution awaiting user input to view results // Suggestion: Consider removing or conditioning on a compile-time directive for batch operations
  except
    on E: Exception do
      writeln(E.ClassName, ': ', E.Message); // Catch and display exceptions to the console
  end;

end. // End of program block