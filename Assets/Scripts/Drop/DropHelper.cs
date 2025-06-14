using IMP.Core;
using UnityEngine;

public static class DropHelper
{
    public static DropType GetRandomDropType()
    {
        float rand = Random.Range(0f, 100f);

        if (rand < 92.5f) return DropType.EXP;
        if (rand < 95.0f) return DropType.HEAL;
        if (rand < 97.5f) return DropType.MAGNET;
        return DropType.BOMB;
    }
}
