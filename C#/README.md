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



[Go top](#spis-treści)