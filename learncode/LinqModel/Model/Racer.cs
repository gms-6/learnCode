using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learncode.LinqModel.Model
{
    public class Racer : IComparable<Racer>, IFormattable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Wins { get; set; }
        public string Country { get; set; }
        public int Starts { get; set; }
        public IEnumerable<string> Cars { get; private set; }
        public IEnumerable<int> Years { get; private set; }
        public Racer(string firstName, string lastName, string country, int starts, int wins):this(firstName, lastName, country, starts, wins,null,null)
        {

        }
        public Racer(string firstName, string lastName, string country, int starts, int wins, IEnumerable<int> years, IEnumerable<string> cars)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Country = country;
            this.Starts = starts;
            this.Wins = wins;
            this.Years = new List<int>( years);
            this.Cars = new List<string>(cars);
        }

        public override string ToString()
        {
            return String.Format($"{FirstName}  {LastName}") ;
        }


        public string ToString(string format)
        {
            return ToString(format,null);
        }

        public string ToString(string format,IFormatProvider formatProvider)
        {
            switch(format)
            {
                case null:
                case "N":
                    return ToString();
                case "F":
                    return FirstName;
                case "L":
                    return LastName;
                case "C":
                    return Country;
                case "S":
                    return Starts.ToString();
                case "W":
                    return Wins.ToString();
                case "A":
                    return String.Format($"{FirstName} {LastName} {Country}; starts:{Starts} ,wins:{Wins}");
                default:
                    throw new FormatException(String.Format($"Format {format} not supported"));
            }
        }


        public int CompareTo(Racer other)
        {
            if (other == null) return -1;
            return string.Compare(this.LastName,other.LastName);
        }

        
    }
}
