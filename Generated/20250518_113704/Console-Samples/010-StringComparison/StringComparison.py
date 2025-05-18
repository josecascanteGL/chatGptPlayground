import sys

# String case manipulation variables
s1 = 'IciOuPas'
s1L = s1.lower()
s1LI = s1.lower()  # Python uses the same method for toLower and toLowerInvariant
s1U = s1.upper()
s1UI = s1.upper()  # Python uses the same method for toUpper and toUpperInvariant

s2 = 'icioupas'
s2L = s2.lower()
s2LI = s2.lower()  # Simulating toLowerInvariant
s2U = s2.upper()
s2UI = s2.upper()  # Simulating toUpperInvariant

s3 = 'ICIOUPAS'
s3L = s3.lower()
s3LI = s3.lower()  # Simulating toLowerInvariant
s3U = s3.upper()
s3UI = s3.upper()  # Simulating toUpperInvariant

# Prints strings in their original and modified forms
print('s1')
print(s1)
print(s1L)
print(s1LI)
print(s1U)
print(s1UI)

print('s2')
print(s2)
print(s2L)
print(s2LI)
print(s2U)
print(s2UI)

print('s3')
print(s3)
print(s3L)
print(s3LI)
print(s3U)
print(s3UI)

# Print comparison results
print('s1 = s2')
print(s1 == s2)
print(s1L == s2L)
print(s1U == s2U)
print(s1LI == s2LI)
print(s1UI == s2UI)

print('s1 = s3')
print(s1 == s3)
print(s1L == s3L)
print(s1U == s3U)
print(s1LI == s3LI)
print(s1UI == s3UI)

# CompareStr is equivalent to direct comparison in Python
def compare_str(s1, s2):
    return (s1 > s2) - (s1 < s2)

print('CompareStr')
print(compare_str(s1, s2))
print(compare_str(s1L, s2L))
print(compare_str(s1U, s2U))
print(compare_str(s1LI, s2LI))
print(compare_str(s1UI, s2UI))
print(compare_str(s1, s3))
print(compare_str(s1L, s3L))
print(compare_str(s1U, s3U))
print(compare_str(s1LI, s3LI))
print(compare_str(s1UI, s3UI))

# CompareText is equivalent to comparing lower-cased versions in Python
def compare_text(s1, s2):
    return (s1.lower() > s2.lower()) - (s1.lower() < s2.lower())

print('CompareText')
print(compare_text(s1, s2))
print(compare_text(s1L, s2L))
print(compare_text(s1U, s2U))
print(compare_text(s1LI, s2LI))
print(compare_text(s1UI, s2UI))
print(compare_text(s1, s3))
print(compare_text(s1L, s3L))
print(compare_text(s1U, s3U))
print(compare_text(s1LI, s3LI))
print(compare_text(s1UI, s3UI))

# Equivalent to `readln` in Delphi, kept for when user input is needed
input()