velocidade = int(input('Digite a velocidade do carro: '))
if velocidade > 110:
    print('Voce foi multado em %.2f R$' % ((velocidade - 110) * 5))
