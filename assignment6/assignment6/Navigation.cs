using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment6
{
    class Navigation:AppSystem,IApp
    {
       
        NavigationManager nvMgr;

        public Navigation(string appName,int price,NavigationManager nvmgr):base( appName, price)
        {
            this.nvMgr = nvmgr;
        }

        public override string ToString()
        {
            return String.Format("Navigation manager: {0}", nvMgr);
            
        }

        public override string AppSystemPurpose()
        {
            return "Catch The Road-Choose The Best Way";
        }

        public void AddVAT(double VAT)
        {
            base.price += (int)(base.price * VAT);
        }
       

    }
}
