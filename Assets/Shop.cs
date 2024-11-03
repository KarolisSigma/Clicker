using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    //granny
    public ShopButtons btn;
    public float gprice;
    public int gcount;

    private ClickerCode clickerCode;

    void Start(){
        clickerCode = FindAnyObjectByType<ClickerCode>();
        StartCoroutine(grandmaCook());
    }

    public void BuyGranny(){
        if(clickerCode.clicks>=gprice){
            clickerCode.clicks -= (int)MathF.Ceiling(gprice);
            
            gcount++;
            gprice*=1.1f;
            UI.instance.updateUI(clickerCode.clicks);
            btn.UpdateUI(gcount, (int)MathF.Ceiling(gprice));
        }
    }

    IEnumerator grandmaCook(){
        while(true){
            yield return new WaitForSeconds(1);
            clickerCode.clicks +=gcount;
            UI.instance.updateUI(clickerCode.clicks);
        }
    }
}
