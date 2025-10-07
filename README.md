# Zadanie 1
# Zastosowane podejście: DDD + SOLID

## Struktura projektu:

Domain        → encje (Employee), value objects (EmployeeStructure), interfejsy repozytoriów <br />
Application   → DTO (EmployeeStructureDto), serwis aplikacyjny (EmployeeStructureService) <br />
Infrastructure→ implementacje repozytoria (EmployeeRepository), dostęp do bazy (DbContext) <br />
App           → warstwa wizualna w konsoli <br />

## DDD:
Domain zawiera model biznesowy i logikę (EmployeeService). <br />
Interfejsy repozytoriów w Domain, implementacje w Infrastructure. (bez CRUD) <br />
DTO w Application izolują model domenowy od warstw wyjściowych. <br />
Serwis aplikacyjny (EmployeeStructureService) koordynuje operacje. <br />

## SOLID:

S: Każdy element ma jedną odpowiedzialność. <br />
O: System rozszerzalny bez zmiany istniejącego kodu. <br /> 
L: Interfejsy umożliwiają wymienność implementacji. <br />
I: Interfejsy mają minimalny zestaw metod. <br />
D: Warstwy wyższe zależą od abstrakcji, nie implementacji. <br />

## Przepływ działania:

Program.cs tworzy repozytorium i serwis aplikacyjny. <br />
Serwis pobiera dane przez repozytorium. <br />
Dane przekazywane są do serwisu domenowego, który buduje hierarchię. <br />
Wynik jest mapowany do DTO i zwracany. 
