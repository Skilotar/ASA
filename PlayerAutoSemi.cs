using System;
using ItemAPI;
using UnityEngine;
using System.Collections;


namespace AutoSemiAuto
{
	public class PlayerAutomaticSemiAutomatic : MonoBehaviour
	{

		public PlayerAutomaticSemiAutomatic()
		{
		

		}

		
		public bool Key(GungeonActions.GungeonActionType action, PlayerController user)
		{
			return BraveInput.GetInstanceForPlayer(user.PlayerIDX).ActiveActions.GetActionFromType(action).IsPressed;
		}

		private void Start()
		{
			this.player = base.GetComponent<PlayerController>();

		}


		private void Update()
		{
			
			Gun thisone = player.CurrentGun;
			if (thisone.DefaultModule.shootStyle == ProjectileModule.ShootStyle.SemiAutomatic && Time.timeScale > 0f)
			{
				if (Key(GungeonActions.GungeonActionType.Shoot, player))
				{
					thisone.Attack();
				}

			}

		}




		public bool theatrefreebegotten;



		private PlayerController player;
	}
}
