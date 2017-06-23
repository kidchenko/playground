atual = 1
anterior = 0
passo = 1

n = int(input('Digite o numero da posicao de Fibonacci: '))

while passo < n:
    proximo = atual + anterior
    anterior = atual
    atual = proximo
    passo += 1

print(atual)


