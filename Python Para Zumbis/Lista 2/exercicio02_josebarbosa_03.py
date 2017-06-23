peso = float(input('Digite o peso de peixes: '))
excesso = 0
multa = 0

if peso > 50:
    excesso = peso - 50
    multa = 4 * excesso

print('Peso: %.2f' % peso)
print('Excesso: %.2f' % excesso)
print('Multa: %.2f' % multa)
