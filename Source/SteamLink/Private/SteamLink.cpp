#include "SteamLink.h"
#include "Interfaces/IPluginManager.h"
#include "Misc/Paths.h"

#define LOCTEXT_NAMESPACE "FSteamLinkModule"

void FSteamLinkModule::StartupModule() 
{
	FString BaseDir = IPluginManager::Get().FindPlugin("SteamLink")->GetBaseDir();
	FString DLLPath = FPaths::Combine(*BaseDir, TEXT("Binaries/steam_api64.dll"));
	DLLHandle = !DLLPath.IsEmpty() ? FPlatformProcess::GetDllHandle(*DLLPath) : nullptr;
	if (DLLHandle)
	{
		UE_LOG(LogTemp, Log, TEXT("Steam DLL loaded successfully."));
	}
	else
	{
		UE_LOG(LogTemp, Error, TEXT("Failed to load Steam DLL."));
	}
}

void FSteamLinkModule::ShutdownModule() 
{
	FPlatformProcess::FreeDllHandle(DLLHandle);
	DLLHandle = nullptr;
}

#undef LOCTEXT_NAMESPACE
	
IMPLEMENT_MODULE(FSteamLinkModule, SteamLink)