﻿namespace QueteDuDragon.Data.Monstres
{
    public class Araignees : Monstre
    {
        public Araignees() : base("Araignées", 40, "araignees.png")
        {
            InitializeSkills();
        }

        public override void InitializeSkills()
        {
            Skills.Add("Morsure venimeuse");
            Skills.Add("Tir de toile");
        }
    }
}