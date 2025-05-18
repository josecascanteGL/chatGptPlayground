import locale  # Used to adjust for locale specific operations where necessary

# Initialize strings
s1 = 'IciOuPas'
s1L = s1.lower()  # Standard lowercase
s1LI = s1.lower()  # Invarient lowercase does not exist in Python, using standard lower
s1U = s1.upper()  # Standard uppercase
s1UI = s1.upper()  # Invariant uppercase does not exist in Python, using standard upper

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

# Output the string variants
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

# Comparing equality of strings
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

# Comparing strings lexicographically using locale settings
print('CompareStr')
print(locale.strcoll(s1, s2))
print(locale.strcoll(s1L, s2L))
print(locale.strcoll(s1U, s2U))
print(locale.strcoll(s1LI, s2LI))
print(locale.strcoll(s1UI, s2UI))
print(locale.strcoll(s1, s3))
print(locale.strcoll(s1L, s3L))
print(locale.strcoll(s1U, s3U))
print(locale.strcoll(s1LI, s3LI))
print(locale.strcoll(s1UI, s3UI))

# Comparing strings in a case-insensitive manner
print('CompareText')
print(locale.strcoll(s1.lower(), s2.lower()))
print(locale.strcoll(s1L.lower(), s2L.lower()))
print(locale.strcoll(s1U.lower(), s2U.lower()))
print(locale.strcoll(s1LI.lower(), s2LI.lower()))
print(locale.strcoll(s1UI.lower(), s2UI.lower()))
print(locale.strcoll(s1.lower(), s3.lower()))
print(locale.strcoll(s1L.lower(), s3L.lower()))
print(locale.strcoll(s1U.lower(), s3U.lower()))
print(locale.strcoll(s1LI.lower(), s3LI.lower()))
print(locale.strcoll(s1UI.lower(), s3UI.lower()))

input()  # Pauses the console window until a key is pressed