﻿namespace QueteDuDragon.Data.Monstres
{
    public class Squelettes : Monstre
    {
        public Squelettes() : base("Squelettes", 50, "squelettes.png")
        {
            InitializeSkills();
        }

        public override void InitializeSkills()
        {
            Skills.Add("Coup lourd");
            Skills.Add("Résistance osseuse");
        }
    }
}