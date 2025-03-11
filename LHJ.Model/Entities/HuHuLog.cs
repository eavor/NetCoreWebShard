using SqlSugar;


namespace LHJ.SqlSugarCore.Entities;

[SugarTable("Log")]
public class HuHuLog
{
    /// <summary>
    /// 主键 
    ///</summary>
    [SugarColumn(ColumnName = "Id", IsPrimaryKey = true, IsIdentity = true)]
    public int Id { get; set; }
    /// <summary>
    /// 创建日期 
    ///</summary>
    [SugarColumn(ColumnName = "CreateDate")]
    public DateTime? CreateDate { get; set; }
    /// <summary>
    /// 描述 
    ///</summary>
    [SugarColumn(ColumnName = "Desc")]
    public string Desc { get; set; }
}
