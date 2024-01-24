using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FacebookLogic
{
    public class PrefferedUsersDetails
    {
        public bool IsAttractInMale { get; set; }
        public bool IsAttractInFemale { get; set; }
        public decimal MinAge { get; set; }
        public decimal MaxAge { get; set; }

        public PrefferedUsersDetails(decimal minAge, decimal maxAge, bool male, bool female)
        {
            IsAttractInMale = male;
            IsAttractInFemale = female;
            MinAge = minAge;
            MaxAge = maxAge;    
        }
    }
}
