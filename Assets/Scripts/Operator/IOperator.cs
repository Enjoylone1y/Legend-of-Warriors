
public interface IOperator
{
    public enum OperatorType
    {
        Box,Entrance
    }

    public OperatorType type { get; set; }

    public void triggerOperate();
}
