# Pytania na rozmowę 
- Czym rozni sie TCP od UDP
	- 
- Jak wyświetlić tablicę routingu 
- Jak sprawdzić porty otwarte na lokalnej maszynie 
- Jak przeskanować porty zdalnej maszyny 
- Na serwerze zdalnym mam aplikację apache ale nie jestem w stanie wyświetlić strony hostowanej przez nią, jak zdiagnozowac problem 
- Jak wyświetlić karty sieciowe 
- Jak działą routing 
- Jak zwrócić wartość funkcji 
	- return 
- Exitcode z instrukcji Bash, wypisac czym jest
- Wypisac zmienne specjalne z instrukcji bash 
- Do czego służy kropka w skryptach bashowych, jak działa source pliku 
	- Czy zmienne ze skryptu zaciaganego zastana zaciagniete ? - Wydaje mi sie ze tak
	- Czy skrypt zostanie wykonany - mysle ze tak 
- Co zwraca funkcja ? 
	- Sama z siebie zwraca exitcode, domyslnie wartosc 0/1  
- Czym jest VLAN
- Czym jest GRUB, jak przebiega proces bootowania systemu 
	- 
- Jak sprawdzić czy filesystem działa poprawnie, jak go naprawić 
	- 
- shebang - czym jest
	-  daje kontrole nad tym w jakim shellu zostanie wykonany skrypt, jezeli nie zostanie uzyty to skrypt wykona sie w obecnie uzywanym shellu 
- Czym różnie się TCP od UDP 
	- Działanie TCP oferuje coś w rodzaju potwierdzenia zwrotnego, że połączenie zostało nawiązane oraz wysyła dane w sesji pomiędzy dwoma węzłami. UDP to również protokół w warstwie transportowej, ale nie wymaga potwierdzenia o otrzymaniu danych
- Czym jest export a czym env, jak działają zmienne środowiskowe, jak je wypisać
	- env - Wypisuje zmienne środowiskowe, export tworzy zmienną środowiskową 	
- Jak stworzyć nowy branch w git od podstaw
	- Dodać do instrukcji Git https://www.atlassian.com/git/tutorials/using-branches/git-checkout
- Jak sprawdzić kto i kiedy dodał jakiś commit  
	- Dodać do instrukcji Git
- Jak sprawdzić biblioteki których nam brakuje 
	- ldd "sciezka docelowa komendy"
- Czym jest SWAP, ile go potrzebujemy 
	- Pamięć ulotna dostępna na dysku którą system może wykorzystywać, jej użycie jest zależne od stopnia swapiness, minimalna wielkość powinna być równa ilości RAM, ze względu na możliwość hibernacji 
- Czym są linki w linuxie, podaj różnice, kiedy ich używamy 
	- 	
- Jak sprawdzić gdzie jest zainstalowany dany program 
	- whereis ?
- Grep po wszystkich katalogach w psozukiwaniu stringa wewnątrz pliku 
	- grep -R "string" sciezka docelowa ?

- Czym jest wirtualizacja  

- Sprawdź czy maszyna na której jesteś jest maszyną wirtualną 
	- lscpu, wyświetla to czy maszyna jest wirtualizowana 
- Czym jest konteneryzacja 
	- 

- Przykładowe shelle 
- Czym jest sticky bit ? 
	- Na koniec komendy jak zmienić lub ustawić te specjalne bity. Do tego słuzy nam komenda chmod.

		```chmod o+s <nazwa pliku>```

		```chmod g+s <nazwa katalogu>```

		```chmod u+s <nazwa pliku>```

- Jak brzmią domyślne ustawienia uprawnień, jak je zmienić 
	- umask - sprawdzic jak zmienic 
- Ogolnie sprawdzic jakie uprawnienia uniemozliwia usuniecie pliku 
Ogarnac notatki z telefonu 
- Dlaczego przypisujemy zmienne sredowiskowe 
- Jak dzialaja klamrowe nawiasy 

