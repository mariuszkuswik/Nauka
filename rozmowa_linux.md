### TODO - Ukryć odpowiedzi na pytania pod rozwijaną listą 

# Pytania na rozmowę 
- Nauczyc sie iptables i znalezc do niego jakies pytania 
- Docker - pouczyć się 
- Puppet - pouczyć się 
- Automatyczne narzędzia do rotowania logów 
- Czym różnią się filesystemy między sobą, np xfs i ext4
- Jak dodać regułę do firewalla
- Gdzie znajduje się plik z użytkownikami w systemie 
- Jak dodać użytkownika - adduser i useradd - jak działa useradd
- Czym jest brama domyślna 
- Na serwerze zdalnym mam aplikację apache ale nie jestem w stanie wyświetlić strony hostowanej przez nią, jak zdiagnozowac problem 
- Exitcode z instrukcji Bash, wypisac czym jest
- Jak sprawdzić czy filesystem działa poprawnie, jak go naprawić 
- Czym są linki w linuxie, podaj różnice, kiedy ich używamy 
- Jak działa routing
- Gdzie przechowywane sa logi
- Gdzie przechowywane są pliki konfiguracyjne
- Jakie znam rodzaje RAIDa, na czym polegają
- Jak działają LVMy, czym są, jak je wyświetlić, jak rozszerzyć, czym jest volume group 
- Jak konfiguruje się firewalla, jak dodać nową regułę
- Jak skonfigurować NFS 
- Jak skonfigurować SAMBe
- Jaki jest proces bootowania systemu 
- Czym jest Kernel 
- Serwer jest zajeżdżany, w jaki sposób zdiagnozuję problem 
- Czym jest wirtualizacja  
- Ogarnac notatki z telefonu 
- Ogolnie sprawdzic jakie uprawnienia uniemozliwia usuniecie pliku 
- Czym jest konteneryzacja 
- Dlaczego przypisujemy zmienne sredowiskowe 
- Jak dzialaja klamrowe nawiasy w bashu 



- Jak stworzyć nowy branch w git od podstaw
	- Dodać do instrukcji Git https://www.atlassian.com/git/tutorials/using-branches/git-checkout
- Jak sprawdzić kto i kiedy dodał jakiś commit  
	- Dodać do instrukcji Git


- Jak działa firewall 

	- ### #TODO - do uzupełnienia 
	- firewall-cmd jest frontendowym klientem, pod spodem jest obecnie nftables, wcześniej było to iptables 






<!-- Lista z ogarniętymi pytaniami  -->
<ol>
	<li>
		<details> <summary>Czym rozni sie <b>TCP od UDP</b></summary>
			- Działanie TCP oferuje coś w rodzaju potwierdzenia zwrotnego, że połączenie zostało nawiązane oraz wysyła dane w sesji pomiędzy dwoma węzłami. ... UDP to również protokół w warstwie transportowej, ale nie wymaga handshake'a ani potwierdzenia o otrzymaniu danych. 
			<a href="https://newsblog.pl/czym-one-sa-roznica-miedzy-protokolem-tcp-i-udp/">Podstawy sieci + opis TCP i UDP</a>
		</details>  
	</li>
	<li>
		<details> <summary>Jak wyświetlić tablicę routingu </summary>
			- <code>ip route</code> 
		</details>  
	</li>
	<li>
		<details> <summary>Jak sprawdzić porty otwarte na lokalnej maszynie </summary>
			- <code>netstat</code> 
			- <code>netstat -a</code> - wyświetla wszystkie porty
			- <code>netstat -l</code> - wyświetla nasłuchujące porty  
		</details>  
	</li>
	<li>
		<details> <summary>Jak przeskanować porty zdalnej maszyny </summary>
			- <code>nmap</code>
		</details>  
	</li>
	<li>
		<details> <summary>Jak wyświetlić karty sieciowe </summary>
			- <code>ip a</code>
	</li>
	<li>
		<details> <summary>Jak zwrócić wartość funkcji </summary>
			- <code> return </code>
		</details>
	</li>
	<li>
		<details> <summary>- Wypisac zmienne specjalne z instrukcji bash </summary>				
				$? - wynik ostatniej komendy ( najczesciej 0/2 - 0 to komenda wykonana prawidlowo, wszystko inne to blad, nie musi byc to 2, liczba moze byc nawet ujemna )  
				$$ - numer procesu używanego przez komende   
				!$ - ostatni użyty argument  
				$0 - nazwa programu  
				$1 - argumenty, zaczynaja sie od jednego, nie musi byc to jeden  
				$# - liczba argumentow  
				$* - wszystkie argumenty jako string  
				$@ - argumenty w postaci tablicy  
				[Instrukcja](https://github.com/mariuszkuswik/Nauka/blob/main/Linux/Linux.md#zmienne-specjalne)  
		</details>
	</li>
	<li>
		<details> <summary>Do czego służy kropka w skryptach bashowych, jak działa source pliku </summary>
			- Zmienne ze skryptu zaciaganego rowniez zastana zaciagniete 
			- Zaciagany/sourcowany skrypt zostanie wykonany ( sprawdzic czy na pewno )
		</details>
	</li>
	<li>
		<details> <summary>- Co zwraca funkcja ? </summary>
			- Sama z siebie zwraca <b>exitcode</b>, domyslnie wartosc 0/1, żeby zwrócić coś więcej używamy <code>return</code>
		</details>
	</li>
	<li>
		<details> <summary>- Czym jest <b>VLAN</b></summary>
			- technologia sieciowa, która pozwala w ramach jednej fizycznej sieci lokalnej tworzyć wiele sieci logicznych (sieci wirtualnych)
		</details>
	</li>
	<li>
		<details> <summary>- Czym jest <b>GRUB</b>, jak przebiega proces bootowania systemu </summary>
			- boot manager,  który ładuje jądro Linuksa, jest to pierwsze oprogramowanie uruchamiane przy starcie systemu.
			[Czym jest grub + bootowanie](https://qa-stack.pl/ubuntu/347203/what-exactly-is-grub)
		</details>
	</li>
	<li>
		<details> <summary>- <b>shebang</b> - czym jest</summary>
			-  daje kontrole nad tym w jakim shellu zostanie wykonany skrypt, jezeli nie zostanie uzyty to skrypt wykona sie w obecnie uzywanym shellu 
		</details>
	</li>
	<li>
		<details> <summary>- Czym jest <b>export</b> a czym <b>env</b>, jak działają zmienne środowiskowe, jak je wypisać</summary>
			- <code>env</code> - wypisuje zmienne środowiskowe
			- <code>export</code> - tworzy zmienną środowiskową 	
		</details> 
	</li>
	<li>
		<details> <summary>- Jak sprawdzić biblioteki których nam brakuje </summary>
			- <code>ldd "sciezka docelowa komendy"</code>
		</details> 
	</li>
	<li>
		<details> <summary>- Czym jest <b>SWAP</b>, ile go potrzebujemy </summary>
			- Pamięć ulotna dostępna na dysku którą system może wykorzystywać, jej użycie jest zależne od stopnia swapiness, minimalna wielkość powinna być równa ilości RAM, ze względu na możliwość hibernacji 
		</details> 
	</li>
	<li>
		<details> <summary>- Jak sprawdzić gdzie jest zainstalowany dany program </summary>
			- <code>whereis</code>
		</details>
	</li>
	<li>
		<details> <summary>- Grep po wszystkich katalogach w psozukiwaniu stringa wewnątrz pliku </summary>
			- <code>grep -R "string" sciezka docelowa ?</code>
	</li>
	<li>
		<details> <summary>- Sprawdź czy maszyna na której jesteś jest maszyną wirtualną </summary>
			- lscpu, wyświetla to czy maszyna jest wirtualizowana 
	</li>
	<li>
		<details> <summary>- Przykładowe shelle </summary>
			- <code>bash</code> 
			- <code>zsh</code> 
			- <code>fish</code> 
		</details>
	</li>
	<li>
		<details> <summary>- Czym jest <b>sticky bit</b> ? </summary>
			- Na koniec komendy jak zmienić lub ustawić te specjalne bity. Do tego słuzy nam komenda chmod.
				<code>chmod o+s <nazwa pliku></code>
				<code>chmod g+s <nazwa katalogu></code>
				<code>chmod u+s <nazwa pliku></code>
		</details>
	</li>
	<li>
		<details> <summary>- Jak brzmią domyślne ustawienia uprawnień, jak je zmienić </summary>
			- <code>umask</code> - sprawdzic jak zmienic 
		</details>
	</li>
	<li>
		<details> <summary>- Jakie znam <b>filesystemy</b> na linuxie, czym się charakteryzują</summary>
			- <code>ext2</code>
			- <code>ext3</code>
			- <code>ext4</code>
			- <code>xfs</code>
			- <code>btrfs</code>
			- <code>bfs</code>
		</details>
	</li>
	<li>
		<details> <summary>- Jakie znam <b>katalogi linuxowe</b>, za co odpowiadają</summary>
			- /boot - pliki niezbędne do uruchomienia systemu (kernel, initrd, pliki bootloadera - w przypadku GRUB)
			- /etc - pliki konfiguracyjne, ustawienia systemowe
			- /home - pliki określające ustawienia każdego użytkownika + ich pliki  
			- /proc - wirtualny katalog, zawierający dane o aktualnie uruchomionych procesach
			- /tmp - pliki tymczasowe
		</details>
	</li>
</ol>

  

















