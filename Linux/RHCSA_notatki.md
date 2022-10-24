# Linki 
- [Oreily link](https://learning.oreilly.com/videos/red-hat-certified/9780135656495/9780135656495-RCSA_02_10_08/)
- [Cloud Guru link](https://learn.acloud.guru/course/red-hat-certified-system-administrator-ex200-exam-prep/learn/4a50133e-bbdb-43b8-b939-5f648997ec6d/9a5ffcb1-8849-4fe1-a2ae-3ed99bfc32ba/watch)
- [Red hat - sysadmin](https://www.redhat.com/sysadmin/)


# Spis treści
1. [Pomoc](#pomoc)
1. [Przywracanie hasła roota](#Przywracanie-hasła-roota)
1. [Selinux](#selinux)
1. [Wyszukiwanie plików](#Wyszukiwanie-plików) 
1. [Tworzenie użytkowników](#Tworzenie-użytkowników)
1. [Firewall](#firewall)
1. [Kontrola czasu w RHEL](#Kontrola-czasu-w-RHEL)
1. [Managing schedulded tasks](#Managing-schedulded-tasks)
1. [NFS](#nfs)
1. [Storage](#storage)
    - [Montowanie](#Montowanie)
    - [Filesystemy](#Filesystemy)
    - [LVM](#LVM)
    - [Stratis](#stratis)
    - [VDO](#vdo)
1. [Logi](#acl)
1. [Uprawnienia](#uprawnienia)
    - [SUID, SGID, Sticky bit](#SUID,-SGID,-Sticky-bit)
    - [ACL](#acl)
1. [Sysstat](#sar---sysstat)
1. [Instalacja/Update](#instalacjaupdate)
    - [Dnf](#dnf)
    - [Modules](#modules)
    - [Repo](#repo)
        - [Dodanie nowego repo](#dodanie-nowego-repozytorium)
1. [Blokowanie połączenia z konkretnego serwera](#blokowanie-po%C5%82%C4%85czenia-z-konkretnego-serwera)
1. [Autofs](#autofs)
1. [Archiwizowanie](#archiwizowanie)
1. [Swap](#swap)
1. [Sieci](#Sieci)
1. [Kontenery](#Kontenery)
1. [Tuned profiles](#Tuned-profiles)
1. [Grub/Kernel](#grubkernel)

---
-  [Przed egzaminem!!!](#przed-egzaminem)
-  [Po egzaminie](#po-egzaminie) - Pytania z egzaminu
---
## Zadania 
- [Chlebik](#chlebik)    
- [Cloud Guru](#cg)    
- [Daily zadanka](#daily-zadanka)  
- [RH - Laby](https://lab.redhat.com/)
  
[Koniec](#Koniec)   
  

# Chlebik
- [Spis treści](#spis-tre%C5%9Bci)

| Zadanko | Notatki | Czy opanowane |
|--|--|--|
| [001_restore_root_password](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/001_restore_root_password.md) | [Przywracanie hasła roota](#Przywracanie-hasła-roota) | tak, BARDZO WAŻNE, + |
| [002_setup_network_parameters](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/002_setup_network_parameters.md) |  | tak, przećwiczyć, + |
| [003_change_hostname]( https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/003_change_hostname.md) |  | tak, + |
| [004_enable_selinux](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/004_enable_selinux.md) |[Selinux](#selinux) | tak, ćwiczyć dalej, na pewno musi być włączony na egzaminie, + |
| [005_install_apache_and_give_it_permission_to_nfs_resource](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/005_install_apache_and_give_it_permission_to_nfs_resource.md) | [Selinux](#selinux) - /var/log/messages | tak, + |
| [006_extend_existing_lv_add_label](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/006_extend_existing_lv_add_label.md) | [LVM](#lvm) | tak, ćwiczyć, ważna jest zmiana rozmiaru filesystemu | 
| [007_assign_sel_context_to_the_directory](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/007_assign_sel_context_to_the_directory.md) | [Selinux](#selinux) - man semanage-fcontext, **jest w przykładach** | tak |
| [008_create_users_with_specified_uid](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/008_create_users_with_specified_uid.md) | [Tworzenie użytkowników](#Tworzenie-użytkowników) | tak, przećwiczyć ! |
| [009_allow_other_user_to_get_access_to_home_dir](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/009_allow_other_user_to_get_access_to_home_dir.md) | [ACL](#acl) | tak, ćwiczyć dalej |
| [010_dir_ownership_via_group](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/010_dir_ownership_via_group.md) |  | tak, do zapamiętania! |
| [011_create_logical_volume_and_add_filesystem](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/011_create_logical_volume_and_add_filesystem.md) | [LVM](#LVM) | tak |
| [012_configure_virtual_console_for_kernel](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/012_configure_virtual_console_for_kernel.md) |  | #TODO - nie wiem o co chodzi |
| [013_create_swap_on_logical_volume](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/013_create_swap_on_logical_volume.md) | [Swap](#swap) | tak, przećwiczyć |
| [014_add_entry_to_cron](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/014_add_entry_to_cron.md) | [Sysstat](#sar---sysstat) | tak, przećwiczyć |
| [015_set_default_system_level](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/015_set_default_system_level.md) | [Runlevele](#runlevele) | tak |
| [016_add_additional_remote_yum_repo](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/016_add_additional_remote_yum_repo.md) | [Dnf](#dnf) | tak, PRZEĆWICZYĆ |
| [017_create_physical_partition_and_mount](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/017_create_physical_partition_and_mount.md) |  | tak, przećwiczyć |
| [018_update_kernel_and_make_it_default_one](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/018_update_kernel_and_make_it_default_one.md) | [Grub/Kernel](#grubkernel) | NIE, przećwiczyć |
| [019_create_users_with_secondary_groups](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/019_create_users_with_secondary_groups.md) | [Tworzenie użytkowników](#Tworzenie-użytkowników) | tak, przećwiczyć |
| [020_create_folders_with_group_access_rights](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/020_create_folders_with_group_access_rights.md) | [SUID, SGID, Sticky bit](#SUID,-SGID,-Sticky-bit) | tak, przećwiczyć |
| [021_configure_ldap_authentication](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/021_configure_ldap_authentication.md) | - | **nie ma na egzaminie** |
| [022_configure_autofs](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/022_configure_autofs.md) | [Autofs](#autofs) | nie, przećwiczyć |
| [023_configure_ntp_on_the_client](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/023_configure_ntp_on_the_client.md) | [Kontrola czasu w RHEL](#Kontrola-czasu-w-RHEL) | tak, przećwiczyć |
| [024_access_rights_for_file](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/024_access_rights_for_file.md) | [ACL](#acl) | tak, przećwiczyć - nie jest aż tak proste |
| [025_create_whole_lvm_stack](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/025_create_whole_lvm_stack.md) | [LVM](#LVM) Dodać extent of VG should be 16MB do notatek | tak, przećwiczyć |
| [026_reduce_the_size_of_lv](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/026_reduce_the_size_of_lv.md) | [LVM](#lvm) | tak, przećwiczyć |
| [027_create_compressed_archive](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/027_create_compressed_archive.md) | [Archiwizowanie](#archiwizowanie) | przećwiczyć |
| [028_search_string_using_grep_and_redirect](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/028_search_string_using_grep_and_redirect.md) | [Wyszukiwanie plików](#wyszukiwanie-plik%C3%B3w) | tak |
| [029_make_journald_persistent](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/029_make_journald_persistent.md) | [Logi](#logi) | tak, przećwiczyć |
| [030_setting_up_vdo](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/030_setting_up_vdo.md) | [VDO](#vdo) | nie |
| [031_finding_files](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/031_finding_files.md) | [Wyszukiwanie plików](#wyszukiwanie-plik%C3%B3w) | przećwiczyć |
| [032_finding_files_with_given_text_in_them](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/032_finding_files_with_given_text_in_them.md) | [Wyszukiwanie plików](#Wyszukiwanie-plików)  | przećwiczyć |
| [033_managing_layered_storage](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/033_managing_layered_storage.md) | [Stratis](#stratis) | tak trochę ogarniam, przećwiczyć |
| [034_containers](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/034_containers.md) | [Kontenery](#Kontenery) | tak trochę ogarniam, przećwiczyć |

# CG 
- [Spis treści](#spis-tre%C5%9Bci)

| Zadanko | Notatki | Czy opanowane |
|--|--|--|
| 1. [Create Users/Groups and Configure Superuser Access on Both Servers](#create-usersgroups-and-configure-superuser-access-on-both-servers) | test | test |   
| 2. [Configure yum Repositories on Both Servers and Install Packages/Modules](#configure-yum-repositories-on-both-servers-and-install-packagesmodules) | test | test |
| 3. [Configure IP Addresses on the Second Network Interface on the First Server](#configure-ip-addresses-on-the-second-network-interface-on-the-first-server) | test | test |
| 4. [Managing Tuned Profiles and Individual Processes](#managing-tuned-profiles-and-individual-processes) | test | test | 
| 6. [manage-scheduled-tasks-on-the-first-server ](#6-manage-scheduled-tasks-on-the-first-server) | test | test | 
| 7. [configure-time-service-clients-for-both-servers](#7-configure-time-service-clients-for-both-servers) | test | test | 
| 8. [managing-the-system-bootloader](#8-managing-the-system-bootloader) | test | test | 
| 9. [configure-persistent-storage-with-lvm-on-top-of-vdo](#9-configure-persistent-storage-with-lvm-on-top-of-vdo) | test | test | 
| 10. [add-swap-space-persistently-and-nondisruptive](#10-add-swap-space-persistently-and-nondisruptive) | test | test | 
| 11. [configure-stratis-storage-persistently](#11-configure-stratis-storage-persistently) | test | test | 
| 12. [configure-autofs-for-home-directories](#12-configure-autofs-for-home-directories) | test | test | 
| 13. [configure-a-shared-directory-for-collaboration ](#13-configure-a-shared-directory-for-collaboration) | test | test | 
| 14. [create-a-persistent-systemd-container-using-podman](#14-create-a-persistent-systemd-container-using-podman) | test | test | 
| 15. [troubleshoot-selinux-issues](#15-troubleshoot-selinux-issues) | test | test | 
| 16. [configure-the-firewall-on-both-servers](#16-configure-the-firewall-on-both-servers) | test | test | 

# Pomoc 
[Spis treści](#spis-tre%C5%9Bci)

## Wyszukiwanie pomocy

- ```apropos``` wyszukuje strony w pomocy, podobnie jak *man -k*
- ```man -k``` - wyszukuje strony w pomocy 
- ```man -K``` - szuka we **wszystkich** plikach pomocy
- ```info``` - wyświetla komendy z opisem  
- ```rpm -qd``` - wyświetl pliki z dokumentacją dla danego pakietu
- locate "$szukana_komenda" - powinno wylistować pliki z pomocą 

## Man

- ```man man``` - manual do ```man```
- ```mandb``` - odświeża bazę danych man, ODPALAĆ NA POCZĄTKU EGZAMINU

## Info

```info``` - **Samo wykonanie polecenia info wyświetla przydatne komendy z opisami**


## /usr/share/doc

Dodatkowa dokumentacja 


# Przywracanie hasła roota
[Spis treści](#spis-tre%C5%9Bci)

You are new System Administrator and from now you are going to handle the system and your main task is Network monitoring, Backup and Restore. But you don't know the root password. Change the root password to redhat and login in default Runlevel.

```console
### In RHEL8
- reboot the system
- press "e" letter
- Add "rd.break" at the end of de line thet begening with "Linux" in grub menu
- ctrl + x

# mount -o remount,rw /sysroot
# chroot /sysroot
# passwd

### SELinux jest rozjechany więc musi ustalić etykiety od nowa ? 
### Inaczej nikt nie będzie mógł zalogować się do systemu
#  touch /.autorelabel
# exit
# logout
```

# Sudoers
- [Spis treści](#spis-tre%C5%9Bci)

### Linki
- [Rhel sudoers](https://access.redhat.com/documentation/en-us/red_hat_enterprise_linux/8/html/configuring_basic_system_settings/managing-sudo-access_configuring-basic-system-settings)

## Config
- ```/etc/sudoers``` - ogólny 

- ```username hostname=path/to/command```
    - username is the name of the user or group, for example, ```user1``` or ```%group1```.
    - hostname is the name of the host on which the rule applies.
    - path/to/command is the complete absolute path to the command. You can also limit the user to only performing a command with specific options and arguments by adding those options after the command path.   
    If you do not specify any options, the user can use the command with all options.  


### #TODO - opisać aliasy w sudoers

Nadanie dla grupy ```dba_managers``` praw do wykonywania na wszystkihch maszynach **ALL** komend pod aliasem **SOFTWARE**
%dba_managers   ALL = SOFTWARE


CG ZADANKo 
Configure superuser access:  

Enable the following command aliases:  

- SOFTWARE
- SERVICES
- PROCESSES
Add a new command alias named "MESSAGES":

/bin/tail -f /var/log/messages
Enable superuser privilages for the following local groups:

dba_managers: everything
dba_admin: Command aliases: SOFTWARE, SERVICES, PROCESSES
dba_intern: Command alias: MESSAGES
Configure yum Repositories on Both Servers and Install Packages/Modules
You'll need to configure three repositories and install some software:


# Wyszukiwanie plików 

[Spis treści](#spis-tre%C5%9Bci)

## find
- ```find```
    - ```-type``` - typ wyszukiwanych plików 
        ```-f``` - file 
        ```-d``` - firectory
    - ```-mtime``` - File's  data  was last **modified** n*24 hours ago
    - ```-atime``` - File was last **accessed** n*24 hours ago
    - ```-ls``` - list current file in ```ls format```


## locate 
locate działa na podstawie bazy danych, domyślnie aktualizowana jest raz dziennie  
- ```updatedb``` - aktualizuje bazę locate
- ```locate "$file_name"``` - wyszukuje plik na podstawie indeksowanej bazy danych


## grep 
### #TODO - może coś dopisać

- ```grep "$wyszukiwana_fraza" "$nazwa_pliku"```


# Uzytkownicy
[Spis treści](#spis-tre%C5%9Bci)


## Tworzenie nowych 
### Configi
- ```/etc/defaults/useradd``` 
- ```/etc/login.defs```

# TODO - dopisać
- ustawienie domyślnych ustawień nowo dodawanych użytkowników, tj. wygasanie hasła, katalogi domowe itd.
- 

### Podstawowe komendy
- ```useradd``` - Dodanie użytkownika
    - ```useradd -u "$uid"``` - user z innym uuid
- ```usermod``` - Modyfikowanie ustawień użytkownika
    - ```usermod -aG "$group_name"``` - samo użycie opcji ```G``` bez ```a``` **powoduje zastępienie obecnych grup użytkownika tą jedną którą przypisujemy**
- ```userdel``` - Usuwanie użytkownika
   

## Edytowanie obecnych
### Wygasanie hasla/Blokowanie konta 
- ```chage``` - blokowanie konta po określonym czasie 
- ```chage``` - wymuszenie zmiany hasła 

### Wyłączenie logowania 
```
vim /etc/passwd 
# dodanie jako shell 
/sbin/nologin
```

# NFS
[Spis treści](#spis-tre%C5%9Bci)

### Linki
- [Spis tresci](#spis-treści)
- [RH - https://www.redhat.com/sysadmin/configure-nfs-linux](https://www.redhat.com/sysadmin/configure-nfs-linux)


### Dokumentacja 

- ```man 5 nfs``` - wyświetlenie opcji montowania dla udziałów nfs   
- ```rpm -qd nfs-utils | less``` - wyświetlenie plików z dokumentacją

- ```man mount.nfs``` - opcje montowania udziału nfs   

### #TODO - sprawdzić dokładniej jak to opisać 
- ```nfsmount.conf``` -   
  
- ```man showmount``` - informacje o użyciu polecenia showmount do wyświetlenia katalogów współdzielonych, które są udostępniane przez serwery NFS  


```bash
# Ogólne infomracje na temat pakietu nfs
rpm -qi nfs-utils
# Configi
rpm -qc nfs-utils
# Wylistowanie plików w pakiecie nfs-utils
rpm -ql nfs-utils | grep bin
```   


Udział udostępniony, wpis w fstabie dodany, 
sprawdzić firewalla i SELinux na serwerze, potem spróbować zamontować udział i nadać kontekst dla procesu httpd

Dodać do configu httpd wpis z udostepnionym katalogiem
Przeladowac serwis httpd
spradzic bledy /var/log/messages

Utworzenie filesystemu na nowym lvmie, zmiana wielkości tego filesystemu, 
zamiana wielkości LVM 


# Firewall 
- [Spis treści](#spis-tre%C5%9Bci)
### Linki
- [RH - Firewalld article](https://www.redhat.com/sysadmin/firewalld-linux-firewall)
---
- W RHEL8 firewall jest zarzadzany przez firewalld, pod spodem jest nftables  
zarzadzanie firewalld odbywa sie za pomoca komendy ```firewall-cmd```

### Configi 
- ```/usr/lib/firewalld``` - katalog z domyslna konfiguracja
- ```/etc/firewalld``` - katalog z obecnie dzialajacym configiem 

### Komendy
- ```firewall-cmd``` - odpowiada za konfigurację zapory   
    
    - Zarządzanie firewallem :  
        - ```--state``` - wyswietla czy firewall dziala
        - ```--reload``` - zatwierdzenie wprowadzonych zmian
        - ```--list-all --permanent``` wypisuje reguły które są zapisane w configu - będą działać po ***reboocie systemu***
        
    - Otwieranie portów/usług :  
        - ```--add-port "$port_number"/[tcp | udp ]``` - Otwarcie portu dla tcp lub udp
        - ```--add-service "$service_name"``` - Udostępnienie możliwości komunikacji z usługą (lista dostępna pod tabulatorem)


**ZAWSZE TRZEBA PAMIĘTAĆ O OPCJI ```--permanent```**, w przeciwnym wypadku zmiany nie będą stałe   

### Przyklad
Otwarcie portu 80 tcp

```console
# firewall-cmd --add-port=80/tcp --permanent
```

Dodanie serwisu mysql do firewalla

```console
# firewall-cmd --add-service=http --permanent
```


Wylistowanie ustawiń **PERMANENTNYCH** dla firewalla

```console
# firewall-cmd --list-all --permanent
```

Przeładowanie configu firewalla 

```console
# firewall-cmd --reload 
```

Sprawdzenie czy port 90 jest otwarty, telnet powinien wyrzucić błąd po czasie jeżeli działa 

```console
# telnet 172.20.183.251 90
```  
  
- ```nmap -A``` - skanuje porty zdalnej maszyny, wyświetla wszystkie informacje      
- ```telnet "$remote_ip" "$remote_port"``` - pozwala sprawdzić czy port jest otwarty   
- ```curl "$remote_ip"``` - pozwala sprawdzić czy działa serwis http      


## Ćwiczenie 

### Otwarcie konkretnego portu na maszynie 

1. Klient - Przeskanowanie serwera na którym działa usługa, sprawdzenie czy ma jakieś otwarte porty

```console
nmap -A "$remote_ip_address"
```

2. SerNa serwerze 


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

### TODO 
#### - dodać jak rozwiązywać podstawowe błędy 
#### - jak ausearch -c "httpd" | audit2allow, trzeba dodać opcje raw  
  
  
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
  
![selinux_boot_permissive](Obrazy/Cloud_Guru/selinux_boot_permissive.png)

![selinux_parametry_bootowanie](Obrazy/Cloud_Guru/selinux_parametry_bootowanie.png)  
  


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

## Kontrola czasu w RHEL
- [Spis treści](#spis-tre%C5%9Bci)
- [RH - How to configure chrony as an NTP client or server in Linux](https://www.redhat.com/sysadmin/chrony-time-services-linux)
- [Cloud_guru - lekcja](https://learn.acloud.guru/course/red-hat-certified-system-administrator-ex200-exam-prep/learn/60dc10ad-0973-4bb6-8a0b-9d987f2c25f3/071c69c6-90ba-4885-9f32-15949b43286f/watch)


Poprzednim serwerem czasu był ntp, obecnym chrony

- ```chrony``` - serwer lub klient (zależy od potrzeby) kontroli czasu

### Ważne pliki :  
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
# dnf install chrony -y
```

2.  Sprawdzenie statusu chronyd i ewentualne odpalenie 

```console
# systemctl status chronyd
# systemctl enable --now chronyd
```

3. Dodanie docelowego serwera w configu ```/etc/chrony.conf```
There is a list of servers being used to get time from. The lines start with server. In order to use only one of the servers (the one that is provided in question) You should comment all others and just put new line there:
server classroom.example.com iburst
    
```console
# vim ```/etc/chrony.conf```

### server "$sever_address" [option] - składnia opisana w man ```chrony.conf```
server 169.254.169.123 iburst
```

4. Restart usługi chronyd

```console
# systemctl restart chronyd
```


5. Sprawdzenie czy serwer został zsynchronizowany **(bez wymuszenia synchronizacja może zająć trochę czasu)**

```console
# chronyc sources -v
```

6. Wymuszenie synchronizacji 

```console
# chronyc makestep

200 OK
```

6. Display parameters about the system’s clock performance

```console
# chronyc tracking 
```

7. Sprawdzenie czy zegar jest zsynchronizowany 

```console
# timedatectl

               Local time: Wed 2022-03-09 12:28:58 EST
           Universal time: Wed 2022-03-09 17:28:58 UTC
                 RTC time: Wed 2022-03-09 17:28:58
                Time zone: America/New_York (EST, -0500)
--> System clock synchronized: yes <--
              NTP service: active
          RTC in local TZ: no
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

- ```findmnt``` - wyświetla zamontowane filesystemy 
    - findmnt --types xfs - listuje tylko filesystemy xfs


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

### ext4


## LVM 
- [Spis treści](#spis-tre%C5%9Bci)

### Ćwiczenie : 
Create a new physical volume with volume group in the name of datacontainer, the extent of VG should be 16MB. Also create new logical volume with name datacopy with the size of 50 extents and filesystem vfat mounted under /datasource.


1. Before any kind of operations on partitions it is good to know what we actually have in the system.

```console
lsblk
```

2. 


## Stratis 
- [Spis treści](#spis-tre%C5%9Bci)

### #TODO - opisać bardziej 

- [Stratis how to, pisemny](https://stratis-storage.github.io/howto/)  
- [Stratis filmik](https://www.youtube.com/watch?v=CJu3kmY-f5o&t=200s)  


1. Instalacja 
```console
dnf whatprovides */stratis

dnf install stratisd stratis-cli
```

2. 



Jak utworzyć / usunąć i zamontować system plików Stratis w CentOS / RHEL 8

1. Zainstaluj pakiety Stratis: ...
2. Włącz i uruchom usługę Stratisd: ...
3. Utwórz pulę: ...
4. Utwórz system plików w nowo utworzonej puli „Stratis_Test”: ...
5. Utwórz punkt montowania i zamontuj system plików: ...
6. Dodaj więcej bloków do istniejącej puli:


- Instalacja 
```sudo dnf install stratis-cli stratisd -y```

- Uruchomienie 
```sudo systemctl enable --now stratisd.service```


## VDO
- [Spis treści](#spis-tre%C5%9Bci)
- [Poradnik od RedHata](https://access.redhat.com/documentation/en-us/red_hat_enterprise_linux/7/html/storage_administration_guide/vdo-quick-start)

### #TODO - opisać bardziej
- VDO będzie na egzaminie, ogarnąć co i jak !


### Instalacja

```console
dnf install vdo kmod-kvdo
```

#### Cwiczenie - Utworzenie VDO

Replace logical_size with the amount of logical storage that the VDO volume should present:


- vdo create \
    - --name=vdo_name \
    - --device=block_device \
    - --vdoLogicalSize=logical_size \
    - [--vdoSlabSize=slab_size]

```console
Create a file system:

For the XFS file system:
# mkfs.xfs -K /dev/mapper/vdo_name
For the ext4 file system:
# mkfs.ext4 -E nodiscard /dev/mapper/vdo_name

Mount the file system:
# mkdir -m 1777 /mnt/vdo_name
# mount /dev/mapper/vdo_name /mnt/vdo_name
To configure the file system to mount automatically, use either the /etc/fstab file or a systemd mount unit:
If you decide to use the /etc/fstab configuration file, add one of the following lines to the file:

For the XFS file system:
/dev/mapper/vdo_name /mnt/vdo_name xfs defaults,_netdev,x-systemd.device-timeout=0,x-systemd.requires=vdo.service 0 0
For the ext4 file system:
/dev/mapper/vdo_name /mnt/vdo_name ext4 defaults,_netdev,x-systemd.device-timeout=0,x-systemd.requires=vdo.service 0 0

VDO space usage and efficiency can be monitored using the vdostats utility:
# vdostats --human-readable

Device                   1K-blocks    Used     Available    Use%    Space saving%
/dev/mapper/node1osd1    926.5G       21.0G    905.5G       2%      73%             
/dev/mapper/node1osd2    926.5G       28.2G    898.3G       3%      64%
```


Za pomocą vdo możemy 

[Pytanie dotyczące VDO](https://github.com/mariuszkuswik/rhcsa-practice-questions/blob/master/questions/030_setting_up_vdo.md)  
[artykuł jak to działa](https://hobo.house/2018/09/13/using-vdo-on-centos-rhel7-for-storage-efficiency/)  

- **WAŻNE!** - VDO działa jako demon!

```vdo create ```

### Tworzenie VDO

1. Instalacja 
```
dnf whatprovides vdo
```

2. Włączenie usługi VDO
```
systemctl status vdo 
```

1. Utworzenie VDO 
```
vdo create 
```

Utworzenie filesystemu 
```console
# -K jest wymagane, sprawdzić czemu
mkfs.xfs -K /dev/LINK 
```

Zamontowanie filesystemu 
- **Opcje montowania VDO :**
    - ```x-systemd.requires=vdo.service``` - VDO musi mieć działającą usługę ```vdo.service``` przed zamontowaniem  
    - 


## Logi 

- [Spis treści](#spis-tre%C5%9Bci)
- [RH - How to configure your system to preserve system logs after a reboot](https://www.redhat.com/sysadmin/store-linux-system-journals)
- [RH - Chapter 23. Viewing and Managing Log Files](https://access.redhat.com/documentation/en-us/red_hat_enterprise_linux/7/html/system_administrators_guide/ch-viewing_and_managing_log_files)


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





## sar - sysstat
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

- ```# systemctl set-default graphical.target``` - ustawia tryb graficzny jako działający domyślnie 
- ```# systemctl set-default multi-user.target``` - ustawia tryb tekstowy jako działający domyślnie 
- ```# systemctl get-default``` - wyświetla obecny defaultowy target 

# autofs 
[Spis treści](#spis-tre%C5%9Bci)

**autofs** - montowanie systemów plików NFS na żądanie

- [RH - autofs](https://access.redhat.com/documentation/en-us/red_hat_enterprise_linux/7/html/storage_administration_guide/nfs-autofs)
- [Montowanie pod /net](#Automatyczne-montowanie-katalogu-/net)  
- [Montowanie katalogów domowych](#Automatyczne-montowanie-katalogów-domowych) 


### Ogarnąć 

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
  

## Automatyczne montowanie katalogów domowych

### Serwer 

1. Na serwerze NFS (mynfs.example.com) na którym zjanduje się *katalog domowy* użytkownika **janek** należy utworzyć konto dla tego użytkownika,  
**UUID użytkownika *janek* na hoscie i kliencie musi być takie samo**  

    ```bash
    mkdir /home/shared
    useradd -c "Jan Kowalski" -d /home/shared/janek janek
    grep janek /etc/passwd
    janek:x:1000:1000:Jan Kowalski:/home/shared/janek:/bin/bash  
    ```

2. Na serwerze NFS należy wyeksportować katalog /home/shared do całej sieci lokalnej (w omawianym przykładzie to sieć 192.168.0.*)  
*Aby to zrobić w /etc/exports należy dodać :*   
    
    ```bash
    # /etc/exports file to share directories under /home/shared  
    # only to other systems on the 192.168.0.0/24 network:
    
    /home/shared 192.168.0.*(rw,insecure)  
    ```
   
    **WAŻNE !** - opcja insecure  umożliwia klientom podczas wykonywania żądań używanie portów o numerach wyższych niż 1024. Część klientów NFS wymaga tej opcji, ponieważ nie ma dostępu do portów zarezerwowanych dla NFS.   

3. Na serwerze NFS ponownie uruchom usługę nfs-server lub, jeśli już działa, wyeksportuj katalog współdzielony.  

    ```bash
    exportfs -a -r -v
    ```

4. **Na serwerze NFS sprawdź, czy w zaporze sieciowej zostały otwarte niezbędne porty lub czy do zapory został dodany seriws nfs.**

### Klient

1. Do pliku */etc/auto.master* dodaj wpis określający punkt montowania, w którym ma zostać zamontowany zdalny katalog NFS oraz (dowolnie wybrany) plik zawierający dane wskazujące położenie zdalnego katalogu NFS.  
*Do pliku auto.master dodaj następujący wiersz kodu:*   

    ```bash
    /home/remote /etc/auto.janek
    ```

2. Do wybranego w poprzednim punkcie pliku
(w moim przypadku jest to /etc/auto.janek) dodaj następujący wiersz kodu:

    ```bash
    janek  -rw   "$nfs_server_address":/home/shared/janek
    ```

3. Ponownie uruchom usługę autofs:
    
    ```bash
    systemctl restart autofs.service
    ```

4. Utwórz użytkownika o nazwie janek **o tym samym UUID co na serwerze** (tutaj jest to 507)   
*aby system klienta był właścicielem plików znajdujących się w katalogu domowym (na serwerze NFS) tego użytkownika.*
 

    ```console
    # useradd -u 507 -c "Jan Kowalski" -d /home/remote/janek janek
    # passwd janek

    Changing password for user janek.  
    New password: ********  
    Retype new password: ********  
    ```


5. **Zaloguj się jako użytkownik janek.**   
Jeżeli wszystko działa prawidłowo, po zalogowaniu się i wejściu do katalogu domowego ```/home/remote/janek```, powinien zostać zamontowany katalog ```/home/shared/janek``` z serwera "$nfs_server_address".  
  

Katalog NFS jest współdzielony, zamontowany w trybie odczytu i zapisu, a jego właścicielem jest użytkownik o identyfikatorze 507 (w obu systemach jest to janek). Dlatego użytkownik janek w systemie lokalnym powinien mieć możliwość dodawania, usuwania, modyfikowania i wyświetlania plików znajdujących się w tym katalogu. Po wylogowaniu się janka — w rzeczywistości gdy przestanie używać katalogu przez ustalony czas (tutaj jest to 10 minut) — katalog zostanie odmontowany.    


# Instalacja/update
- [Spis treści](#spis-tre%C5%9Bci)

### Lokalny spis
- [Dnf](#dnf)
- [Repozytoria](#repo)
- [Dodanie nowego repozytorium](#dodanie-nowego-repozytorium)

### Linki 
Red Hat
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


Random 
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

> ID| Command                  | Date and time    | Action(s)| Altered    
> ------------------------------------------------------------------    
> 12 | -y remove httpd         | 2021-12-22 01:12 | Removed  |   10  
> 11 | -y update bash          | 2021-12-22 01:12 | Upgrade  |    1  
> 10 | -y install wireshark    | 2021-12-22 01:07 | Install  |   98  
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
### Kernel update 
- [RH - Kernel update](https://access.redhat.com/documentation/en-us/red_hat_enterprise_linux/8/html/managing_monitoring_and_updating_the_kernel/updating-kernel-with-yum_managing-monitoring-and-updating-the-kernel)  
- [Lokalnie - Zarządzanie Kernelem](#kernel)  

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

### Przyklady
- ```tar -cvzf "$plik_archiwum" "$folder_do_skompresowania"``` - tworzenie nowego gzipowego archiwum 
- ```tar -tvzf "$plik_archiwum" "$folder_do_skompresowania"``` - wyświetlenie list plików w gzipowym archiwum 
- ```tar -xvzf "$plik_archiwum" "$folder_do_skompresowania"``` - wypakowanie gzipowego archiwum

### gzip

### bzip

### TODO - cos jeszcze?

# Swap
- [Spis treści](#spis-tre%C5%9Bci)

### #TODO - uzupełnić chociaż trochę

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
- [RH - How to change boot options on Linux](https://www.redhat.com/sysadmin/linux-change-boot-options-grub)
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
- [RSYSLOG - aktualny forum](https://learn.redhat.com/t5/Platform-Linux/How-to-install-the-containerized-version-of-rhel8-rsyslog/td-p/20887)
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

### Rootless container procedura
1. loginctl enable-linger "$user" ?
2. loginctl show-user "$user" - sprawdzenie czy linger jest wlaczony dla uzytkownika?
2. podman generate systemd
    - Pliki uslug systemd uzytkownika ```~/.config/systemd/user```
3. systemctl --user daemon-reload - przeladowane plikow systemd dla uzytkownikow standardowych
5. systemctl --user enable|start|stop "$UNIT" - obsluga uslug systemd dla uzytkownikow 


### Kontenery - SeLinux 
- [RH - How to modify SELinux settings with booleans](https://www.redhat.com/sysadmin/change-selinux-settings-boolean)

**Każdy wolumen musi mieć odpowiednio udostępniony plik - Z ODPOWIEDNIO USTAWIONYM KONTEKSTEM PLIKU**
- kontekst dla folderów które mają byc udostępnione może być taki sam jak dla reszty plików 
SRPAWDZIĆ TO MOŻNA PO PODŁĄCZENIU DO TERMINALA KONTENERA I WYDANIU POLECENIA ```ls -lZ /```

- podman container create --volume "volume/volume:Z" - automatyczny kontekst dla volumenu? - ogarnąć całą komendę



## Obrazy kontenerów
### Inspecting images - skopeo
- ```skopeo``` - used to inspect, copy, delete and sign container images


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



# Daily zadanka 
[Spis treści](#spis-tre%C5%9Bci)

- Create a user called tom. Create a directory named /private. Use an acl to only allow access (rwx) to tom to the private directory.
    - Allowed time: 5 minutes.
    
- Create an EXT4 file system mounted under /vol based on a logical volume of 100MB. Reduce the size to 60MB.
    - Allowed time: 10 minutes.

- Find all files bigger than 100MB and write their names into the /root/results.txt file.
    - Allowed time: 8 minutes.

- Create a XFS file system of 100MB. Mount it under /mnt. Then, increase its size by 50MB
    - Allowed time: 10 minutes.

- Find all files bigger than 100MB and write their names into the /root/results.txt file.
    - Allowed time: 8 minutes.

- Archive and compress the content of the /opt directory (create files if none exists).
Uncompress and unarchive the resulting file in /root
    - Allowed time: 10 minutes.

- Add 100MB of swap space to the machine using a new logical volume.
    - Allowed time: 5 minutes.

- Set up time services pointing to default time servers.
    - Allowed time: 5 minutes.

- Create a new user account called "bob" with password "redhat" and set expiration in one week.
    - Allowed time: 5 minutes.

- Install the appropriate kernel update from http://mirrors.kernel.org/centos/6.4/updates/x86_64/Packages.
The following conditions must also be met:
    – the updated kernel is the default kernel when the system is rebooted.
    – the original kernel remains available and bootable on the system.

- Create two new user accounts "steve" and "oliver".  
Create a group "team". Create a directory "shared".  
All files put into the "shared" directory by "steve" or "oliver" should belong to the "team" group and be only visible by them.  
    - Allowed time: 10 minutes.

- Create two users "tom" and "engine". "tom" has the UID/GID 3000 and "engine" the UID/GID 4000. "engine" doesn't have an interactive shell.
    - Allowed time: 5 minutes.

- Add 100MB of swap space to the machine using a new logical volume.
    - Allowed time: 5 minutes.


# Przed egzaminem 
- [Spis treści](#spis-treści)

### Ogolne 
- [Przywracanie hasła roota](#przywracanie-hasła-roota)
- [man](#man)
    - ```mandb``` - odświeża bazę danych man, ODPALAĆ NA POCZĄTKU EGZAMINU

### Storage
- [Sprawdzene poprawnosci fstab](https://sleeplessbeastie.eu/2019/01/21/how-to-verify-fstab-file/)
    - ```findmnt --verify``` - komenda sprawdzajaca poprawnosc fstab

### Skrypty
- ```man sh``` - lista zmiennych specjalnych

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


ZADANIE 12 CHELBIK
grub2-mkconfig 

/boot - 

OPISAĆ


# Blokowanie połączenia z konkretnego serwera  

I just added the following to the drop zone and it worked without any issue:

firewall-cmd --zone=drop --add-source=x.x.x.x/xx

replace x.x.x.x with the IP and you can add the subnet under /xx

reguły dla danej strefy, do drop dodajemy źródłą które chcemy blokować 
```
firewall-cmd --zone=drop --list-all
```

you could also use /etc/hosts.allow
/etc/hosts.deny


## ftp
```console
# vi /etc/sysconfig/iptables-config
IPTABLES_MODULES=”nf_conntrack_ftp nf_nat_ftp”
# iptables -I INPUT -m state –state NEW -m tcp -p tcp –dport 20 -j ACCEPT
# iptables -I INPUT -m state –state NEW -m tcp -p tcp –dport 21 -j ACCEPT
# service iptables save
# service iptables restart
# vi /etc/hosts.deny
vsftpd: .hackers.net: DENY
```

### httpd
```console
# vi /etc/httpd/conf/httpd.conf
Order allow,deny
Allow from 127.0.0.1 server1.example.com
```



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
    - musiałem stawiać kontenery jako root, sprawdzić dlaczego 
    - pobieranie kontenerów ze zdalnego repozytorium 
- VDO
    - założenie filesystemu z miejscem logicznym
    - pamiętać o włączeniu usługi!
- Przypisanie IP do serwerów, zmiana hostname
- Repo 
    - dodanie repo, appstream i baseos, nie ma żadnego innego przykładowego 
    - pamietac o gpgcheck=no i sslverify=no 
- autofs
    - home foldery, automatyczne mapowanie
- SELinux 
    - jest błąd z serwerem httpd, nadanie kontekstu do folderu tak żeby serwer mógł odczytać pliki
    - zdiagnozowanie problemu z SELinux przez /var/log/messages





https://askubuntu.com/questions/1148620/rc-local-to-be-executed-at-boot
. You can find a rc.local in there that has a remark about it running /etc/rc.local if present. That is the one you probably are expected to create.

In /etc/rc.local you can put scripts to be executed at a run-level.

Example file with 1 line added:

$ more /etc/rc.local

#!/bin/sh -e
#
# rc.local
#
# This script is executed at the end of each multiuser runlevel.
# Make sure that the script will "exit 0" on success or any other
# value on error.
#
# In order to enable or disable this script just change the execution
# bits.
#
# By default this script does nothing.

[ -x /sbin/initctl ] && initctl emit --no-wait google-rc-local-has-run || true

exit 0


# Koniec

- [Spis treści](#spis-tre%C5%9Bci)

