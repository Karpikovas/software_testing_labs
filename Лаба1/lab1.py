def ReduceFraction(a, b):
    v = a
    g = b
    while v != 0 and g != 0:
        if v > g:
            v = v % v
        else:
            g = g % v

    if a == 0:
        c = v
        print(a // c, b // c)
    else:
        c = g
        print(a // c, b // c)

a = int(input())
b = int(input())

if a > 0 and b > 0:
    ReduceFraction(a, b)
else:
    print("error")
