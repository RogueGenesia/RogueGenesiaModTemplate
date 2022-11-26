using System.IO;
using System.Reflection;
using BepInEx;

namespace RogueGenesiaModTemplate;

public static class Paths
{
    /// <summary>
    /// The full path of your plugin. Attempts to get it from the calling assembly, but falls back to BepInEx's
    /// <see cref="BepInEx.Paths.PluginPath"/> combined with your plugin name.
    /// </summary>
    public static readonly string PluginPath = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location) ??
                                               Path.Combine(BepInEx.Paths.PluginPath, MyPluginInfo.PLUGIN_NAME);
}