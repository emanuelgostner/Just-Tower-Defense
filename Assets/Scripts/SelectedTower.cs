using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedTower : MonoBehaviour
{
    private GameObject selectedBuildplace;
    public Button closeMenuObj;
    public Button placeTowerObj;
    public Button upgradeTowerObj;
    public Button removeTowerObj;
    
    private void handleButtonVisibility()
    {
        // No buildable place selected
        if (!selectedBuildplace)
        {
            closeMenuObj.gameObject.SetActive(false);
            placeTowerObj.gameObject.SetActive(false);
            upgradeTowerObj.gameObject.SetActive(false);
            removeTowerObj.gameObject.SetActive(false);
        }
        // Buildable place has no building yet
        else if (selectedBuildplace.GetComponent<Buildplace>().getCurLevel() == 0)
        {
            closeMenuObj.gameObject.SetActive(true);
            placeTowerObj.gameObject.SetActive(true);
        }
        // Buildable place has a upgradable tower 
        else if (selectedBuildplace.GetComponent<Buildplace>().getCurLevel() >
                 selectedBuildplace.GetComponent<Buildplace>().getMaxLevel())
        {
            closeMenuObj.gameObject.SetActive(true);
            placeTowerObj.gameObject.SetActive(false);
            upgradeTowerObj.gameObject.SetActive(true);
            removeTowerObj.gameObject.SetActive(true);
        }
        // Builable place has tower with max level
        else
        {
            removeTowerObj.gameObject.SetActive(false);
        }
    }
    public void SetSelectedBuildplace(GameObject buildplace)
    {
        this.selectedBuildplace = buildplace;
        Debug.Log("Buildplace updated", selectedBuildplace);
        handleButtonVisibility();
    }

    public void placeTower()
    {
        selectedBuildplace.GetComponent<Buildplace>().placeTower();
        handleButtonVisibility();
    }

    public void upgradeTower()
    {
        selectedBuildplace.GetComponent<Buildplace>().upgradeTower();
        handleButtonVisibility();
    }

    public void removeTower()
    {
        selectedBuildplace.GetComponent<Buildplace>().removeTower();
        handleButtonVisibility();
    }

    public void closeMenu()
    {
        selectedBuildplace = null;
        handleButtonVisibility();
    }
}
