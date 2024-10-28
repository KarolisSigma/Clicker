using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    public static UI instance;

    public TextMeshProUGUI text;
    public void updateUI(int clicks){
        text.text = clicks.ToString();
    }


    void Awake(){
        
        if(instance==null){
            instance=this;
        }
        else{
            Destroy(this);
            print("Lol instance!=null");
        }
    }
}
