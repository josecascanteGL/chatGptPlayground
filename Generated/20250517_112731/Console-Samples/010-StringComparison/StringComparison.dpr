/// ***************************************************************************

// Delphi Sample Projects

// Copyright 1995-2025 Patrick Prémartin under AGPL 3.0 license.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR

// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,

// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL

// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER

// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING

// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER

// DEALINGS IN THE SOFTWARE.

// ***************************************************************************

// Set of projects demonstrating the features of the Delphi development

// environment, its libraries and its programming language.

// Some of the projects have been presented at conferences, on training

// courses or online coding sessions.

// The programs are up to date with the Community Edition and the commercial

// version of Delphi or RAD Studio.

// ***************************************************************************

// Author(s) :

// Patrick PREMARTIN

// Site :

// https://samples.developpeur-pascal.fr

// Project site :

// https://github.com/DeveloppeurPascal/Delphi-samples

// ***************************************************************************

// File last update : 2025-04-01T17:34:38.000+02:00

// Signature : 22bfedba947dcea84f26bcb8532a5ef8f899b54f

// ***************************************************************************

/// </summary>

program StringComparison;

{$APPTYPE CONSOLE}
{$R *.res}

uses
  System.SysUtils;

var
  s1, s1L, s1U, s1LI, s1UI, s2, s2L, s2U, s2LI, s2UI, s3, s3L, s3U, s3LI, s3UI: string;

begin
  try
    s1 := 'IciOuPas'; // Initialize s1 with a mixed-case string
    s1L := s1.ToLower; // Convert s1 to lowercase and store in s1L
    s1LI := s1.ToLowerInvariant; // Convert s1 to lowercase using invariant culture and store in s1LI
    s1U := s1.ToUpper; // Convert s1 to uppercase and store in s1U
    s1UI := s1.ToUpperInvariant; // Convert s1 to uppercase using invariant culture and store in s1UI

    s2 := 'icioupas'; // Initialize s2 with lowercase string
    s2L := s2.ToLower; // Convert s2 to lowercase and store in s2L
    s2LI := s2.ToLowerInvariant; // Convert s2 to lowercase using invariant culture and store in s2LI
    s2U := s2.ToUpper; // Convert s2 to uppercase and store in s2U
    s2UI := s2.ToUpperInvariant; // Convert s2 to uppercase using invariant culture and store in s2UI

    s3 := 'ICIOUPAS'; // Initialize s3 with uppercase string
    s3L := s3.ToLower; // Convert s3 to lowercase and store in s3L
    s3LI := s3.ToLowerInvariant; // Convert s3 to lowercase using invariant culture and store in s3LI
    s3U := s3.ToUpper; // Convert s3 to uppercase and store in s3U
    s3UI := s3.ToUpperInvariant; // Convert s3 to uppercase using invariant culture and store in s3UI

    writeln('s1');
    writeln(s1); // Output s1
    writeln(s1L); // Output s1 converted to lowercase
    writeln(s1LI); // Output s1 converted to lowercase using invariant culture
    writeln(s1U); // Output s1 converted to uppercase
    writeln(s1UI); // Output s1 converted to uppercase using invariant culture

    writeln('s2');
    writeln(s2); // Output s2
    writeln(s2L); // Output s2 converted to lowercase
    writeln(s2LI); // Output s2 converted to lowercase using invariant culture
    writeln(s2U); // Output s2 converted to uppercase
    writeln(s2UI); // Output s2 converted to uppercase using invariant culture

    writeln('s3');
    writeln(s3); // Output s3
    writeln(s3L); // Output s3 converted to lowercase
    writeln(s3LI); // Output s3 converted to lowercase using invariant culture
    writeln(s3U); // Output s3 converted to uppercase
    writeln(s3UI); // Output s3 converted to uppercase using invariant culture

    // readln; // Commented out, waiting for user input is disabled

    writeln('s1 = s2');
    writeln(s1 = s2); // Output comparison of s1 and s2
    writeln(s1L = s2L); // Output comparison of s1L and s2L
    writeln(s1U = s2U); // Output comparison of s1U and s2U
    writeln(s1LI = s2LI); // Output comparison of s1LI and s2LI
    writeln(s1UI = s2UI); // Output comparison of s1UI and s2UI

    writeln('s1 = s3');
    writeln(s1 = s3); // Output comparison of s1 and s3
    writeln(s1L = s3L); // Output comparison of s1L and s3L
    writeln(s1U = s3U); // Output comparison of s1U and s3U
    writeln(s1LI = s3LI); // Output comparison of s1LI and s3LI
    writeln(s1UI = s3UI); // Output comparison of s1UI and s3UI

    writeln('CompareStr');
    writeln(compareStr(s1, s2)); // Output comparison using CompareStr of s1 and s2
    writeln(compareStr(s1L, s2L)); // Output comparison using CompareStr of s1L and s2L
    writeln(compareStr(s1U, s2U)); // Output comparison using CompareStr of s1U and s2U
    writeln(compareStr(s1LI, s2LI)); // Output comparison using CompareStr of s1LI and s2LI
    writeln(compareStr(s1UI, s2UI)); // Output comparison using CompareStr of s1UI and s2UI
    writeln(compareStr(s1, s3)); // Output comparison using CompareStr of s1 and s3
    writeln(compareStr(s1L, s3L)); // Output comparison using CompareStr of s1L and s3L
    writeln(compareStr(s1U, s3U)); // Output comparison using CompareStr of s1U and s3U
    writeln(compareStr(s1LI, s3LI)); // Output comparison using CompareStr of s1LI and s3LI
    writeln(compareStr(s1UI, s3UI)); // Output comparison using CompareStr of s1UI and s3UI

    writeln('CompareText');
    writeln(compareText(s1, s2)); // Output comparison using CompareText of s1 and s2
    writeln(compareText(s1L, s2L)); // Output comparison using CompareText of s1L and s2L
    writeln(compareText(s1U, s2U)); // Output comparison using CompareText of s1U and s2U
    writeln(compareText(s1LI, s2LI)); // Output comparison using CompareText of s1LI and s2LI
    writeln(compareText(s1UI, s2UI)); // Output comparison using CompareText of s1UI and s2UI
    writeln(compareText(s1, s3)); // Output comparison using CompareText of s1 and s3
    writeln(compareText(s1L, s3L)); // Output comparison using CompareText of s1L and s3L
    writeln(compareText(s1U, s3U)); // Output comparison using CompareText of s1U and s3U
    writeln(compareText(s1LI, s3LI)); // Output comparison using CompareText of s1LI and s3LI
    writeln(compareText(s1UI, s3UI)); // Output comparison using CompareText of s1UI and s3UI

    readln; // Wait for user input after all comparisons

  except
    on E: Exception do
      writeln(E.ClassName, ': ', E.Message); // Output any exceptions that occur
  end;

end.