

Console.WriteLine("Podaj pierwsza liczbe z przedzialu");
int userNumber1=int.Parse(Console.ReadLine());
Console.WriteLine("Podaj druga liczbe z przedzialu");
int userNumber2=int.Parse(Console.ReadLine());


while (userNumber1<=userNumber2)
{
    if (userNumber1 % 2 == 0)
    Console.WriteLine(userNumber1);

    userNumber1++;
}
