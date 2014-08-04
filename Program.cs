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
        private static SpellSlot[] AbilitySequence;

        static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += OnGameLoad;
        }

        private static void OnGameLoad(EventArgs args)
        {
            Player = ObjectManager.Player;

            switch(Player.BaseSkinName)
            {
                case "Caitlyn":
                    AbilitySequence = new SpellSlot[] { SpellSlot.W, SpellSlot.E, SpellSlot.Q, SpellSlot.Q, SpellSlot.Q, SpellSlot.R, SpellSlot.Q, SpellSlot.E, SpellSlot.Q, SpellSlot.E, SpellSlot.R, SpellSlot.E, SpellSlot.E, SpellSlot.W, SpellSlot.W, SpellSlot.R, SpellSlot.W, SpellSlot.W };
                    break;
                case "Chogath":
                    AbilitySequence = new SpellSlot[] { SpellSlot.E, SpellSlot.Q, SpellSlot.E, SpellSlot.W, SpellSlot.E, SpellSlot.R, SpellSlot.E, SpellSlot.W, SpellSlot.E, SpellSlot.W, SpellSlot.R, SpellSlot.W, SpellSlot.W, SpellSlot.Q, SpellSlot.Q, SpellSlot.R, SpellSlot.Q, SpellSlot.Q };
                    break;
                case "Ezreal":
                    AbilitySequence = new SpellSlot[] { SpellSlot.Q, SpellSlot.E, SpellSlot.Q, SpellSlot.W, SpellSlot.Q, SpellSlot.R, SpellSlot.Q, SpellSlot.E, SpellSlot.Q, SpellSlot.E, SpellSlot.R, SpellSlot.E, SpellSlot.E, SpellSlot.W, SpellSlot.W, SpellSlot.R, SpellSlot.W, SpellSlot.W };
                    break;
                case "Graves":
                    AbilitySequence = new SpellSlot[] { SpellSlot.Q, SpellSlot.E, SpellSlot.Q, SpellSlot.W, SpellSlot.Q, SpellSlot.R, SpellSlot.Q, SpellSlot.W, SpellSlot.Q, SpellSlot.E, SpellSlot.R, SpellSlot.E, SpellSlot.E, SpellSlot.E, SpellSlot.W, SpellSlot.R, SpellSlot.W, SpellSlot.W };
                    break;
                case "Jinx":
                    AbilitySequence = new SpellSlot[] { SpellSlot.Q, SpellSlot.W, SpellSlot.E, SpellSlot.W, SpellSlot.W, SpellSlot.R, SpellSlot.W, SpellSlot.Q, SpellSlot.W, SpellSlot.Q, SpellSlot.R, SpellSlot.Q, SpellSlot.Q, SpellSlot.E, SpellSlot.E, SpellSlot.R, SpellSlot.E, SpellSlot.E };
                    break;
                case "Orianna":
                    AbilitySequence = new SpellSlot[] { SpellSlot.E, SpellSlot.Q, SpellSlot.W, SpellSlot.Q, SpellSlot.Q, SpellSlot.R, SpellSlot.Q, SpellSlot.W, SpellSlot.Q, SpellSlot.W, SpellSlot.R, SpellSlot.W, SpellSlot.W, SpellSlot.E, SpellSlot.E, SpellSlot.R, SpellSlot.E, SpellSlot.E };
                    break; 
                case "Ryze":
                    AbilitySequence = new SpellSlot[] { SpellSlot.Q, SpellSlot.W, SpellSlot.Q, SpellSlot.E, SpellSlot.Q, SpellSlot.R, SpellSlot.Q, SpellSlot.W, SpellSlot.Q, SpellSlot.W, SpellSlot.R, SpellSlot.W, SpellSlot.W, SpellSlot.E, SpellSlot.E, SpellSlot.R, SpellSlot.E, SpellSlot.E };
                    break;
                case "Sivir":
                    AbilitySequence = new SpellSlot[] { SpellSlot.W, SpellSlot.E, SpellSlot.Q, SpellSlot.Q, SpellSlot.Q, SpellSlot.R, SpellSlot.Q, SpellSlot.W, SpellSlot.Q, SpellSlot.W, SpellSlot.R, SpellSlot.W, SpellSlot.W, SpellSlot.E, SpellSlot.E, SpellSlot.R, SpellSlot.E, SpellSlot.E };
                    break;
                case "Syndra":
                    AbilitySequence = new SpellSlot[] { SpellSlot.Q, SpellSlot.W, SpellSlot.Q, SpellSlot.E, SpellSlot.Q, SpellSlot.R, SpellSlot.Q, SpellSlot.E, SpellSlot.Q, SpellSlot.E, SpellSlot.R, SpellSlot.E, SpellSlot.E, SpellSlot.W, SpellSlot.W, SpellSlot.R, SpellSlot.W, SpellSlot.W };
                    break;
                case "Tristana":
                    AbilitySequence = new SpellSlot[] { SpellSlot.E, SpellSlot.W, SpellSlot.E, SpellSlot.Q, SpellSlot.E, SpellSlot.R, SpellSlot.Q, SpellSlot.Q, SpellSlot.Q, SpellSlot.Q, SpellSlot.R, SpellSlot.W, SpellSlot.W, SpellSlot.W, SpellSlot.W, SpellSlot.R, SpellSlot.E, SpellSlot.E };
                    break;
                case "TwistedFate":
                    AbilitySequence = new SpellSlot[] { SpellSlot.W, SpellSlot.Q, SpellSlot.Q, SpellSlot.E, SpellSlot.Q, SpellSlot.R, SpellSlot.Q, SpellSlot.W, SpellSlot.Q, SpellSlot.W, SpellSlot.R, SpellSlot.W, SpellSlot.W, SpellSlot.E, SpellSlot.E, SpellSlot.R, SpellSlot.E, SpellSlot.E };
                    break;
                case "Ziggs":
                    AbilitySequence = new SpellSlot[] { SpellSlot.Q, SpellSlot.E, SpellSlot.W, SpellSlot.Q, SpellSlot.Q, SpellSlot.R, SpellSlot.Q, SpellSlot.E, SpellSlot.Q, SpellSlot.E, SpellSlot.R, SpellSlot.E, SpellSlot.E, SpellSlot.W, SpellSlot.W, SpellSlot.R, SpellSlot.W, SpellSlot.W };
                    break;
            }

            if (AbilitySequence.Length == 18)
            {
                Game.PrintChat("<font color='#fda74a'>>> Pingo's AutoLeveler loaded! <<");
                Game.OnGameUpdate += OnGameUpdate;
            }
            else
                Game.PrintChat("<font color='#f0371e'>>> Error <<");
        }

        private static void OnGameUpdate(EventArgs args)
        {
            int QL = Player.Spellbook.GetSpell(SpellSlot.Q).Level;
            int WL = Player.Spellbook.GetSpell(SpellSlot.W).Level;
            int EL = Player.Spellbook.GetSpell(SpellSlot.E).Level;
            int RL = Player.Spellbook.GetSpell(SpellSlot.R).Level;

            if ((QL + WL + EL + RL) < Player.Level)
            {
                for (int i = (QL + WL + EL + RL); i < Player.Level; i++)
                {
                    Player.Spellbook.LevelUpSpell(AbilitySequence[i]);
                }
            }
        }
    }
}
