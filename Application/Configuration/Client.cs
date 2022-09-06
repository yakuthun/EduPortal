﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Configuration
{
    public class Client
    {//bu client AuthServer'a istek yapacak uygulamalara karşılık gelir.
        public string Id { get; set; }
        public string Secret { get; set; }
        public List<String> Audiences { get; set; }
        //keni iç mekanizmasında bu client. API'lerden hangilerine erişecek bunu tutar
        //www.myap1.com www.myapi2.com'a erişebilir gibi.
    }
}
