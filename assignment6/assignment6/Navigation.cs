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

        public NavigationManager NvMgr { get { return nvMgr; } }
        public override string ToString()
        {
            return base.ToString()+String.Format("\nNavigation manager: {0}\n", nvMgr);
            
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
