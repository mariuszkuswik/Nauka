
# Linux/Bash

## System Linux 

### Pytania pod rozmowę 
- Jakie znam filesystemy na linuxie, czym się charakteryzują  
	- ext2, ext3, ext4, xfs, btrfs
	- Upenić się czy jest to ok 
- jakie znam katalogi linuxowe, za co odpowiadają 
- gdzie przechowywane sa logi 
- gdzie przechowywane są pliki konfiguracyjne 
- jak dziala . ./script_name.sh
	- sourcowanie plikow, skrypt wykona się i zaciągnięte zostaną z niego wartości
	- Sprawdzić czy coś dopisać  
- jakie znam rodzaje RAIDa, na czym polegają



## Skryptowanie 

## Zmienne specjalne


- **$?** - wynik ostatniej komendy 
_( najczesciej  0/2 - 0 to komenda wykonana prawidlowo, wszystko inne to blad, nie musi byc to 2, liczba moze byc nawet ujemna )_
- **$$** - numer procesu używanego przez komende
- **!$** - ostatni użyty argument 
- **$0** - nazwa programu 
- **$1** - argumenty, zaczynaja sie od jednego, nie musi byc to jeden 
- **$#** - liczba argumentow 
- **$*** - wszystkie argumenty jako string 
- **$@** - argumenty w postaci tablicy 




### Exitcode
**Dodawanie innych exit kodow pomaga uzytkownikom**
* Exitcode wieksze niz 0 mozemy definiowac sami 
* Exitcode 0 - kod wykonany prawidlowo 
* Exitcode 1 i kazdy wiekszy - kod wykonany z bledem 

 

**Do poprawienia**
- Dodać jakąs informację na temat **elif** 


### Automatyczne tworzenie użytkownika 

```bash
# Jeżeli liczba podanych argumentow jest mniejsza niz 1 to 
if [ "$#" -lt 1 ]
then
   echo "You must provide the username: $0 <username>"
   exit 1

# If sam sprawdzi czy komenda wykonala sie poprawnie 
elif getent passwd "$1" 
then 
   echo "The username "$1" already exists on this system" 
   exit 2 
fi

```

###  Odczytanie danych podanych przez użytkownika
* -s = secret, ukrywa znaki wpisywane przez użytkownika 
* -p <Tekst dla uzytkownika\> = prompt, tekst dla uzytkownika 
 
```bash
read -s -p "Enter a password for the new user "$1": " USER_PASSWORD
```

## Funkcje 
Return - Zwraca wartos funkcji

# Sieci 

Jak działa routing i maska podsieci 
Wyświetl karty sieciowe w linuxie, opisz czego się na tej podstawie dowiedziałeś

# Wirtualizacja 

Czym jest wirtualizacja  
Sprawdź czy maszyna na której jesteź jest maszyną wirtualną 

