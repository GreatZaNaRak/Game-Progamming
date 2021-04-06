using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Properties_Controller : MonoBehaviour
{


    public GameObject Plant;
    public GameObject Engi;
    public GameObject NoData;


    public void show(string user)
    {
        if (user == "Plant") {
            Plant.SetActive(true);
            Engi.SetActive(false);
            NoData.SetActive(false);
        } else if (user == "Engineer") {
            Plant.SetActive(false);
            Engi.SetActive(true);
            NoData.SetActive(false);
        } else {
            Plant.SetActive(false);
            Engi.SetActive(false);
            NoData.SetActive(true);
        }
    }

}
