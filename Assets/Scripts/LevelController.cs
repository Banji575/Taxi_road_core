using System;
using UnityEngine;
using static GameManager;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;
    private int CarsInLevel;
    public Level currentLevel = null;

    public event EventHandler OnLevelEnd;

    private void Awake()
    {
        Instance = this;

    }

    private void Start()
    {
        NextLevel();
       /* GameManager.Instance.OnStartNextLevel += GameManager_OnStartNextLevel;
        GameManager.Instance.NextLevel();*/
    }

/*    private void GameManager_OnStartNextLevel(object sender, GameManager.OnStartNextLevelEventArgs e)
    {
        Debug.Log("On start new level");

        if (currentLevel)
        {
            Destroy(currentLevel.gameObject);
            Debug.Log("destroy level");
            currentLevel = null;
        }
        currentLevel = e.level;
        CarsInLevel = currentLevel.CarCount;
        Debug.Log("level controller on start new level" + CarsInLevel.ToString());
    }*/

    public void EscapeCar()
    {
        CarsInLevel--;

        if(CarsInLevel <= 0)
        {
/*            OnLevelEnd?.Invoke(this, EventArgs.Empty);*/
            GameManager.Instance.NextLevel();
            NextLevel();
        }

    }

    public void NextLevel()
    {
        if (currentLevel)
        {
            Destroy(currentLevel.gameObject);
        }
        GameData globalContext = GameManager.Instance.globalContext;
        int levelCount = globalContext.setLevel;
        Debug.Log("level count " +  levelCount.ToString());
        Debug.Log(globalContext.playerStoreBalance.offers[levelCount].levelPrefab.ToString());
        GameObject levelGO = Instantiate(globalContext.playerStoreBalance.offers[levelCount].levelPrefab.gameObject, null);
        currentLevel = levelGO.GetComponent<Level>();
    }

/*    public void NextLevel(int levelCount)
    {
        if (currentLevel)
        {
            Destroy(currentLevel);
        }
        currentLevel = Instantiate(GameManager.Instance.globalContext.levelBalance.offers[levelCount].levelPrefab, null);
    }*/

}
