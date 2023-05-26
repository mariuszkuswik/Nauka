 
# Spis treści

# Strona 91

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
