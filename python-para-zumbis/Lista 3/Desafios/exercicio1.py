resultado = 0
contador = 0

numero = int(input('Digite um numero: '))

while resultado < numero:
    resultado = (contador -2) * (contador -1) * contador
    if resultado == numero:
        print('O numero %d e triangular. %d x %d x %d = %d' % (numero, (contador -2), (contador - 1), contador, numero))
        break
    contador += 1

else:
    print('O numero %d nao e triangular')
