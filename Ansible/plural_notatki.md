 
# Spis treści

1. [Grupowanie](#grupowanie)
- [Koniec](#Koniec)


# Grupowanie 
[Spis treści](#spis-treści)

Pliki konfiguracyjne ini - zawierają informacje na temat maszyn na których chcemy stosowac komendy/ustawienia?

## Pliki ini 

- Przykładowy plik ini
- Hostami mogą być **pełne nazwy domenowe**, **nazwy hostów** lub **adresy ip** 

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

### Grupy 
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



### Koniec