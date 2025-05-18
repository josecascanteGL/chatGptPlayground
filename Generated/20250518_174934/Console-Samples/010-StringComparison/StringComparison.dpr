program StringComparison;

{$APPTYPE CONSOLE} // Directs the application to run as a console application
{$R *.res} // Links the compiled resource file to the application

uses
  System.SysUtils; // Uses the System.SysUtils unit which provides system-level routines and utilities

// Declaration of multiple string variables
var
  s1, s1L, s1U, s1LI, s1UI, s2, s2L, s2U, s2LI, s2UI, s3, s3L, s3U, s3LI, s3UI: string;

begin
  try
    // Initialize strings with different cases to demonstrate case sensitivity
    s1 := 'IciOuPas'; // Assign string with mixed case
    s1L := s1.ToLower; // Convert s1 to lowercase
    s1LI := s1.ToLowerInvariant; // Convert s1 to lowercase using invariant culture
    s1U := s1.ToUpper; // Convert s1 to uppercase
    s1UI := s1.ToUpperInvariant; // Convert s1 to uppercase using invariant culture

    s2 := 'icioupas'; // Assign string in lowercase
    s2L := s2.ToLower; // Convert s2 to lowercase
    s2LI := s2.ToLowerInvariant; // Convert s2 to lowercase using invariant culture
    s2U := s2.ToUpper; // Convert s2 to uppercase
    s2UI := s2.ToUpperInvariant; // Convert s2 to uppercase using invariant culture

    s3 := 'ICIOUPAS'; // Assign string in uppercase
    s3L := s3.ToLower; // Convert s3 to lowercase
    s3LI := s3.ToLowerInvariant; // Convert s3 to lowercase using invariant culture
    s3U := s3.ToUpper; // Convert s3 to uppercase
    s3UI := s3.ToUpperInvariant; // Convert s3 to uppercase using invariant culture

    // Display values of string variables
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

    // Demonstrating comparisons for equality
    writeln('s1 = s2');
    writeln(s1 = s2); // Compare s1 with s2
    writeln(s1L = s2L); // Compare lowercase versions
    writeln(s1U = s2U); // Compare uppercase versions
    writeln(s1LI = s2LI); // Compare lowercase invariant versions
    writeln(s1UI = s2UI); // Compare uppercase invariant versions

    writeln('s1 = s3');
    writeln(s1 = s3); // Compare s1 with s3
    writeln(s1L = s3L); // Compare lowercase versions
    writeln(s1U = s3U); // Compare uppercase versions
    writeln(s1LI = s3LI); // Compare lowercase invariant versions
    writeln(s1UI = s3UI); // Compare uppercase invariant versions

    // Demonstrating string comparison functions
    writeln('CompareStr');
    writeln(compareStr(s1, s2)); // Case-sensitive comparison between s1 and s2
    writeln(compareStr(s1L, s2L)); // Case-sensitive comparison after conversion to lowercase
    writeln(compareStr(s1U, s2U)); // Case-sensitive comparison after conversion to uppercase
    writeln(compareStr(s1LI, s2LI)); // Case-sensitive comparison using invariant culture
    writeln(compareStr(s1UI, s2UI)); // Case-sensitive comparison using invariant culture
    writeln(compareStr(s1, s3)); // Case-sensitive comparison between s1 and s3
    writeln(compareStr(s1L, s3L)); // Case-sensitive comparison after conversion to lowercase
    writeln(compareStr(s1U, s3U)); // Case-sensitive comparison after conversion to uppercase
    writeln(compareStr(s1LI, s3LI)); // Case-sensitive comparison using invariant culture
    writeln(compareStr(s1UI, s3UI)); // Case-sensitive comparison using invariant culture

    writeln('CompareText');
    writeln(compareText(s1, s2)); // Case-insensitive comparison between s1 and s2
    writeln(compareText(s1L, s2L)); // Case-insensitive comparison after conversion to lowercase
    writeln(compareText(s1U, s2U)); // Case-insensitive comparison after conversion to uppercase
    writeln(compareText(s1LI, s2LI)); // Case-insensitive comparison using invariant culture
    writeln(compareText(s1UI, s2UI)); // Case-insensitive comparison using invariant culture
    writeln(compareText(s1, s3)); // Case-insensitive comparison between s1 and s3
    writeln(compareText(s1L, s3L)); // Case-insensitive comparison after conversion to lowercase
    writeln(compareText(s1U, s3U)); // Case-insensitive comparison after conversion to uppercase
    writeln(compareText(s1LI, s3LI)); // Case-insensitive comparison using invariant culture
    writeln(compareText(s1UI, s3UI)); // Case-insensitive comparison using invariant culture

    readln; // Wait for user input before closing the console. Good for debugging and standalone tests.
  except
    on E: Exception do
      writeln(E.ClassName, ': ', E.Message); // Catches and writes out exceptions with specific error messages
  end;

end.