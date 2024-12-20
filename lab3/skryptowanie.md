# Skryptowanie w Unity


# Skryptowanie w Unity

## Wybór IDE

- Visual Studio 2022 + Resharper
- Rider
- Mono Develop
- Visual Studio Code + wtyczki

## Serializacja

W Unity, serializacja polega na konwersji obiektów i ich stanów na
format, który może być zapisany i później odtworzony. To kluczowy
element, umożliwiający pracę z edytorem Unity i systemem zapisu. Dla
klas dziedziczących po `MonoBehaviour`, mechanizm serializacji Unity ma
kilka szczególnych cech i najlepszych praktyk, zwłaszcza w kontekście
pól zmiennych w tych klasach.

<https://docs.unity3d.com/ScriptReference/SerializeField.html>

## Dostępność Pól: Publiczne vs Prywatne z \[SerializeField\]

- **Pola Publiczne**: Tradycyjnie, pola publiczne są automatycznie
  serializowane przez Unity. Oznacza to, że ich wartości są
  automatycznie zachowywane przez edytor Unity i są widoczne w
  inspektorze. Jest to prosta metoda na szybkie dodawanie możliwości
  serializacji, ale jest uważana za złą praktykę z punktu widzenia
  bezpieczeństwa i organizacji kodu, ponieważ eksponuje zmienne klasy na
  zewnątrz bez żadnej kontroli dostępu.

- **Prywatne Pola z \[SerializeField\]**: Unity pozwala także na
  serializację prywatnych pól za pomocą adnotacji `[SerializeField]`.
  Jest to zalecana praktyka, ponieważ pozwala zachować hermetyzację i
  bezpieczeństwo klasy, umożliwiając jednocześnie serializację i edycję
  wartości pola przez inspektor Unity. Używanie `[SerializeField]`
  pozwala na utrzymanie pola jako prywatnego (co jest zgodne z dobrymi
  praktykami programowania obiektowego), jednocześnie czyniąc pole
  edytowalnym w inspektorze Unity bez potrzeby pisania dodatkowych metod
  dostępowych.

## Różnice

1.  **Widoczność w Inspektorze**: Pola publiczne są domyślnie widoczne w
    inspektorze Unity, podczas gdy prywatne pola są domyślnie ukryte.
    Adnotacja `[SerializeField]` pozwala na wyświetlenie i edycję
    prywatnych pól w inspektorze.

2.  **Zabezpieczenie Dostępu**: Publiczne pola są dostępne z zewnątrz
    klasy, co może prowadzić do niepożądanych zmian stanu obiektu.
    Prywatne pola z adnotacją `[SerializeField]` są chronione przed
    dostępem z zewnątrz klasy, co poprawia bezpieczeństwo i integralność
    obiektu.

3.  **Dobre Praktyki Programowania**: Użycie prywatnych pól z adnotacją
    `[SerializeField]` jest zgodne z zasadami enkapsulacji w
    programowaniu obiektowym, zachowując hermetyzację i minimalizując
    ryzyko błędów.

## Atrybuty

<https://docs.unity3d.com/Manual/Attributes.html>

## 

1.  **Atrybuty inspektora**:
    - `[SerializeField]`: Prywatne pole w skrypcie może być widoczne w
      inspektorze, ale bez udostępniania jego dostępu innym skryptom.
    - `[HideInInspector]`: Ukrywa publiczne pole w inspektorze.
    - `[Range(min, max)]`: Umożliwia ustawienie wartości pola za pomocą
      suwaka w zakresie od `min` do `max`.
    - `[Tooltip("Opis")]`: Dodaje wskazówkę, która pojawia się, gdy
      najedziesz kursorem na pole w inspektorze.
    - `[Multiline]`: Umożliwia wprowadzanie wielolinijkowego tekstu w
      inspektorze.
    - `[TextArea]`: Tworzy obszar tekstowy w inspektorze.

------------------------------------------------------------------------

2.  **Atrybuty dotyczące wykonania**:
    - `[ContextMenu("Nazwa opcji")]`: Dodaje opcję do menu kontekstowego
      w inspektorze, która, gdy jest wybrana, uruchamia określoną
      metodę.
    - `[ContextMenuItem("Nazwa opcji", "NazwaMetody")]`: Dodaje element
      do menu kontekstowego dla konkretnego pola.
    - `[ExecuteInEditMode]`: Skrypt z tym atrybutem zostanie wykonany w
      Edytorze Unity, nawet jeśli gra nie jest w trybie odtwarzania.
    - `[InitializeOnLoad]`: Klasa z tym atrybutem jest inicjalizowana,
      gdy Unity jest startowane.

------------------------------------------------------------------------

3.  **Atrybuty dotyczące właściwości komponentów**:
    - `[RequireComponent(typeof(Komponent))]`: Wymusza, aby obiekt gry
      miał określony komponent przed dodaniem tego skryptu.
    - `[DisallowMultipleComponent]`: Zapobiega dodaniu wielu instancji
      tego samego skryptu do jednego obiektu gry.

------------------------------------------------------------------------

4.  **Atrybuty dotyczące edytora**:
    - `[CustomEditor(typeof(Typ))]`: Definiuje niestandardowy edytor dla
      określonego typu.
    - `[CanEditMultipleObjects]`: Pozwala na edycję wielu obiektów
      jednocześnie w niestandardowym edytorze.

## Cykl życia funkcji

<https://docs.unity3d.com/Manual/ExecutionOrder.html>

------------------------------------------------------------------------

Cykl życia funkcji w Unity określa kolejność, w jakiej metody (lub
“funkcje”, używając terminologii Unity) są wywoływane przez silnik gry w
różnych fazach działania aplikacji. Zrozumienie tego cyklu jest kluczowe
dla efektywnego programowania zachowań obiektów w Unity. Dokumentacja
Unity dostarcza szczegółowy opis kolejności wykonania tych metod, ale
poniżej znajdziesz uproszczone wyjaśnienie głównych etapów cyklu życia:

## Inicjalizacja

- **Awake()**: Wywoływana, gdy skrypt zostanie załadowany. Używana do
  inicjalizacji zmiennych lub stanów gry przed rozpoczęciem gry. `Awake`
  jest wywoływana tylko raz podczas życia skryptu.
- **OnEnable()**: Wywoływana za każdym razem, gdy obiekt staje się
  aktywny. Jest to miejsce na wszelkie inicjalizacje lub rejestracje w
  menedżerach zdarzeń, które powinny odbywać się każdorazowo, gdy obiekt
  jest aktywowany.

## Start Fazy

- **Start()**: Wywoływana przed pierwszym uaktualnieniem ramki, ale po
  `Awake`. Używana do inicjalizacji, która zależy od innych obiektów w
  scenie. Podobnie jak `Awake`, wywoływana jest tylko raz.

## Pętla Gry

- **FixedUpdate()**: Wywoływana w regularnych odstępach czasu. Używana
  głównie do aktualizacji związanych z fizyką. Częstotliwość wywołań
  `FixedUpdate` jest stała, niezależna od klatek na sekundę (FPS).
- **Update()**: Główna pętla gry. Wywoływana co klatkę i służy do
  większości aktualizacji niezwiązanych z fizyką, takich jak odbieranie
  wejścia od użytkownika.
- **LateUpdate()**: Wywoływana co klatkę, ale po `Update`. Używana do
  aktualizacji, które muszą być wykonane po wszystkich innych
  aktualizacjach w ramce, np. do kamer śledzących obiekty.

------------------------------------------------------------------------

<https://docs.unity3d.com/ScriptReference/MonoBehaviour.FixedUpdate.html>

Opcjonalnie ustawienie:

- w kodzie `Application.targetFrameRate = 25;`
- w edytorze `Edit > Settings > Time > Fixed Timestep`

## Renderowanie

- **OnPreRender()**: Wywoływana przed renderowaniem każdej klatki.
  Miejsce na przygotowanie danych przed renderowaniem sceny.
- **OnRenderObject()**: Wywoływana, gdy obiekt jest gotowy do
  renderowania. Używana do niestandardowych efektów renderowania.
- **OnPostRender()**: Wywoływana po zrenderowaniu wszystkich obiektów.
  Służy do operacji po-renderowaniu, np. efektów posrenderowanych.

## Wyłączanie

- **OnDisable()**: Wywoływana, gdy obiekt staje się nieaktywny. To
  miejsce na sprzątanie, np. odrejestrowywanie z menedżerów zdarzeń.
- **OnDestroy()**: Wywoływana, gdy obiekt jest niszczony. Używana do
  ostatecznego sprzątania, np. zwalniania zasobów.

## Specjalne Metody i Zdarzenia

Unity oferuje również szereg specjalnych metod i zdarzeń, takich jak
obsługa kolizji (`OnCollisionEnter`, `OnCollisionExit`), obsługa
triggerów (`OnTriggerEnter`, `OnTriggerExit`), oraz inne metody
specyficzne dla różnych aspektów gry i interakcji z silnikiem.

## Struktury a klasy w Unity

W Unity, zarówno klasy (`class`) jak i struktury (`struct`) są
wykorzystywane do modelowania danych i zachowań, ale mają kluczowe
różnice wynikające z ich natury w języku C#. Rozumienie tych różnic jest
ważne przy projektowaniu i implementacji twoich systemów w Unity,
zwłaszcza że dotyczą one zarządzania pamięcią, wydajności i semantyki.

## Klasy

Klasy są typami referencyjnymi. Oznacza to, że gdy przypisujesz obiekt
klasy do zmiennej, ta zmienna przechowuje referencję do miejsca w
pamięci, gdzie obiekt jest przechowywany. Jeśli przekażesz obiekt klasy
do funkcji lub przypiszesz go do innej zmiennej, obie zmienne będą
wskazywać na ten sam obiekt w pamięci. Zmiany dokonane na obiekcie
poprzez jedną zmienną będą widoczne również dla innej zmiennej. Klasy w
Unity są powszechnie używane do tworzenia skryptów zachowań
(`MonoBehaviour` i pochodnych) oraz do definicji bardziej złożonych
struktur danych, które wymagają funkcjonalności takich jak
dziedziczenie.

## Struktury

Struktury są typami wartościowymi. Gdy przypisujesz strukturę do
zmiennej, zmienna ta przechowuje bezpośrednio wartość. Oznacza to, że
przekazując strukturę do funkcji lub przypisując ją do innej zmiennej,
tworzona jest jej kopia. Zmiany dokonane na kopii nie wpłyną na
oryginał. Struktury są używane w Unity do reprezentowania mniejszych i
prostszych zestawów danych, takich jak współrzędne (`Vector3`), obrót
(`Quaternion`) i kolor (`Color`), gdzie kopiowanie wartości zamiast
tworzenia referencji jest bardziej wydajne z punktu widzenia zarządzania
pamięcią i wydajności.

## Podstawowe Różnice

- **Typ przechowywania**: Klasy są przechowywane w stercie (heap), a
  struktury na stosie (stack) lub w miejscu, gdy są częścią innej
  struktury/klasy.
- **Wydajność**: Dostęp do danych i ich modyfikacja może być szybsza dla
  struktur ze względu na ich przechowywanie na stosie, szczególnie dla
  małych i często używanych danych. Jednak nieodpowiednie używanie
  struktur, zwłaszcza dużych, może prowadzić do nadmiernego kopiowania i
  obniżenia wydajności.
- **Dziedziczenie**: Klasy mogą dziedziczyć po innych klasach,
  pozwalając na rozbudowane hierarchie obiektów. Struktury nie mogą
  dziedziczyć i zawsze są dziedziczone po `System.ValueType`.
- **Semantyka**: Użycie typów referencyjnych (klas) jest zalecane, gdy
  potrzebujesz, aby dwa obiekty wskazywały na tę samą instancję danych.
  Struktury są preferowane, gdy chcesz, aby obiekty były niezależne i
  miały własne kopie danych.
