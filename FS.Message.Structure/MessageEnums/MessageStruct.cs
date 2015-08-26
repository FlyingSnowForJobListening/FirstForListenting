namespace FS.Message.Structure
{
    /// <summary>
    /// 申报类型:1-新增;2-变更;3-删除,默认为1
    /// </summary>
    public enum AppType
    {
        Add = 1,
        Update = 2,
        Delete = 3
    }
    /// <summary>
    /// 业务状态,1-暂存,2-申报,默认为1
    /// </summary>
    public enum AppStatus : int
    {
        Declare = 2,
        Storage = 1
    }
    /// <summary>
    /// 进出口标志,I/E标志
    /// </summary>
    public enum OrderType
    {
        I,
        E
    }
}
