using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class ClickerCode : MonoBehaviour
{
	Ray ray;
	RaycastHit hit;
    public int clicks;
    public AudioSource AudioSource;


    [Header("Animation")]
    public float duration;
    public float scale;
    public Ease ease = Ease.InOutSine;


    void OnMouseDown()  
    {  
            clicks++;
            UI.instance.updateUI(clicks);
            transform.DOScale(5, duration).ChangeStartValue(scale * Vector3.one).SetEase(ease);
            AudioSource.pitch = Random.Range(0.5f, 1.5f);
            AudioSource.Play();
    }
}
