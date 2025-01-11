﻿namespace QueteDuDragon.Data.Heroes;

public class Thief : Hero
    {
        public Thief(): base("Voleur"){}
        public override void InitializeSkills()
        {
            Skills.Add("Flèche empoisonnée");
            Skills.Add("Piège");
            Skills.Add("Disparition");
        }
    }
