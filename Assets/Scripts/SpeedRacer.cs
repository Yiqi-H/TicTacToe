using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpeedRacer : MonoBehaviour
{
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

    void Start()
    {
        
        
        CheckWeight();

        if (yearMade <= 2009)
        {
            print("It was first introduced in" + yearMade);
            int carAge = CalculateAge(yearMade);
            print("That makes it" + carAge + "years old.");
        }
        else
        {
            print("The car was introduced in the 2010's");
            print("and the car's maximum acceleration is" + maxAcceleration + " m/s2");
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

    void ConsumeFuel()
    {
        carFuel.fuelLevel = carFuel.fuelLevel - 10;
    }

    void CheckFuelLevel()
    {
        switch (carFuel.fuelLevel)
        {
            case 70:
                print("fuel level is nearing two - thirds.");
                break;
            case 50:
                print("fuel level is at half amount.");
                break;
            case 10:
                 print("Warning! Fuel level is critically low.");
                break;
            default:
                print("There’s nothing to report.");
                break;
        }
     }

    void CheckWeight()
    {
        if (carWeight < 1500)
        {
            print("The" + carModel + "weighs less than 1500kg");
        }
        else
        {
            print("The" + carModel + "weighs over 1500kg ");
        }
    }

    int CalculateAge(int yearMade)
    {
        return 2023 - yearMade;
    }

    string CheckCharacteristics()
    {
        if (isCarTypeSedan)
        {
            return " The car type is a sedan.";
        }
        else if (hasFrontEngine)
        {
            return "The car isn’t a sedan, but has a front engine.";
        }
        else
        {
            return " The car is neither a sedan nor does it have a front engine.";
        }
    }
     
}
