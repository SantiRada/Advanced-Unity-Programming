using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using LitJson;

public class WeatherChange : MonoBehaviour {

    [Header("Variables")]
    private int currentWeather;
    
    [Header("Object")]
    [SerializeField] private DigitalRuby.RainMaker.RainScript2D rainMaker;

    private void Start()
    {
        StartCoroutine(GetWeather());
    }
    private void ChangeWeather()
    {
        if (currentWeather >= 200 && currentWeather < 300)
        {
            // ---- TORMENTA -----------------------------
            rainMaker.enabled = true;
            rainMaker.RainIntensity += 1;
        }
        else if (currentWeather >= 300 && currentWeather < 400)
        {
            // ---- LLOVIZNA -----------------------------
            rainMaker.enabled = true;
            rainMaker.RainIntensity += 0.2f;
        }
        else if (currentWeather >= 400 && currentWeather < 500)
        {
            // ---- LLUVIA MAS LEVE ----------------------
            rainMaker.enabled = true;
            rainMaker.RainIntensity += 0.55f;
        }
        else if (currentWeather >= 500 && currentWeather < 700)
        {
            // ---- LLUVIA -------------------------------
            rainMaker.enabled = true;
            rainMaker.RainIntensity += 0.7f;
        }
        else if (currentWeather >= 700 && currentWeather < 800)
        {
            // ---- NIEBLA -------------------------------
            rainMaker.enabled = true;
            rainMaker.RainIntensity += 0.1f;
        }
        else if(currentWeather >= 800)
        {
            // ---- SOLEADO ------------------------------
            rainMaker.enabled = false;
        }
    }
    private IEnumerator GetWeather()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://api.openweathermap.org/data/2.5/weather?q=Mar%20del%20Plata&appid=4442e65e990ce4eba658655e709a4768");
        yield return www.SendWebRequest();

        if(www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {
            JsonData jsonData = JsonMapper.ToObject(www.downloadHandler.text);
            currentWeather = (int)jsonData["weather"][0]["id"];
        }

        Debug.Log(currentWeather);
        ChangeWeather();
        StopCoroutine(GetWeather());
    }
}
