using System;
using System.Collections.Generic;
using System.Text;
using TravelListAppG7.DataModel;

namespace TravelListAppG7.Domain
{
    public class DomainController
    {
        private static DomainController instance;
        public User user { get; set; }
        private DomainController() { }

        public static DomainController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DomainController();
                }
                return instance;
            }
        }
    }
}
