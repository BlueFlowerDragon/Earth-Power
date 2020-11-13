using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyEdit : MonoBehaviour
{
    public GameObject self;

    Event keyEvent;
    KeyCode newKey;
    bool waitingForKey;
    // Start is called before the first frame update
    void Start()
    {
        waitingForKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnGUI()

    {
        keyEvent = Event.current;


        if (keyEvent.isKey && waitingForKey)

        {
            newKey = keyEvent.keyCode; //Assigns newKey to the key user presses
            Debug.Log("抓到newKey是:"+ newKey);
            waitingForKey = false;

        }

    }


    public void EditMode(int NO)
    {
        self.SetActive(true);
        switch (NO)
        {
            case 0:
                Debug.Log("進行編輯上");
                StartAssignment(0);
                break;
            case 1:
                Debug.Log("進行編輯下");
                break;
            case 2:
                Debug.Log("進行編輯左");
                break;
            case 3:
                Debug.Log("進行編輯右");
                break;
            case 4:
                Debug.Log("進行編輯攻擊");
                break;
            case 5:
                Debug.Log("進行編輯跳躍");
                break;
        }
    }

    public void StartAssignment(int NO)

    {
        Debug.Log("執行編輯的編號：" + NO);
        if (!waitingForKey)
        {
            Debug.Log("符合");
            StartCoroutine(AssignKey(NO));
        }

    }

    IEnumerator WaitForKey()

    {
        
        while (!keyEvent.isKey) { Debug.Log("未輸入案件"); }

            yield return null;

    }

    public IEnumerator AssignKey(int NO)

    {
        waitingForKey = true;
        Debug.Log("進入編輯中");


        yield return WaitForKey(); //Executes endlessly until user presses a key



        switch (NO)

        {

            case 0:
                Debug.Log("newKey是：" + newKey);
                GameManager.GM.Up = newKey; //Set forward to new keycode

                //PlayerPrefs.SetString("up", GameManager.GM.Up.ToString()); //save new key to PlayerPrefs
                PlayerPrefs.SetString("up", GameManager.GM.Up.ToString());
                Debug.Log("W以套用");
                self.SetActive(false);
                break;

        }



        yield return null;

    }
}
