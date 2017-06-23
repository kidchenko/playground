minutos = int(input('Digite quantos minutos de telefone voce usou:'))

valor = 0.15

if minutos < 200:
    valor = 0.20
elif minutos < 400:
    valor = 0.18
elif minutos > 800:
    valor = 0.08
print('O valor da conta de telefone e: %.2f' % (valor * minutos))
