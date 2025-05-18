program StringComparison;

{$APPTYPE CONSOLE} // This directive sets the application type as a console application
{$R *.res} // This directive includes resources into the application

uses
  System.SysUtils; // Uses the System.SysUtils unit, which contains system-related utilities and functions

var
  // Declaration of variables to store different string modifications
  s1, s1L, s1U, s1LI, s1UI, s2, s2L, s2U, s2LI, s2UI, s3, s3L, s3U, s3LI, s3UI: string;

begin
  try // Begin exception handling block
    // Assign strings and their variations (lowercase, uppercase, invariant culture)
    s1 := 'IciOuPas';
    s1L := s1.ToLower; // Convert s1 to lowercase
    s1LI := s1.ToLowerInvariant; // Convert s1 to lowercase using invariant culture
    s1U := s1.ToUpper; // Convert s1 to uppercase
    s1UI := s1.ToUpperInvariant; // Convert s1 to uppercase using invariant culture

    s2 := 'icioupas';
    s2L := s2.ToLower; // Redundant operation, s2 is already in lowercase
    s2LI := s2.ToLowerInvariant; // Same as s2L but using invariant culture
    s2U := s2.ToUpper; // Convert s2 to uppercase
    s2UI := s2.ToUpperInvariant; // Convert s2 to uppercase using invariant culture

    s3 := 'ICIOUPAS';
    s3L := s3.ToLower; // Convert s3 to lowercase
    s3LI := s3.ToLowerInvariant; // Convert s3 to lowercase using invariant culture
    s3U := s3.ToUpper; // Redundant operation, s3 is already in uppercase
    s3UI := s3.ToUpperInvariant; // Same as s3U but using invariant culture

    // Output the values of the strings and their variations
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

    // readln; // Commented out - usually used to pause console for viewer, but not active

    // Compare strings using both assignment and CompareStr/CompareText
    writeln('s1 = s2');
    writeln(s1 = s2); // Compare s1 with s2 for equality
    writeln(s1L = s2L); // Compare lowercase versions
    writeln(s1U = s2U); // Compare uppercase versions
    writeln(s1LI = s2LI); // Compare invariant culture lowercase versions
    writeln(s1UI = s2UI); // Compare invariant culture uppercase versions

    writeln('s1 = s3');
    writeln(s1 = s3); // Compare s1 with s3 for equality
    writeln(s1L = s3L); // Compare lowercase versions
    writeln(s1U = s3U); // Compare uppercase versions
    writeln(s1LI = s3LI); // Compare invariant culture lowercase versions
    writeln(s1UI = s3UI); // Compare invariant culture uppercase versions

    writeln('CompareStr');
    writeln(compareStr(s1, s2)); // Compare s1 and s2 using CompareStr, sensitive to case
    writeln(compareStr(s1L, s2L)); // Sensitive comparison of lowercase versions
    writeln(compareStr(s1U, s2U)); // Sensitive comparison of uppercase versions
    writeln(compareStr(s1LI, s2LI)); // Sensitive comparison using invariant culture
    writeln(compareStr(s1UI, s2UI)); 
    writeln(compareStr(s1, s3)); 
    writeln(compareStr(s1L, s3L)); 
    writeln(compareStr(s1U, s3U)); 
    writeln(compareStr(s1LI, s3LI)); 
    writeln(compareStr(s1UI, s3UI)); 

    writeln('CompareText');
    writeln(compareText(s1, s2)); // Compare s1 and s2 using CompareText, insensitive to case
    writeln(compareText(s1L, s2L)); // Insensitive comparison of lowercase versions, redundant
    writeln(compareText(s1U, s2U)); // Insensitive comparison of uppercase versions, redundant
    writeln(compareText(s1LI, s2LI)); // Insensitive comparison using invariant culture
    writeln(compareText(s1UI, s2UI)); 
    writeln(compareText(s1, s3)); 
    writeln(compareText(s1L, s3L)); 
    writeln(compareText(s1U, s3U)); 
    writeln(compareText(s1LI, s3LI)); 
    writeln(compareText(s1UI, s3UI)); 

    readln; // Pauses the execution allowing users to see the output before console closes
  except
    on E: Exception do
      writeln(E.ClassName, ': ', E.Message); // If an exception occurs, print the exception class name and message
  end;

end.
