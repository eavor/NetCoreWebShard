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
    [SugarTable("u_train_plan_b")]
    public class TrainPlanDetail
    {
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "ID")]
        public int Id { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "SeqID", IsPrimaryKey = true, IsIdentity = true)]
        public int SeqID { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "CourseID")]
        public int CourseID { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "ClassID")]
        public int ClassID { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "CourseName")]
        public string? CourseName { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "Channels")]
        public int Channels { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "DeptID")]
        public int DeptID { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "Examineway")]
        public int Examineway { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "PlanClasshour")]
        public int PlanClasshour { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "PlanTrainDate")]
        public DateTime? PlanTrainDate { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "Memo")]
        public string? Memo { get; set; }
    }
}
