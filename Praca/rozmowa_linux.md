# Spis treści 

- [Atos](#Atos)
	- [Pytania ktore byly](#pytania-ktore-były-ostatnio)
	- [Potencjalne pytania](#potencjalne-pytania)
- [Co opisac](#co-opisac)
- [Czego się uczyc](#czego-się-uczyc)
- [Pytania do uzupełnienia](#pytania-do-uzupełnienia)
- [Pytania na rozmowe](#pytania-na-rozmowę)



# Atos - Linux z pythonem

## Pytania ktore były ostatnio 
- [Jak skonfigurowac NFS](#jak-skonfigurowac-nfs)
- [Jak skonfigurowac Sambę](#jak-skonfigurowac-sambe)
- [Logi](#logi)
	- [Gdzie znalezc logi](#gdzie-znalezc-logi)
	- [Logrotate](#logrotate)

## Potencjalne pytania  
- [Git](#git)



# Co opisac 
- #### Jak skonfigurowac NFS
- #### Jak skonfigurowac Sambe
- #### Git 
	- #### Branch - jak dodac nowy
		- Dodac do instrukcji Git https://www.atlassian.com/git/tutorials/using-branches/git-checkout
	- Jak sprawdzic kto i kiedy dodał jakiś commit  
- #### Logi
	- #### Gdzie znalezc logi
	- #### Logrotate
- Gdzie przechowywane sa logi
- Ansible 
- Puppet
- Docker



# Czego się uczyc
- KVM 
- firewall-cmd jest frontendowym klientem, pod spodem jest obecnie nftables, wcześniej było to iptables 
- Jak działa firewall 
- Nauczyc sie iptables i znalezc do niego jakies pytania
- Automatyczne narzędzia do rotowania logów

	

# Pytania do uzupełnienia 
<ol>
	<li>
		<details> <summary>	- Automatyczne narzędzia do rotowania logów </summary>
			Tekst
		</details>
	</li>
	<li>
		<details> <summary>Print information about users who are currently logged in</summary>
			<code>who</code>
		</details>
	</li>
	<li>
		<details> <summary>	- Czym różnią się filesystemy między sobą, np xfs i ext4</summary>
			Tekst
		</details>
	</li>
	<li>
		<details> <summary>	- Jak dodac regułę do firewalla</summary>
			Tekst
		</details>
	</li>
	<li>
		<details> <summary>	- Gdzie znajduje się plik z użytkownikami w systemie </summary>
			/etc/passwd
		</details>
	</li>
	<li>
		<details> <summary>	- Jak dodac użytkownika - adduser i useradd - jak działa useradd</summary>
			Tekst
		</details>
	</li>
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














