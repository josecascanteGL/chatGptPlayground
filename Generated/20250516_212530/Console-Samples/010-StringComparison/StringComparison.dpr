// Program entry point
program StringComparison;

// Compiler directives
{$APPTYPE CONSOLE}
{$R *.res}

// System unit import for standard utilities
uses
  System.SysUtils;

// Variable declaration
var
  // Strings for testing case conversion
  s1, s1L, s1U, s1LI, s1UI, s2, s2L, s2U, s2LI, s2UI, s3, s3L, s3U, s3LI, s3UI: string;

// Main program logic
begin
  try
    // Initialize strings with different cases
    s1 := 'IciOuPas';
    s1L := s1.ToLower;  // Convert to lowercase
    s1LI := s1.ToLowerInvariant;  // Convert to lowercase invariant
    s1U := s1.ToUpper;  // Convert to uppercase
    s1UI := s1.ToUpperInvariant;  // Convert to uppercase invariant

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

    // Output original, lowercase, lowercase invariant, uppercase, and uppercase invariant strings for s1
    writeln('s1');
    writeln(s1);
    writeln(s1L);
    writeln(s1LI);
    writeln(s1U);
    writeln(s1UI);

    // Output original, lowercase, lowercase invariant, uppercase, and uppercase invariant strings for s2
    writeln('s2');
    writeln(s2);
    writeln(s2L);
    writeln(s2LI);
    writeln(s2U);
    writeln(s2UI);

    // Output original, lowercase, lowercase invariant, uppercase, and uppercase invariant strings for s3
    writeln('s3');
    writeln(s3);
    writeln(s3L);
    writeln(s3LI);
    writeln(s3U);
    writeln(s3UI);

    // Compare the strings for equality
    writeln('s1 = s2');
    writeln(s1 = s2);  // Check equality for original strings
    writeln(s1L = s2L);  // Check equality for lowercase strings
    writeln(s1U = s2U);  // Check equality for uppercase strings
    writeln(s1LI = s2LI);  // Check equality for lowercase invariant strings
    writeln(s1UI = s2UI);  // Check equality for uppercase invariant strings

    writeln('s1 = s3');
    writeln(s1 = s3);  // Check equality for original strings
    writeln(s1L = s3L);  // Check equality for lowercase strings
    writeln(s1U = s3U);  // Check equality for uppercase strings
    writeln(s1LI = s3LI);  // Check equality for lowercase invariant strings
    writeln(s1UI = s3UI);  // Check equality for uppercase invariant strings

    // Output results of string comparisons using CompareStr function
    writeln('CompareStr');
    writeln(compareStr(s1, s2));  // Compare original strings
    writeln(compareStr(s1L, s2L));  // Compare lowercase strings
    writeln(compareStr(s1U, s2U));  // Compare uppercase strings
    writeln(compareStr(s1LI, s2LI));  // Compare lowercase invariant strings
    writeln(compareStr(s1UI, s2UI));  // Compare uppercase invariant strings
    writeln(compareStr(s1, s3));
    writeln(compareStr(s1L, s3L));
    writeln(compareStr(s1U, s3U));
    writeln(compareStr(s1LI, s3LI));
    writeln(compareStr(s1UI, s3UI));

    // Output results of string comparisons using CompareText function
    writeln('CompareText');
    writeln(compareText(s1, s2));  // Compare original strings
    writeln(compareText(s1L, s2L));  // Compare lowercase strings
    writeln(compareText(s1U, s2U));  // Compare uppercase strings
    writeln(compareText(s1LI, s2LI));  // Compare lowercase invariant strings
    writeln(compareText(s1UI, s2UI));  // Compare uppercase invariant strings
    writeln(compareText(s1, s3));
    writeln(compareText(s1L, s3L));
    writeln(compareText(s1U, s3U));
    writeln(compareText(s1LI, s3LI));
    writeln(compareText(s1UI, s3UI);

    // Pause to see output results before closing console window
    readln;
  except
    // Handle any exceptions that may occur during execution
    on E: Exception do
      writeln(E.ClassName, ': ', E.Message);
  end;
end.