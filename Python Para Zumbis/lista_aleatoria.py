import random
def embaralha(texto):
    lista = list(texto)
    random.shuffle(lista)
    return lista
   

texto = input('Digite um texto: ')
print(embaralha(texto))
