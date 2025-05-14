// This program demonstrates different ways to compare strings in Delphi

program StringComparison;

{$APPTYPE CONSOLE}
{$R *.res}

uses
  System.SysUtils;

var
  // Declarations of string variables for testing
  s1, s1L, s1U, s1LI, s1UI, s2, s2L, s2U, s2LI, s2UI, s3, s3L, s3U, s3LI, s3UI: string;

begin
  try
    // Initialize string variables with different cases
    s1 := 'IciOuPas';
    s1L := s1.ToLower; // Convert to lowercase
    s1LI := s1.ToLowerInvariant; // Convert to lowercase invariant
    s1U := s1.ToUpper; // Convert to uppercase
    s1UI := s1.ToUpperInvariant; // Convert to uppercase invariant

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

    // Display the original, lowercase, lowercase invariant, uppercase, and uppercase invariant versions of strings
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

    // Compare the strings using different comparison methods
    writeln('s1 = s2');
    writeln(s1 = s2);
    writeln(s1L = s2L);
    writeln(s1U = s2U);
    writeln(s1LI = s2LI);
    writeln(s1UI = s2UI);

    writeln('s1 = s3');
    writeln(s1 = s3);
    writeln(s1L = s3L);
    writeln(s1U = s3U);
    writeln(s1LI = s3LI);
    writeln(s1UI = s3UI);

    // Compare strings using CompareStr function
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

    // Compare strings using CompareText function
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

    // Pause to display output before closing
    readln;
  except
    on E: Exception do
      writeln(E.ClassName, ': ', E.Message);
  end;

end.