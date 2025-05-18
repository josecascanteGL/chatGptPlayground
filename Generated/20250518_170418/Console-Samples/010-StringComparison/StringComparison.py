import locale

locale.setlocale(locale.LC_ALL, 'C')  # Set locale for case transformations

s1 = 'IciOuPas'
s1L = s1.lower()  # Lowercase transformation
s1LI = s1.lower()  # Locale invariant lowercase, same as regular in C locale
s1U = s1.upper()  # Uppercase transformation
s1UI = s1.upper()  # Locale invariant uppercase, same as regular in C locale

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
print(s1 == s2)  # String comparison is done with ==
print(s1L == s2L)
print(s1U == s2U)
print(s1LI == s2LI)
print(s1UI == s2UI)

print('s1 = s3')
print(s1 == s3)  # String comparison for equality
print(s1L == s3L)  # Compare lower case variants
print(s1U == s3U)  # Compare upper case variants
print(s1LI == s3LI)  # Compare locale invariant lower case variants
print(s1UI == s3UI)  # Compare locale invariant upper case variants

print('CompareStr')
print((s1 > s2) - (s1 < s2))  # Simulate Delphi's CompareStr
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
print((s1.upper() > s2.upper()) - (s1.upper() < s2.upper()))  # Use upper case for case insensitive comparison
print((s1L.upper() > s2L.upper()) - (s1L.upper() < s2L.upper()))
print((s1U.upper() > s2U.upper()) - (s1U.upper() < s2U.upper()))
print((s1LI.upper() > s2LI.upper()) - (s1LI.upper() < s2LI.upper()))
print((s1UI.upper() > s2UI.upper()) - (s1UI.upper() < s2UI.upper()))
print((s1.upper() > s3.upper()) - (s1.upper() < s3.upper()))
print((s1L.upper() > s3L.upper()) - (s1L.upper() < s3L.upper()))
print((s1U.upper() > s3U.upper()) - (s1U.upper() < s3U.upper()))
print((s1LI.upper() > s3LI.upper()) - (s1LI.upper() < s3LI.upper()))
print((s1UI.upper() > s3UI.upper()) - (s1UI.upper() < s3UI.upper()))

input()  # Python's input() substitutes Delphi's readln
