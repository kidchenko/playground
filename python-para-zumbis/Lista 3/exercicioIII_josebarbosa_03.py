populacaoA = 8000
populacaoB = 20000
crescimentoA = 1.03   # crescimento de 3 % ao ano
crescimentoB = 1.015  # crescimento de 1.5 % ao ano
anos = 0

while populacaoA < populacaoB:
    populacaoA *= crescimentoA
    populacaoB *= crescimentoB
    print('A: ', populacaoA)
    print('B: ', populacaoB)
    anos += 1

print('A quantidade de anos para a populacao A passar a B: %d' % anos)
