using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHJ.SqlSugarCore.Entities
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("u_train_plan")]
    public class TrainPlan
    {
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "ID", IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "Code")]
        public string? Code { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "BillState")]
        public int BillState { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "BillDate")]
        public DateTime BillDate { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "BillType")]
        public int BillType { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "CompanyID")]
        public int CompanyID { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "CreateDeptID")]
        public int CreateDeptID { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "PlanCompleteTime")]
        public DateTime? PlanCompleteTime { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "CreateID")]
        public int CreateID { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "CreateTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "MakeID")]
        public int? MakeID { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "MakeTime")]
        public DateTime? MakeTime { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "CheckID")]
        public int? CheckID { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "CheckTime")]
        public DateTime? CheckTime { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "RatifyID")]
        public int? RatifyID { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "RatifyTime")]
        public DateTime? RatifyTime { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "CompleteID")]
        public int? CompleteID { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "CompleteTime")]
        public DateTime? CompleteTime { get; set; }
    }
}
