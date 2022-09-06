using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class CityManager : MonoBehaviour
{
    //public TextAsset CitiesData; todo get data form this file not path

    public struct CityData
    {
       
        public string City;
        public string Country;
        public float LatitudeDD;
        public float LongitudeDD;
        public int Population;

        public CityData(string v1, string v2, float v3, float v4, int v5) : this()
        {
          
            this.City = v1;
            this.Country = v2;
            this.LatitudeDD = v3;
            this.LongitudeDD = v4;
            this.Population = v5;
        }
    }

    public List<CityData> CitiesList;

    private void Start()
    {
        GetDataFromText();
        PlotCities();
    }

    public void GetDataFromText()
    {
        CitiesList = new List<CityData>();
        string[] text = File.ReadAllLines("Assets/Data/worldcities.csv");
       
        char separator = ',';
        for (int i = 1; i < text.Length; i++)
        {
            String Line = text[i].Replace("\"", "");
            string[] strValues = Line.Split(separator);
            //Debug.Log(strValues[0] + strValues[4] + strValues[2] + strValues[3] + strValues[9]);
            try
            {
                if (strValues.Length == 11)
                {
                    CitiesList.Add(new CityData(strValues[0], strValues[4], float.Parse(strValues[2]), float.Parse(strValues[3]), int.Parse(strValues[9])));
                }
                else
                {
                    CitiesList.Add(new CityData(strValues[0], strValues[4], float.Parse(strValues[2]), float.Parse(strValues[3]), int.Parse(strValues[10])));
                }
            }catch(FormatException e)
            {
                //Debug.Log(e.Message);
            }
           
        }
    }
    private void PlotCities()
    {
        for (int i = 0; i < CitiesList.Count; i++)
        {
            
            GameObject GO = TowerSpawner.Instance.Plot(CitiesList[i].LatitudeDD, CitiesList[i].LongitudeDD, CitiesList[i].Population/15000);
            
        }
    }
}
