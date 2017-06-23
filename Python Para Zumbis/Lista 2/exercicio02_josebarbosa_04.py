numero1 = float(input('Digite o primeiro numero: '))
numero2 = float(input('Digite o segundo numero: '))
numero3 = float(input('Digite o terceiro numero: '))

if numero2 < numero1 > numero3:
    print('O numero %d e maior' % numero1);
elif numero1 < numero2 > numero3:
    print('O numero %d e maior' % numero2);
elif numero2 < numero3 > numero1:
    print('O numero %d e maior' % numero3)
