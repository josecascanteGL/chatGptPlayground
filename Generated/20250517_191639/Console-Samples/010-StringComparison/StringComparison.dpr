// Program entry point
program StringComparison;

// Console application
{$APPTYPE CONSOLE}
// Include resources file
{$R *.res}

// Uses System.SysUtils unit
uses
  System.SysUtils;

// Declare string variables
var
  s1, s1L, s1U, s1LI, s1UI, s2, s2L, s2U, s2LI, s2UI, s3, s3L, s3U, s3LI, s3UI: string;

begin
  try
    // Assign values to string variables
    s1 := 'IciOuPas';
    s1L := s1.ToLower;
    s1LI := s1.ToLowerInvariant;
    s1U := s1.ToUpper;
    s1UI := s1.ToUpperInvariant;

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

    // Print values of s1
    writeln('s1');
    writeln(s1);
    writeln(s1L);
    writeln(s1LI);
    writeln(s1U);
    writeln(s1UI);

    // Print values of s2
    writeln('s2');
    writeln(s2);
    writeln(s2L);
    writeln(s2LI);
    writeln(s2U);
    writeln(s2UI);

    // Print values of s3
    writeln('s3');
    writeln(s3);
    writeln(s3L);
    writeln(s3LI);
    writeln(s3U);
    writeln(s3UI);

    // Comparison between s1 and s2
    writeln('s1 = s2');
    writeln(s1 = s2);
    writeln(s1L = s2L);
    writeln(s1U = s2U);
    writeln(s1LI = s2LI);
    writeln(s1UI = s2UI);

    // Comparison between s1 and s3
    writeln('s1 = s3');
    writeln(s1 = s3);
    writeln(s1L = s3L);
    writeln(s1U = s3U);
    writeln(s1LI = s3LI);
    writeln(s1UI = s3UI);

    // Compare using CompareStr function
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

    // Compare using CompareText function
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

    // Wait for user input
    readln;
  except
    // Exception handling
    on E: Exception do
      writeln(E.ClassName, ': ', E.Message);
  end;

end.