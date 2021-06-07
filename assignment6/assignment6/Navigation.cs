using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment6
{
    class Navigation:AppSystem,IApp // יורשת מ-AppSystem
        // משתמשת בממשק שיצרנו
    {
       
        NavigationManager nvMgr; // שדה שמייצג מנהל ניווט

        public Navigation(string appName,int price,NavigationManager nvmgr):base( appName, price) // בנאי
        {
            this.nvMgr = nvmgr;
        }

        public NavigationManager NvMgr { get { return nvMgr; } }
        public override string ToString() // דריסת מתודה טו-סטרינג
        {
            return base.ToString()+String.Format("\nNavigation manager: {0}\n", nvMgr);
            
        }

        public override string AppSystemPurpose() // מימוש המתודה האבסטרקטית בהתאם לאפליקציית הניווט
        {
            return "Catch The Road-Choose The Best Way";
        }

        public void AddVAT(double VAT) // הוספת מע"מ
        {
            base.price += (int)(base.price * VAT);
        }
       

    }
}
