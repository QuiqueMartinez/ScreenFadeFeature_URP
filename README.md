# ScreenFadeFeature_URP

## Quick Start

Copy all scripts into a folder in your Unity project (e.g. Assets/ScreenFade/)

Add the Render Feature to your URP Renderer:

Go to your URP Renderer asset

Under Render Features, click Add Feature → choose ScreenFadeRenderFeature

Add ScreenFade.cs to a GameObject in your scene (e.g. an empty object called ScreenFadeController)

Call ScreenFade.Instance.FadeIn() or FadeOut() as needed.

You may need to adjust or extend ScreenFade.cs depending on your project setup.


## Why this instead of Canvas/Spheres around camera hacks?

Works with XR and non-XR setups

No need to deal with render order issues or canvas layering

No weird sphere occlusion tricks

Clean, native URP integration
