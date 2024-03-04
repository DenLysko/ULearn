using System.Collections.Generic;
using Avalonia.Media;
using GeometryTasks;
using Color = Avalonia.Media.Color;

namespace GeometryPainting;

public static class SegmentExtension
{
    // Весьма сомнительное решение
    // держать в статическом класе все цвета отрезков,
    // но лучше чёт в голову ничего не пришло
    public static Dictionary<Segment, Color> ColorsOfSegments = new();

    public static void SetColor(this Segment segment, Color color)
    {
        ColorsOfSegments[segment] = color;
    }

    public static Color GetColor(this Segment segment)
    {
        return ColorsOfSegments.TryGetValue(segment, out Color result)
            ? result
            : Colors.Black;
    }
}