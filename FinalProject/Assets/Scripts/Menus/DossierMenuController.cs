/*
    * Jacob Cohen
    * DossierMenuController.cs
    * Final Project
    * controls the dossierMenu
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DossierMenuController : MonoBehaviour
{
    //variables
    public GameObject safeHouseMenu;
    public GameObject dossierMenu;

    // Start is called before the first frame update
    void Start()
    {
        safeHouseMenu.SetActive(true);
        dossierMenu.SetActive(false);
    }

    public void OpenDossier()
    {
        safeHouseMenu.SetActive(false);
        dossierMenu.SetActive(true);
    }

    public void CloseDossier()
    {
        safeHouseMenu.SetActive(true);
        dossierMenu.SetActive(false);
    }
}
