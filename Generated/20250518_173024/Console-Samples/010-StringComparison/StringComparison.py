import sys

def main():
    try:
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

        # Input blocking for console interaction similar to readln
        input()

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
        print((lambda x,y: (x > y) - (x < y))(s1, s2))
        print((lambda x,y: (x > y) - (x < y))(s1L, s2L))
        print((lambda x,y: (x > y) - (x < y))(s1U, s2U))
        print((lambda x,y: (x > y) - (x < y))(s1LI, s2LI))
        print((lambda x,y: (x > y) - (x < y))(s1UI, s2UI))
        print((lambda x,y: (x > y) - (x < y))(s1, s3))
        print((lambda x,y: (x > y) - (x < y))(s1L, s3L))
        print((lambda x,y: (x > y) - (x < y))(s1U, s3U))
        print((lambda x,y: (x > y) - (x < y))(s1LI, s3LI))
        print((lambda x,y: (x > y) - (x < y))(s1UI, s3UI))

        print('CompareText')
        comparison = lambda x, y: (x.lower() > y.lower()) - (x.lower() < y.lower())
        print(comparison(s1, s2))
        print(comparison(s1L, s2L))
        print(comparison(s1U, s2U))
        print(comparison(s1LI, s2LI))
        print(comparison(s1UI, s2UI))
        print(comparison(s1, s3))
        print(comparison(s1L, s3L))
        print(comparison(s1U, s3U))
        print(comparison(s1LI, s3LI))
        print(comparison(s1UI, s3UI))

        input()  # Final read to mimic readln behavior
    except Exception as E:
        print(E.__class__.__name__ + ': ' + str(E))

if __name__ == "__main__":
    main()