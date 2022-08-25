<<<<<<< HEAD
﻿int minLength=8;
bool uppercase=true;
bool lowercase=true;
int digits=10;
bool specialChars=true;

int score=0;
      
Console.WriteLine("Podaj bezpieczne haslo");
string password=Console.ReadLine();

// if ()
=======
using System;

namespace PasswordChecker
{
  class Program
  {
    public static void Main(string[] args)
    {
      int minLength=8;
      bool uppercase=true;
      bool lowercase=true;
      int digits=10;
      bool specialChars=true;

      Console.WriteLine("Podaj bezpieczne haslo");
      string password=Console.ReadLine();

      if (password.Length < minLength )
      {
        Console.WriteLine("Haslo jest za krotkie");
      }
      else
      {
        Console.WriteLine("haslo jest poprawnej dlugosci");
      }
    }
  }
}
>>>>>>> 8673ea0ab1e35fb7722d567c80a6879653ca3cdf
