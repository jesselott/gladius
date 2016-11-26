using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator
{
    public class Fighter
    {
        //Fighter class fields
        #region Fighter fields
        private string fName/*CharactersName*/;
        private int fHP/*CurrentHitPoints*/, fMHP/*MaxHitPoints*/, fXP/*ExperiencePoints*/, fLvl/*Level*/, 
            fStr/*Strength*/, fAgl/*Agility*/, fInt/*Intelligence*/, fLck/*Luck*/, fChr/*Charisma*/,
            fCon/*Constitution*/, fSpr/*Spirit*/, fFry/*Fury*/, fNot/*Noteriety*/, fFam/*Fame*/,
            fMny/*Money*/;
        #endregion

        //Fighter class properties
        #region Fighter Class Props

        public string Name
        { get { return fName; } set { fName = value; } }

        public int Strength
        { get { return fStr; } set { fStr = value; } }

        public int Agility
        { get { return fAgl; } set { fAgl = value; } }

        public int Intelligence
        { get { return fInt; } set { fInt = value; } }

        public int Luck
        { get { return fLck; } set { fLck = value; } }

        public int Charisma
        { get { return fChr; } set { fChr = value; } }

        public int Constitution
        { get { return fCon; } set { fCon = value; } }

        public int Spirit
        { get { return fSpr; } set { fSpr = value; } }

        public int Fury
        { get { return fFry; } set { fFry = value; } }

        public int Notoriety
        { get { return fNot; } set { fNot = value; } }

        public int Fame
        { get { return fFam; } set { fFam = value; } }

        public int Money
        { get { return fMny; } set { fMny = value; } }

        public int CurrentHitPoints
        { get { return fHP; } set { fHP = value; } }

        public int MaxHitPoints
        { get { return fMHP; } set { fMHP = value; } }

        public int ExperiencePoints
        { get { return fXP; } set { fXP = value; } }

        public int Level
        { get { return fLvl; } set { fLvl = value; } }
        #endregion

        //Fighter base constructor
        #region Fighter Ctor, uses a dictionary built in the Roller class to add the core stats to fields and props
        
        public Fighter(Dictionary<string, int>RollCharStats)
        {
           int value;
            Name = "Glad Jr.";
            if (RollCharStats.TryGetValue("Strength", out value))
            { Strength = value; }
            if (RollCharStats.TryGetValue("Agility", out value))
            { Agility = value; }
            if (RollCharStats.TryGetValue("Intelligence", out value))
            { Intelligence = value; }
            if (RollCharStats.TryGetValue("Luck", out value))
            { Luck = value; }
            if (RollCharStats.TryGetValue("Charisma", out value))
            { Charisma = value; }
            if (RollCharStats.TryGetValue("Constitution", out value))
            { Constitution = value; }
            Spirit = 0;
            Fury = 0;
            Notoriety = 0;
            Fame = 0;
            Money = 500;
            if (RollCharStats.TryGetValue("CurrentHitPoints", out value))
            { MaxHitPoints = value; }
            if (RollCharStats.TryGetValue("MaxHitPoints", out value))
            { MaxHitPoints = value; }
            ExperiencePoints = 0;
            Level = 1;                          
        }
        #endregion

    }//end Fighter Class


}//end namespace
