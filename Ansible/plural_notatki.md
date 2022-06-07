 
# Spis treści

1. [Grupowanie](#grupowanie)
- [Koniec](#Koniec)


## Grupowanie 
[Spis treści](#spis-treści)

Pliki konfiguracyjne ini - zawierają informacje na temat maszyn na których chcemy stosowac komendy/ustawienia?

#### Pliki ini 

- Przykładowy plik ini
- Hostami mogą być **pełne nazwy domenowe**, **nazwy hostów** lub **adresy ip** 

```ini
[nazwa_grupy]
host1
web.server.com
192.168.1.10

[nazwa_drugiej_grupy]
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

Grupy moga zawierać grupy podżędne 

```ini
[nazwa_grupy:]
host1
web.server.com
192.168.1.10
```

### Koniec