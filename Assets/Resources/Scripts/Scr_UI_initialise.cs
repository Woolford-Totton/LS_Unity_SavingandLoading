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

    private string FileName = "YourList.sav";

    private string FilePath = "Assets/Resources/Saves/";

    private int Adjust_ASCII_Amount = 10;

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
        /*
            Get Data to Save
         */

        string list_text = "My Saved List:";

        for (var i = 0; i < UIList_Count; i++)
        {
            list_text += "\n" + UI_List[i];
        }

        /*
            Encrypt our data
         */

        EncryptSave(ref list_text);               

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
            currentitem += Savedata.ReadLine();


        }

        Savedata.Close();

        DecryptSave(ref currentitem);

        char[] ReadableSavedata = currentitem.ToCharArray();

       
        list_text = new string(ReadableSavedata);

        currentitem = "";
        var recordnextitem = false;
        var countdown_to_next_item = 0;

        for (var i = 0; i < ReadableSavedata.Length; i++)
        {
            if (recordnextitem == true)
            {
                recordnextitem = false;

                currentitem = ReadableSavedata[i].ToString();

                UI_List.Add(currentitem);

                UIList_Count += 1;
            }
            if (ReadableSavedata[i] == System.Convert.ToChar("\n"))
            {
                recordnextitem = true;
                countdown_to_next_item = 2;                
            }
            
        }
        

        UpdateList();
    }
    
    void EncryptSave(ref string SaveData)
    {
        char[] encryptdata = SaveData.ToCharArray();



        for (var i = 0; i < encryptdata.Length; i++)
        {
            encryptdata[i] = System.Convert.ToChar(encryptdata[i] + Adjust_ASCII_Amount);


        }
        SaveData= new string(encryptdata);
    }

    void DecryptSave(ref string SaveData)
    {
        char[] decryptdata = SaveData.ToCharArray();

        for (var i = 0; i < decryptdata.Length; i++)
        {
            decryptdata[i] = System.Convert.ToChar(decryptdata[i] - Adjust_ASCII_Amount);


        }
        SaveData = new string(decryptdata);
    }

}
