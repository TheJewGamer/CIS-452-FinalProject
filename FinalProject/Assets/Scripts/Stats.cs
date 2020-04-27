/*
    * Jacob Cohen
    * Stats.cs
    * Final Project
    * stores the stats of the player
*/

public static class Stats
{
    //variables
    private static string companion1Name = null;
    private static string companion2Name = null;
    private static string companion3Name = null;
    private static string companion4Name = null;
    private static string carName = null;

    private static float companion1Health = 10;
    private static float companion2Health = 10;
    private static float companion3Health = 10;
    private static float companion4Health = 10;
    private static int maxHealth = 10;
    private static float carFuel = 0;
    private static int maxFuel = 10;

    private static int companion1Ammo = 10;
    private static int companion2Ammo = 10;
    private static int companion3Ammo = 10;
    private static int companion4Ammo = 10;

    private static bool companion1Dead = false;
    private static bool companion2Dead = false;
    private static bool companion3Dead = false;
    private static bool companion4Dead = false;

    private static int medicalSuppliesCount = 2;
    private static int ammoSuppliesCount = 0;
    private static int fuelSuppliesCount = 0;
    private static int runsLeft = 4;
    private static int activeRunner = 0;
    private static int ammoPerPickup = 10;

    public static string Companion1Name
    {
        get
        {
            return companion1Name;
        }
        set
        {
            companion1Name = value;
        }
    }

    public static string Companion2Name
    {
        get
        {
            return companion2Name;
        }
        set
        {
            companion2Name = value;
        }
    }

    public static string Companion3Name
    {
        get
        {
            return companion3Name;
        }
        set
        {
            companion3Name = value;
        }
    }

    public static string Companion4Name
    {
        get
        {
            return companion4Name;
        }
        set
        {
            companion4Name = value;
        }
    }

    public static string CarName
    {
        get
        {
            return carName;
        }
        set
        {
            carName = value;
        }
    }

    public static float Companion1Health
    {
        get
        {
            return companion1Health;
        }
        set
        {
            companion1Health = value;
        }
    }

    public static float Companion2Health
    {
        get
        {
            return companion2Health;
        }
        set
        {
            companion2Health = value;
        }
    }

    public static float Companion3Health
    {
        get
        {
            return companion3Health;
        }
        set
        {
            companion3Health = value;
        }
    }

    public static float Companion4Health
    {
        get
        {
            return companion4Health;
        }
        set
        {
            companion4Health = value;
        }
    }

    public static int MaxHealth
    {
        get
        {
            return maxHealth;
        }
    }

    public static float CarFuel
    {
        get
        {
            return carFuel;
        }
        set
        {
            carFuel = value;
        }
    }

    public static int MaxFuel
    {
        get
        {
            return maxFuel;
        }
    }

    public static int Companion1Ammo
    {
        get
        {
            return companion1Ammo;
        }
        set
        {
            companion1Ammo = value;
        }
    }

    public static int Companion2Ammo
    {
        get
        {
            return companion2Ammo;
        }
        set
        {
            companion2Ammo = value;
        }
    }

    public static int Companion3Ammo
    {
        get
        {
            return companion3Ammo;
        }
        set
        {
            companion3Ammo = value;
        }
    }

    public static int Companion4Ammo
    {
        get
        {
            return companion4Ammo;
        }
        set
        {
            companion4Ammo = value;
        }
    }

    public static bool Companion1Dead
    {
        get
        {
            return companion1Dead;
        }
        set
        {
            companion1Dead = value;
        }
    }
    public static bool Companion2Dead
    {
        get
        {
            return companion2Dead;
        }
        set
        {
            companion2Dead = value;
        }
    }
    public static bool Companion3Dead
    {
        get
        {
            return companion3Dead;
        }
        set
        {
            companion3Dead = value;
        }
    }
    public static bool Companion4Dead
    {
        get
        {
            return companion4Dead;
        }
        set
        {
            companion4Dead = value;
        }
    }

    public static int MedicalSuppliesCount
    {
        get
        {
            return medicalSuppliesCount;
        }
        set
        {
            medicalSuppliesCount = value;
        }
    }
    public static int AmmoSuppliesCount
    {
        get
        {
            return ammoSuppliesCount;
        }
        set
        {
            ammoSuppliesCount = value;
        }
    }
    public static int FuelSuppliesCount
    {
        get
        {
            return fuelSuppliesCount;
        }
        set
        {
            fuelSuppliesCount = value;
        }
    }

    public static int RunsLeft
    {
        get
        {
            return runsLeft;
        }
        set
        {
            runsLeft = value;
        }
    }

    public static int ActiveRunner
    {
        get
        {
            return activeRunner;
        }
        set
        {
            activeRunner = value;
        }
    }

    public static int AmmoPerPickup
    {
        get
        {
            return ammoPerPickup;
        }
    }
}