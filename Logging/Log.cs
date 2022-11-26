using System;
using System.Collections.Generic;
using BepInEx.Logging;

namespace RogueGenesiaModTemplate.Logging;

/// <summary>
/// Helper class that simplifies logging within your plugin.
/// </summary>
public static class Log
{
    private static readonly ManualLogSource logger;
    static Log()
    {
        logger = Logger.CreateLogSource(MyPluginInfo.PLUGIN_NAME);
    }
    
    public static void Info(object msg)
    {
        logger.LogInfo(msg);
    }

    public static void Debug(object msg)
    {
        logger.LogDebug(msg);
    }

    public static void Message(object msg)
    {
        logger.LogMessage(msg);
    }

    public static void Error(object msg)
    {
        logger.LogError(msg);
    }

    public static void Warn(object msg)
    {
        logger.LogWarning(msg);
    }
    
    /// <summary>
    /// A method that attempts to read through all fields and properties of the provided type and return
    /// a string that contains all that data.
    /// </summary>
    public static string StructToString<T>(T data)
    {
        var type = data.GetType();
        var fields = type.GetFields();
        var properties = type.GetProperties();

        var values = new Dictionary<string, object>();
        Array.ForEach(fields, (field) =>
        {
            values.TryAdd(field.Name, field.GetValue(data));
        });

        Array.ForEach(properties, (property) =>
        {
            values.TryAdd(property.Name, property.GetValue(data));
        });

        var lines = new List<string>();
        foreach (var value in values)
        {
            lines.Add($"\"{value.Key}\":\"{value.Value}\"");
        }

        return $"\"{type}\": " + "{" + String.Join(",", lines) + "}";
    }
}