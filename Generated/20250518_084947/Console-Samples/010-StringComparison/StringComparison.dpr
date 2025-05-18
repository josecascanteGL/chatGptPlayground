// Declare the main program block
program StringComparison;

// Specify the console application type
{$APPTYPE CONSOLE}
// Include resource files
{$R *.res}

// Use SysUtils library for utilities like string manipulation
uses
  System.SysUtils;

// Declare several string variables for handling different case formats:
var
  s1, s1L, s1U, s1LI, s1UI, s2, s2L, s2U, s2LI, s2UI, s3, s3L, s3U, s3LI, s3UI: string;

begin
  try
    // Initialize strings with different cases
    s1 := 'IciOuPas';
    // Convert s1 to lowercase using current locale
    s1L := s1.ToLower;
    // Convert s1 to lowercase using invariant locale (culture-independent)
    s1LI := s1.ToLowerInvariant;
    // Convert s1 to uppercase using current locale
    s1U := s1.ToUpper;
    // Convert s1 to uppercase using invariant locale
    s1UI := s1.ToUpperInvariant;

    // Initialize s2 with lowercase letters
    s2 := 'icioupas';
    // Lowercase and uppercase operations similar to s1
    s2L := s2.ToLower;
    s2LI := s2.ToLowerInvariant;
    s2U := s2.ToUpper;
    s2UI := s2.ToUpperInvariant;

    // Initialize s3 with uppercase letters
    s3 := 'ICIOUPAS';
    // Lowercase and uppercase operations similar to s1 and s2
    s3L := s3.ToLower;
    s3LI := s3.ToLowerInvariant;
    s3U := s3.ToUpper;
    s3UI := s3.ToUpperInvariant;

    // Output original and modified strings for s1
    writeln('s1');
    writeln(s1);
    writeln(s1L);
    writeln(s1LI);
    writeln(s1U);
    writeln(s1UI);

    // Output original and modified strings for s2
    writeln('s2');
    writeln(s2);
    writeln(s2L);
    writeln(s2LI);
    writeln(s2U);
    writeln(s2UI);

    // Output original and modified strings for s3
    writeln('s3');
    writeln(s3);
    writeln(s3L);
    writeln(s3LI);
    writeln(s3U);
    writeln(s3UI);

    // Uncomment the below line if inputs are required in the console before continuing
    // readln;

    // Comparisons between s1 and s2 in different cases and formats
    writeln('s1 = s2');
    writeln(s1 = s2);
    writeln(s1L = s2L);
    writeln(s1U = s2U);
    writeln(s1LI = s2LI);
    writeln(s1UI = s2UI);

    // Comparisons between s1 and s3 in different cases and formats
    writeln('s1 = s3');
    writeln(s1 = s3);
    writeln(s1L = s3L);
    writeln(s1U = s3U);
    writeln(s1LI = s3LI);
    writeln(s1UI = s3UI);

    // More detailed case-sensitive comparisons between strings
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

    // Case-insensitive comparisons between strings
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

    // Waits for user interaction before closing the console window
    readln;
  except
    // Exception handling block to catch and display errors
    on E: Exception do
      writeln(E.ClassName, ': ', E.Message);
  end;

end.