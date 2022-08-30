# Linki ważne
- [Aktualny link do Codecademy](https://www.codecademy.com/courses/learn-python-3/lessons/modules-python/exercises/modules-python-files-and-scope)
- [Ostatnie miejsce notatek](https://www.codecademy.com/courses/learn-python-3/lessons/create-python-list/exercises/modifying-2-d-lists)



# Spis treści 

1. [Listy](#listy)
1. [Petle](#petle)
1. [Stringi](#stringi)

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

## Listy - .insert() 

#### The Python list method .insert() allows us to add an element to a specific index in a list.

The **.insert()** method takes in two inputs:
- The index you want to insert into.
- The element you want to insert at the specified index.


#### Here is how we would use the .insert() method to insert "Vikor" :
```python
store_line = ["Karla", "Maxium", "Martim", "Isabella"]

store_line.insert(2, "Vikor")
print(store_line) # ['Karla', 'Maxium', 'Vikor', 'Martim', 'Isabella']
```

> ['Karla', 'Maxium', 'Vikor', 'Martim', 'Isabella']

## Listy - .pop()

- metoda **.pop()** bez parametru wyrzuca ostatni element z listy
- po podaniu parametru wyrzuca konkretny
- wyrzucony element można przypisać zmiennej

```python
data_science_topics = ["Machine Learning", "SQL", "Pandas", "Algorithms", "Statistics", "Python 3"]
print(data_science_topics)   

# Wyrzucenie ostatniego elementu listy
data_science_topics.pop()
print(data_science_topics)    # ['Machine Learning', 'SQL', 'Pandas', 'Algorithms', 'Statistics']

# Wyrzucenie drugiego od konca elementu listy
data_science_topics.pop(-2)
print(data_science_topics)    # ['Machine Learning', 'SQL', 'Pandas', 'Statistics']

# Wyrzucenie trzeciego elementu listy
data_science_topics.pop(2)
print(data_science_topics)    # ['Machine Learning', 'SQL', 'Statistics']
```

>['Machine Learning', 'SQL', 'Pandas', 'Algorithms', 'Statistics', 'Python 3']
['Machine Learning', 'SQL', 'Pandas', 'Algorithms', 'Statistics']
['Machine Learning', 'SQL', 'Pandas', 'Statistics']
['Machine Learning', 'SQL', 'Statistics']


## Listy - range i list
Often, we want to create a list of consecutive numbers in our programs. For example, suppose we want a list containing the numbers 0 through 9:

my_list = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
Typing out all of those numbers takes time and the more numbers we type, the more likely it is that we have a typo that can cause an error.

Python gives us an easy way of creating these types of lists using a built-in function called range().

The function range() takes a single input, and generates numbers starting at 0 and ending at the number before the input.

So, if we want the numbers from 0 through 9, we use range(10) because 10 is 1 greater than 9:

my_range = range(10)
print(my_range)
Would output:

range(0, 10)
Notice something different? The range() function is unique in that it creates a range object. It is not a typical list like the ones we have been working with.

In order to use this object as a list, we have to first convert it using another built-in function called list().

The list() function takes in a single input for the object you want to convert.

We use the **list()** function on our range object like this:

```python
print(list(my_range))
```
Would output:

> [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]

Let’s try out using range()!

### Your code below: 

```python
number_list = range(9)
print(list(number_list))

zero_to_seven=range(8)
print(list(zero_to_seven))
```

## Tupples 

### #TODO - opisać chociaż coś


# Petle

[Spis tresci](#spis-treści)
1. [For](#for)

## Petle - For
#### Jak działa
```python
for <temporary variable> in <collection>:
  <action>
```
1. A for keyword indicates the start of a for loop.
2. A <temporary variable> that is used to represent the value of the element in the collection the loop is currently on.
3. An in keyword separates the temporary variable from the collection used for iteration.
4. A <collection> to loop over. In our examples, we will be using a list.
5. An <action> to do anything on each iteration of the loop.


#### Przykład 
```python
ingredients = ["milk", "sugar", "vanilla extract", "dough", "chocolate"]
 
for ingredient in ingredients:
  print(ingredient)
```


# Stringi

Review

- A string is a list of characters.
- A character can be selected from a string using its index string_name[index]. These indices start at 0.
- A ‘slice’ can be selected from a string. These can be between two indices or can be open-ended, selecting all of the string from a point.
- Strings can be concatenated to make larger strings.
- len() can be used to determine the number of characters in a string.
- Strings can be iterated through using for loops.
- Iterating through strings opens up a huge potential for applications, especially when combined with conditional statements.


# STRING METHODS

Review

- .upper(), .title(), and .lower() adjust the casing of your string.
- .split() takes a string and creates a list of substrings.
- .join() takes a list of strings and creates a string.
- .strip() cleans off whitespace, or other noise from the beginning and end of a string.
- .replace() replaces all instances of a character/string in a string with another character/string.
- .find() searches a string for a character/string and returns the index value that character/string is found at.
- .format() allows you to interpolate a string with variables.






[Spis treści - top](#spis-treści)