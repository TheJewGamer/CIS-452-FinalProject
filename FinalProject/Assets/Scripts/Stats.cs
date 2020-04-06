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
    private static float carHealth = 10;

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

    public static float CarHealth
    {
        get
        {
            return carHealth;
        }
        set
        {
            carHealth = value;
        }
    }
}