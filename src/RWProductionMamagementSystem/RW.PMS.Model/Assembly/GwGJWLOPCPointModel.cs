namespace RW.PMS.Model.Assembly
{
    /// <summary>
    /// OPC点位实体类
    /// </summary>
    public class GwGJWLOPCPointModel
    {
        public string OPCDeviceName { get; set; }
        public string OPCTypeCode { get; set; }
        public string OPCValue { get; set; }
        public string Value { get { return OPCDeviceName + OPCValue; } }
        public string Remark { get; set; }
    }
}
