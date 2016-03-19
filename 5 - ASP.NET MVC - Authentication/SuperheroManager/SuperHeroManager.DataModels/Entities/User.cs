using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperHeroManager.DataModels.Common;

namespace SuperHeroManager.DataModels.Entities
{
    public class User : EntityBase
    {
        public String Username { get; set; }

        public String Password { get; set; }
    }
}
