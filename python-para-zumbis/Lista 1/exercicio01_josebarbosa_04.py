salario = float(input('Digite o valor do salario: '))
porcentagem = float(input('Digite a porcentagem do aumento: '))
novoSalario = salario + ((salario * porcentagem) / 100)

print ('O valor do aumento foi de: %.2f' % novoSalario - salario)
print ('O valor do salario com o aumento e: %.2f' % novoSalario)

