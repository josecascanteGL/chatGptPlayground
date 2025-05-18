/// <summary>
/// ***************************************************************************
///
/// Delphi Sample Projects
///
/// Copyright 1995-2025 Patrick Prémartin under AGPL 3.0 license.
///
/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
/// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
/// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
/// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
/// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
/// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
/// DEALINGS IN THE SOFTWARE.
///
/// ***************************************************************************
///
/// Set of projects demonstrating the features of the Delphi development
/// environment, its libraries and its programming language.
///
/// Some of the projects have been presented at conferences, on training
/// courses or online coding sessions.
///
/// The programs are up to date with the Community Edition and the commercial
/// version of Delphi or RAD Studio.
///
/// ***************************************************************************
///
/// Author(s) :
/// Patrick PREMARTIN
///
/// Site :
/// https://samples.developpeur-pascal.fr
///
/// Project site :
/// https://github.com/DeveloppeurPascal/Delphi-samples
///
/// ***************************************************************************
/// File last update : 2025-04-01T17:34:38.000+02:00
/// Signature : 22bfedba947dcea84f26bcb8532a5ef8f899b54f
/// ***************************************************************************
/// </summary>

program StringComparison;

{$APPTYPE CONSOLE} // Directs the compiler to generate a console application.
{$R *.res} // Include resource files in the executable.

uses
  System.SysUtils; // Use System.SysUtils library for system utilities like string functions.

var
  // Declaration of multiple string variables to be used for string manipulations.
  s1, s1L, s1U, s1LI, s1UI, s2, s2L, s2U, s2LI, s2UI, s3, s3L, s3U, s3LI, s3UI: string;

begin
  try
    // Initialize the variables with different cases for string comparisons.
    s1 := 'IciOuPas';
    s1L := s1.ToLower; // Convert s1 to lowercase.
    s1LI := s1.ToLowerInvariant; // Convert s1 to lowercase using invariant culture.
    s1U := s1.ToUpper; // Convert s1 to uppercase.
    s1UI := s1.ToUpperInvariant; // Convert s1 to uppercase using invariant culture.

    s2 := 'icioupas'; // A lowercase version of the string for comparison.
    s2L := s2.ToLower; // Redundant here since s2 is already in lowercase.
    s2LI := s2.ToLowerInvariant; // Also redundant as s2 is already in lowercase using invariant culture.
    s2U := s2.ToUpper; // Convert s2 to uppercase.
    s2UI := s2.ToUpperInvariant; // Convert s2 to uppercase using invariant culture.

    s3 := 'ICIOUPAS'; // An uppercase version of the string for comparison.
    s3L := s3.ToLower; // Convert s3 to lowercase.
    s3LI := s3.ToLowerInvariant; // Convert s3 to lowercase using invariant culture.
    s3U := s3.ToUpper; // Redundant since s3 is already in uppercase.
    s3UI := s3.ToUpperInvariant; // Also redundant as s3 is already in uppercase using invariant culture.

    // Output the original strings and their transformations to the console.
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

    // Output comparison results between string variants.
    writeln('s1 = s2');
    writeln(s1 = s2); // Compare case-sensitive s1 and s2.
    writeln(s1L = s2L); // Compare case-insensitive since both are lowercase.
    writeln(s1U = s2U); // Compare case-insensitive since both are uppercase.
    writeln(s1LI = s2LI); // Compare lowercase in culture invariant way.
    writeln(s1UI = s2UI); // Compare uppercase in culture invariant way.

    writeln('s1 = s3');
    writeln(s1 = s3); // Compare case-sensitive s1 and s3.
    writeln(s1L = s3L); // Compare case-insensitive since both are lowercase.
    writeln(s1U = s3U); // Compare case-insensitive since both are uppercase.
    writeln(s1LI = s3LI); // Compare lowercase in culture invariant way.
    writeln(s1UI = s3UI); // Compare uppercase in culture invariant way.

    // Output detailed comparison results using CompareStr and CompareText functions.
    writeln('CompareStr');
    writeln(compareStr(s1, s2)); // Compare case-sensitive strings.
    writeln(compareStr(s1L, s2L)); // Compare case-insensitive strings.
    writeln(compareStr(s1U, s2U)); // Compare case-insensitive strings.
    writeln(compareStr(s1LI, s2LI)); // Compare in culture invariant way, case-sensitive.
    writeln(compareStr(s1UI, s2UI)); // Compare in culture invariant way, case-sensitive.
    writeln(compareStr(s1, s3)); // Compare case-sensitive strings.
    writeln(compareStr(s1L, s3L)); // Compare case-insensitive strings.
    writeln(compareStr(s1U, s3U)); // Compare case-insensitive strings.
    writeln(compareStr(s1LI, s3LI)); // Compare in culture invariant way, case-sensitive.
    writeln(compareStr(s1UI, s3UI)); // Compare in culture invariant way, case-sensitive.

    writeln('CompareText');
    writeln(compareText(s1, s2)); // Compare strings case-insensitively.
    writeln(compareText(s1L, s2L)); // Compare strings case-insensitively.
    writeln(compareText(s1U, s2U)); // Compare strings case-insensitively.
    writeln(compareText(s1LI, s2LI)); // Compare strings case-insensitively.
    writeln(compareText(s1UI, s2UI)); // Compare strings case-insensitively.
    writeln(compareText(s1, s3)); // Compare strings case-insensitively.
    writeln(compareText(s1L, s3L)); // Compare strings case-insensitively.
    writeln(compareText(s1U, s3U)); // Compare strings case-insensitively.
    writeln(compareText(s1LI, s3LI)); // Compare strings case-insensitively.
    writeln(compareText(s1UI, s3UI)); // Compare strings case-insensitively.

    readln; // Waits for the user to press Enter before closing the application.
  except
    on E: Exception do
      writeln(E.ClassName, ': ', E.Message); // Handle exceptions by printing error messages.
  end;

end.