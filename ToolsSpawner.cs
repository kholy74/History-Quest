using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ToolsSpawner : MonoBehaviour
{
   

    
    [SerializeField] private GameObject NatronPanel;
    [SerializeField] private GameObject oilPanel;
    [SerializeField] private GameObject HerbsPanel;
    [SerializeField] private GameObject FoodPanel;
    [SerializeField] private GameObject WaterPanel;
    [SerializeField] private GameObject NewHerbsPanel;
   


   
   
    public void displayPanel(String s)
    {
        Time.timeScale = 0f;
        if (s.Equals("Natron"))
        {
          
            NatronPanel.SetActive(true);
        }
        if (s.Equals("Oil"))
        {
            oilPanel.SetActive(true);
        }
        if (s.Equals("Herb"))
        {
            HerbsPanel.SetActive(true);
        }
        if (s.Equals("Food"))
        {
          
            FoodPanel.SetActive(true);
        }
        if (s.Equals("Water"))
        {
            WaterPanel.SetActive(true);
        }
        if (s.Equals("NewHerb"))
        {
            NewHerbsPanel.SetActive(true);
        }
    }
    public void NatronButton()
    {
        Time.timeScale = 1f;
        NatronPanel.SetActive(false);
    }
    public void OilButton()
    {
        Time.timeScale = 1f;
        oilPanel.SetActive(false);
    }
    public void HerbsButton()
    {
        Time.timeScale = 1f;
        HerbsPanel.SetActive(false);
    }
  public void FoodButton()
    {
        Time.timeScale = 1f;
        FoodPanel.SetActive(false);
    }
    public void WaterButton()
    {
        Time.timeScale = 1f;
        WaterPanel.SetActive(false);
    }
    public void NewHerbsButton()
    {
        Time.timeScale = 1f;
        NewHerbsPanel.SetActive(false);
    }
}
