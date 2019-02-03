using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopScene : MonoBehaviour
{
    public string fightSceneName;
    public Canvas canvas;
    
    private FightState fightState;

    // Start is called before the first frame update
    void Start()
    {
        fightState = GameObject.FindWithTag("FightState").GetComponent<FightState>();
        fightState.SetShopComponent(GetComponent<ShopScene>());
        
        foreach (Transform tf in canvas.transform)
        {
            tf.gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // debug to step through scenes
        if (Input.GetButtonDown("Fire3"))
        {
            OnShopComplete();
        }
    }

    public void Show()
    {
        foreach (Transform tf in canvas.transform)
        {
            tf.gameObject.SetActive(true);
        }
        gameObject.SetActive(true);
    }

    public void Restock()
    {

    }

    void OnShopComplete()
    {
        foreach (Transform tf in canvas.transform)
        {
            tf.gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
        fightState.OnShopEnd();
    }
}
