using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperheroManager.Web.Utilities
{
    public static class SkillExtensions
    {
        public static IEnumerable<String> DeserializeSkills(String skills)
        {
            var values = skills?.Split(',') ?? Enumerable.Empty<String>();
            return values;
        }

        public static String SerializeSkills(IEnumerable<String> skills)
        {
            return String.Join(",", skills);
        }
    }
}