using AutoMapper;
using Com.OPPO.Mo.Bpm.ActionSoft;
using Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects;
using Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Dtos;
using Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Requests;
using Com.OPPO.Mo.Bpm.ActionSoft.Metadatas.Dtos;
using Com.OPPO.Mo.Bpm.ActionSoft.Metadatas.Requests;
using Com.OPPO.Mo.Bpm.ActionSoft.Processes.Dtos;
using Com.OPPO.Mo.Bpm.ActionSoft.Processes.Requests;
using Com.OPPO.Mo.Bpm.ActionSoft.Processes.Responses;
using Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Dtos;
using Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Requests;
using Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Responses;
using Com.OPPO.Mo.Bpm.Dtos;
using Com.OPPO.Mo.Bpm.Etos;
using System.Runtime;

namespace Com.OPPO.Mo.Bpm
{
    public class MoBpmApplicationAutoMapperProfile : Profile
    {
        public MoBpmApplicationAutoMapperProfile()
        {
            //业务对象
            CreateMap<ActionSoftBusinessObjectBatchCreateInput, ActionSoftBusinessObjectBatchCreateRequest>(MemberList.Source);
            CreateMap<ActionSoftBusinessObjectCreateInput, ActionSoftBusinessObjectCreateRequest>(MemberList.Source);
            CreateMap<ActionSoftBusinessObjectGetInput, ActionSoftBusinessObjectGetRequest>(MemberList.Source);
            CreateMap<ActionSoftBusinessObjectQueryInput, ActionSoftBusinessObjectQueryRequest>(MemberList.Source);
            CreateMap<ActionSoftBusinessObjectDeleteByIdInput, ActionSoftBusinessObjectDeleteByIdRequest>(MemberList.Source);
            CreateMap<ActionSoftBusinessObjectDeleteByProcessInput, ActionSoftBusinessObjectDeleteByProcessRequest>(MemberList.Source);
            CreateMap<ActionSoftBusinessObjectFieldUpdateByProcessInput, ActionSoftBusinessObjectFieldUpdateByProcessRequest>(MemberList.Source);
            CreateMap<ActionSoftBusinessObjectFieldBatchUpdateInput, ActionSoftBusinessObjectFieldBatchUpdateRequest>(MemberList.Source);
            CreateMap<ActionSoftBusinessObjectFieldGetInput, ActionSoftBusinessObjectFieldGetRequest>(MemberList.Source);

            //业务附件
            CreateMap<ActionSoftBusinessObjectAttachmentInfoInput, ActionSoftBusinessObjectAttachmentInfo>(MemberList.Source);
            CreateMap<ActionSoftBusinessObjectAttachmentInfo, ActionSoftBusinessObjectAttachmentInfoDto>(MemberList.Source);
            CreateMap<ActionSoftBusinessObjectAttachmentData, ActionSoftBusinessObjectAttachmentDataDto>(MemberList.Source);
            CreateMap<ActionSoftBusinessObjectAttachmentInfosGetInput, ActionSoftBusinessObjectAttachmentInfosGetRequest>(MemberList.Source);
            CreateMap<ActionSoftBusinessObjectAttachmentRemoveInput, ActionSoftBusinessObjectAttachmentsRemoveRequest>(MemberList.Source);

            //流程
            CreateMap<ActionSoftProcessCancelInput, ActionSoftProcessCancelRequest>(MemberList.None);
            CreateMap<ActionSoftProcessCreateInput, ActionSoftProcessCreateRequest>(MemberList.Source)
                .ForSourceMember(x => x.ActivityApprovers, y => y.DoNotValidate());
            CreateMap<ActionSoftProcessCreateAndStartInput, ActionSoftProcessCreateRequest>(MemberList.None)
                .ForSourceMember(x => x.ActivityApprovers, y => y.DoNotValidate()); ;
            CreateMap<ActionSoftProcessDeleteInput, ActionSoftProcessDeleteRequest>(MemberList.None);
            CreateMap<ActionSoftProcessPageQueryInput, ActionSoftProcessQueryModel>(MemberList.Destination);
            CreateMap<ActionSoftProcessQueryInput, ActionSoftProcessQueryModel>(MemberList.Source);
            CreateMap<ActionSoftProcessInfo, ActionSoftProcessDto>(MemberList.Destination);
            CreateMap<ActionSoftProcessInfo, ActionSoftSimplifiedProcessDto>(MemberList.Destination);
            CreateMap<ActionSoftProcessVarBatchSetInput, ActionSoftProcessVarBatchSetRequest>(MemberList.Source);
            CreateMap<ActionSoftSpecifiedProcessVarSetInput, ActionSoftSpecifiedProcessVarSetRequest>(MemberList.Source);
            CreateMap<ActionSoftProcessCountGetInput, ActionSoftProcessQueryModel>(MemberList.Source);
            CreateMap<ActionSoftTaskCommentInfo, ActionSoftTaskCommentInfoDto>(MemberList.Source);

            //任务
            CreateMap<ActionSoftTaskInfo, ActionSoftTaskDto>(MemberList.Destination);
            CreateMap<ActionSoftHistoryTaskInfo, ActionSoftHistoryTaskDto>(MemberList.Destination);
            CreateMap<ActionSoftTaskExecutionResultInfo, ActionSoftTaskExecuteResultDto>(MemberList.Destination);
            CreateMap<ActionSoftTaskInfo, ActionSoftSimplifiedTaskDto>(MemberList.Destination);
            CreateMap<ActionSoftEaiTaskInfo, ActionSoftEaiTaskDto>(MemberList.Destination);
            CreateMap<ActionSoftTaskCountGetInput, ActionSoftTaskQueryModel>(MemberList.Source);
            CreateMap<ActionSoftTaskQueryInput, ActionSoftTaskQueryModel>(MemberList.Source);
            CreateMap<ActionSoftHistoryTaskQueryInput, ActionSoftTaskQueryModel>(MemberList.Source);
            CreateMap<ActionSoftTaskPageQueryInput, ActionSoftTaskQueryModel>(MemberList.Destination);
            CreateMap<ActionSoftHistoryTaskPageQueryInput, ActionSoftTaskQueryModel>(MemberList.Destination);
            CreateMap<ActionSoftEaiTaskExtensionInfoDto, ActionSoftEaiTaskExtensionInfo>(MemberList.Source);
            CreateMap<ActionSoftEaiTaskActionParameterInfoDto, ActionSoftEaiTaskActionParameterInfo>(MemberList.Source);
            CreateMap<ActionSoftEaiTaskCreateInput, ActionSoftEaiTaskCreateRequest>(MemberList.Source);
            CreateMap<ActionSoftTaskCompleteInput, ActionSoftTaskCompleteRequest>(MemberList.Source);
            CreateMap<ActionSoftTaskRecordCommitInput, ActionSoftTaskRecordCommitRequest>(MemberList.Source)
                .ForMember(destination => destination.Action, opitons => opitons.MapFrom((x, y) => { return y.Action = x.Action.Description(); }));
            CreateMap<ActionSoftTaskPredictInfo, ActionSoftTaskPredictInfoDto>(MemberList.Destination);
            CreateMap<ActionSoftTaskSimulateInput, ActionSoftTaskSimulateRequest>(MemberList.Source);
            CreateMap<ActionSoftTaskSimulationInfo, ActionSoftTaskSimulationInfoDto>(MemberList.Destination);
            CreateMap<ActionSoftTaskParticipantsGetInput, ActionSoftTaskParticipantsGetRequest>(MemberList.Source);
            CreateMap<ActionSoftCirculationTaskCreateInput, ActionSoftCirculationTaskCreateRequest>(MemberList.Source);

            //元数据
            CreateMap<ActionSoftUserTaskDefinitionGetInput, ActionSoftUserTaskDefinitionGetRequest>(MemberList.Source);

            //Bpm开放平台
            CreateMap<ProcessLaunchPermission, ProcessLaunchPermissionDto>(MemberList.Destination);
            CreateMap<ProcessLaunchPermissionGrantInput, ProcessLaunchPermission>(MemberList.Source);

            CreateMap<BusinessObjectTablePermission, BusinessObjectTablePermissionDto>(MemberList.Destination);
            CreateMap<BusinessObjectTablePermissionGrantInput, BusinessObjectTablePermission>(MemberList.Source);

            CreateMap<ProcessInstanceBelong, ProcessInstanceBelongDto>(MemberList.Destination);
            CreateMap<EaiTaskInstanceBelong, EaiTaskInstanceBelongDto>(MemberList.Destination);

            CreateMap<BusinessObjectBelong, BusinessObjectBelongDto>(MemberList.Destination);

            CreateMap<TaskCallbackConfigurationAddInput, TaskCallbackConfiguration>(MemberList.Source)
                .ForMember(destination => destination.Action, opitons => opitons.MapFrom((x, y) => { return y.Action = x.Action.Description(); }));
            CreateMap<TaskCallbackConfiguration, TaskCallbackConfigurationDto>(MemberList.Destination);
            CreateMap<ProcessCallbackConfigurationAddInput, ProcessCallbackConfiguration>(MemberList.Source);
            CreateMap<ProcessCallbackConfiguration, ProcessCallbackConfigurationDto>(MemberList.Destination);

            CreateMap<ProcessInstanceInfo, ProcessInstanceInfoDto>().ReverseMap();
            CreateMap<ProcessDefinitionInfo, ProcessDefinitionInfoDto>().ReverseMap();
            CreateMap<TaskDefinitionInfo, TaskDefinitionInfoDto>().ReverseMap();
            CreateMap<OperatorInfo, OperatorInfoDto>().ReverseMap();
            CreateMap<TargetUserInfo, TargetUserInfoDto>().ReverseMap();
            CreateMap<TaskEventMessage, TaskEventMessageDto>(MemberList.Destination);
            CreateMap<TaskEventMessageAddInput, TaskEventMessage>(MemberList.Source);
            CreateMap<ProcessEventMessage, ProcessEventMessageDto>(MemberList.Destination);
            CreateMap<ProcessEventMessageAddInput, ProcessEventMessage>(MemberList.Source);

            CreateMap<ProcessEventMessage, ProcessEventMessageEto>(MemberList.Destination);
            CreateMap<TaskEventMessage, TaskEventMessageEto>(MemberList.Destination);
            CreateMap<ProcessInstanceInfo, ProcessInstanceInfoEto>(MemberList.Destination);
            CreateMap<OperatorInfo, OperatorInfoEto>(MemberList.Destination);
            CreateMap<TargetUserInfo, TargetUserInfoEto>(MemberList.Destination);
            CreateMap<ProcessDefinitionInfo, ProcessDefinitionInfoEto>(MemberList.Destination);
            CreateMap<TaskDefinitionInfo, TaskDefinitionInfoEto>(MemberList.Destination);
        }
    }
}
