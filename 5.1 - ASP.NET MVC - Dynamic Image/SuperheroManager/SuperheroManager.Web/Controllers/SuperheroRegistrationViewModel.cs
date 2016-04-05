using System;
using System.Collections.Generic;

namespace SuperheroManager.Web.Controllers
{
    public class SuperheroRegistrationViewModel
    {
        public String Name { get; set; }

        public String NewSkill { get; set; }

        public List<String> Skills { get; set; }

        public List<String> AvailableTeams { get; set; }

        public List<String> CurrentTeams { get; set; }

        public SuperheroRegistrationViewModel()
        {
            Skills = new List<String>();
            AvailableTeams = new List<String>();
            CurrentTeams = new List<String>();
        }

        public SuperheroRegistrationViewModel(SuperheroRegistrationViewModel other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));

            Name = other.Name;
            NewSkill = other.NewSkill;
            Skills = other.Skills;
            AvailableTeams = other.AvailableTeams;
            CurrentTeams = other.CurrentTeams;
        }
    }
}