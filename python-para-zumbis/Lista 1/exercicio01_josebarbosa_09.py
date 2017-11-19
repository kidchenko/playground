kms = float(input('Digite os km percorridos: '))
dias = float(input('Quantidade de dias que o carro foi alugado: '))
preco = (dias * 60) + (0.15 * kms)

print('O valor total a ser pago e: %.2f' % preco)
