#region

using System;
using System.Collections.Generic;
using System.Linq;
using LeagueSharp;
using LeagueSharp.Common;

#endregion

namespace AutoLeveler
{
    class Program
    {
        private static Obj_AI_Hero Player;
        private static int[] AbilitySequence;

        static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += OnGameLoad;
        }

        private static void OnGameLoad(EventArgs args)
        {
            Player = ObjectManager.Player;

            switch(Player.ChampionName)
            {
                case "Annie":
                    AbilitySequence = new int[] { 1, 0, 1, 0, 1, 3, 2, 1, 1, 0, 3, 0, 0, 2, 2, 3, 2, 2 };
                    break;
                case "Caitlyn":
                    AbilitySequence = new int[] { 1, 2, 0, 0, 0, 3, 0, 2, 0, 2, 3, 2, 2, 1, 1, 3, 1, 1 };
                    break;
                case "Chogath":
                    AbilitySequence = new int[] { 2, 0, 2, 1, 2, 3, 2, 1, 2, 1, 3, 1, 1, 0, 0, 3, 0, 0 };
                    break;
                case "Ezreal":
                    AbilitySequence = new int[] { 0, 2, 0, 1, 0, 3, 0, 2, 0, 2, 3, 2, 2, 1, 1, 3, 1, 1 };
                    break;
                case "Graves":
                    AbilitySequence = new int[] { 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 3, 2, 2, 2, 1, 3, 1, 1 };
                    break;
                case "Jinx":
                    AbilitySequence = new int[] { 0, 1, 2, 0, 0, 3, 0, 1, 0, 1, 3, 1, 1, 2, 2, 3, 2, 2 };
                    break;
                case "Kogmaw":
                    AbilitySequence = new int[] { 1, 2, 1, 0, 1, 3, 1, 0, 1, 0, 3, 0, 0, 2, 2, 3, 2, 2 };
                    break;
                case "Orianna":
                    AbilitySequence = new int[] { 2, 0, 1, 0, 0, 3, 0, 1, 0, 1, 3, 1, 1, 2, 2, 3, 2, 2 };
                    break;
                case "Pantheon":
                    AbilitySequence = new int[] { 0, 1, 0, 2, 0, 3, 0, 2, 0, 2, 2, 2, 3, 2, 2, 3, 2, 2 };
                    break; 
                case "Ryze":
                    AbilitySequence = new int[] { 0, 1, 0, 2, 0, 3, 0, 1, 0, 1, 3, 1, 1, 2, 2, 3, 2, 2 };
                    break;
                case "Sivir":
                    AbilitySequence = new int[] { 1, 2, 0, 0, 0, 3, 0, 1, 0, 1, 3, 1, 1, 2, 2, 3, 2, 2 };
                    break;
                case "Syndra":
                    AbilitySequence = new int[] { 0, 2, 1, 0, 0, 3, 0, 2, 0, 2, 3, 2, 2, 1, 1, 3, 1, 1 };
                    break;
                case "Tristana":
                    AbilitySequence = new int[] { 2, 1, 2, 0, 2, 3, 0, 0, 0, 0, 3, 1, 1, 1, 1, 3, 2, 2 };
                    break;
                case "TwistedFate":
                    AbilitySequence = new int[] { 1, 0, 0, 2, 0, 3, 0, 1, 0, 1, 3, 1, 1, 2, 2, 3, 2, 2 };
                    break;
                case "Xerath":
                    AbilitySequence = new int[] { 0, 2, 0, 1, 0, 3, 0, 1, 0, 1, 3, 1, 1, 2, 2, 3, 2, 2 };
                    break;
                case "Ziggs":
                    AbilitySequence = new int[] { 0, 2, 1, 0, 0, 3, 0, 2, 0, 2, 3, 2, 2, 1, 1, 3, 1, 1 };
                    break;
            }

            if (AbilitySequence.Length == 18)
            {
                LevelSpellsUp(Player.Level);
                CustomEvents.Unit.OnLevelUp += OnLevelUp;
                Game.PrintChat("<font color='#fda74a'>>> Pingo's AutoLeveler loaded! <<");
            }
            else
                Game.PrintChat("<font color='#f0371e'>>> Error <<");
        }

        private static void OnLevelUp(Obj_AI_Base sender, CustomEvents.Unit.OnLevelUpEventArgs args)
        {
            if (sender.IsMe)
                LevelSpellsUp(args.NewLevel);
        }

        private static void LevelSpellsUp(int PlayerLevel)
        {
            int QL = Player.Spellbook.GetSpell(SpellSlot.Q).Level;
            int WL = Player.Spellbook.GetSpell(SpellSlot.W).Level;
            int EL = Player.Spellbook.GetSpell(SpellSlot.E).Level;
            int RL = Player.Spellbook.GetSpell(SpellSlot.R).Level;

            for (int i = (QL + WL + EL + RL); i < PlayerLevel; i++)
            {
                Player.Spellbook.LevelUpSpell((SpellSlot) AbilitySequence[i]);
            }
        }
    }
}
