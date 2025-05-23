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

{$APPTYPE CONSOLE}
{$R *.res}

uses
  System.SysUtils;

var
  s1, s1L, s1U, s1LI, s1UI, s2, s2L, s2U, s2LI, s2UI, s3, s3L, s3U, s3LI, s3UI: string;

begin
  try
    s1 := 'IciOuPas'; // Assigns a string value to s1
    s1L := s1.ToLower; // Converts s1 to lowercase and assigns to s1L
    s1LI := s1.ToLowerInvariant; // Converts s1 to lowercase invariant and assigns to s1LI
    s1U := s1.ToUpper; // Converts s1 to uppercase and assigns to s1U
    s1UI := s1.ToUpperInvariant; // Converts s1 to uppercase invariant and assigns to s1UI

    s2 := 'icioupas'; // Assigns a string value to s2
    s2L := s2.ToLower; // Converts s2 to lowercase and assigns to s2L
    s2LI := s2.ToLowerInvariant; // Converts s2 to lowercase invariant and assigns to s2LI
    s2U := s2.ToUpper; // Converts s2 to uppercase and assigns to s2U
    s2UI := s2.ToUpperInvariant; // Converts s2 to uppercase invariant and assigns to s2UI

    s3 := 'ICIOUPAS'; // Assigns a string value to s3
    s3L := s3.ToLower; // Converts s3 to lowercase and assigns to s3L
    s3LI := s3.ToLowerInvariant; // Converts s3 to lowercase invariant and assigns to s3LI
    s3U := s3.ToUpper; // Converts s3 to uppercase and assigns to s3U
    s3UI := s3.ToUpperInvariant; // Converts s3 to uppercase invariant and assigns to s3UI

    // Displaying the values of s1, s1L, s1LI, s1U, s1UI
    writeln('s1');
    writeln(s1);
    writeln(s1L);
    writeln(s1LI);
    writeln(s1U);
    writeln(s1UI);

    // Displaying the values of s2, s2L, s2LI, s2U, s2UI
    writeln('s2');
    writeln(s2);
    writeln(s2L);
    writeln(s2LI);
    writeln(s2U);
    writeln(s2UI);

    // Displaying the values of s3, s3L, s3LI, s3U, s3UI
    writeln('s3');
    writeln(s3);
    writeln(s3L);
    writeln(s3LI);
    writeln(s3U);
    writeln(s3UI);

    // Comparing different forms of strings s1=s2 and s1=s3
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

    // Comparing strings using CompareStr
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

    // Comparing strings using CompareText
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

    readln; // Wait for user input

  except
    on E: Exception do
      writeln(E.ClassName, ': ', E.Message); // Display any exceptions that occur
  end;

end.