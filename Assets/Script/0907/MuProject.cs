using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class MuProject : MonoBehaviour
{
    public Text textNum;
    public List<string> numList = new List<string>();

    public void Click1()
    {
        numList.Add("1");
        textNum.text = string.Join("", numList.ToArray());
        Debug.Log(string.Join("",numList.ToArray()));
    }
    public void Click2()
    {
        numList.Add("2");
        textNum.text = string.Join("", numList.ToArray());
        Debug.Log(string.Join("", numList.ToArray()));
    }
    public void Click3()
    {
        numList.Add("3");
        textNum.text = string.Join("", numList.ToArray());
        Debug.Log(string.Join("", numList.ToArray()));
    }
    void Start()
    {
        textNum.text = "";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)&& numList[0] == "1")
        {
            numList.RemoveAt(0);
            textNum.text = string.Join("", numList.ToArray());
            Debug.Log("1번키 누름");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && numList[0] == "2")
        {
            numList.RemoveAt(0);
            textNum.text = string.Join("", numList.ToArray());
            Debug.Log("2번키 누름");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && numList[0] == "3")
        {
            numList.RemoveAt(0);
            textNum.text = string.Join("", numList.ToArray());
            Debug.Log("3번키 누름");
        }
    }
}
