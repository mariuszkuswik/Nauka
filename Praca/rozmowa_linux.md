# Spis treści 

- [Atos - Linux z pythonem](#atos---linux-z-pythonem)
	- [Pytania ktore byly](#pytania-ktore-były-ostatnio)
	- [Potencjalne pytania](#potencjalne-pytania)
- [Co opisac](#co-opisac)
- [Czego się uczyc](#czego-się-uczyc)
- [Pytania do uzupełnienia](#pytania-do-uzupełnienia)
- [Pytania na rozmowe](#pytania-na-rozmowę)



# Atos - Linux z pythonem

## Spis treści
- [NFS - jak skonfigurowac](#nfs---jak-skonfigurowac)
- [Samba - jak skonfigurowac](#samba---jak-skonfigurowac)
- [Logi](#logi)
	- [Gdzie znalezc logi](#gdzie-znalezc-logi)
	- [Logrotate](#logrotate)
- [LVM - jak dziala, cos tam, procedura](#Lvm)
- [Git](#git)
- [Sieci](#sieci)
- [Pomoc](#pomoc)




# Tematy
## Logi
### Gdzie znalezc logi
- ```/var/log``` - folder z logami  
	- ```/var/log/messages``` - główny plik z logami  
  
### Logrotate
- [Log rotate opisany](https://www.tecmint.com/install-logrotate-to-manage-log-rotation-in-linux/)
- [Plural - lab z logami](https://app.pluralsight.com/labs/play/65c22f76-5118-44a8-a8de-871e2061488a/task/1)
- [Plural - logi wyjasnione by Andrew Mallet ](https://app.pluralsight.com/course-player?clipId=0cc96a45-0ee8-4ff2-93ae-06247c6c3bfc)
- Gdzie przechowywane sa logi

## NFS - jak skonfigurowac 
1. Pobranie nfs-utils?
1. Uruchomienie uslugi nfs-server.service
1. Dodanie wpisu do /etc/exports
1. Otwarcire portu na firewall - sprawdzic jaki port


## Samba - jak skonfigurowac 
1. Pobranie smb?
1. Uruchomienie uslugi 
1. Dodanie udzialu do /etc/smb/smbd.conf?
	- sprawdzic jak ma wygladac config
1. Odblokowanie portu na firewall
1. Restart uslugi


## Git 
### Branch - jak dodac nowy
- Dodac do instrukcji Git https://www.atlassian.com/git/tutorials/using-branches/git-checkout
- Jak sprawdzic kto i kiedy dodał jakiś commit  
## LVM 
- ### Jak dodać LVM - procedura
## Bash 
- Co zwraca funkcja - Sama z siebie zwraca 0/1, jeżeli chcemy zwrócić coś konkretnego to używamy return
## Sieci
- Selenium - webdriver, klikanie w przegladarce
- BeautifulSoup - parsowanie htmla
- Pandas - ekstraktowanie csv


### Firewall
- Jak dodać regułę do firewalla
- firewall-cmd jest frontendowym klientem, pod spodem jest obecnie nftables, wcześniej było to iptables 
- Jak działa firewall 
- Nauczyc sie iptables i znalezc do niego jakies pytania

### TCP i UDP
- czym są TCP i UDP, opisać mniej więcej
- różnice pomiędzy TCP i UDP 

### Routing
- czym jest routing, jak działa, opisać
- Wyświetl tablicę routingu i opowiedz o niej, opisać jak zadziała

## Pomoc 
- Dokumentacja/pomoc w linuxie
	- man 
	- /usr/share/doc

## Randomowe pytania
- Czym jest SWAP, ile go potrzeba
	- SWAP to SWAP
- Różnica między hard a soft linkiem
	- odpowiedzieć na pytanie
	- ```ln -s``` - tworzenie soft linka?
	- hard link jest tworzony domyślnie?
- Print information about users who are currently logged in
	- who 
- Wymień znane Ci filesystemy, czym się charakteryzują/różnią
	- btrfs
	- nfs?
	- ext3,4
	- xfs
- Gdzie znajduje się plik z użytkownikami w systemie
	- /etc/passwd
- Jak dodać użytkownika 
	- adduser i useradd
		- opisać ocpje useradd
	- domyślne opcje dla useradd znajdują się w pliku /etc/defaults/useradd?
		- dopisać jeszcze jeden plik w którym można zmieniać ustawienia domyślne


# Czego się uczyc
- KVM 
- Automatyczne narzędzia do rotowania logów
- Ansible 
- Puppet
- Docker
	


# Pytania do uzupełnienia 
<ol>
	<li>
		<details> <summary>	- Na serwerze zdalnym mam aplikację apache ale nie jestem w stanie wyświetlic strony hostowanej przez nią, jak zdiagnozowac problem </summary>
			Tekst
		</details>
	</li>
	<li>
		<details> <summary>	- Exitcode z instrukcji Bash, wypisac czym jest</summary>
			Tekst
		</details>
	</li>
	<li>
		<details> <summary>	- Jak sprawdzic czy filesystem działa poprawnie, jak go naprawic </summary>
			fsck."$filesystem"
		</details>
	</li>
	<li>
		<details> <summary>	- Czym są linki w linuxie, podaj różnice, kiedy ich używamy </summary>
			Tekst
		</details>
	</li>
	<li>
		<details> <summary>	- Jak działa routing</summary>
			Tekst
		</details>
	</li>
	<li>
		<details> <summary>	- Gdzie przechowywane są pliki konfiguracyjne</summary>
			/etc
		</details>
	</li>
	<li>
		<details> <summary>	- Jakie znam rodzaje RAIDa, na czym polegają</summary>
			Tekst
		</details>
	</li>
	<li>
		<details> <summary>	- Jak działają LVMy, czym są, jak je wyświetlic, jak rozszerzyc, czym jest volume group </summary>
			lvm 
			lslvm - wyświela lvm
			rozszerzenie lvm :
				- rozszerzenie partycji lvm w wirtualizatorze
				- <code>partprobe</code> - sprawdza 
		</details>
	</li>
	<li>
		<details> <summary>	- Jak konfiguruje się firewalla, jak dodac nową regułę</summary>
			Tekst
		</details>
	</li>
	<li>
		<details> <summary>	- Jak skonfigurowac NFS </summary>
			Tekst
		</details>
	</li>
	<li>
		<details> <summary>	- Jak skonfigurowac SAMBe</summary>
			Tekst
		</details>
	</li>
	<li>
		<details> <summary>	- Jaki jest proces bootowania systemu </summary>
			Tekst
		</details>
	</li>
	<li>
		<details> <summary>	- Czym jest Kernel </summary>
				Tekst	
		</details>
	</li>
	<li>
		<details> <summary>	- Serwer jest zajeżdżany, w jaki sposób zdiagnozuję problem </summary>
				Tekst
		</details>
	</li>
	<li>
		<details> <summary>	- Czym jest wirtualizacja  </summary>
				Tekst
		</details>
	</li>
	<li>
		<details> <summary>	- Ogolnie sprawdzic jakie uprawnienia uniemozliwia usuniecie pliku </summary>
				Tekst
		</details>
	</li>
	<li>
		<details> <summary>	- Czym jest konteneryzacja </summary>
				Tekst
		</details>
	</li>
	<li>
		<details> <summary>	- Dlaczego przypisujemy zmienne sredowiskowe </summary>
				Tekst
		</details>
	</li>
	<li>
		<details> <summary>	- Jak dzialaja klamrowe nawiasy w bashu </summary>
				Tekst
		</details>
	</li>
	<li>
		<details> <summary>	- Jak ustawic statyczne ip dla maszyny</summary>
				Tekst
		</details>
	</li>
</ol>


# Pytania na rozmowę 

<!-- Lista z ogarniętymi pytaniami  -->
<ol>
	<li>
		<details> <summary class="sieci">Czym jest brama domyślna </summary>
			- W sieci TCP/IP domyślna brama (sieciowa) (ang. default gateway) oznacza router, do którego komputery sieci lokalnej mają wysyłac pakiety o ile nie powinny byc one kierowane w siec lokalną lub do innych, znanych im routerów.
		</details> 
	</li>
	<li>
		<details> <summary class="sieci">Czym rozni sie <b>TCP od UDP</b></summary>
			- Działanie TCP oferuje coś w rodzaju potwierdzenia zwrotnego, że połączenie zostało nawiązane oraz wysyła dane w sesji pomiędzy dwoma węzłami. ... UDP to również protokół w warstwie transportowej, ale nie wymaga handshake'a ani potwierdzenia o otrzymaniu danych. 
			<a href="https://newsblog.pl/czym-one-sa-roznica-miedzy-protokolem-tcp-i-udp/">Podstawy sieci + opis TCP i UDP</a>
		</details>  
	</li>
	<li>
		<details> <summary class="sieci">Jak wyświetlic tablicę routingu </summary>
			- <code>ip route</code>   
		</details>  
	</li>
	<li>
		<details> <summary class="linux sieci">Jak sprawdzic porty otwarte na lokalnej maszynie </summary>
			- <code>netstat</code>  </br>
			- <code>netstat -a</code> - wyświetla wszystkie porty  </br>
			- <code>netstat -l</code> - wyświetla nasłuchujące porty   </br>
		</details>  
	</li>
	<li>
		<details> <summary class="linux sieci">Jak przeskanowac porty zdalnej maszyny </summary>
			- <code>nmap</code>
		</details>  
	</li>
	<li>
		<details> <summary class="linux sieci">Jak wyświetlic karty sieciowe </summary>
			- <code>ip a</code>
	</li>
	<li>
		<details> <summary class="linux bash">Jak zwrócic wartośc funkcji </summary>
			- <code> return </code>
		</details>
	</li>
	<li>
		<details> <summary>- Wypisac zmienne specjalne z instrukcji bash </summary>				
				<code>$?</code> - wynik ostatniej komendy ( najczesciej 0/2 - 0 to komenda wykonana prawidlowo, wszystko inne to blad, nie musi byc to 2, liczba moze byc nawet ujemna )   </br>
				<code>$$</code> - numer procesu używanego przez komende   </br>
				<code>!$</code> - ostatni użyty argument  </br>
				<code>$0</code> - nazwa programu  </br>
				<code>$1</code> - argumenty, zaczynaja sie od jednego, nie musi byc to jeden  </br>
				<code>$#</code> - liczba argumentow  </br>
				<code>$*</code> - wszystkie argumenty jako string  </br>
				<code>$@</code> - argumenty w postaci tablicy  </br>
				<a href="https://github.com/mariuszkuswik/Nauka/blob/main/Linux/Linux.md#zmienne-specjalne">Instrukcja z mojego githuba</a>
		</details>
	</li>
	<li>
		<details> <summary>Do czego służy kropka w skryptach bashowych, jak działa source pliku </summary>
			- Zmienne ze skryptu zaciaganego rowniez zastana zaciagniete  </br>
			- Zaciagany/sourcowany skrypt zostanie wykonany ( sprawdzic czy na pewno )  </br>
		</details>
	</li>
	<li>
		<details> <summary>- Co zwraca funkcja ? </summary>
			- Sama z siebie zwraca <b>exitcode</b>, domyslnie wartosc 0/1, żeby zwrócic coś więcej używamy <code>return</code>
		</details>
	</li>
	<li>
		<details> <summary>- Czym jest <b>VLAN</b></summary>
			- technologia sieciowa, która pozwala w ramach jednej fizycznej sieci lokalnej tworzyc wiele sieci logicznych (sieci wirtualnych)
		</details>
	</li>
	<li>
		<details> <summary>- Czym jest <b>GRUB</b>, jak przebiega proces bootowania systemu </summary>
			- boot manager,  który ładuje jądro Linuksa, jest to pierwsze oprogramowanie uruchamiane przy starcie systemu.  </br>
			[Czym jest grub + bootowanie](https://qa-stack.pl/ubuntu/347203/what-exactly-is-grub)
		</details>
	</li>
	<li>
		<details> <summary>- <b>shebang</b> - czym jest</summary>
			-  daje kontrole nad tym w jakim shellu zostanie wykonany skrypt, jezeli nie zostanie uzyty to skrypt wykona sie w obecnie uzywanym shellu 
		</details>
	</li>
	<li>
		<details> <summary>- Czym jest <b>export</b> a czym <b>env</b>, jak działają zmienne środowiskowe, jak je wypisac</summary>
			- <code>env</code> - wypisuje zmienne środowiskowe   </br> 
			- <code>export</code> - tworzy zmienną środowiskową   </br>	
		</details> 
	</li>
	<li>
		<details> <summary>- Jak sprawdzic biblioteki których nam brakuje </summary>
			- <code>ldd "sciezka docelowa komendy"</code>
		</details> 
	</li>
	<li>
		<details> <summary>- Czym jest <b>SWAP</b>, ile go potrzebujemy </summary>
			- Pamięc ulotna dostępna na dysku którą system może wykorzystywac, jej użycie jest zależne od stopnia swapiness, minimalna wielkośc powinna byc równa ilości RAM, ze względu na możliwośc hibernacji 
		</details> 
	</li>
	<li>
		<details> <summary>- Jak sprawdzic gdzie jest zainstalowany dany program </summary>
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
			- <code>bash</code>  </br>
			- <code>zsh</code>  </br>
			- <code>fish</code>  </br>
		</details>
	</li>
	<li>
		<details> <summary>- Czym jest <b>sticky bit</b> ? </summary>
			- Na koniec komendy jak zmienic lub ustawic te specjalne bity. Do tego słuzy nam komenda chmod.  
				<code>chmod o+s <nazwa pliku></code>  </br>
				<code>chmod g+s <nazwa katalogu></code>  </br>
				<code>chmod u+s <nazwa pliku></code>  </br>
		</details>
	</li>
	<li>
		<details> <summary>- Jak brzmią domyślne ustawienia uprawnień, jak je zmienic </summary>
			- <code>umask</code> - sprawdzic jak zmienic 
		</details>
	</li>
	<li>
		<details> <summary>- Jakie znam <b>filesystemy</b> na linuxie, czym się charakteryzują</summary>
			- <code>ext2</code>  </br>
			- <code>ext3</code>  </br>
			- <code>ext4</code>  </br>
			- <code>xfs</code>  </br>
			- <code>btrfs</code>  </br>
			- <code>bfs</code>  </br>
		</details>
	</li>
	<li>
		<details> <summary>- Jakie znam <b>katalogi linuxowe</b>, za co odpowiadają</summary>
			- /boot - pliki niezbędne do uruchomienia systemu (kernel, initrd, pliki bootloadera - w przypadku GRUB)  </br>
			- /etc - pliki konfiguracyjne, ustawienia systemowe  </br>
			- /home - pliki określające ustawienia każdego użytkownika + ich pliki  </br>
			- /proc - wirtualny katalog, zawierający dane o aktualnie uruchomionych procesach  </br>
			- /tmp - pliki tymczasowe
		</details>
	</li>
</ol>

  



  
[Go top](#spis-treści)














