using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuList : MonoBehaviour
{
    public bool Controlled;
    public int Amount;
    public int place;
    public GameObject[] Box;
    // Start is called before the first frame update
    void Start()
    {
        place = 0;
        Box = GameObject.FindGameObjectsWithTag("MenuBox");
        for (int i = 0; i < Box.Length; i++)
        {
            if (i == place)
            {
                Box[i].GetComponent<ListLight>().targeted = true;
            }
            else
            {
                Box[i].GetComponent<ListLight>().targeted = false;
            }
            Box[i].GetComponent<ListLight>().Refresh();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(GameManager.GM.Up))
        {
            place--;
            if (place < 0)
            {
                place = 0;
            }
            for (int i = 0; i < Box.Length; i++)
            {
                if(i== place)
                {
                    Box[i].GetComponent<ListLight>().targeted= true;
                }
                else
                {
                    Box[i].GetComponent<ListLight>().targeted = false;
                }
                Box[i].GetComponent<ListLight>().Refresh();
            }
        }
        if (Input.GetKeyDown(GameManager.GM.Down))
        {
            place++;
            if (place >= Amount)
            {
                place = Amount -1 ;
            }
            for (int i = 0; i < Box.Length; i++)
            {
                if (i == place)
                {
                    Box[i].GetComponent<ListLight>().targeted = true;
                }
                else
                {
                    Box[i].GetComponent<ListLight>().targeted = false;
                }
                Box[i].GetComponent<ListLight>().Refresh();
            }
        }

        if (Input.GetKeyDown(GameManager.GM.Jump))
        {
            switch (place)
            {
                case 0:
                    Debug.Log("開始遊戲");
                    break;
                case 1:
                    Debug.Log("讀取遊戲");
                    break;
                case 2:
                    Debug.Log("設定");
                    SceneManager.LoadScene(1);
                    break;
                case 3:
                    Application.Quit();
                    break;
            }
        }
    }
}
