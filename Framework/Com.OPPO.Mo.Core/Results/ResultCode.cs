using System.ComponentModel.DataAnnotations;

namespace Com.OPPO.Mo
{
    /// <summary>
    ///���״̬��
    /// </summary>
    public enum ResultCode
    {
        /// <summary>
        /// �����ɹ�
        ///</summary>
        [Display(Name = "�����ɹ�", GroupName = Result.Successfull)]
        Ok = MoConsts.BaseResultCode + 0,

        /// <summary>
        /// ����ʧ��
        ///</summary>
        [Display(Name = "����ʧ��")]
        Fail = MoConsts.BaseResultCode + 1,

        /// <summary>
        /// �������쳣
        ///</summary>
        [Display(Name = "�����쳣")]
        ServerError = MoConsts.BaseResultCode + 10,

        /// <summary>
        /// δ��֤
        ///</summary>
        [Display(Name = "δ��֤")]
        Unauthencatied = MoConsts.BaseResultCode + 20,

        /// <summary>
        /// δ��Ȩ
        ///</summary>
        [Display(Name = "δ��Ȩ")]
        Unauthorized = MoConsts.BaseResultCode+30,

        /// <summary>
        /// ��ֹ����
        /// </summary>
        [Display(Name = "��ֹ����")]
        Forbidden = MoConsts.BaseResultCode + 40,

        /// <summary>
        /// Token ��֤ʧ��
        /// </summary>
        [Display(Name = "��ЧToken")]
        InvalidToken = MoConsts.BaseResultCode + 50,

        /// <summary>
        /// ǩ����֤ʧ��
        /// </summary>
        [Display(Name = "ǩ����֤ʧ��")]
        InvalidSign = MoConsts.BaseResultCode + 100,

        /// <summary>
        /// ������֤ʧ��
        /// </summary>
        [Display(Name = "������֤ʧ��")]
        InvalidParams = MoConsts.BaseResultCode + 200,

        /// <summary>
        /// û������
        ///</summary>
        [Display(Name = "û������")]
        NoData = MoConsts.BaseResultCode + 404,

        /// <summary>
        /// �����ظ�
        /// </summary>
        [Display(Name = "�����ظ�")]
        DuplicateData = MoConsts.BaseResultCode + 405,

        /// <summary>
        /// �ؼ�����ȱʧ
        /// </summary>
        [Display(Name = "�ؼ�����ȱʧ")]
        MissEssentialData = MoConsts.BaseResultCode + 406,
    }
}