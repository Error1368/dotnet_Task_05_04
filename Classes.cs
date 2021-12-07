using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classess
{
    public interface IBuilding
    {
        string Adress { get; set; }

        Dictionary<string, object> getParams();
        void Destruct();
    }

    public abstract class PublicBuilding : IBuilding
    {
        public enum State_E
        {
            OPEN,
            CLOSE,
            DESTRUCTED,
        }
        private int age = 0;
        private State_E state = State_E.CLOSE;
        private string address = "def addr";

        public int Age { get { return age; } set { age = value; } }
        public State_E State
        {
            get { return state; }
            set
            {
                if (state != State_E.DESTRUCTED && value != State_E.DESTRUCTED)
                    state = value;
            }
        }
        public string Adress { get { return address; } set { address = value; } }
        
        public void Destruct()
        {
            this.state = State_E.DESTRUCTED;
        }
        public virtual Dictionary<string, object> getParams()
        {
            Dictionary<string, object> parames = new Dictionary<string, object>();
            parames.Add("adress", this.Adress);
            parames.Add("age", this.Age);
            parames.Add("state", this.State);
            return parames;
        }

        public virtual bool checkValid()
        {
            // Я просто уже не знаю, что здесь придумать /(`>_<)\
            return Age >= 0 && address != "def addr";
        }

    }

    public class Theatre : PublicBuilding
    {
        private int max_viewer_count = 100;
        private int price = 100;
        private bool have_buffet = false;

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
        public override bool checkValid()
        {
            return base.checkValid() && Viewers > 0 && Price >= 0;
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
}
