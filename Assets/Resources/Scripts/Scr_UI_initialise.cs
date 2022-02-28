using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

using System.IO;



public class Scr_UI_initialise : MonoBehaviour
{
    public GameObject List;

    private List<string> UI_List = new List<string>();


    private int UIList_Count=0;

    public int UIList_MaxCount=10;

    private string FileName = "YourList.txt";

    private string FilePath = "Assets/Resources/Saves/";

    // Start is called before the first frame update
    void Start()
    {  
        if (System.IO.File.Exists(FilePath+FileName))
        {
            LoadList();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    
    }
    
    void UpdateList()
    {
        var btn_save_btn_text = List.GetComponent<Text>();

        var list_text = "My Saved List:";

        for (var i = 0; i < UIList_Count; i++)
        {
            list_text += "\n" + UI_List[i] ;
        }

        btn_save_btn_text.text = list_text;
    }

    public void SubtractItem()
    {
        if (UIList_Count > 0)
        {
            UI_List.RemoveAt(UIList_Count-1);

            UIList_Count -= 1;

            UpdateList();
        }
    }
    public void AddItem()
    {
        if (UIList_Count < UIList_MaxCount)
        {

            UI_List.Add(UIList_Count.ToString());

            UIList_Count += 1;

            UpdateList();

        }
    }
    public void Savegame()
    {
        var list_text = "My Saved List:";

        for (var i = 0; i < UIList_Count; i++)
        {
            list_text += "\n" + UI_List[i];
        }

        StreamWriter Savedata = new StreamWriter(FilePath+FileName);

        Savedata.Write(list_text);

        Savedata.Close();


    }
    void LoadList()
    {
        var list_text = "My Saved List:";

        var currentitem = "";

        StreamReader Savedata = new StreamReader(FilePath + FileName);

        currentitem = Savedata.ReadLine();

        while (Savedata.EndOfStream == false)
        {
            currentitem = Savedata.ReadLine();

            list_text += "\n" + currentitem;


            UI_List.Add(currentitem);

            UIList_Count += 1;
        }

        Savedata.Close();

        UpdateList();
    }
    void EncryptSave()
    { 
        
    }

    void DecryptSave()
    { 
    
    }

}
