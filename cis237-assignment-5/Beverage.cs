using System;

namespace cis237_assignment_5
{
    class Beverage
    {
        // Private Class Level Variables
        private string id;
        private string name;
        private string pack;
        private decimal price;
        private bool active;

        // Public Property to get the Id
        public string Id
        {
            get
            {
                return this.id;
            }
        }

        // Default Constructor
        public Beverage() { }

        // 5 Parameter Constructor
        public Beverage(string id, string name, string pack, decimal price, bool active)
        {
            this.id = id;
            this.name = name;
            this.pack = pack;
            this.price = price;
            this.active = active;
        }

        // Override ToString Method to concatenate the fields together.
        public override string ToString()
        {
            return String.Format(
                "{0,6} {1,-55} {2,-15} {3,6} {4,-6}",
                this.id,
                this.name,
                this.pack,
                this.price,
                this.active ? "True" : "False"
            );
        }
    }
}
