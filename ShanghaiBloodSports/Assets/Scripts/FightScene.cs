using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightScene : MonoBehaviour
{
    public GameObject fightStateObject;
    private FightState fightState;

    // Start is called before the first frame update
    void Start()
    {
        // fightState = fightStateObject.GetComponent<FightState>();
        fightState = GameObject.FindWithTag("FightState").GetComponent<FightState>();
    }

    // Update is called once per frame
    void Update()
    {
        // debug to step through scenes
        if (Input.GetButtonDown("Fire3"))
        {
            gameObject.SetActive(false);
            OnP1RoundWin();
        }
    }

    public void Fight()
    {
        gameObject.SetActive(true);
    }

    void OnP1RoundWin()
    {
        fightState.IncrementP1Score();
    }

    void OnP2RoundWin()
    {
        fightState.IncrementP2Score();
    }
}
