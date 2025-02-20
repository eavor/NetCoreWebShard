using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHJ.SqlSugarCore.Model
{
    public class RequestPage
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
    }

    public class RequestData
    {
        public RequestPage? page { get; set; }
        public int  companyId { get; set; }
    }

}
