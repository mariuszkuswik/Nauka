
# Spis treści 

| Kategoria | Nazwa zadania | Link | 
|---|---|---|
| + Przywrocenie hasla | Przywrocenie hasla roota | [Przywracanie hasla roota](#przywracanie-hasła-roota) | 
| + Bash completion | Bash completion | [Bash completion - instalacja](#bash-completion) | 
| - podman | podman - rsyslog | [Podman - rsyslog](#podman---rsyslog) | 
| - podman | podman - httpd | [Podman - httpd](#podman---httpd) | 
| + podman | podman login + rejestry | [RH - Podman rejestry](https://www.redhat.com/sysadmin/manage-container-registries) |
| + autofs | autofs - home dir | [autofs - home dirs](#automatyczne-montowanie-katalogów-domowych) | 
| + lvm-vdo | Utworzenie vdo na lvm | [Tworzenie VDO](#vdo)| 
| + selinux | Rozwiazywanie problemow selinux | [Selinux](#selinux) |  
| + selinux - | Selinux - audit2allow | [audit2allow](#audit2allow) | 
| + chronyd - ntp | synchronizacja czasu chrony | [Synchronizacja czasu](#synchronizacja-czasu-klient-z-serwerem) | 
| + tuned | tuned | [tuned](#tuned-profiles) | 
| + repo | dodanie repo | [Dodawanie nowego repo](#dodanie-nowego-repozytorium) |
| + rpm | podstawy rpm | [rpm](#rpm) | 
| + kernel | Zmiana parametrow kernela | [Zmiana konfiguracji grub ](#zmiana-zmiennych-konfiguracji-grub) | 
| + kernel | update kernela | [Kernel Update](#kernel-update) | 
| + kernel | zmiana domyslnego kernela | [Zmiana domyslnego kernela](https://access.redhat.com/solutions/4326431) | 
| - find - TODO - opisać sensownie, pamietac o + kiedy chcemy znajdowac daty po czasie i o dokladnym wyszukiwaniu | Wyszukiwanie plików | [Wyszukiwanie plików](#wyszukiwanie-plików) |
| - grep | Grep | [grep](#grep) |

# TODO - 

# Wyszukiwanie plików
- [Spis treści](#spis-treści)
## Find 

- Find All Files in /etc (not subdirectories) that where modified more than 180 days ago.
- Znalezienie plików które były modyfikowane **więcej niż 180 dni temu** w folderze /etc, bez uwzględniania katalogów pod lub nad /etc
find /etc -type f -mindepth 1 -maxdepth 1 -mtime +180

- Znalezienie plików które były modyfikowane **dokładnie 180 dni temu** w folderze /etc, bez uwzględniania katalogów pod lub nad /etc
find /etc -type f -mindepth 1 -maxdepth 1 -mtime 180

## Grep


# Bash completion 

- Instalacja 
```
dnf search bash 
dnf install bash-completion 
whereis bash-completion
cd /usr/share/bash-completion 
. ./bash-completion
```

-------


# Przywracanie hasła roota
- [spis treści](#spis-tre%c5%9bci)

1. *Reboot*
2. *W Grubie* - nacisnąć ```e```
3. Na końcu linii zaczynającej się od ```linux``` dodać ```init=/bin/bash``` lub ```rd.break```
4. Naciskamy ```ctrl+x```
5. mount -o remount,rw /sysroot
    - *Katalog z filesystemem można sprawdzić poleceniem ```mount```*
6. chroot /sysroot
7. passwd
8. touch ```/.autorelabel```
    - **WAŻNE!** - bez utworzenia ```/.autorelabel``` SELinux się rozsypie
9. exit
10. reboot now 

# hostname
- ```nmtui``` i ```nmcli``` - pozwalają na zmianę hostname i ip
- ```hostnamectl``` - wyświetla aktualny hostname + informacje na temat systemu
    - ```set-hostname``` - zmienia hostname na podany

# Wyszukiwanie plików 
- [spis treści](#spis-tre%c5%9bci)

## find
- ```find```
    - ```-type``` - typ wyszukiwanych plików 
        ```-f``` - file 
        ```-d``` - firectory
    - ```-mtime``` - file's  data  was last **modified** n*24 hours ago
    - ```-atime``` - file was last **accessed** n*24 hours ago
    - ```-ls``` - list current file in ```ls format```


# Firewall 
- [spis treści](#spis-tre%c5%9bci)

- ```firewall-cmd``` - odpowiada za konfigurację zapory   
    
    - zarządzanie firewallem :  
        - ```--state``` - wyswietla czy firewall dziala
        - ```--reload``` - zatwierdzenie wprowadzonych zmian
        - ```--list-all --permanent``` wypisuje reguły które są zapisane w configu - będą działać po ***reboocie systemu***
        
    - otwieranie portów/usług :  
        - ```--add-port "$port_number"/[tcp | udp ]``` - otwarcie portu dla tcp lub udp
        - ```--add-service "$service_name"``` - udostępnienie możliwości komunikacji z usługą (lista dostępna pod tabulatorem)

#### **WAŻNE!**
**zawsze trzeba pamiętać o opcji ```--permanent```**, w przeciwnym wypadku zmiany nie będą stałe   
oraz o **przeładowaniu firewalla**, w przyciwnym razie zmiany nie zostaną zastosowane

### Przyklady użycie
- Otwarcie portu 80 tcp
    ```console
    firewall-cmd --add-port=80/tcp --permanent
    ```

- Dodanie serwisu mysql do firewalla
    ```console
    firewall-cmd --add-service=http --permanent
    ```

- Wylistowanie ustawiń **PERMANENTNYCH** dla firewalla
    ```console
    firewall-cmd --list-all --permanent
    ```

- Przeładowanie configu firewalla 
    ```console
    firewall-cmd --reload 
    ```

# SELinux
- [Spis treści](#spis-tre%C5%9Bci)

## Instalacja
- ```dnf whatprovides */semanage``` - domyślnie narzędzia SELinux mogą nie być zainstalowane  

## Pomocne komendy
- ```ausearch``` - command parses audit daemon logs. You can view the man page for all of the details, but the -c 'httpd' argument will search for any event with that httpd name.
- ```audit2allow``` - command generates an SELinux policy based on logs returned by ausearch. This tells you that the first command parses the audit logs for anything with an event based on httpd and then generates an SELinux policy to allow it.
- ```getenforce``` - Pokazuje **w jakim trybie** działa SELinux 
- ```sestatus``` - Pokazuje **szczegółowe informacje** na temat SELinux

## audit2allow  
- Wyszukiwanie problemów z SELinux + zezwolenie 
    ```
    ausearch -c "httpd" --raw | audit2allow -M my-httpd
    ```
- Wyszukiwanie problemów + zezwolenie
    ```
    audit2allow -a -M "$nazwa_reguly"
    ```

**Jeżeli mamy jakiś problem z selinuxem to jest duża szansa że odpowiednią komendę znajdziemy poprzez ```grep "$nazwa_usługi" /var/log/messages```**

- ```semanage boolean -l``` - **wyświetlenie opisu** wszystkich zmiennych SELinux 

## Tryby SELinux
### Sprawdzanie trybu selinux 
- ```sestatus``` - szczegółowe informacje
- ```getenforce``` - dostajemy tylko tryb w jakim selinux działa obecnie 

### Zmiana trybu SELinux
- Tymczasowa zmiana 
    - ```setenforce``` - umożliwia tymczasową zmianę trybu - PO REBOOCIE STOSOWANY JEST TRYB Z CONFIGA    
  
- Stała zmiana SELinux - **zmiany zostają zastosowane po reboocie**  
    - zmiana parametru ```SELINUX=``` w pliku ```/etc/selinux/config``` np. ```SELINUX=enforcing```     
        - **enforcing** - selinux działa w pełni, **blokuje**, zdarzenia blokowane są reportowane   
        - **permissive** - selinux tylko zapisuje blokowane akcje w logach, **nic nie jest blokowane**    
        - **disabled** - nic nie jest blokowane, nic nie jest logowane  

- Zmiana podczas bootowania systemu ( parametry przy odpalaniu systemu)  
    - Dopisanie/zmiana parametru ```enforcing``` np. ```enforcing=0``` w linijce ```linux``` (parametry jądra)  - zmiana parametru selinux przy bootowaniu na   permissive     
  
## Konteksty SELinux
Dla większości komend aby sprawdzić kontekst działa parametr ```-Z```,   
np. 
- ```ls -laZ``` - sprawdzenie kontekstu plików 
- ```ps -elZ``` - sprawdzenie kontekstu procesów 


### Sprawdzenie kontekstu pliku 
- ```ls -laZ "$file_name"``` - wyświetlenie kontekstu pliku 
    - **Context** is the one with **_t** suffix - *user_home_dir_t*

```console
# ls -lZ /home

drwx------. chlebik chlebik unconfined_u:object_r:user_home_dir_t:s0 chlebik
```

### Przypisanie kontekstu SELinux
- ```semanage``` - służy do zarządzania kontekstami   
- ```semanage fcontext``` - zarządza kontekstami plików i folderów   
- ```restorecon -Rv``` - służy do zatwierdzenia zmian na folderach, zmiany   etykiet   


# Synchronizacja czasu (klient z serwerem)
- [Spis treści](#spis-tre%C5%9Bci)

1. instalacja chrony 

```console
# dnf install chrony -y
```

2.  Sprawdzenie statusu chronyd i ewentualne odpalenie 

```console
# systemctl status chronyd
# systemctl enable --now chronyd
```

3. Dodanie docelowego serwera w configu ```/etc/chrony.conf```  
Pozostałe wpisy należy usunąć 
    
```console
server 169.254.169.123 iburst
```

4. Restart usługi chronyd

```console
systemctl restart chronyd
```

5. Wymuszenie synchronizacji 

```console
# chronyc makestep

200 OK
```


6. Sprawdzenie czy serwer został zsynchronizowany, jeżeli tak to będzie podane tu jakieś źródło

```console
chronyc sources -v
```

Można też użyć 

```
tinedatectl
```

6. Display parameters about the system’s clock performance

```console
chronyc tracking 
```

# Storage 
## Montowanie
- [Spis treści](#spis-tre%C5%9Bci)

### WAŻNE!
- ```findmnt``` - wyświetla zamontowane filesystemy 
    - ```findmnt --verify``` - sprawdza poprawność fstab
    - ```findmnt --types xfs``` - listuje tylko filesystemy xfs

## Filesystemy
- [Spis treści](#spis-tre%C5%9Bci)

### Comparison of tools used with ext4 and XFS

| Task | ext4 | XFS |
|------|------|-----|
| Create a file system | mkfs.ext4 | mkfs.xfs | 
File system check | e2fsck | xfs_repair
Resize a file system | resize2fs | xfs_growfs
Save an image of a file system | e2image | xfs_metadump and xfs_mdrestore
Label or tune a file system | tune2fs | xfs_admin
Back up a file system | dump and restore | xfsdump and xfsrestore
Quota management | quota | xfs_quota
File mapping | filefrag | xfs_bmap

### xfs 
- [RH - Getting started with XFS](https://access.redhat.com/documentation/en-us/red_hat_enterprise_linux/8/html/managing_file_systems/assembly_getting-started-with-xfs_managing-file-systems)

#### Rozszerzanie filesystemu

#### zmiana właściwości filesystemu 
- Dodać zmianę labelki 
- sprawdzić co jeszcze możmna dopisać

### ext4

- ```e2fsck``` - srawdzenie filesystemu 
- ```resize2fs``` - zmiana wielkości filesystemu
- ```tune2fs``` - zmiana właściwości filesystemu 

#### Rozszerzanie filesystemu

1. Umount filesystemu
2. Sprawdzenie filesystemu
3. 
- ```resize2fs /dev/vdb2``` - filesystem zajmie cala dostepna powierzchnie partycji 

#### zmiana właściwości filesystemu 
- Dodać zmianę labelki 
- sprawdzić co jeszcze możmna dopisać

### TODO - Dodac kopiowanie filesystemu/jakis backup

## LVM 
- [Spis treści](#spis-tre%C5%9Bci)

- ```/dev/mapper/"$group_name"-"$lv_name"``` - ścieżka do utworzonego lvm

### Opisy skrócone
- ```pvs``` - physical volume 
- ```vgs``` - volume group
- ```lvs``` - lvm 

### Opisy długie
- ```pvdisplay``` - physical volume 
- ```vgdisplay``` - volume group
- ```lvdisplay``` - lvm 

- ```pvcreate```
- ```vgcreate```
- ```lvcreate``` 
    - ```-l``` - **liczba extent** z której chcemy utworzyć lvm (wielkość extent jest ustawiony przy volume grupie)

## VDO
- [Spis treści](#spis-tre%C5%9Bci)
- [Poradnik od RedHata](https://access.redhat.com/documentation/en-us/red_hat_enterprise_linux/7/html/storage_administration_guide/vdo-quick-start)
---

1. Instalacja VDO
```console
yum install vdo
```

2. Utworzenie VDO
```
lvcreate --type vdo --size Size[m|UNIT] VG/VDO_pool_name
```
3. Weryfikacja, że wolumen działa 
```
vdostats 
```

## Stratis 
- [Spis treści](#spis-tre%C5%9Bci)
- [Stratis - ogolna strona + how_to](https://stratis-storage.github.io/howto/)  
---

1.  Instalacja 
```sudo dnf install stratis-cli stratisd -y```

```console
dnf whatprovides */stratis
dnf install stratisd stratis-cli
```

2.  Uruchomienie uslugi 
```sudo systemctl enable --now stratisd.service```

### Stratis - Jak utworzyć/usunąć i zamontować system plików Stratis

1. Zainstaluj pakiety Stratis:
```
dnf install stratisd stratis-cli
```
2. Włącz i uruchom usługę Stratisd:
```
systemctl start stratisd
systemctl enable stratisd
```
3. Utwórz pulę: 
- A pool with one block device.
```
# stratis pool create "$stratis_pool_name" /dev/sdb

# stratis pool list
Name             Total Physical Size  Total Physical Used
"$stratis_pool_name"                  1 TiB               52 MiB
```

- A pool with 2 block devices (no redundancy).
```
# stratis pool create tale_of_2_disks /dev/sdd /dev/sdf

# stratis pool list
Name               Total Physical Size  Total Physical Used
"$stratis_pool_name"                    1 TiB               52 MiB
tale_of_2_disks                 16 GiB               56 MiB
```

4. Utwórz system plików w nowo utworzonej puli „Stratis_Test”: 
```
# stratis filesystem create "$stratis_pool_name" fs_howto

# stratis filesystem list
Pool Name      Name      Used     Created            Device
"$stratis_pool_name"  fs_howto  546 MiB  Nov 09 2018 11:08  /dev/stratis/"$stratis_pool_name"/fs_howto
```

5. To create another file system, just repeat the same command with a different file system name. The file system names are required to be unique in a pool.
```
# stratis filesystem create stratis_howto my_precious

# stratis filesystem list
Pool Name      Name         Used     Created            Device
stratis_howto  fs_howto     546 MiB  Nov 09 2018 11:08  /dev/stratis/stratis_howto/fs_howto
stratis_howto  my_precious  546 MiB  Nov 09 2018 11:09  /dev/stratis/stratis_howto/my_precious
```

6. Mount the file system
Dodanie UUID ```/dev/stratis/"$pool_name"/"$filesystem_name"```

5. Utwórz punkt montowania i zamontuj system plików: ...


# Logi 
- [Spis treści](#spis-tre%C5%9Bci)

## Understanding Logging and Using Persistent Journals on RHEL 8

```grep "$nazwa_szukanej_usługi" `find /var/log -maxdepth 1 -type f` | less ``` - Dobrze jest grepować logi w /var/log, w ten sposób dowiemy się które pliki zawierają logi o nazej usłudze

- ```journalctl``` - dziennik zdarzeń dla **systemd**, standardowo resetowany przy reboocie
    - ```journalctl -k``` - Wyświetla komunikaty tylko **na temat jądra**   `
    - ```journalctl -u nazwa_usługi``` - Wyświetlenie komunikatów **dotyczących określonej usługi**:   

    ```console
    journalctl -u NetworkManager.service
    journalctl -u httpd.service
    journalctl -u avahi-daemon.service
    ```

- ```/var/log/messages```

### #TODO - opisać jakoś 

## Ustawienie stałego journalctl 

```/etc/systemd/journald.conf```
```man journalctl.conf``` - pomoc dla pliku 

Zmieniamy zmienną ```Storage```

```Storage=persistent``` - powoduje, że odpowiedni katalog jest tworzony w razie potrzeby
```Storage=auto``` - logi będą zapisywane tylko jeżeli katalog istniał wcześniej 

```bash
[Journal]
#Storage=auto
#Compress=yes
#Seal=yes
#SplitMode=uid
#SyncIntervalSec=5m
#RateLimitIntervalSec=30s
#RateLimitBurst=10000
```

# Uprawnienia
- [Spis treści](#spis-tre%C5%9Bci)

## SUID, SGID, Sticky bit
- [Spis treści](#spis-tre%C5%9Bci)

http://miro.borodziuk.eu/index.php/2017/03/13/uprawnienia-specjalne/

| Bit | Nadanie | Opis |
|--|--|--|
| SUID | 4 lub u+s | buser którzy tworzy plik jest jego właścicielem |
| SGID | 2 lub g+s | grupa która jest właścicielem katalogu jest właścicielem pliku|
| Sticky bit | 1 lub o+t | tylko user może usunąć plik |

## ACL 
- [Spis treści](#spis-tre%C5%9Bci)

**WAŻNE !** - Przy poleceniu **ls -l** trzeba zwracać uwagę na **+**, jeżeli występuje to **oznacza, że dla pliku są ustawione uprawnienia ACL**   
```drwxrw----+ 2 mariusz mariusz 56 Mar 22 19:03 aclki/```     
   
- ```man acl``` -  ogólne informacje o tym jak działają acl 
- ```man mount ```
    - ```acl``` **obsługa acl powinna być domyślnie dostępna w systemie plików**, jeżeli nie to dodać w fstab jeżeli domyślnie nie jest włączone w systemie plików 

### getfacl, pobieranie nadanych ACL  
- ```getfacl "$shared_directory"``` - Wyświetla ACLki dla pliku    
    ```console
    $ getfacl ./a1

    # file: a1  
    # owner: mariusz  
    # group: mariusz  
    user::---  
    user:test:rwx                   #effective:r--  
    group::rwx                      #effective:r--  
    mask::r--   
    other::---   
    ```  

- ```setfacl -m u:jill:r-- "$shared_directory"``` - ustawia uprawnienia 

### setfacl, dodawanie ACL 
- ```setfacl``` - modyfikuje uprawnienia (**--modify**) lub usuwa uprawnienia ACL (**--remove**) 
    - ```setfacl --modify u:"$nazwa_użytkownika":rwx "$nazwa_folderu"``` - setfacl modyfikuje uprawnienia dla folderu *nazwa_folderu*, 
        - ```u``` - wskazuje na nadanie uprawnień użytkownikowi 
        - ```g``` - nadanie uprawnień grupie 
        - ```rwx``` - to uprawnienia jakie zostają nadane w powyższym przykładzie
    
    - ```setfacl --modify u:"$nazwa_użytkownika":--- "$nazwa_folderu"``` - polecenie **odmawia** użytkownikowi wszystkich uprawnień do folderu
        - **WAŻNE!** ```-``` zabrania dostępu, 
            np. ```rw-``` zabrania prawa do wykonywania 
        
  
    - ```setfacl --remove u:"$nazwa_użytkownika"  "$nazwa_folderu"``` - setfacl usuwa uprawnienia "$nazwa_uzytkownika" dla folderu *nazwa_folderu*  


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



# sar - sysstat
- [Spis treści](#spis-tre%C5%9Bci)

**sprawdzanie zasobów systemowych**

### #TODO - przeredagować 

Polecenie ```sar``` jest częścią pakietu sysstat. Po jego zainstalowaniu  
**i uruchomieniu usługi sysstat** ```sudo systemctl sysstat enable --now```  
system natychmiast rozpocznie zbieranie dotyczących aktywności danych, które będzie można wyświetlić później po użyciu określonych opcji polecenia ```sar```.  

### Włączenie usługi sysstat
```console
systemclt enable sysstat
systemctl start sysstat
```

- ```/var/log/sa/sa??``` - domyślne miejsce docelowe dla logów  

- ```sar``` - przeglądanie logów  
    - ```-A``` - wyświetla wszystkie możliwe informacje o systemie 
    - ```-u``` - wyświetla informacje dotyczące procesora   
    - ```-d``` - wyświetla informacje dotyczące dysku  

### #TODO - sar do uzupełnienia, nie było możliwości pobrania na wirtualkę 

# Runlevele 
[Spis treści](#spis-tre%C5%9Bci)  

- ```systemctl set-default graphical.target``` - ustawia tryb graficzny jako działający domyślnie 
- ```systemctl set-default multi-user.target``` - ustawia tryb tekstowy jako działający domyślnie 
- ```systemctl get-default``` - wyświetla obecny defaultowy target 

# autofs 
[Spis treści](#spis-tre%C5%9Bci)

**autofs** - montowanie systemów plików NFS na żądanie

- [RH - autofs](https://access.redhat.com/documentation/en-us/red_hat_enterprise_linux/7/html/storage_administration_guide/nfs-autofs)
- [Montowanie pod /net](#Automatyczne-montowanie-katalogu-/net)  
- [Montowanie katalogów domowych](#Automatyczne-montowanie-katalogów-domowych) 

## WAŻNE! 
```man 5 autofs``` - wyjaśnia w jaki sposób zamontować home directory, w manie szukać ```home```
```mount``` wyświetla listę katalogów mających być zamontowanymi przez autofs 

- Configi 
    - ```/etc/auto.master``` - mapa dla folderów montowania, linkujemy tu config dla poszczególnych katalogów
        ```bash
        # folder do auto-montowania     konfiguracja dla autofs
        /export/home                    /etc/auto.home
        ```

    - ```/etc/auto."$file_name"``` - konfiguracja dla indywidualnych systemów montowania - **SPRAWDZIĆ CZY JEST PLIK** ```/etc/auto.misc``` - objaśnia przykładowo
        ```bash
        # * - dowolny użytkownik
        # & - dowolny folder

        # Użytkownik    opcje montowania    adres serwera:folder do zamontowania
        manny           -fstype=nfs,rw      172.29.188.8:/home/manny
        *               -fstype=nfs,rw      172.29.188.8:/home/&

        ```

    - ```/etc/autofs.conf``` - Główny plik konfiguracyjny usługi 

- Pomoc 
    - ```man 5 auto.master``` - wyjaśnia skłądnie pliku konfiguracyjnego   
    - ```man automount``` - montuje udziały nfs dla pliku auto.master   

- Instalacja
    - ```yum install autofs``` - **instalacja** autofs   
  

## Automatyczne montowanie katalogów domowych
 
```
# Komenda pokazuje liste katalogow eksporowtanych przez serwer  
showmount -e 192.168.10.10 
```
#### UID użytkownika na serwerze nfs i kliencie musi być taki sam!
1. Plik /etc/auto.master - punkt montowania - ścieżka do mapy montowania 
    ```bash
    /home   /etc/auto.home
    ```

2. Plik /etc/auto.home
- Opcja dla jednego użytkownika
    ```bash
    janek  -rw,filesystem=nfs   "$nfs_server_address":/home/janek
    ```
- Opcja dla wielu użytkownikó
    ```bash
    *   -rw,filesystem=nfs  "$nfs_server_address":/home/janek
    ```

3. Enable + restart autofs
    ```bash
    systemctl enable autofs
    systemctl restart autofs
    ```

5. Zmiana **home** w ```/etc/passwd``` 


### Automatyczne montowanie katalogu /net   
Po włączeniu autofs, jeżeli znasz nazwę komputera oraz współdzielonego katalogu, należy po prostu zmienić katalog (cd) na katalog montowania autofs (domyślnie /net lub /var/autofs). W ten sposób współdzielony zasób zostanie automatycznie zamontowany i udostępniony.    
### #TODO - Dopisać jakiś przykład

1. **Otworzyć plik /etc/auto.master, a następnie znaleźć następujący wiersz:**  

    ```/net -hosts```

    Wiersz ten powoduje, że katalog /net będzie funkcjonował jako punkt montowania dla współdzielonych katalogów NFS, do których chcesz uzyskać dostęp w sieci. *(Jeżeli na początku wiersza znajduje się znak komentarza, wówczas trzeba go usunąć)*.  

2. **Uruchomienie usługi autofs**  

    ```systemctl enable --now autofs``` 
   
   
3. Po przeprowadzeniu powyższej procedury, jeżeli mamy dostęp do jakiegoś udziału udostępnionego NFS to będzie on dostępny pod :     
**/net/hostname/sharename**   
  
np. ```cd /net/localhost/pub```  


# Instalacja/update
- [Spis treści](#spis-tre%C5%9Bci)

## Lokalny spis
- [Dnf](#dnf)
- [Repozytoria](#repo)
- [Dodanie nowego repozytorium](#dodanie-nowego-repozytorium)

## Repo
### Pomoc
```man dnf.conf``` - pomoc dla opcji konfiguracyjnych repozytoriów

### Config 
- ```/etc/yum.repos.d``` - katalog z plikami konfiguracyjnymi dla repozytowiów 
    - ```"$repo_name".repo``` - pliki nazywamy w konwencji nazwa_repo.repo

### Polecenia
```dnf repolist``` - pokazuje liste repo i ewentualne błędy  
```dnf repoquery``` - wyświetla dostępne do pobrania pakiety

### Pobranie lokalnie repozytorium 
```dnf reposync --download-metadata --downloaddir "$path_to_download"``` - Pobranie lokalnie plików repozytorium


### Dodanie nowego repozytorium
1. Dodajemy plik konfiguracyjny o nazwie repozytorium 

```bash
[nazwa_repo]
name="$nazwa_repo"

# https://link lub file:///plik dla plików lokalnych
baseurl="$repo_link"

# Czy sprawdzać klucz gpg - 0 lub 1 
# Klucz gpg sprawdza czy paczki w repo nie zostały podmienione
gpgcheck="no" 
gpgkey="$gpg_path"
sslverify=no
sslke
```


## Dnf
### Podstawowe operacje
- dnf install "$package"
- dnf list ```updates``` - wyświetla listę dostępnych updatów
    - "$package" - wyświetla paczkę 
- dnf update "$package" - updatuje tylko wskazaną paczkę 
- dnf remove "$package" - usuwa wskazaną paczkę 
  
- dnf history - wyświetla listę operacji  

> ID| Command                  | Date and time    | Action(s)| Altered    
> ------------------------------------------------------------------    
> 12 | -y remove httpd         | 2021-12-22 01:12 | Removed  |   10  
> 11 | -y update bash          | 2021-12-22 01:12 | Upgrade  |    1  
> 10 | -y install wireshark    | 2021-12-22 01:07 | install  |   98  
>  9 | install -y httpd        | 2021-12-22 01:04 | Install  |   10  <  
 8 |                         | 2021-12-22 01:02 | I, U     |   81 >  
 7 | install -y git          | 2021-09-03 15:10 | Install  |   48  

- dnf -y history rollback 11 - cofa operacje o ID 11
You can use other relative offsets, such as ```last-3```


### Modules

1. List module streams available to your system:
```console
$ yum module list
```

2. Display details about a module, including a description, a list of all profiles, and a list of all provided packages:
```console
$ yum module info module-name
```

3. Display the current status of a module, including enabled streams and installed profiles:
```console
$ yum module list module-name
```

### Installing Applications via Modules

1. lists all modules
```console
# yum module list
```

2. lists all modules for postgresql
```console
# yum module info postgresql 
```


## Rpm 
- [Spis treści](#spis-treści)

### Kernel update 
- [RH - Kernel update](https://access.redhat.com/documentation/en-us/red_hat_enterprise_linux/8/html/managing_monitoring_and_updating_the_kernel/updating-kernel-with-yum_managing-monitoring-and-updating-the-kernel)  
- [Lokalnie - Zarządzanie kernelem](#kernel)  

1. Kernel Update 
```
# yum update kernel
```

2. Installation of a specific kernel version:
```console
# yum install kernel-{version}
```
# Archiwizowanie 
- [Spis treści](#spis-tre%C5%9Bci)

### #TODO - do uzupełnienia
- Jak tworzyć inne typy archiwów niż gzip 
- Jak dodać coś do istniejącego archiwum 

### Tar
- tar
    - ```c``` - create
    - ```v``` - verbose 
    - ```z``` - gzip
    - ```f``` - file  
    - ```t``` - wylisowanie plików archiwum 
    - ```x``` - extract 
    - ```u``` - update files that are newer 

### przyklady
- ```tar -cvzf "$plik_archiwum" "$folder_do_skompresowania"``` - tworzenie nowego gzipowego archiwum 
- ```tar -tvzf "$plik_archiwum" "$folder_do_skompresowania"``` - wyświetlenie list plików w gzipowym archiwum 
- ```tar -xvzf "$plik_archiwum" "$folder_do_skompresowania"``` - wypakowanie gzipowego archiwum

### gzip

### bzip

### todo - cos jeszcze?

# Swap
- [Spis treści](#spis-tre%C5%9Bci)

### Wlaczenie/Wylaczenie swapu  
- ```swapon -a``` - wlaczenie calego swapu z fstab? 
- ```swapoff -a``` - wylaczenie calego swapu z fstab? 

### Utworzenie partycji swapowej
- ```mkswap``` - tworzenie systemu plików swapowego 
- ```fstab``` - dodawanie swapowej partycji/pliku 
    - ```"$UUID"/PATH   SWAP    SWAP    defaults    0 0```

### Utworzenie pliku swapowego
- ```fallocate``` - przypisanie plikowi określonej ilości zajmowanego miejsca
### TODO - tworzenie swapu z pliku, procedura do ogarnięcia

# Grub/Kernel
- [Spis treści](#spis-tre%C5%9Bci)

### Linki 
- [rh - how to change boot options on linux](https://www.redhat.com/sysadmin/linux-change-boot-options-grub)
- [Zmiana ustawień grub](https://www.unixarena.com/2015/04/how-to-edit-the-grub-on-rhel-7.html/)

## Grub
- ```grubby``` - command line tool for configuring grub
- ```grub2-mkconfig``` - generuje skrypt konfiguracyjny, możliwy do przekierowania do właściwego configu - ```/boot/grub2/grub.cfg```
- ```grub2-script-check``` - sprawdza czy utworzony config jest poprawny

### Pomoc
- ```man grubby``` - wskazany plik konfiguracyjny  
- ```info grub2``` - mocno wyjaśnione bootowanie  
- ```info grub``` - starsza wersja, nadal może tam coś być 

### Config
- ```/boot/grub2/grub.cfg``` -  plik konfiguracyjny dla **grub**, generowany automatycznie przez **grub2-mkconfig** na podstawie wpisów w **/etc/default/grub**
- ```/etc/default/grub``` - config dla **KOMENDY GENERUJĄCEJ SKRYPT BOOTUJĄCY, NIE DLA GRUBA**,  
    - ```grub2-mkconfig > /boot/grub2/grub.cfg``` - **ZATWIERDZENIE ZMIAN** - aktualizacja skryptu dla grub

### Zmiana zmiennych konfiguracji Grub
- [Spis treści](#spis-treści)

1. Edycja zmiennych dla komendy ```grub2-mkconfig```
```console
# vim /etc/default/grub

### Przykładowa zmiana
GRUB_TIMEOUT=15
```

2. Utworzenie backupu starego configu 
```console
# cp /boot/grub2/grub.cfg ~/grub.cfg
```

3. Utworzenie configu na podstawie wpisu z punktu drugiego i przekierowanie powstałego skryptu do pliku konfiguracyjnego
```console
# grub2-mkconfig > /boot/grub2/grub.cfg
```

## Kernel
- [Spis treści](#spis-treści)
- [Kernel Update](#Kernel-update)

### Linki
- [Zmiana domyslnego kernela](https://access.redhat.com/solutions/4326431)
- [Fedora przydatne](https://docs.fedoraproject.org/en-US/fedora/latest/system-administrators-guide/kernel-module-driver-configuration/Working_with_the_GRUB_2_Boot_Loader/)

---
- ```grubby --add-kernel="$kernel-path"```   
- ```grubby --default-kernel```   
- ```grubby --info="$kernel-path"```  
- ```grubby --remove-kernel="$kernel-path"```  
- ```grubby --update-kernel=kernel-path```  

## Managing kernel modules
- [RH - Managing kernel modules](https://access.redhat.com/documentation/en-us/red_hat_enterprise_linux/8/html/managing_monitoring_and_updating_the_kernel/managing-kernel-modules_managing-monitoring-and-updating-the-kernel)

# Sieci
[Spis treści](#spis-tre%C5%9Bci)

### **Zmiana** ustawien sieciowych
- ```nmcli``` - Zarządzanie network managerem za pomocą **komend tekstowych**     
    - ```nmcli con reload``` - Zaktualizowanie konfiguracji dla urządzeń sieciowych (ifcfg-interface), **wszelkie zmiany przy pomocy komendy ip nie są trwałe**
- ```nmtui``` - Zarządzanie network managerem za pomocą **terminalowego GUI**  
---

### **Wyswietlenie** ustawien sieciowych
- ```ip``` - show / manipulate routing, network devices, interfaces and tunnels
    - ```ip route show```
    - ```ip address show```

# Kontenery
[Spis treści](#spis-tre%C5%9Bci)

## Przydatne  
- Selinux
```podman -v "volume_hosta:volume_kontenera:Z"``` - z dopiskiem ```:Z``` podman sam ogarnie SELinuxa!**  

- Uruchomienie terminala jako root  
```podman exec -u 0 -it "$nazwa_kontenera" bash``` - uruchomienie interaktywnego terminala jako **root** (```-u 0```)  
  
## Pomoc 
- ```man -k podman``` - wyświetla wszystkie potrzebne komendy podmana   
- ```man podman-generate-systemd``` - pomaga w instalacji dla zwyklego uzytkownika, dobrze grepowac "home"

## Instalacja
- ```dnf module install -y container-tools``` - instaluje podmana i container-tools
- ```systemctl enable podman --now``` 

## Komendy, stawianie uslugi
### Obrazy kontenerów
- **Rejestr** 
    - **The list of registries is defined in /etc/containers/registries.conf**
    - ```podman login "$registryURL" -u username [-p password]``` - logowanie do rejestru kontenerów 
    - ```podman logout```- Log out of the current remote registry  
- **Wyszukiwanie obrazu**  
    - ```podman images``` - List all local images  
    - ```podman search "$nazwa_obrazu"``` - wyszukiwanie obrazu kontenera w rejestrze 
- **Pobranie obrazu** 
    - ```podman pull "$nazwa_obrazu"``` - pobranie obrazu z rejestru 
- **Zarządzanie obrazami**
    - ```podman image``` - zarządzanie obrazami kontenerów 
        - ```podman image list``` - listuje dostępne obrazy 
        - ```podman image rm "$nazwa_obrazu"``` - usuwa obraz 
        - ```podman image tag "$nazwa_obrazu" "$tag"``` - nadaje obrazowi tag

### Operacje na kontenerach
- **Tworzenie kontenera**
    - ```podman container``` - operacje wykonywane na kontenerach     
        - ```podman container create "$nazwa_obrazu"``` - utworzenie kontenera z obrazu 
        - ```podman container list --all``` - listuje wszystkie kontenery, również te nieaktywne
        - ```-v``` - mapowanie udziału host-kontener
        - ```-p 80:80``` - mapowanie portu host-kontener
- **Uruchamianie**
    - ```podman run -d —name``` - Launch a new container to use as a model to generate the systemd unit files
- **Operacje**
    - ```podman exec``` - wykonanie komendy na kontenerze 
        - ```podman exec -it -u 0 "$nazwa_kontenera" bash``` - odpala interaktywną sesję jako root  (```-u 0``` oznacza użytkownika o uid 0 czyli roota)  
- **Stan**
    - ```podman stop|start <container>```
    - ```podman rm <container>``` - Get rid of the container you created before you try to start your systemd container


### Rootless containers as a service  
- [Rootless container service](https://www.linuxtechi.com/run-containers-systemd-service-podman/)

- **Włączenie opcji uruchamiania usługi bez zalogowania? Doczytać**
    - ```loginctl enable-linger``` - Włącza trwałość non-root kontenerów
    - ```loginctl disable-linger``` - Wyłącza trwałość non-root kontenerów
    - ```loginctl show-user <username>``` - Pokazuje konfirgurację użytkownika, dobre do sprawdzenia czy linger jest włączony dla danego użytkownika 
- **Podman - systemd**
    - podman generate systemd - wygenerowanie configu? dla sysmtemd 
    - ```~/.config/systemd/user/``` - Ścieżka w której zwyczajowo trzymane są pliki **.service** użytkownika
        - ```mkdir -p ~/.config/systemd/user```
    - ```podman generate systemd``` - Generate systemd unit file from your container. Must delete the container as systemd will create a new one.
        ```podman generate systemd --name myubi > ~/.config/systemd/user/container-myubi.service``` 
        - DO SEKCJI ```[SERVICE]``` DODAJEMY ```USER="$user"```, DZIĘKI TEMU UŻYTKOWNIK MOŻE URUCHAMIAĆ SERWIS, TYM SAMYM JEST DOSTĘP DO KONTENERÓW    
- **Systemd - Uruchomienie usługi**
    - ```systemctl --user daemon-reload``` - Update konfiguracji systemd po dodaniu plików konfiguracyjnych
    - ```systemctl --user start|stop|enable UNIT``` - Zarządzanie usługami systemd użytkownika
        - ```systemctl --user enable --now container-myubi.service``` - Uruchomienie usługi kontenera przy starcie systemu

### Kontenery - SeLinux 
- [RH - How to modify SELinux settings with booleans](https://www.redhat.com/sysadmin/change-selinux-settings-boolean)

**Każdy wolumen musi mieć odpowiednio udostępniony plik - Z ODPOWIEDNIO USTAWIONYM KONTEKSTEM PLIKU**
- podman container create --volume "volume/volume:Z" - podman sam ogarnie odpowiednie konteksty 
- kontekst dla folderów które mają byc udostępnione może być taki sam jak dla reszty plików 
SRPAWDZIĆ TO MOŻNA PO PODŁĄCZENIU DO TERMINALA KONTENERA I WYDANIU POLECENIA ```ls -lZ /```


## Obrazy kontenerów
### Inspecting images - skopeo
- ```skopeo``` - used to inspect, copy, delete and sign container images


## podman - httpd
- [Spis treści](#spis-treści) 

- serrice: httpd
- user: cloud_user
- shared folder: ~/web_data:/var/www/html
- port: 8000:8080

1. ```mkdir -p /home/cloud_user/.config/systemd/user``` - katalog dla zwyklego usera
2. ```podman run -d --name web_server -p 8000:8080 -v "~/web_data:/var/www/html:Z" "$container_image"``` tworzenie kontenera w trybie detach 
3. ```podman ps -a``` - wyswietlenie kontenerow ktore dzialaja
4. ```curl 127.0.0.1:8000``` / ```curl http://127.0.0.1:8000/text.txt```
5. ```podman generate systemd --name web_server --files --new``` - ### TODO - sprawdzic opcje
6. cp plik do katalogu
6. podman stop web_server 
7. podman rm web_server 
8. podman ps -a - potwierdzenie, ze zostal usuniety 
9. loginctl enable-linger cloud_user
10. loginctl show-user cloud_user | grep linger 
11. systemctl --user daemon-reload
12. systemctl --user enable --now container-web_server.service
13. systemctl --user status container-web_server.service
14. ```curl http://127.0.0.1:8000/text.txt```
15. systemctl reboot now - reboot dla potiwerdzenia 
14. ```curl http://127.0.0.1:8000/text.txt``` - potiwerdzenie po reboocie 


1. loginctl enable-linger "$user" 
2. loginctl show-user "$user" - sprawdzenie czy linger jest wlaczony dla uzytkownika?
2. podman generate systemd
    - Pliki uslug systemd uzytkownika ```~/.config/systemd/user```
3. systemctl --user daemon-reload - przeladowane plikow systemd dla uzytkownikow standardowych
5. systemctl --user enable|start|stop "$UNIT" - obsluga uslug systemd dla uzytkownikow 


# Tuned profiles
- [Spis treści](#spis-tre%C5%9Bci)

**TuneD** - tuned is a dynamic adaptive system tuning ```daemon``` that tunes system settings dynamically depending on usage.

```
systemctl enable --now tuned
```

- ```tuned-adm``` - command line tool for switching between different tuning profiles
    - ```tuned-adm list``` - wyświetlenie wszystkich dostępnych profili 
    - ```tuned-adm active``` - wyświetlenie obecnie działających profili 
    - ```tuned-adm profile "$profile_name1" "$profile_name2"``` - Switches  to  the given profile. If more than one profile is given, the profiles are merged
