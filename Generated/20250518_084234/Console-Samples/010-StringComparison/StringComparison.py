s1 = 'IciOuPas'
s1L = s1.lower()  # Convert to lowercase
s1LI = s1.casefold()  # Convert to lowercase in a way suitable for case insensitive comparisons
s1U = s1.upper()  # Convert to uppercase
s1UI = s1.upper()  # No invariant method in Python, using upper() for invariant effects

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
print((s1 > s2) - (s1 < s2))  # Simulates Delphi's CompareStr
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
print((s1.lower() > s2.lower()) - (s1.lower() < s2.lower()))  # Compare in a case-insensitive manner
print((s1L.lower() > s2L.lower()) - (s1L.lower() < s2L.lower()))
print((s1U.lower() > s2U.lower()) - (s1U.lower() < s2U.lower()))
print((s1LI.lower() > s2LI.lower()) - (s1LI.lower() < s2LI.lower()))
print((s1UI.lower() > s2UI.lower()) - (s1UI.lower() < s2UI.lower()))
print((s1.lower() > s3.lower()) - (s1.lower() < s3.lower()))
print((s1L.lower() > s3L.lower()) - (s1L.lower() < s3L.lower()))
print((s1U.lower() > s3U.lower()) - (s1U.lower() < s3U.lower()))
print((s1LI.lower() > s3LI.lower()) - (s1LI.lower() < s3LI.lower()))
print((s1UI.lower() > s3UI.lower()) - (s1UI.lower() < s3UI.lower()))

input()  # Wait for user input to mimic readln in Delphi