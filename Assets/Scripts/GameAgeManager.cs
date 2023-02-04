using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameAgeManager : MonoBehaviour
{
    public int Age = 2023;

    public Image bgTop;
    public Image bgDown;

    public Image[] bgTops;
    public Image[] bgBots;
    
    private int[] Ages = new int[]
    {
        2023, //1 today
        1960,
        1500, //2 castle
        0,
        -10000, //3 stone
        -23300,
        -102000, //4 ape
        -347000,
        -1332678, //5 volcano
        -4003823, 
        -10022231, //6 fish
        -60300523,
        -999999999//7 alien
    };

    int getEra()
    {
        if (Age > 1500)
            return 1;
        if (Age > -10000)
            return 2;
        if (Age > -102000)
            return 3;
        if (Age > -1332678)
            return 4;
        if (Age > -10022231)
            return 5;
        if (Age > -999999999)
            return 6;
        return 7;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void setBackground()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
