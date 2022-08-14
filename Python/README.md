# Linki ważne
- [Aktualny link do Codecademy](https://www.codecademy.com/courses/learn-python-3/lessons/create-python-list/exercises/review)

- [Ostatnie miejsce notatek](https://www.codecademy.com/courses/learn-python-3/lessons/create-python-list/exercises/modifying-2-d-lists)



# Spis treści 

1. [Listy](#listy)
1. [Testowy linkk](#Testowy)

# Listy 
[Spis treści](#spis-treści)

1. [Listy - rozszerzanie](#Listy---rozszerzanie)
1. [Listy - indeksy](#Listy---indeksy)
1. [Listy - modyfikowanie elementów](#Listy---modyfikowanie-elementów)
1. [Listy - Usuwanie elementów](#Listy---Usuwanie-elementów)

# Wstęp
```python
# Example syntax for methods
list.method(input)
 
# Example syntax for a built-in function 
builtinfuncion(input)
```


## Listy - rozszerzanie
### Dodawanie pojedynczego elementu
```python
orders = ["daisies", "periwinkle"]

print (orders)

# Dodanie jednego elementu
orders.append("tulips")
orders.append("roses")

print (orders)

```

### Dodawanie list
```python
orders = ["daisy", "buttercup", "snapdragon", "gardenia", "lily"]
new_orders=["lilac","iris"]

# Dodanie dwóch list orders i new_orders
orders_combined=orders+new_orders

# Dodanie kolejnego elementu za pomocą dodatkowej listy
broken_prices = [5, 3, 4, 5, 4] + [4]
print (broken_prices)
```
> [5, 3, 4, 5, 4, 4]


## Listy - indeksy

### Indeksy pozytywne
- **Indeksy liczone są od 0!**
```python
employees = ["Michael", "Dwight", "Jim", "Pam", "Ryan", "Andy", "Robert"]

# Przypisanie trzeciego elementu 
employee_four=employees[3]
# Wypisanie szóstego elementu
print(employees[6])
```
> Robert

### Indeksy negatywne 
- Indeksy negatywne sprawdzają listę od tyłu
```python
shopping_list = ["eggs", "butter", "milk", "cucumbers", "juice", "cereal"]

last_element=shopping_list[-1]
index5_element=shopping_list[5]

print (index5_element,last_element)
```
>cereal cereal


## Listy - modyfikowanie elementów
```python
garden_waitlist=["Jiho", "Adam", "Sonny", "Alisha"]
garden_waitlist[1]="Calla"
garden_waitlist[-1]="Alex"
print(garden_waitlist)
```
>['Jiho', 'Calla', 'Sonny', 'Alex']


## Listy -  Usuwanie elementów
- Jezeli nie mamy na liscie elementu ktory chcemy usunac dostaniemy **ValueError**

```python
order_list=["Celery", "Orange Juice", "Orange", "Flatbread"]
print (order_list)

order_list.remove("Flatbread")
print (order_list)

new_store_order_list=["Orange", "Apple", "Mango", "Broccoli", "Mango"]
print(new_store_order_list)

# Jezeli istnieja dwie wartosci to metoda remove usunie tylko piwersza!
new_store_order_list.remove("Mango")
print(new_store_order_list) # ['Orange', 'Apple', 'Broccoli', 'Mango']

# Jezeli nie mamy na liscie elementu ktory chcemy usunac dostaniemy ValueError
new_store_order_list.remove("Onions")
```
>['Celery', 'Orange Juice', 'Orange', 'Flatbread']  
['Celery', 'Orange Juice', 'Orange']  
['Orange', 'Apple', 'Mango', 'Broccoli', 'Mango']  
['Orange', 'Apple', 'Broccoli', 'Mango']  
> 
> Traceback (most recent call last):  
  File "script.py", line 16, in <module>  
    new_store_order_list.remove("Onions")  
ValueError: list.remove(x): x not in list  
  

## Listy - dwuwymiarowe 
- Lists that contains other lists  

```python
class_name_test=[["Jenny", 90], ["Alexus", 85.5], ["Sam", 83], ["Ellie", 101.5]]

print (class_name_test) # [['Jenny', 90], ['Alexus', 85.5], ['Sam', 83], ['Ellie', 101.5]]

### WAZNE!
# Wyswietlenie drugiej listy i jej pierwszego elementu
sams_score=class_name_test[2][1]
print (sams_score) # 83

### WAZNE!
# Uzycie negatywnych indeksow do wyswietlenia
ellies_score=class_name_test[-1][-1]
print (ellies_score) # 101.5
```

>[['Jenny', 90], ['Alexus', 85.5], ['Sam', 83], ['Ellie', 101.5]]  
83  
101.5  


```python
incoming_class=[["Kenny", "American", 9], ["Tanya", "Russian", 9], ["Madison", "Indian", 7]]

print (incoming_class)
incoming_class[2][2]=8

incoming_class[-3][-3]="Ken"
print (incoming_class)
```









[Spis treści - top](#spis-treści)