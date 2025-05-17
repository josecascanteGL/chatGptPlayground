// This program demonstrates string comparison functions in Delphi

program StringComparison;

{$APPTYPE CONSOLE} // Specifies the type of application
{$R *.res} // Resource file

uses
  System.SysUtils; // Using the SysUtils unit

var
  s1, s1L, s1U, s1LI, s1UI, // Declaring string variables
  s2, s2L, s2U, s2LI, s2UI,
  s3, s3L, s3U, s3LI, s3UI: string;

begin
  try
    s1 := 'IciOuPas'; // Assigning string values to variables
    s1L := s1.ToLower; // Converting string to lowercase
    s1LI := s1.ToLowerInvariant; // Converting string to lowercase using invariant culture
    s1U := s1.ToUpper; // Converting string to uppercase
    s1UI := s1.ToUpperInvariant; // Converting string to uppercase using invariant culture

    s2 := 'icioupas'; // Assigning string values to variables
    s2L := s2.ToLower; // Converting string to lowercase
    s2LI := s2.ToLowerInvariant; // Converting string to lowercase using invariant culture
    s2U := s2.ToUpper; // Converting string to uppercase
    s2UI := s2.ToUpperInvariant; // Converting string to uppercase using invariant culture

    s3 := 'ICIOUPAS'; // Assigning string values to variables
    s3L := s3.ToLower; // Converting string to lowercase
    s3LI := s3.ToLowerInvariant; // Converting string to lowercase using invariant culture
    s3U := s3.ToUpper; // Converting string to uppercase
    s3UI := s3.ToUpperInvariant; // Converting string to uppercase using invariant culture

    // Outputting the original strings and their lowercase/uppercase versions
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

    // Performing string comparisons
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

    // Comparing strings using CompareStr function
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

    // Comparing strings using CompareText function
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

    readln; // Waiting for user input
  except
    on E: Exception do
      writeln(E.ClassName, ': ', E.Message); // Handling exceptions
  end;

end.