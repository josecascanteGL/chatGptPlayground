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
print(cmp_to_key(compare)(s1, s2))
print(cmp_to_key(compare)(s1L, s2L))
print(cmp_to_key(compare)(s1U, s2U))
print(cmp_to_key(compare)(s1LI, s2LI)
print(cmp_to_key(compare)(s1UI, s2UI)
print(cmp_to_key(compare)(s1, s3))
print(cmp_to_key(compare)(s1L, s3L))
print(cmp_to_key(compare)(s1U, s3U)
print(cmp_to_key(compare)(s1LI, s3LI)
print(cmp_to_key(compare)(s1UI, s3UI)

print('CompareText')
print(cmp_to_key(compare)(s1, s2))
print(cmp_to_key(compare)(s1L, s2L))
print(cmp_to_key(compare)(s1U, s2U))
print(cmp_to_key(compare)(s1LI, s2LI)
print(cmp_to_key(compare)(s1UI, s2UI)
print(cmp_to_key(compare)(s1, s3))
print(cmp_to_key(compare)(s1L, s3L))
print(cmp_to_key(compare)(s1U, s3U)
print(cmp_to_key(compare)(s1LI, s3LI)
print(cmp_to_key(compare)(s1UI, s3UI)

input()