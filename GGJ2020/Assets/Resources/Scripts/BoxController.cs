using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public bool DialActive = true, ButtonActive = true, SliderActive = true;
    public GameObject boxLight;

    private Material greenLight, redLight, orangeLight, purpleLight, blueLight, whiteLight,
        pinkLight, skyblueLight, brownLight;

    public enum LightColor : byte
    {
        GREEN = 0,
        RED,
        ORANGE,
        PURPLE,
        BLUE,
        WHITE,
        PINK,
        SKYBLUE,
        BROWN
    }

    public enum Mechanism : byte
    {
        BUTTON,
        DIAL,
        SLIDER
    }

    // Start is called before the first frame update
    void Start()
    {
        greenLight = Resources.Load<Material>("Materials/Green Light");
        redLight = Resources.Load<Material>("Materials/Red Light");
        orangeLight = Resources.Load<Material>("Materials/Orange Light");
        purpleLight = Resources.Load<Material>("Materials/Purple Light");
        blueLight = Resources.Load<Material>("Materials/Blue Light");
        whiteLight = Resources.Load<Material>("Materials/White Light");
        pinkLight = Resources.Load<Material>("Materials/Pink Light");
        skyblueLight = Resources.Load<Material>("Materials/Skyblue Light");
        brownLight = Resources.Load<Material>("Materials/Brown Light");

        if (Random.Range(0, 2) == 0)
        {
            DialActive = false;
        }
        if (Random.Range(0, 2) == 0)
        {
            ButtonActive = false;
        }
        if (Random.Range(0, 2) == 0)
        {
            SliderActive = false;
        }

        UpdateColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlipMechanism(Mechanism m)
    {
        if (m == Mechanism.BUTTON)
        {
            ButtonActive = !ButtonActive;
        } else if (m == Mechanism.DIAL)
        {
            DialActive = !DialActive;
        }
        else if (m == Mechanism.SLIDER)
        {
            SliderActive = !SliderActive;
        }

        UpdateColor();
    }

    public void UpdateColor()
    {
        LightColor currentBoxColor = GetColor();
        Material selectedColor;
        Color selectedLightColor;

        if (currentBoxColor == LightColor.GREEN)
        {
            selectedColor = greenLight;
            selectedLightColor = Color.green;
        }
        else if (currentBoxColor == LightColor.RED)
        {
            selectedColor = redLight;
            selectedLightColor = Color.red;
        }
        else if (currentBoxColor == LightColor.ORANGE)
        {
            selectedColor = orangeLight;
            selectedLightColor = new Color(1.0f, 0.5f, 0.0f);
        }
        else if (currentBoxColor == LightColor.PURPLE)
        {
            selectedColor = purpleLight;
            selectedLightColor = new Color(0.5f, 0.0f, 0.9f);
        }
        else if (currentBoxColor == LightColor.BLUE)
        {
            selectedColor = blueLight;
            selectedLightColor = Color.blue;
        }
        else if (currentBoxColor == LightColor.WHITE)
        {
            selectedColor = whiteLight;
            selectedLightColor = Color.white;
        }
        else if (currentBoxColor == LightColor.PINK)
        {
            selectedColor = pinkLight;
            selectedLightColor = new Color(1.0f, 0.75f, 0.8f);
        }
        else if (currentBoxColor == LightColor.SKYBLUE)
        {
            selectedColor = skyblueLight;
            selectedLightColor = Color.cyan;
        }
        else if (currentBoxColor == LightColor.BROWN)
        {
            selectedColor = brownLight;
            selectedLightColor = new Color(0.32f, 0.16f, 0.16f);
        }
        else
        {
            selectedColor = greenLight;
            selectedLightColor = Color.green;
        }

        boxLight.GetComponent<MeshRenderer>().material = selectedColor;
        boxLight.GetComponentInChildren<Light>().color = selectedLightColor;
    }

    public LightColor GetColor()
    {
        if (DialActive && !ButtonActive && !SliderActive)
        {
            return LightColor.GREEN;
        }
        else if (DialActive && ButtonActive && !SliderActive)
        {
            return LightColor.RED;
        }
        else if (DialActive && ButtonActive && SliderActive)
        {
            return LightColor.ORANGE;
        }
        else if (!DialActive && ButtonActive && SliderActive)
        {
            return LightColor.BLUE;
        }
        else if (!DialActive && !ButtonActive && SliderActive)
        {
            return LightColor.WHITE;
        }
        else if (!DialActive && !ButtonActive && !SliderActive)
        {
            return LightColor.PINK;
        }
        else if (!DialActive && ButtonActive && !SliderActive)
        {
            return LightColor.SKYBLUE;
        }
        else if (DialActive && !ButtonActive && SliderActive)
        {
            return LightColor.PURPLE;
        }

        // dead code path
        return LightColor.GREEN;
    }

    public bool GetMechanismState(Mechanism m)
    {
        if (m == Mechanism.DIAL)
        {
            return DialActive;
        } else if (m == Mechanism.BUTTON)
        {
            return ButtonActive;
        } else if (m == Mechanism.SLIDER)
        {
            return SliderActive;
        }

        return false;
    }
}
