# Ogólne linki 
- [oreily link](https://learning.oreilly.com/videos/red-hat-certified/9780135656495/9780135656495-rcsa_02_10_08/)
- [cloud guru link](https://learn.acloud.guru/course/red-hat-certified-system-administrator-ex200-exam-prep/learn/4a50133e-bbdb-43b8-b939-5f648997ec6d/9a5ffcb1-8849-4fe1-a2ae-3ed99bfc32ba/watch)
- [red hat - sysadmin](https://www.redhat.com/sysadmin/)


# Start
# Spis treści
1. [pomoc](#pomoc)
1. [przywracanie hasła roota](#przywracanie-hasła-roota)
1. [selinux](#selinux)
1. [wyszukiwanie plików](#wyszukiwanie-plików) 
1. [firewall](#firewall)
1. [kontrola czasu w rhel](#kontrola-czasu-w-rhel)
1. [managing schedulded tasks](#managing-schedulded-tasks)
1. [storage](#storage)
    - [montowanie](#montowanie)
    - [filesystemy](#filesystemy)
    - [lvm](#lvm)
        - [vdo](#vdo)
    - [stratis](#stratis)
1. [logi](#acl)
1. [uprawnienia](#uprawnienia)
    - [suid, sgid, sticky bit](#suid,-sgid,-sticky-bit)
    - [acl](#acl)
1. [sysstat](#sar---sysstat)
1. [instalacja/update](#instalacjaupdate)
    - [dnf](#dnf)
    - [modules](#modules)
    - [repo](#repo)
        - [dodanie nowego repo](#dodanie-nowego-repozytorium)
1. [blokowanie połączenia z konkretnego serwera](#blokowanie-po%c5%82%c4%85czenia-z-konkretnego-serwera)
1. [autofs](#autofs)
1. [archiwizowanie](#archiwizowanie)
1. [swap](#swap)
1. [sieci](#sieci)
1. [kontenery](#kontenery)
1. [tuned profiles](#tuned-profiles)
1. [grub/kernel](#grubkernel)

---
-  [przed egzaminem!!!](#przed-egzaminem)
-  [po egzaminie](#po-egzaminie) - pytania z egzaminu
- [Po egzaminie 2](#po-egzaminie-2)
---
# Zadania 
- [chlebik](#chlebik)    
- [cloud guru](#cg)    
- [daily zadanka](#daily-zadanka)  
- [rh - laby](https://lab.redhat.com/)
  
[koniec](#koniec)   
  

## Przykladowe zadania 

| Kategoria | Nazwa zadania | Link | 
|---|---|---|
| Przywrocenie hasla | Przywrocenie hasla roota | [Przywracanie hasla roota](#przywracanie-hasła-roota) | 
| Bash completion | Bash completion | [Bash completion - instalacja](#bash-completion) | 
| podman | podman - rsyslog | [Podman - rsyslog](#podman---rsyslog) | 
| podman | podman - httpd | [Podman - httpd](#podman---httpd) | 
| podman | podman login + rejestry | [RH - Podman rejestry](https://www.redhat.com/sysadmin/manage-container-registries) |
| autofs | autofs - home dir | [autofs - home dirs](#automatyczne-montowanie-katalogów-domowych) | 
| lvm-vdo | Utworzenie vdo na lvm | [Tworzenie VDO](#zadanie---tworzenie-vdo)| 
| selinux | Rozwiazywanie problemow selinux | [audit2allow](#audit2allow) | 
| chronyd - ntp | synchronizacja czasu chrony | [Synchronizacja czasu](#synchronizacja-czasu-klient-z-serwerem) | 
| tuned | tuned | [tuned](#tuned-profiles) | 
| repo | dodanie repo | [Dodawanie nowego repo](#dodanie-nowego-repozytorium) |
| rpm | podstawy rpm | [rpm](#rpm) | 
| kernel | Zmiana parametrow kernela | [Zmiana konfiguracji grub ](#zmiana-zmiennych-konfiguracji-grub) | 
| kernel | update kernela | [Kernel Update](#kernel-update) | 
| kernel | zmiana domyslnego kernela | [Zmiana domyslnego kernela](https://access.redhat.com/solutions/4326431) | 


## chlebik
- [spis treści](#spis-tre%c5%9bci)

| zadanko | notatki | czy opanowane |
|--|--|--|
| [001_restore_root_password](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/001_restore_root_password.md) | [przywracanie hasła roota](#przywracanie-hasła-roota) | tak, WAZNE, ++++ |
| [002_setup_network_parameters](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/002_setup_network_parameters.md) | [sieci](#sieci) | tak, ++ |
| [003_change_hostname]( https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/003_change_hostname.md) | [hostname](#hostname) | tak, ++ |
| [004_enable_selinux](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/004_enable_selinux.md) |[selinux](#selinux) | tak, ++ |
| [005_install_apache_and_give_it_permission_to_nfs_resource](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/005_install_apache_and_give_it_permission_to_nfs_resource.md) | [selinux](#selinux) | PRZECWICZYC, PROBLEM, mozliwe ze problemem jest kernel, sprawdzic |
| [006_extend_existing_lv_add_label](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/006_extend_existing_lv_add_label.md) | [lvm](#lvm) | tak, +++ | 
| [007_assign_sel_context_to_the_directory](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/007_assign_sel_context_to_the_directory.md) | [selinux](#selinux) - man semanage-fcontext, **jest w przykładach** | tak, +++ |
| [008_create_users_with_specified_uid](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/008_create_users_with_specified_uid.md) | [tworzenie użytkowników](#tworzenie-użytkowników) | tak, dopisac chage do instrukcji +++ |
| [009_allow_other_user_to_get_access_to_home_dir](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/009_allow_other_user_to_get_access_to_home_dir.md) | [acl](#acl) | tak, +++ |
| [010_dir_ownership_via_group](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/010_dir_ownership_via_group.md) | [suid,sgid,sticky bit](#suid-sgid-sticky-bit) | tak, +++ |
| [011_create_logical_volume_and_add_filesystem](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/011_create_logical_volume_and_add_filesystem.md) | [lvm](#lvm) | tak, ++++ |
| [012_configure_virtual_console_for_kernel](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/012_configure_virtual_console_for_kernel.md) |  | #todo - nie wiem o co chodzi |
| [013_create_swap_on_logical_volume](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/013_create_swap_on_logical_volume.md) | [swap](#swap) | tak, +++ |
| [014_add_entry_to_cron](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/014_add_entry_to_cron.md) | [sysstat](#sar---sysstat) | tak, ++++ |
| [015_set_default_system_level](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/015_set_default_system_level.md) | [runlevele](#runlevele) | tak, +++ |
| [016_add_additional_remote_yum_repo](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/016_add_additional_remote_yum_repo.md) | [dnf](#dnf) | tak, WAZNE, ++ |
| [017_create_physical_partition_and_mount](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/017_create_physical_partition_and_mount.md) |  | tak, ++ |
| [018_update_kernel_and_make_it_default_one](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/018_update_kernel_and_make_it_default_one.md) | [grub/kernel](#grubkernel) | nie, + |
| [019_create_users_with_secondary_groups](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/019_create_users_with_secondary_groups.md) | [tworzenie użytkowników](#tworzenie-użytkowników) | tak, ++ |
| [020_create_folders_with_group_access_rights](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/020_create_folders_with_group_access_rights.md) | [suid, sgid, sticky bit](#suid,-sgid,-sticky-bit) | tak, +++ |
| [021_configure_ldap_authentication](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/021_configure_ldap_authentication.md) | - | **nie ma na egzaminie** |
| [022_configure_autofs](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/022_configure_autofs.md) | [autofs](#autofs) | tak, +++ |
| [023_configure_ntp_on_the_client](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/023_configure_ntp_on_the_client.md) |[Synchronizacja czasu chrony](#synchronizacja-czasu-klient-z-serwerem) | tak, ++++ | 
| [024_access_rights_for_file](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/024_access_rights_for_file.md) | [acl](#acl) | tak, +++ |
| [025_create_whole_lvm_stack](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/025_create_whole_lvm_stack.md) | [lvm](#lvm) dodać extent of vg should be 16mb do notatek | tak, +++ |
| [026_reduce_the_size_of_lv](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/026_reduce_the_size_of_lv.md) | [LVM - Dodawanie i zmniejszanie](#zadanie---rozszerzanie-i-zmniejszanie-filesystemu-na-lvm) | tak, +++ |
| [027_create_compressed_archive](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/027_create_compressed_archive.md) | [archiwizowanie](#archiwizowanie) | tak, +++ |
| [028_search_string_using_grep_and_redirect](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/028_search_string_using_grep_and_redirect.md) | [wyszukiwanie plików](#wyszukiwanie-plik%c3%b3w) | tak, +++ |
| [029_make_journald_persistent](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/029_make_journald_persistent.md) | [Ustawianie stalego journal](#ustawienie-stałego-journalctl) | tak, +++ |
| [030_setting_up_vdo](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/030_setting_up_vdo.md) | [vdo](#vdo) | tak, +++ - poćwiczyć |
| [031_finding_files](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/031_finding_files.md) | [wyszukiwanie plików](#wyszukiwanie-plik%c3%b3w) | tak, ćwiczyć na innych przykladach! +++ |
| [032_finding_files_with_given_text_in_them](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/032_finding_files_with_given_text_in_them.md) | [wyszukiwanie plików](#wyszukiwanie-plików)  | tak, dodać do krótkich +++ |
| [033_managing_layered_storage](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/033_managing_layered_storage.md) | [Stratis - jak utworzyć](#jak-utworzyć--usunąć-i-zamontować-filesystem-stratis) | tak, ++ |
| [034_containers](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/034_containers.md) | [kontenery](#kontenery) | tak, ćwiczyć z rsyslogiem! ++ |

## cg 
- [spis treści](#spis-tre%c5%9bci)

| zadanko | notatki | czy wykonane |
|--|--|--|
| 1. [create users/groups and configure superuser access on both servers](egzamin_praktyczny_cg.md/#create-usersgroups-and-configure-superuser-access-on-both-servers) | [użytkownicy](#użytkownicy), [grupy użytkowników](#grupy-użytkowników) | +, dalej do ogarniecia szybka automatuzacja |   
| 2. [configure yum repositories on both servers and install packages/modules](egzamin_praktyczny_cg.md/#configure-yum-repositories-on-both-servers-and-install-packagesmodules) | [Repo](#repo) | tak, ++ |
| 3. [configure ip addresses on the second network interface on the first server](egzamin_praktyczny_cg.md/#configure-ip-addresses-on-the-second-network-interface-on-the-first-server) | [Zmiana ustawien sieciowych](#zmiana-ustawien-sieciowych) | tak, ++ |
| 4. [managing tuned profiles and individual processes](egzamin_praktyczny_cg.md/#configure-yum-repositories-on-both-servers-and-install-packagesmodules#managing-tuned-profiles-and-individual-processes) | [tuned profiles](#tuned-profiles) | tak, ++ | 
| 6. [manage-scheduled-tasks-on-the-first-server ](egzamin_praktyczny_cg.md/#6-manage-scheduled-tasks-on-the-first-server) | [cron, at](#managing-schedulded-tasks) | tak, + | 
| 7. [configure-time-service-clients-for-both-servers](egzamin_praktyczny_cg.md/#7-configure-time-service-clients-for-both-servers) | [Configure time services](#kontrola-czasu-w-rhel) | tak, ++ | 
| 8. [managing-the-system-bootloader](egzamin_praktyczny_cg.md/#8-managing-the-system-bootloader) | [Zmiana zmiennych konfiguracji Grub](#zmiana-zmiennych-konfiguracji-grub) | tak, +++ | 
| 9. [configure-persistent-storage-with-lvm-on-top-of-vdo](egzamin_praktyczny_cg.md/#9-configure-persistent-storage-with-lvm-on-top-of-vdo) | [LVM/VDO](#vdo) | tak, +++, WAZNE | 
| 10. [add-swap-space-persistently-and-nondisruptive](egzamin_praktyczny_cg.md/#configure-yum-repositories-on-both-servers-and-install-packagesmodules)| [Swap](#swap) | tak, + | 
| 11. [configure-stratis-storage-persistently](egzamin_praktyczny_cg.md/#11-configure-stratis-storage-persistently) | [Stratis - jak utorzyć](#jak-utworzyć--usunąć-i-zamontować-filesystem-stratis) | tak, + | 
| 12. [configure-autofs-for-home-directories](egzamin_praktyczny_cg.md/#12-configure-autofs-for-home-directories) | [autofs](#autofs) | tak, ++++ | 
| 13. [configure-a-shared-directory-for-collaboration ](egzamin_praktyczny_cg.md/#13-configure-a-shared-directory-for-collaboration) | [acl](#acl) | tak, ++ | 
| 14. [create-a-persistent-systemd-container-using-podman](egzamin_praktyczny_cg.md/#14-create-a-persistent-systemd-container-using-podman) | [kontenery](#kontenery) | tak, +++ | 
| 15. [troubleshoot-selinux-issues](egzamin_praktyczny_cg.md/#15-troubleshoot-selinux-issues) | [selinux](#selinux) - man semanage-fcontext, **jest w przykładach** | + | 
| 16. [configure-the-firewall-on-both-servers](egzamin_praktyczny_cg.md/#16-configure-the-firewall-on-both-servers) | [firewall](#firewall) | + | 



# Po egzaminie 2 
## Pytania 2
| lp. | Ogarnięcie | Opisane? | Zadanie | 
|--|--|--|--|
| 1 | + | + | autofs - mapowanie home directory  home folder to /rhome, ma dzialac dla jegnego uzytkownika|
| 2 | - | +/- | Budowanie obrazu kontenera z pliku |
| 3 | + | + | Budowanie kontenera, kontener ma miec udostepnione foldery, dzialac przy starcie systemu jako konkretny user,  |
| 4 | +  | + | Usluga httpd nie dziala, ma dzialac na porcie 82 i ma miec dostep do plikow - pliki nie maja nadanego kontekstu selinux, pamietac o tym + nauczyc sie jak przypisywac porty selinux |
| 5 | + | + |  Problem z repo - dnf, sudo itd nie jest dostepne, nie udalo mi sie podlaczyc repo  |
| 6 | + | + | Reset hasla roota - montowanie katalogu roota jako read only, tak zeby zbootowac |
| 7 | + | + | Tworzenie partycji z systemem plikow ext3, montowal mi sie jako ext4 - ext2+ journal? sprawdzic |
| 8 | + | + | Dodanie partycji swapowej |
| 9 | + | + | Dodanie stacka LVM - VG ma miec okreslona wielkosc extent, LVM ma miec wielkosc 50 extents |
| 10 | + | + | Rozszerzenie istniejacego LVM bez naruszenia filesystemu |
| 11 | + | + | Dodanie uzytkownikow z grupami pobocznymi, jeden z uzytkownikow nie powinien moc sie logowac do shella |
| 12 | + | + | Dodanie uzytkownika z konkretnym UUID |
| 13 | + | + | Dodanie folderu wspoldzielonego, kazdy plik ktory jest tworzony ma nalezec do grupy, uprawnienia ma miec tylko grupa |
| 14 | + | + | Chrony - ustawienie serwera |
| 15 | + | + | tuned-adm - ustawienie profilu zalecanego jako defaultowy? co kolwiek to znaczy   - get the recommended profile for tuned-adm and set is as default|
| 16 | +/- | -/+ | archiwizowanie tar /usr/local jako bzip2 |
| 17 | - | + | Nowo tworzeni uzytkownicy maja miec haslo wazne 20 dni, nie dzialalo z /etc/defaults/useradd |
| 18 | + | + | Repo2 - Dodaj repo do serwera 2 |
| 19 | + | + | Networking - ustawienie adresu ip  |
| 20 | + | + | Ustawienie odpowiedniego hostname |
| 21 | + | + | Zadanie w cronie - co dwie minuty ma wykonywac polecenie logrotate "testowe echo" jako jaki uzytkownik |
| 22 | + | + | Wyszukiwanie linii w pliku z konkretnym słowem, grep ale upewnić się jak to ma być zrobione, słowa mają byc przekierowane do pliku, nie może być żadnych dodatkowych linii, słowa mają być dokładnie w tej kolejności |
| 23 | + | + | find - Wyszukiwanie plików należących do konkretnego usera |

## Objectivy 2
OBJECTIVE: SCORE
Manage basic networking: 100%
Understand and use essential tools: 56%
Operate running systems: 50%
Configure local storage: 75%
Create and configure file systems: 75%
Deploy, configure and maintain systems: 62%
Manage users and groups: 75%
Manage security: 100%
Manage containers: 67%


---
# Pomoc 
[spis treści](#spis-tre%c5%9bci)

## Wyszukiwanie pomocy
- ```apropos``` wyszukuje strony w pomocy, podobnie jak *man -k*
- ```man -k``` - wyszukuje strony w pomocy 
- ```man -k``` - szuka we **wszystkich** plikach pomocy
- ```info``` - wyświetla komendy z opisem  
- ```rpm -qd``` - wyświetl pliki z dokumentacją dla danego pakietu
- locate "$szukana_komenda" - powinno wylistować pliki z pomocą 

## man
- ```man man``` - manual do ```man```
- ```mandb``` - odświeża bazę danych man, odpalać na początku egzaminu

## info

```info``` - **samo wykonanie polecenia info wyświetla przydatne komendy z opisami**


## /usr/share/doc
dodatkowa dokumentacja 

# Przywracanie hasła roota
- [spis treści](#spis-tre%c5%9bci)

you are new system administrator and from now you are going to handle the system and your main task is network monitoring, backup and restore. but you don't know the root password. change the root password to redhat and login in default runlevel.

```console
### in rhel8
- reboot the system
- press "e" letter
- add "rd.break" or "init=/bin/bash" at the end of de line thet begening with "linux" in grub menu
- ctrl + x

# mount -o remount,rw /sysroot
# chroot /sysroot
# passwd

### selinux jest rozjechany więc musi ustalić etykiety od nowa ? 
### inaczej nikt nie będzie mógł zalogować się do systemu
#  touch /.autorelabel
# exit
# logout
```


# hostname
- ```hostnamectl``` - wyświetla aktualny hostname + informacje na temat systemu
    - ```set-hostname``` - zmienia hostname na podany
  
- ```nmtui``` i ```nmcli``` również pozwalają na zmianę hostname 

### ważne!
- zmiana w /etc/hostname jest niezalecana!

# Użytkownicy 
[spis treści](#spis-tre%c5%9bci)

## Tworzenie nowych 
### configi
- ```/etc/defaults/useradd``` 
- ```/etc/login.defs```

### ToDo - dopisać
- ustawienie domyślnych ustawień nowo dodawanych użytkowników, tj. wygasanie hasła, katalogi domowe itd.
 
### podstawowe komendy
- ```useradd``` - dodanie użytkownika
    - ```useradd -u "$uid"``` - user z innym uuid
- ```usermod``` - modyfikowanie ustawień użytkownika
    - ```usermod -ag "$group_name"``` - samo użycie opcji ```g``` bez ```a``` **powoduje zastępienie obecnych grup użytkownika tą jedną którą przypisujemy**
- ```userdel``` - usuwanie użytkownika
   

## Edycja użytkowników
### wygasanie hasla/blokowanie konta 
- ```chage``` - blokowanie konta po określonym czasie 
- ```chage``` - wymuszenie zmiany hasła 

### wyłączenie logowania 
```
vim /etc/passwd 
# dodanie jako shell 
/sbin/nologin
```

# Grupy użytkowników
-  szybkie tworzenie  
`for group in gropup1 group2 group3 ; do groupadd "$group" ; done`

# sudoers
- [spis treści](#spis-tre%c5%9bci)

### linki
- [rhel sudoers](https://access.redhat.com/documentation/en-us/red_hat_enterprise_linux/8/html/configuring_basic_system_settings/managing-sudo-access_configuring-basic-system-settings)

### todo - dopisać coś

## config
- ```/etc/sudoers``` - ogólny 

- ```username hostname=path/to/command```
    - username is the name of the user or group, for example, ```user1``` or ```%group1```.
    - hostname is the name of the host on which the rule applies.
    - path/to/command is the complete absolute path to the command. you can also limit the user to only performing a command with specific options and arguments by adding those options after the command path.   
    if you do not specify any options, the user can use the command with all options.  

### #todo - opisać aliasy w sudoers

nadanie dla grupy ```dba_managers``` praw do wykonywania na wszystkihch maszynach **all** komend pod aliasem **software**
%dba_managers   all = software


# wyszukiwanie plików 
- [spis treści](#spis-tre%c5%9bci)

## find
- ```find```
    - ```-type``` - typ wyszukiwanych plików 
        ```-f``` - file 
        ```-d``` - firectory
    - ```-mtime``` - file's  data  was last **modified** n*24 hours ago
    - ```-atime``` - file was last **accessed** n*24 hours ago
    - ```-ls``` - list current file in ```ls format```


## locate 
locate działa na podstawie bazy danych, domyślnie aktualizowana jest raz dziennie  
- ```updatedb``` - aktualizuje bazę locate
- ```locate "$file_name"``` - wyszukuje plik na podstawie indeksowanej bazy danych

# Firewall 
- [spis treści](#spis-tre%c5%9bci)
### Linki
- [rh - firewalld article](https://www.redhat.com/sysadmin/firewalld-linux-firewall)
---
- w rhel8 firewall jest zarzadzany przez firewalld, pod spodem jest nftables  
zarzadzanie firewalld odbywa sie za pomoca komendy ```firewall-cmd```

### Configi 
- ```/usr/lib/firewalld``` - katalog z domyslna konfiguracja
- ```/etc/firewalld``` - katalog z obecnie dzialajacym configiem 

### Komendy
- ```firewall-cmd``` - odpowiada za konfigurację zapory   
    
    - zarządzanie firewallem :  
        - ```--state``` - wyswietla czy firewall dziala
        - ```--reload``` - zatwierdzenie wprowadzonych zmian
        - ```--list-all --permanent``` wypisuje reguły które są zapisane w configu - będą działać po ***reboocie systemu***
        
    - otwieranie portów/usług :  
        - ```--add-port "$port_number"/[tcp | udp ]``` - otwarcie portu dla tcp lub udp
        - ```--add-service "$service_name"``` - udostępnienie możliwości komunikacji z usługą (lista dostępna pod tabulatorem)


**zawsze trzeba pamiętać o opcji ```--permanent```**, w przeciwnym wypadku zmiany nie będą stałe   

### Przyklady
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

- **Sprawdzenie czy port 90 jest otwarty** - telnet powinien wyrzucić błąd po czasie jeżeli działa 
    ```console
    telnet 172.20.183.251 90
    ```  

    np. 
    ```
    telnet "$remote_ip" "$remote_port"
 
 ---  
- ```nmap -A``` - skanuje porty zdalnej maszyny, wyświetla wszystkie informacje      
- ```curl "$remote_ip"``` - pozwala sprawdzić czy działa serwis http      


# SELinux
- [Spis treści](#spis-tre%C5%9Bci)

### Linki
- [RH - How to troubleshoot SELinux policy violations](https://www.redhat.com/sysadmin/diagnose-selinux-violations)  
- [RH - How to modify SELinux settings with booleans](https://www.redhat.com/sysadmin/change-selinux-settings-boolean)  

### Instalacja
- ```yum whatprovides */semanage``` - domyślnie narzędzia SELinux mogą nie być zainstalowane  

### Pomocne komendy
- ```ausearch``` - command parses audit daemon logs. You can view the man page for all of the details, but the -c 'httpd' argument will search for any event with that httpd name.
- ```audit2allow``` - command generates an SELinux policy based on logs returned by ausearch. This tells you that the first command parses the audit logs for anything with an event based on httpd and then generates an SELinux policy to allow it.
- ```getenforce``` - Pokazuje **w jakim trybie** działa SELinux 
- ```sestatus``` - Pokazuje **szczegółowe informacje** na temat SELinux

#### audit2allow  
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

# Kontrola czasu w RHEL
- [Spis treści](#spis-tre%C5%9Bci)
- [RH - How to configure chrony as an NTP client or server in Linux](https://www.redhat.com/sysadmin/chrony-time-services-linux)
- [Cloud_guru - lekcja](https://learn.acloud.guru/course/red-hat-certified-system-administrator-ex200-exam-prep/learn/60dc10ad-0973-4bb6-8a0b-9d987f2c25f3/071c69c6-90ba-4885-9f32-15949b43286f/watch)


Poprzednim serwerem czasu był ntp, obecnym chrony

- ```chrony``` - serwer lub klient (zależy od potrzeby) kontroli czasu

### Ważne pliki  
- ```/etc/chrony.conf``` - config  
- ```/etc/chrony.keys``` - zawiera klucze ? 
- ```/usr/share/doc/chrony``` - dokumentacja

---

- ```chronyd``` - **daemon for synchronisation of the system clock**, can be controlled via local or remote instances of ```chronyc```
- ```chronyc``` - command line program **used to monitor and control ```chronyd```** - działa na tej samej zasadzie co fdisk, **tabulator mocno pomaga** 
    - ```help``` - wyświetla pomoc
    - ```sources -v``` - wyświetla dostępne źródła, razem z wyjaśnieniem co znaczą wpisy w tabeli  

    ![chronyc_sources_verbosed](Obrazy/Cloud_Guru/chronyc_sources_verbosed.png)  

    - ```serverstats``` - nie wiem ? 


## Synchronizacja czasu (klient z serwerem)

1. instalacja chrony 
```console
dnf install chrony -y
```

2.  Sprawdzenie statusu chronyd i ewentualne odpalenie 
```console
systemctl status chronyd
systemctl enable --now chronyd
```

3. Dodanie docelowego serwera w configu ```/etc/chrony.conf```  
Serwer zaczyna się od frazy **server**, poola od frazy **pool**,   
jeżeli chcemy używac tylko jednego (tego podanego w zadaniu to resztę należy zakomentować)   
* **iburst** powoduje szybszą synchronizację
```console
vim ```/etc/chrony.conf```

### server "$sever_address" [option] - składnia opisana w man ```chrony.conf```
server classroom.example.com iburst
```

4. Restart usługi chronyd
```console
systemctl restart chronyd
```


5. Wymuszenie synchronizacji 
```console
chronyc makestep

200 OK
```

6. ```chronyc sources``` - sprawdzenie czy serwer został zsynchronizowany **(bez wymuszenia synchronizacja może zająć trochę czasu)**
```console
# Sources pokazuje listę serwerów z których korzysta obecnie chrony
chronyc sources -v
```

7. ```timedatectl``` - sprawdzenie czy zegar jest zsynchronizowany 
* timedatectl pokazuje status synchronized: yes lub no 
```console
timedatectl
               Local time: Wed 2022-03-09 12:28:58 EST
           Universal time: Wed 2022-03-09 17:28:58 UTC
                 RTC time: Wed 2022-03-09 17:28:58
                Time zone: America/New_York (EST, -0500)
--> System clock synchronized: yes <--
              NTP service: active
          RTC in local TZ: no
```

8. Display parameters about the system’s clock performance
```console
chronyc tracking 
```

# Managing schedulded tasks
- [Spis treści](#spis-treści)

## cron
- ```dnf list --installed cronie``` - sprawdzenie czy **cron** jest zainstalowany
- ```systemctl status crond.service``` - sprawdzenie czy działa uzługa **cron**
- ```cronnext -c``` pokazuje datę wszystkich następnych **cronjobów** 


### Budowa pliku ```/etc/crontab``` 

```
Example of job definition:  
.---------------- minute (0 - 59)  
|  .------------- hour (0 - 23)  
|  |  .---------- day of month (1 - 31)  
|  |  |  .------- month (1 - 12) OR jan,feb,mar,apr ...  
|  |  |  |  .---- day of week (0 - 6) (Sunday=0 or 7) OR sun,mon,tue,wed,thu,fri,sat  
|  |  |  |  |  
*  *  *  *  * user-name  command to be executed  
```

## at
- ```dnf list --installed at``` - sprawdzenie czy **at** jest zainstalowany
- ```systemctl status atd.service``` - sprawdzenie czy działa uzługa **at**
- ```atq``` - kolejka at
---
- Można wywoływać komendę o konkretnej godzine lub po jakimś czasie, np. at 20:00 lub at +7 days 

```
sudo at 20:00 
>at command to execute
*ctrl+d*
```

# Storage 
## Montowanie
- [Spis treści](#spis-tre%C5%9Bci)
- [RH - Mounting file systems](https://access.redhat.com/documentation/en-us/red_hat_enterprise_linux/8/html/managing_file_systems/assembly_mounting-file-systems_managing-file-systems)
---

### WAŻNE!
- ```findmnt``` - wyświetla zamontowane filesystemy 
    - findmnt --types xfs - listuje tylko filesystemy xfs


## Filesystemy
- [Spis treści](#spis-tre%C5%9Bci)


### SZYBKIE NOTATKI 
```lvresize -r``` - zmienia wielkość lvm i filesystemu!

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

# LVM 
- [Spis treści](#spis-tre%C5%9Bci)

### TODO - Dodać ogólnie jak tworzyć

\* **WAŻNE**
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
    - ```-L``` - **wielkość którą podajemy** ręcznie 
- lvresize 
    - -r - rozszerza filesystem razem z lvm

--- 
## Zadanie - Rozszerzanie i zmniejszanie filesystemu na lvm 
\* **WAŻNE** - ```-r``` - rozszerza lub zmniejsza filesystem razem z lvm 
- ```lvresize -r -L -200M datacontainer/ext4-lvm``` - Zmniejszenie **lvm wraz z filesystemem** o 200M 

## VDO
- [Spis treści](#spis-tre%C5%9Bci)
- [Poradnik od RedHata](https://access.redhat.com/documentation/en-us/red_hat_enterprise_linux/7/html/storage_administration_guide/vdo-quick-start)


- [Utworzenie VDO na bazie LVM](https://access.redhat.com/solutions/6809311)

### SPRAWDZIC WLASCIWIE WSZYSTKO, pozmienialo sie od czasu kiedy jest na lvm

### Instalacja vdo
```console
dnf install vdo kmod-kvdo
```
- [STARY artykuł jak to działa](https://hobo.house/2018/09/13/using-vdo-on-centos-rhel7-for-storage-efficiency/)  

---

## Zadanie - Tworzenie VDO
#### TODO - Opisac 

Zamontowanie filesystemu 
- **Opcje montowania VDO :**
    - ```x-systemd.requires=vdo.service``` - VDO musi mieć działającą usługę ```vdo.service``` przed zamontowaniem  


## Stratis 
- [Spis treści](#spis-tre%C5%9Bci)
### Linki
- [Stratis - ogolna strona + how_to](https://stratis-storage.github.io/howto/)  
- [Stratis filmik](https://www.youtube.com/watch?v=CJu3kmY-f5o&t=200s)  

1.  Instalacja 
```sudo dnf install stratis-cli stratisd -y```

```console
dnf whatprovides */stratis
dnf install stratisd stratis-cli
```

2.  Uruchomienie uslugi 
```sudo systemctl enable --now stratisd.service```

### Z czego sklada sie Stratis
- Stratis Block device - Linux block devices
    - Stratis może leżeć na dowolnym urządzeniu blokowym, tj. partycja, LVM czy RAID
    - Disk (HDD/SSD/NVMe)
    - Partition
    - LVM logical volume
    - LUKS
    - MD RAID
- Stratis Pool - One or more block devices
    - Jej wielkość to suma powierzchni na block devices 
    - Każda poola ma katalog /stratis/"$pool_name" który prowadzi do filesystemu Stratis
    - Size is the sum of the block devices in the pool
    - Each pool has a /stratis/<poolname> directory with links to Stratis file systems
    - Pool can contain one or more file systems
- Stratis File System
    - No fixed size
    - Thinly provisioned
    - Supports snapshots
    - Formatted with xfs, managed via Stratis.
    - Do not try to manage Stratis file systems with xfs tools!



### Jak utworzyć / usunąć i zamontować filesystem Stratis

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
6. Dodaj więcej bloków do istniejącej puli:



# Logi 
- [Spis treści](#spis-tre%C5%9Bci)
- [RH - How to configure your system to preserve system logs after a reboot](https://www.redhat.com/sysadmin/store-linux-system-journals)
- [RH - Chapter 23. Viewing and Managing Log Files](https://access.redhat.com/documentation/en-us/red_hat_enterprise_linux/7/html/system_administrators_guide/ch-viewing_and_managing_log_files)


## Understanding Logging

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
| SUID - setuid | 4 lub u+s | bit identyfikatora użytkownika | 
| SGID - setgid | 2 lub g+s | bit identyfikatora grupy |
| Sticky bit | 1 lub o+t | 	klejący bit |


### Bit SUID
- [Spis treści](#spis-tre%C5%9Bci)

**Bit SUID** - gdy zostaje ustawiony dla katalogu *(4 lub u+s)*, wówczas **proces będzie miał prawa użytkownika który jest właścicielem pliku wykonywalnego, a nie użytkownika który ten plik uruchamia.**  
O tym, że *SUID* jest przypisany świadczy *litera s* w miejscu execute dla użytkownika   
*Ustawienie tego bitu na katalogu nie ma żadnego znaczenia, jest ignorowany.*  


Plik wykonywalny z ustawionym bitem setuid jest wykonywany przez zwykłych użytkowników z takimi przywilejami jakie posiada właściciel pliku. 

Jeśli bit SUID jest ustawiony, po uruchomieniu polecenia efektywny UID staje się identyfikatorem właściciela pliku, a nie użytkownika, który go uruchamia. Oznacza to, że SUID zapewnia tymczasowe podwyższenie uprawnień podczas wykonywania. Przykładowo, jeśli wykonywany plik był własnością roota i ma ustawiony bit SUID, to bez względu na to, kto uruchamia skrypt lub aplikację, uprawnienia będą tymczasowo równe uprawnieniom roota.



Dodać coś o tym kto może usuwać pliki

### Bit SGID
- [Spis treści](#spis-tre%C5%9Bci)

**Tworzenie katalogów współdzielonych przez grupy**

**Bit SGID** - gdy zostaje ustawiony dla katalogu *(2 lub g+s)*, wówczas **wszystkie pliki tworzone w tym katalogu zostają przypisane grupie katalogu.**   
O tym, że *SGID* jest przypisany świadczy *litera s* w miejscu execute dla grupy    

- *Bit GID* można ustawić poprzez użycie *chmod g+s* lub dodając *2 na początku* uprawnień które nadajemy *np. chmod 2755*  - [Tabela 11.4](#tabela-114-strona-285)

    ```console
    ### Zmiana grupy dla folderu na shared_folder
    # chgrp shared_folder GID_test_shared

    ### Dodanie GID do folderu 
    # chmod 2775 GID_test_shared/

    ### Potwierdzenie dodania bitu GID ( s w miejscu execute dla grupy )
    # ls -l GID_test_shared/
    
    drwxrwsr-x. 2 mariusz shared_folder  4096 Feb  2 12:30 GID_test_shared

    ### Grupą do której należy plik jest shared_folder - skutek przypisania GID
    # ls -l test_file
    -rw-rw-r--. 1 mariusz shared_folder 0 Feb 2 12:37 test_file
    ```



### Bit sticky
- [Spis treści](#spis-tre%C5%9Bci)

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



## ACL 
- [Spis treści](#spis-tre%C5%9Bci)

WAŻNE ! - Przy poleceniu **ls -l** trzeba zwracać uwagę na **+**, jeżeli występuje to **oznacza, że dla pliku są ustawione uprawnienia ACL**   
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
# systemclt enable sysstat
# systemctl start sysstat
```

```/var/log/sa/sa??``` - domyślne miejsce docelowe dla logów  

```sar``` - przeglądanie logów  
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
### Klient

1. Instalacja nfs-utils + autofs
```
dnf install nfs-utils autofs
```

2. Uruchomienie autofs przy starcie systemu 
```
systemctl enable autofs --now
```

3. Edycja auto.master - działa jak mapa **punkt montowania = plik montowania**
``` 
vim /etc/auto.master

# Dodanie do auto.master pliku ktory bedzie odpowiadac za mapowanie pod /mnt/home
/mnt/home       /etc/auto.home
```

4. **WAŻNE!** - Jeżeli udostępniamy automatyczne katalogi osobno dla każdego użytkownika to ich home foldery muszą istnieć!

5. Utworzenie auto.home - pliku który został przypisany w auto.master  
- *Najlepiej do tego celu skopiowac auto.misc*
- **man 5 autofs** - po wyszukaniu home znajdziemy to samo

```
cp /etc/auto.misc /etc/auto.home
vim /etc/auto.home

### Dodanie do /etc/auto.home ścieżki montowania 
## Wszyscy uzytkownicy

*       -rw,fstype=nfs      server:/home/&

## Jeden uzytkownik
# WAZNE! - Katalog /mnt/home/mariusz musi istniec!

mariusz     -rw,fstype=nfs      server:/home/mariusz
```

6. Restart uslugi autofs
```
systemctl restart autofs 
```

7. Zalogowanie sie na uzytkownika i sprawdzenie czy dziala
```
ls ~
```

### Serwer

1. Instalacja nfs-utils, wlaczenie nfs-server 
1.1 Instalacja nfs-utils
```bash
dnf install nfs-utils
```

1.2 Włączenie usługi nfs-server 
```
systemctl enable --now nfs-server
```

2. Wyeksportowanie katalogu /home
1.1 Edycja /etc/exports
```
# Wyeksportowanie dla wszystkich sieci
/home   *(rw,insecure)

# Wyeksportowanie dla podsieci 192.168.0.* 
/home   192.168.0.*(rw,insecure)
```

1.2 Eksport katalogu z configu 
```
exportfs -avr 
```

1.2.3 Sprawdzenie czy jest dobrze wyeksportowany 
```
# Komenda pokazuje liste katalogow eksporowtanych przez serwer  
showmount -e
```

---

### Automatyczne montowanie katalogu /net   
Po włączeniu autofs, jeżeli znasz nazwę komputera oraz współdzielonego katalogu, należy po prostu zmienić katalog (cd) na katalog montowania autofs (domyślnie /net lub /var/autofs). W ten sposób współdzielony zasób zostanie automatycznie zamontowany i udostępniony.    

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

### Lokalny spis
- [Dnf](#dnf)
- [Repozytoria](#repo)
- [Dodanie nowego repozytorium](#dodanie-nowego-repozytorium)

### Linki 
- Red Hat
    - [RH LAB - Installing Software using Package Managers](https://developers.redhat.com/learn/installing-software-using-package-managers?intcmp=7013a0000026UTXAA2)
    - [RH Sysadmin - How to install software packages on RHEL](https://www.redhat.com/sysadmin/install-software-packages-rhel)
    - [RH - Chapter 1. Using AppStream](https://access.redhat.com/documentation/en-us/red_hat_enterprise_linux/8/html/installing_managing_and_removing_user-space_components/using-appstream_using-appstream)
    - [RH - Chapter 2. Introduction to modules](https://access.redhat.com/documentation/en-us/red_hat_enterprise_linux/8/html/installing_managing_and_removing_user-space_components/introduction-to-modules_using-appstream)
    - [RH - Chapter 3. Finding RHEL 8 content](https://access.redhat.com/documentation/en-us/red_hat_enterprise_linux/8/html/installing_managing_and_removing_user-space_components/finding-rhel-8-content_using-appstream)
        - Searching for a package
        - Listing available modules
        - Finding out details about a module
        - Commands for listing content  
  
- [Kernel Red Hat](https://access.redhat.com/documentation/en-us/red_hat_enterprise_linux/8/html/managing_monitoring_and_updating_the_kernel/updating-kernel-with-yum_managing-monitoring-and-updating-the-kernel)


- Random 
    - [Introduction to Application Streams](https://www.redhat.com/en/blog/introduction-appstreams-and-modules-red-hat-enterprise-linux)   
    - [Różnica pomiędzy dnf module a dnf group](https://unix.stackexchange.com/questions/603905/what-is-the-difference-between-a-yum-group-and-a-yum-module-in-red-hat-enterpris)


## Dnf
### Podstawowe operacje
- dnf install "$package"
- dnf list ```updates``` - wyświetla listę dostępnych updatów
    - "$package" - wyświetla paczkę 
- dnf update "$package" - updatuje tylko wskazaną paczkę 
- dnf remove "$package" - usuwa wskazaną paczkę 
  
- dnf history - wyświetla listę operacji  

``` 
ID| Command                  | Date and time    | Action(s)| Altered    
------------------------------------------------------------------    
12 | -y remove httpd         | 2021-12-22 01:12 | Removed  |   10  
11 | -y update bash          | 2021-12-22 01:12 | Upgrade  |    1  
10 | -y install wireshark    | 2021-12-22 01:07 | install  |   98  
 9 | install -y httpd        | 2021-12-22 01:04 | Install  |   10   
 8 |                         | 2021-12-22 01:02 | I, U     |   81   
 7 | install -y git          | 2021-09-03 15:10 | Install  |   48  
```
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
fallocate - przypisanie plikowi określonej ilości zajmowanego miejsca
### TODO
tworzenie swapu z pliku, procedura do ogarnięcia

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
- [Kernel Update](#Kernel-update)
### Linki
- [Zmiana domyslnego kernela](https://access.redhat.com/solutions/4326431)
- [Fedora przydatne](https://docs.fedoraproject.org/en-US/fedora/latest/system-administrators-guide/kernel-module-driver-configuration/Working_with_the_GRUB_2_Boot_Loader/)

### #TODO - Sprawdzić jak dokładnie działają 
```grubby --add-kernel="$kernel-path"```   
```grubby --default-kernel```   
```grubby --info="$kernel-path"```  
```grubby --remove-kernel="$kernel-path"```  
  
```grubby --update-kernel=kernel-path```  

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

### Tutoriale
- [RH - podman rootless container procedura](https://access.redhat.com/documentation/en-us/red_hat_enterprise_linux/8/html/building_running_and_managing_containers/assembly_porting-containers-to-systemd-using-podman_building-running-and-managing-containers#proc_enabling-systemd-services_assembly_porting-containers-to-systemd-using-podman)
- [RSYSLOG - aktualny forum](https://learn.redhat.com/t5/platform-Linux/How-to-install-the-containerized-version-of-rhel8-rsyslog/td-p/20887)
    - [RSYSLOG2](https://access.redhat.com/documentation/en-us/red_hat_enterprise_linux/8/html-single/building_running_and_managing_containers/index#assembly_running-special-container-images_building-running-and-managing-containers)
- [RH - lab kontenery](https://developers.redhat.com/learn/lessons/deploying-containers-podman?intcmp=7013a0000026UTXAA2)
- [Youtube RH - podman systemd](https://www.youtube.com/watch?v=AGkM2jGT61Y)
- [RH - How to modify SELinux settings with booleans](https://www.redhat.com/sysadmin/change-selinux-settings-boolean)
- [Rootless container service](https://www.linuxtechi.com/run-containers-systemd-service-podman/)


## Przydatne  
**podman -v "volume_hosta:volume_kontenera:Z" - z dopiskiem ```:Z``` sam ogarnie SELinuxa!**  

- Uruchomienie terminala jako root  
```podman exec -u 0 -it "$nazwa_kontenera" bash``` - uruchomienie interaktywnego terminala jako **root** (```-u 0```)  
- ```podman container/image/volume...``` - ogólna budowa komend 
  
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

#### Inspecting images - skopeo
- ```skopeo``` - used to inspect, copy, delete and sign container images

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
- ```podman container create --volume "$host_volume/$container_volume:Z"``` - automatyczny kontekst dla volumenu
- kontekst dla folderów które mają byc udostępnione może być taki sam jak dla reszty plików 
SRPAWDZIĆ TO MOŻNA PO PODŁĄCZENIU DO TERMINALA KONTENERA I WYDANIU POLECENIA ```ls -lZ /```
  

## Podman - httpd  
- [Spis treści](#spis-treści)

- service: httpd
- user: cloud_user
- shared folder: ~/web_data:/var/www/html
- port: 8000:8080

#### Podman - SZYBKIE NOTATKI  
1. ```ssh usernam@hostname``` - ssh jest konieczne dla dzialania podmana jako non root
2. ```loginctl enable-linger "$user"``` 
    - ```loginctl show-user "$user"``` - sprawdzenie czy linger jest wlaczony dla uzytkownika?
3. ```podman generate systemd```
    - Pliki uslug systemd uzytkownika ```~/.config/systemd/user```
4. ```systemctl --user daemon-reload``` - przeladowane plikow systemd dla uzytkownikow standardowych
    - ```systemctl --user enable|start|stop "$UNIT"``` - obsluga uslug systemd dla uzytkownikow 

---
#### Stawianie kontenera

1. katalog dla zwyklego usera
```
mkdir -p /home/cloud_user/.config/systemd/user
``` 

2. tworzenie kontenera  
```
podman create --name web_server -p 8000:8080 -v "~/web_data:/var/www/html:Z" "$container_image"
``` 

3. wyświetlenie wszystkich kontenerów
```
podman ls -a
``` 

4. sprawdzenie czy strona jest wyświetlana
```
curl 127.0.0.1:8000
``` 

5. Wygenerowanie serwisu systemd i dodanie go do folderu z unitami
```
podman generate systemd web_server >> ~/container.service 

### WAŻNY KATALOG 
cp ~/container.service ~/.config/systed/user
``` 

9. Włączenie lingera dla użytkownika - **konieczne do włączenia usługi po reboocie**
```
loginctl enable-linger "$user"
```

10. Potwierdzenie włączenia lingera
```
loginctl show-user "$user" | grep linger
```

11. Odświeżenie plików systemd dla userów
```
systemctl --user daemon-reload
```

12. Włączenie kontenera po reboocie 
```
systemctl --user enable --now container-web_server.service
```

13. Wprawdzenie statusu uslugi 
```
systemctl --user status container-web_server.service
```

14. Potwiedzenie dzialania uslugi na porcie 8000
```
curl http://127.0.0.1:8000
```

15. Reboot dla potwierdzenia 
```
systemctl reboot now
```

14. Potiwerdzenie po reboocie 
```
curl http://127.0.0.1:8000
```

## Podman - rsyslog container 
-  Zadanie:
    - Create a container that runs the rsyslog service. This container should be configured to write log files persistently to the directory ```/var/log/logcontainer/``` on the host operating system. Run this container with the same user account that the rsyslog service normally uses. 
    - Kontener ma dzialac jako non-root dla uzytkownika standardowego uzytkownika **rsysuser** 
    - Kontener ma dzialac po reboocie

1. Pull the rsyslog image from a registry
```
podman pull rsyslog
```

2. Create a directory on the host operating system to store the log files:
```
sudo mkdir /var/log/logcontainer
```

3. Change the ownership of the directory to the user account that the rsyslog service normally uses:
```
sudo chown <username>:<groupname> /var/log/logcontainer
```
4. Run the rsyslog container, mounting the host directory to the container directory and setting the appropriate environment variables:
```
podman run -d --name rsyslog-container -v /var/log/logcontainer:/var/log/rsyslog -e TZ=<timezone> --user <username> rsyslog/rsyslog
```

**This will create a Podman container named rsyslog-container that runs the rsyslog service and writes log files persistently to the directory /var/log/logcontainer/ on the host operating system.**


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


# Rozwiązywanie problemów (ogólnie)
[Spis treści](#spis-tre%C5%9Bci)

## httpd
1. Sprawdzenie czy usługa działa, jeżeli tak/nie to czy systemd pokazuje jakieś błędy 
2. Pobranie strony ```curlem``` z podanego serwera
3. sprawdzenie logów systemd - ```journalctl -u httpd``` - pobranie logów dla konkretnej usługi
4. sprawdzenie loga audit - ```grep /var/log/audit/audit.log``` - sprawdzić co to jest konkretnie za log, jest od niego demon ```auditd```
5. sprawdzenie logów - ```grep /var/log/messages``` 
3. Ustawienie selinux w tryb permissive 
4. Włączenie odpowiedniej zmiennej boolowskiej ?


# Przed egzaminem 
- [Spis treści](#spis-treści)

- **ZAWSZE SPRAWDZAJ CZY USLUGA NFS/AUTOFS ITD DZIALA**

### Ogolne 
- [Przywracanie hasła roota](#przywracanie-hasła-roota)
- [man](#man)
    - ```mandb``` - odświeża bazę danych man, ODPALAĆ NA POCZĄTKU EGZAMINU
- ```bc``` - basic calculator 


### Bash completion 
- [Bash completion ubuntu](https://askubuntu.com/questions/545540/terminal-autocomplete-doesnt-work-properly)

```
dnf search bash 
dnf install bash-completion 
whereis bash-completion
cd /usr/share/bash-completion 
. ./bash-completion
```

### Storage
- [Sprawdzene poprawnosci fstab](https://sleeplessbeastie.eu/2019/01/21/how-to-verify-fstab-file/)
    - ```findmnt --verify``` - komenda sprawdzajaca poprawnosc fstab
- Pamiętać o dodawaniu ```nofail``` do filesystemów w fstabie!
#### LVM
- ```lvresize -r``` - zmienia wielkość lvm i filesystemu!

### Skrypty
- ```man sh``` - lista zmiennych specjalnych

### Selinux
- [Selinux](#selinux)
### TODO - Dodać coś o audit2allow i takie tam

### Repo
- ```dnf-config-manager``` - upraszcza dodawanie repo 
- ```dnf repolist``` - listuje repo i sprawdza je

```
[$name]
name=$name
baseurl=file:/// lub http://
gpgcheck=no
sslverify=no
```

```yum --exclude=packgeName1\* --exclude=packgeName2\* update```

### Autofs
- [autofs](#autofs)

### Ustawianie taskow w czasie?
- ```cronnext -c``` - pokazuje datę wszystkich następnych cronjobów 

### Kontenery
- [Kontenery](#Kontenery)

DO SEKCJI [SERVICE] DODAJEMY USER="$user", DZIĘKI TEMU UŻYTKOWNIK MOŻE URUCHAMIAĆ SERWIS, TYM SAMYM JEST DOSTĘP DO KONTENERÓW  

**podman -v "volume_hosta:volume_kontenera:Z" - z dopiskiem ```:Z``` sam ogarnie SELinuxa!**
podman generate systemd - generuje plik systemd który z nazwą service kopiujemy do ```/etc/systemd/system``` - ```man systemd.unit```


### Narzędzie do edycji parametrów konsoli?
- ```grubby –update-kernel=ALL –args="console=ttyS0"```

### TODO 
### Dopisać coś na temat zmiany configu bootowania?

Zadanie 18 - update kernel

https://github.com/chlebik/rhcsa-practice-questions/blob/master/questions/018_update_kernel_and_make_it_default_one.md

dnf update kernel - updatuje kernel


# Blokowanie połączenia z konkretnego serwera  

I just added the following to the drop zone and it worked without any issue:

```
firewall-cmd --zone=drop --add-source=x.x.x.x/xx
```
replace x.x.x.x with the IP and you can add the subnet under /xx

reguły dla danej strefy, do drop dodajemy źródłą które chcemy blokować 
```
firewall-cmd --zone=drop --list-all
```

you could also use /etc/hosts.allow
/etc/hosts.deny


# Po egzaminie
## Opracowane pytania
- RESTART HASŁA ROOT
- LVM 
    - rozszerzanie wolumenu bez uszkodzenia pierwotnego filesystemu ext3, ext4, xfs 
    - dodawanie SWAPu jako nowy lvm
    - założenie całości LVM
    - ustawienie wielkości extent dla LVM 
    - założenie LVM na podstawie np. 32 extents 
- Użytkownicy 
    - zablokowanie logowania do shella
- Kontenery 
    - rsyslog - ma logować dla jakiegoś systemu, jak to sprawdzić 
    - kontener musi być postawiony jako zwykły user
    - pobieranie kontenerów ze zdalnego repozytorium 
- VDO
    - założenie filesystemu z miejscem logicznym
    - pamiętać o włączeniu usługi i nofail w fstab!
- Przypisanie IP do serwerów, zmiana hostname
- Repo 
    - dodanie repo, appstream i baseos, nie ma żadnego innego przykładowego 
    - pamietac o gpgcheck=no i sslverify=no 
- autofs
    - home foldery, automatyczne mapowanie
- SELinux 
    - jest błąd z serwerem httpd, nadanie kontekstu do folderu tak żeby serwer mógł odczytać pliki
    - zdiagnozowanie problemu z SELinux przez /var/log/messages






# Koniec

- [Spis treści](#spis-tre%C5%9Bci)

