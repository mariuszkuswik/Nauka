# Linki ważne
- [Wstęp do programowania w C# pdf](http://c-sharp.ue.katowice.pl/ksiazka/c_sharp_wer2_0.pdf)  
Aktualna strona : 87
- [Link Codecademy](https://www.codecademy.com/courses/learn-c-sharp/projects/csharp-password-checker)

# Spis treści 
- [Koniec](#koniec)

1. [Pętle](#pętle)
    - [Pętla for](#pętla-for)
    - [Pętle while i do while](#pętle-while-i-do-while)



# Wstęp
Jeżeli instrukcja (np. dla if lub pętli) nie jest umieszczona w klamrach to wykona się pierwsza następująca po niej linia 

# Pętle
[Go top](#spis-treści)

[Skrócony opis wszystkich pętli](http://c-sharp.ue.katowice.pl/ksiazka/c_sharp_wer2_0.pdf#page=203&zoom=100,90,94)

## Pętla for

- Ogólna budowa
```C#
for ([inicjalizacja]; [wyrażenie logiczne]; [iteracja])
{
    // ciało pętli (instrukcje)
}
```

- Przykład 

```C#
static void Main(string[] args)
{
    for (int i = 1; i < 10; i++)
    {
        Console.WriteLine(i);
    }
    Console.ReadKey();
}
```


## Pętle while i do while

### While
- Wykonuje się dopóki warunek jest spełniony, jeżeli nie jest od samego początku to nie wykona się

#### Ogólna budowa
```C#
while (wyrażenie logiczne)
{
    // ciało pętli (instrukcje)
}
```
#### Przykład 
```C#
static void Main(string[] args)
{
    int i = 0;
    while (i < 10)
    {
        Console.WriteLine(i);
        i++;
    }
    Console.ReadKey();
}
```
- Przykład 3.21. strona 77 
```C#
static void Main(string[] args)
{
    Console.WriteLine("Czas: {0}", DateTime.Now);
    Console.WriteLine("Ponownie pokazać aktualny czas? (t/n)");
    string odpowiedz = Console.ReadLine();
    while (odpowiedz != "n")
    {
        Console.WriteLine("Czas: {0}", DateTime.Now);
        Console.WriteLine("Ponownie pokazać aktualny czas? (t/n)");
        odpowiedz = Console.ReadLine();
    }
}

```

> Czas: 2017-07-17 20:21:24  
Ponownie pokazać aktualny czas? (t/n)  
t  
Czas: 2017-07-17 20:21:25  
Ponownie pokazać aktualny czas? (t/n)  
t  
Czas: 2017-07-17 20:21:27  
Ponownie pokazać aktualny czas? (t/n)  
t  
Czas: 2017-07-17 20:21:30  
Ponownie pokazać aktualny czas? (t/n)  
n  


---

### Do while
- Ciało pętli jest wykonywane dopóki wyrażenie logiczne ma wartość true. Wyrażenie logiczne sprawdzane jest po pierwszym przebiegu pętli **(czyli pętla wykona się przynajmniej raz)**.

#### Ogólna budowa
```C#
do
{
 // ciało pętli (instrukcje)
} while (wyrażenie logiczne);
```

#### Przykład 
```C#
static void Main(string[] args)
{
 string odpowiedz;
 do
    {
        Console.WriteLine("Czas: {0}", DateTime.Now);
        Console.WriteLine("Ponownie pokazać aktualny czas? (t/n)");
        odpowiedz = Console.ReadLine();

    } while (odpowiedz != "n");
}

```

## Break i continue

### Break
- W przypadku pętli zagnieżdżonych break przerywa działanie tylko tej w której jest umiejscowione - prawdopodobnie wewnętrznej?

#### Przykład

```C#
static void Main(string[] args)
{
    int a = 0;
    do
    {
        a++;
        if (a == 5)
        break;  // przerwij pętle
        Console.WriteLine(a);
    } while (true);
     Console.ReadKey();
}
```




### Continue 
- polecenie continue powoduje przerwanie
jedynie bieżącego przebiegu pętli (a nie działania całej pętli jak w przypadku break).

#### Przykład 3.26.
```C#
static void Main(string[] args)
{
    for (int i = 1; i <= 6; i++)
    {
        if (i == 4)
        continue; // pomiń dalsze instrukcje i wznów pętle
        Console.WriteLine(i);
    }
    Console.ReadKey();
}
```

## Foreach 

Pętla foreach jest przeznaczona dla kolekcji (np. tablicy). Ma tyle przebiegów, ile
jest elementów w kolekcji. Przy użyciu tej pętli nie można zmieniać elementów
kolekcji (są dostępne tylko „do odczytu”). 

#### Przykład (wypisanie na ekranie imion Ala, Ola, Ela, jedno pod drugim)

```C#
string[] imiona = { "Ala" , "Ola" , "Ela" };
foreach (string x in imiona)
    Console.WriteLine(x);
```




##### Koniec
[Go top](#spis-treści)

