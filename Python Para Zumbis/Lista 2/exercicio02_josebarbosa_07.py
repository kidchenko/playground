metros = float(input('Digite a quantidade de metros quadrado a ser pintada: '))
valor = 80.00
litros = metros / 3

if litros % 18 == 0:
    print('Voce precisara de %d lata(s) de tinta e %.2f reais' % 
            ((litros / 18), ((litros / 18) * valor)))
else:
    print('Voce precisara de %d lata(s) de tinta e %.2f reais' % 
            ((litros / 18) + 1, (int(litros / 18) + 1) * valor))
