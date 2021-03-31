using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Personal_Controller : MonoBehaviour
{

    public Player_Controller Player;

    public void enterPlant()
    {
        Player.setCurrentUser("Plant");
        onEnter();
    }

    public void exitPlant()
    {
        Player.setCurrentUser("No Data");
        onExit();
    }

    public void enterEngineer()
    {
        Player.setCurrentUser("Engineer");
        onEnter();
    }

    public void exitEngineer()
    {
        Player.setCurrentUser("No Data");
        onExit();
    }

    private void onEnter()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(130, 130);
    }

    private void onExit()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
    }

}
