using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AirportDataDisplay : MonoBehaviour
{
    public static AirportDataDisplay Instance;
    public TextMeshProUGUI CodeText;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI CityText;
    public TextMeshProUGUI CountryText;
    public TextMeshProUGUI LatText;
    public TextMeshProUGUI LonText;
    public TextMeshProUGUI AltitudeText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void FillAirportData(string IATACode, string AirportName, string City, string Country, float LatitudeDD, float LongitudeDD, int AltitudeParam)
    {
        CodeText.text = IATACode;
        NameText.text = AirportName;
        CityText.text = City;
        CountryText.text = Country;
        LatText.text = LatitudeDD.ToString();
        LonText.text = LongitudeDD.ToString();
        AltitudeText.text = AltitudeParam.ToString();
    }
}
