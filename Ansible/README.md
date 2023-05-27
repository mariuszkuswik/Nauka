 
# Spis treści

# Strona 109

[RH - How to use YAML nesting, lists, and comments in Ansible playbooks](https://www.redhat.com/sysadmin/yaml-nesting-lists-comments-ansible)

1. [Grupowanie](#grupowanie)
- [Koniec](#Koniec)

# CONFIGURING MANAGED HOSTS
## Wymagania dla zdalnych hostów
1. systemctl status sshd - sshd musi być włączony 
2. rpm -qa | grep python - python musi być zainstalowany 
3. firewall-cmd --list-all - sshd musi być dodany

# CONFIGURING THE ANSIBLE USER

While managing an environment with Ansible, you need a dedicated user account. 

### Exercise 2-6 Setting Up SSH Key-Based User Authentication
Na egzaminie 

## Configuring sudo for the Ansible User



# CONFIGURING STATIC INVENTORY

## Listing hosts

In the project approach,
each project directory should have its own inventory
file.

In smaller Ansible managed environments, the file
/etc/ansible/hosts can be used as the inventory file. 

An Ansible inventory can be just a list of host names or
IP addresses. You don’t need to specify name-resolving
information as well because DNS or the /etc/hosts file
should be taking care of name resolving. Apart from just
listing the names or IP addresses of hosts, the inventory
file also can work with ranges. For instance, the line
server[1:6].example.com would address all servers
between server1 and server6.

## Inventory Host Groups

When you’re working with many hosts, using host
groups is convenient. Host groups can be defined in
inventory, and a host may be a member of multiple host
groups. You can also work with nested groups, where a
group is a member of another group. The example in
Listing 3-1 shows what host group definitions should
look like.

Listing 3-1 Inventory File with Host Groups

```
ansible1
ansible2
192.168.4.1
192.168.4.2

[web]
web1
web2

[db]
db1
db2

[servers:children]
web
db
```

In Listing 3-1, you first see the hosts ansible1 and
ansible2, which are not members of any specific group.
Also, you see two IP addresses. You are allowed **(though
it is not recommended)** to include IP addresses as well.


Next, a group web and a group db are defined. In the
example you also see the group servers that address all
hosts in the group [web] as well as the [db] group.









# Pliki ini  
[Spis treści](#spis-treści)

Pliki konfiguracyjne ini - zawierają informacje na temat maszyn na których chcemy stosowac komendy/ustawienia?



## Grupy 

- Grupy definjuje się w kwadratowych nawiasach
- Hostami mogą być **pełne nazwy domenowe**, **nazwy hostów** lub **adresy ip** 

- plik ini
```ini
[canada]
host1
web.server.com
192.168.1.10

[usa]
host11
host22
host33
```

- Grupy specjalne 
    - ```all``` - wszystkie hosty
    - ```ungrouped``` - hosty po za jakąkolwiek grupą
- Nazwy moga zawierać podłóg **_** ale nie myślniki **-**
- Nazwy grup nie powinny być takie same jak nazwy hostów 


### Grupy podrzędne - Nested groups

```ini
[canada]
host1
web.server.com
192.168.1.10

[usa]
host11
host22
host33

[noth_america:children]
canada
usa
```

W powyższym przykładzie ```canada``` i ```usa``` są podrupami dla ```north_america``` 

### Zasięgi dla hostów 




# Ansible config 

```/etc/ansible/hosts``` - domyślny plik dla wskazania hostów 
```/etc/ansible/ansible.cfg``` - config dla ansible

```ansible --version``` - wyświetla który config jest obecnie używany 

```ANSIBLE_CONFIG``` - zmienna śrowowiskowa do której można przypisać nowy config
```export ANSIBLE_CONFIG=/ansible/ansible.cfg```





### Koniec
