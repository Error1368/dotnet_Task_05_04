using System.Collections.Generic;
using bases;

namespace classess
{

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
