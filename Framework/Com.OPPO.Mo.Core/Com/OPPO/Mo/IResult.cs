namespace Com.OPPO.Mo
{
    /// <summary>
    /// ���ؽ��
    /// </summary>
    public interface IResult
    {
        /// <summary>
        /// ���״̬��
        /// </summary>
        ResultCode Code { get; set; }

        /// <summary>
        /// ��ʾ��Ϣ
        /// </summary>
        /// <example>�����ɹ�</example>
        string Msg { get; set; }

        /// <summary>
        /// �Ƿ�ɹ�
        /// </summary>
        bool IsSuccess { get; }
    }

    /// <summary>
    /// ���ؽ��
    /// </summary>
    public interface IResult<TData> : IResult
    {
        /// <summary>
        /// ���״̬��
        /// </summary>
        TData Data { get; set; }
    }
}