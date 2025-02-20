using LHJ.IService.IServices;
using LHJ.SqlSugarCore.Entities;
using LHJ.SqlSugarCore.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LHJ.WebHost.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class TrainPlanController : ControllerBase
{
    private readonly ITrainPlanService trainPlanService;

    public TrainPlanController(ITrainPlanService trainPlanService) { this.trainPlanService = trainPlanService; }

    [HttpPost(Name = "GetTrainPlan")]
    [Tags("获取审核计划信息")]
    public Task<ResponsePage<List<TrainPlanDto<List<TrainPlanDetail>>>>> GetTrainPlan(RequestData page)
    {
        return trainPlanService.GetTrainPlans(page);
    }
}
