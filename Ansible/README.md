 
# Spis treści

# Serial
ozark

# Strona 139

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


1. Type ansible all --list-hosts. You get a failure
message because the ansible command does
not find any inventory containing hosts.
4. Type ansible -i inventory all --list-hosts.
Now you see a list of all hosts in inventory.
5. Type ansible -i inventory ungrouped --listhosts. This command shows all hosts that are
not a member of any group.
6. Use ansible-inventory -i inventory --
graph. This command shows a hierarchical
overview of inventory, including information
about which host is a member of which group.
7. Use ansible-inventory -i inventory --list.
This command shows the contents of the
inventory represented in JSON format.

## Specifying Host Variables

**In older versions of Ansible**, the inventory file was also used to define variables for specific hosts.   
**This behavior is deprecated and should not be used anymore.**

- Sample Inventory with Variables
```
[win]
windows.example.com

[win:vars]
ansible_user=ansible
ansible_password=@nsible123
ansible_connection=winrm
ansible_winrm_server_cert_validation=ignore
```

As you can see, the variables are set at a group level, using [groupname:vars]. You shouldn’t use this approach anymore, though. 
**Variables in current versions of Ansible should be set using the host_vars and group_vars directories**

# WORKING WITH DYNAMIC INVENTORY

Można tworzyć skrypty do automatycznego tworzenia plików ini, nic specjalnego, zwykłe skrypty, 
są gotowce na githubie



# MANAGING SETTINGS IN ANSIBLE.CFG

- ```/etc/ansible/ansible.cfg``` - główny config



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

- ```/etc/ansible/hosts``` - domyślny plik dla wskazania hostów 
- ```/etc/ansible/ansible.cfg``` - config dla ansible

- Wyświetlenie obecnego configu 
    - ```ansible --version``` - wyświetla który config jest obecnie używany 

- Plik ansible Config 
    - ```ANSIBLE_CONFIG``` - zmienna śrowowiskowa do której można przypisać nowy config
        - np. ```export ANSIBLE_CONFIG=/ansible/ansible.cfg```

Rzeczy zapisane w configu ansible mogą zostać zastąpione w playbooku!
Config to miejsce dla domyślnych opcji


# Using Ad Hoc Commands


Sample ad-hoc command

```ansible all -m user -a "name=lisa"``` - This command contains a few ingredients. To start with,
there is the ansible command, which is the command
for running ad hoc commands. Next, you need to specify
on which hosts you want to run the ad hoc commands,
which is accomplished by the all part of the command.
The third element refers to the module that you want to
run. A module is a script that is executed by Ansible to
perform a specific task. In the sample command shown,
the -m option is used to call the module, and the
specific module in this example is user. Finally, you
need to provide arguments to the module by using the -
a option. In an ad hoc command, all arguments are
provided between double quotes. In this case there is
just one argument, but if there are many arguments, all
of them need to be included between double quotes.


# WORKING WITH MODULES

## Essential Modules


- command
- shell
- raw - runs commands directly on top of SSH without using Python
- copy
- yum
- service
- ping




### Koniec
