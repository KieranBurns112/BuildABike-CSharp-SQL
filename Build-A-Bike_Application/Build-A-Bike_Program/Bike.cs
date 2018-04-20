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
    public class Bike
    {
        private int _bike_No;
        private int _frame_Size;
        private int _frame_Colour;
        private int _groupSet_Gears;
        private int _groupSet_Brakes;
        private int _wheels;
        private int _finishingSet_Handlebars;
        private int _finishingSet_Saddle;
        private bool _extendedWarranty;

        public int Bike_No
        {
            get
            {
                return _bike_No;
            }

            set
            {
                _bike_No = value;
            }
        }

        public int Frame_Size
        {
            get
            {
                return _frame_Size;
            }

            set
            {
                _frame_Size = value;
            }
        }

        public int Frame_Colour
        {
            get
            {
                return _frame_Colour;
            }

            set
            {
                _frame_Colour = value;
            }
        }

        public int GroupSet_Gears
        {
            get
            {
                return _groupSet_Gears;
            }

            set
            {
                _groupSet_Gears = value;
            }
        }

        public int GroupSet_Brakes
        {
            get
            {
                return _groupSet_Brakes;
            }

            set
            {
                _groupSet_Brakes = value;
            }
        }

        public int Wheels
        {
            get
            {
                return _wheels;
            }

            set
            {
                _wheels = value;
            }
        }

        public int FinishingSet_Handlebars
        {
            get
            {
                return _finishingSet_Handlebars;
            }

            set
            {
                _finishingSet_Handlebars = value;
            }
        }

        public int FinishingSet_Saddle
        {
            get
            {
                return _finishingSet_Saddle;
            }

            set
            {
                _finishingSet_Saddle = value;
            }
        }

        public bool ExtendedWarranty
        {
            get
            {
                return _extendedWarranty;
            }

            set
            {
                _extendedWarranty = value;
            }
        }
    }
}
