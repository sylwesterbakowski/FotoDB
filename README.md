# FotoDB
Entity Framework Core - Projekt na zaliczenie JIPP

TODO:
Wykonać aplikację opartą na .NET Core MVC do przechowywania w bazie danych informacji na temat zdjęć, ich autorów i kraju pochodzenia autora.
Zdjęcia powinny być zapisywane w bazie danych, a nie na dysku.

Aplikacja ma realizować następujące elementy:
1. Połączenie z bazą danych  poprzez Entity Framework
	a. modele danych: KrajModel, AutorModel, FotoModel
2. Operacje CRUD (utwórz, wyświetl jeden element, wyświetl listę elementów, edytuj, usuń)
3. Warstwa pośrednia pomiędzy bazą danych a kontrolerem: KrajManager, AutorManager, FotoManager
4. Widoki do wszystkich operacji CRUD
	Create, Delete, Details, Edit, Index z listą elementów
5. Wykorzystanie framework Bootstrap do poprawienia wyglądu widoków
6. Dependency Injection
7. Opis wzorców projektowych i ich zastosowanie w .NET Core
	a. Kompozytor
		Wzorzec projektowy kompozytor to wzorzec projektowy, który pozwala komponować obiekty w strukturę drzewa, 
		a następnie pracować z tą strukturą tak, jakby był to pojedynczy obiekt. Oznacza to również, że użycie tego wzorca projektowego 
		ma sens, gdy część aplikacji może być reprezentowana jako drzewo.
		Struktura wzorca projektu kompozytowego
		
	b. Obserwator
		Wzorzec obserwatora to wzorzec projektowy, w którym obiekt, nazwany podmiotem, utrzymuje listę swoich obiektów zależnych, 
		zwanych obserwatorami i automatycznie powiadamia ich o wszelkich zmianach stanu, zwykle wywołując jedną z ich metod.
		Zapewnia schludny i dobrze przetestowany projekt dla aplikacji, w których wiele obiektów jest zależnych od stanu jednego obiektu.

	c. Startegia
		Wzorzec strategii to wzorzec projektowy, który pozwala zaimplementować rodziny algorytmów (strategii) do oddzielnych klas, 
		a następnie przełączać się z jednego algorytmu (strategii) na inny w czasie wykonywania. Korzystając z tego wzorca, programiści 
		mogą odizolować kod, wewnętrzną logikę i zależności różnych algorytmów od reszty kodu aplikacji, co sprawia, 
		że ​​kod jest łatwy w utrzymaniu i skalowaniu. Ten wzorzec pozwala również zmieniać zachowanie aplikacji w czasie wykonywania, 
		przełączając się z jednego algorytmu na inny.
		Wzorzec strategii pomaga w tworzeniu wydajnego, bardziej czytelnego i łatwego w utrzymaniu oprogramowania. 
		Pozwala na tworzenie oprogramowania z komponentami wielokrotnego użytku i wymiennymi, które mogą być dynamicznie dodawane/zamieniane 
		w czasie wykonywania. 

	d. Metoda Wytwórcza
		Metoda wytworcza to wzorzec projektowy, który rozwiązuje problem tworzenia obiektu bez ujawniania klientowi logiki tworzenia.
		Definiuje ona metodę, która ma służyć tworzeniu obiektów bez bezpośredniego wywoływania konstruktora (poprzez operator new). 
		Podklasy mogą nadpisać tę metodę w celu zmiany klasy tworzonych obiektów.

	e. Dekorator
		Wzorzec dekoratora to strukturalny wzorzec projektowy używany do dynamicznego dodawania zachowania do klasy bez zmiany klasy. 
		Można użyć wielu dekoratorów, aby rozszerzyć funkcjonalność klasy, podczas gdy każdy dekorator koncentruje się na jednym zadaniu, 
		promując separacje problemów. Klasy dekoratorów umożliwiają dynamiczne dodawanie funkcjonalności bez zmiany klasy, 
		z poszanowaniem zasady open-closed.
		Wzorzec dekoratora powinien być używany do rozszerzania klas bez ich zmiany. Przeważnie ten wzorzec jest używany do przekrojowych 
		problemów, takich jak rejestrowanie lub buforowanie. Innym przypadkiem użycia jest modyfikacja danych wysyłanych do lub z komponentu.
		Używany np. podczas tworzenia modelu danych - tabeli w bazie danych.
