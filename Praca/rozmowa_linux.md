# Spis treści
[Koniec](#koniec)
- [Czego sie uczyc](#czego-się-uczyc)

	## Pytania - kategorie
	- [Linux](#linux)
	- [Bash](#bash)
	- [NFS - jak skonfigurowac](#nfs---jak-skonfigurowac)
	- [Samba - jak skonfigurowac](#samba---jak-skonfigurowac)
	- [Logi](#logi)
		- [Gdzie znalezc logi](#gdzie-znalezc-logi)
		- [Logrotate](#logrotate)
	- [LVM - jak dziala, cos tam, procedura](#Lvm)
	- [Git](#git)
	- [Sieci](#sieci)
	- [Pomoc](#pomoc)

- [Tematy pytan](#tematy-pytan)
- [Randomowe pytania](#randomowe-pytania)

- [Pytania do uzupełnienia](#pytania-do-uzupełnienia)


# Czego się uczyc
- KVM 
- logrotate - Automatyczne narzędzia do rotowania logów
- Ansible 
- Puppet
- Docker
	

### #TODO - odpowiedziec na reszte pytan

ATOS
- Jak wyświetlić porty selinux 
- Jak sprawdzić która sieciówka jest obecnie używana
- Czym jest daemon
- Daemon działa w kernelspace czy userspace? - kernelspace
- Do czego służy systemd ? - nie wystarczy start i restart usług, można też montować dyski itd. 

EURO LINUX
- co robi lsof, kiedy go używamy - usuwanie plików, folderów, jakiekolwiek zmiany?
- usr - co znaczy skrot (nie kurde user tylko unix system resource)
- Jak działają dwie ostatnie kolumny w fstabie
- Co zwraca $@ i ogólnie zmienne specjalne?
- Jak zwrócić trzeci argument podany do skryptu? - $3 - w bashu liczymy od 1 a nie 0
- Uczyć się Jenkinsa
- Jak podglądać logi na bierząco? - tail -f ???
- Jak wyświetlić liczbę twardych doswiązań do plików ? - `ls -l`
- Czym jest system operacyjny?
- Jak ustawić tryb permissive tymczasowo i na stałe 
- rpm -ql - jak wyświetlić jaki pakiet zainstalował dany plik?
- Jak wyświetlić informacje na temat partycji ? = wyświetlić informacje w /proc - sprawdzić gdzie konkretnie 
- Jak wyświetlić wszystkie usługi działające w systemd - nie samo systemctl, sprawdzić
- Jak dodać użytkownika do wielu grup jednym poleceniem - usermod -aG grupa,grupa username?
- Jak wyświetlić konteksty SELinux? - ogolnie selinux 



# Tematy pytan

## Linux 

### System

- Gdzie przechowywane są pliki konfiguracyjne
	- /etc

- Jaki jest proces bootowania systemu
	- Tekst

- Czym jest **sticky bit** i ogólnie kurde bity, sprawdzić nazwy - Na koniec komendy jak zmienic lub ustawic te specjalne bity. - nie wystarczy tylko zabranianie usunięcia folderu, robi więcej
	- Do tego słuzy nam komenda chmod.  
		- chmod o+s "$nazwa pliku"
		- chmod g+s "$nazwa katalogu"
		- chmod u+s "$nazwa pliku"

- Jakie znam **katalogi linuxowe**, za co odpowiadają
	- **/boot** - pliki niezbędne do uruchomienia systemu (kernel, initrd, pliki bootloadera - w przypadku GRUB)  
	- **/etc** - pliki konfiguracyjne, ustawienia systemowe  
	- **/home** - pliki określające ustawienia każdego użytkownika + ich pliki  
	- **/proc** - wirtualny katalog, zawierający dane o aktualnie uruchomionych procesach  
	- **/tmp** - pliki tymczasowe

- Jakie są zmienne środowiskowe w linuxie 
	- EDITOR
	- SHELL
	- PWD
	- HOME
	- USER
	- PATH
	- NAME

- Czym jest **GRUB**, jak przebiega proces bootowania systemu
	- boot manager,  który ładuje jądro Linuksa, jest to pierwsze oprogramowanie uruchamiane przy starcie systemu.  
	[Czym jest grub + bootowanie](https://qa-stack.pl/ubuntu/347203/what-exactly-is-grub)

- Jak sprawdzic biblioteki których nam brakuje
	- ldd "sciezka docelowa komendy"

- Czym jest **SWAP**, ile go potrzebujemy
	- Pamięc ulotna dostępna na dysku którą system może wykorzystywac, jej użycie jest zależne od stopnia swapiness, minimalna wielkośc powinna byc równa ilości RAM, ze względu na możliwośc hibernacji

- Jak sprawdzic gdzie jest zainstalowany dany program
	- whereis

- Przykładowe shelle
	- bash
	- zsh
	- fish

- Jak brzmią domyślne ustawienia uprawnień, jak je zmienic
	- **umask** - sprawdzic jak zmienic - trzeba to zmieniać w bashrc?

- Sprawdź czy maszyna na której jesteś jest maszyną wirtualną
	- lscpu, wyświetla to czy maszyna jest wirtualizowana

- Grep po wszystkich katalogach w psozukiwaniu stringa wewnątrz pliku
	- ```grep -R "string" sciezka docelowa ?```

- Czym są linki, różnica między hard a soft linkiem
	- odpowiedzieć na pytanie
	- ```ln -s``` - tworzenie soft linka?
	- hard link jest tworzony domyślnie?

- Print information about users who are currently logged in
	- who 

- Gdzie znajduje się plik z użytkownikami w systemie
	- /etc/passwd

- Jak dodać użytkownika 
	- adduser i useradd
		- opisać ocpje useradd
	- domyślne opcje dla useradd znajdują się w pliku /etc/defaults/useradd?
		- dopisać jeszcze jeden plik w którym można zmieniać ustawienia domyślne

- Na serwerze zdalnym mam aplikację apache ale nie jestem w stanie wyświetlic strony hostowanej przez nią, jak zdiagnozowac problem 
	- Tekst

### Storage 
- Jak działają LVMy, czym są, jak je wyświetlic, jak rozszerzyc, czym jest volume group
	- lvm 
		- lslvm - wyświela lvm
		- rozszerzenie lvm :
			- rozszerzenie partycji lvm w wirtualizatorze
			- partprobe - sprawdza zmiany w tablicy partycji?

- Jak sprawdzic czy filesystem działa poprawnie, jak go naprawic
	- fsck."$filesystem"

- Wymień znane Ci filesystemy, czym się charakteryzują/różnią
	- btrfs
	- ext2,3,4
	- xfs
	- bfs

## Bash
- Wypisac zmienne specjalne z instrukcji bash 			
	- wynik ostatniej komendy ( najczesciej 0/2 - 0 to komenda wykonana prawidlowo, wszystko inne to blad, nie musi byc to 2, liczba moze byc nawet ujemna )  
		- `$$` - numer procesu używanego przez komende   
		- `!$` - ostatni użyty argument  
		- `$0` - nazwa programu  
		- `$1` - argumenty, zaczynaja sie od jednego, nie musi byc to jeden  
		- `$#` - liczba argumentow  
		- `$*` - wszystkie argumenty jako string  
		- `$@` - argumenty w postaci tablicy  
[Opis z notatek RHCSA](https://github.com/mariuszkuswik/Nauka/blob/main/Linux/Linux.md#zmienne-specjalne)

- Exitcode z instrukcji Bash, wypisac czym jest
	- Tekst
- **shebang** - czym jest?
	-  daje kontrole nad tym w jakim shellu zostanie wykonany skrypt, jezeli nie zostanie uzyty to skrypt wykona sie w obecnie uzywanym shellu 
	
- Do czego służy kropka w skryptach bashowych, jak działa source pliku
	- Zmienne ze skryptu zaciaganego rowniez zastana zaciagniete
	- Zaciagany/sourcowany skrypt zostanie wykonany ( sprawdzic czy na pewno )

- Co zwraca funkcja ?
	- Sama z siebie zwraca **exitcode**, domyslnie wartosc 0/1, żeby zwrócic coś więcej używamy **return**

- Czym jest **export** a czym **env**, jak działają zmienne środowiskowe, jak je wypisac
	- env - wypisuje zmienne środowiskowe
	- export - tworzy zmienną środowiskową

- Dlaczego przypisujemy zmienne sredowiskowe 
	- Żeby być do nich dostęp z każdego shella?


## Logi
- [Logi RHEL](https://access.redhat.com/documentation/en-us/red_hat_enterprise_linux/7/html/system_administrators_guide/ch-viewing_and_managing_log_files)

### Gdzie znalezc logi
#### Komendy
- `journalctl` - Odpytuje dziennik **systemd** 
- `last` - ostatnie logowania, komenda bardziej szczegółowa, wyświetla adresy ip ze zdalnych logowań i rebooty
	- **last reboot** - wyświetla same rebooty
	- **last "$username"** - wyświetla same logowania użytkownika
- `lastlog` - ostatnie logowania, komenda dosyć ogólna
 
#### Pliki
- ```/var/log``` - folder z logami  
	- **/var/log/messages** - główny plik z logami  
	- **/var/log/secure** - plik ?
	- **/var/log/boot** - log z bootowania

#### Service 
- ```rsyslogd``` - służy do zgłaszania logów 
	- **/etc/rsyslog.conf** - domyślny plik konfiguracyjny dla rsyslog 

#### Logrotate
- [Log rotate opisany](https://www.tecmint.com/install-logrotate-to-manage-log-rotation-in-linux/)
- [Plural - logi wyjasnione by Andrew Mallet ](https://app.pluralsight.com/course-player?clipId=0cc96a45-0ee8-4ff2-93ae-06247c6c3bfc)

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
- git log - co robi 
- git checkout - przechodzi do nowego branchu?
- git branch 
- git merge - opisać 

## LVM 
- ### Jak dodać LVM - procedura
## Bash 
- Co zwraca funkcja 
	- Sama z siebie zwraca 0/1, jeżeli chcemy zwrócić coś konkretnego to używamy return

- Jak zwrócic wartośc funkcji
	- return

## Sieci

- Czym jest VLAN 
	- Vlan pozwala w ramach jednej fizycznej sieci lokalnej tworzyc wiele sieci logicznych (sieci wirtualnych)
	- technologia sieciowa, która pozwala w ramach jednej fizycznej sieci lokalnej tworzyc wiele sieci logicznych (sieci wirtualnych)

- Czym jest brama domyślna
	- W sieci TCP/IP domyślna brama (sieciowa) (ang. default gateway) oznacza router, do którego komputery sieci lokalnej mają wysyłac pakiety o ile nie powinny byc one kierowane w siec lokalną lub do innych, znanych im routerów.

- Czym rozni sie **TCP od UDP**
	- Działanie TCP oferuje coś w rodzaju potwierdzenia zwrotnego, że połączenie zostało nawiązane oraz wysyła dane w sesji pomiędzy dwoma węzłami. ... UDP to również protokół w warstwie transportowej, ale nie wymaga handshake'a ani potwierdzenia o otrzymaniu danych.   
			[Podstawy sieci + opis TCP i UDP](https://newsblog.pl/czym-one-sa-roznica-miedzy-protokolem-tcp-i-udp/) 

- Jak sprawdzic porty otwarte na lokalnej maszynie 
	- **netstat**
		- **netstat -a** - wyświetla wszystkie porty
		- **netstat -l** - wyświetla nasłuchujące porty

- Jak przeskanowac porty zdalnej maszyny
	- nmap

- Jak wyświetlic karty sieciowe
	- ip a

- Jak ustawic statyczne ip dla maszyny
	- Opisac nmcli - jak dziala nmcli 

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
	- ip route

## Pomoc 
- Dokumentacja/pomoc w linuxie
	- man 
	- /usr/share/doc

## Randomowe pytania

- Jakie znam rodzaje RAIDa, na czym polegają
	- Tekst
- Czym jest Kernel
	- Tekst
- Serwer jest zajeżdżany, w jaki sposób zdiagnozuję problem
	- Tekst
- Czym jest wirtualizacja
	- Tekst
- Czym jest konteneryzacja
	- Tekst
- Jak dzialaja klamrowe nawiasy w bashu
	- Tekst


  
##### Koniec


  
[Go top](#spis-treści)


