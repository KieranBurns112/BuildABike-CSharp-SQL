// Kieran Burns
// Last edit: 22/03/2018
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_A_Bike_Program
{
    [Serializable]
    public class Customer
    {
        private String _name;
        private String _address;
        private String _email;

        public List<Bike> Bikes = new List<Bike>();

        public String Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public String Address
        {
            get
            {
                return _address;
            }

            set
            {
                _address = value;
            }
        }

        public String Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        public Bike findBike(int bikeNo)
        {
            foreach (Bike bikeFind in Bikes)
            {
                if (bikeNo == bikeFind.Bike_No)
                {
                    return bikeFind;
                }
            }
            return null;
        }
    }
}

