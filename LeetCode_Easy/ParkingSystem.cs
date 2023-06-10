using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_Easy
{   
    public class ParkingSystem // 1603. Design Parking System
    {
        Dictionary<int, int> dictator = new Dictionary<int, int>() ;

        public ParkingSystem(int big, int medium, int small)
        {
            dictator.Add(1, big);
            dictator.Add(2, medium);
            dictator.Add(3, small);
        }

        public bool AddCar(int carType)
        {
            if (dictator[carType] != 0)
            {
                dictator[carType]--;
                return true;
            }
            return false;
        }
    }
}
