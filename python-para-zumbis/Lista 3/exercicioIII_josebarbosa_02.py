nome = senha = ''
nome = input('Digite seu nome: ')
senha = input('Digite sua senha: ')
while nome == senha:
    print('Erro. O nome nao pode ser igual a senha.')
    nome = input('Digite seu nome: ')
    senha = input('Digite sua senha: ')
