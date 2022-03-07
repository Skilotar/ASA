using ItemAPI;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using MonoMod.RuntimeDetour;
using UnityEngine;
using Dungeonator;
using UnityEngine.UI;




namespace AutoSemiAuto
{
    
    public class Module : ETGModule
    {
        public static string ZipFilePath;
        public static string FilePath;
        public static readonly string MOD_NAME = "AutoSemiAuto";
        public static readonly string VERSION = "1.0.0";
        public static readonly string TEXT_COLOR = "#5deba4";

       
        public override void Start()
        {
            try
            {
                
                ItemAPI.FakePrefabHooks.Init();
                ItemAPI.Tools.Init();
                ItemBuilder.Init();
                Hooks.Init();
                

               
                Log($"{MOD_NAME} v{VERSION} is running", TEXT_COLOR);
               
                



            }
            catch (Exception e)
            {
                ETGModConsole.Log($"<color=#{TEXT_COLOR}>{MOD_NAME}: {e.Message}</color>");
                ETGModConsole.Log(e.StackTrace);

                Log(e.Message);
                Log("\t" + e.StackTrace);
                Log($"Something in AutoSemiAuto broke somewhere...", TEXT_COLOR);
                Log($"If you're reading this please tell me at the gungeon discord and screenshot the error.", TEXT_COLOR);
            }


        }

       
        public static void Log(string text, string color= "#5deba4")
        {
            ETGModConsole.Log($"<color={color}>{text}</color>");
        }

        public static void RunStartHook(Action<PlayerController, float> orig, PlayerController self, float invisibleDelay)
        {
            orig(self, invisibleDelay);
            self.gameObject.GetOrAddComponent<PlayerAutomaticSemiAutomatic>();
            
        }
       
        public override void Exit() 
        { 
        
        }
        public override void Init() 
        {

        }
    }
}
