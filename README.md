# ERP-система для Московского зоопарка

## Описание проекта

Данное консольное приложение представляет собой ERP-систему для Московского зоопарка, позволяющую вести учёт животных и вещей, состоящих на балансе.

### Функциональность:
1. **Добавление новых животных в зоопарк** (после проверки их здоровья).
2. **Расчёт общего количества пищи**, необходимого всем животным.
3. **Вывод списка животных для контактного зоопарка** (только травоядные с уровнем доброты > 5).
4. **Учёт вещей и инвентаря**, состоящих на балансе зоопарка.
5. **Использование DI-контейнера** для внедрения зависимостей.

---

## Применение SOLID

### **S**ingle Responsibility Principle (Принцип единственной ответственности)
Каждый класс отвечает только за одну задачу:
- `Animal`, `Herbo`, `Predator`, `Monkey`, `Rabbit`, `Tiger`, `Wolf` — отвечают за представление животных.
- `Zoo` управляет коллекцией животных и инвентаря.
- `VeterinaryClinic` проверяет здоровье животных.
- `Thing`, `Table`, `Computer` представляют объекты инвентаря.

### **O**pen/Closed Principle (Принцип открытости/закрытости)
- Новые виды животных можно добавлять без изменения существующего кода, расширяя класс `Animal`.
- В будущем можно добавлять новые виды инвентаря, расширяя `Thing`.

### **L**iskov Substitution Principle (Принцип подстановки Барбары Лисков)
- `Herbo` и `Predator` расширяют `Animal`, не изменяя его базовое поведение.
- Все наследники `Animal` можно использовать вместо базового класса без нарушения логики.

### **I**nterface Segregation Principle (Принцип разделения интерфейсов)
- `IAlive` отвечает за характеристики живых существ (свойство `Food`).
- `IInventory` отвечает за характеристики инвентаря (свойство `Number`).
- Классы `Animal` и `Thing` реализуют только нужные им интерфейсы.

### **D**ependency Inversion Principle (Принцип инверсии зависимостей)
- В `Program.cs` используется **DI-контейнер** (`Microsoft.Extensions.DependencyInjection`).
- `Zoo` получает `VeterinaryClinic` через конструктор (внедрение зависимостей).

---

## Инструкция по запуску

### **Требования:**
- .NET 6+
- Visual Studio 2022 / Rider / VS Code

### **Запуск приложения:**
1. **Клонируйте репозиторий:**
   ```sh
   git clone https://github.com/M1steryO/KPO_HW_1.git
   cd zoo-erp
   ```
2. **Соберите проект:**
   ```sh
   dotnet build
   ```
3. **Запустите приложение:**
   ```sh
   dotnet run --project Zoo.ConsoleApp
   ```


---


