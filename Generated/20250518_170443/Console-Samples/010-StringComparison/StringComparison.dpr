// Console application named StringComparison to compare string variants in various cases
program StringComparison;

{$APPTYPE CONSOLE} // Defines the application type as a console application
{$R *.res} // Links resource files with the executable

uses
  System.SysUtils; // Uses SysUtils unit for system utilities such as string manipulation

// Declaration of various string variables to use in the program
var
  s1, s1L, s1U, s1LI, s1UI, s2, s2L, s2U, s2LI, s2UI, s3, s3L, s3U, s3LI, s3UI: string;

begin
  try
    // Assigning string literals to variables s1, s2, and s3
    s1 := 'IciOuPas';
    s1L := s1.ToLower; // Converts s1 to lowercase
    s1LI := s1.ToLowerInvariant; // Converts s1 to lowercase invariant culture
    s1U := s1.ToUpper; // Converts s1 to uppercase
    s1UI := s1.ToUpperInvariant; // Converts s1 to uppercase invariant culture

    s2 := 'icioupas'; 
    s2L := s2.ToLower; // Converts s2 to lowercase
    s2LI := s2.ToLowerInvariant; // Converts s2 to lowercase invariant culture
    s2U := s2.ToUpper; // Converts s2 to uppercase
    s2UI := s2.ToUpperInvariant; // Converts s2 to uppercase invariant culture

    s3 := 'ICIOUPAS';
    s3L := s3.ToLower; // Converts s3 to lowercase
    s3LI := s3.ToLowerInvariant; // Converts s3 to lowercase invariant culture
    s3U := s3.ToUpper; // Converts s3 to uppercase
    s3UI := s3.ToUpperInvariant; // Converts s3 to uppercase invariant culture

    // Print each string with its variations
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

    // Comparing equality of strings in different cases
    writeln('s1 = s2');
    writeln(s1 = s2); // Compares s1 and s2
    writeln(s1L = s2L); // Compares s1L and s2L
    writeln(s1U = s2U); // Compares s1U and s2U
    writeln(s1LI = s2LI); // Compares s1LI and s2LI
    writeln(s1UI = s2UI); // Compares s1UI and s2UI

    writeln('s1 = s3');
    writeln(s1 = s3); // Compares s1 and s3
    writeln(s1L = s3L); // Compares s1L and s3L
    writeln(s1U = s3U); // Compares s1U and s3U
    writeln(s1LI = s3LI); // Compares s1LI and s3LI
    writeln(s1UI = s3UI); // Compares s1UI and s3UI

    // Using CompareStr to compare strings and output differences
    writeln('CompareStr');
    writeln(compareStr(s1, s2)); // Compares using exact case
    writeln(compareStr(s1L, s2L));
    writeln(compareStr(s1U, s2U));
    writeln(compareStr(s1LI, s2LI));
    writeln(compareStr(s1UI, s2UI));
    writeln(compareStr(s1, s3));
    writeln(compareStr(s1L, s3L));
    writeln(compareStr(s1U, s3U));
    writeln(compareStr(s1LI, s3LI));
    writeln(compareStr(s1UI, s3UI));

    // Using CompareText to compare strings in a case-insensitive manner
    writeln('CompareText');
    writeln(compareText(s1, s2)); // Compares ignoring case differences
    writeln(compareText(s1L, s2L));
    writeln(compareText(s1U, s2U));
    writeln(compareText(s1LI, s2LI));
    writeln(compareText(s1UI, s2UI));
    writeln(compareText(s1, s3));
    writeln(compareText(s1L, s3L));
    writeln(compareText(s1U, s3U));
    writeln(compareText(s1LI, s3LI));
    writeln(compareText(s1UI, s3UI));

    readln; // Waits for the user to press ENTER before closing the console window
  except
    on E: Exception do
      writeln(E.ClassName, ': ', E.Message); // Catches and writes out any exceptions that may occur
  end;

end.