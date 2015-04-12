namespace Sandbox.Domain.Models
{
    public class ContractRateOption : ValueObject<int>
    {
        public virtual string Name { get; set; }
    }
}