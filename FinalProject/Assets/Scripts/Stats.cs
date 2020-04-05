/*
    * Jacob Cohen
    * Stats.cs
    * Final Project
    * stores the stats of the player
*/

public static class Stats
{
    //variables
    private static string companion1Name;
    private static string companion2Name;
    private static string companion3Name;
    private static string companion4Name;
    private static string carName;

    private static int companion1Health;
    private static int companion2Health;
    private static int companion3Health;
    private static int companion4Health;
    private static int carHealth;

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

    public static int Companion1Health
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

    public static int Companion2Health
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

    public static int Companion3Health
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

    public static int Companion4Health
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

    public static int CarHealth
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