# Rogue Genesia Mod Template

This template is designed to make creating a Rogue Genesia mod easier.

## Enabling Mod Support in Rogue Genesia

To enable mod support in the game, you need to install BepInEx. 
Follow the instructions [here](https://docs.bepinex.dev/master/articles/user_guide/installation/unity_il2cpp.html) to install it.
Make sure you are getting the latest `Unity.IL2CPP-win-x64` version from their [Bleeding Edge Builds List](https://builds.bepinex.dev/projects/bepinex_be)!

**NOTE:** Make sure you start the game once after installing BepInEx to generate assemblies! 

## Creating your mod

1. Clone this repo
2. Rename [RogueGenesiaModTemplate.csproj](RogueGenesiaModTemplate.csproj) to your mods name.
3. Change the assembly name to your mods name, so the generated DLL file reflects that name.

That's it, you're ready to mod Rogue Genesia!

## FAQ (aka: How do I?)

### How do I log a debug message?

You can use the `Log` class from anywhere in your code. Just call `Log.Info()` and similar and it will log events with your Plugins name.

### How do I intercept game events?

BepInEx uses [HarmonyX](https://github.com/BepInEx/HarmonyX) for patching game code.

To intercept game functionality, you can do something like this:

```csharp
[HarmonyPatch(typeof(PauseMenu), nameof(PauseMenu.Open))]
public static class PauseMenuOpenPatches
{
    [HarmonyPrefix]
    public static void Prefix(PauseMenu __instance)
    {
        Log.Info($"Method called BEFORE Pause Menu opened in Game");
    }

    [HarmonyPostfix]
    public static void Postfix(PauseMenu __instance)
    {
        Log.Info($"Method called AFTER Pause Menu opened in Game");
    }
}
```

These patches will be automatically applied, since the template calls `Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());` on initialization. If you want to know more about what you can do with this, read the [HarmonyX Wiki](https://github.com/BepInEx/HarmonyX/wiki) or the original [Harmony Documentation](https://harmony.pardeike.net/articles/intro.html).

### How do I handle input events from the game?

Make sure you've copied `Unity.InputSystem.dll` from the `interop` folder and added it as a reference!

Then, create a new class that inherits from `MonoBehaviour`:

```csharp
public class InputHandler : MonoBehaviour {
    private void LateUpdate()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            Plugin.Log.LogInfo("R key was pressed this frame");
        } 
    }
}
```

Finally, in your `Plugin.Load` method, add it, so that Unity knows about it:

```csharp
public class Plugin : BasePlugin
{
    public override void Load()
    {
        // ... other code
        AddComponent<InputHandler>();
    }
}
```