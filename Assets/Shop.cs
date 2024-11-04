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
    public int gcps=1;
    public int cookTime = 2;
    public ParticleSystem effect2;

    private ClickerCode clickerCode;

    void Start(){
        clickerCode = FindAnyObjectByType<ClickerCode>();
        StartCoroutine(grandmaCook());
        btn.UpdateUI(gcount, (int)MathF.Ceiling(gprice));
    }

    public void BuyGranny(){
        if(clickerCode.clicks>=gprice){
            clickerCode.clicks -= (int)MathF.Ceiling(gprice);
            
            gcount++;
            gprice*=1.1f;
            UI.instance.updateUI(clickerCode.clicks);
            btn.UpdateUI(gcount, (int)MathF.Ceiling(gprice));

            PlayerPrefs.SetInt("gcount", gcount);
            PlayerPrefs.SetFloat("gprice", gprice);
            PlayerPrefs.Save();
            
        }
    }


    public void upgradeCookie() {
        clickerCode.multiplier = 2;

    }


    IEnumerator grandmaCook(){
        while(true){
            yield return new WaitForSeconds(cookTime);

            clickerCode.clicks +=gcount*gcps*cookTime;
            UI.instance.updateUI(clickerCode.clicks);
            effect2.Emit(gcount * gcps * cookTime);
        }
    }
}
