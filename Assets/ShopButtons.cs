using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopButtons : MonoBehaviour
{
    public TextMeshProUGUI pricetxt;
    public TextMeshProUGUI counttxt;

    public void UpdateUI(int count, int price){
        pricetxt.text = "Price: " + price;
        counttxt.text = count.ToString();
    }   

}
