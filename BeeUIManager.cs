using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR;

namespace BeePro
{
	internal class BeeUIManager : MonoBehaviour
	{
		private void Start()
		{
			bee = BeeProManager.instance;
			Button[] allButtons = GetAllButtons(transform);
			allButtons[0].gameObject.AddComponent<UIButtonBehaviour>();
			allButtons[0].onClick.AddListener(new UnityAction(ToggleFPV));
			allButtons[1].gameObject.AddComponent<UIButtonBehaviour>();
			allButtons[1].onClick.AddListener(new UnityAction(ToggleSmoothing));
			allButtons[2].gameObject.AddComponent<UIButtonBehaviour>();
			allButtons[2].onClick.AddListener(new UnityAction(TogglePlayerLook));
			allButtons[3].gameObject.AddComponent<UIButtonBehaviour>();
			allButtons[3].onClick.AddListener(new UnityAction(ToggleLocalSpace));
			allButtons[4].gameObject.AddComponent<UIButtonBehaviour>();
			allButtons[4].onClick.AddListener(new UnityAction(ToggleFreeCam));
			allButtons[5].gameObject.AddComponent<UIButtonBehaviour>();
			allButtons[5].onClick.AddListener(new UnityAction(ToggleHideBee));
			allButtons[6].gameObject.AddComponent<UIButtonBehaviour>();
			allButtons[6].onClick.AddListener(new UnityAction(ToggleHideCosmetics));
			lR = EasyAssetLoading.SetupAsset(Assembly.GetExecutingAssembly(), "BeePro.beepro", "pointer", GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget, false).GetComponent<LineRenderer>();
		}

		// Linq doesn't decompile, so screw you Antoca
		private Button[] GetAllButtons(Transform source)
		{
			List<Button> res = new List<Button>();
			for (int i = 0; i < 3; i++)
			{
				List<Button> list = source.GetChild(i).GetComponentsInChildren<Button>().ToList<Button>();

                foreach (Button button in list)
					res.Add(button);
			}
			return res.ToArray();
		}

		private void ToggleFPV()
		{
			bee.fp = !bee.fp;
		}

		private void ToggleSmoothing()
		{
			bee.smoothing = !bee.smoothing;
		}

		private void TogglePlayerLook()
		{
			bee.playerLook = !bee.playerLook;
		}

		private void ToggleLocalSpace()
		{
			bee.localSpace = !bee.localSpace;
		}

		private void ToggleFreeCam()
		{
			bee.freecamEnabled = !bee.freecamEnabled;
		}

		private void ToggleHideBee()
		{
			bee.hideBee = !bee.hideBee;
		}

		private void ToggleHideCosmetics()
		{
			bee.hideCosmetics = !bee.hideCosmetics;
		}

		

		private BeeProManager bee;
        private LineRenderer lR;

        private bool canOpen = false;
		private bool canClick = false;
		private bool isActive = false;

		private float lastDistance;
	}
}
