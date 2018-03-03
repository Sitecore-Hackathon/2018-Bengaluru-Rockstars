using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Feature.ServiceAPI
{
    public struct Templates
    {
        public struct Intent
        {
            public static readonly ID ID = new ID("{CC5169F0-10F1-4665-8DC4-3E2A6852D52C}");

            public struct Fields
            {
                public static readonly ID IntentText = new ID("{159148DE-ED5A-4EDB-A9B0-08139B54F6B6}");
                public static readonly ID Goal = new ID("{37706AB9-CB22-498C-995B-0332FFD33DF9}");
               
            }
        }
    }
}