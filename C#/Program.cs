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
