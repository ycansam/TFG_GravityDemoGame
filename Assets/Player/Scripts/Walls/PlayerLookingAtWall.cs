using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookingAtWall : MonoBehaviour
{
    public static bool IsLookingInferiorWall()
    {
        return GetWallName().Contains("Inferior");
    }
    public static bool IsLookingRightWall()
    {
        return GetWallName().Contains("Right");
    }
    public static bool IsLookingFrontWall()
    {
        return GetWallName().Contains("Front");
    }
    public static bool IsLookingLeftWall()
    {
        return GetWallName().Contains("Left");
    }
    public static bool IsLookingBackWall()
    {
        return GetWallName().Contains("Back");
    }
    public static bool IsLookingTopWall()
    {
        return GetWallName().Contains("Top");
    }

    public static string GetWallName()
    {
        return CharacterWallsInformation.GetCharLookingAtWallName();
    }
}
