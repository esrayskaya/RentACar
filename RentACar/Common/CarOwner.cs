using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class CarOwner : Counterpartie
    {
        private int cityLife;
        public int CityLife
        {
            get { return cityLife; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Код не может быть отрицательным или равным 0");
                }
                else cityLife = value;
            }
        }
        public CarOwner(Int64 drivanSertificate, string lastName, string firstName,
            string patronymic, Int64 passport, DateTime birthDay, int cityLife) 
            : base(drivanSertificate, lastName, firstName, patronymic, passport, birthDay)
        {
            CityLife = cityLife;
        }
    }
}
