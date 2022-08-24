using UnityEngine;

public class GameStats : MonoBehaviour
{
    private static GameStats _instance;
    public static GameStats Instance { get { return _instance; } }

    static Stats stats;

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
    public static void AddPoint() { stats.points++; }

    public static int GetHealth => stats.health;
    public static void RemoveHealth() { stats.health--; }
}

class Stats
{
    public int health = 3;
    public int points = 0;
}