using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using LitJson;

public class WeatherChange : MonoBehaviour {

    [Header("Variables")]
    private int currentWeather;

    private void Start()
    {
        StartCoroutine(GetWeather());
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
            Debug.Log(currentWeather);
        }
    }
}
