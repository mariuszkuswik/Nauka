#!/bin/python3

def sito_eratostenesa(n):
    # Tworzymy listę liczb od 2 do n
    numbers = [i for i in range(2, n+1)]
    primes = []
    twins_triplets = []
    for i in numbers:
        if i != -1:
            primes.append(i)
            for j in range(i*i, n+1, i):
                numbers[j-2] = -1
            if i+2 in numbers:
                twins_triplets.append((i,i+2))
            if i+6 in numbers:
                twins_triplets.append((i,i+6))
    return primes, twins_triplets

n = int(input("Podaj górną granicę: "))
primes, twins_triplets = sito_eratostenesa(n)
print("Liczby pierwsze:", primes)
print("Bliźniaki i trojaczki pierwszych:", twins_triplets)
