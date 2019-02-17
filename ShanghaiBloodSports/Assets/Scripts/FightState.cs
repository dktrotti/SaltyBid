using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightState : MonoBehaviour
{
    public int p1Score;
    public int p2Score;

    public string fightSceneName;
    public string shopSceneName;
    private Scene fightScene;
    private Scene shopScene;
    public FightScene fightComponent;
    private ShopScene shopComponent;

    private readonly int roundsToWin = 5;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        gameObject.tag = "FightState";

        SceneManager.LoadScene(shopSceneName, LoadSceneMode.Additive);
        shopScene = SceneManager.GetSceneByName(shopSceneName);
        fightScene = SceneManager.GetSceneByName(fightSceneName);

        p1Score = 0;
        p2Score = 0;
    }

    public void SetShopComponent(ShopScene component)
    {
        shopComponent = component;
    }

    // these two functions are very legal and very cool
    public void IncrementP1Score()
    {
        p1Score++;
        if (CheckWin())
        {
            OnGameEnd();
        }
        else
        {
            // do other stuff that matters to the shop probably
            // then
            OnRoundEnd();
        }
    }

    public void IncrementP2Score()
    {
        p2Score++;
        if (CheckWin())
        {
            OnGameEnd();
        }
        else
        {
            // do other stuff that matters to the shop probably
            // then
            OnRoundEnd();
        }
    }

    bool CheckWin()
    {
        return p1Score == roundsToWin || p2Score == roundsToWin;
    }

    void OnRoundEnd()
    {
        SceneManager.SetActiveScene(shopScene);
        shopComponent.Restock();
        shopComponent.Show();
    }

    public void OnShopEnd()
    {
        SceneManager.SetActiveScene(fightScene);
        fightComponent.Fight();
    }

    void OnGameEnd()
    {
        // end game
        SceneManager.LoadScene("MainMenu");
        Destroy(this.gameObject);
    }
}
