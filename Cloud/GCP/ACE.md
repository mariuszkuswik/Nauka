# strona 58


# Rozdzial 1 - Exam Essentials

## Cloud computing resources
- VMki 
- Clustry VMek
- GKE - google kubernetes engine? - Wymaga zarządzania kubernetesem 
- Serverless - brak zarządzania i kontroli nad maszynami

## Cloud Storage
Kategorie: 
- object storage - do przechowywania plików, takie buckety?
- file storage - storage dostępny po sieci  
- block storage - storage na którym tworzy się filesystem 
- in-memory caches - cache

## Różnice pomiędzy on-premise a chmurą

### Główne cechy chmury 
#### Zalety
- pay-as-you-go model
- elastyczne przydzielanie zasobów
- możliwośc wykorzystywania specjalnych serwisów, zapewnionych przez dostawców chmury

### Wady
- koszt operacji maszyn może być wyższy niż w przypadku on-premise 
- Ważne jest aby zrozumieć jak działają koszty tak aby rozłożyć workload pomiędzy chmurę a on-premise 



### Rozdzial 1 - Test 
1. B. +
2. D. +
3. A. -
4. B. +
5. d +
6. c +
7. c +
8. b + 
9. b +
10. d +
11. b +
12. d + 
13. a + 
14. c -
15. d +
16. b +
17. c + 
18. b +
19. c +
20. b +


# Rozdzial 2 - Exam Essentials 

# Uslugi GCP

## IAAS i PAAS 
- IaaS - Compute Engine
    - GCP używa bardziej zabezpieczonej wersji KVM
    - Making the VM preemptible - VMka może być wywłaszczalna, obniża to koszty do 80% ale może być wyłączona w dowolnym momencie (będzie wczęsto wyłączana, jeżeli działa minimum 24h)
    - 
- PaaS (Platform as a Service) - App Engine, Cloud Functions, Kubernetes Engine
    - App Engine - serverless - app engine jest dobry jako backend dla aplikacji web i mobile,  
        - standard - aplikacja działa w sandboxie specificznym dla danego języka, jest odizolowana od systemu operacyjnego i innych aplikacji, jest to dobre gdy aplikacja nie potrzebuje dodatkowych paczek ani innych aplikacji
        - felxible - Odpalasz kontener dockerowy w środowisku app engine - działa dobrze gdy potrzebujesz dodatkowych bibliotek lub oprogramowania, pozwala na pracę z procesami systemowymi i zapisu na lokalnym dysku 
    - Cloud Functions - serverless - Odpala kod w odpowiedzi na jakiś event, np. plik zostaje wrzucony do Cloud Storage lub jakaś wiadomość przyszła do kolejek wiadomości, kod w takiej aplikacji musi działać krótko, często działa do odpalania innych serwisów, takich jak API czy inne funkcje GCPa 

- Kubernetes Engine

## Cloud Storage 
Objects are organized into buckets, which are analogous to directories in a file system. It is important to remember that Cloud Storage is not a file system.

Cloud Storage is not part of a VM in the way an attached persistent disk is. Cloud Storage
is accessible from VM (or any other network device with appropriate privileges) and so
complements file systems on persistent disks.
Each stored object is uniquely addressable by a URL.

Cloud Storage is useful for storing objects that are treated as single units of data. For
example, an image file is a good candidate for object storage. Images are generally read and
written all at once. There is rarely a need to retrieve only a portion of the image. In general,
if you write or retrieve an object all at once and you need to store it independently of servers that may or may not be running at any time, then Cloud Storage is a good option.