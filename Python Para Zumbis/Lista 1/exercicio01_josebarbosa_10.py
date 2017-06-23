cigarros = int(input('Quantos cigarros voce fuma por dia: '))
anos = int(input('Quantos anos voce ja fumou: '))

totalCigarros = cigarros * anos * 365

#cada cigarro - 10 minutos de vida

minutosPerdidos = totalCigarros * 10

#1 dia = 24 horas ou 1440 minutos

diasPerdidos = minutosPerdidos / 1440

print('Por causa do cigarro voce ja perdeu %d dias de vida.' % diasPerdidos)
