using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LinQEinfuehrung2.models
{
    public class Customer
    {
        private int _id;
        private DateTime _birthdate;
        private List<Address> _addresses;
        private decimal _capital;
        public int Id
        {
            get { return _id; }
            set
            {
                if(value >= 0)
                {
                    _id = value;
                }

            }
        }

        public decimal Capital
        {
            get { return _capital; }
            set { if(value >= 0.0m)
                {
                    this._capital = value;
                } 
            }
        }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public EGender Gender { get; set; }

        //ctor
        public Customer():this(0,"","",DateTime.MinValue, 0.0m, EGender.notSpecified)
        {

        }

        public Customer(int id, string firstname, string lastname, DateTime birthdate, decimal capital, EGender gender)
        {
            this.Id = id;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Birthdate = birthdate;
            this.Capital = capital;
            this.Gender = gender;
        }
        public DateTime Birthdate
        {
            get { return _birthdate; }
            set { if (value < DateTime.Now)
                {
                    this._birthdate= value;
                } 
            }
        }

        public List<Address> Addresses
        {
            get { return _addresses; }
        }

        public bool AddAddress(Address address)
        {
            if (this._addresses == null)
            {
                this._addresses = new List<Address>();
            }
            this._addresses.Add(address);
            return true;
        }

        public bool RemoveAddress(int id)
        {
            foreach(Address address in this._addresses)
            {
                if(address.Id == id)
                {
                    return this._addresses.Remove(address);
                }
            }
            return false;
        }

        public override string ToString()
        {
            return this.Id+"\t"+this.Firstname+"\t"+this.Lastname+"\t"+this.Birthdate+"\t"+this.Capital+"\t"+this.Gender;
        }

    }
}
