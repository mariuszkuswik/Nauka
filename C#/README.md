# Linki ważne
[Wstęp do programowania w C# pdf](http://c-sharp.ue.katowice.pl/ksiazka/c_sharp_wer2_0.pdf)  
Aktualna strona : 80

# Spis treści 
- [Koniec](#koniec)

1. [Pętle](#pętle)
    - [Pętla for](#pętla-for)
    - [Pętle while i do while](#pętle-while-i-do-while)



# Wstęp
Jeżeli instrukcja (np. dla if lub pętli) nie jest umieszczona w klamrach to wykona się pierwsza następująca po niej linia 

# Pętle
[Go top](#spis-treści)

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
- Wykona się minimum raz, później dopóki warunek jest spełniony

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





#### Przykład


##### Koniec
[Go top](#spis-treści)

