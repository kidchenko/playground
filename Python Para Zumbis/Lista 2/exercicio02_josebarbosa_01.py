a = int(input('Digite o primeiro lado do triangulo: '))
b = int(input('Digite o segundo lado do triangulo: '))
c = int(input('Digite o terceiro lado do triangulo: '))

if a > b + c or b > b + c or c > a + b:
    print('Nao e um triangulo')
else:
    if a == b == c:
        print('Equilatero')
    elif a == b or b == c or a == c:
        print('Isosceles')
    else:
        print('Escaleno')
