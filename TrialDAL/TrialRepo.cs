using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialDAL
{
    public class TrialRepo
    {
        WeatherDBEntities weatherDBEntities;

        public TrialRepo()
        {
            weatherDBEntities = new WeatherDBEntities();
        }
    }
}
