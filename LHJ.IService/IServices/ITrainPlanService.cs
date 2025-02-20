using LHJ.SqlSugarCore.Entities;
using LHJ.SqlSugarCore.Model;

namespace LHJ.IService.IServices;

public interface ITrainPlanService : IBaseService<TrainPlan>
{
    /// <summary>
    /// 获取培训计划单信息
    /// </summary>
    /// <param name="page"></param>
    /// <returns></returns>
    Task<ResponsePage<List<TrainPlanDto<List<TrainPlanDetail>>>>> GetTrainPlans(RequestData page);
}
