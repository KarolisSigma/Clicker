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
    //public ParticleSystem effect2;


    private float cprice;

    private ClickerCode clickerCode;

    void Start(){
        
        cprice = PlayerPrefs.GetFloat("cprice");
        clickerCode = FindAnyObjectByType<ClickerCode>();
        StartCoroutine(grandmaCook());
        gcount = PlayerPrefs.GetInt("gcount");
        gprice = PlayerPrefs.GetFloat("gprice");
        btn.UpdateUI(gcount, (int)MathF.Ceiling(gprice));
        btn.cookiebtn((int)cprice);
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
        if (clickerCode.clicks >= cprice)
        {
            clickerCode.clicks -= (int)cprice;

            cprice *= 3f;
            btn.cookiebtn((int)cprice);
            PlayerPrefs.SetFloat("cprice", cprice);
            PlayerPrefs.SetInt("multiplier", PlayerPrefs.GetInt("multiplier")+1);
            clickerCode.multiplier = PlayerPrefs.GetInt("multiplier");
            clickerCode.updateModel();

            PlayerPrefs.Save();

        }
    }


    IEnumerator grandmaCook(){
        while(true){
            yield return new WaitForSeconds(cookTime);

            clickerCode.clicks +=gcount*gcps*cookTime;
            UI.instance.updateUI(clickerCode.clicks);
            clickerCode.effect.Emit(gcount * gcps * cookTime);
        }
    }
}
