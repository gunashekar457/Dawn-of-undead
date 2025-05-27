using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class WeatherControl : MonoBehaviour
{
    public PostProcessVolume postProcessing;
    public Light shadowDiractionLight;
    public Light withOutShadowDiractionLight;
    public GameObject rainParticleEffect;
    public GameObject nightSoundEffect;
    public GameObject morningSoundEffect;
    public GameObject rainView;

    [Space(5)]
    [Header("---------------------------------LIGHTS---------------------------------------------------")]
    public GameObject[] lights;

    [Space(5)]
    [Header("---------------------------------DAY---------------------------------------------------")]
    public bool dayRain;
    public Material day_skyBox;
    public Color dayShadowColor;
    public bool dayFog;
    public Color dayFogColor;
    public float dayFogDensity;
    public PostProcessProfile dayProfile;
    public float dayShadowDiractionLightDensity;
    public float dayWithOutShadowDiractionLightDensity;
    public Color dayShadownDLColor;
    public Color dayWithOutShadownDLColor;
    public bool dayStreetLights;

    [Space(5)]
    [Header("---------------------------------NIGHT---------------------------------------------------")]
    public bool nightRain;
    public Material night_skyBox;
    public Color nightShadowColor = new Color(61, 87, 114);
    public bool nightFog;
    public Color nightFogColor = new Color(62, 83, 108);
    public float nightFogDensity = 0.002f;
    public PostProcessProfile nightProfile;
    public float nightShadowDiractionLightDensity;
    public float nightWithOutShadowDiractionLightDensity;
    public Color nightShadownDLColor;
    public Color nightWithOutShadownDLColor;
    public bool nightStreetLights;
    [Space(5)]
    [Header("---------------------------------RAINY---------------------------------------------------")]
    public bool rainyRain;
    public Material rain_skyBox;
    public Color rainyShadowColor;
    public bool rainyFog;
    public Color rainyFogColor;
    public float rainyFogDensity;
    public PostProcessProfile rainyProfile;
    public float rainShadowDiractionLightDensity;
    public float rainWithOutShadowDiractionLightDensity;
    public Color rainShadownDLColor;
    public Color rainWithOutShadownDLColor;
    public bool rainyStreetLights;

    private float changeDayTime;

    public void Start()
    {
        day();
    }
    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.O))
        {
            day();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            night();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            //rainy();
        }

       
    }
    public void weather_State(weather state)
    {
        switch (state)
        {
            case weather.Day:
                day();
                break;
            case weather.Night:
                night();
                break;
            case weather.Rainy:
                //rainy();
                break;

        }
    }

    void night()
    {
        if (nightRain)
        {
            rainView.SetActive(true);
        }
        rainParticleEffect.SetActive(nightRain);
        nightSoundEffect.SetActive(true);
        morningSoundEffect.SetActive(false);
        RenderSettings.skybox = night_skyBox;
        RenderSettings.subtractiveShadowColor = nightShadowColor;
        RenderSettings.fog = nightFog;
        RenderSettings.fogColor = nightFogColor;
        RenderSettings.fogDensity = nightFogDensity;
        postProcessing.profile = nightProfile;
        shadowDiractionLight.intensity = nightShadowDiractionLightDensity;
        withOutShadowDiractionLight.intensity = nightWithOutShadowDiractionLightDensity;
        shadowDiractionLight.color = nightShadownDLColor;
        withOutShadowDiractionLight.color = nightWithOutShadownDLColor;
        lightsEnable(nightStreetLights);

    }
    void day()
    {
        if (dayRain)
        {
            rainView.SetActive(true);
        }
        rainParticleEffect.SetActive(dayRain);
        morningSoundEffect.SetActive(true);
        nightSoundEffect.SetActive(false);
        RenderSettings.skybox = day_skyBox;
        RenderSettings.subtractiveShadowColor = dayShadowColor;
        RenderSettings.fog = dayFog;
        RenderSettings.fogColor = dayFogColor;
        RenderSettings.fogDensity = dayFogDensity;
        postProcessing.profile = dayProfile;
        shadowDiractionLight.intensity = dayShadowDiractionLightDensity;
        withOutShadowDiractionLight.intensity = dayWithOutShadowDiractionLightDensity;
        shadowDiractionLight.color = dayShadownDLColor;
        withOutShadowDiractionLight.color = dayWithOutShadownDLColor;
        lightsEnable(dayStreetLights);

    }
    //void rainy()
    //{
    //    if (rainyRain)
    //    {
    //        rainView.SetActive(true);
    //    }
    //    nightSoundEffect.SetActive(false);
    //    morningSoundEffect.SetActive(false);
    //    rainParticleEffect.SetActive(rainyRain);
    //    RenderSettings.skybox = rain_skyBox;
    //    RenderSettings.subtractiveShadowColor = rainyFogColor;
    //    RenderSettings.fog = rainyFog;
    //    RenderSettings.fogColor = rainyFogColor;
    //    RenderSettings.fogDensity = rainyFogDensity;
    //    postProcessing.profile = rainyProfile;
    //    shadowDiractionLight.intensity = rainShadowDiractionLightDensity;
    //    withOutShadowDiractionLight.intensity = rainWithOutShadowDiractionLightDensity;
    //    shadowDiractionLight.color = rainShadownDLColor;
    //    withOutShadowDiractionLight.color = rainWithOutShadownDLColor;
    //    lightsEnable(rainyStreetLights);

    //}

    void lightsEnable(bool check)
    {
        foreach (GameObject obj in lights)
        {
            obj.SetActive(check);
        }
    }


}

public enum weather
{
    Day,
    Night,
    Rainy,
}
