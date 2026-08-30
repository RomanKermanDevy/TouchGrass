using System.Collections;
using UnityEngine;

namespace TouchGrass
{
    [KSPAddon(KSPAddon.Startup.MainMenu, false)]
    public sealed class TouchGrass : MonoBehaviour
    {
        private IEnumerator Start()
        {
            Debug.Log("[TouchGrass] Waiting for the main menu...");

            float deadline = Time.realtimeSinceStartup + 15f;

            while (FindObjectOfType<MainMenu>() == null &&
                   Time.realtimeSinceStartup < deadline)
            {
                yield return null;
            }

            Debug.Log("[TouchGrass] Touch grass.");

            while (true)
            {
                TextProButton3D[] buttons =
                    Resources.FindObjectsOfTypeAll<TextProButton3D>();

                foreach (TextProButton3D button in buttons)
                {
                    if (button == null)
                        continue;

                    GameObject buttonObject = button.gameObject;

                    if (!buttonObject.scene.IsValid())
                        continue;

                    buttonObject.SetActive(false);
                }

                yield return new WaitForSecondsRealtime(0.25f);
            }
        }
    }
}