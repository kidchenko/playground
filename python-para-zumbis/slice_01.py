palavra = input('Digite uma palavra: ')

if palavra == palavra[::-1]:
    print('A palavra "%s" � palindrome' % palavra) #palavra invertida igual
else:
    print('A palavra "%s" nao e palindrome' % palavra) 
