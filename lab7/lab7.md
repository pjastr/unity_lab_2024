# Laboratorium \#7


# Dokończenie + `ScriptableObject` + `PlayerPrefs`

Dodatkowe info:

- wykład
- https://docs.unity3d.com/Manual/class-ScriptableObject.html
- https://docs.unity3d.com/ScriptReference/PlayerPrefs.html

## Ćw.1. - Nawigacja do kolejnych scen (dokończenie)

Dodaj do projektu z poprzedniego labu nawigację do kolejnych scen.
Upewnij się, że sceny są ujęte w Build Setting.

``` csharp
// Metoda do ładowania sceny o nazwie
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Metoda do ładowania sceny po jej indeksie
    public void LoadSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
```

## Ćw.2. Wyjście (dokończenie)

Dodaj obsługę wyjścia z aplikacji za pomocą `Application.Quit()`.

## Ćw.3. Mini-projekt (dokończenie)

Zaimplementuj mały projekt testując komponenty UI na bazie przykładowego
GameFlow:

![](images/f11.png) \## Ćw.4.

Zmodyfikuj Player Settings:

![](images/g1.png)

## Ćw.4.

Dodaj własną klasę dziedziczącą po ScriptableObject i co najmniej jedną
instancję. Możesz wykorzystać przykładowe kody z wykładu:

``` csharp
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "Player Data")]
public class PlayerData : ScriptableObject
{
    public string playerName;
    public int playerScore;
    public int playerHealth;

    // Dodaj dodatkowe pola w zależności od potrzeb
}
```

``` csharp
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerData playerData; // Przypisz `PlayerDataInstance` przez Inspektor w Unity

    private void Start()
    {
        Debug.Log("Player Name: " + playerData.playerName);
        Debug.Log("Player Score: " + playerData.playerScore);
        Debug.Log("Player Health: " + playerData.playerHealth);
    }

    // Przykładowa funkcja modyfikująca dane
    public void IncreaseScore(int amount)
    {
        playerData.playerScore += amount;
        Debug.Log("Nowy wynik gracza: " + playerData.playerScore);
    }
}
```

## Ćw.5.

Zaimplementuj w dowolny sposób przekazywanie instancji między scenami.

## Ćw.6.

Rozszerz projekt o użycie `PlayerPrefs`. Przykładowe kody z wykładu:

``` csharp
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "Player Data")]
public class PlayerData : ScriptableObject
{
    public string playerName;
    public int playerScore;
    public int playerHealth;

    // Klucze do przechowywania danych w PlayerPrefs
    private const string PlayerNameKey = "PlayerName";
    private const string PlayerScoreKey = "PlayerScore";
    private const string PlayerHealthKey = "PlayerHealth";

    // Funkcja do załadowania danych z PlayerPrefs
    public void LoadData()
    {
        playerName = PlayerPrefs.GetString(PlayerNameKey, "DefaultName");
        playerScore = PlayerPrefs.GetInt(PlayerScoreKey, 0);
        playerHealth = PlayerPrefs.GetInt(PlayerHealthKey, 100);
    }

    // Funkcja do zapisania danych do PlayerPrefs
    public void SaveData()
    {
        PlayerPrefs.SetString(PlayerNameKey, playerName);
        PlayerPrefs.SetInt(PlayerScoreKey, playerScore);
        PlayerPrefs.SetInt(PlayerHealthKey, playerHealth);
        PlayerPrefs.Save(); // Zapisz wszystkie zmiany w PlayerPrefs
    }
}
```

``` csharp
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerData playerData; // Przypisz `PlayerDataInstance` przez Inspektor w Unity

    private void Start()
    {
        // Ładowanie danych na starcie
        playerData.LoadData();
        Debug.Log("Player Name: " + playerData.playerName);
        Debug.Log("Player Score: " + playerData.playerScore);
        Debug.Log("Player Health: " + playerData.playerHealth);
    }

    private void OnApplicationQuit()
    {
        // Zapisz dane przy zamykaniu aplikacji
        playerData.SaveData();
    }

    private void OnDestroy()
    {
        // Zapisz dane przy niszczeniu obiektu (np. zmiana sceny)
        playerData.SaveData();
    }

    // Przykładowa funkcja modyfikująca dane
    public void IncreaseScore(int amount)
    {
        playerData.playerScore += amount;
        Debug.Log("Nowy wynik gracza: " + playerData.playerScore);
    }
}
```

## Ćw.7.

Dodaj obsługę JSON dla `PlayerPrefs`. Przykładowo:

``` csharp
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "Player Data")]
public class PlayerData : ScriptableObject
{
    public string playerName;
    public int playerScore;
    public int playerHealth;

    // Klucz do przechowywania danych w PlayerPrefs w formacie JSON
    private const string PlayerDataKey = "PlayerData";

    // Funkcja do załadowania danych z PlayerPrefs jako JSON
    public void LoadData()
    {
        if (PlayerPrefs.HasKey(PlayerDataKey))
        {
            string jsonData = PlayerPrefs.GetString(PlayerDataKey);
            JsonUtility.FromJsonOverwrite(jsonData, this);
        }
        else
        {
            // Ustaw domyślne wartości, jeśli dane nie istnieją
            playerName = "DefaultName";
            playerScore = 0;
            playerHealth = 100;
        }
    }

    // Funkcja do zapisania danych do PlayerPrefs jako JSON
    public void SaveData()
    {
        string jsonData = JsonUtility.ToJson(this);
        PlayerPrefs.SetString(PlayerDataKey, jsonData);
        PlayerPrefs.Save(); // Zapisz wszystkie zmiany w PlayerPrefs
    }
}
```

## Zadanie dodatkowe (1pkt)

Przerabiając niego kody z wykładu dodaj do projektu zastosowania
`ScriptableObject` i `PlayerPrefs`. Możesz przechowywać dane graczy, ale
możesz dodać inne niestandardowe elementy.

Opcjonalnie rzeczy dodatkowe:

- jak zrobić skrytpty zgodnie z hermetyzają (pola prywatne)?
- wykorzystanie innych metod z PlayerPrefs
  https://docs.unity3d.com/ScriptReference/PlayerPrefs.html
- dodanie walidacji do pól np. punkty życia są liczbą całkowitą z
  przedziału $[0,100]$

``` csharp
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    private string playerName; // Pole prywatne dla imienia

    [SerializeField, Range(0, 100)]
    private int health = 100; // Pole prywatne dla zdrowia z zakresem [0, 100]

    // Publiczna właściwość do odczytu i zapisu nazwy
    public string Name
    {
        get => playerName;
        set => playerName = value;
    }

    // Publiczna właściwość do odczytu i zapisu zdrowia z walidacją
    public int Health
    {
        get => health;
        set => health = Mathf.Clamp(value, 0, 100); // Gwarantuje zakres [0, 100]
    }
}
```
