
# Linux/Bash

# Spis treści
1. [System](#system-linux)
2. [Biblia](#Biblia)
    - [Uprawnienia](#Uprawnienia)
        - [Umask](#umask---definiowanie-uprawnień-domyślnych)
        - [Chown](#chown---Zmiana-właściciela-pliku)
    - [Praca z plikami tekstowymi](#Praca-z-plikami-tekstowymi)
        - [Vim](#vim)
        - [Wyszukiwanie plików](#wyszukiwanie-plików)
            - [Locate](#locate-1)
            - [Find](#find)
            - [Grep](#grep)
2. [Skryptowanie](#skryptowanie)
	- [Zmienne specjalne](#zmienne-specjalne)
	- [Exitcode](#exitcode)
	- [Automatyczne tworzenie użytkownika - przykładowy skrypt](#automatyczne-tworzenie-u%C5%BCytkownika)
3. [Funkcje](#funkcje)
4. [Sieci](#sieci)
5. [Wirtualizacja](#wirtualizacja)


## System Linux 




# Biblia

## Używanie Powłoki 



# #TODO - Dodać zwijanie przy opisach poleceń i skrócić część notatek 

### <code>id</code>


id pokazuje id uzytkownika i gid ( id grupy uzytkownika)

Więcej informacji o tożsamości użytkownika dostarcza polecenie id:
<code>$ id</code>
> uid=1000(chris) gid=1000(chris) groups=1005(sales), 7(lp)

nazwa użytkownika to chris, (uid) 1000. Podstawową grupą użytkownika **chris**, podstawową grupą również jest **chris** (gid) 1000. 
Użytkownik chris należy również do innych grup o nazwach **sales** (gid 1005) i **lp** (gid 7).

**W dystrybucjach systemu Linux, w których jest włączony mechanizm SELinux (Security Enhanced Linux),
takich jak Fedora i Red Hat Enterprise Linux, na końcu danych wyjściowych polecenia id znajdują się
jeszcze informacje dodatkowe. Te dane mogą mieć następującą postać:** 
    
> context=unconfined_u:unconfined_r:unconfined_t:s0-s0:c0.c1023


### <code>type</code>

Określenie źródła poszczególnych poleceń powłoki jest możliwe po wydaniu polecenia type.
(Jeżeli używana powłoka jest inna niż bash, wtedy należy skorzystać z polecenia which).
Na przykład określenie miejsca położenia polecenia bash jest możliwe po wpisaniu:

<code>$ type bash</code>
> bash is /bin/bash

Jeżeli sprawdzane polecenie znajduje się
w kilku miejscach, wówczas dodanie opcji -a spowoduje wyświetlenie wszystkich znanych
lokalizacji danego polecenia. Na przykład polecenie type -a ls powinno wyświetlić położenie
systemowego polecenia ls i polecenia zdefiniowanego za pomocą aliasu.

<code>$ type -a ls</code>

> ls is aliased to `ls --color -F'
> ls is /usr/bin/ls




### Katalogi z komendami 
   
Większość poleceń dostarczanych z Linuksem znajduje się w katalogach /bin, /usr/bin oraz /usr/local/bin.
Katalogi /sbin i /usr/sbin zawierają polecenia administracyjne 




## Uprawnienia 

### Plik 

    - Read - Wyświetlenie zawartości pliku
    - Write - Zmiana zawartości pliku, zmianajego nazwy lub usunięcie pliku
    - Execute - Uruchomienie pliku jako programu

### Katalog 

    - Read - Wyświetlenie plików oraz podkatalogów danego katalogu
    - Write - Dodawanie plików lub podkatalogów do danego katalogu, usunięcie plików lub katalogów z danego katalogu
    - Execute - Wejście do katalogu, przeszukiwanie lub uruchomienie programu znajdującego się w nim, dostęp do metadanych pliku (wielkość, znaczniki czasu) dla wszystkich plików znajdujących się w tym katalogu

### Uprawnienia liczbowe  

- 4 - read
- 2 - write 
- 1 - execute 

```chmod -R 755 $HOME/myapps``` - zmiana uprawnien rekurencyjnie dla calego katalogu 

### Uprawnienia tekstowe 

- a - all 
- u - user
- g - group 
- o - others  

- w - write 
- r - read 
- x - execute 


- Nadawanie uprawnien tekstowo, poczatkowo do pliku wszyscy maja pelne uprawnienia  
    \- ( minus ) zabiera uprawnienia  
    \+ ( plus ) dodaje uprawnienia   
    
    Wszyscy maja pelne uprawnienia, po wykonaniu r-xr-xr-x  
    ```$ chmod a-w plik```  
    
    Nikt nie ma uprawnien, po wykonaniu rw-------  
    ```$ chmod u+rw plik```  

    Wynikiem wykonania tego polecenia chmod będą uprawnienia r-xr-x---:
    ```$ chmod ug+rx plik```

## Ważne !

**Użycie liter podczas rekurencyjnej zmiany uprawnień za pomocą polecenia chmod sprawdza się
lepiej niż zastosowanie liczb do tego celu** , ponieważ bity można zmieniać wybiórczo zamiast
wszystkich uprawnień jednocześnie. Załóżmy na przykład, że chcemy usunąć uprawnienia
„pozostałych użytkowników” bez zmiany innych uprawnień zdefiniowanych dla plików
i katalogów. W takim przypadku można wydać następujące polecenie:

```$ chmod -R o-w $HOME/myapps```

To polecenie powoduje rekurencyjne usunięcie uprawnień „pozostałych użytkowników” dla
wszystkich plików i katalogów znajdujących się w katalogu myapps. Jeżeli do zdefiniowania
uprawnień użylibyśmy liczby, np. 644, uprawnienie wykonywania zostałoby usunięte dla
wszystkich katalogów. Liczba 755 oznaczałaby włączenie uprawnienia wykonywania także
dla zwykłych plików. Opcja o-w umożliwia wyłączenie tylko jednego bitu i pozostawienie
pozostałych bitów bez zmian.


### Umask - Definiowanie uprawnień domyślnych 

```umask``` - Wyświetla obecnie ustawiony umask 

**Zmiana umask poleceniem umask zmienia to tylko tymczasowo !**

- Tymczasowa zmiana 
    ```umask 777``` 

- Stałą zmiana 
    Jeżeli wartość umask chcesz zmienić trwale, polecenie umask musisz dodać do pliku .bashrc
    znajdującego się w katalogu domowym (polecenie to umieść gdzieś na końcu pliku).
    Po następnym uruchomieniu powłoki wartość umask będzie odpowiadała zdefiniowanej
    w pliku **.bashrc** ( ```/etc/bashrc``` chcąc zmienić dla wszystkich użytkowników )


**The pre-defined initial permissions for files and directories are 666 and 777 respectively.**
Without any change in default umask permissions, all files created by user root will get 644 (666 - 022) permissions and all directories will get 755 (777-022) permissions.

![Umask wyjaśnienie](https://github.com/mariuszkuswik/Nauka/blob/main/Linux/umask_permissions.png)


### chown - Zmiana właściciela pliku 

Zmiana właściciela użytkownika i grupy na janek
```chown janek:janek /home/janek/notatka.txt```

Zmiana rekurencyjna właściciela i grupy dla katalogu  
```chown -R janek:janek /media/myusb```

### cp - kopiowanie plikow 

```cp -a test test2``` - kopia zachowała znaczniki daty i godziny oraz uprawnienia. Bez tej opcji użyte zostaną znaczniki daty i godziny oraz uprawnienia określone przez wartość umask

### mv - przenoszenie plików 

Dla mv jest użycie opcji -b. W takim przypadku, jeśli w położeniu
docelowym istnieje już plik o danej nazwie, to przed przeniesieniem nowego pliku nastąpi
utworzenie kopii zapasowej już istniejącego

### Przydatne !
wydanie polecenia mv, cp lub rm z ukośnikiem
na początku, np. \rm ogromny_katalog. Ukośnik powoduje użycie polecenia rm, a nie jego aliasu



## Praca z plikami tekstowymi 

### Wpisywanie tekstu do pliku przy pomocy ```cat```
cat << tekst > /tmp/yourfilehere
These contents will be written to the file.
        This line is indented.
tekst

### Vim 

```ZZ``` - wyjście z zapisem 
```:qw``` - wyjście z zapisem

```ZQ``` - wyjście bez zapisywania 
```:q!``` - wyjście bez zapisywania 

```u``` - undo 
```Ctrl+R``` - redo 


```:!polecenie``` - wydanie polecenia do shella z poziomu vima
```:!bash``` - otwiera nowego shella, **exit** wychodzi z shella i wraca do terminala 


## Wyszukiwanie plików 

### Locate 

Wyszukuje na podstawie nazw w swojej bazie danych, jest przez to wydajniejszy,
znajduje wszystkie pliki które zawierają podaną nazwę w swojej ścieżce,
jeżeli nie masz uprawnień do danego pliku/folderu to nie zostanie on odnaleziony,  
baza domyślnie jest odświeżana raz dziennie, odświeżanie manualne ```updatedb```

- ```updatedb``` - odświeżenie bazy danych locate 

- ```/etc/updatedb.conf``` - plik konfiguracyjny określający jakie pliki mają być ignorowane i nie dodawane do bazy, 
domyślnie **locate** nie przeszukuje 
    - plików z zewnętrznie zamontowanych dysków ( cifs, nfs ), 
    - /tmp
 
- ```locate -i``` - wyszukuje pliki niezależnie od wielkości liter

### Find 

Przeprowadza wyszukiwanie w całym systemie plików, jest wolniejszy niż locate,
Po znalezieniu plików można na nich przeprowadzać pewne
operacje (służy do tego opcja -exec lub -okay) przez wydanie żądanych poleceń.

1. Wyświetlenie szczegółów na temat plików
- ```find . -ls``` - przeszukuje obecny katalog, wyświetla szczegółowe informacje w formacie takim jak **ls -l** 

2. Wyszukiwanie po nazwie 
- ```find . -name``` -  
- ```find . -iname``` - 

3. Wyszukiwanie pliku o danych wielkościach 
- ```$ find /usr/share/ -size +10M``` - wyszukuje pliki większe niż 10MB
- ```$ find /mostlybig -size -1M``` - wyszukuje pliki mniejsze niż 1MB
- ```$ find /bigdata -size +500M -size -5G -exec du -sh {} \;``` - - wyszukuje pliki większe niż 500MB i mniejsze niż 5GB, wykonuje na nich polecenie du 

4. Wyszukiwanie plików na podstawie użytkowników i grup 
- ```$ find /home -user chris -ls``` - wyszukuje pliki należące do użytkownika chris 
- ```find /home \( -user chris -or -user janek \) -ls``` - wyszukuje pliki należące do użytkownika chris lub janek  
- ```find /etc -group ntp -ls``` - wyszukuje pliki należące do grupy ntp 
- ```find /var/spool -not -user root -ls``` - wyszukuje pliki nie należące do użytkownika root 

Do wyszukiwania za pomocą uprawnień służy ```-perm``` 

### #TODO - Dopisać co dokładnie oznacza które, nie do końca to rozumiem, strona w Biblii około 149
**Brak znaku** 
**Minus (-)** 
**Slash (/)** 


- ```$ find /usr/bin -perm 755 -ls``` - dokładne dopasowanie 
> 788884 28 -rwxr-xr-x 1 root root 28176 Mar 10 2014 /bin/echo

- ```$ find /myreadonly -perm /222 -type f```
> 685035 0 -rw-rw-r-- 1 chris chris 0 Dec 30 16:34 /myreadonly/abc

- ```$ find . -perm -002 -type f -ls``` - ustawienie typu jako file 
> 266230 0 -rw-rw-rw- 1 chris chris 0 Dec 30 16:28 ./LINUX_BIBLE/abc 


5. Wyszukiwanie plików na podstawie daty i godziny 

- ```$ find /etc/ -mmin -10``` - Wyszukuje pliki zmodyfikowane w ciągu ostatnich 10 min 
- ```$ find /bin /usr/bin /sbin /usr/sbin -ctime -3``` - File's  status was last changed n*24 hours ago.

### #TODO - Dodać wyszukiwanie na podstawie czasu, strona w Bibilii 150 

Jak widać na podstawie zaprezentowanych przykładów, masz możliwość wyszukiwania zmian
w treści lub w metadanych, które zaszły w ciągu określonej liczby dni lub minut. Opcje
dotyczące czasu (-atime, -ctime i -mtime) pozwalają wyszukiwać dane na podstawie podanej
liczby dni, które upłynęły od chwili ostatniego dostępu do pliku, jego zmiany bądź modyfikacji
jego metadanych. Opcje min (tzn. -amin, -cmin i -mmin) działają tak samo, ale dotyczą minut.
Wartości podawane jako argumenty dla opcji min i time są poprzedzone znakiem minus
(wskazującym, ile czasu należy odjąć od bieżącego dnia i godziny) lub znakiem plus
(wskazującym, ile czasu należy dodać do bieżącego dnia i godziny). Bez znaku minus lub plus
konieczne jest dokładne dopasowanie wartości


6. Wyszukiwanie plików za pomocą not i or

pliki należące do użytkownika janek, które nie zostały przypisane grupie janek:
- ```$ find /var/allusers/ -user janek -not -group janek -ls```
    > 679972 0 -rw-r--r-- 1 janek sales 0 Dec 31 13:02 /var/allusers/one

plik musi należeć do użytkownika janek, a ponadto jego wielkość nie może przekraczać 1 MB:
- ```$ find /var/allusers/ -user janek -and -size +1M -ls```
    > 679977 1812 -rw-r--r-- 1 janek root 1854379 Dec 31 13:09 /var/allusers/dict.dat


7. Wyszukiwanie plików i wykonywanie na nich poleceń


```$ find [opcje] -exec polecenie {} \;``` - **-exec** wykonuje polecenie dla wszystkich znalezionych plików  
```$ find [opcje] -ok polecenie {} \;``` - **-ok** pyta przed wykonaniem każdego z poleceń 

Każde polecenie musi zostać zakończone backslashem i średnikiem (\;)


**Przykłady użycia :**  
- ```$ find /etc -iname passwd -exec echo "Znaleziono plik {}" \;```
    > Znaleziono plik /etc/pam.d/passwd
    > Znaleziono plik /etc/passwd

- ```$ find /usr/share -size +5M -exec du {} \; | sort -nr```
    > 116932 /usr/share/icons/HighContrast/icon-theme.cache
    > 69048 /usr/share/icons/gnome/icon-theme.cache
    > 20564 /usr/share/fonts/cjkuni-uming/uming.ttc


- ```# find /var/allusers/ -user janek -ok mv {} /tmp/janek/ \;```
    > < mv ... /var/allusers/dict.dat > ? y
    > < mv ... /var/allusers/five > ? y

### Grep 

```grep [opcja] [pattern] [plik]``` - wyszukuje patternu w podanych plikach  

```-i``` - małe/duże litery   
```-R``` - wyszukiwanie rekurencyjne ( wewnątrz wszystkich folderów )  
```-v``` - wyszukuje wiersze które **nie zawierają** podanej frazy    
```-l``` - wyśiwetla **nazwy plików** zawierających podaną frazę, bez wyświetlania zawartości   










# Koniec Biblii





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
  
```ip``` - show / manipulate routing, network devices, interfaces and tunnels  
```ip address``` - protocol address management  
```ip route``` - routing table management  
```ip link``` - network device configuration

```nmcli``` - network manager cli 

- Jak ustawić ip i brame 
	1. wejscie w config ```/etc/sysconfig/network-scripts/ifcfg-"$device_name"
	2. Config  
		```IPADDR="$adres_ip"
		NETMASK="255.255.255.0"
		GATEWAY="$adres_bramy"```
	### ***Po wszystkich zmianach configu musimy przeładować połączenie w network managerze***
	3. Przeładowanie 
		```nmcli connection down $connectionName``` 
		```nmcli connection up $connectionName```  
- Jak dodać DNS 
	1. wejscie w config ```/etc/sysconfig/network-scripts/ifcfg-"$device_name"
	2. Config 
		```DNS1="$adres_DNS"
		DNS2="$adres_DNS2"
		DNS... ```
- Jak dodać routing 
	- komenda ip route odpowiada za routing  
		```ip route add default via "$ip_address" dev "$network_card_name"


https://serverfault.com/questions/810636/how-to-manage-dns-in-networkmanager-via-console-nmcli

Here is the command to modify an existing connection.  

nmcli con mod $connectionName ipv4.dns "8.8.8.8 8.8.4.4"  

Finally, to enable the changes, bring the connection down then up:  

Verify with cat /etc/resolv.conf. You should not edit /etc/resolv.conf manually as it is generated by NetworkManager service, it is likely to get overridden at any given time.  






### Namespaces/Przestrzeenie nazw 
[Artykuł wyjaśniający](https://linuxpolska.pl/blog/zabawa-w-namespaces/)
- Przestrzenie nazw sprawiają, że możliwa jest całkowita separacja sieci – routingu, iptables i interfejsów sieciowych.





**#TODO - Całość przykładu jest do sprawdzenia i poprawienia**

<details><summary>Przykład użycia</summary>
 
   ### Przykład   
   - ```ip netns``` - Network namaspaces, bez uzycia parametrow listuje je  
   - ```ip netns add net1``` - Add network space na domyślnej karcie

   - ```ip netns exec net1 ip addr add 10.0.0.1/24 dev veth1``` - Dla namaspace **net1** wykonaj komendę ***dodania adresu ip dla urządzenia veth1***

   - ```ip netns exec net1 ip link set dev veth1 up``` - Dla namespace net1 włączenie urządzenia veth1

   - ```ping 10.0.0.1 # Fails``` - Obecnie ustawiony jest domyślny namespace więc ping nie przechodzi 

   - ```ip addr add 10.0.0.2/24 dev veth0``` - dodanie adresu ip na urządzeniu veth0 

   - ```ip link set dev veth0 up``` - włączenie urządzenia veth0

   - ```ping 10.0.0.1``` - Ping przechodzi

sudo ip link add veth0 type veth peer name veth1 netns net1  
  
chia@mariusz-chia1:~$ ip link  
1: lo: <LOOPBACK,UP,LOWER_UP> mtu 65536 qdisc noqueue state UNKNOWN mode DEFAULT group default qlen 1000  
    link/loopback 00:00:00:00:00:00 brd 00:00:00:00:00:00  
2: enp6s0: <BROADCAST,MULTICAST,UP,LOWER_UP> mtu 1500 qdisc fq_codel state UP mode DEFAULT group default qlen 1000  
    link/ether fc:34:97:10:09:2e brd ff:ff:ff:ff:ff:ff  
3: virbr0: <NO-CARRIER,BROADCAST,MULTICAST,UP> mtu 1500 qdisc noqueue state DOWN mode DEFAULT group default qlen 1000  
    link/ether 52:54:00:4f:e5:43 brd ff:ff:ff:ff:ff:ff  
4: virbr0-nic: <BROADCAST,MULTICAST> mtu 1500 qdisc fq_codel master virbr0 state DOWN mode DEFAULT group default qlen 1000  
    link/ether 52:54:00:4f:e5:43 brd ff:ff:ff:ff:ff:ff
5: docker0: <NO-CARRIER,BROADCAST,MULTICAST,UP> mtu 1500 qdisc noqueue state DOWN mode DEFAULT group default  
    link/ether 02:42:56:ca:d7:7e brd ff:ff:ff:ff:ff:ff  
8: veth0@if2: <BROADCAST,MULTICAST> mtu 1500 qdisc noop state DOWN mode DEFAULT group default qlen 1000  
    link/ether 3a:0a:61:e5:9a:ce brd ff:ff:ff:ff:ff:ff link-netns net1  


chia@mariusz-chia1:~$ sudo ip netns exec net1 ip link
1: lo: <LOOPBACK> mtu 65536 qdisc noop state DOWN mode DEFAULT group default qlen 1000
    link/loopback 00:00:00:00:00:00 brd 00:00:00:00:00:00
2: veth1@if8: <BROADCAST,MULTICAST> mtu 1500 qdisc noop state DOWN mode DEFAULT group default qlen 1000
    link/ether 02:5c:a6:fe:9f:f2 brd ff:ff:ff:ff:ff:ff link-netnsid 0

ip netns exec net1 ip add a 10.0.0.1/24 dev veth1

ip netns exec net1 ip link set dev veth1 up



</details>





### Routing 

```ip route``` - routing table management  

```ip route show ```  




### Konfiguracja adresu IP na stałe 

<details><summary><b>#TODO - sprawdzić notatki + poprawić to co jest źle</b></summary>
   
   - Komenda ```ip``` zmienia ip tylko w trakcie obecnej sesji  
   - ```/etc/sysconfig/network-scripts/``` - miejsce w którym znajdują się pliki konfiguracyjne dla kart sieciowych  
   - 

</details>




**#TODO - odpowiedzieć na pytanie**
Jak działa routing i maska podsieci 
Wyświetl karty sieciowe w linuxie, opisz czego się na tej podstawie dowiedziałeś


### iptables
### TODO - do uzupelnienia, przynajmniej krotko 

### firewalld
- W RHEL8 firewall jest zarzadzany przez firewalld, w RHEL7 pod spodem bylo iptables, obecnie jest to nftables
zarzadzanie firewalld odbywa sie za pomoca komendy ```firewall-cmd```
	
    - ```firewall-cmd --state``` - wyswietla czy firewall dziala 

	- ```firewall-cmd --list-all``` - wypisuje wszystkie reguly które obecnie działają  
	```firewall-cmd --list-all --permanent``` wypisuje reguły które są zapisane w configu - będą działać po ***reboocie systemu***

	- Stale przypisanie regul jest za pomoca configu, TODO - sprawdzic jak dokladnie


	- ```systemctl start firewalld``` wlaczenie firewalla

	- ```firewall-cmd --reload``` -  Reload firewalld to force rule changes to take effect 



- Pliki konfiguracyjne : 
	- ```/usr/lib/firewalld``` - katalog z domyslna konfiguracja
	- ```/etc/firewalld``` - katalog z obecnie dzialajacym configiem 



# System 

Systemctl - opisać 

# Wirtualizacja 

Sprawdź czy maszyna na której jesteś jest maszyną wirtualną 


	
	
	



# Notatki skopiowane z katalogu Linux


### Co to jest Linux
Linux jest to system operacyjny, który stworzył Linus Torvalds. Wzorowany na systemach UNIX jest re-implementacją jego jądra. Linux zawiera wiele udoskonaleń technicznych jakich nie ma w UNIX, co sprawia, iż jest to coś więcej niż tylko klon systemu. Na system składają się:

<ol>
  <li>Jądro (kernel).</li> 
  <li>Biblioteki systemowe.</li>
  <li>Wbudowane narzędzia. </li>
</ol>

<br>
  
<p>Środowiska te mogą być uruchamiane na różnych platformach sprzętowych produkowanych przez różnych producentów. Pierwsza wersja jądra systemowego Linux została udostępniona 17 września 1991 roku. Sam termin "LINUX" pomimo potocznego użycia go w rozumieniu systemu operacyjnego jest raczej bliższy określeniu samego jądra systemowego, które w połączeniu z pozostałymi elementami składa się na w pełni na system operacyjny. </p>

### Czym Linux różni się od UNIX
Test2

### Co to jest BASH
Skrót BASH pochodzi od "Bourne Again SHell". Twórcą tego rozwiązania jest Steve Bourne. Jest to powłoka systemowa będąca następcą wcześniejszego shell'a. (/bin/sh). Bash umożliwia prace w trybie konwersacyjnym i wsadowym. Możliwe jest definiowanie aliasów oraz funkcji, zawiera konstrukcje sterujące przepływem (if, while, for). 


### Co to jest jądro Linuxa ( Linux kernel)   
Najważniejsza część systemów operacyjnych z rodziny Linux / Unix. Pierwsze wydanie miało miejsce w 26 sierpnia 1991 roku. Jest to oprogramowanie systemowe niskiego poziomu. Jądro linux odpowiada za komunikacje ze sprzętem oraz wykonywanie operacji na pamięci operacyjnej. Służy za pośrednika (warstwa jądra) pomiędzy użytkownikiem (warstwa użytkownika), który uruchamia swoje programy a fizycznymi urządzeniami wchodzącymi w skład danej maszyny. 


# Sieci 



### Które porty są otwarte 
### Tablica routingu 
### Adres ip lokalnej maszyny  




[Idz na górę](https://github.com/mariuszkuswik/Nauka/blob/main/Linux/Linux.md#linuxbash) 
