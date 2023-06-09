using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hats : MonoBehaviour
{
    private static bool hat_01 = false;
    private static bool hat_02 = false;

    public static GameObject hopps_01;
    public static GameObject hopps_02;

    

    public void Start()
    {
        hopps_01 = GetComponent<GameObject>();
        hopps_02 = GetComponent<GameObject>();

        
    }



    public static void HatSelected_01()
    {
        if (hat_01 == true)
        {
            hopps_01.SetActive(true);
            hopps_02.SetActive(false);
        }
    }
    public static void HatSelected_02()
    {
        if (hat_02 == true)
        {
            hopps_02.SetActive(true);
            hopps_01.SetActive(false);
        }
        
        
        

    }






}
