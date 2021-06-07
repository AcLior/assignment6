using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment6
{  
    class Social:AppSystem,IApp // יורשת מאפ-סיסטם ומהממשק שלנו
    {
        int rating; // דירוג
        bool isOrg; // האם שייך לארגון

        public int Rating
        {
            get => rating;
            set
            {
                if (value>5||value<1)
                {
                    throw new ArgumentNullException("Rating's range is 1-5"); // ערך לא יכול להיות מספר אחר
                }
                else
                {
                    rating = value;
                }
            }
        }
        public bool IsOrg { get => isOrg; set => isOrg = value; }

        public Social(string appName, int price, int rating, bool isOrg) : base(appName, price)
        {
            Rating = rating;
            IsOrg = isOrg;            
        }

        public void AddVAT(double VAT)
        {
            base.price += (int)(base.price * VAT);
        }

        public override string AppSystemPurpose()
        {
            return "Far away and talking close";
        }
    }
}
