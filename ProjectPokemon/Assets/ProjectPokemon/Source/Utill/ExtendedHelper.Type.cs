using UnityEngine;
using static UnityEngine.Rendering.DebugUI.MessageBox;

public static partial class ExtendedHelper
{

    public static float GetTypeMatchup(this Defines.MoveType pokemon, Defines.MoveType target)
    {
        switch (pokemon)
        {
            case Defines.MoveType.Normal:
                return target.GetTypeMatchupToNormal();
            case Defines.MoveType.Fighting:
                return target.GetTypeMatchupToFighting();
            case Defines.MoveType.Flying:
                return target.GetTypeMatchupToFlying();
            case Defines.MoveType.Poison:
                return target.GetTypeMatchupToPoison();
            case Defines.MoveType.Ground:
                return target.GetTypeMatchupToGround();
            case Defines.MoveType.Rock:
                return target.GetTypeMatchupToRock();
            case Defines.MoveType.Bug:
                return target.GetTypeMatchupToBug();
            case Defines.MoveType.Ghost:
                return target.GetTypeMatchupToGhost();
            case Defines.MoveType.Steel:
                return target.GetTypeMatchupToSteel();
            case Defines.MoveType.Fire:
                return target.GetTypeMatchupToFire();
            case Defines.MoveType.Water:
                return target.GetTypeMatchupToWater();
            case Defines.MoveType.Grass:
                return target.GetTypeMatchupToGrass();
            case Defines.MoveType.Electric:
                return target.GetTypeMatchupToElectric();
            case Defines.MoveType.Psychic:
                return target.GetTypeMatchupToPsychic();
            case Defines.MoveType.Ice:
                return target.GetTypeMatchupToIce();
            case Defines.MoveType.Dragon:
                return target.GetTypeMatchupToDragon();
            case Defines.MoveType.Dark:
                return target.GetTypeMatchupToDark();


        }

        return 0f;
    }

    //내가 때렸을 떄 기준
    public static float GetTypeMatchupToNormal(this Defines.MoveType target)
    {
        switch (target)
        {
            case Defines.MoveType.Ghost:
                return 0f;

            case Defines.MoveType.Steel:
            case Defines.MoveType.Rock:
                return 0.5f;
        }

        return 1f;
    }

    public static float GetTypeMatchupToFire(this Defines.MoveType target)
    {
        switch (target)
        {
            case Defines.MoveType.Steel:
            case Defines.MoveType.Grass:
            case Defines.MoveType.Ice:
            case Defines.MoveType.Bug:
                return 2f;

            case Defines.MoveType.Rock:
            case Defines.MoveType.Fire:
            case Defines.MoveType.Water:
            case Defines.MoveType.Dragon:
                return 0.5f;
        }

        return 1f;
    }

    public static float GetTypeMatchupToWater(this Defines.MoveType target)
    {
        switch (target)
        {
            case Defines.MoveType.Ground:
            case Defines.MoveType.Rock:
            case Defines.MoveType.Fire:
                return 2f;

            case Defines.MoveType.Dragon:
            case Defines.MoveType.Water:
            case Defines.MoveType.Grass:
                return 0.5f;
        }

        return 1f;
    }

    public static float GetTypeMatchupToGrass(this Defines.MoveType target)
    {
        switch (target)
        {
            case Defines.MoveType.Ground:
            case Defines.MoveType.Rock:
            case Defines.MoveType.Water:
                return 2f;

            case Defines.MoveType.Steel:
            case Defines.MoveType.Poison:
            case Defines.MoveType.Dragon:
            case Defines.MoveType.Bug:
            case Defines.MoveType.Fire:
            case Defines.MoveType.Flying:
            case Defines.MoveType.Grass:
                return 0.5f;
        }

        return 1f;
    }

    public static float GetTypeMatchupToElectric(this Defines.MoveType target)
    {
        switch (target)
        {
            case Defines.MoveType.Water:
            case Defines.MoveType.Flying:
                return 2f;

            case Defines.MoveType.Dragon:
            case Defines.MoveType.Electric:
            case Defines.MoveType.Grass:
                return 0.5f;
        }

        return 1f;
    }

    public static float GetTypeMatchupToIce(this Defines.MoveType target)
    {
        switch (target)
        {
            case Defines.MoveType.Dragon:
            case Defines.MoveType.Flying:
            case Defines.MoveType.Ground:
            case Defines.MoveType.Grass:
                return 2f;

            case Defines.MoveType.Steel:
            case Defines.MoveType.Water:
            case Defines.MoveType.Fire:
            case Defines.MoveType.Ice:
                return 0.5f;
        }

        return 1f;
    }

    public static float GetTypeMatchupToFighting(this Defines.MoveType target)
    {
        switch (target)
        {
            case Defines.MoveType.Steel:
            case Defines.MoveType.Normal:
            case Defines.MoveType.Rock:
            case Defines.MoveType.Ice:
            case Defines.MoveType.Dark:
                return 2f;

            case Defines.MoveType.Poison:
            case Defines.MoveType.Bug:
            case Defines.MoveType.Flying:
            case Defines.MoveType.Psychic:
                return 0.5f;

            case Defines.MoveType.Ghost:
                return 0f;
        }

        return 1f;
    }

    public static float GetTypeMatchupToPoison(this Defines.MoveType target)
    {
        switch (target)
        {
            case Defines.MoveType.Grass:
                return 2f;

            case Defines.MoveType.Poison:
            case Defines.MoveType.Ghost:
            case Defines.MoveType.Ground:
            case Defines.MoveType.Rock:
                return 0.5f;

            case Defines.MoveType.Steel:
                return 0f;
        }

        return 1f;
    }

    public static float GetTypeMatchupToGround(this Defines.MoveType target)
    {
        switch (target)
        {
            case Defines.MoveType.Fire:
            case Defines.MoveType.Electric:
            case Defines.MoveType.Poison:
            case Defines.MoveType.Rock:
            case Defines.MoveType.Steel:
                return 2f;

            case Defines.MoveType.Bug:
            case Defines.MoveType.Grass:
                return 0.5f;

            case Defines.MoveType.Flying:
                return 0f;
        }

        return 1f;
    }

    public static float GetTypeMatchupToFlying(this Defines.MoveType target)
    {
        switch (target)
        {
            case Defines.MoveType.Grass:
            case Defines.MoveType.Fighting:
            case Defines.MoveType.Bug:
                return 2f;

            case Defines.MoveType.Electric:
            case Defines.MoveType.Ice:
            case Defines.MoveType.Rock:
                return 0.5f;
        }

        return 1f;
    }

    public static float GetTypeMatchupToPsychic(this Defines.MoveType target)
    {
        switch (target)
        {
            case Defines.MoveType.Fighting:
            case Defines.MoveType.Poison:
                return 2f;

            case Defines.MoveType.Steel:
            case Defines.MoveType.Psychic:
                return 0.5f;

            case Defines.MoveType.Dark:
                return 0f;
        }

        return 1f;
    }

    public static float GetTypeMatchupToBug(this Defines.MoveType target)
    {
        switch (target)
        {
            case Defines.MoveType.Dark:
            case Defines.MoveType.Psychic:
            case Defines.MoveType.Grass:
                return 2f;

            case Defines.MoveType.Steel:
            case Defines.MoveType.Fighting:
            case Defines.MoveType.Ghost:
            case Defines.MoveType.Fire:
            case Defines.MoveType.Flying:
                return 0.5f;
        }

        return 1f;
    }

    public static float GetTypeMatchupToRock(this Defines.MoveType target)
    {
        switch (target)
        {
            case Defines.MoveType.Bug:
            case Defines.MoveType.Fire:
            case Defines.MoveType.Flying:
            case Defines.MoveType.Ice:
                return 2f;

            case Defines.MoveType.Steel:
            case Defines.MoveType.Fighting:
            case Defines.MoveType.Ground:
                return 0.5f;
        }

        return 1f;
    }

    public static float GetTypeMatchupToGhost(this Defines.MoveType target)
    {
        switch (target)
        {
            case Defines.MoveType.Ghost:
            case Defines.MoveType.Psychic:
                return 2f;

            case Defines.MoveType.Dark:
                return 0.5f;

            case Defines.MoveType.Normal:
                return 0f;
        }

        return 1f;
    }

    public static float GetTypeMatchupToDragon(this Defines.MoveType target)
    {
        switch (target)
        {
            case Defines.MoveType.Dragon:
                return 2f;

            case Defines.MoveType.Steel:
                return 0.5f;
        }

        return 1f;
    }

    public static float GetTypeMatchupToDark(this Defines.MoveType target)
    {
        switch (target)
        {
            case Defines.MoveType.Ghost:
            case Defines.MoveType.Psychic:
                return 2f;

            case Defines.MoveType.Dark:
            case Defines.MoveType.Fighting:
                return 0.5f;
        }

        return 1f;
    }

    public static float GetTypeMatchupToSteel(this Defines.MoveType target)
    {
        switch (target)
        {
            case Defines.MoveType.Rock:
            case Defines.MoveType.Ice:
                return 2f;

            case Defines.MoveType.Steel:
            case Defines.MoveType.Water:
            case Defines.MoveType.Fire:
            case Defines.MoveType.Electric:
                return 0.5f;

            case Defines.MoveType.Dark:
                return 0f;
        }

        return 1f;
    }
}
