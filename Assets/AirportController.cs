using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirportController : MonoBehaviour
{
    public string IATACode;
    public string AirportName;
    public string City;
    public string Country;
    public float LatitudeDD;
    public float LongitudeDD;
    public int Altitude;
    
    public void ReceiveAportData(AirportManager.AirportData data)
    {
        IATACode = data.IATACode;
        AirportName = data.AirportName;
        City = data.City;
        Country = data.Country;
        LatitudeDD = data.LatitudeDD;
        LongitudeDD = data.LongitudeDD;
        Altitude = data.Altitude;
    }

    public void OnMouseDown()
    {
        AirportDataDisplay.Instance.FillAirportData(IATACode, AirportName, City, Country, LatitudeDD, LongitudeDD,Altitude);
    }
}
