using UnityEngine;

public class GameStats : MonoBehaviour
{
    private static GameStats _instance;
    public static GameStats Instance { get { return _instance; } }

    static Stats stats;

    #region Events
    public delegate void OnPointsChanged(int amount);
    public static event OnPointsChanged OnPointsChangedEvent;

    public delegate void OnHealthChanged(int amount);
    public static event OnHealthChanged OnHealthChangedEvent;
    #endregion

    void Awake()
    {
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        if (stats == null) { stats = new Stats(); }
    }

    //Getters & 'Setters'
    public static int GetPoints => stats.points;
    public static void AddPoint() { stats.points++; OnPointsChangedEvent.Invoke(stats.points); }

    public static int GetHealth => stats.health;
    public static void RemoveHealth() { stats.health--; OnHealthChangedEvent.Invoke(stats.health); }


    public static void ResetGameStats()
    {
        stats.health = 3;
        stats.points = 0;

        OnPointsChangedEvent.Invoke(stats.points);
    }
}

class Stats
{
    public int health = 3;
    public int points = 0;
}