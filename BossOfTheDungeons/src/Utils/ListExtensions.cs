using System.Collections.Generic;

namespace BossOfTheDungeons.Utils;

public static class ListExtensions
{
    public static T RemoveAtAndReturn<T>(this List<T> list, int index)
    {
        var item = list[index];
        list.RemoveAt(index);
        return item;
    }
}