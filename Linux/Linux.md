
# Linux/Bash

# Obecna strona 253 
- do uzuępnienia czym jest cgroup. tylko mniej więcej, bez szczegółów,

# Odpowiedzi strona 797 


# Spis treści
[Koniec Biblii](#Koniec-biblii)

1. [System](#system-linux)
2. [Biblia](#Biblia)
    - [Korzystanie z pomocy](#Korzystanie-z-pomocy)
        - [man](#man)
        - [info](#info)
    - [Używanie Powłoki](#Używanie-Powłoki)
        - [id](#id)
        - [type](#type)
    - [Uprawnienia](#Uprawnienia)
        - [Umask](#umask---definiowanie-uprawnień-domyślnych)
        - [Chown](#chown---Zmiana-właściciela-pliku)
    - [Praca z plikami tekstowymi](#Praca-z-plikami-tekstowymi)
        - [Vim](#vim)
        - [Wyszukiwanie plików](#wyszukiwanie-plików)
            - [Locate](#locate-1)
            - [Find](#find)
            - [Grep](#grep)
    - [Praca z procesami](#Zarządzanie-uruchomionymi-procesami)
        - [Background and foreground processes](#Background-and-foreground-processes )
    - [Administracja systemem linux](#administracja-systemem-linux)
    - [Zarządzanie kontami użytkowników](#Zarządzanie-kontami-użytkowników)
        - [useradd](#useradd---Ustalanie-ustawień-domyślnych-użytkownika)
        - [usermod](#usermod---Modyfikowanie-ustawień-użytkownika)
        - [userdel](#userdel---Usuwanie-użytkownika)
- [Koniec Biblii](#Koniec-Biblii)
2. [Skryptowanie](#skryptowanie)
	- [Zmienne specjalne](#zmienne-specjalne)
	- [Exitcode](#exitcode)
	- [Automatyczne tworzenie użytkownika - przykładowy skrypt](#automatyczne-tworzenie-u%C5%BCytkownika)
3. [Funkcje](#funkcje)
4. [Sieci](#sieci)
5. [Wirtualizacja](#wirtualizacja)


# Korzystanie z pomocy

## man  

```man man``` - pomoc odnośnie mana   
```man -k``` - wyszukiwanie komend   
```man -f``` - wyświetlenie wszystkich możliwych sekcji pomocy dla danej komendy  

## info

```info -a``` - wyświetla wszystkie manuale i pozwala wybrać 
### #TODO - dodać opis


# Używanie Powłoki 

# #TODO - Dodać zwijanie przy opisach poleceń i skrócić część notatek 

## id


id pokazuje *id* uzytkownika i *gid* ( id grupy uzytkownika)

```bash
id "$username"
```

> uid=1000(chris) gid=1000(chris) groups=1005(sales), 7(lp)

Nazwa użytkownika to chris, (uid) 1000, podstawową grupą użytkownika jest **chris** (gid) 1000, użytkownik chris należy również do innych grup o nazwach **sales** (gid 1005) i **lp** (gid 7).  


Jeżeli jest włączony SELinux to na końcu danych wyjściowych polecenia id znajdują się jeszcze informacje dodatkowe. Te dane mogą mieć następującą postać:

> context=unconfined_u:unconfined_r:unconfined_t:s0-s0:c0.c1023  


## type

Pokazuje gdzie znajduje się dane polecenie
(Jeżeli używana powłoka jest inna niż bash, wtedy należy skorzystać z polecenia which).
Np. określenie położenia polecenia *bash*

```$ type bash```
> bash is /bin/bash

```type -a "$command"``` - wyświetla wszystkie znane położenia danego polecenia,  
*np. polecenie type -a ls wyświetla położenie systemowego polecenia ls i polecenia zdefiniowanego za pomocą aliasu.*
   
   
```$ type -a ls```
  
> ls is aliased to `ls --color -F'
> ls is /usr/bin/ls


## Katalogi z komendami 
   
Większość poleceń dostarczanych z Linuksem znajduje się w katalogach /bin, /usr/bin oraz /usr/local/bin.
Katalogi /sbin i /usr/sbin zawierają polecenia administracyjne 


# Uprawnienia 

## Plik 

- Read - Wyświetlenie zawartości pliku
- Write - Zmiana zawartości pliku, zmianajego nazwy lub usunięcie pliku
- Execute - Uruchomienie pliku jako programu

## Katalog 

- Read - Wyświetlenie plików oraz podkatalogów danego katalogu
- Write - Dodawanie plików lub podkatalogów do danego katalogu, usunięcie plików lub katalogów z danego katalogu
- Execute - Wejście do katalogu, przeszukiwanie lub uruchomienie programu znajdującego się w nim, dostęp do metadanych pliku (wielkość, znaczniki czasu) dla wszystkich plików znajdujących się w tym katalogu

## Uprawnienia liczbowe  

- 4 - read
- 2 - write 
- 1 - execute 

```chmod -R 755 $HOME/myapps``` - zmiana uprawnien rekurencyjnie dla calego katalogu 

## Uprawnienia tekstowe 

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


### Formatowanie ogarnięte

### Ważne ! - **Użycie liter podczas rekurencyjnej zmiany uprawnień za pomocą polecenia chmod sprawdza się lepiej niż zastosowanie liczb do tego celu**,
Ponieważ bity można zmieniać wybiórczo zamiast wszystkich uprawnień jednocześnie.   
Załóżmy na przykład, że chcemy usunąć uprawnienia „pozostałych użytkowników” bez zmiany innych uprawnień zdefiniowanych dla plików i katalogów.   
W takim przypadku można wydać następujące polecenie:  

```$ chmod -R o-w $HOME/myapps```

To polecenie powoduje rekurencyjne usunięcie uprawnień „pozostałych użytkowników” dla wszystkich plików i katalogów znajdujących się w katalogu myapps. Jeżeli do zdefiniowania
uprawnień użylibyśmy liczby, np. 644, uprawnienie wykonywania zostałoby usunięte dla wszystkich katalogów.   
Liczba 755 oznaczałaby włączenie uprawnienia wykonywania także dla zwykłych plików. Opcja o-w umożliwia wyłączenie tylko jednego bitu i pozostawienie pozostałych bitów bez zmian.  

   
## Umask - Definiowanie uprawnień domyślnych 

```umask``` - Wyświetla obecnie ustawiony umask 

**Zmiana umask poleceniem umask zmienia to tylko tymczasowo !**

- Tymczasowa zmiana 
    ```umask 777``` 

- Stała zmiana 
    Jeżeli wartość umask chcesz zmienić trwale, polecenie umask musisz dodać do pliku .bashrc
    znajdującego się w katalogu domowym (polecenie to umieść gdzieś na końcu pliku).
    Po następnym uruchomieniu powłoki wartość umask będzie odpowiadała zdefiniowanej
    w pliku **.bashrc** ( ```/etc/bashrc``` chcąc zmienić dla wszystkich użytkowników )


**The pre-defined initial permissions for files and directories are 666 and 777 respectively.**
Without any change in default umask permissions, all files created by user root will get 644 (666 - 022) permissions and all directories will get 755 (777-022) permissions.

![Umask wyjaśnienie](https://github.com/mariuszkuswik/Nauka/blob/main/Linux/umask_permissions.png)


## chown - Zmiana właściciela pliku 

Zmiana właściciela użytkownika i grupy na janek  
```chown janek:janek /home/janek/notatka.txt```  

Zmiana rekurencyjna właściciela i grupy dla katalogu    
```chown -R janek:janek /media/myusb```  

## cp - kopiowanie plikow 

```cp -a test test2``` - kopia zachowała znaczniki daty i godziny oraz uprawnienia. Bez tej opcji użyte zostaną znaczniki daty i godziny oraz uprawnienia określone przez wartość umask  

## mv - przenoszenie plików 

```mv -b "$source_file/folder" "$dest_file/folder"``` - jeśli w położeniu docelowym istnieje już plik o danej nazwie, to przed przeniesieniem nowego pliku nastąpi utworzenie kopii zapasowej już istniejącego


### Przydatne ! - wydanie polecenia mv, cp lub rm z ukośnikiem na początku, np. \rm ogromny_katalog. Ukośnik powoduje użycie polecenia rm, a nie jego aliasu

# Praca z plikami tekstowymi 

## Wpisywanie tekstu do pliku przy pomocy ```cat```

```bash
cat << tekst > /tmp/yourfilehere
These contents will be written to the file.
        This line is indented.
tekst
```

## Vim 

```ZZ``` - wyjście z zapisem 
```:qw``` - wyjście z zapisem

```ZQ``` - wyjście bez zapisywania 
```:q!``` - wyjście bez zapisywania 

```u``` - undo 
```Ctrl+R``` - redo 


```:!polecenie``` - wydanie polecenia do shella z poziomu vima
```:!bash``` - otwiera nowego shella, **exit** wychodzi z shella i wraca do terminala 


# Wyszukiwanie plików 

## Locate 

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

## Find 

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

-atime n - File was last accessed n*24 hours ago.
-ctime n - File's  status was last changed n*24 hours ago.
-mtime n - File's data was last modified n*24 hours ago.



6. Wyszukiwanie plików za pomocą not i or

pliki należące do użytkownika janek, które nie zostały przypisane grupie janek:
- ```$ find /var/allusers/ -user janek -not -group janek -ls```
    > 679972 0 -rw-r--r-- 1 janek sales 0 Dec 31 13:02 /var/allusers/one

plik musi należeć do użytkownika janek, a ponadto jego wielkość nie może przekraczać 1 MB:
- ```$ find /var/allusers/ -user janek -and -size +1M -ls```
    > 679977 1812 -rw-r--r-- 1 janek root 1854379 Dec 31 13:09 /var/allusers/dict.dat


7. Wyszukiwanie plików i wykonywanie na nich poleceń


- ```$ find [opcje] -exec polecenie {} \;``` - **-exec** wykonuje polecenie dla wszystkich znalezionych plików  
- ```$ find [opcje] -ok polecenie {} \;``` - **-ok** pyta przed wykonaniem każdego z poleceń 

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

## Grep 

```grep [opcja] [pattern] [plik]``` - wyszukuje patternu w podanych plikach  

```-i``` - małe/duże litery   
```-R``` - wyszukiwanie rekurencyjne ( wewnątrz wszystkich folderów )  
```-v``` - wyszukuje wiersze które **nie zawierają** podanej frazy    
```-l``` - wyśiwetla **nazwy plików** zawierających podaną frazę, bez wyświetlania zawartości   


# Zarządzanie uruchomionymi procesami

## ps

```ps aux``` - wyświetla wszystkie uruchomione procesy dla wszystkich użytkowników w systemie 
```-e``` - wyświetla wsyzystkie działające procesy 
```-f``` - full-format, including command lines


```-o``` - pozwala na wybranie konkretnych kolumn 
    - kolumny które mogą zostać wyświetlone = pid,user,uid,group,gid (group id),vsz (zaalokowana pamięć wirtualna),rss (faktycznie użyta
pamięć operacyjna),comm (pełne polecenie, które zostało wydane)

```sort=[nazwa_kolumny]``` - sortowanie na podstawie podanej kolumny 
```sort=-[nazwa_kolumny]``` - sortowanie odwrotne po nazwie kolumny 


## top 

```h``` - w oknie top w każdym momencie można użyć ```h``` - wyświetla to pomoc   
  
```M``` - sortowanie według ilości zajmowanej pamięci  
```P``` - sortowanie według zużycia procesora ( domyślna opcja )
```R``` - sortowanie w odwrotnej kolejności 
  
```1``` - wyświelta zużycie wszystkich procesorów ( jeżeli jest ich więcej )    
```u``` - wyszkuje procesy otwarte przez podanego użytkownika   
  
   
```r``` - renice procesu  
```k``` - kill procesu 
    **-9** - natychmiastowe zakończenie 
    **-15** - eleganckie zakończenie 
  
  
## Procesy w tle i na pierwszym planie 

- ```$ find /usr > /tmp/allusrfiles &``` - uruchamia proces w tle
    >  [3] 15971
    > - [3] - numer zadania
    > - 15871 - numer procesu



- ```jobs``` - wyświetla wszytkie obecnie działające zadania 
    - ```-l``` - wyświetla pid i status dla jobów 
    - ```-p``` - wyświetla tylko pidy dla jobów  

- ```$ fg %1``` - przenosi pierwsze zadanie z listy jobs **na pierwszy plan** 
- ```$ bg %5``` - przenosi piąte zadanie z listy jobs **w tło**

## Zamykanie procesu i zmiana jego priorytetu

## Kończenie działania procesów 

Do najczęściej używanych
sygnałów z poziomu powłoki zaliczamy 

- SIGKILL (9) - natychmiastowe zakończenie procesu 
- SIGTERM (15) - eleganckie zakończenie procesu 
- SIGHUP (1) - ponowne załadowanie plików konfiguracyjnych 

**kill i kilall** mozna wykorzystywac do kończenia lub zmiany procesu, **np. nakazujący procesowi ponowne odczytanie plików konfiguracyjnych, wstrzymanie działania, kontynuowanie działania po wcześniejszym wstrzymaniu itd.**


```$ killall -9 testme``` - kilall wysyła sygnał na podstawie nazwy proces


### Tabela z syganłami dla procesów

| Sygnał | Liczba | Opis |
|--|--|--|
| SIGHUP | 1 | Wykryto zerwanie połączenia z terminalem kontrolnym lub zamknięcie jego procesu |
| SIGINT | 2 | Przerwanie z poziomu klawiatury |
| SIGQUIT | 3 | Zakończenie działania zainicjowane z poziomu klawiatury |
| SIGABRT | 6 | Sygnał przerwania z abort(3) |
| SIGKILL | 9 | Natychmiastowe zakończenie działania |
| SIGTERM | 15 | Sygnał zakończenia działania procesu |
| SIGCONT | 19,18,25 | Kontynuowanie działania wcześniej wstrzymanego procesu |
| SIGSTOP | 17,19,23 | Zatrzymanie procesu |

##### Tabela 6.1, strona 165


Zwróć uwagę na istnienie wielu liczb reprezentujących sygnały SIGCONT i SIGSTOP, ponieważ
poszczególne architektury sprzętowe używają różnych liczb wskazujących na te sygnały.
Na przykład architektury x86 i Power w większości przypadków wykorzystują wartość
środkową. Pierwsza wartość zwykle sprawdza się na platformach Alpha i SPARC, podczas
gdy ostatnia — w architekturze MIPS.


## nice i renice - definiowanie priorytetu procesu

- Procesy mają wartości **-20 do 19, im niższa wartość tym proces ma wyższy priorytet**, domyślnie jest 0,
- Zwykły użytkownik może przypisać większą wartość priorytetu, ale nie niższą. Dlatego jeśli użytkownik przypisze procesowi wartość 10 dla priorytetu, a później będzie
chciał przywrócić poprzednią wartość priorytetu, np. 5, taka operacja zakończy się
niepowodzeniem. Podobnie próba przypisania wartości ujemnej priorytetowi procesu
również zakończy się niepowodzeniem.
- Zwykły użytkownik może zmieniać priorytet jedynie własnym procesom.


```# nice -n +5 updatedb &``` - **uruchamia polecenie updatedb z nice +5** i uruchomienie go w tle

Potiwerdzenie zmiany nice procesu na 5 za pomocą polecenia **top**   
> PID USER PR NI VIRT RES SHR S %CPU %MEM TIME+ COMMAND   
> 20284 root 25 5 98.7m 932 644 D 2.7 0.0 0:00.96 updatedb   

```# renice -n -5 20284``` - **zmienia wartośc nice** polecenia updatedb na -5


### Ograniczanie procesów za pomocą cgroup

### #TODO - strona 167 - usupełnić informacje na temat cgroup, dopisać mniej więcej to czym jest, nie opisywać samych grup 

### #TODO - szrobić ćwiczenia od nowa


# Skrypty powłoki 

## Debugowanie

**Przydatne !** - Na początku skryptu można umieścić polecenie set -x w celu wyświetlenia każdego polecenia wykonywanego przez skrypt.  

```$ set -x mojskrypt``` lub ```$ bash -x mojskrypt``` - wyświetla każdą wykonywana komendę ( **równwnież to co jest przypisane pod alias **)  
  
```nazwa_zmiennej=$(echo "test")``` - przypisanie komendy pod zmienną   
```BILANS="$BiezacyBilans"``` - przypisanie zmiennej BILANS wartości zmiennej BiezacyBilans   
  
```unset zmienna``` - zwolnienie zmiennej ```zmienna```  


## Zmienne specjalne

```man bash``` - Pełna lista zmiennych specjalnych

| Zmienna |Opis  |
|--|--|
| $? | wynik ostatniej komendy _( najczesciej 0/2 - 0 to komenda wykonana prawidlowo, wszystko inne to blad, nie musi byc to 2, liczba moze byc nawet ujemna )_   |
| $$ | numer procesu używanego przez komende   |
| !$ | ostatni użyty argument   |
| $0 | nazwa programu   |
| $1 | argumenty, zaczynaja sie od jednego, nie musi byc to jeden  |
| $# | Liczba podanych parametrów |
| $* | Wszystkie parametry jako string |
| $@ | Podane parametry w postaci tablicy |



##  Odczytanie danych podanych przez użytkownika

```bash
# secret, ukrywa znaki wpisywane przez użytkownika
read -s   

# prompt, tekst dla uzytkownika
read -p "$Tekst_dla_uzytkownika"

# Komenda wyświetla wiadomośc i zapisuje podane wartość do zmiennej **wiek** i **wzrost**
read -p "Ile masz lat i wzrostu" wiek wzrost

# Prompt, secret, pobranie pierwszego parametru od użytkownika do zmiennej USER_PASSWORD
read -s -p "Enter a password for the new user "$1": " USER_PASSWORD  

### #TODO - Sprawdzić jak to opisać 
$MIASTO jest skróconym zapisem ${MIASTO}
```  


### Przykłady przypisania zmiennych w powłoce bash 
Konstrukcja Znaczenie
${zmienna:-wartość} Jeżeli zmienna nie jest ustawiona bądź jest pusta, wówczas zostanie używa wartość.
${zmienna#wzorzec} Usunięcie krótszego dopasowania wzorca z początku wartości zmiennej.
${zmienna##wzorzec} Usunięcie dłuższego dopasowania wzorca z początku wartości zmiennej.
${zmienna%wzorzec} Usunięcie krótszego dopasowania wzorca z końca wartości zmiennej.
${zmienna%%wzorzec} Usunięcie dłuższego dopasowania wzorca z końca wartości zmiennej.


**Przykłady użycia przypisać z tabeli powyżej** 

> $ THIS="Przykład"
> $ THIS=${THIS:-"Nieustawiona"}
> $ THAT=${THAT:-"Nieustawiona"}
> $ echo $THIS
> Przykład
> $ echo $THAT
> Nieustawiona


W poniższym przykładzie zmienna MOJANAZWAPLIKU otrzymuje wartość /home/janek/
mojplik.txt. Następnie zmiennej PLIK zostaje przypisana wartość mojplik.txt, natomiast
zmiennej KATALOG wartość /home/janek. W zmiennej NAZWA nazwa pliku zostaje skrócona
do mojplik, a zmienna ROZSZERZENIE przechowuje wartość txt. (W celu wypróbowania
przedstawionych tutaj przykładów należy je po prostu wpisać w powłoce, podobnie jak
w przypadku poprzedniego przykładu. Następnie wartości zmiennych można wyświetlić
za pomocą polecenia echo). Wpisz kod przedstawiony po lewej stronie; informacje
zamieszczone po prawej stronie wyjaśniają sposób działania poszczególnych poleceń.
MOJANAZWAPLIKU="/home/janek/mojplik.txt" # Zdefiniowanie wartości zmiennej

> MOJANAZWAPLIKU  
> PLIK=${MOJANAZWAPLIKU##*/} # PLIK otrzymuje wartość "mojplik.txt"  
> KATALOG=${MOJANAZWAPLIKU%/*} # KATALOG otrzymuje wartość "/home/janek"  
> NAZWA=${PLIK%.*} # NAZWA otrzymuje wartość "mojplik"  
> ROZSZERZENIE=${PLIK##*.} # ROZSZERZENIE otrzymuje wartość "txt"  


1. Inkrementacja

```$ I=0```
```$ echo Wartość po inkrementacji wynosi $((++I))```
> Wartość  po inkrementacji wynosi 1


2. Polecenia if…then

```bash
ZMIENNA=1
if [ $ZMIENNA -eq 1 ] ; then
echo "Zmienna ma wartość 1"
fi
```

### Wszystkie instrukcje warunkowe 
```man test``` - wszystkie instrukcje warunkowe 

- ```=``` - Stringi są równe 
- ```!=``` - Stringi są różne 

- ```-eq``` - Liczby są równe


elif - else if  
```bash 
if [ -f "$nazwapliku" ] ; then
echo "$nazwapliku to zwykły plik"
elif [ -d "$nazwapliku" ] ; then
echo "$nazwapliku to katalog"
else
echo "Nie mam pojęcia, czym jest $nazwapliku"
fi
```

Domlyślnie if zwraca 0 lub 1, podobnie jak wykonywany program, **0 oznacza prawdę**

### Exitcode
**Dodawanie innych exit kodow pomaga uzytkownikom**
* Exitcode wieksze niz 0 mozemy definiowac sami 
* Exitcode 0 - kod wykonany prawidlowo 
* Exitcode 1 i kazdy wiekszy - kod wykonany z bledem 

np. ```exit 141```


- ```&&``` - jeżeli polecenie **wykonało się** poprawnie to wykonuje następne
- ```||``` - jeżeli polecenie **nie wykonało się** poprawnie to wykonuje następne 

```bash
nazwakatalogu=mojkatalog
[ -e $nazwakatalogu ] && echo $nazwakatalogu już istnieje || mkdir $nazwakatalogu
```


3. Case
### #TODO - case - opisać jakoś sensownie strona 180


4. Pętla for…do

Konstrukcja pętli for

```bash
for ZMIENNA in LISTA
do
{ polecenia }
done
```

5. Pętle while…do i until…do

### #TODO - strona 182 - może coś opisać 


6. Przydatne programy 

### #TODO - sed - dodać opis, strona 183

# #TODO - Strona 186 - ćwiczenia do rozdziału, do zrobienia 


# Administracja systemem Linux

## Podstawowa administracja systemem Linux

### sudo/root 

- ```visudo ``` - służy do ecycji plików jako root, zapis działa nawet gdy nikt nie ma do niego prawa 

- ```/etc/sudoers``` - Plik w którym nadawane są uprawnienia sudo 

    ```janek ALL=(ALL) ALL``` - Nadanie użutkownikowi pełnych uprawnień sudo w pliku **sudoers**

Domyślnie sudo działa bez wpisywania hasła przez 5 minut, zmiany można dokonać w **/etc/sudoers** edytując wartość zmiennej **passwd_timeout**


### Pliki konfiguracyjne

- ```$HOME``` - osobiste pliki konfiguracyjne

- ```/etc``` - pliki konfiguracyjne które wpływają na cały system
    - ```/etc/httpd``` — katalog zawiera różne pliki służące do konfiguracji zachowania serwera
    WWW Apache
    - ```/etc/mail``` — pliki konfigurujące usługę poczty elektronicznej (sendmail).
    - ```/etc/postfix``` — pliki konfiguracyjne agenta transportu poczty elektronicznej (postfix)
    - ```/etc/cups``` — katalog zawiera pliki używane do konfiguracji usługi drukowania CUPS.



### Wybrane spośród najbardziej interesujących plików konfiguracyjnych w katalogu /etc
##### Tabela 8.1 strona 203

| Plik | Opis |
|--|--|
| bashrc | Ustawienia konfiguracyjne powłoki bash, których zasięg obejmuje cały system. (W niektórych dystrybucjach Linuksa plik nosi nazwę bash.bashrc). |
| crontab | Ustawienie godzin uruchamiania zautomatyzowanych zadań oraz zmiennych powiązanych ze środowiskiem cron (na przykład SHELL i PATH). |
| exports | Plik zawiera listę katalogów lokalnych dostępnych do współdzielenia ze zdalnymi komputerami za pomocą Network File System (NFS). |
| fstab | Identyfikacja najczęściej stosowanych urządzeń magazynujących dane (dysk twardy, napędy DVD i CD-ROM itd.) oraz miejsc zamontowania ich w systemie Linux. Plik jest używany przez polecenie mount do wyboru systemów plików montowanych podczas uruchamiania komputera. |
| group | Identyfikacja nazw oraz identyfikatorów grup (GID), które zostały zdefiniowane w systemie. Uprawnienia grup w Linuksie są definiowane przez drugi bądź trzeci zbiór bitów rwx (read, write, execute) powiązanych z każdym plikiem i katalogiem. |
| gshadow | Zawiera zaszyfrowane hasła grup |

 


### journalctl, przeglądania dziennika zdarzeń systemd

Proces uruchamiania komputera, jądro oraz wszystkie usługi zarządzane przez systemd kierują swoje komunikaty stanu i błędów bezpośrednio do dziennika systemd.

Przykłady użycia polecenia ```journalctl``` :

```bash
journalctl
journalctl --list-boots | head
```
> -2 93bdb6164... Sat 2020-01-04 21:07:28 EST—Sat 2020-01-04 21:19:37 EST
> -1 7336cb823... Sun 2020-01-05 10:38:27 EST—Mon 2020-01-06 09:29:09 EST
> 0 eaebac25f... Sat 2020-01-18 14:11:41 EST—Sat 2020-01-18 16:03:37 EST

```bash
journalctl -b 488e152a3e2b4f6bb86be366c55264e7
journalctl -k
```

- Wszystkie komunikaty  
    - ```journalctl``` - wywoływane bez opcji pozwala przejrzeć wszystkie komunikaty zapisane w dzienniku systemd
    - ```journalctl -a``` - Wyświetla wszystkie kolumny
    - ```journalctl -f``` - wyświetlanie journalctl na bierząco

- Bootowanie  
    - ```journalctl --list-boots``` - wyświetla identyfikatory rozruchu dla każdej operacji uruchomienia systemu i czas w któym nastąpiły
    - ```journalctl -b [ID bootowania]``` - wyświetla informacje dotyczące określonej operacji uruchomienia systemu

- Komunikaty jądra   
    - ```journalctl -k``` - Wyświetlenie jedynie komunikatów jądra 

- Konkretna usługa   
    - ```journalctl _SYSTEMD_UNIT=sshd.service``` - Opcje _SYSTEMD_UNIT= umożliwiają wyświetlenie komunikatów dla konkretnych usług (tutaj jest to sshd) albo dla innego pliku systemd (np. inna usługa lub punkt montowania).

- Priorytet komunikatów   
    - ```journalctl PRIORITY=0``` - Komunikaty powiązane z określonym poziomem rejestrowania danych, dla opcji **PRIORITY=** przypisujemy wartość z przedziału od 0 do 7, 0 to komunikaty krytyczne 


### rsyslogd 

**rsyslogd** - odpowiadaa za zbieranie komunikatów oraz kierowanie ich do plików dzienników zdarzeń lub zdalnych hostów rejestrowania danych. 
Zapisuje informacje w pliku **/etc/rsyslog.conf**. 
Komunikaty są zazwyczaj kierowane do plików dzienników zdarzeń, które zwykle znajdują się w katalogu /var/log, choć w celu zapewnienia bezpieczeństwa nie zawsze tak jest, 

Przykłady najczęściej spotykanych plików : 

- ```boot.log``` — zawiera komunikaty generowane w trakcie uruchamiania usług podczas startu systemu.
- ```messages``` — zawiera wiele ogólnych informacji o systemie.
- ```secure``` — zawiera komunikaty związane z kwestiami bezpieczeństwa, na przykład dotyczące logowania i innych zadań związanych z uwierzytelnianiem użytkowników.


### Sprawdzanie komponentów komputera

### #TODO - # Strona 208 - dmesg do opisania 
- ```dmesg``` - wyświetla obecną wersję jądra, print or control the kernel ring buffer

- ```lspci``` - wyświetla listę szyn PCI w komputerze i podłączone do nich urządzenia.
    - ```lspci -v``` lub ```lspci -vvv``` - dodanie jednego **v** lub więcej **v** wyświetla więcej informacji szczegółowych

- ```lsusb``` - wyświetla informacje dotyczące wejść USB oraz podłączonych do nich urządzeń
    - ```lsusb -v``` lub ```lsusb -vvv``` - podobnie jak przy lspci dodanie jednego lub więcej parametru **v** wyświetla dodatkowe informacje 

- ```lscpu``` - wyświetla informacje na temat procesora 


### Praca z wczytywanymi modułami

Moduły jądra są instalowane w podkatalogach katalogu /lib/modules. Nazwa katalogu bazuje
na wersji jądra. Na przykład jeśli jądro jest w wersji 5.3.8-200.fc30.x86_64, to moduły dla niego
będą się znajdowały w katalogu /lib/modules/5.3.8-200.fc30.x86_64.


- ```lsmod``` - wyświetla listę aktualnie wczytanych modułów jądra

- ```modinfo``` - wyświetla informacje o dowolnym z wczytanych modułów 
    - ```modinfo -d e1000``` - opis modułu e1000 (moduł do obsługi karty sieciowej)
        > Intel(R) PRO/1000 Network Driver
    - ```modinfo -a e1000``` - autor 
        > Intel Corporation, <linux.nics@intel.com>
    - ```modinfo -n e1000``` - katalog zawierający  
        > /lib/modules/4.18.0-348.7.1.el8_5.x86_64/kernel/drivers/net/ethernet/intel/e1000/e1000.ko.xz

### Wczytywanie modułów

- ```modprobe``` - Dodawanie modułów do działającego jądra, **po restarcie systemu wczytane moduły nie będą już dostępne**, aby były należy dodać wiersz z poleceniem modprobe do skryptów startowych, dodawać można moduły,

    Przed załadowaniem moduły muszą zostać wcześniej skompilowane i zainstalowane w katalogu **/lib/modules**, 
    przykładem dla którego możemy chcieć załadować moduł jest dodanie nowego systemu plików  

    **modprobe** wczytuje moduły tymczasowo ( do czasu restartu ), aby załadować je na stałe dodajemy **modprobe** do skryptów startowych systemu

- ```rmmod``` - Usuwanie modułów

    - ```rmmod parport_pc``` - Przykładowe usunięcie modułu **parport_pc**

    Jeżeli moduł jest w użyciu, trzeba spróbować zamknąć proces używający danego
    urządzenia, a następnie ponownie wydać polecenie rmmod. 

    - ```modprobe -r [nazwa_modułu]``` - usunięcie modułu razem z modułami zależnymi od wskazanego do usunięcia  


### Strona 214 ćwiczenia do rozdziału


Wykonanie do sprawdzenia 

1. sudo systemctl sart  
3. sudo find /var/spool ! -user root -ls


9. sudo modprobe bttv
lsmod | grep bttv

Tak, razem z modułem bttv zostały dodane też kolejne 

10. sudo modprobe -r bttv
lsmod | grep bttv




## Instalacja systemu Linux

- **kdump** - włączenie tej opcji powoduje, że pewna ilość pamięci RAM zostanie zarezerwowana do przechwycenia zawartości jądra w przypadku jego awarii

- Pliki typu kickstart - Skrypty umieszczane w plikach typu kickstart mogą wykonywać wybrane polecenia przed skonfigurowaniem
lub po skonfigurowaniu systemu Linux przez program instalacyjny, np. dodawaanie użytkowników, zmiana uprawnień, pobieranie plików przez sieć
Podczas instalacji RHEL plik typu kickstart zawierający udzielone odpowiedzi na wszystkie pytania programu instalacyjnego będzie dostępny jako /root/anaconda-ks.cfg. Można go wykorzystać w trakcie następnego procesu instalacji. 

Więcej informacji w podręczniku str 279 

[Tutorial dot kickstar od RedHata](https://access.redhat.com/documentation/en-us/red_hat_enterprise_linux/8/html/performing_an_advanced_rhel_installation/performing_an_automated_installation_using_kickstart)


### #TODO - jak zbackupować całość systemu 

![Instalacja](instalacja_linux_1.png)



## Opcje rozruchowe dla plików typu kickstart i zdalnych repozytoriów
Strona 234


## Partycjonowanie dysku twardego 
strona 235


## Używanie programu uruchamiającego GRUB

### rpm

**rpm nie instaluje zależności potrzebnych do zainstalowania danego pakietu, do zainstalowania pakietu potrzebna jest dokładna ścieżkla pliku .rmp**


```-q``` - querry  
```-i``` - information  
```-l``` - list files in a package 
```-c``` - configfiles 
```-v``` - sprawdzenie czy jakieś pliki nie zostały zmodyfikowane ? doczytać 

### #TODO - Przykłady poniżej do opisania 

- rpm -qpi - wyświetla informacje o pakiecie  
- rpm -qpc - wyświetla pliki konfiguracyjne 


```rmp -q firefox``` 
> firefox-67.0-4.fc30.x86_64


```rmp -qi firefox```
> Name : firefox  
Version : 67.0  
Release : 4.fc30  
Architecture: x86_64  
Install Date: Sun 02 Jun 2019 09:37:25 PM EDT  
Group : Unspecified  
Size : 266449296  
License : MPLv1.1 or GPLv2+ or LGPLv2+  
Signature : RSA/SHA256, Fri 24 May 2019 12:09:57 PM EDT, Key ID ef3c111fcfc659b9  
Source RPM : firefox-67.0-4.fc30.src.rpm  
Build Date : Thu 23 May 2019 10:03:55 AM EDT  
Build Host : buildhw-08.phx2.fedoraproject.org  
Relocations : (not relocatable)  
Packager : Fedora Project  
Vendor : Fedora Project  
URL : https://www.mozilla.org/firefox/  
Bug URL : https://bugz.fedoraproject.org/firefox  
Summary : Mozilla Firefox Web browser  
Description :  
Mozilla Firefox is an open-source web browser, designed for standards  
compliance, performance and portability.  


### yum

**yum instaluje pakiet razem z jego zależnościami na podstawie repozytoriów, w nowych wersjach RHEL yum jest linkem do dnf** 

Repozytoria yum mogą być umieszczane w katalogu, na serwerze WWW (http://), FTP (ftp://), CD lub DVD albo w katalogu lokalnym (file:///).   
Położenie tych repozytoriów jest następnie przechowywane w pliku użytkownika systemu ```/etc/yum.conf``` lub częściej , w oddzielnych plikach konfiguracyjnych w katalogu ```/etc/yum.repos.d``` ( obecnie pliki konfiguracyjne te są linkami do plików dnf )

```yum [opcje] polecenie``` - podstawowa składnia 
```yum install firefox``` - instalacja pakietu firefox

### yum.conf 

strona 252 - dopisać informacje na temat plików konfiguracyjnych 

### Instalacja pakietu przy pomocy yum 

1. Sprawdzanie pliku /etc/yum.conf

### #TODO - Dodać opis

2. Sprawdzanie plików /etc/yum.repos.d/*.repo

Repozytoria oprogramowania mogą być włączane przez umieszczanie w katalogu /etc/yum.repos.d plików z rozszerzeniem .repo wskazujących położenie jednego lub więcej repozytoriów.

Przykład dla pliku ```/etc/yum.repos.d/myrepo.repo```

> [myrepo]  # Nazwa repozytorium  
name=Moje repozytorium  # Prosty opis  
baseurl=http://myrepo.example.com/pub/myrepo    # Położenie repo, lokalne zaczynają się od ( file:/// )   
enabled=1   # Opcja wskazuje czy dane repozytorium jest aktywne  
gpgcheck=1  # Sprawdzenie klucza, spradza czy repozytorium nie zostało zmienione  
gpgkey=file:///etc/pki/rpm-gpg/MYOWNKEY # klucz  


3. Pobieranie z repozytorium YUM pakietów RPM i metadanych

Po wydaniu polecenia yum zostają sprawdzone wszystkie repozytoria, co oznacza pobranie do systemu lokalnego metadanych o wszystkich znajdujących się w nich pakietach.

Metadane są w systemie lokalnym przechowywane w katalogu ```/var/cache/yum```. Wszelkie kolejne zapytania dotyczące pakietów, grup pakietów lub innych informacji o repozytorium
są pobierane z buforowanych metadanych, aż do upływu czasu ich ważności.

**Domyślnie czas ważności to 48 godzin dla dnf**, można go zmienić za pomocą opcji **metadata_expire w pliku /etc/yum.conf**.

Następnie polecenie yum szuka pakietów wskazanych do instalacji i sprawdza, czy wymagane są pakiety zależne, po przygotowaniu listy pakietów prosi o potwierdzenie a następnie instaluje.


4. Instalowanie pakietów RPM w systemie plików Linuksa

Po pobraniu do katalogów tymczasowych wszystkich niezbędnych pakietów narzędzie
yum wykonuje polecenia rpm dla każdego instalowanego pakietu.

Jeżeli pakiet zawiera jakiekolwiek skrypty wykonywane przed lub po instalacji (np. odpowiedzialne za utworzenie specjalnego konta użytkownika lub katalogów), zostają one uruchomione.


5. Przechowywanie w lokalnej bazie danych RPM medadanych repozytorium YUM

Metadane znajdujące się w instalowanym pakiecie RPM zostają skopiowane do lokalnej **bazy danych RPM**. 

Gdy informacje dotyczące zainstalowanych pakietów znajdują się w lokalnej bazie RPM, można wykonywać do niej zapytania. 
Np. można sprawdzić zainstalowane pakiety, wyświetlić komponenty tych pakietów, a także zajrzeć do skryptów i dzienników zdarzeń powiązanych z poszczególnymi pakietami. 
Istnieje również możliwość zweryfikowania zainstalowanych pakietów względem **bazy danych RPM**.

Polecenie **rpm** to najlepsze narzędzie do wykonywania zapytań do **bazy danych RPM**.


### #TODO - strona 254 - sprawdzić czy jest zostawić tak długo opisane kroki czy ich nie skrócić 


### Wyszukiwanie pakietów za pomocą yum 

```yum search editor``` - wyszukuje słowa **editor** w nazwie lub opisie pakietów 
>...  
eclipse-veditor.noarch : Eclipse-based Verilog/VHDL plugin  
ed.x86_64 : The GNU line editor  
emacs.x86_64 : GNU Emacs text editor  

```yum info emacs``` - wyświetlenie informacji o pakiecie
> yum info emacs  
Name : emacs  
Epoch : 1  
Version : 26.2  
Release : 1.fc30  
...  

```yum provides dvdrecord``` - Znajduje pakiet po nazwie polecenia, pliku konfiguracyjnego lub biblioteki
> wodim-1.1.11-41.fc30.x86_64 : A command line CD/DVD recording program   
Repo : fedora  
Matched from:  
Filename : /usr/bin/dvdrecord  


- Podpolecenie ```list``` pozwala wyświetlić listę nazw pakietów na różne sposoby. 
    - ```yum list "nazwa_pakietu"``` - wyświetla wersję i repozytorium danego pakietu
    - ```yum list available``` - wyświetla dostępne pakiety
    - ```yum list installed``` - wyświetla zainstalowane pakiety 
    - ```yum list all``` - wyświetla wszystkie pakiety 

```yum deplist emacs``` - Wyświetla komponenty zależne (dependency) a także dostarczane w samym pakiecie (provider) 
> yum deplist emacs | less  
package: emacs-1:26.1-8.fc30.x86_64  
dependency: /bin/sh  
provider: bash-5.0.7-1.fc30.i686  



### Instalowanie i usuwanie pakietów 

```yum install emacs``` -  zainstalowanie jednego lub więcej pakietów razem z niezbędnymi zależnościami
```yum reinstall emacs``` - Od nowa instaluje wymagane zależności
```yum remove emacs``` - Usuwa pakiet emacs


Podpolecenie ```history``` pozwala przejżeć historię operacji ```yum``` i je wycofać za pomocą opcji ```history undo```


- ```yum history``` - wyświetla historię transakcji polecenia ```yum```
    > ID | Command line | Date and time | Action(s) | Altered  
    12 | install emacs | 2019-06-22 11:14 | Install | 7  
     3 | install tmux  | 2022-01-19 06:33 | Install | 1  
     2 | update -y     | 2022-01-19 06:28 | I, U    | 91  
    ...  

- ```yum history info 12``` - wyświetla informacje na temat transakcji o **ID 12**
    > Transaction ID : 12  
    ...  
    Command Line : install emacs  
    ...  

- ```yum history undo 12``` - wycofuje transakcję z **ID 12** ( w tym przypadku instalacji emacs )


### Uaktualnianie pakietów

```yum check-update``` - sprawdza czy dostępne są updaty 

```yum update``` - updatuje **wszystkie** pakiety dla których dostępne są aktualizacje 

```yum update cups``` - updatuje **jedynie pakiet cups**, jeżeli razem z nim muszą zostać uaktualnione także pewne pakiety zależne, one również będą pobrane i zainstalowane.


### Uaktualnianie grup pakietów

```yum grouplist``` - Wyświetlenie listy grup dostępnych pakietów 
> Available Environment Groups:  
Fedora Custom Operating System  
Minimal Install  
Fedora Server Edition  
...  
Installed Groups:  
LibreOffice  
GNOME Desktop Environment  
Fonts  
...  
Available Groups:  
Authoring and Publishing  
Books and Guides  
C Development Tools and Libraries  
...  

```yum groupinfo gnome``` - wyświetlenie opisu grupy LXDE, pakietów obowiązkowych, domyślnych i opcjonalnych   
> Group: GNOME    
 Description: GNOME is a highly intuitive and user-friendly desktop environment.   
 Mandatory Packages:  
   ModemManager   
   NetworkManager-adsl  
 ...  

```yum groupinstall gnome``` - instalacja pakietów grupy gnome

```yum groupremove LXDE``` - usunięcie grupy pakietów gnome 


### Konserwacja bufora i bazy danych pakietów RPM


Opróżnienie bufora to operacja, którą należy przeprowadzać od czasu do czasu. Jeżeli
zdecydujesz się na zachowanie pobranych pakietów po ich zainstalowaniu (domyślnie są
usuwane, na podstawie opcji keepcache=0 w pliku /etc/yum.conf), wówczas katalogi bufora
(/var/cache/yum) mogą się zapełnić. Metadane przechowywane w katalogach bufora mogą
zostać usunięte, co podczas następnego wykonania polecenia yum spowoduje pobranie od nowa
metadanych dla wszystkich włączonych repozytoriów. Oto przykład opróżnienia metadanych:

- Opróżnianie bufora yum

    ```yum clean packages```
    > 14 files removed  

    ```yum clean metadata```
    > Cache was expired  
    16 files removed  

    ```yum clean all```
    > 68 files removed  


- Sprawdzenie i naprawienie bazy danych yum

    ```yum check``` - Sprawdza bazę danych **yum** w przypadku jej ewentualnego uszkodzenia 
    > error: db5 error(11) from dbenv->open: Resource temporarily  
    unavailable  
    error: cannot open Packages index using db5-Resource temporarily  
    unavailable(11)  
    error: cannot open Packages database in /var/lib/rpm  
    Error: Error: rpmdb open failed  

    ```rpm --rebuilddb``` - odbudowuje uszkodzoną bazę danych yum 

    ```yum check``` - po raz kolejny sprawdza bazę danych **yum** w celu potwierdzenia jej naprawienia 


**rpm to polecenie, które najlepiej sprawdza się w pracy z lokalną bazą danych RPM**


```dnf download firefox``` - **samo pobranie** pakietu **rpm** dla firefox 
> firefox-60.7.0-1.el8_0.x86_64.rpm 6.1 MB/s | 93 MB 00:15  


### rmp, instalowanie, analizowanie i weryfikowanie oprogramowania


```rpm --install ./zsh-5.5.1-6.el8.x86_64.rpm``` - **instalacja** pakietu **zsh** znajdującego się w lokalnym folderze

```rpm --update ./zsh-5.5.1-6.el8.x86_64.rpm``` - **update** pakietu **zsh** do wersji z pliku znajdującego się w lokalnym folderze,  
```--update lub -U``` - instaluje pakiet **również jeżeli nie znajdował się wcześniej w systemie**  
```--freshen lub -F``` - instaluje pakiet **tylko jeżeli znajdował się wcześniej w systemie**  
> Verifying... ######################### [100%]  
Preparing... ######################### [100%]  
1:zsh-5.5.1-6.el8 ######################### [100%]  

```rpm --Uhv ./zsh-5.5.1-6.el8.x86_64.rpm``` - **update, hash, verbose** - aktualizacja z użyciem opcji które mówią więcej o procesie

```rpm -e emacs``` - usunięcie pakietu 


### Pobieranie informacji o pakiecie


```rpm -qi zsh``` - opis
> Name : zsh  
Version : 5.5.1  
Release : 6.el8  
...  

```rpm -ql zsh``` - lista plików
> /etc/skel/.zshrc  
/etc/zlogin  
/etc/zlogout  
...  

```rpm -qd zsh``` - dokumentacja  
> /usr/share/doc/zsh/BUGS  
/usr/share/doc/zsh/CONTRIBUTORS  
/usr/share/doc/zsh/FAQ  
...  

```rpm -qc zsh``` - pliki konfiguracyjne
> /etc/skel/.zshrc   
/etc/zlogin  
/etc/zlogout  
...  


### #TODO - zastanowić się ile z tego potrzebuję, strona 263 

Opcje można wykorzystać do pobrania dowolnych informacji znajdujących się w pakiecie RPM.
To pozwala ustalić, które pakiety RPM są konieczne do zainstalowania (--requires), jaka
wersja oprogramowania jest dostarczana (--provides), jakie skrypty zostaną wykonane przed
zainstalowaniem i po zainstalowaniu pakietu RPM lub jego usunięciu (--scripts), a także jakie
zmiany zostały wprowadzone w pakiecie RPM (--changelog):


Wszystkie wykonywane dotąd zapytania dotyczyły lokalnej bazy danych RPM. Jeżeli dodać
opcję -p do zapytania, wówczas informacje zostaną pobrane z pliku RPM znajdującego się
w katalogu lokalnym. Opcja -p to doskonały sposób na przeanalizowanie otrzymanego pakietu,
zanim zostanie zainstalowany w systemie.


Jeżeli jeszcze tego nie zrobiłeś, pobierz pakiet zsh i umieść go w katalogu lokalnym (dnf download
zsh). Następnie wykonaj kilka poleceń rpm pobierających informacje o tym pakiecie:
\# rpm -qip zsh-5.7.1-1.fc30.x86_64.rpm Wyświetlenie informacji o danym pliku RPM
\# rpm -qlp zsh-5.7.1-1.fc30.x86_64.rpm Wyświetlenie wszystkich plików znajdujących się
´w danym pliku RPM
\# rpm -qdp zsh-5.7.1-1.fc30.x86_64.rpm Wyświetlenie dokumentacji znajdującej się
´w danym pliku RPM
\# rpm -qcp zsh-5.7.1-1.fc30.x86_64.rpm Wyświetlenie plików konfiguracyjnych znajdujących się
´w danym pliku RPM.


### Weryfikowanie pakietów RPM

Za pomocą opcji -V można sprawdzić pakiety zainstalowane w systemie i zobaczyć, czy
którykolwiek z komponentów został zmieniony od chwili instalacji pakietu


W celu przywrócenie pakietu do jego stanu początkowego użyj polecenia rpm z opcją
--replacepkgs

### Zarządzanie oprogramowaniem w firmie

Serwery Satellite (Spacewalk). Systemy Red Hat Enterprise Linux można wdrażać za
pomocą tzw. serwerów Satellite, które w zakresie zarządzania i wdrażania nowych
systemów i uaktualnień mają dokładnie tę samą funkcjonalność co Red Hat CDN.
Systemy RHEL można skonfigurować do automatycznego pobierania uaktualnień
z serwerów Satellite. Zbiory pakietów określane mianem Errata, które służą do
usuwania określonych problemów, można szybko i automatycznie wdrażać
w wymagających tego systemach.


Obrazy kontenerów. Zamiast instalować poszczególne pakiety w systemie, kilka lub
kilkaset pakietów RPM można umieścić w obrazie kontenera. Jest on podobny do RPM
pod tym względem, że przechowuje zestaw oprogramowania. Jednocześnie różni się
od RPM tym, że obraz można znacznie łatwiej niż RPM dodać do systemu, uruchomić
i usunąć.


### #TODO - Ćwiczenia, strona 267   

## Zarządzanie kontami użytkowników



### useradd - Dodawanie użytkowników


### #TODO - do poprawienia procedura, opis i tabela, Strona 272  

- ```useradd```
    Polecenie useradd stosuje wartości domyślne podczas tworzenia nowych kont, które odczytuje z plików /etc/login.defs oraz /etc/default/useradd.

- Tworzenie nowego użytkownika przy pomocy 

    ```useradd -c "Maria Kowalska" maria```
    ```passwd maria```

**Po utworzeniu konta użutkownika dobrze jest się na nim zalogować, sprawdzić home folder i ewentualne uprawnienia**

Podczas tworzenia konta dla Marii polecenie useradd wykonuje następujące zadania:

- Odczyt plików ```/etc/login.defs``` i ```/etc/default/useradd``` w celu pobrania wartości domyślnych używanych w trakcie tworzenia nowego konta.
- Sprawdzenie parametrów polecenia powłoki i określenie, które wartości domyślne należy nadpisać.
- Utworzenie wpisu nowego użytkownika w plikach ```/etc/passwd``` i ```/etc/shadow```, na podstawie wartości domyślnych oraz podanych w poleceniu powłoki.
- Utworzenie wszystkich wpisów grup w pliku ```/etc/group```. (Dystrybucja Fedora tworzy grupę, używając nazwy nowego użytkownika).
- Utworzenie w katalogu ```/home``` katalogu domowego na podstawie nazwy użytkownika.
- Skopiowanie wszystkich plików z katalogu ```/etc/skel``` do katalogu domowego nowego użytkownika. Katalog wzorcowy zawiera zwykle skrypty startowe logowania i aplikacji.

### Strona 273 do tabeli 

| Opcja | Opis |
|--|--|
| -c *"komentarz"* | Komenatrz do opisu konta, najczęściej pełne imię i nazwisko |
| -d *katalog_domowy* | Wartością domyślną jest */home/username* ale możemy to zmienić |
| -D | **Podane informacje zostaną zapisane jako ustawienia domyślne** dla wszystkich nowo tworzonych kont. Nowe konto użytkownika nie zostanie utworzone. |
| -e data_upływu_ważności_konta | |
| -g nazwa_grupy | Ustawienie grupy podstawowej |
|  -G lista_grup |  **Dodanie nowego użytkownika do rozdzielonej przecinkami listy grup** (na przykład -G wheel,sales,tech,lunch). W poleceniu usermod, musi zostać podane -aG samo -G usuwa dotychczasowe grupy i nadpisuje je podanymi w poleceniu  |
| -k katalog_wzorcowy |  |
| -m |  |
| -M |  |
| -n |  |
| -o |  |
| -p *hasło* |  |
| -s *shell* |  |
| -u  |  |



-c komentarz
-c "miejsce na komentarz"
Opcja powoduje dodanie opisu do nowego konta. Bardzo często opisem jest pełne imię i nazwisko
użytkownika. Słowo komentarz należy zastąpić danymi użytkownika konta (-c janek).
W przypadku wielu słów trzeba zastosować cudzysłów (-c "janek kowalski").
-d katalog_domowy Opcja ustala katalog domowy dla tworzonego konta. Wartością domyślną jest nazwa odpowiadająca
loginowi konta i umieszczona w katalogu /home. Argument katalog_domowy należy zastąpić
nazwą używanego katalogu (na przykład -d /mnt/home/janek).
-D Zamiast tworzyć nowe konto użytkownika, podane informacje zostaną zapisane jako ustawienia
domyślne dla wszystkich nowo tworzonych kont.
-e
data_upływu_ważności_konta
Ustalenie daty upływu ważności konta w postaci RRRR-MM-DD. Argument data_upływu_
´ważności_konta należy zastąpić datą, na przykład jeśli konto ma utracić ważność 5 maja
2022 roku, należy użyć opcji -e 2022-05-06.
-f -1 Ustalenie liczby dni, po których konto zostanie trwale zablokowane po upływie ważności hasła.
Wartością domyślną jest -1 i oznacza wyłączenie tej opcji. Wartość 0 powoduje, że konto zostanie
zablokowane natychmiast po upływie ważności hasła. Liczbę -1 trzeba zastąpić wybraną liczbą dni.
-g grupa Ustawienie grupy podstawowej (jak przedstawiono w pliku /etc/group) dla nowego użytkownika.
Słowo grupa należy zastąpić nazwą grupy (na przykład -g wheel). Jeżeli pominiesz tę opcję,
utworzona zostanie grupa o nazwie odpowiadającej nazwie użytkownika i stanie się ona grupą
podstawową dla nowo tworzonego użytkownika.
-G lista_grup Dodanie nowego użytkownika do rozdzielonej przecinkami listy grup (na przykład -G
wheel,sales,tech,lunch). Jeżeli później chcesz użyć opcji -G w poleceniu usermod,
musi zostać podane -aG zamiast po prostu -G. Gdy o tym zapomnisz, grupy dodatkowe
zostaną usunięte, a jedynymi przypisanymi grupami będą tylko te podane w tym miejscu.
-k katalog_wzorcowy Ustawienie katalogu wzorcowego zawierającego pliki konfiguracyjne oraz skrypty logowania, które
powinny zostać skopiowane do katalogu domowego tworzonego użytkownika. Ten parametr może
być użyty tylko w połączeniu z opcją -m. Wyrażenie katalog_wzorcowy należy zastąpić nazwą
wybranego katalogu. (Jeżeli opcja ta nie zostanie użyta, zastosowany będzie katalog /etc/skel).
-m Automatyczne tworzenie katalogu domowego użytkownika i skopiowanie plików z katalogu
wzorcowego (/etc/skel). W przeciwieństwie do Ubuntu w dystrybucjach Fedora i RHEL działanie
to jest automatycznie podejmowane, więc nie trzeba go wskazywać.
-M Katalog domowy nowego użytkownika nie zostanie utworzony, nawet jeśli domyślnie ustawione
zachowanie nakazuje jego utworzenie.
-n Wyłączenie domyślnego zachowania polegającego na utworzeniu nowej grupy, która odpowiada nazwie
i identyfikatorowi nowego użytkownika. Ta opcja jest dostępna w systemach Red Hat Linux. Inne
dystrybucje Linuksa zamiast tego powodują przypisanie nowego użytkownika do grupy o nazwie users.
-o Opcja używana wraz z -u uid do utworzenia konta użytkownika, który będzie miał taki sam
identyfikator jak inny użytkownik. (W ten sposób można posiadać dwie różne nazwy użytkownika
z prawem dostępu do takiego samego zestawu plików i katalogów).
-p hasło Ustalenie hasła dla tworzonego konta. Hasło powinno być zaszyfrowane. Zamiast podawania
w tym miejscu zaszyfrowanego hasła można po prostu później użyć polecenia passwd
użytkownik i dodać hasło dla danego użytkownika. (W celu wygenerowania hasła
zaszyfrowanego przez MD5 należy wydać polecenie openssl passwd).
-s powłoka Wskazanie powłoki używanej w tworzonym koncie. Słowo powłoka należy zastąpić wybraną
powłoką (na przykład -s /bin/csh).
-u id_użytkownika Ustawienie numeru identyfikacyjnego dla konta użytkownika (na przykład -u 1793). Bez użycia
opcji -u zachowanie domyślne polega na automatycznym przypisaniu pierwszego wolnego numeru.
W poleceniu zapis id_użytkownika trzeba zastąpić wybranym numerem identyfikacyjnym.
Te numery automatycznie przypisywane zwykłym użytkownikom rozpoczynają się od wartości
1000. Dlatego identyfikatory dla zwykłych użytkowników należy wybierać w sposób, który nie
będzie kolidował z automatycznie przypisywanymi identyfikatorami.


Każdy wiersz pliku /etc/passwd przedstawia konto pojedynczego użytkownika. 

- ```/etc/passwd``` - **Informacje na temat kont użytkowników** znajdują się w */etc/passwd* i są oddzielone dwukropkiem, 
znaczenie pola jest określane na podstawie położenia w wierszu,   
    - ```maria:x:1002:1007:Maria Kowalska:/home/maria:/bin/tcsh```   
    > login:hasło:user id:group id:komentarz:katalog domowy:shell   

- ```/etc/shadow``` zawiera **zaszyfrowane hasła użytkowników** i opcjonalnie o ich wygaśnięciu  
    - ```man 5 shadow``` - konstrukcja pliku   

- ```/etc/group``` - text file that **defines the groups on the system**. There is one entry per line, with the following format:  
    - ```wheel:x:10:mariusz```    
    > group_name:password:GID:user_list  

- ```/etc/skel``` - folder zawiera pliki domyślne, które będą kopiowane do katalogu domowego użytkownika
  

### useradd - Ustalanie ustawień domyślnych użytkownika

Polecenie useradd stosuje wartości domyślne podczas tworzenia nowych kont, które odczytuje z plików */etc/login.defs* oraz */etc/default/useradd*  
  
Zmiana wartości domyślnych dla **useradd** :

- ```man login.defs``` - wartości możliwe do nadania w pliku **login.defs**  

- ```useradd -D``` - wyświetlenie wartości domyślnych używanych obecnie przez **useradd**  
        Opcja ```-D``` służy również do zmiany wartości domyślnych  
        np. ```useradd -D -b /home/everyone -s /bin/tcsh``` - zmienia domyślny home-folder na */garage* i shell na *tcsh*  


### usermod - Modyfikowanie ustawień użytkownika

**usermod** - służy do modyfikowania ustawień użytkownika, wiele parametrów pokrywa się z **useradd**

- ```usermod -Ga sales,marketing, chris``` - **Dodanie użytkownika** chris **do grup** sales, marketing
**WAŻNE** - jeżeli opcja **-a** nie zostanie zastosowana to użytkownik zostanie dodany do grup do których nie należał i utraci członkostwo w dotychczasowych   

- ```man 8 usermod``` - pełna lista parametrów możliwych do zmiany 


### userdel - Usuwanie użytkownika

- ```userdel chris``` - usunięcie użytkownika *chris*, domyślnie usuwany **jest sam użytkownik** 

- ```userdel -r chris``` - usunięcie uytkownika *chris* **razem z katalogiem domowym**

Przed usunięciem użytkownika dobrze jest wydać polecenie find i wyszukać wszystkie pliki należące do tego użytkownika, 
samo usunięcie użytkownika nie zmienia właściciela pliku

```find / -user chris -ls``` - pliki ownera *po loginie*
```find / -uid 504 -ls``` - pliki ownera *po UID*

```find / -nouser -ls``` - odnalezienie plików *nienależących do nikogo*


### Grupy kont użytkowników

### #TODO - strona 279, ogarnąć jak działa polecenie newgrp i gpasswd

Każdy plik przypisany do grupy sales lub marketing jest dostępny dla użytkownika
maria z uprawnieniami dla grupy i pozostałych użytkowników (w zależności od tego,
które mają większy zasięg). Jeżeli użytkownik maria chce utworzyć plik z przypisanymi
do niego grupami sales i marketing, może użyć polecenia newgrp. W przykładzie
użytkownik maria wydaje polecenie newgrp, aby sales tymczasowo stała się jego grupą
podstawową, a następnie tworzy plik:

```bash
[sara]$ touch file1
[sara]$ newgrp sales
[sara]$ touch file2
[sara]$ ls -l file*
-rw-rw-r--. 1 sara sara 0 Jan 18 22:22 file1
-rw-rw-r--. 1 sara sales 0 Jan 18 22:23 file2
[sara]$ exit
```

Za pomocą polecenia newgrp można też umożliwić użytkownikowi tymczasowe przypisanie mu
grupy, bez faktycznego dodawania go do tej grupy. W tym celu ktoś z uprawnieniami roota może
wydać polecenie gpasswd (np. gpasswd sales). Następnie jeśli użytkownik wykona z poziomu
powłoki polecenie newgrp sales, będzie mógł tymczasowo użyć sales jako swojej grupy
podstawowej — wystarczy podać hasło grupy, gdy system o nie poprosi.


### Tworzenie grup kont

- **groupadd** - tworzenie grup 
    - ```groupadd kings``` - utworzenie grupy kings z pierwszym wolnym GID (group ID)    
    - ```groupadd -g 1325 jokers```- utworzenie grupy jokers o GID 1325

- **groupmod** - zmiana parametrów grupy 
    - ```groupmod -g 330 jokers``` - zmiana GID na 330
    - ```groupmod -n jacks jokers``` - zmiana nazwy grupy jokers 


## Definiowanie uprawnień za pomocą listy ACL


### #TODO - Strona 281 - do skrócenia  


### Definiowanie ACL za pomocą setfacl

- ```setfacl``` - modyfikuje uprawnienia (-m) lub usuwa uprawnienia ACL (-x) 

    - ```setfacl -m u:nazwa_użytkownika:rwx nazwa_pliku``` - setfacl modyfikuje uprawnienia dla pliku *nazwa_pliku*, 
        - ```u``` - wskazuje na nadanie uprawnień użytkownikowi 
        - ```g``` - nadanie uprawnień grupie 
        - ```rwx``` - to uprawnienia jakie zostają nadane w powyższym przykładzie

- ```getfacl``` -  Wyświetla ACLki dla pliku
    
    - ```getfacl ./a1```  
        > \# file: a1  
        \# owner: mariusz  
        \# group: mariusz  
        user::---  
        user:test:rwx                   #effective:r--  
        group::rwx                      #effective:r--  
        mask::r--   
        other::---   


        **WAŻNE**
          
        Wiersz **mask** określa jakie uprawnienia maksymalne może mieć użytkownik lub grupa - w tym przypadku **read** dla użytkownika **test**,  
        **mask** jest określany **na podstawie uprawnień zwykłej grupy** (*chmod nadaje*), 
        Nawet jeśli użytkownik otrzyma większe uprawnienia ACL to nie będą one miały zastosowania
        


    **Przykład użycia :**

    ```setfacl -m u:test:rwx ./a1``` 

    ```ls -l ./a1```
    > drwxrwxr-x+ 2 mariusz mariusz 6 Feb  1 09:20 a1  

    ```getfacl ./a1```  
    
    > \# file: a1  
    \# owner: mariusz  
    \# group: mariusz  
    user::rwx  
    user:test:rwx  
    group::rwx  
    mask::rwx  
    other::r-x  


Przy poleceniu **ls -l** w uprawnieniach w ```rw-rw-r--+``` trzeba zwracać uwagę na ```+```,  
**Oznacza to, że dla pliku są ustawione uprawnienia ACL**   
Wydanie polecenia **getfacl** dla tego pliku spowoduje wyświetlenie pełnych informacji o sposobie ustawienia ACL


## Określanie domyślnych uprawnień ACL


Zdefiniowanie domyślnych uprawnień ACL dla katalogu pozwala na ich dziedziczenie.  
Do zdefiniowania domyślnych uprawnień ACL służy opcja ```d:```    
    - ```setfacl -m d:g:market:rwx /tmp/maria/``` - polecenie sprawia, że w folderze maria wszystkie uprawnienia dla grupy market będą dziedziczone  
        > getfacl /tmp/maria/  
        \# file: tmp/maria/  
        \# owner: maria  
        \# group: maria  
        user::rwx  
        group::rwx  
        other::r-x  
        default:user::rwx  
        default:group::rwx  
        default:group:sales:rwx  
        default:group:market:rwx  
        default:<zero-width space>mask::rwx   
        default:other::r-x  

*Domyślnie uprawnienia do plików są nadawane bez execute*, tak samo jest w przypadku uprawnień odziedziczonych 



## Włączanie ACL

W RHEL systemy plików *xfs* i *ext* są automatycznie tworzone z włączoną obsługą ACL.

Jak włączyć ACL :  
    - Dodanie opcji acl do piątego pola w wierszu zdefiniowanym w pliku **/etc/fstab**, co powoduje automatyczne zamontowanie danego systemu plików podczas uruchamiania systemu.  
    - Umieszczenie wiersza acl w polu Default mount options w superbloku systemu plików, co powoduje użycie opcji acl podczas zarówno automatycznego, jak i ręcznego montowania systemu plików.  
    - Dodanie opcji acl do polecenia mount podczas ręcznego montowania systemu plików za pomocą polecenia mount.  



#### Sprawdzenie czy opcja acl została włączona, wyświetlenie opcji montowania systemu:

    ```mount | grep home```  
    > /dev/mapper/mybox-home on /home type ext4 (rw)  
  
    ```tune2fs -l /dev/mapper/mybox-home | grep "mount options"```  
    > Default mount options: user_xattr acl  
  

### Sposoby na zamontowanie opcji acl  

1. Dodanie opcji montowania **acl** za pomocą polecenia **tune2fs -o**  
   
    ```tune2fs -o acl /dev/sdc1```  
   
    ```tune2fs -l /dev/sdc1 | grep "mount options"```  
    > Default mount options: acl  
  
Potwierdzić można poprzez zamontowanie i próbę użycia ```setfacl```   


2. Dołączenie opcji **acl** do wiersza w pliku **/etc/fstab**  
    Krótki opis fstaba:   
    UUID    | mount_point | file_system | options | 4 i 5 opcja - man fstab  

    ```/dev/sdc1 /var/stuff ext4 acl 1 2```  
  
3. **Tymczasowe zamontowanie** systemu plików za pomocą **mount** i podanie opcji montowania acl  
  
    ```mount -o acl /dev/sdc1 /var/stuff```  

  
## Dodawanie katalogów współdzielonych przez użytkowników

##### Tabela 11.4, strona 285
![Litery i cyfry używane w specjalnych bitach uprawnień](https://github.com/mariuszkuswik/Nauka/blob/biblia/Linux/Obrazy/tabela_11_4.png)


## Bit GID - tworzenie katalogów współdzielonych przez grupy

**Bit GID** - gdy zostaje ustawiony dla katalogu *(2 lub g+s)*, wówczas **wszystkie pliki tworzone w tym katalogu zostają przypisane grupie katalogu.**
O tym, że *GID* jest przypisany świadczy *litera s* w miejscu execute dla grupy

- *Bit GID* można ustawić poprzez użycie *chmod g+s* lub dodając *2 na początku* uprawnień które nadajemy *np. chmod 2755*  - [Tabela 11.4](#tabela-114-strona-285)

    ```bash
    # Zmiana grupy dla folderu na shared_folder
    chgrp shared_folder GID_test_shared

    # Dodanie GID do folderu 
    chmod 2775 GID_test_shared/

    # Potwierdzenie dodania bitu GID ( s w miejscu execute dla grupy )
    ls -l GID_test_shared/
    > drwxrwsr-x. 2 mariusz shared_folder  4096 Feb  2 12:30 GID_test_shared

    # Grupą do której należy plik jest shared_folder - skutek przypisania GID
    ls -l test_file
    > -rw-rw-r--. 1 mariusz shared_folder 0 Feb 2 12:37 test_file
    ```


## Bit sticky - tworzenie katalogu, którego nie można łatwo usunąć

**Bit sticky** - gdy zostaje ustawiony dla katalogu *(1 lub u+s)*, wówczas **tylko użytkownik root lub właściciel katalogu może go usunąć.**
O tym, że *Sticky bit* jest przypisany świadczy *litera t w miejscu execute dla others*

- *Sticky Bit* można ustawić poprzez użycie *chmod u+s* lub dodając *1 na początku* uprawnień które nadajemy *np. chmod 1755*  - [Tabela 11.4](#tabela-114-strona-285)

    ```bash
    # Dodanie sticky bitu
    chmod 1777 Sticky_catalog/

    # Sprawdzenie czy bit został dodany - t w miejscu execute dla others oznacza, że tak
    ls -l Sticky_catalog
    drwxrwxrwt. 2 mariusz mariusz        4096 Feb  2 12:57 Sticky_catalog

    # Przelogowanie na użytkownika test 
    su test

    # Próba usunięcia pliku w folderze ze stickybitem nieudana 
    rm Sticky_catalog/test_file
    >rm: cannot remove 'Sticky_catalog/test_file': Operation not permitted 
    ```


### #TODO - Ćwiczenia do zrobienia, strona 289 


# Zarządzanie dyskami i systemami plików

## Partycjonowanie dysku twardego

### Tablica partycji

MBR - stara wersja, ograniczenie do 4 partycji podstawowych + parycje logiczne na partycji rozszerzonej, maksymalny rozmar 2TB  
GUID - nowa wersja, ograniczenie do 128 partycji podstawowych ( chyba tyle partycji), maksymalny rozmar 9,4ZB (zetabajty)


### parted - wyświetlanie i edycja partycji 

**cfdisk** - łatwiejsza wersja fdisku 

W razie problemów parted podpowiada po naciśnięciu *tab* 

**WAŻNE** - parted przeprowadza zmiany od razu, w przeciwieństwie do fdisk nie muszą one być zatwierdzane   
**WAŻNE** - RHEL 8 **może nie mieć** zainstalowanego *gdisk*, parted jest istotne    
  
```parted -l /dev/disk``` - wyświetla tablicę partycji   
  
```parted /dev/sdb```- Odpalenie parted dla /dev/sdb  
  
**parted** - Przydatne opcje w trybie interaktywnym  
- ```p``` - wyświetlenie partycji  
- ```mklabel gpt``` - zmiana tablicy partycji na gpt   
- ```mkapart``` - utworzenie nowej partycji   


### #TODO - strona 299, niestandardowe ćwiczenia do wykonania 

Tworzenie filesystemu 
```mkfs.filesystem_name``` 
```mkswap /dev/sdb2``` - Utworzenie filesystemu dla SWAPu 


```/proc/partitions``` - plik w którym możemy potwierdzić, że system faktycznie widzi nowe partycje 
```partprobe /dev/sbd``` - Załadowanie nowych partycji z dysku /dev/sdb


## Używanie menedżera partycji LVM


![LVM schemat](rys_12_1.png)

Rysunek 12.1 pokazuje, że najpierw tworzymy jeden lub więcej woluminów fizycznych (pv), używamy ich do utworzenia grupy woluminów (vg), aby następnie na jej podstawie tworzymy woluminy logiczne.

### #TODO - schemat przerobić na jakiś prostszy, opisowy 

Polecenia przeznaczone do pracy z poszczególnymi komponentami LVM rozpoczynają się od
pv, vg i lv.

WAŻNE - ```man lvm``` - zbiór większości komend potrzebnych do zarządzania LVM  

Wyświetlanie informacji na temat LVM :  

- ```pvdisplay /dev/disk_name``` - wyświetla woluminy fizyczne
    - ```pvs /dev/disk_name``` - alternatywna, kompaktowa wersja

- ```vgdisplay vg_name``` - wyświetla grupę woluminów
    - ```vgs vg_name``` - alternatywna, kompaktowa wersja


- ```lvdisplay vg_name``` -  wyświetla woluminy logiczne
    - ```lvs vg_name``` - alternatywna, kompaktowa wersja


LVM breaks up each physical volume into extents. A logical volume consists of a set of extents. Each extent is either wholly unused, or wholly in used by a particular logical volume: extents cannot be subdivided. Extents are the elementary blocks of LVM allocation.

**This extent is the minimum amount by which the logical volume may be increased or decreased in size.**

https://unix.stackexchange.com/questions/341077/lvm-volume-group-what-are-extents

## Tworzenie woluminów logicznych LVM

**/dev/mapper** - ścieżka w której znajdują się *lvm*y 

1. Nadanie flagi lvm w programie parted 
    ```bash
    # Odpalenie parted
    parted /dev/sdb

    # opcja set dla ustawienia nowej flagi 
    set 

    # Pierwsza partycja 
    1

    # Flaga lvm 
    lvm
    ```

2. Dodanie woluminu fizycznego 
    ```bash
    # pvcreate disk_name
    pvcreate /dev/sdb1
    ```

3. Dodanie grupy woluminów na woluminie fizycznym 
    ```bash
    # vgcreate volume_group_name physical_volume_name
    vgcreate myvg0 /dev/sdb1
    ```

4. Dodanie woluminu logicznego o wybranej nazwie 
    ```bash
    # lvreate -n lvm_name --size size volume_group_name 
    lvcreate -n music --size 1G myvg0
    ```

5. Potwierdzenie utworzenia woluminu logicznego
    ```bash
    # Wyświetlenie szczegółowych informacji o lvm ( w tym ścieżki )
    lvdisplay
    > LV Path /dev/myvg0/music
    ```

6. Utworzenie filesystemu na woluminie logicznym 
    ```bash 
    # mkfs.filesystem_name lvm_path
    mkfs.xfs /dev/myvg0/music
    ```


## Powiększanie woluminów logicznych LVM

1. Sprawdzenie dostępnego miejsca na woluminie   
    ```bash
    vgs myvg0
    ```  
  
2. Sprawdzenie ile miejsca zajmuje filesystem   
    ```bash
    df -h /mnt/mymusic/
    ```
  
3. Powiększenie lvm, alternatywnie można wpisać --size 1G, co ustawi lvm na równo 1GB  
    ```bash
    lvextend --size +1G /dev/mapper/myvg0-music
    ```
  
4. Zmiana wielkości filesystemu (ext2/3/4) tak aby wypełniał całą wielkość woluminu   
    ```bash
    resize2fs -p /dev/mapper/myvg0-music
    ```
  
5. Sprawdzenie czy filesystem został powiększony   
    ```bash
    df -h /mnt/mymusic/
    ```


## Montowanie systemów plików

```man fs``` - informacje na temat filesystemów w Linuxie  
```cat /proc/filesystems``` - wyświetlenie obsługiwanych systemów plików  

### Wybrane Filesystemy

| Rodzaj | Opis |
|--|--|
| btrfs | Wykorzystujący technikę „kopiowanie przy zapisie” system plików, który implementuje zaawansowaną funkcjonalność systemu plików. Charakteryzuje się odpornością na awarie i łatwą administracją. |
| cifs | Common Internet File System (CIFS), wirtualny system plików używany w celu uzyskania dostępu do serwerów zgodnych ze specyfikacją SNIA CIFS. System CIFS jest próbą dopracowania i ustandaryzowania protokołu SMB używanego przez Sambę i mechanizm współdzielenia plików Windowsa. |
| ext4 | Następca popularnego systemu plików ext3, względem którego zawiera wiele usprawnień, między innymi obsługę woluminów o wielkości do 1 eksabajtu; obsługuje także pliki o wielkości do 16 terabajtów. (W dystrybucjach Fedora i RHEL zastąpił ext3 jako domyślny system plików. Obecnie domyślnym systemem plików w RHEL jest xfs). |
| ext3 | Ext jest systemem plików stosowanym najczęściej wielu systemach Linux. System plików ext3, nazywany również trzecim rozszerzonym systemem plików, zawiera funkcję księgowania, która w porównaniu z ext2 poprawia możliwości systemu plików w podniesieniu się po awarii. |
| ext2 | Domyślny system plików wcześniejszych systemów Linux. Ma takie same funkcje jak ext3, poza księgowaniem. |
| ext | To pierwsza wersja systemu plików ext3, która nie jest już używana. |
| swap | System plików przeznaczony dla partycji wymiany. Wymienione partycje są używane do tymczasowego przechowywania danych, gdy zajęta jest pamięć RAM. W takim przypadku dane są przenoszone do obszaru wymiany i ponownie zwracane do pamięci RAM, gdy staną się niezbędne. |
| nfs | Network File System (NFS) jest używany do montowania systemów plików w innych komputerach z systemem Linux bądź UNIX. |
| xfs | System plików o dużej wydajności, który działa szczególnie dobrze z ogromnymi plikami. Jest on używany domyślnie w dystrybucji RHEL 7. |

##### Tabela 12.1 strona 308

 
## SWAP - Włączanie przestrzeni wymiany


```mkswap /dev/sdb1``` - tworzy przestrzeń SWAP na patrycji lub z pliku  
  
```swapon/swapoff``` - tymczasowe włączenie SWAPu (do następnego reboota)  
    - ```-a``` - użycie *całego dostępnego SWAPu*  
    - ```/dev/sdb1``` - użycie *konkretnej partycji SWAPowej*  
  
```free -m``` - wyświetla dostępną pamięć RAM i SWAP w MB  

  
1. Wyświetlenie dostępnej pamięci RAM i SWAP 
```
free -m
```

2. Wyczyszczenie partycji/punktu w którym jest zamontowana  
```
dd if=/dev/zero of=/var/tmp/myswap bs=1M count=1024
```

3. Utworzenie pliku lub partycji SWAP 
```
mkswap /dev/sdb5
```

4. Tymczasowe włączenie swapu, na stałe dodaje się do *fstab*
```
swapon /dev/sdb5
```

5. Sprawdzenie UUID dla partycji swapowej
```
blkid /dev/sdb5
```

5. Sprawdzenie czy swap włączył się dobrze 
``` 
free -m
```

6. Dodanie wpisu w /etc/fstab, *punkt montowania ma wartośc swap ponieważ swapu nie trzeba montować*
```
/dev/sdb5 swap swap defaults 0 0
```


## fstab - definiowanie montowanych systemów plików

```bash
/dev/mapper/vg_abc-lv_root / ext4 defaults 1 1
```

- 1 kolumna - urządzenie do zamontowania 
    - UUID=some_uuid (```lsblk -f lub blkid```)
    - LABEL=some_label (```lsblk```)
    - local_device_path ( np. ```/dev/sdb1``` )
- 2 kolumna - *punkt montowania* - katalog, w którym urządzenie jest montowane
- 3 kolumna - *filesystem* ( np. xfs, swap, nfs )
- 4 kolumna - *opcje montowania* - ```defaults``` dla domyślnych ustawień
    - ```man mount``` - zawiera opcje możliwe do ustawienia
    - user - pozwala użytkownikom na montowanie danego katalogu
    - _netdev - nakazuje urządzeniom czekać ze zmapowaniem aż sieć zostanie włączona
- 5 kolumna - ```0 0``` - domyślnie wpisujemy dwa zera, ```man fstab``` dla informacji


## mount i umount

```mount /dev/device /mnt/mount_point``` - wyświetla obecnie zamontowane systemy plików   
- ```-o``` - opcje montowania  
    - ```mount -o loop plik.iso /mnt/obraz``` - tymczasowe zamontowanie pliku iso do folderu     
- ```-t``` - filesystem  
  

```umount /mnt/mount_point``` - służy do odmontowywania   
- ```lsof /mnt/mount_point``` - pokazuje jakie procesy używają danego punktu montowania, pozwala je ubić a następnie odmontować      



### #TODO - Ćwiczenia do zrobienia - strona 319


# 13. Wprowadzenie do administracji serwerem


Monitorowanie serwera

man rsyslogd 

Dzięki usłudze rsyslog (demon rsyslogd) można zebrać pochodzące z wielu różnych usług
informacje o znaczeniu krytycznym i o błędach, a następnie umieścić je w plikach dzienników
zdarzeń. Domyślnie w RHEL komunikaty generowane przez aplikacje są umieszczane w plikach
dzienników zdarzeń znajdujących się w katalogu /var/log. 

**logwatch** każdej nocy skanuje
pliki dzienników zdarzeń, a następnie na podany adres e-mail wysyła wychwycone w nich
informacje o znaczeniu krytycznym. Z kolei funkcjonalność **logrotate** powoduje kompresję
plików dzienników zdarzeń po osiągnięciu przez nie określonej wielkości lub po upływie
określonego czasu od chwili poprzedniego wykonania kopii zapasowej dzienników zdarzeń.


Narzędzie sar (dostarczane przez pakiet sysstat) może być skonfigurowane do monitorowania
aktywności systemu w kategoriach takich jak poziom użycia pamięci i procesora, opóźnienie
dyskowe, aktywność sieci oraz wykorzystanie innych zasobów. Domyślnie sar co kilka minut
uruchamia narzędzie sadc, aby zebrać dane. Późniejsza analiza tych danych może pomóc
w ustaleniu, co i kiedy spowodowało zwiększone użycie zasobów w systemie. 

Dokładne informacje dalej 


## SSH - Zarządzanie zdalnym dostępem  

```yum list installed | grep openssh``` - wylistowanie zainstalowanego oprogramowania z narzędziami ssh
>...  
openssh.x86_64 7.9p1-5.fc30 @anaconda  
openssh-clients.x86_64 7.9p1-5.fc30 @anaconda  
openssh-server.x86_64 7.9p1-5.fc30 @anaconda  


### Uruchamianie usługi openssh-server

```sshd``` - daemon ssh


```systemctl status sshd.service``` - sprawdzenie statusu daemona ssh  
```systemctl start sshd.service``` - uruchomienie daemona ssh  
```systemctl enable sshd.service``` - uruchamianie sshd przy starcie systemu   
 

```/etc/ssh/sshd_config``` - config file dla sshd  
```man sshd_config``` - pomoc w konfiguracji sshd  


Minimum bezpieczeństwa to ustawienie *no* dla opcji *PermitRootLogin*  


### Używanie narzędzi klienta SSH

### Używanie ssh do zdalnego logowania

```~/.ssh/known_hosts``` - plik z kluczami publicznymi zaufanych hostów i ich adresami IP - chcąc zalogować się na któryś musi On zostać dodany   


```ssh janek@10.140.67.23 "cat myfile"``` - wykonanie polecenia zdalnie przez ssh, katalogiem domyślnym jest home użytkownika wykonującego  



**Graficzny SSH** - strona 336

Innym typem zdalnego wykonywania poleceń w przypadku ssh jest tzw. przekazywanie X11.
Jeżeli na serwerze została włączona opcja przekazywania X11 (w pliku /etc/sshd/sshd_config
znajduje się wiersz X11Forwarding yes), to za pomocą SSH można bezpiecznie uruchamiać
aplikacje graficzne z serwera, używając polecenia ssh -X. Dla nowego administratora serwera
to oznacza, że jeśli serwer zawiera zainstalowane graficzne narzędzia administracji, wówczas
będzie można je uruchamiać bez konieczności znajdowania się bezpośrednio przed konsolą.
Oto kolejny przykład:

```bash
$ ssh -X janek@10.140.67.23 system-config-printer 
janek@10.140.67.23's password: **********
```
Po wydaniu tego polecenia zostaniesz poproszony o podanie hasła użytkownika root.
Następnie na ekranie zostanie wyświetlone okno narzędzia graficznego umożliwiającego
skonfigurowanie drukarki.

Jeżeli chcesz wydać więcej poleceń X i nie chcesz ponownie nawiązywać połączenia za każdym
razem, funkcjonalność przekazywania X11 możesz zastosować bezpośrednio ze zdalnej powłoki.
Wystarczy uruchomić polecenia w tle, a w systemie lokalnym będziesz mieć kilka działających
zdalnych aplikacji X. Oto kolejny fragment kodu:

```bash
$ ssh -X janek@10.140.67.23
janek@10.140.67.23's password: **********
$ system-config-printer &
$ gedit &
$ exit
```


## scp i rsync - kopiowanie plików między systemami

### scp 

Przykład działania scp, kopiowanie ze zdalnego systemu na nasz odbywa się anagloicznie 

```bash
# scp source user@hostname:destination  
scp /home/chris/memo janek@10.140.67.23:/tmp  

```
> janek@10.140.67.23's password: ***************   
memo 100%|****************| 153 0:00   


Cechy *scp* :

- Utrata atrybutów - uprawnienia oraz znaczniki daty i godziny nie są kopiowane
- Utrata dowiązań symbolicznych - scp zastępuje linki symboliczne plikami do których prowadzą 
- Niepotrzebnie powtarzane kopiowanie - Pliki są ponownie kopiowane, nawet jeżeli już istnieją w miejscu docelowym

### rsync 

Rsync nie kopiuje plików jeżeli w miejscu docelowym już się znajdują, oszczędza to czas,   
**atrybuty plików ( data utworzenia itd ) zostają zachowane** 


- ```-a``` - archive - archiwizacja przed kopiowaniem 
- ```-v``` - verbose - pokazuje więcej informacji przy kopiowaniu 
- ```-l``` - links - kopiuje linki symboliczne jako linki ( nie pliki do których prowadzą )


Przykład : 
```bash
rsync -avl janek@10.140.67.23:/usr/share/man/man1/ /tmp/
```


## sftp - Interaktywne kopiowanie

**WAŻNE - sftp nie ma nic wspólnego z protokołem ftp !**
sftp to interaktywna sesja ssh, pozwalająca na łatwe kopiowanie plików 

```sftp janek@jd.example.com``` - połączenie z hostem przez *sftp* 
> Connecting to jd.example.com  
janek@jd.example.com's password: ***************  
sftp>  


- ```?``` - wyświetlenie komend  
- ```get``` - pobieranie pliku  
- ```put``` - upload pliku  


## Uwierzytelnianie ssh na podstawie klucza


- **Klucz prywatny** - przechowywany na serwerze docelowym 
- **Klucz publiczny** - używany przez hosty do łączenia z serwerem 

Do klucza prywatnego można nadać hasło które będzie wykorzystywane przy uwierzytelnienia 

- ```ssh-keygen``` - generowanie pary kluczy 
- ```ssh-copy-id -i ~/.ssh/id_rsa.pub janek@10.140.67.23``` - Kopiowanie klucza publicznego na host zdalny 

Kopiowanie przy pomocy *ssh-copy-id* samo dodaje wpis do pliku authorized_keys w *katalogu .ssh* użytkownika kopiującego  

```PasswordAuthentication no``` - opcja wyłączająca uwierzytelnienie za pomocą hasła w pliku */etc/ssh/sshd_config*


## Włączanie rejestrowania danych za pomocą rsyslog

### Plik /etc/rsyslog.conf

Całośc z rsyslog do przećwiczenia !

```man 5 rsyslog.conf``` - man dla configu rsyslog
```man rsyslogd``` - man dla daemona syslog 

```/etc/rsyslog.conf``` - config dla rsyslog

- Przykładowy config 
    ```bash
    module(load="imuxsock"
    # provides support for local system logging (e.g. via logger command)
    SysSock.Use="off") # Turn off message reception via local log socket;
    # local messages are retrieved through imjournal now.
    module(load="imjournal"
    # provides access to the systemd journal
    StateFile="imjournal.state") # File to store the position in the journal
    #module(load="imklog")
    # reads kernel messages (the same are read from journald)
    #module(load="immark")
    # provides --MARK-- message capability
    # Provides UDP syslog reception
    # for parameters see http://www.rsyslog.com/doc/imudp.html
    #module(load="imudp") # needs to be done just once
    #input(type="imudp" port="514")
    # Provides TCP syslog reception
    # for parameters see http://www.rsyslog.com/doc/imtcp.html
    #module(load="imtcp") # needs to be done just once
    #input(type="imtcp" port="514")
    ```

- Wiersze rozpoczynające się od ```module(load=``` powodują wczytanie modułów.
- ```imjournal``` - moduł pozwala usłudze rsyslog uzyskać dostęp do dziennika systemd
- ```imuxsock``` - służy do akceptowania komunikatów pochodzących z systemu lokalnego
- ```imklog``` - rejestrowanie komunikatów generowane przez jądro
- ```immark ```- rejestrowanie komunikatów --MARK-- (używanych do wskazania, że usługa działa) ( nie włączony domyślnie ) 

Wszyskite moduły są opisane pod ```man rsyslog.conf```

- sekcja RULES w pliku *rsyslog.conf*

    ```bash
    #### RULES ####
    # Log all kernel messages to the console.
    # Logging much else clutters up the screen.
    #kern.* /dev/console
    # Log anything (except mail) of level info or higher.
    # Don't log private authentication messages!
    *.info;mail.none;authpriv.none;cron.none /var/log/messages
    # The authpriv file has restricted access.
    authpriv.* /var/log/secure
    # Log all the mail messages in one place.
    mail.* -/var/log/maillog
    # Log cron stuff
    cron.* /var/log/cron
    ```

**W kolumnie po lewej stronie RULES jest wskazany rodzaj dopasowywanych komunikatów, kolumna po prawej określa miejsce docelowe dla dopasowanych komunikatów. Komunikaty są dopasowywane na podstawie funkcjonalności (mail, cron, kern itd.) i priorytetu (od debug, info, notice do crit, alert i emerg) rozdzielonych kropką.  
Dlatego mail.info dopasowuje wszystkie komunikaty pochodzące z usługi poczty i mające poziom co najmniej info.**

Większość komunikatów jest przekazywana do plików znajdujących się w katalogu /var/log.   

Istnieje również możliwość przekierowania komunikatów do urządzenia, takiego jak /dev/console, lub zdalnego hosta rejestracji danych, takiego jak @loghost.example.com.  
Znak @ określa, że znajdująca się po nim nazwa jest nazwą hosta.  


## Plik dziennika zdarzeń messages


```bash
Feb 25 11:04:32 toys network: Bringing up loopback: succeeded
Feb 25 11:04:35 toys network: Bringing up interface eth0: succeeded
Feb 25 13:01:14 toys vsftpd(pam_unix)[10565]: authentication failure;
logname= uid=0 euid=0 tty= ruser= rhost=10.0.0.5 user=chris
Feb 25 14:44:24 toys su(pam_unix)[11439]: session opened for
user root by chris(uid=500)
```

Domyślny format komunikatu w pliku /var/log/messages został podzielony na pięć głównych  
części i jest określony przez następujący wpis w pliku /etc/rsyslog.conf:  
```module(load="builtin:omfile" Template="RSYSLOG_TraditionalFileFormat")```  

■ data i godzina zarejestrowania komunikatu;  
■ nazwa komputera, z którego pochodzi komunikat;  
■ nazwa programu lub usługi, której dotyczy komunikat;  
■ ujęty w nawias kwadratowy numer procesu programu, z którego pochodzi komunikat;  
■ rzeczywisty tekst komunikatu.  


## Konfigurowanie i używanie loghost za pomocą rsyslog


Do przekierowania logów komputera do demona rsyslogd w innym komputerze konieczne jest wprowadzenie zmian w configu rsyslog */etc/rsyslog.conf*,  
**hosta lokalnego i zdalnego**

## Zmiany po stronie klienta

Aby komunikaty były przekazywane do innego komputera (tzw. loghost) zamiast do pliku, nazwę pliku dziennika zdarzeń zastępuemy znakiem **@ i hosntame**.  
np. dla przekierowania *messages, secure i maillog*, do configu */etc/rsyslog.conf* dodaj wiersze, zawierające **@loghost**

```bash
# Log anything (except mail) of level info or higher.
# Don't log private authentication messages!
*.info;mail.none;news.none;authpriv.none;cron.none /var/log/messages
*.info;mail.none;news.none;authpriv.none;cron.none @loghost

# The authpriv file has restricted access.
authpriv.* /var/log/secure
authpriv.* @loghost

# Log all the mail messages in one place.
mail.* -/var/log/maillog
mail.* @loghost
```

Nazwa **loghost** jest stosowana zazwyczaj, dzieki temu można łatwo podmienić serwer bez zmieniania configu na wszystkich maszynach


## Zmiany po stronie loghosta

Loghost skonfigurowany do akceptowania komunikatów musi nasłuchiwać ich na standardowych
portach (514 UDP, choć może być skonfigurowany również do akceptowania komunikatów
na porcie 514 TCP).

### #TODO - strona 346 - do ogarnięcia procedura 

Procedura konfiguracji loghosta
■ Edytuj plik /etc/rsyslog.conf w loghoście i usuń znak # na początku wierszy włączających  
nasłuchiwanie przez demon rsyslogd komunikatów ze zdalnych systemów. Znak # usuń
z dwóch pierwszych wierszy włączających nasłuchiwanie komunikatów przychodzących
na porcie 514 UDP (domyślnie), a także z dwóch wierszy po wierszu zezwalającym
na nasłuchiwanie komunikatów przez protokół TCP (również na porcie 514).
module(load="imudp") # needs to be done just once
input(type="imudp" port="514")
module(load="imtcp") # needs to be done just once
input(type="imtcp" port="514")
■ Zmodyfikuj konfigurację zapory sieciowej w taki sposób, aby umożliwiała kierowanie  
komunikatów do Twojego loghosta. (W rozdziale 25. znajdziesz dokładne informacje o tym,
jak otwierać określone porty zapory sieciowej w celu zapewnienia dostępu do systemu).
■ Ponownie uruchom usługę rsyslog (service rsyslog restart lub systemctl restart
rsyslog.service).  
■ Jeżeli usługa jest uruchomiona, powinieneś zobaczyć, że nasłuchuje na włączonych
portach (514 dla ruchu sieciowego UDP i/lub TCP). Wydaj polecenie netstat i sprawdź,
czy demon rsyslogd faktycznie nasłuchuje na portach 514 (IPv4 i IPv6) dla ruchu
sieciowego UDP i TCP:  

```bash
# netstat -tupln | grep 514
tcp 0 0 0.0.0.0:514 0.0.0.0:* LISTEN 25341/rsyslogd
tcp 0 0 :::514 :::* LISTEN 25341/rsyslogd
udp 0 0 0.0.0.0:514 0.0.0.0:* 25341/rsyslogd
udp 0 0 :::514 :::* 25341/rsyslogd
```



## Obserwowanie komunikatów za pomocą usługi logwatch

*logwatch* polega na pobieraniu każdej nocy komunikatów, które mogą  
przedstawiać problem. Są one umieszczane w wiadomości e-mail wysyłanej na adres podany  
przez administratora.  
Logwatch trzeba zainstalować - ```yum install logwatch```  

logwatch jest uruchamiana jako zadanie mechanizmu cron (0logwatch) umieszczone w /etc/cron.daily  

```/etc/logwatch/conf/logwatch.conf``` - config  
```man logwatch.conf``` - man dla configu  

Domyślnie po zainstalowaniu logwatch wysyła maila raz dziennie,   
jest to ustawione w *cron.daily*  

```mail``` - polecenie służy do lokalnego przeglądania maili, można przy jego pomocy sprawdzić czy logwatch dobrze działa  
    - ```1``` - wyświetlenie pierwszego maila  
    - ```2``` - wyświetlenie drugiego maila  
    - ...  
    - ```x``` - wyjście z polecenia mail  


## sar - sprawdzanie zasobów systemowych 


### #TODO - przeredagować 

Polecenie sar jest częścią pakietu sysstat. Po jego zainstalowaniu i uruchomieniu usługi  
sysstat system natychmiast rozpocznie zbieranie dotyczących aktywności danych, które  
będzie można wyświetlić później po użyciu określonych opcji polecenia sar.  

```bash
# systemclt enable sysstat
# systemctl start sysstat
```

```/var/log/sa/sa??``` - domyślne miejsce docelowe dla logów  

```sar``` - przeglądanie logów  
    - ```-u``` - wyświetla informacje dotyczące procesora   
    - ```-d``` - wyświetla informacje dotyczące dysku  

### #TODO - sar do uzupełnienia, nie było możliwości pobrania na wirtualkę 

## Sprawdzanie ilości wolnego miejsca

### df - Wyświetlanie dostępnej powierzchni dyskowej

```df``` - wyświetla dostępną wolną powierzchnię w systemie plików  
    - ```-h``` - human readable - użycie większych jednostek   
    - ```-t``` - Wyświetlenie informacji tylko o systemie plików wskazanego rodzaju  
    - ```-x``` - Wyłączenie wyświetlania informacji o wskazanym rodzaju systemu pliku ( np. *df -x tmpfs* )  
    - ```-a``` - include pseudo, duplicate, inaccessible file systems  
    - ```-i``` - list inodes information instead of block usage  
    - ```--block-size=#``` - Wyświetlenie wolnego miejsca w jednostkach *np. G, M*  

### du - Sprawdzanie zużycia miejsca na dysku

```du``` - wyświetla ilośc miejsca którą zajmują pliki i katalogi, domyślnie działa rekursywnie, na koniec podaje ilość miejsca zajętą przez dany katalog   
    - ```-h``` - human readable - użycie większych jednostek  
    - ```-s``` - wyświetla miejsce zajmowane przez dany katalog, bez wyświetlania plików  

```du -h /home/janek```  
> 114k /home/janek/httpd/stuff  
234k /home/janek/httpd  
137k /home/janek/uucp/data  
701k /home/janek/uucp  
1.0M /home/janek  


### find - Określanie zużycia miejsca na dysku

- Wyszukanie plików należących do użytkownika janek, wywietlenie dokładnych informacji przy pomocy ls, wyświetlenie katalogów bez ich zawartości, posortowanie po wielkości plików 

```bash
find / -xdev -user janek -print | xargs ls -ldS > /tmp/janek
```
    - ```-xdev``` - uniemożliwia przeszukiwanie innych systemów plików niż wskazane


```bash
find / -xdev -size +100k -print | xargs ls -ldS > /tmp/size
```


# Administracja siecią


```ip addr show``` - wyświetlenie informacji o wszystkich interfejsach sieciowych   
    - ```-s``` - wyświetla dane statystyczne dotyczące transmisji pakietów oraz wygenerowanych błędów dla każdego interfejsu   
   
```ip addr show```   
> 1: lo: <LOOPBACK,UP,LOWER_UP> mtu 65536 qdisc noqueue   
        state UNKNOWN group default qlen 1000   
    link/loopback 00:00:00:00:00:00 brd 00:00:00:00:00:00   
    inet 127.0.0.1/8 scope host lo   
        valid_lft forever preferred_lft forever   
    inet6 ::1/128 scope host   
        valid_lft forever preferred_lft forever   
2: enp4s0: <NO-CARRIER,BROADCAST,MULTICAST,UP> mtu 1500   
        qdisc fq_codel state DOWN group default qlen 1000   
    link/ether 30:85:a9:04:9b:f9 brd ff:ff:ff:ff:ff:ff   
3: wlp2s0: <BROADCAST,MULTICAST,UP,LOWER_UP> mtu 1500   
...   

```ifconfig``` - Starsza, chociaż wciąż działająca alternatywa dla komendy ip  



## Sprawdzanie informacji o routingu

```ip route show``` - wyświetlenie tablicy routingu
> default via 192.168.122.1 dev ens3 proto dhcp metric 20100    
192.168.122.0/24 dev ens3 proto kernel scope link src 192.168.122.194 metric 100   

Polecenie ip route show wskazuje, że adres 192.168.122.1 zapewnia trasę prowadzącą do hosta z maszyny wirtualnej RHEL 8 przez interfejs sieciowy ens3. Za pomocą tego interfejsu odbywa się wychodząca z maszyny wirtualnej (192.168.122.194) komunikacja ze wszystkimi adresami w zakresie 192.168.122.0/24.  

```route``` - starsza alternatywa dla ip route   

### #TODO - ogarnąc jak interpretować tablicę routingu

```tracepath``` - traceroute - sprawdza trasę między jednym hostem a drugim

### Wyświetlanie nazw hosta i domeny

```hostname``` - wyświetla hostname
> spike.example.com

```dnsdomainname``` - wyświetla samą domenę 
> example.com


## Konfigurowanie interfejsów sieciowych

### #TODO - rozdział sieci ogólnie do uzupełnienia 

### Konfigurowanie sieci z poziomu powłoki

#### nmtui - podstawowa konfiguracja sieci z interfejsu

```nmtui``` - pozwala skonfigurować podstawowe ustawienia sieci, **zmiana ip, ustawienie hostname, dns**

![nmtui](https://github.com/mariuszkuswik/Nauka/blob/biblia/Linux/Obrazy/nmtui.png)
##### Menu nmtui 

```/etc/sysconfig/network-script``` - folder dla configów w których ustawiane są interfejsy sieciowe i trasy niestandardowe  
```/usr/share/doc/initscripts/sysconfig.txt``` - instrukcje konfiguracyjne dla skryptów sieciowych


Pozostałe sieciowe pliki konfiguracyjne : 

- /etc/hostname
- /etc/sysconfig/network
- /etc/hosts
- /etc/resolv.conf
- /etc/nsswitch.conf


### #TODO - od strony 373 do końca sieci do ogarnięcia 

## Definiowanie aliasu interfejsu sieciowego

# Uruchamianie i zatrzymywanie usług

## Demon inicjalizacji (init lub systemd)

### #TODO - opisać jak działa 


### Runlevele/Standardowe poziomy działania w Linuksie
##### Tabela 15.1

| Poziom działania |  Nazwa | Opis |
|--|--|--|
| 0  | System zatrzymany | Wszystkie usługi zostały zamknięte, a serwer zatrzymany. |
| 1 lub S | Tryb pojedynczego użytkownika | Użytkownik root zostaje automatycznie zalogowany do serwera. Inni użytkownicy nie mogą się zalogować do serwera. Dostępny jest jedynie interfejs powłoki. Usługi sieciowe nie są uruchamiane. |
| 2 | Tryb wielodostępny | Użytkownicy mogą logować się do serwera, ale dostępny jest tylko interfejs powłoki. W niektórych systemach są uruchamiane interfejsy sieciowe i usługi, w innych nie. Początkowo ten poziom działania był używany do uruchomienia urządzeń terminali, do których mogli się logować użytkownicy (przy czym usługi sieciowe były niedostępne). |
| 3 | Rozszerzony tryb wielodostępny | Użytkownicy mogą się logować do serwera, ale dostępny jest tylko interfejs powłoki. Interfejsy sieciowe i usługi są uruchomione. Jest to powszechnie stosowany poziom działania dla serwerów. |
| 4 | Zdefiniowany przez użytkownika | Ten poziom działania użytkownicy mogą dostosowywać do własnych potrzeb. | 
| 5 | Tryb graficzny | Użytkownicy mogą logować się do serwera. Dostępne są interfejsy powłoki i graficzny. Usługi sieciowe są uruchomione. Jest to powszechnie używany poziom działania dla systemów biurkowych. |
| 6 | Ponowne uruchomienie systemu | Serwer jest ponownie uruchamiany. |


### #TODO - sprawdzić jak w systemd zmienia się runlevele

### #TODO - strona 384 - opisć init 


```init 3``` zmienia aktualnie działający runlevel na 3   
```runlevel``` - wyświetla aktualnie działający runlevel   
  
```/etc/inittab``` - ustawienia domyślne dla runleveli   


 
## Inicjalizacja systemd 

### #TODO - strona 388 - powtórzyć i ogarnąc to co było 
- Czym są targety systemd
- jak zmienić runlevel za pomocą systemd 


### Podstawy pracy z demonem systemd

W przypadku demona SysVinit usługi są uruchamiane i zatrzymywane na podstawie poziomu
działania. Demon systemd wie o istnieniu poziomów działania, choć implementuje je w zupełnie
inny sposób — za pomocą jednostek docelowych. Pomimo że podstawowym zadaniem demona
systemd jest uruchamianie i zatrzymywanie usług, potrafi on również zarządzać innymi jednostkami.
Jednostka to po prostu grupa składająca się z nazwy, typu i pliku konfiguracyjnego skoncentrowana
na określonej usłudze lub akcji.


Jednostki w systemd
■ automount  
■ device  
■ mount  
■ path  
■ service   
■ snapshot  
■ socket   
■ target   
■ timer  
■ swap  
■ slice  
■ scope  

Dwie podstawowe jednostki demona systemd ważne podczas pracy z usługami to jednostki
usług i jednostki celów. Jednostka usługi jest przeznaczona do zarządzania demonami
na serwerze Linuksa, a jednostka celu to po prostu grupa innych jednostek. 


##### Przykładowy plik jednostki usługi systemd


#### Informacje na temat plików konfiguracyjnych systemd !!!
```bash
man systemd.service  
man systemd.target   
man systemd.unit  
```


```man -k systemd``` - dokumentacja na temat narzędzi systemd



```bash
cat /lib/systemd/system/sshd.service
```

> [Unit]  
Description=OpenSSH server daemon  
Documentation=man:sshd(8) man:sshd_config(5)  
After=network.target sshd-keygen.target  
[Service]  
Type=notify  
EnvironmentFile=-/etc/crypto-policies/back-ends/opensshserver.config  
EnvironmentFile=-/etc/sysconfig/sshd  
ExecStart=/usr/sbin/sshd -D $OPTIONS $CRYPTO_POLICY  
ExecReload=/bin/kill -HUP $MAINPID  
c528defda93e9420916cfa7705790125  
c528defda93e9420916cfa7705790125  
ROZDZIA Ł 15. Uruchamianie i zatrzymywanie usług 393  
15  
KillMode=process  
Restart=on-failure  
RestartSec=42s  
[Install]  
WantedBy=multi-user.target  
[Install]   
WantedBy=multi-user.target   
 

Podstawowy plik konfiguracyjny jednostki usługi zawiera następujące opcje:  
    - **Description** - Opis usługi (wiersz komentarza).  
    - **Documentation** - Lista stron podręcznika systemowego dotyczących demona sshd i jego pliku konfiguracyjnego.  
    - **After** - Konfiguruje kolejność. Innymi słowy jest to lista jednostek, które powinny być aktywowane przed uruchomieniem tej jednostki.  
    - **Environment File** - Pliki konfiguracyjne jednostki.  
    - **ExecStart** - Polecenie użyte do uruchomienia usługi.  
    - **ExecReload** - Polecenie użyte do ponownego wczytania usługi.  
    - **WantedBy** - Jednostka docelowa, do której należy usługa.   


Zwróć uwagę, że jednostka docelowa, multi-user.target, została wymieniona w pliku
konfiguracyjnym jednostki usługi sshd. Jednostka usługi sshd jest wymagana przez
multi-user.target. Innymi słowy podczas aktywowania jednostki multi-user.target
następuje uruchomienie jednostki sshd.


```systemctl show multi-user.target``` - Show properties of one or more units, jobs, or the manager itself. If no argument is specified, properties of the manager will be shown. 


```bash
# Wyświetlenie jednostki, które zostaną aktywowane przez jednostkę celu:

systemctl show --property "Wants" multi-user.target
```

> Wants=irqbalance.service firewalld.service plymouth-quit.service
systemd-update-utmp-runlevel.service systemd-ask-password-wall.path...
(END) q

jednostka celu (.target) to po prostu grupa innych jednostek, nie wszystkie jednostki w tej grupie są jednostkami usług — mamy tutaj jednostki ścieżek i inne jednostki celu.


Jednostka celu ma wymienione :  
	- **oczekiwania (Wants)** - wszystkie wymienione jednostki zostaną wskazane do aktywacji (uruchomienia).   
	Jeżeli zakończy się to niepowodzeniem i nie uda się uruchomić jednostki, **jednostka celu będzie kontynuowała działanie.**   
	- **wymagania (Requires)** - wszystkie wymienione jednostki zostaną wskazane do aktywacji (uruchomienia).  
	 Jeżeli zakończy się to niepowodzeniem i nie uda się uruchomić jednostki, **wówczas cała grupa jednostek zostanie dezaktywowana.**  


### #TODO - czym jest jednostka celu a czym jednostka usługi  strona 394
### #TODO - proces uruchamiania systemu z systemd
- W chwili uruchomienia systemu systemd aktywuje jednostkę default.target. Jest ona aliasem dla multi-user.target lub graphical.target.
Dlatego w zależności od sposobu zdefiniowania aliasu uruchomione zostaną usługi wskazane
przez jednostkę celu. 


Podstawowy plik konfiguracyjny jednostki celu zawiera następujące opcje:
    - **Description.** Opis danej jednostki celu.
    - **Documentation.** Odpowiednia strona podręcznika systemowego dotyczącego systemd.
    - **Requires.** Jeżeli jednostka multi-user.target zostanie aktywowana, wówczas aktywowana
    zostanie wymieniona w tym miejscu jednostka celu. Jeżeli ta jednostka celu zostanie
    dezaktywowana lub ulegnie awarii, to oznacza także dezaktywację multi-user.target.
    W przypadku braku opcji After i Before następuje jednoczesne aktywowanie
    multi-user.target i jednostki celu.
    - **Conflicts.** Ta opcja pozwala uniknąć konfliktów w jednostkach. Uruchomienie
    multi-user.target oznacza zatrzymanie wymienionych w tym miejscu jednostek
    i usług oraz na odwrót.
    - **After.** Konfiguruje kolejność. Innymi słowy to jest lista jednostek, które powinny być
    aktywowane przed uruchomieniem tej jednostki.
    - **AllowIsolate.** Ta opcja to wartość boolowska yes lub no. Wartość yes oznacza, że podczas
    aktywowania danej jednostki celu, tutaj multi-user.target, aktywowane będą jej
    zależności, a wszystkie pozostałe jednostki będą dezaktywowane. 



Plik /etc/inittab nie ma już żadnego faktycznego zastosowania. 
Przykładowy plik /etc/inittab na serwerze Linuksa, który używa demona systemd:

```bash
# cat /etc/inittab
# inittab is no longer used.
#
# ADDING CONFIGURATION HERE WILL HAVE NO EFFECT ON YOUR SYSTEM.
#
# Ctrl-Alt-Delete is handled by
# /etc/systemd/system/ctrl-alt-del.target
#
# systemd uses 'targets' instead of runlevels.
# By default, there are two main targets:
#
# multi-user.target: analogous to runlevel 3
# graphical.target: analogous to runlevel 5
#
# To view current default target, run:
# systemctl get-default
#
# To set a default target, run:
# systemctl set-default TARGET.target 
```


Aby sprawdzić jaki obecnie domyślny poziom działania możemy wyświetlić plik ```/etc/systemd/system/default.target```

```bash
# ls -l /etc/systemd/system/default.target
lrwxrwxrwx. 1 root root 36 Mar 13 17:27
 /etc/systemd/system/default.target ->
 /lib/systemd/system/runlevel3.target 
```


## Sprawdzanie stanu usługi 



```systemctl status cups.service``` - wyświetla status usługi ( w tym przypadku wydruku )
> cups.service - CUPS Scheduler
 Loaded: loaded (/lib/systemd/system/cups.service; enabled)
 Active: active (running) since Wed 2019-09-18 17:32:27 EDT; 3 days ago
 Docs: man:cupsd(8)
Main PID: 874 (cupsd)
 Status: "Scheduler is running..."
 Tasks: 1 (limit: 12232)
 Memory: 3.1M
 CGroup: /system.slice/cups.service
 └─874 /usr/sbin/cupsd –l 


## Uruchamianie i zatrzymywanie usług za pomocą demona systemd


### #TODO strona 400 
systemctl - opisać wszystkie opcje i samo polecenie systemctl  
systemctl - bez żadnych parametrów wyświetla wszystie jednostki ? - opisać dokładnie   
	- status - sprawdzenie statusu usługi  

	- stop - zatrzymanie    
	- start - uruchomienie   

	- restart - restart, jeżeli usługa nie działała to **zostanie uruchomiona**  
	- conrestart - restart warunkowy - jeżeli usługa nie działała to **nie zostanie uruchomiona**  

	- reload - Ponowne wczytanie plików konfiguracyjnych  

	- enable - trwałe uruchomienie ? usługa włączy się po restarcie systemu   
	- disable - trwałe wyłączenie ? usługa włączy się po restarcie systemu   
	- mask  - trwałe wyłączenie usługi, uniemożliwiające uruchomienie jej kiedykolwiek w systemie 



```systemctl status cups.service``` - sprawdzenie statusu usługi cups   
> cups.service - CUPS Printing Service  
 Loaded: loaded (/lib/systemd/system/cups.service; enabled)  
 Active: active (running) since Mon, 20 Apr 2020 12:36:3...  
 Main PID: 1315 (cupsd)   
 CGroup: name=systemd:/system/cups.service  
 1315 /usr/sbin/cupsd -f   


## Ponowne uruchamianie usługi za pomocą demona systemd 

Ponowne uruchomienie usługi oznacza jej zatrzymanie, a następnie ponowne uruchomienie.  
Jeżeli usługa nie była wcześniej uruchomiona, opcja restart powoduje po prostu jej uruchomienie. 


- ```systemctl restart cups.service``` - Restart usługi cups 
- ```systemctl conrestart cups.service``` - Restart usługi w trybie warunkowym - usługa zrestartuje się **tylko jeżeli była już wcześniej uruchomiona**


```bash
systemctl status cups.service
```

> cups.service - CUPS Printing Service  
 Loaded: loaded (/lib/systemd/system/cups.service; enabled)  
 Active: inactive (dead) since Tue, 21 Apr 2020 06:03:32...  
 Process: 17108 ExecStart=/usr/sbin/cupsd -f  
 (code=exited, status=0/SUCCESS)  
 CGroup: name=systemd:/system/cups.service  


```bash
# Warunkowy restart
systemctl condrestart cups.service
# Status usługi
systemctl status cups.service
```

> cups.service - CUPS Printing Service  
 Loaded: loaded (/lib/systemd/system/cups.service; enabled)  
 Active: inactive (dead) since Tue, 21 Apr 2020 06:03:32...  
 Process: 17108 ExecStart=/usr/sbin/cupsd -f  
 (code=exited, status=0/SUCCESS)  
 CGroup: name=systemd:/system/cups.service   

```# Usługa nie została uruchomiona przez condrestart ponieważ przed wykonaniem polecenia nie działała```


## Ponowne wczytywanie usługi za pomocą demona systemd 

Po wydaniu polecenia reload usługa nie zostaje zatrzymana, **ponownie wczytane zostają jedynie jej pliki konfiguracyjne.**    
Nie wszystkie usługi mają zaimplementowaną funkcjonalność ponownego wczytania.    
Wykonanie operacji **reload** zamiast restart nie powoduje zakłócenia działalności danej usługi.



systemctl reload sshd.service - Ponowne wczytanie plików konfiguracyjnych dla sshd


## Włączanie trwałej usług


**enable** - Definjuje usługę jako zawsze uruchamianą razem z systemem (czyli rónież po restarcie).  


```bash
systemctl status cups.service
```
> cups.service - CUPS Printing Service  
 Loaded: loaded (/lib/systemd/system/cups.service; disabled)  
 Active: inactive (dead) since Tue, 21 Apr 2020 06:42:38 ...  
 Main PID: 17172 (code=exited, status=0/SUCCESS)  
 CGroup: name=systemd:/system/cups.service   


```bash
systemctl enable cups.service
```

> Created symlink /etc/systemd/system/printer.target.wants/cups.service  
 → /usr/lib/systemd/system/cups.service.  
Created symlink /etc/systemd/system/sockets.target.wants/cups.socket  
 → /usr/lib/systemd/system/cups.socket.  
Created symlink /etc/systemd/system/multi-user.target.wants/cups.path  
 → /usr/lib/systemd/system/cups.path.  

```bash
systemctl status cups.service
```

> cups.service - CUPS Printing Service  
 Loaded: loaded (/lib/systemd/system/cups.service; enabled)  
 Active: inactive (dead) since Tue, 21 Apr 2020 06:42:38...  
 Main PID: 17172 (code=exited, status=0/SUCCESS)  
 CGroup: name=systemd:/system/cups.service   



```Po użyciu polecenia systemctl z opcją enable stan usługi cups.service zmienił się z wyłączonego (disabled) na włączony (enabled).```


## Wyłączanie usługi za pomocą demona systemctl

**disable** - uniemożliwia uruchomienie danej usługi razem z systemem.  
Polecenie **nie powoduje natychmiastowego zatrzymania usługi.** - W tym celu konieczne jest użycie wcześniej omówionej opcji stop.


```bash
systemctl disable cups.service
```

> rm '/etc/systemd/system/printer.target.wants/cups.service'
rm '/etc/systemd/system/sockets.target.wants/cups.socket'
rm '/etc/systemd/system/multi-user.target.wants/cups.path'


```bash
systemctl status cups.service
```
  
> cups.service - CUPS Printing Service  
Loaded: loaded (/lib/systemd/system/cups.service; disabled )  
Active: active (running) since Tue, 21 Apr 2020 06:06:41...  
Main PID: 17172 (cupsd)  
CGroup: name=systemd:/system/cups.service  
17172 /usr/sbin/cupsd -f  
  
```W powyższym przykładzie widać, że usługa pozostałą włączona ale nie włączy się przy następnym uruchomieniu systemu.```  
  
```bash  
systemctl status dbus.service  
```  

> dbus.service - D-Bus System Message Bus  
Loaded: loaded (/lib/systemd/system/dbus.service; static)  
Active: active (running) since Mon, 20 Apr 2020 12:35:...  
Main PID: 707 (dbus-daemon)  
...  
  
```bash  
systemctl disable dbus.service  
systemctl status dbus.service  
```  

> dbus.service - D-Bus System Message Bus  
Loaded: loaded (/lib/systemd/system/dbus.service; static)  
Active: active (running) since Mon, 20 Apr 2020 12:35:...  
Main PID: 707 (dbus-daemon)  
...  
  
**System nie pozwala na wyłączenie usług statycznych takich jak dbus**   

## Stałe wyłączenie usługi 

**mask** - usługa nie zostanie włączona nawet jeśli jest ona zależnością innej usługi, inaczej niż w przypadku opcji **disabled** 

Podczas gdy trwała usługa to taka, która jest uruchamiana razem z systemem, trwały (domyślny) **poziom działania** (runlevel dla SysVinit) lub **trwała jednostka celu** (target dla systemd) oznacza grupę usług uruchamianych razem z systemem. 


## Konfigurowanie domyślnego poziomu działania (runlevelu) lub jednostki celu (target)

| **systemd targets** |**SystemV runlevel**  | **target aliases**|**Description** |
|--|--|--|--|
| default.target |  | | This target is always aliased with a symbolic link to either **multi-user.target** or **graphical.target**. systemd always uses the **default.target** to start the system. The **default.target** should never be aliased to **halt.target**, **poweroff.target**, or **reboot.target**.|
| graphical.target| 5|runlevel5.target	|**Multi-user.target** with a GUI |
| |4 | runlevel4.target|Unused. Runlevel 4 was identical to runlevel 3 in the SystemV world. This target could be created and customized to start local services without changing the default **multi-user.target**. |
| multi-user.target| 3|runlevel3.target |All services running, but command-line interface (CLI) only |
| | 2| runlevel2.target|Multi-user, without NFS, but all other non-GUI services running |
| rescue.target|1 | runlevel1.target|A basic system, including mounting the filesystems with only the most basic services running and a rescue shell on the main console |
| emergency.target| S| | Single-user mode—no services are running; filesystems are not mounted. This is the most basic level of operation with only an emergency shell running on the main console for the user to interact with the system.|
| halt.target| | |Halts the system without powering it down |
| reboot.target| 6|runlevel6.target | Reboot|
| poweroff.target|0 |  runlevel0.target | Halts the system and turns the power off|


- ```systemctl get-default``` - wyświetlenie domyślnego targetu 
- ```systemctl set-default``` - ustawienie domyślnego targetu 
- ```systemctl isolate``` - zmiana obecnego targetu


```bash
systemctl get-default
```

> graphical.target

```bash
systemctl set-default runlevel3.target
```

> Removed /etc/systemd/system/default.target.
Created symlink /etc/systemd/system/default.target →
/usr/lib/systemd/system/multi-user.target.

```bash
systemctl get-default
```

> multi-user.target

```Po ponownym uruchomieniu systemu multi-user.target będzie trwałą jednostką celu. Wszystkie usługi zdefiniowane w tej jednostce zostaną uruchomione (aktywowane) razem z systemem.```


## Dodawanie nowej usługi do demona systemd

```man systemd.syntax``` - ogólne zasady składni  
```man systemd.unit``` - opisanie poszczególnych sekcji pliku   
```man systemd.service``` - ogólny opis tworzenia usługi ?  


1. Utworzenie pliku skryptu nowej usługi lub dostosowanej do własnych potrzeb.  
2. Przeniesienie skryptu usługi do odpowiedniego katalogu, aby umożliwić demonowi systemd zarządzanie tą usługą.   
3. Dodanie usługi do sekcji Wants wybranej jednostki celu, aby usługa była automatycznie uruchamiana z innymi.   


### Krok 1. Utworzenie pliku skryptu nowej usługi lub dostosowanej do własnych potrzeb  

- Jeżeli dostosowujesz do własnych potrzeb skrypt istniejącej usługi, wykonaj kopię oryginalnego pliku jednostki w katalogu /lib/systemd/system i wprowadź żądane modyfikacje.  
 
Minimum dla działania usługi to zdefiniowanie opcji *Description* i *ExecStart*  

> [Unit]  
Description=My New Service  
[Service]  
ExecStart=/usr/bin/My_New_Service  


### Krok 2. Przeniesienie skryptu usługi do odpowiedniego katalogu

Plik konfiguracyjny jednostki usługi można umieścić w jednym z dwóch następujących katalogów:

- ```/etc/systemd/system```
    - Ten katalog służy do przechowywania plików konfiguracyjnych lokalnych jednostek usług.  
    - Pliki umieszczone w tym katalogu nie są nadpisywane podczas instalowania lub uaktualniania oprogramowania. System będzie używał tych plików nawet wtedy, gdy plik o takiej samej nazwie istnieje w katalogu /lib/systemd/system.  
- ```/lib/systemd/system```
    - Ten katalog służy do przechowywania plików konfiguracyjnych systemowych jednostek usług.  
    - Pliki umieszczone w tym katalogu są nadpisywane podczas instalowania lub uaktualniania oprogramowania.  

System będzie używał tych plików tylko wtedy, gdy w katalogu ```/etc/systemd/system``` nie istnieje już plik o takiej samej nazwie.  

#### TLDR : Dlatego najlepszym miejscem na umieszczenie pliku konfiguracyjnego jednostki nowej usługi lub usługi dostosowanej do własnych potrzeb jest katalog ```/etc/systemd/system```  

**WAŻNE** : Podczas tworzenia nowej usługi lub dostosowanej do własnych potrzeb, aby wprowadzona zmiana nie wymagała ponownego uruchomienia systemu, konieczne jest wydanie specjalnego polecenia z poziomu powłoki: ```systemctl daemon-reload```


### Krok 3. Dodanie usługi do katalogu Wants

Ostatni krok wykonuje się tylko wtedy gdy chcesz, aby nowa usługa była uruchamiana z *określoną jednostką celu demona systemd*.

1. Dodanie linku do usługi w **katalogu Wants** danej jednostki celu
```bash
# Przykładowy katalog wants - w tym przypadku multi-user.target
 ls -l /etc/systemd/system/multi-user.target.wants
```

> lrwxrwxrwx. 1 root root 37 Nov 2 22:29 abrt-ccpp.service -> /lib/systemd/system/abrt-ccpp.service  
lrwxrwxrwx. 1 root root 33 Nov 2 22:29 abrtd.service -> /lib/systemd/system/abrtd.service  
...  
lrwxrwxrwx. 1 root root 32 Apr 26 20:05 sshd.service -> /lib/systemd/system/sshd.service  

```bash
# Dodanie soft linku w katalogu Wants dla nowo utworzonej usługi
ln -s /etc/systemd/system/My_New_Service.service
```

> /etc/systemd/system/multi-user.target.wants/My_New_Service.service


2. Na końcu pliku konfiguracyjnego jednostki usługi dodaj wiersz WantedBy=desired.target (np. multi-user.target)

```bash
[Install]
WantedBy=multi-user.target
```

Po wykonaniu tej procedury jednostka zostanie zostanie aktywowana (uruchomiona) po aktywowaniu jednostki multi-user.target.


### #TODO - ćwiczenia systemd do zrobienia, strona 412



# Serwer wydruku 

## Konfigurowanie drukarek

```http://localhost:631/``` - strona konfiguracyjna dla drukarek udostępnionych przez CUPS

Aby zmiany wprowadzone w przeglądarce zostały zastosowane konieczne może być wydanie polecenia ```systemctl restart cups.service```

Domyślnie strona konfiguracyjna cups jest dostępna tylko z lokalnego systemu, aby udostępnić ją należy wejść w zakładkę *Administracja* i otworzyć port TCP na firewallu


### Dodawanie drukarki, która nie została wykryta automatycznie

### #TODO - strona 417 - zastanowić się czy to dodawać 
1. Add Printer (Dodawanie drukarki). 
2. 

### #TODO - strona 417 - tu skończyłem prace z drukarkami 



# Serwer WWW

## Pakiet httpd

```/etc/httpd/conf/httpd.conf``` - podstawowy plik konfiguracyjny dla pakietu *httpd*  
```/etc/httpd/conf.d/welcome.conf``` - definjuje fomyślną stronę internetową 


```rpm -qpc httpd-*rpm``` - wyświetlenie plików konfiguracyjnych dla pakietu *httpd*  

> /etc/httpd/conf.d/autoindex.conf
/etc/httpd/conf.d/userdir.conf
/etc/httpd/conf.d/welcome.conf
/etc/httpd/conf.modules.d/00-base.conf
/etc/httpd/conf.modules.d/00-dav.conf
...
/etc/httpd/conf/httpd.conf
/etc/httpd/conf/magic
/etc/logrotate.d/httpd
/etc/sysconfig/htcacheclean

```dnf groupinfo "web-server"```
dnf install httpd - instalacja samego pakietu httpd
dnf groupinstall web-server - instalacja httpd i dodatków 

httpd działa jako usługa więc trzeba ją włączyć 

```bash
systemctl enable httpd.service
systemctl start httpd.service
```

```systemctl edit httpd``` - edycja opcji demona httpd


## Apache i zapora sieciowa

```netstat -tupln | grep httpd``` - Sprawdzenie portów wykorzystywanych przez httpd

> tcp6 0 0 :::80 :::* LISTEN 29169/httpd
tcp6 0 0 :::443 :::* LISTEN 29169/httpd 

Dane wyjściowe wyraźnie pokazują, że demon httpd (proces o identyfikatorze 29169)
nasłuchuje na wszystkich adresach dla portów 80 (:::80) i 443 (:::443). Oba porty są
powiązane z protokołem TCP (tcp6). W celu otworzenia tych portów w Fedorze i Red Hat
Enterprise Linux konieczne jest dodanie reguł zapory sieciowej

W bieżących wydaniach Fedory 30 oraz RHEL 7 i 8 należy przejść do okna zapory sieciowej
(w tym celu trzeba na ekranie Podgląd środowiska graficznego GNOME 3 wpisać Zapora
sieciowa). W wyświetlonym oknie należy z rozwijanego menu Konfiguracja wybrać opcję
Trwałe. Następnie w strefie publicznej (public) trzeba zaznaczyć pola wyboru znajdujące się
obok usług http i https. Powiązane z nimi porty zostaną natychmiast otworzone.


## Apache i SELinux
strona 439

```man httpd_selinux``` - pomoc w temacie selinux dla httpd  
    - ```yum install selinux-policy-doc``` - jeżeli ta strona jest niedostępna to można ją zainstalować   
  
```/etc/sysconfig/selinux``` - plik konfiguracyjny SELinux  

```SELINUX=permissive``` - ustawienie powoduje źe zdarzenia są notowane ale nic nie jest blokowane  


## Apache/httpd - Edytowanie plików konfiguracyjnych

```http://lcaolhost/manual``` - **instrukcje online do apache**   


```/etc/httpd/conf/httpd.conf``` - podstawowy plik konfiguracyjny   
```/etc/httpd/conf.d``` - katalog w którym znajdują się inne pliki używane do konfiguracji *apache* (na podstawie wiersza *Include* w pliku /etc/httpd/httpd.conf)   
```/etc/httpd/conf.modules.d``` - miejsce na dodatkowe moduły dla httpd  

  

```apachectl configtest``` - sprawdzenie configu apache, *dobrze jets używać przed restartem usługi*  



## Używanie dyrektyw

Opisać jakoś 


## Ustawienia domyślne

strona 445

## Dodawanie serwera wirtualnego do serwera Apache

strona 448

The term Virtual Host refers to the practice of running more than one web site (such as company1.example.com and company2.example.com ) on a single machine.  
  
**WAŻNE** - Po włączeniu pierwszego kontenera VirtualHost domyślna dyrektywa DocumentRoot (/var/www/html) nie będzie już używana podczas uzyskiwania dostępu do serwera za pomocą adresu IP lub nazwy niezdefiniowanej w kontenerze VirtualHost.  
Zamiast tego pierwszy kontener VirtualHost zostanie użyty jako domyślna lokalizacja dla serwera.




1. Utworzenie nowego pliku w folderze ```/etc/httpd/conf.d``` 
```bash
vim /etc/httpd/conf.d/example.org
```

2. Edycja pliku, niżej **minimalny config** dla virtual hosta
```html
<VirtualHost *:80>
    ServerName www.example.org
    DocumentRoot /var/www/html/example.org/
</VirtualHost>
```

3. Sprawdzenie configu
```bash
apachectl configtest
```
> Syntax OK

4. 


## Umożliwienie użytkownikom publikowania własnej treści

strona 450

## Rozwiązywanie problemów z serwerem WWW

```apachectl configtest``` - sprawdza poprawnośc configu  
```apachectl graceful``` - powpduje wczytanie nowego configu bez odłączania klientów   
  
```/var/log/httpd/error.log``` - logi dla httpd  
```/var/log/xferlogs``` - logi dla pobieranych i uploadowanych plików 

Przykładowy błąd, problem wskazuje że inny program jest dołączony do portu 80  

> [crit] (98)Address already in use: make_sock: could not bind to port 80  

Może to oznaczać że uruchomiony jest inny proces apache (polecenie apachectl zwykle to wychwytuje) lub zdefiniowano dołączenie tego samego adresu IP i portu w więcej niż tylko jednym miejscu.  
  
Wyświetlenie listy programów wraz z portami TCP w stanie LISTEN:  

```bash
netstat -nltp
```

> Active Internet connections (only servers)  
Proto Local Address Foreign Address State PID/Program name  
tcp6 :::80 :::* LISTEN 2105/httpd  

Dane wyjściowe wskazują, że proces httpd o *PID 2105* nasłuchuje na porcie 80,    
*jeżeli inny proces nasłuchuje na tym samym porcie to również zostanie wyświetlony*   


```httpd -X``` - uruchomienie demona httpd w trybie debugowania, powoduj 


### #TODO - strona 460 - ćwiczenia httpd 


# Serwer FTP

TCP 21 - port do uwierzytelniania ftp
TCP 20 - port na którym serwer przekazuje dane użytkownikowi 
sprawdzić oba ^

- Port 21 musi być otwarty
- Jeżeli SELinux działa w trybie enforce to konieczne jest włączenie opcji boolowskiej
- Domyślnie użytkownik *anonymous* może tylko pobierać pliki, użytkownik zalogowany może pobierać i zapisywać zgodnie z uprawnieniami danego folderu 



---

Po uwierzytelnieniu (port TCP 21) następuje nawiązanie drugiego połączenia między klientem
i serwerem. FTP obsługuje typy połączeń aktywnych i pasywnych. W przypadku aktywnego
połączenia FTP serwer przekazuje klientowi dane z portu TCP 20 do losowo wybranego portu
o numerze większym niż 1023. Natomiast w przypadku pasywnego połączenia FTP klient żąda
od serwera połączenia pasywnego i losowo wybranego numeru portu.

---


```/var/ftp``` - domyślny katalog dla użutkownika anonimowego   
```/home/username``` - domyślny katalog dla użytkowników zalogowanych,   
*użytkownik zalogowany może poruszać się po wszystkich katalogach do których ma uprawnienia*   


```lftp``` i ```ftp``` - komendy do łączenia z serwerem FTP  


## vsftpd - Instalowanie serwera FTP 

```rpm -qc vsftpd``` - wyświetlenie plików konfiguracyjnych   
```rpm -qd vsftpd``` - wyświetlenie dostępnej domkumentacji   


```/etc/vsftpd/vsftpd.conf``` - **główny config**  
```/etc/vsftpd/ftpusers``` i ```/etc/vsftpd/user_list``` - domyślnie zawierają **black listę użytkowników**   
```/etc/pam.d/vsftpd``` - definiuje **sposób uwierzytelniania** na serwerze FTP  


```/etc/logrotate.d/vsftpd``` - konfiguracja sposobu **rotacji logów**  



## Uruchamianie usługi vsftpd

vsftpd włącza się jak każdą usługę systemd

```netstat -tupln | grep vsftpd``` - sprawdzenie czy demon ftp nasłuchuje  

> tcp 0 0 0.0.0.0:21 0.0.0.0:* LISTEN 4229/vsftpd  


```ftp 127.0.0.1``` - logowanie do lokalnego serwera *FTP* 


## Zabezpieczanie serwera FTP

### Otwieranie zapory sieciowej dla FTP

```firewalld``` - służy do zarządzania zaporą sieciową 
```/etc/firewalld/zones``` - folder zawierający reguł zapory 

- W Rhel7 jest opcja konfiguracja zapory z GUI 
- Aby zezwolić na dostęp do serwera FTP **należy otworzyć port 21** a następnie trzeba wczytać moduł zapewniający śledzenie połączenia.   
  

### Konfigurowanie SELinux dla serwera FTP

```dnf install selinux-policy-doc``` - instalacja instrukcji dla usług odnośnie SELinux  
```man ftpd_selinux``` - pomoc dla ftpd odnośnie SELinux   


```getenforce``` - sprawdzenie czy SELinux jest włączony     
- ```enforcing or 1``` - włączony    
- ```permissive or 0``` - zdarzenia są raportowane ale nic nie jest blokowane     
- ```disabled``` - wyłączonu     


```/etc/sysconfig/selinux``` **zmiennna SELINUX=** - ustawienie stanu SELinux   
   

*Jeżeli ftp nie działa* to można przełączyć tymczasowo SELinux w tryb **permissive**, sprawdzić czy coś się zmieni a następnie wrócić do **enforcing**   


### Powiązywanie uprawnień Linuksa z vsftpd


Serwer vsftpd używa standardowych uprawnień Linuksa,  

Dla użytkownika **anonymous** działają uprawnienia przypisane standardowo dla **others**,  
aby uzytkownik anonimowy mógł wyświetlić lub pobrać plik, others musi miec przynajmniej uprawnienia do odczytu (------r--)  
żeby **anonymous** miał dostęp do folderu others musi mieć przynajmniej uprawnienia execute (--------x)  

W przypadku **zwykłych użytkowników**, jeżeli użytkownik ma dostęp do pliku w systemie to będzie miał też dostęp na serwerze FTP,   


### Konfigurowanie serwera FTP


```/etc/vsftpd/vsftpd.conf``` - przeprowadza sie tu większość konfiguracji usługi vsftpd  
```/usr/share/doc/vsftpd``` - przykładowe pliki konfiguracyjne vsftpd  

Pamiętaj o ponownym uruchomieniu usługi vsftpd po wprowadzeniu jakichkolwiek zmian.  


Domyślnie wszyscy **użytkownicy lokalni mają dostęp** do ftp a użytkownicy **anonimowi nie**  
Poniższe ustawienia to zapewniają :  

```bash
anonymous_enable=NO  
local_enable=YES  
```

Konta nie mające uprawnień do shella (/sbin/nologin) mogą mieć dostęp do FTP  

```bash
# ustawienie pliku user_list jako **blacklista**  
```userlist_enable=YES```
# ustawienie pliku user_list jako **whitelista**   
```userlist_enable=NO```  
```

```/etc/vsftpd/user_list``` - lista użytkowników którzy w zależności od ustawienia jako jedyni *mają lub nie mają* dostępu do FTP 
```/etc/vsftpd/ftpusers``` - plik  zawsze zawiera nazwy użytkowników, którzy **nie mają** dostępu do serwera, niezależnie od wartości opcji ```userlist_enable```


### #TODO - ogarnąć jak działa chroot dla ftp 

Jednym ze sposobów ograniczenia dostępu do użytkowników posiadających zwykłe konta użytkowników w systemie jest użycie ustawień chroot.  
Oto kilka przykładów takich ustawień:  

    ```bash
    chroot_local_user=YES
    chroot_list_enable=YES
    chroot_list_file=/etc/vsftpd/chroot_list
    ```

Po zastosowaniu tych ustawień można utworzyć listę użytkowników lokalnych, a następnie
dodać ich do pliku /etc/vsftpd/chroot_list. Gdy któryś z użytkowników wymienionych w tym
pliku zaloguje się do serwera FTP, nie będzie mógł wyjść poza strukturę katalogów znajdujących
się w jego katalogu domowym.

Jeżeli dozwolone jest przekazywanie plików do serwera FTP, katalogi, do których mają trafić
pliki od użytkownika, muszą mieć uprawnienia zapisu przez użytkownika. Jednak przekazane
pliki mogą być przechowywane z inną nazwą użytkownika niż ten, który przekazał dany plik.
Jest to jedna z funkcjonalności omówionych w następnej sekcji



## Przekazywanie plików do serwera FTP


- **Użytkownicy zalogowani** - przekazywanie plików na serwer jest domyślnie włączone (write_enable=YES)   

    ```bash
    # Umożliwienie użytkownikom zalogowanym na przekazywanie plików do serwera 
    write_enable=YES  
    ```   

- **Użytkownicy anonimowi** - mają domyślnie zablokowane przekazywanie plików i tworzenie folderów na serwerze   

    ```bash
    # Włączenie przekazywania plików przez użytkowników anonimowych
    anon_upload_enable=YES

    # Umożliwienie użytkownikom anonimowym tworzenia folderów 
    anon_mkdir_write_enable=YES
    ```

Po włączeniu opcji zapisu dla użytkownika anonimowego bedzie on mógł zapisywać pliki podkatalog w katalogu ```/var/ftp```   
do folderu uprawnienia musi mieć użytkownik ftp, grupa ftp lub others.   
Powszechnie stosowanym rozwiązaniem jest tworzenie przeznaczonego na przekazywane pliki katalogu z uprawnieniem zapisu.   


Utworzenie folderu uploads dla **użytkownika anonimowego**  

    ```bash
    mkdir /var/ftp/uploads
    chown ftp:ftp /var/ftp/uploads
    chmod 775 /var/ftp/uploads
    ```

Określone dla tego katalogu uprawnienia 775, pozwalają zobaczyć istniejące w nim pliki użytkownikowi anonimowemu ale bez prawa do ich zmiany bądź nadpisania.   

Jeżeli chcemy zablokować możliwość usuwania plików dodanych przez użytkowników anonimowych to możemy zastosować opcję chown, którą można umieszczamy w pliku ```vsftpd.conf```  
Po uploadowaniu pliku właścicielem stanie sie wskazany użytkownik,  

```bash
chown_uploads=YES
chown_username=janek
```

Po zastosowaniu powyższej zmiany pliki uploadowane przez użytkownika anonimowego będą należały do uzytkownika *janek* i grupy *ftp*,  
uprawnienia do pliku będzie miał tylko *janek* (rw-------)


### Konfigurowanie vsftpd do udostępnienia serwera w internecie


```rpm -qpd``` - wyświetlenie plików z dokumentacją (razem z przykładowymi plikami konfiguracyjnymi dla vsftpd) 

```/usr/share/doc/vsftpd/EXAMPLE/INTERNET_SITE/vsftpd.conf``` - przykładowy config dla ftp udostępnianego w interneci 

#### Zawartość przykładowego configu, pogrupowane w sekcjach 

1. Uprawnienia dostępu  
```bash
# Access rights

# Włączenie dostępu dla użytkowników anonimowych 
anonymous_enable=YES
# Wyłączenie dostępu dla kont lokalnych, każdy będzie musiał korzystać z konta użytkownika anonimowego
local_enable=NO
# Nikt nie może przekazywac plików
write_enable=NO
# Użytkownik anonimowy nie może przekazywać plików 
anon_upload_enable=NO
# anon nie może tworzyć katalogów
anon_mkdir_write_enable=NO
# anon nie może zapisisywac innych elementów 
anon_other_write_enable=NO
```
  

2. Bezpieczeństwo  
```bash
# Security

# anon będzie miał uprawnienia tylko do plików do ktorych upranienia ma others (------r--)
anon_world_readable_only=YES
connect_from_port_20=YES
# Opcja ukrywa faktyczne uprawnienia przypisane plikowi, 
# użytkownik podłączony do ftp będzie widział że właścicielem wszystkich jest ftp
hide_ids=YES
pasv_min_port=50000
pasv_max_port=60000
```

3. Funkcjonalność serwera
```bash
# Features

# Informacje o przekazaniach i pobraniach plików będą przekazane do /var/log/xferlog
xferlog_enable=YES
# Zabrania ls -R, mogłoby to wymagać wielu zasobów
ls_recurse_enable=NO
ascii_download_enable=NO
async_abor_enable=YES
```

4. Wydajność 

```bash
# Performance
one_process_model=YES
idle_session_timeout=120
data_connection_timeout=300
accept_timeout=60
connect_timeout=60
anon_max_rate=50000
```


## Używanie klientów FTP




## Koniec Biblii



### Strona 468
477



373 - strona na której skończyłem sieci 
383 - strona na ktorej zacząłem po sieciach 
417 - strona na której skończyłem drukarki 
435 - strona od której wznowiłem po drukarkach


You are new System Administrator and from now you are going to handle the system and your main task is Network monitoring, Backup and Restore. But you don't know the root password. Change the root password to redhat and login in default Runlevel.
```bash
# In RHEL8
- reboot the system
- press "e" letter
- Add "rd.break" at the end of de line thet begening with "Linux" in grub menu
- ctrl + x
- # mount -o remount,rw /sysroot
- # chroot /sysroot
- # passwd
- #  touch /.autorelabel
- # exit
- # logout
```


# Itexams
  
- przerobione :
https://www.examtopics.com/exams/redhat/ex200/view/
https://www.examtopics.com/exams/redhat/ex200/view/7/
https://www.examtopics.com/exams/redhat/ex200/view/11/
przerobione do 41 pytania 

- do ogarniecia :
    - FTP, jak dziala, jak pobierac pliki (wedlug komentarzy nie ma juz na egzaminie, mimo wszystko podstawy dobrze miec)
    - httpd ? - niby nie ma



### #TODO - dodać do dnf/yum jak dodać repo z iso
https://access.redhat.com/solutions/1355683





## Skryptowanie 


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
		GATEWAY="$adres_bramy
        ONBOOT=yes"```
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

```lspci``` - można to powiedzieć na podstawie procesora 
	
	
	



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




### Które porty są otwarte 
### Tablica routingu 
### Adres ip lokalnej maszyny  




[Idz na górę](#linuxbash) 
