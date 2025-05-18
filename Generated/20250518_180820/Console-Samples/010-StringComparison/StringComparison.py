import sys

s1 = 'IciOuPas'
s1L = s1.lower()
s1LI = s1.casefold()
s1U = s1.upper()
s1UI = s1.upper()

s2 = 'icioupas'
s2L = s2.lower()
s2LI = s2.casefold()
s2U = s2.upper()
s2UI = s2.upper()

s3 = 'ICIOUPAS'
s3L = s3.lower()
s3LI = s3.casefold()
s3U = s3.upper()
s3UI = s3.upper()

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

# readline() equivalent in Python to pause execution is input()

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

print('CompareStr')
print((s1 > s2) - (s1 < s2)) # Python string comparison returns boolean, converted to -1,0,1 for equivalence to compareStr
print((s1L > s2L) - (s1L < s2L))
print((s1U > s2U) - (s1U < s2U))
print((s1LI > s2LI) - (s1LI < s2LI))
print((s1UI > s2UI) - (s1UI < s2UI))
print((s1 > s3) - (s1 < s3))
print((s1L > s3L) - (s1L < s3L))
print((s1U > s3U) - (s1U < s3U))
print((s1LI > s3LI) - (s1LI < s3LI))
print((s1UI > s3UI) - (s1UI < s3UI))

print('CompareText')
print((s1.lower() > s2.lower()) - (s1.lower() < s2.lower())) # Using case-insensitive comparison for CompareText
print((s1L > s2L) - (s1L < s2L))
print((s1U.lower() > s2U.lower()) - (s1U.lower() < s2U.lower()))
print((s1LI > s2LI) - (s1LI < s2LI))
print((s1UI.lower() > s2UI.lower()) - (s1UI.lower() < s2UI.lower()))
print((s1.lower() > s3.lower()) - (s1.lower() < s3.lower()))
print((s1L > s3L) - (s1L < s3L))
print((s1U.lower() > s3U.lower()) - (s1U.lower() < s3U.lower()))
print((s1LI > s3LI) - (s1LI < s3LI))
print((s1UI.lower() > s3UI.lower()) - (s1UI.lower() < s3UI.lower()))

input() # Pause to view output like readln in Delphi