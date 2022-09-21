using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQEinfuehrung2.models
{
    public class Address
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set
            {
                if (value >= 0)
                {
                    _id = value;
                }

            }
        }
        public string Postalcode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Streetnumber { get; set; }

        public Address() : this(0, "","","","")
        {

        }

        public Address(int id, string postalcode, string city, string street, string streetnumber)
        {
            this._id = id;
            this.Postalcode = postalcode;
            this.City = city;
            this.Street = street;
            this.Streetnumber = streetnumber;
        }

        public override string ToString()
        {
            return this.Id+"\t"+this.Postalcode+"\t"+this.City+"\t"+this.Street+"\t"+this.Streetnumber;
        }
    }
}
