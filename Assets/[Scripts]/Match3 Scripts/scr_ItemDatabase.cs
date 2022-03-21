
using UnityEngine;

public static class scr_ItemDatabase
{
    public static scr_Item[] Items { get; private set; }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)] private static void Initialize() => Items = Resources.LoadAll<scr_Item>("Items/");
}
