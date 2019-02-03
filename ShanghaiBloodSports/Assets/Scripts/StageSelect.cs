using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    public GameObject characterSelect;
    public string fightSceneName;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            characterSelect.SetActive(true);
            gameObject.SetActive(false);
        }

        if (Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene(fightSceneName);
        }
    }
}
