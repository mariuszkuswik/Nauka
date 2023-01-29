
# Sito Erastotenesa ogólnie
Sito Eratostenesa jest algorytmem, który pozwala na znalezienie liczb pierwszych w zadanym zakresie. Algorytm ten jest bardzo prosty w implementacji i działa na zasadzie eliminacji liczb złożonych.

# Wstęp do programu 
W programie, który zaproponowałem, najpierw tworzymy listę liczb od 2 do n (gdzie n jest górną granicą wyszukiwania liczb pierwszych). Następnie przy pomocy pętli for przeszukujemy tę listę i dla każdej liczby sprawdzamy, czy jest ona pierwsza. Jeśli tak, to dodajemy ją do listy liczb pierwszych, a także usuwamy jej wielokrotności z listy liczb (ponieważ liczby te nie mogą być pierwsze). Dzięki temu, dla każdej liczby pierwszej, eliminujemy z listy jej niepierwsze wielokrotności.


# Co to są bliźniaki i trojaczki 
Bliźniaki pierwsze to para liczb pierwszych, które różnią się od siebie o 2. Na przykład liczby 3 i 5 są bliźniakami pierwszymi, ponieważ różnica między nimi wynosi 2.

Trojaczki pierwsze to trójka liczb pierwszych, które różnią się od siebie o 6. Na przykład liczby 5, 11 i 17 są trojaczkami pierwszymi, ponieważ różnica między każdą z tych liczb a następną wynosi 6.


# Znajdowanie bliźniaków i trojaczków
W programie zaproponowanym przeze mnie, znajdowanie bliźniaków i trojaczków pierwszych jest realizowane po znalezieniu liczb pierwszych, przy pomocy kolejnej pętli for, która sprawdza czy liczba pierwsza +2 oraz liczba pierwsza +6 są również liczbami pierwszymi i jeśli tak to zapisuje je do odpowiedniej listy.

W programie, który zaproponowałem, po znalezieniu liczb pierwszych, przy pomocy pętli for, sprawdzamy czy liczba pierwsza +2 oraz liczba pierwsza +6 są również liczbami pierwszymi. Jeśli tak to zapisujemy je do odpowiedniej listy, czyli listy bliźniaków lub listy trojaczków pierwszych.

Te pojęcia są często używane przez matematyków, zwłaszcza przy badaniach dotyczących liczb pierwszych, ponieważ ich występowanie jest rzadkie i interesujące.

# Stio Erastotenesa cd. 
Sito Eratostenesa jest skuteczne tylko dla małych zakresów liczb, ponieważ jego skuteczność maleje wraz ze wzrostem zakresu. Dla większych zakresów lepiej używać innych algorytmów, takich jak np. Miller-Rabin lub AKS.

# Zakończenie 
Podsumowując, algorytm Sita Eratostenesa jest prostym i skutecznym rozwiązaniem do znajdowania liczb pierwszych oraz ich bliźniaków i trojaczków, jednak jego skuteczność jest ograniczona do małych zakresów liczb. Program jest uniwersalny i dostosowany do indywidualnych potrzeb dzięki zastosowaniu zmiennej n, która określa górną granicę wyszukiwania liczb pierwszych.Sito Eratostenesa to algorytm pozwalający na znalezienie liczb pierwszych w zadanym zakresie. Jest to jeden z najstarszych i najprostszych algorytmów do tego celu.




# WSTĘPNA WERSJA?
W programie najpierw tworzymy listę liczb od 2 do n (gdzie n jest górną granicą wyszukiwania liczb pierwszych). Następnie, przy pomocy pętli for, przeszukujemy tę listę i dla każdej liczby sprawdzamy, czy jest ona pierwsza. Jeśli tak, to dodajemy ją do listy liczb pierwszych, a także usuwamy jej wielokrotności z listy liczb (ponieważ liczby te nie mogą być pierwsze).

W programie przygotowanym dla Ciebie, dodatkowo znajdujemy bliźniaki i trojaczki pierwszych, czyli liczby pierwsze, które różnią się od siebie o 2 lub 6.

Warto pamiętać, że algorytm Sita Eratostenesa jest skuteczny tylko dla małych zakresów liczb (do około 10 milionów). Dla większych zakresów lepiej używać innych algorytmów, takich jak np. "Miller-Rabin" lub "AKS"

W programie zastosowano zmienną n, która określa górną granice wyszukiwania liczb pierwszych, dzięki czemu program jest uniwersalny i można go dostosować do indywidualnych potrzeb.




Co to są bliźniaki i trojaczki 

