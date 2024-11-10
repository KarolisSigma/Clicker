using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;

public class ClickerCode : MonoBehaviour
{
    public List<GameObject> updates;
    private int update;

    public int clicks;
    public AudioSource AudioSource;
    public ParticleSystem effect;
    public Shop shopcode;
    private List<int> cl = new List<int>();
    private int cl2;
    private float timepassed = 0;
    public TextMeshProUGUI cpstxt;
    public int multiplier;

    [Header("Animation")]
    public float duration;
    public float scale;
    public Ease ease = Ease.InOutSine;


    void Start()
    {
        clicks = PlayerPrefs.GetInt("clicks");

        StartCoroutine(CPS());
        cl2 = 0;
        multiplier = 1;
        multiplier = PlayerPrefs.GetInt("multiplier");
        PlayerPrefs.SetInt("multiplier", 1);
        updateModel();

    }
    public void updateModel()
    {
        update = PlayerPrefs.GetInt("multiplier") - 1;
        int a = 0;
        if (update > updates.Count - 1)
        {
            a = updates.Count - 1;
        }
        else
        {
            a = update;
        }
        foreach (GameObject g in updates)
        {
            g.SetActive(false);
        }
        updates[a].SetActive(true);
    }
    void OnMouseDown()  
    {  
        cl2+=1*multiplier;

        clicks+=1*multiplier;
        UI.instance.updateUI(clicks);
        transform.DOScale(5, duration).ChangeStartValue(scale * Vector3.one).SetEase(ease);
        AudioSource.pitch = Random.Range(0.5f, 1.5f);
        AudioSource.Play();
        effect.Emit(1);

        PlayerPrefs.SetInt("Clicks", clicks);
        PlayerPrefs.Save();

    }
    IEnumerator CPS() {
        while (true) {
            yield return new WaitForSeconds(1);
            int num = cl2;

            cl2 = 0;
            if (cl.Count == 10)
            {
                cl.RemoveAt(0);
            }
            cl.Add(num);
            int allclicks = 0;

            foreach (int i in cl)
            {
                allclicks += i;
            }
            float average = allclicks / 10f + shopcode.gcount;
            cpstxt.text = average + " CPS";
        }

    }
    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("clicks", clicks);
        PlayerPrefs.Save();
    }

}
