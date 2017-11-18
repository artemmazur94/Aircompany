using System.Collections.Generic;
using Aircompany.DataAccess.Entities;

namespace Aircompany.Web.Helpers
{
    public static class PlaneHelper
    {
        public static Dictionary<int, Dictionary<int, int>> CreatePlanePlan(List<Sector> sectors)
        {
            var planePlan = new Dictionary<int, Dictionary<int, int>>();
            foreach (Sector sector in sectors)
            {
                for (int i = sector.FromRow; i <= sector.ToRow; i++)
                {
                    if (!planePlan.ContainsKey(i))
                    {
                        planePlan.Add(i, new Dictionary<int, int>());
                    }
                    for (int j = sector.FromPlace; j <= sector.ToPlace; j++)
                    {
                        planePlan[i].Add(j, sector.SeatTypeId);
                    }
                }
            }
            return planePlan;
        }
    }
}