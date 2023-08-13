namespace MDM.Common.EntityFactory
{
    [AttributeUsage(AttributeTargets.Class)]
    public class InjectContextAttribute : Attribute
    {
        public InjectContextAttribute()
        {
            
        }
    }
}
