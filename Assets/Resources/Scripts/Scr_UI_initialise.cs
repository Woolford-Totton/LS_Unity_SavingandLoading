using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

using System.IO;

public class Scr_UI_initialise : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
       
        var prefabbutton = Resources.Load("Prefab/Btn_Empty");

        GameObject btn_save = (GameObject)Instantiate(prefabbutton
            , new Vector3(0, 0, 0), Quaternion.identity);

        btn_save.transform.SetParent(transform);

        Button btn_save_btn = btn_save.GetComponent<Button>();

        Text btn_save_btn_text = btn_save_btn.GetComponentInChildren<Text>();

        btn_save_btn_text.text = "Save";

        RectTransform btn_save_transform = btn_save.GetComponent<RectTransform>();

        btn_save.transform.Translate(btn_save_transform.rect.width * 0.5f
            , (Screen.height * 1.0f) - btn_save_transform.rect.height * 0.5f, 0);

        btn_save_btn.onClick.AddListener(Savegame);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Savegame()
    {
        
    }


}
