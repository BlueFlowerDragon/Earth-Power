using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public bool Controlled;
    public int Amount;
    public int place;
    public GameObject[] Box;
    public GameObject ChangeKey;
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
        if (Input.GetKeyDown(GameManager.GM.Down))
        {
            place++;
            if (place >= Amount)
            {
                place = Amount - 1;
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
                    Debug.Log("修改上");
                    ChangeKey.GetComponent<KeyEdit>().EditMode(0);
                    break;
                case 1:
                    Debug.Log("修改下");
                    ChangeKey.GetComponent<KeyEdit>().EditMode(1);
                    break;
                case 2:
                    Debug.Log("修改左");
                    ChangeKey.GetComponent<KeyEdit>().EditMode(2);
                    break;
                case 3:
                    Debug.Log("修改右");
                    ChangeKey.GetComponent<KeyEdit>().EditMode(3);
                    break;
                case 4:
                    Debug.Log("修改攻擊");
                    ChangeKey.GetComponent<KeyEdit>().EditMode(4);
                    break;
                case 5:
                    Debug.Log("修改跳");
                    ChangeKey.GetComponent<KeyEdit>().EditMode(5);
                    break;
                case 6:
                    Debug.Log("返回");
                    SceneManager.LoadScene(0);
                    break;
            }
        }
    }
}
