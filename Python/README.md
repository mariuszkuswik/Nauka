# Spis treści 

### [Aktualny link do Codecademy](https://www.codecademy.com/courses/learn-python-3/lessons/create-python-list/exercises/modifying-list-elements)


1. [Listy](#listy)


# Listy 
[Spis treści](#spis-treści)

1. [Listy - rozszerzanie](#Listy---rozszerzanie)
1. [Listy - indeksy](#Listy---indeksy)
1. [Listy - modyfikowanie elementów](#Listy---modyfikowanie-elementów)
1. [Listy - Usuwanie elementów](#Listy---Usuwanie-elementów)


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
**Indeksy liczone są od 0!**
```python
employees = ["Michael", "Dwight", "Jim", "Pam", "Ryan", "Andy", "Robert"]

# Przypisanie trzeciego elementu 
employee_four=employees[3]
# Wypisanie szóstego elementu
print(employees[6])
```
> Robert

### Indeksy negatywne 
Indeksy ujemne sprawdzają listę od tyłu
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
>Output:
['Celery', 'Orange Juice', 'Orange', 'Flatbread']  
['Celery', 'Orange Juice', 'Orange']  
['Orange', 'Apple', 'Mango', 'Broccoli', 'Mango']  
['Orange', 'Apple', 'Broccoli', 'Mango']  
> 
> Traceback (most recent call last):  
  File "script.py", line 16, in <module>  
    new_store_order_list.remove("Onions")  
ValueError: list.remove(x): x not in list  
  


[Spis treści - top](#spis-treści)