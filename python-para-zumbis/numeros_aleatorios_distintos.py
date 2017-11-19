import random

numeros = []
while len(numeros) < 15:
    numero = random.randint(10, 100)
    if numero not in numeros:
        numeros.append(numero)

print(numeros)
