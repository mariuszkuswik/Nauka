# Linki ważne
[Wstęp do programowania w C# pdf](http://c-sharp.ue.katowice.pl/ksiazka/c_sharp_wer2_0.pdf)

# Spis treści 
1. [Pętle](#pętle)
    - [Pętla for](#pętla-for)
    - [Pętle while i do while](#pętle-while-i-do-while)



# Wstęp

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
- Ogólna budowa
```C#
while (wyrażenie logiczne)
{
    // ciało pętli (instrukcje)
}
```
- Przykład 
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
- Przykład 3.21.
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



[Go top](#spis-treści)