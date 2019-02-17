using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject stageSelect;

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
            mainMenu.SetActive(true);
            gameObject.SetActive(false);
        }

        if (Input.GetButtonDown("Submit"))
        {
            stageSelect.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
