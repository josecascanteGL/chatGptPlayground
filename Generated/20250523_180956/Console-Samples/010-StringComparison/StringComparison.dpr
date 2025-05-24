program StringComparison;

{$APPTYPE CONSOLE} // Sets the application type to a console application
{$R *.res} // Include resources file

uses
  System.SysUtils;

var
  // Declaration of all string variables used for comparison
  s1, s1L, s1U, s1LI, s1UI, s2, s2L, s2U, s2LI, s2UI, s3, s3L, s3U, s3LI, s3UI: string;

begin
  try
    // Initial assignment of string values
    s1 := 'IciOuPas';
    // Conversion operations for various cases
    s1L := s1.ToLower; // Convert s1 to lowercase
    s1LI := s1.ToLowerInvariant; // Convert s1 to lowercase using invariant culture
    s1U := s1.ToUpper; // Convert s1 to uppercase
    s1UI := s1.ToUpperInvariant; // Convert s1 to uppercase using invariant culture

    // Repeat the process for other string literal 'icioupas'
    s2 := 'icioupas';
    s2L := s2.ToLower;
    s2LI := s2.ToLowerInvariant;
    s2U := s2.ToUpper;
    s2UI := s2.ToUpperInvariant;

    // Repeat the process for other string literal 'ICIOUPAS'
    s3 := 'ICIOUPAS';
    s3L := s3.ToLower;
    s3LI := s3.ToLowerInvariant;
    s3U := s3.ToUpper;
    s3UI := s3.ToUpperInvariant;

    // Output values so they can be visually compared
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

    // Comparison operations to demonstrate equality between strings
    writeln('s1 = s2');
    writeln(s1 = s2); // Check if s1 and s2 are literally the same
    writeln(s1L = s2L); // Compare lowercase versions
    writeln(s1U = s2U); // Compare uppercase versions
    writeln(s1LI = s2LI); // Compare lowercase invariant versions
    writeln(s1UI = s2UI); // Compare uppercase invariant versions

    writeln('s1 = s3');
    writeln(s1 = s3); // Repeat comparisons for s1 and s3
    writeln(s1L = s3L);
    writeln(s1U = s3U);
    writeln(s1LI = s3LI);
    writeln(s1UI = s3UI);

    // Using CompareStr and CompareText functions to demonstrate differences
    writeln('CompareStr'); // Case-sensitive comparison
    writeln(compareStr(s1, s2)); // Compare s1 and s2
    writeln(compareStr(s1L, s2L)); // Compare their lowercase forms
    writeln(compareStr(s1U, s2U)); // and uppercase forms
    writeln(compareStr(s1LI, s2LI)); // and lower invariant forms
    writeln(compareStr(s1UI, s2UI)); // and upper invariant forms
    writeln(compareStr(s1, s3)); // Repeat for s1 and s3
    writeln(compareStr(s1L, s3L));
    writeln(compareStr(s1U, s3U));
    writeln(compareStr(s1LI, s3LI));
    writeln(compareStr(s1UI, s3UI));

    writeln('CompareText'); // Case-insensitive comparison
    writeln(compareText(s1, s2)); // Compare s1 and s2
    writeln(compareText(s1L, s2L)); // Compare their lowercase forms
    writeln(compareText(s1U, s2U)); // and uppercase forms
    writeln(compareText(s1LI, s2LI)); // and lower invariant forms
    writeln(compareText(s1UI, s2UI)); // and upper invariant forms
    writeln(compareText(s1, s3)); // Repeat for s1 and s3
    writeln(compareText(s1L, s3L));
    writeln(compareText(s1U, s3U));
    writeln(compareText(s1LI, s3LI));
    writeln(compareText(s1UI, s3UI));

    readln;
  except
    on E: Exception do
      writeln(E.ClassName, ': ', E.Message);
  end;

end.