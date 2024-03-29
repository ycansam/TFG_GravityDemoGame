using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnWall : MonoBehaviour
{
    public static bool IsOnInferiorWall()
    {
        return GetWallName().Contains("Inferior");
    }
    public static bool IsOnRightWall()
    {
        return GetWallName().Contains("Right");
    }
    public static bool IsOnFrontWall()
    {
        return GetWallName().Contains("Front");
    }
    public static bool IsOnLeftWall()
    {
        return GetWallName().Contains("Left");
    }
    public static bool IsOnBackWall()
    {
        return GetWallName().Contains("Back");
    }
    public static bool IsOnTopWall()
    {
        return GetWallName().Contains("Top");
    }

    private static string GetWallName()
    {
        return CharacterWallsInformation.GetCharOnWallName();
    }
}
