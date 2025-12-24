using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace WebGLAutomation.Editor
{
    [InitializeOnLoad]
    public class WebGLAutomator
    {
        private const string LOGO_PATH = "Packages/com.havengrind.webgl-automation/Editor/CompanyLogo/Logo.png";
        static WebGLAutomator()
        {
            EditorApplication.update += EnsureSplashScreenSettings;
        }

        private static void EnsureSplashScreenSettings()
        {
            Sprite companyLogo = AssetDatabase.LoadAssetAtPath<Sprite>(LOGO_PATH);
            if (companyLogo == null)
            {
                LoadSpriteByGUID("663e506a625cf4a03ad45ace15fab71e");
            }

            if(companyLogo == null)
            {
                Debug.LogWarning($"[Haven Grind] cannot find Haven Grind logo: {LOGO_PATH}");
                return;
            }

            PlayerSettings.SplashScreen.show = true;

            PlayerSettings.SplashScreen.drawMode = PlayerSettings.SplashScreen.DrawMode.AllSequential;

            PlayerSettings.SplashScreenLogo[] currentLogos = PlayerSettings.SplashScreen.logos;

            if(InternalEditorUtility.HasFreeLicense())
            {
                bool isAlreadySet = currentLogos.Length >= 2 && currentLogos[1].logo == companyLogo;

                if (!isAlreadySet)
                {
                    // Kita buat array baru dengan ukuran 2
                    PlayerSettings.SplashScreenLogo[] newLogos = new PlayerSettings.SplashScreenLogo[2];

                    // Indeks 0: Biarkan kosong atau salin yang sudah ada 
                    // (Ini akan membuat logo Unity tampil sendirian di sekuen pertama)
                    newLogos[0] = new PlayerSettings.SplashScreenLogo
                    {
                        logo = PlayerSettings.SplashScreenLogo.unityLogo,
                        duration = 2f
                    };

                    // Indeks 1: Masukkan logo perusahaan kamu
                    newLogos[1] = new PlayerSettings.SplashScreenLogo
                    {
                        logo = companyLogo,
                        duration = 2f
                    };

                    // Masukkan kembali array baru ke PlayerSettings
                    PlayerSettings.SplashScreen.logos = newLogos;
                
                    Debug.Log("[Haven Grind] Splash Screen locked at Index 1 for Free License.");
                }
            }
        }

        private static Sprite LoadSpriteByGUID(string guid)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            return AssetDatabase.LoadAssetAtPath<Sprite>(path);
        }
    }
    
}
