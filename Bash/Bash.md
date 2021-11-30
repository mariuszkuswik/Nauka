
# Linux/Bash

## System Linux 

### Pytania pod rozmowę 
- Jakie znam filesystemy na linuxie, czym się charakteryzują  
	- ext2, ext3, ext4, xfs, btrfs
	- Upenić się czy jest to ok 
- jakie znam katalogi linuxowe, za co odpowiadają 
- gdzie przechowywane sa logi 
- gdzie przechowywane są pliki konfiguracyjne 
- jak dziala . ./script_name.sh
	- sourcowanie plikow, skrypt wykona się i zaciągnięte zostaną z niego wartości
	- Sprawdzić czy coś dopisać  
- jakie znam rodzaje RAIDa, na czym polegają



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

### Namespaces/Przestrzeenie nazw 
[Artykuł wyjaśniający](https://linuxpolska.pl/blog/zabawa-w-namespaces/)
- Przestrzenie nazw sprawiają, że możliwa jest całkowita separacja sieci – routingu, iptables i interfejsów sieciowych.
   # #TODO - Do sprawdzenia + poprawienia wszystko, sprawdzić czy poniższe komendy działają dobrze, przetestować je sensownie 


<details>
   <summary>

   ## Przykład   
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

### Routing 


```ip route``` - routing table management  

```ip route show ```  





   </summary>

</details>














# #TODO - odpowiedzieć na pytanie 
Jak działa routing i maska podsieci 
Wyświetl karty sieciowe w linuxie, opisz czego się na tej podstawie dowiedziałeś

# System 

Systemctl - opisać 

# Wirtualizacja 

Czym jest wirtualizacja  
Sprawdź czy maszyna na której jesteź jest maszyną wirtualną 

