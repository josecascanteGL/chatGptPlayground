```delphi
program StringComparison;

{$APPTYPE CONSOLE} // Specifies the type of application; Console application
{$R *.res} // Includes resource file in the program

uses
  System.SysUtils; // Include SysUtils unit for system routines and utilities

// Declaration of string variables for use in string comparisons
var
  s1, s1L, s1U, s1LI, s1UI, s2, s2L, s2U, s2LI, s2UI, s3, s3L, s3U, s3LI, s3UI: string;

begin
  try
    s1 := 'IciOuPas';            // Original mixed-case string
    s1L := s1.ToLower;          // Convert s1 to lowercase
    s1LI := s1.ToLowerInvariant; // Convert s1 to lowercase using invariant culture
    s1U := s1.ToUpper;          // Convert s1 to uppercase
    s1UI := s1.ToUpperInvariant; // Convert s1 to uppercase using invariant culture

    s2 := 'icioupas';            // Lowercase version of s1
    s2L := s2.ToLower;          // Redundant: s2 already in lowercase
    s2LI := s2.ToLowerInvariant; // Same as s2L, but uses invariant culture
    s2U := s2.ToUpper;          // Convert s2 to uppercase
    s2UI := s2.ToUpperInvariant; // Convert s2 to uppercase using invariant culture

    s3 := 'ICIOUPAS';            // Uppercase version of s1
    s3L := s3.ToLower;          // Convert s3 to lowercase
    s3LI := s3.ToLowerInvariant; // Convert s3 to lowercase using invariant culture
    s3U := s3.ToUpper;          // Redundant: s3 already in uppercase
    s3UI := s3.ToUpperInvariant; // Same as s3U, but uses invariant culture

    // Output the strings and their variants
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

    writeln('s1 = s2'); // Compare original strings and variants for equality
    writeln(s1 = s2);  // Results false
    writeln(s1L = s2L); // Results true
    writeln(s1U = s2U); // Results true
    writeln(s1LI = s2LI); // Results true
    writeln(s1UI = s2UI); // Results true

    writeln('s1 = s3');
    writeln(s1 = s3);  // Results false
    writeln(s1L = s3L); // Results true
    writeln(s1U = s3U); // Results true
    writeln(s1LI = s3LI); // Results true
    writeln(s1UI = s3UI); // Results true

    writeln('CompareStr'); // Case-sensitive string comparison
    writeln(compareStr(s1, s2));  // Negative if s1 is less than s2
    writeln(compareStr(s1L, s2L)); // Zero if s1L equals s2L
    writeln(compareStr(s1U, s2U)); // Zero if s1U equals s2U
    writeln(compareStr(s1LI, s2LI)); // Zero if s1LI equals s2LI
    writeln(compareStr(s1UI, s2UI)); // Zero because s1UI is the same as s2UI
    writeln(compareStr(s1, s3)); // Positive if s1 is greater than s3
    writeln(compareStr(s1L, s3L)); // Zero if s1L equals s3L
    writeln(compareStr(s1U, s3U)); // Zero if s1U equals s3U
    writeln(compareStr(s1LI, s3LI)); // Zero if s1LI equals s3LI
    writeln(compareStr(s1UI, s3UI)); // Zero because s1UI is the same as s3UI

    writeln('CompareText'); // Case-insensitive string comparison
    writeln(compareText(s1, s2));  // Zero if s1 equals s2 when ignoring case
    writeln(compareText(s1L, s2L)); // Zero if s1L equals s2L when ignoring case
    writeln(compareText(s1U, s2U)); // Zero if s1U equals s2U when ignoring case
    writeln(compareText(s1LI, s2LI)); // Zero if s1LI equals s2LI when ignoring case
    writeln(compareText(s1UI, s2UI)); // Zero because s1UI is the same as s2UI when ignoring case
    writeln(compareText(s1, s3)); // Zero if s1 equals s3 when ignoring case
    writeln(compareText(s1L, s3L)); // Zero if s1L equals s3L when ignoring case
    writeln(compareText(s1U, s3U)); // Zero if s1U equals s3U when ignoring case
    writeln(compareText(s1LI, s3LI)); // Zero if s1LI equals s3LI when ignoring case
    writeln(compareText(s1UI, s3UI)); // Zero because s1UI is the same as s3UI when ignoring case

    readln; // Waits for user to press Enter
  except
    on E: Exception do
      writeln(E.ClassName, ': ', E.Message); // Error handling: prints exception class and message
  end;

end.
```