using UnrealBuildTool;
using System.IO;
public class SteamLink : ModuleRules
{
	public SteamLink(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
		PublicIncludePaths.AddRange(new string[] { Path.Combine(ModuleDirectory, "Steamworks", "Include") });
		PrivateIncludePaths.AddRange(new string[] {});
		PublicDependencyModuleNames.AddRange(new string[] { "Core" });
		PrivateDependencyModuleNames.AddRange(new string[] { "CoreUObject","Engine","Slate","SlateCore", "Interfaces" });
		DynamicallyLoadedModuleNames.AddRange(new string[] {});
        if (Target.Platform == UnrealTargetPlatform.Win64) {
			PublicAdditionalLibraries.Add(Path.Combine(ModuleDirectory, "Steamworks", "steam_api64.lib"));
            PublicDelayLoadDLLs.Add("steam_api64.dll");
            RuntimeDependencies.Add(
				Path.Combine("$(TargetOutputDir)", "steam_api64.dll"), 
				Path.Combine(ModuleDirectory, "Steamworks", "steam_api64.dll")
				);
        }
    }
}
