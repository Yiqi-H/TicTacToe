using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpeedRacerUI : MonoBehaviour
{
    public Text text;
    public string carMaker;
    public string carModel = "GTR R35";
    public string engineType = "V6, Twin Turbo";

    public int carWeight = 1609;
    public int yearMade = 2009;

    public float maxAcceleration = 0.98f;

    public bool isCarTypeSedan = false;
    public bool hasFrontEngine = true;

    public class Fuel
    {
        public int fuelLevel;
        public Fuel(int amount)
        {
            fuelLevel = amount;
        }
    }
    public Fuel carFuel = new Fuel(100);

    public TMP_Text racerTextUI;

    public TMP_Text racerTextAgeUI;

    public TMP_Text carFuelLevelTextUI;

    public TMP_Text carWeightTextUI;

    public TMP_Text carCharecteristicsTextUI;

    void Start()
    {
        racerTextUI.text = "The racer model is" + carModel + "made by" + carMaker + ".It has" + engineType + "engine.";
        //Debug.Log("The racer model is" + carModel + ".It has" + engineType + "engine.");

        CheckWeight();

        if (yearMade <= 2009)
        {
            racerTextAgeUI.text = "It was first introduced in" + yearMade;
            int carAge = CalculateAge(yearMade);
            racerTextAgeUI.text += " That makes it" + carAge + "years old.";
        }
        else
        {
            racerTextAgeUI.text = "The car was introduced in the 2010's";
            racerTextAgeUI.text += " and the car's maximum acceleration is" + maxAcceleration + " m/s2";
        }
        print(CheckCharacteristics());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ConsumeFuel();
            CheckFuelLevel();
        }
    }

    public void ConsumeFuel()
    {
        carFuel.fuelLevel = carFuel.fuelLevel - 10;
    }

    public void CheckFuelLevel()
    {
        switch (carFuel.fuelLevel)
        {
            case 70:
                carFuelLevelTextUI.text = "fuel level is nearing two - thirds.";
                break;
            case 50:
                carFuelLevelTextUI.text = "fuel level is at half amount.";
                break;
            case 10:
                carFuelLevelTextUI.text = "Warning! Fuel level is critically low.";
                break;
            default:
                carFuelLevelTextUI.text = "There is nothing to report.";
                break;
        }
    }

    void CheckWeight()
    {
        if (carWeight < 1500)
        {
            carWeightTextUI.text = "The" + carModel + "weighs less than 1500kg";
        }
        else
        {
            carWeightTextUI.text = "The" + carModel + "weighs over 1500kg ";
        }
    }

    int CalculateAge(int yearMade)
    {
        return 2023 - yearMade;
    }

    public string CheckCharacteristics()
    {
        if (isCarTypeSedan)
        {
            carCharecteristicsTextUI.text = " The car type is a sedan.";
        }
        else if (hasFrontEngine)
        {
            carCharecteristicsTextUI.text += "The car isnt a sedan, but has a front engine.";
        }
        else
        {
            carCharecteristicsTextUI.text += " The car is neither a sedan nor does it have a front engine.";
        }
        return carCharecteristicsTextUI.text;
    }

}
