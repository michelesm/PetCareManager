using Android.App;
using Android.Content.PM;
using Microsoft.Maui;

namespace PetCareManager;

[Activity(Label = "PetCareManager", Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode)]
public class MainActivity : MauiAppCompatActivity
{
}