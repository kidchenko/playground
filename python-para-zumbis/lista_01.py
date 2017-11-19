cont = 0
letras = []
while cont < 3:
    letras.append(input('Digite uma letra: ')[0])
    cont += 1
print(len([letra for letra in letras if letra not in 'aeiou']))
