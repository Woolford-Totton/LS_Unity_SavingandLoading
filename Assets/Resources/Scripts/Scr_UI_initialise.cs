using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

using System.IO;

public class Scr_UI_initialise : MonoBehaviour
{
    private List<GameObject> UIButtons;

    private List<string> UI_List;

    private int UIButtons_Count;

    private int UIList_Count;

    private int UIList_MaxCount;

    private string FileName = "YourList.sav";

    private string FilePath = "Assets/Resources/Saves/";

    // Start is called before the first frame update
    void Start()
    {
        UI_List = new List<string>();
        UIList_Count = 0;
        UIList_MaxCount = 10;

        #region Initialise UI layout

        UIButtons = new List<GameObject>();
        UIButtons_Count = 0;

        // UIButtons[0] = new GameObject ();
        var prefabbutton = Resources.Load("Prefab/Btn_Empty");
        
        UIButtons.Add((GameObject)Instantiate(prefabbutton
            , new Vector3(0, 0, 0), Quaternion.identity));

        UIButtons[UIButtons_Count].transform.SetParent(transform);

        Button btn_save_btn = UIButtons[UIButtons_Count].GetComponent<Button>();

        Text btn_save_btn_text = btn_save_btn.GetComponentInChildren<Text>();

        btn_save_btn_text.text = "Save";

        RectTransform btn_save_transform = UIButtons[UIButtons_Count].GetComponent<RectTransform>();

        UIButtons[UIButtons_Count].transform.Translate(btn_save_transform.rect.width * 0.5f
            , (Screen.height * 1.0f) - btn_save_transform.rect.height * 0.5f, 0);

        btn_save_btn.onClick.AddListener(Savegame);

        UIButtons_Count += 1;

        prefabbutton = Resources.Load("Prefab/Btn_Empty");

        UIButtons.Add((GameObject)Instantiate(prefabbutton
            , new Vector3(0, 0, 0), Quaternion.identity));

        UIButtons[UIButtons_Count].transform.SetParent(transform);

        btn_save_btn = UIButtons[UIButtons_Count].GetComponent<Button>();

        btn_save_btn_text = btn_save_btn.GetComponentInChildren<Text>();

        btn_save_btn_text.text = "Add Item";

        btn_save_transform = UIButtons[UIButtons_Count].GetComponent<RectTransform>();



        UIButtons[UIButtons_Count].transform.position= new Vector3( UIButtons[UIButtons_Count-1].transform.position.x,
            UIButtons[UIButtons_Count-1].transform.position.y - btn_save_transform.rect.height * 1.0f, 0.0f);

        
        btn_save_btn.onClick.AddListener(AddItem);

        UIButtons_Count += 1;

        prefabbutton = Resources.Load("Prefab/Btn_Empty");

        UIButtons.Add((GameObject)Instantiate(prefabbutton
            , new Vector3(0, 0, 0), Quaternion.identity));

        UIButtons[UIButtons_Count].transform.SetParent(transform);

        btn_save_btn = UIButtons[UIButtons_Count].GetComponent<Button>();

        btn_save_btn_text = btn_save_btn.GetComponentInChildren<Text>();

        btn_save_btn_text.text = "Subtract Item";

        btn_save_transform = UIButtons[UIButtons_Count].GetComponent<RectTransform>();



        UIButtons[UIButtons_Count].transform.position = new Vector3(UIButtons[UIButtons_Count - 1].transform.position.x,
            UIButtons[UIButtons_Count - 1].transform.position.y - btn_save_transform.rect.height * 1.0f, 0.0f);


        btn_save_btn.onClick.AddListener(SubtractItem);

        UIButtons_Count += 1;

        prefabbutton = Resources.Load("Prefab/Label_Empty");

        UIButtons.Add((GameObject)Instantiate(prefabbutton
            , new Vector3(0, 0, 0), Quaternion.identity));

        UIButtons[UIButtons_Count].transform.SetParent(transform);

        btn_save_btn_text = UIButtons[UIButtons_Count].GetComponent<Text>();

        btn_save_btn_text.verticalOverflow = VerticalWrapMode.Overflow;

        var list_text = "My Saved List:";

        if (System.IO.File.Exists(FilePath+FileName))
        {
            var currentitem = "";

            StreamReader Savedata = new StreamReader(FilePath + FileName);

            currentitem = Savedata.ReadLine();

            while (Savedata.EndOfStream == false)
            {
                currentitem = Savedata.ReadLine();

                list_text +="\n" + currentitem;


                UI_List.Add(currentitem);

                UIList_Count += 1;
            }




            

            Savedata.Close();
        }

        btn_save_btn_text.text = list_text;

        btn_save_transform = UIButtons[UIButtons_Count].GetComponent<RectTransform>();

        UIButtons[UIButtons_Count].transform.Translate((Screen.width * 1.0f) - btn_save_transform.rect.width * 0.5f
            , (Screen.height * 1.0f) - btn_save_transform.rect.height * 0.5f, 0);

        UIButtons_Count += 1;

        #endregion

       


    }

    // Update is called once per frame
    void Update()
    {
        
    
    }

    void UpdateList()
    {
        var btn_save_btn_text = UIButtons[UIButtons_Count - 1].GetComponent<Text>();

        var list_text = "My Saved List:";

        for (var i = 0; i < UIList_Count; i++)
        {
            list_text += "\n" + UI_List[i] ;
        }

        btn_save_btn_text.text = list_text;
    }

    void SubtractItem()
    {
        if (UIList_Count > 0)
        {
            UI_List.RemoveAt(UIList_Count-1);

            UIList_Count -= 1;

            UpdateList();
        }
    }
    void AddItem()
    {
        if (UIList_Count < UIList_MaxCount)
        {

            UI_List.Add(UIList_Count.ToString());

            UIList_Count += 1;

            UpdateList();

        }


    }
    void Savegame()
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
    void EncryptSave()
    { 
        
    }

    void DecryptSave()
    { 
    
    }

}
