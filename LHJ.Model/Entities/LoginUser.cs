using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHJ.SqlSugarCore.Entities;

/// <summary>
/// 
///</summary>
[SugarTable("u_login_user")]

public class LoginUser
{

    /// <summary>
    ///  
    ///</summary>
    [SugarColumn(ColumnName = "UserID", IsPrimaryKey = true, IsIdentity = true)]
    public int UserID { get; set; }
    /// <summary>
    ///  
    ///</summary>
    [SugarColumn(ColumnName = "UserCode")]
    public string? UserCode { get; set; }
    /// <summary>
    ///  
    ///</summary>
    [SugarColumn(ColumnName = "UserName")]
    public string? UserName { get; set; }
    /// <summary>
    ///  
    ///</summary>
    [SugarColumn(ColumnName = "Tel")]
    public string? Tel { get; set; }
    /// <summary>
    ///  
    ///</summary>
    [SugarColumn(ColumnName = "PassWord")]
    public string? PassWord { get; set; }
    /// <summary>
    ///  
    ///</summary>
    [SugarColumn(ColumnName = "CreateTime")]
    public DateTime CreateTime { get; set; }
    /// <summary>
    ///  
    ///</summary>
    [SugarColumn(ColumnName = "CreateID")]
    public int CreateID { get; set; }
    /// <summary>
    ///  
    ///</summary>
    [SugarColumn(ColumnName = "ShopID")]
    public int? ShopID { get; set; }
    /// <summary>
    ///  
    ///</summary>
    [SugarColumn(ColumnName = "CompanyID")]
    public int CompanyID { get; set; }
    /// <summary>
    ///  
    ///</summary>
    [SugarColumn(ColumnName = "IsAdmin")]
    public bool IsAdmin { get; set; }
    /// <summary>
    ///  
    ///</summary>
    [SugarColumn(ColumnName = "SuperAdmin")]
    public bool SuperAdmin { get; set; }
    /// <summary>
    ///  
    ///</summary>
    [SugarColumn(ColumnName = "Effective")]
    public bool Effective { get; set; }
    /// <summary>
    ///  
    ///</summary>
    [SugarColumn(ColumnName = "ModifyTime")]
    public DateTime? ModifyTime { get; set; }
    /// <summary>
    ///  
    ///</summary>
    [SugarColumn(ColumnName = "UserImg")]
    public string? UserImg { get; set; }
    /// <summary>
    ///  
    ///</summary>
    [SugarColumn(ColumnName = "OpenID")]
    public string? OpenID { get; set; }
}
