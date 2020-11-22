using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty
{
    public class ThirdpartyConsts
    {
        #region datagrand
        /// <summary>
        /// 达观搜索签名参数名称
        /// </summary>
        public const string DataGrandSignParameterName = "sign";

        /// <summary>
        /// 达观搜索数据上报网关标识
        /// </summary>
        public const string DataGrandDataUploadGatewayIdentitifier = "/search";

        /// <summary>
        /// 达观搜索数据搜索网关标识
        /// </summary>
        public const string DataGrandDataSearchGatewayIdnentitifier = "/search/app";

        /// <summary>
        /// 达观搜索为Mo分配的数据存储表名
        /// </summary>
        public const string DataGrandDataTableName = "item";

        /// <summary>
        /// 达观搜索为Mo分配的用户行为存储表名
        /// </summary>
        public const string DataGrandUserBehaviorTableName = "user_action";

        /// <summary>
        /// 达观搜索为Mo分配的提示词存储表名
        /// </summary>
        public const string DataGrandSuggestTableName = "suggest";

        /// <summary>
        /// MO上报到达能搜索的角色类型
        /// </summary>
        public static readonly IReadOnlyList<string> Mo2DataGrandRoleTypes = new List<string>
        {
            "ReaderRole",
            "DestinationRole",
            "ProcessRole",
            "AuthRole"
        }.AsReadOnly();

        /// <summary>
        /// 流程模块访问Url模板
        /// </summary>
        public const string ProcessModuleListUrlTemplate = "/Home/ProcessCenter/ProcessPortal/ProcessList?procSetID={0}";

        /// <summary>
        /// 流程模块发起Url模板
        /// </summary>
        public const string ProcessModuleLaunchUrlTemplate = "/Auditing/Auditing/Index?AT={0}&PSID={1}";

        /// <summary>
        /// 功能(菜单)模块Url模板
        /// </summary>
        public const string FunctionModuleUrlTemplate = "/{0}";

        /// <summary>
        /// 扩展模块访问Url模板
        /// </summary>
        public const string ExtensionModuleListUriTemplate = "/Home/ProcessCenter/ProcessPortal/ProcessList?procSetID={0}&ProcSetDesc={1}&ExMenuFlowId={2}";

        /// <summary>
        /// 扩展模块发起Url模板
        /// </summary>
        public const string ExtensionModuleLaunchUriTemplate = "/Auditing/Auditing/Index?AT={0}&PSID={1}&ProcSetDisPlay={2}&ExMenuFlowId={3}";


        /// <summary>
        /// 处于发件箱中便签Uri模板
        /// </summary>
        public const string InternalMailInOutboxUriTemplate = "/Home/Mail/InternalMail/MailOutDetail?mailCode={0}";

        /// <summary>
        /// 处于草稿箱中的便签Uri模板
        /// </summary>
        public const string InternalMailInDraftboxUriTemplate = "/Home/Mail/InternalMail/SendMailIndex?mailCode={0}";

        /// <summary>
        /// 处于废纸篓中的收件箱便签Uri模板
        /// </summary>
        public const string InternalInboxMailThatInTrashboxUriTemplate = "/Home/Mail/InternalMail/MailTrashDetailInBox?mailcode={0}";

        /// <summary>
        /// 处于废纸篓中的发件箱便签Uri模板
        /// </summary>
        public const string InternalOutboxMailThatInTrashboxUriTemplate = "/Home/Mail/InternalMail/MailTrashDetailOutBox?mailcode={0}";

        /// <summary>
        /// 处于收件箱中的便签Uri模板
        /// </summary>
        public const string InternalMailInInboxUriTemplate = "/Home/Mail/InternalMail/MailInDetail?mailcode={0}";

        /// <summary>
        /// 达观搜索人员角色前缀
        /// 达观搜索人员角色 =观搜索人员角色前缀+ MO员工号
        /// </summary>
        public const string DataGrandUserPrefix = "u_";

        /// <summary>
        /// 达观搜索群组角色前缀
        /// 达观搜索群组角色 =达观搜索群组角色前缀+ MO角色编码
        /// </summary>
        public const string DataGrandGroupPrefix = "g_";

        /// <summary>
        /// 达观搜索部门角色前缀
        /// 达观搜索部门角色 =达观搜索部门角色前缀+ MO部门编码
        /// </summary>
        public const string DataGrandDepartmentPrefix = "d_";

        /// <summary>
        /// 达观搜索流程负责人(修改人)前缀
        /// 达观搜索流程负责人角色 =达观搜索流程负责人(修改人)前缀+ MO流程设置Id
        /// </summary>
        public const string DataGrandWorkflowProcessManagerPrefix = "a_";

        /// <summary>
        /// 达观搜索发文特殊读者前缀
        ///  达观搜索特殊读者角色 =达观搜索发文特殊读者前缀+ 部门编码
        /// </summary>
        public const string DataGrandArticleSpecialReaderPrefix = "s_";

        /// <summary>
        /// 达观搜索部门负责人前缀
        /// 达观搜索部门负责人角色 =达观搜索部门负责人前缀+ 部门编码
        /// </summary>
        public const string DataGrandDepartmentLeaderPrefix = "l_";

        /// <summary>
        /// 达观搜索流程模块Id前缀
        /// 达观搜索流程模块Id = 达观搜索流程模块Id前缀+ MO流程模块Id（ProcSetId）
        /// </summary>
        public const string DataGrandProcessModulePrefix = "p_";

        /// <summary>
        /// 达观搜索功能模块Id前缀
        /// 达观搜索功能模块Id = 达观搜索功能模块Id前缀+ MO功能模块Id（MenuId）
        /// </summary>
        public const string DataGrandFunctionModulePrefix = "f_";

        /// <summary>
        /// 达观搜索扩展模块Id前缀
        /// 达观搜索扩展模块Id = 达观搜索扩展模块Id前缀+ MO扩展模块Id（ExtensionMenuId）
        /// </summary>
        public const string DataGrandExtensionModulePrefix = "e_";

        /// <summary>
        /// 达观搜索收件箱便签Id前缀
        /// </summary>
        public const string DataGrandInboxMailPrefix = "i_";

        /// <summary>
        /// 达观搜索发件箱便签Id前缀
        /// </summary>
        public const string DataGrandOutboxMailPrefix = "o_";

        /// <summary>
        /// 达观搜索废纸篓便签Id前缀
        /// </summary>
        public const string DataGrandTrashboxMailPrefix = "t_";

        /// <summary>
        /// 达观搜索扩展模块提示Id前缀
        /// </summary>
        public const string DataGrandExtensionModuleSuggestionPrefix = "e_";

        /// <summary>
        /// 达观搜索流程模块提示Id前缀
        /// </summary>
        public const string DataGrandProcessModuleSuggestionPrefix = "p_";

        /// <summary>
        /// 达观搜索功能模块提示Id前缀
        /// </summary>
        public const string DataGrandFunctionModuleSuggestionPrefix = "f_";

        /// <summary>
        /// 达观搜索自定义提示Id前缀
        /// </summary>
        public const string DataGrandCustomSuggestionPrefix = "c_";

        /// <summary>
        /// 达观搜索英文ItemId前缀
        /// </summary>
        public const string DataGrandEnglishItemIdPrefix = "en_";

        /// <summary>
        /// 达观搜索中文ItemId前缀
        /// </summary>
        public const string DataGrandChineseItemIdPrefix = "cn_";

        /// <summary>
        /// 达观搜索纪元时间
        /// </summary>
        public static DateTime DataGrandEraTime => new DateTime(1970, 1, 1).AddHours(8);

        /// <summary>
        /// 达观搜索默认的每页记录条数
        /// </summary>
        public const int DefaultDataGrandPageSize = 20;
        #endregion

        #region esb
        /// <summary>
        /// Esb签名参数名称
        /// </summary>
        public const string EsbSignParameterName = "sign";
        #endregion


        #region otravel
        /// <summary>
        /// Otravel签名参数名称
        /// </summary>
        public const string OTravelParameterPassword = "password";
        #endregion

        #region ocsm
        /// <summary>
        /// Ocsm签名参数名称
        /// </summary>
        public const string OcsmSignParameterName = "sign";
        #endregion

        #region realme
        /// <summary>
        /// RealmeOpenApi签名参数名称
        /// </summary>
        public const string RealmeOpenApiSignParameterName = "sign";
        #endregion

        #region
        /// <summary>
        /// DiDiOpenApi签名参数名称
        /// </summary>
        public const string DiDiOpenApiSignParameterName = "sign";
        #endregion

        #region
        /// <summary>
        /// 飞鹤签名参数名称
        /// </summary>
        public const string FeiHeairSignParameterName = "appSecret";
        #endregion
    }
}
