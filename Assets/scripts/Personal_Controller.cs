using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Personal_Controller : MonoBehaviour
{

    public GameStatus gs;

    public void enterPlant()
    {
        onEnter();
    }

    public void exitPlant()
    {
        onExit();
    }

    public void clickPlant()
    {
        gs.setCurrentUser("Plant");
        gs.setIsCharSelected(1);
        onExit();
    }

    public void enterEngineer()
    {
        onEnter();
    }

    public void exitEngineer()
    {
        onExit();
    }

    public void clickEngineer()
    {
        gs.setCurrentUser("Engineer");
        gs.setIsCharSelected(1);
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
