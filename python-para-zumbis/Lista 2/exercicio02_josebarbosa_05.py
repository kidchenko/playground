numeros = []
numeros.append(int(input('Digite o primeiro numero: ')))
numeros.append(int(input('Digite o segundo numero: ')))
numeros.append(int(input('Digite o terceiro numero: ')))
maior = numeros[0]
menor = numeros[0]


for numero in numeros:
    if numero > maior:
        maior = numero
        continue
    if numero < menor:
        menor = numero
print('Maior: %d ' % maior)
print('Menor: %d ' % menor)
    
