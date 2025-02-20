using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHJ.SqlSugarCore.Model;

public class ResponsePage<T>
{
    public string? msg { get; set; } = "OK";
    public int code { get; set; } = 200;
    public T? data { get; set; }
    public int totalNumber { get; set; }
}

public class TrainPlanDto<T> where T : class, new()
{
    public int id { get; set; }

    public string? code { get; set; }

    public int companyId { get; set; }

    public int createID { get; set; }

    public string? createName { get; set; }

    public DateTime? createTime { get; set; }

    public int billState { get; set; }

    public T details { get; set; } = new();
}