def euclides(dividendo, divisor):
    resto = dividendo % divisor
    if resto == 0:
        return divisor
    else:
        return euclides(divisor, resto)

print(euclides(15, 10))
print(euclides(1128, 336))
print(euclides(348, 156))
