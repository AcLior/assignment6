﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment6
{
    interface IApp //ממשק שאחראי להוסיף מע"מ למחיר מוצר\שירות
    {
        void AddVAT(double VAT);
    }
}
