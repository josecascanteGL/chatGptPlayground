import sys

# Define string manipulation to lower and upper cases
s1 = 'IciOuPas'
s1L = s1.lower()  # Lowercase
s1LI = s1.lower()  # Lowercase invariant, same as lower in Python
s1U = s1.upper()  # Uppercase
s1UI = s1.upper()  # Uppercase invariant, same as upper in Python

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

# Print statements for each string version
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

# String comparison
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

def compare_str(a, b):
    # Compare strings exactly
    if a > b:
        return 1
    elif a < b:
        return -1
    else:
        return 0

def compare_text(a, b):
    # Compare strings case-insensitively
    a, b = a.lower(), b.lower()
    if a > b:
        return 1
    elif a < b:
        return -1
    else:
        return 0

# CompareStr function results
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

# CompareText function results
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

# Placeholder for user input to pause execution (as readln in Delphi)
input()