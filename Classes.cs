using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classess
{
    public enum State_E
    {
        OPEN,
        CLOSE,
        REPAIR,
        DESTRUCTED,
    }
    public interface IBuilding
    {
        string Adress { get; set; }
        Dictionary<string, object> getParams();
        void Destruct();
    }

    public abstract class PublicBuilding : IBuilding
    {
        public PublicBuilding(int age, string adress)
        {
            Adress = adress;
            Age = age;
        }
        
        private State_E state = State_E.CLOSE;

        public int Age { get; set; }
        public string Adress { get; set; }
        public State_E State { get { return state; } }

        public void Destruct()
        {
            state = State_E.DESTRUCTED;
        }

        public virtual void Repair() {
            state = State_E.REPAIR;
        }

        public void Open_or_close(bool is_open)
        {
            if (is_open && state == State_E.CLOSE)
                state = State_E.OPEN;
            else if (!is_open && state == State_E.OPEN)
                state = State_E.CLOSE;
        }

        public virtual Dictionary<string, object> getParams()
        {
            Dictionary<string, object> parames = new Dictionary<string, object>();
            parames.Add("adress", this.Adress);
            parames.Add("age", this.Age);
            parames.Add("state", this.State);
            return parames;
        }

    }

    public class Theatre : PublicBuilding
    {
        private int max_viewer_count;
        private int price;
        private bool have_buffet = false;

        public Theatre(int age, string adress, int max_viewer_count, int price):base(age, adress)
        {
            this.max_viewer_count = max_viewer_count;
            this.price = price;
        }

        public int Viewers { get { return max_viewer_count; } }
        public int Price { get { return price; } }
        public bool Buffet { get { return have_buffet; } }

        public override Dictionary<string, object> getParams()
        {
            Dictionary<string, object> parames = base.getParams();
            parames.Add("viewers", Viewers);
            parames.Add("price", Price);
            return parames;
        }
        private bool checkValid()
        {
            return Viewers > 0 && Price >= 0;
        }

        public void expand_hall()
        {
            max_viewer_count += 50;
            price -= 10;
            if (!checkValid())
            {
                max_viewer_count -= 50;
                price += 10;
            }
        }
        public void add_buffet()
        {
            if (!Buffet)
            {
                have_buffet = true;
                price += 25;
            }
        }
    }

    public class Shop : PublicBuilding
    {
        
        public Shop(int age, string adress, string name, string product) : base(age, adress)
        {
            Name = name;
            Product = product;
        }

        public string Name { get; set; }
        public string Product { get; set; }
        
        public override Dictionary<string, object> getParams()
        {
            Dictionary<string, object> parames = base.getParams();
            parames.Add("name", Name);
            parames.Add("product", Product);
            return parames;
        }
    }

    public class Bank : PublicBuilding
    {

        public Bank(int age, string adress, int capital, int percent) : base(age, adress)
        {
            Capital = capital;
            Percent = percent;
        }

        public int Capital { get; set; }
        public int Percent { get; set; }

        public int Deposit_for_the_year(int deposit)
        {
            int res = (int)(deposit * (1.0 + Percent/100.0));
            return res >= Capital + deposit ? res : Capital + deposit;
        }

        public override Dictionary<string, object> getParams()
        {
            Dictionary<string, object> parames = base.getParams();
            parames.Add("capital", Capital);
            parames.Add("percent", Percent);
            return parames;
        }
    }
}
