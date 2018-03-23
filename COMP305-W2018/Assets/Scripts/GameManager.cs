using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject[] Pickups;

    public int TotalTime;
    public int TotalPickups;

    public float XMin;
    public float XMax;
    public float YMin;
    public float YMax;

    private GameObject _gemPickupText;
    private GameObject _coinPickupText;
    private GameObject _bananaPickipText;
    private Text _timeText;

    private static int _totalGems;
    private static int _totalCoins;
    private static int _totalBananas;
    private float _timer;
    private static bool _gameOver;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
            DestroyImmediate(gameObject);

        _gameOver = false;
        _timer = TotalTime;
        InstantiatePickups(TotalPickups);
    }

    private void DisplayResults()
    {
        if (!_gemPickupText)
            _gemPickupText = GameObject.Find("GemText");
        else
            _gemPickupText.GetComponent<Text>().text = "" + _totalGems;
        if (!_coinPickupText) _coinPickupText = GameObject.Find("CoinText");
        else
            _coinPickupText.GetComponent<Text>().text = "" + _totalCoins;
        if (!_bananaPickipText)
            _bananaPickipText = GameObject.Find("BananaText");
        else
            _bananaPickipText.GetComponent<Text>().text = "" + _totalBananas;
    }

    private void Update()
    {
        if (!_gameOver)
        {
            if (!_timeText)
                _timeText = GameObject.Find("TimeText").GetComponent<Text>();
            _timer -= Time.deltaTime;
            _timeText.text = "Time: " + (int) _timer;
        }

        if ((!(_timer <= 0))) return;
        if (!_gameOver)
        {
            SceneManager.LoadScene("Lab5-b");
            _gameOver = true;
        }

        DisplayResults();
    }

    private void InstantiatePickups(int totalPickups)
    {
        for (var i = 0; i < totalPickups; i++)
        {
            Instantiate(Pickups[Random.Range(0, 3)],
                new Vector3(Random.Range(XMin, XMax),
                    Random.Range(YMin, YMax),
                    -1),
                Quaternion.identity);
        }
    }

    public static void RegisterFood(string gameobject)
    {
        switch (gameobject)
        {
            case "Gem":
                _totalGems++;
                break;
            case "Banana":
                _totalBananas++;
                break;
            case "Coin":
                _totalCoins++;
                break;
            default:
                break;
        }
    }

    public void ResetGame()
    {
        _totalGems = 0;
        _totalBananas = 0;
        _totalCoins = 0;
        _timer = TotalTime;
    }
}