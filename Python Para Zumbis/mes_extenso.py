meses = {1 : 'janeiro',
         2 : 'fevereiro',
         3 : 'marco',
         4 : 'abril',
         5 : 'maio',
         6 : 'junho',
         7 : 'julho',
         8 : 'agosto',
         9 : 'setembro',
         10 : 'outubro',
         11 : 'novembro',
         12 : 'dezembro'
        }
data = input('Digite uma data no formato dd/mm/aaaa: ').split('/')
mes = meses[int(data[1])]

print('%s de %s de %s' % (data[0], mes, data[2]))


