import sys

def writeln(data):
    print(data)

def compareStr(s1, s2):
    return (s1 > s2) - (s1 < s2)  # Return 1 if s1 > s2, -1 if s1 < s2, 0 if equal

def compareText(s1, s2):
    return compareStr(s1.lower(), s2.lower())  # Case-insensitive comparison

# Initialize strings
s1 = 'IciOuPas'
s1L = s1.lower()
s1LI = s1.lower()  # .lower() is invariant in Python
s1U = s1.upper()
s1UI = s1.upper()  # .upper() is invariant in Python

s2 = 'icioupas'
s2L = s2.lower()
s2LI = s2.lower()
s2U = s2.upper()
s2UI = s2.upper()

s3 = 'ICIOUPAS'
s3L = s3.lower()
s3LI = s3.lower()
s3U = s3.upper()
s3UI = s3.upper()

# Output results
writeln('s1')
writeln(s1)
writeln(s1L)
writeln(s1LI)
writeln(s1U)
writeln(s1UI)

writeln('s2')
writeln(s2)
writeln(s2L)
writeln(s2LI)
writeln(s2U)
writeln(s2UI)

writeln('s3')
writeln(s3)
writeln(s3L)
writeln(s3LI)
writeln(s3U)
writeln(s3UI)

# string comparisons
writeln('s1 = s2')
writeln(s1 == s2)
writeln(s1L == s2L)
writeln(s1U == s2U)
writeln(s1LI == s2LI)
writeln(s1UI == s2UI)

writeln('s1 = s3')
writeln(s1 == s3)
writeln(s1L == s3L)
writeln(s1U == s3U)
writeln(s1LI == s3LI)
writeln(s1UI == s3UI)

# Using compareStr for direct string comparison results
writeln('CompareStr')
writeln(compareStr(s1, s2))
writeln(compareStr(s1L, s2L))
writeln(compareStr(s1U, s2U))
writeln(compareStr(s1LI, s2LI))
writeln(compareStr(s1UI, s2UI))
writeln(compareStr(s1, s3))
writeln(compareStr(s1L, s3L))
writeln(compareStr(s1U, s3U))
writeln(compareStr(s1LI, s3LI))
writeln(compareStr(s1UI, s3UI))

# Using compareText for case-insensitive string comparison results
writeln('CompareText')
writeln(compareText(s1, s2))
writeln(compareText(s1L, s2L))
writeln(compareText(s1U, s2U))
writeln(compareText(s1LI, s2LI))
writeln(compareText(s1UI, s2UI))
writeln(compareText(s1, s3))
writeln(compareText(s1L, s3L))
writeln(compareText(s1U, s3U))
writeln(compareText(s1LI, s3LI))
writeln(compareText(s1UI, s3UI))

input()  # To hold the console window open until user presses enter
