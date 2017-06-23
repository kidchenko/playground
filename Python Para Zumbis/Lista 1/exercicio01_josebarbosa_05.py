mercadoria = float(input('Digite o valor da mercadoria: '))
desconto = float(input('Digite a porcentagem do desconto: '))
precoComDesconto = mercadoria - ((mercadoria * desconto) / 100)

print ('O valor do desconto foi de: %.2f' % (mercadoria - precoComDesconto))
print ('O valor da mercadoria com o desconto e: %.2f' % precoComDesconto)

