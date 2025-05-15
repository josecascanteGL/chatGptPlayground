// Program entry point
begin
  try
    // Initialize strings
    s1 := 'IciOuPas';
    s1L := s1.ToLower; // Convert s1 to lowercase
    s1LI := s1.ToLowerInvariant; // Convert s1 to lowercase (invariant culture)
    s1U := s1.ToUpper; // Convert s1 to uppercase
    s1UI := s1.ToUpperInvariant; // Convert s1 to uppercase (invariant culture)

    // Initialize s2 strings with lowercase values
    s2 := 'icioupas';
    s2L := s2.ToLower;
    s2LI := s2.ToLowerInvariant;
    s2U := s2.ToUpper;
    s2UI := s2.ToUpperInvariant;

    // Initialize s3 strings with uppercase values
    s3 := 'ICIOUPAS';
    s3L := s3.ToLower;
    s3LI := s3.ToLowerInvariant;
    s3U := s3.ToUpper;
    s3UI := s3.ToUpperInvariant;

    // Output s1 strings
    writeln('s1');
    writeln(s1); // Original s1
    writeln(s1L); // s1 in lowercase
    writeln(s1LI); // s1 in lowercase (invariant culture)
    writeln(s1U); // s1 in uppercase
    writeln(s1UI); // s1 in uppercase (invariant culture)

    // Output s2 strings
    writeln('s2');
    writeln(s2); // Original s2
    writeln(s2L); // s2 in lowercase
    writeln(s2LI); // s2 in lowercase (invariant culture)
    writeln(s2U); // s2 in uppercase
    writeln(s2UI); // s2 in uppercase (invariant culture)

    // Output s3 strings
    writeln('s3');
    writeln(s3); // Original s3
    writeln(s3L); // s3 in lowercase
    writeln(s3LI); // s3 in lowercase (invariant culture)
    writeln(s3U); // s3 in uppercase
    writeln(s3UI); // s3 in uppercase (invariant culture)

    // Check string comparisons
    writeln('s1 = s2');
    writeln(s1 = s2); // Check if s1 equals s2
    writeln(s1L = s2L); // Check if s1 in lowercase equals s2 in lowercase
    writeln(s1U = s2U); // Check if s1 in uppercase equals s2 in uppercase
    writeln(s1LI = s2LI); // Check if s1 in lowercase (invariant culture) equals s2 in lowercase (invariant culture)
    writeln(s1UI = s2UI); // Check if s1 in uppercase (invariant culture) equals s2 in uppercase (invariant culture)

    writeln('s1 = s3');
    writeln(s1 = s3); // Check if s1 equals s3
    writeln(s1L = s3L); // Check if s1 in lowercase equals s3 in lowercase
    writeln(s1U = s3U); // Check if s1 in uppercase equals s3 in uppercase
    writeln(s1LI = s3LI); // Check if s1 in lowercase (invariant culture) equals s3 in lowercase (invariant culture)
    writeln(s1UI = s3UI); // Check if s1 in uppercase (invariant culture) equals s3 in uppercase (invariant culture)

    // Output string comparison results using CompareStr
    writeln('CompareStr');
    writeln(compareStr(s1, s2)); // Compare s1 and s2
    writeln(compareStr(s1L, s2L)); // Compare s1 in lowercase and s2 in lowercase
    writeln(compareStr(s1U, s2U)); // Compare s1 in uppercase and s2 in uppercase
    writeln(compareStr(s1LI, s2LI)); // Compare s1 in lowercase (invariant culture) and s2 in lowercase (invariant culture)
    writeln(compareStr(s1UI, s2UI)); // Compare s1 in uppercase (invariant culture) and s2 in uppercase (invariant culture)
    writeln(compareStr(s1, s3)); // Compare s1 and s3
    writeln(compareStr(s1L, s3L)); // Compare s1 in lowercase and s3 in lowercase
    writeln(compareStr(s1U, s3U)); // Compare s1 in uppercase and s3 in uppercase
    writeln(compareStr(s1LI, s3LI)); // Compare s1 in lowercase (invariant culture) and s3 in lowercase (invariant culture)
    writeln(compareStr(s1UI, s3UI)); // Compare s1 in uppercase (invariant culture) and s3 in uppercase (invariant culture)

    // Output string comparison results using CompareText
    writeln('CompareText');
    writeln(compareText(s1, s2)); // Compare s1 and s2
    writeln(compareText(s1L, s2L)); // Compare s1 in lowercase and s2 in lowercase
    writeln(compareText(s1U, s2U)); // Compare s1 in uppercase and s2 in uppercase
    writeln(compareText(s1LI, s2LI)); // Compare s1 in lowercase (invariant culture) and s2 in lowercase (invariant culture)
    writeln(compareText(s1UI, s2UI)); // Compare s1 in uppercase (invariant culture) and s2 in uppercase (invariant culture)
    writeln(compareText(s1, s3)); // Compare s1 and s3
    writeln(compareText(s1L, s3L)); // Compare s1 in lowercase and s3 in lowercase
    writeln(compareText(s1U, s3U)); // Compare s1 in uppercase and s3 in uppercase
    writeln(compareText(s1LI, s3LI)); // Compare s1 in lowercase (invariant culture) and s3 in lowercase (invariant culture)
    writeln(compareText(s1UI, s3UI)); // Compare s1 in uppercase (invariant culture) and s3 in uppercase (invariant culture)

    // Wait for user input before closing the console window
    readln;
  except
    on E: Exception do
      writeln(E.ClassName, ': ', E.Message);
  end;

end.