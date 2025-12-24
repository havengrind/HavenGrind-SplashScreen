# Haven Grind Splash Screen Automator

A lightweight, robust Unity Editor extension designed to standardise and enforce Haven Grind Production branding on the Splash Screen. This package ensures that the **Haven Grind** logo is always present in every build, preventing accidental removal by developers.

## Features
* **Automated Setup**: Automatically configures the Splash Screen settings upon project load.
* **Strict Enforcement**: Uses `IPreprocessBuildWithReport` to re-apply the company logo immediately before the build process begins.
* **Optimised Performance**: Minimal CPU footprint by avoiding `Update` loops; it only runs when necessary.
* **Dual Logo Support**: Maintains the "Made with Unity" branding whilst adding the Haven Grind sequence.

## Installation

### Via Git URL
1. Open the **Package Manager** in Unity (`Window` > `Package Manager`).
2. Click the **+** button in the top-left corner.
3. Select **Add package from git URL...**.

<img width="182" height="136" alt="Screenshot 2025-12-24 at 22 46 55" src="https://github.com/user-attachments/assets/cacbf2f4-8f12-4e7f-a666-4f27fe4e70c3" />

4. Enter the following URL:
   `https://github.com/havengrind/HavenGrind-SplashScreen.git`
5. Click **Add**.

## How It Works
The script monitors the `PlayerSettings` and ensures that:
1. The Splash Screen is enabled.
2. The draw mode is set to `AllSequential`.
3. The Haven Grind logo (found at `Editor/CompanyLogo/Logo.png`) is assigned as the second logo in the sequence.

## Requirements
* Unity 2022.1 or higher.
* Logo file must be located at: `Editor/CompanyLogo/Logo.png` inside the package.
