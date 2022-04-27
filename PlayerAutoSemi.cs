using System;
using ItemAPI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AutoSemiAuto
{
	public class PlayerAutomaticSemiAutomatic : MonoBehaviour
	{

		public PlayerAutomaticSemiAutomatic()
		{
		

		}
		public float KeyTime(GungeonActions.GungeonActionType action, PlayerController user)
		{
			return BraveInput.GetInstanceForPlayer(user.PlayerIDX).ActiveActions.GetActionFromType(action).PressedDuration;
		}

		public bool Key(GungeonActions.GungeonActionType action, PlayerController user)
		{
			return BraveInput.GetInstanceForPlayer(user.PlayerIDX).ActiveActions.GetActionFromType(action).IsPressed;
		}

		private void Start()
		{
			this.player = base.GetComponent<PlayerController>();

		}

		bool isModdedException = false;
		private void Update()
		{
			isModdedException = false;
			Gun thisone = player.CurrentGun;
			foreach(String ModdedExcept in Modded_Exceptions)
            {
				if(PickupObjectDatabase.GetByEncounterName(ModdedExcept) != null)
                {
					if(thisone.PickupObjectId == PickupObjectDatabase.GetByEncounterName(ModdedExcept).PickupObjectId)
                    {
						isModdedException = true;
                    }
                }
            }
																							
			if (thisone.DefaultModule.shootStyle == ProjectileModule.ShootStyle.SemiAutomatic && thisone.PickupObjectId != PickupObjectDatabase.GetById(274).PickupObjectId && !isModdedException && Time.timeScale > 0f && thisone.enabled && player.IsGunLocked == false && player.CurrentStoneGunTimer == 0 && player.IsDodgeRolling == false)
			{
				if (Key(GungeonActions.GungeonActionType.Shoot, player) && KeyTime(GungeonActions.GungeonActionType.Shoot, player) >= .1f && !Key(GungeonActions.GungeonActionType.GunQuickEquip,player) && !Key(GungeonActions.GungeonActionType.EquipmentMenu, player) && !Key(GungeonActions.GungeonActionType.Map, player))
				{
					thisone.Attack();
				}

			}

		}

		public List<string> Modded_Exceptions = new List<string>
		{
			"First Impression",
			""
		};


		public bool theatrefreebegotten;



		private PlayerController player;
	}
}
