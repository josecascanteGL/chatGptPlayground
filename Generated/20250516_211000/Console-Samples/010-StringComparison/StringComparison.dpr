// Delphi Sample Projects copyright information and project summary

program StringComparison;

{$APPTYPE CONSOLE}
{$R *.res}

uses
  System.SysUtils;

var
  s1, s1L, s1U, s1LI, s1UI, // Declaration of string variables
  s2, s2L, s2U, s2LI, s2UI,
  s3, s3L, s3U, s3LI, s3UI: string;

begin
  try
    s1 := 'IciOuPas'; // Initialize string s1
    s1L := s1.ToLower; // Convert s1 to lowercase and store in s1L
    s1LI := s1.ToLowerInvariant; // Convert s1 to lowercase invariant and store in s1LI
    s1U := s1.ToUpper; // Convert s1 to uppercase and store in s1U
    s1UI := s1.ToUpperInvariant; // Convert s1 to uppercase invariant and store in s1UI

    s2 := 'icioupas'; // Initialize string s2
    s2L := s2.ToLower; // Convert s2 to lowercase and store in s2L
    s2LI := s2.ToLowerInvariant; // Convert s2 to lowercase invariant and store in s2LI
    s2U := s2.ToUpper; // Convert s2 to uppercase and store in s2U
    s2UI := s2.ToUpperInvariant; // Convert s2 to uppercase invariant and store in s2UI

    s3 := 'ICIOUPAS'; // Initialize string s3
    s3L := s3.ToLower; // Convert s3 to lowercase and store in s3L
    s3LI := s3.ToLowerInvariant; // Convert s3 to lowercase invariant and store in s3LI
    s3U := s3.ToUpper; // Convert s3 to uppercase and store in s3U
    s3UI := s3.ToUpperInvariant; // Convert s3 to uppercase invariant and store in s3UI

    // Output the different cases of strings and their respective lowercase/uppercase forms
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

    // Comparison of strings and their lowercase/uppercase forms
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

    // Comparison based on case-sensitive comparison
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

    // Comparison based on case-insensitive comparison
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

    readln;
  except
    on E: Exception do
      writeln(E.ClassName, ': ', E.Message);
  end;

end.