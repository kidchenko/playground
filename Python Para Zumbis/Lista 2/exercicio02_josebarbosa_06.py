valor = float(input('Digite o quanto voce ganha por hora: '))
horas = float(input('Digite o quantas horas voce trabalha por mes: '))
bruto = valor * horas
ir = bruto * 0.11
inss = bruto * 0.08
sindicato = bruto * 0.05

print('Salario Bruto: %.2f' % bruto)
print('IR: %.2f' % ir)
print('INSS: %.2f' % inss)
print('Sindicato: %.2f' % sindicato)
print('Salario Liquido %.2f' % (bruto - ir - inss - sindicato))


