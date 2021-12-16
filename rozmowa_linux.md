### TODO - Ukryć odpowiedzi na pytania pod rozwijaną listą 

# Pytania na rozmowę 
- Nauczyc sie iptables i znalezc do niego jakies pytania 
- Jak działa firewall 
	- ### #TODO - do uzupełnienia 
	- firewall-cmd jest frontendowym klientem, pod spodem jest obecnie nftables, wcześniej było to iptables 
- Czym rozni sie TCP od UDP
- 	- [Podstawy sieci + opis TCP i UDP](https://newsblog.pl/czym-one-sa-roznica-miedzy-protokolem-tcp-i-udp/)
	- Działanie TCP oferuje coś w rodzaju potwierdzenia zwrotnego, że połączenie zostało nawiązane oraz wysyła dane w sesji pomiędzy dwoma węzłami. ... UDP to również protokół w warstwie transportowej, ale nie wymaga handshake'a ani potwierdzenia o otrzymaniu danych. 
- Jak wyświetlić tablicę routingu
	- ip route 
- Jak sprawdzić porty otwarte na lokalnej maszynie 
	- ```netstat``` 
	- ```netstat -a``` - wyświetla wszystkie porty
	- ```netstat -l``` - wyświetla nasłuchujące porty  
- Jak przeskanować porty zdalnej maszyny 
	- ```nmap```
- Na serwerze zdalnym mam aplikację apache ale nie jestem w stanie wyświetlić strony hostowanej przez nią, jak zdiagnozowac problem 
- Jak wyświetlić karty sieciowe 
	- ip a 
- Jak działą routing 
- Jak zwrócić wartość funkcji 
	- return 
- Exitcode z instrukcji Bash, wypisac czym jest
- Wypisac zmienne specjalne z instrukcji bash 
	- $? - wynik ostatniej komendy ( najczesciej 0/2 - 0 to komenda wykonana prawidlowo, wszystko inne to blad, nie musi byc to 2, liczba moze byc nawet ujemna )  
	$$ - numer procesu używanego przez komende   
	!$ - ostatni użyty argument  
	$0 - nazwa programu  
	$1 - argumenty, zaczynaja sie od jednego, nie musi byc to jeden  
	$# - liczba argumentow  
	$* - wszystkie argumenty jako string  
	$@ - argumenty w postaci tablicy  
	[Instrukcja](https://github.com/mariuszkuswik/Nauka/blob/main/Linux/Linux.md#zmienne-specjalne)  
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
	- whereis
- Grep po wszystkich katalogach w psozukiwaniu stringa wewnątrz pliku 
	- grep -R "string" sciezka docelowa ?
- Czym jest wirtualizacja  

- Sprawdź czy maszyna na której jesteś jest maszyną wirtualną 
	- lscpu, wyświetla to czy maszyna jest wirtualizowana 
- Czym jest konteneryzacja 
	- 
- Przykładowe shelle 
	- bash 
	- zsh 
	- fish 
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
- Jak dzialaja klamrowe nawiasy w bashu 
- Jakie znam filesystemy na linuxie, czym się charakteryzują
	- ext2, ext3, ext4, xfs, btrfs, bfs
- Jakie znam katalogi linuxowe, za co odpowiadają
	- /boot - pliki niezbędne do uruchomienia systemu (kernel, initrd, pliki bootloadera - w przypadku GRUB)
	- /etc - pliki konfiguracyjne, ustawienia systemowe
	- /home - pliki określające ustawienia każdego użytkownika + ich pliki  
	- /proc - wirtualny katalog, zawierający dane o aktualnie uruchomionych procesach
	- /tmp - pliki tymczasowe
- Gdzie przechowywane sa logi
- Gdzie przechowywane są pliki konfiguracyjne
- Jakie znam rodzaje RAIDa, na czym polegają
